using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeAssemblyPipelineEventActions : PipelineEventActions<Func<BeforeAssemblyPipelineExecutionContext, CancellationToken, Task>, Action<BeforeAssemblyPipelineExecutionContext>, BeforeAssemblyPipelineExecutionContext>
    {
        protected override Func<BeforeAssemblyPipelineExecutionContext, CancellationToken, Task> MakeAsync(Action<BeforeAssemblyPipelineExecutionContext> action)
            => new Func<BeforeAssemblyPipelineExecutionContext, CancellationToken, Task>((ctx, ct) =>
            {
                action.Invoke(ctx);
                return Task.FromResult<object>(null);
            });

        protected override Action<BeforeAssemblyPipelineExecutionContext> MakeSync(Func<BeforeAssemblyPipelineExecutionContext, CancellationToken, Task> action)
           => new Action<BeforeAssemblyPipelineExecutionContext>(ctx => action.Invoke(ctx, CancellationToken.None).GetAwaiter().GetResult());
    }
}
