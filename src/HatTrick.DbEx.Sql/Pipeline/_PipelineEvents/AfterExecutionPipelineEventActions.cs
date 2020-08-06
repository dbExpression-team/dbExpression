using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterExecutionPipelineEventActions : PipelineEventActions<Func<AfterExecutionPipelineExecutionContext, CancellationToken, Task>, Action<AfterExecutionPipelineExecutionContext>, AfterExecutionPipelineExecutionContext>
    {
        protected override Func<AfterExecutionPipelineExecutionContext, CancellationToken, Task> MakeAsync(Action<AfterExecutionPipelineExecutionContext> action)
            => new Func<AfterExecutionPipelineExecutionContext, CancellationToken, Task>((ctx, ct) =>
            {
                action.Invoke(ctx);
                return Task.FromResult<object>(null);
            });

        protected override Action<AfterExecutionPipelineExecutionContext> MakeSync(Func<AfterExecutionPipelineExecutionContext, CancellationToken, Task> action)
           => new Action<AfterExecutionPipelineExecutionContext>(ctx => action.Invoke(ctx, CancellationToken.None).GetAwaiter().GetResult());
    }
}
