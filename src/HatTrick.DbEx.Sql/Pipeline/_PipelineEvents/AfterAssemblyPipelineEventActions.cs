using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterAssemblyPipelineEventActions : PipelineEventActions<Func<AfterAssemblyContext, CancellationToken, Task>, Action<AfterAssemblyContext>, AfterAssemblyContext>
    {
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
