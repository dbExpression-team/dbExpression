using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterAssemblyPipelineEventActions : PipelineEventActions<Func<AfterAssemblyPipelineExecutionContext, CancellationToken, Task>, Action<AfterAssemblyPipelineExecutionContext>, AfterAssemblyPipelineExecutionContext>
    {
        protected override Func<AfterAssemblyPipelineExecutionContext, CancellationToken, Task> MakeAsync(Action<AfterAssemblyPipelineExecutionContext> action)
            => new Func<AfterAssemblyPipelineExecutionContext, CancellationToken, Task>((ctx, ct) =>
            {
                action.Invoke(ctx);
                return Task.FromResult<object>(null);
            });

        protected override Action<AfterAssemblyPipelineExecutionContext> MakeSync(Func<AfterAssemblyPipelineExecutionContext, CancellationToken, Task> action)
           => new Action<AfterAssemblyPipelineExecutionContext>(ctx =>action.Invoke(ctx, CancellationToken.None).GetAwaiter().GetResult());
    }
}
