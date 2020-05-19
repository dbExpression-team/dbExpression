using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeAssemblyPipelineEventActions : PipelineEventActions<Func<BeforeAssemblyContext, CancellationToken, Task>, Action<BeforeAssemblyContext>, BeforeAssemblyContext>
    {
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
