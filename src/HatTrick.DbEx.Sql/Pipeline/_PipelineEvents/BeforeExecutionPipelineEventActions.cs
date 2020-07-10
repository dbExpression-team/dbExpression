using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeExecutionPipelineEventActions : PipelineEventActions<Func<BeforeExecutionPipelineExecutionContext, CancellationToken, Task>, Action<BeforeExecutionPipelineExecutionContext>, BeforeExecutionPipelineExecutionContext>
    {
        protected override Func<BeforeExecutionPipelineExecutionContext, CancellationToken, Task> MakeAsync(Action<BeforeExecutionPipelineExecutionContext> action)
            => new Func<BeforeExecutionPipelineExecutionContext, CancellationToken, Task>((ctx, ct) =>
            {
                action.Invoke(ctx);
                return Task.FromResult<object>(null);
            });

        protected override Action<BeforeExecutionPipelineExecutionContext> MakeSync(Func<BeforeExecutionPipelineExecutionContext, CancellationToken, Task> action)
           => new Action<BeforeExecutionPipelineExecutionContext>(ctx => action.Invoke(ctx, CancellationToken.None).GetAwaiter().GetResult());
    }
}
