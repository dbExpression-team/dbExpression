using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeAssemblyPipelineEvent : PipelineEventActions<Func<BeforeAssemblyContext, CancellationToken, Task>, Action<BeforeAssemblyContext>>
    {
        public async Task InvokeAsync(IPipelineExecutionContext context, CancellationToken ct)
            => await InvokeAsync(context as BeforeAssemblyContext, ct);

        public void Invoke(IPipelineExecutionContext context)
            => Invoke(context as BeforeAssemblyContext);

        public async Task InvokeAsync(BeforeAssemblyContext context, CancellationToken cancellationToken)
        {
            foreach (var action in AsyncActions)
            {
                await action.Invoke(context, cancellationToken).ConfigureAwait(false);
            }
        }

        public void Invoke(BeforeAssemblyContext context)
        {
            foreach (var action in SyncActions)
            {
                action.Invoke(context);
            }
        }

        protected override Func<BeforeAssemblyContext, CancellationToken, Task> MakeAsync(Action<BeforeAssemblyContext> action)
            => new Func<BeforeAssemblyContext, CancellationToken, Task>((ctx, ct) =>
            {
                action.Invoke(ctx);
                return Task.FromResult<object>(null);
            });

        protected override Action<BeforeAssemblyContext> MakeSync(Func<BeforeAssemblyContext, CancellationToken, Task> action)
           => new Action<BeforeAssemblyContext>(ctx => action.Invoke(ctx, CancellationToken.None).GetAwaiter().GetResult());
    }
}
