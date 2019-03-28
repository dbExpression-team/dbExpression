using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterInsertPipeline : PipelinePair<Func<AfterInsertContext, CancellationToken, Task>, Action<AfterInsertContext>>
    {
        public async Task InvokeAsync(IPipelineExecutionContext context, CancellationToken ct)
            => await InvokeAsync(context as AfterInsertContext, ct);

        public void Invoke(IPipelineExecutionContext context)
            => Invoke(context as AfterInsertContext);

        public async Task InvokeAsync(AfterInsertContext context, CancellationToken cancellationToken)
        {
            foreach (var action in AsyncActions)
            {
                await action.Invoke(context, cancellationToken).ConfigureAwait(false);
            }
        }

        public void Invoke(AfterInsertContext context)
        {
            foreach (var action in SyncActions)
            {
                action.Invoke(context);
            }
        }

        protected override Func<AfterInsertContext, CancellationToken, Task> MakeAsync(Action<AfterInsertContext> action)
            => new Func<AfterInsertContext, CancellationToken, Task>((ctx, ct) =>
            {
                action.Invoke(ctx);
                return Task.FromResult<object>(null);
            });

        protected override Action<AfterInsertContext> MakeSync(Func<AfterInsertContext, CancellationToken, Task> action)
           => new Action<AfterInsertContext>(ctx => action.Invoke(ctx, CancellationToken.None).GetAwaiter().GetResult());
    }
}