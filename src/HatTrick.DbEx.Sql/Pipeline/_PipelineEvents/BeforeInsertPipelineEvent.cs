using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeInsertPipelineEvent : PipelineEventActions<Func<BeforeInsertContext, CancellationToken, Task>, Action<BeforeInsertContext>>
    {
        public async Task InvokeAsync(IPipelineExecutionContext context, CancellationToken ct)
            => await InvokeAsync(context as BeforeInsertContext, ct);

        public void Invoke(IPipelineExecutionContext context)
            => Invoke(context as BeforeInsertContext);

        public async Task InvokeAsync(BeforeInsertContext context, CancellationToken cancellationToken)
        {
            foreach (var action in AsyncActions)
            {
                await action.Invoke(context, cancellationToken).ConfigureAwait(false);
            }
        }

        public void Invoke(BeforeInsertContext context)
        {
            foreach (var action in SyncActions)
            {
                action.Invoke(context);
            }
        }

        protected override Func<BeforeInsertContext, CancellationToken, Task> MakeAsync(Action<BeforeInsertContext> action)
            => new Func<BeforeInsertContext, CancellationToken, Task>((ctx, ct) =>
            {
                action.Invoke(ctx);
                return Task.FromResult<object>(null);
            });

        protected override Action<BeforeInsertContext> MakeSync(Func<BeforeInsertContext, CancellationToken, Task> action)
           => new Action<BeforeInsertContext>(ctx => action.Invoke(ctx, CancellationToken.None).GetAwaiter().GetResult());
    }
}