using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterAssemblyPipeline : PipelinePair<Func<AfterAssemblyContext, CancellationToken, Task>, Action<AfterAssemblyContext>>
    {
        public async Task InvokeAsync(IPipelineExecutionContext context, CancellationToken ct)
            => await InvokeAsync(context as AfterAssemblyContext, ct);

        public void Invoke(IPipelineExecutionContext context)
            => Invoke(context as AfterAssemblyContext);

        public async Task InvokeAsync(AfterAssemblyContext context, CancellationToken cancellationToken)
        {
            foreach (var action in AsyncActions)
            {
                await action.Invoke(context, cancellationToken).ConfigureAwait(false);
            }
        }

        public void Invoke(AfterAssemblyContext context)
        {
            foreach (var action in SyncActions)
            {
                action.Invoke(context);
            }
        }

        protected override Func<AfterAssemblyContext, CancellationToken, Task> MakeAsync(Action<AfterAssemblyContext> action)
            => new Func<AfterAssemblyContext, CancellationToken, Task>((ctx, ct) =>
            {
                action.Invoke(ctx);
                return Task.FromResult<object>(null);
            });

        protected override Action<AfterAssemblyContext> MakeSync(Func<AfterAssemblyContext, CancellationToken, Task> action)
           => new Action<AfterAssemblyContext>(ctx =>action.Invoke(ctx, CancellationToken.None).GetAwaiter().GetResult());
    }
}
