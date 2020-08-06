using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeSelectPipelineEventActions : PipelineEventActions<Func<BeforeSelectPipelineExecutionContext, CancellationToken, Task>, Action<BeforeSelectPipelineExecutionContext>, BeforeSelectPipelineExecutionContext>
    {
        protected override Func<BeforeSelectPipelineExecutionContext, CancellationToken, Task> MakeAsync(Action<BeforeSelectPipelineExecutionContext> action)
            => new Func<BeforeSelectPipelineExecutionContext, CancellationToken, Task>((ctx, ct) =>
            {
                action.Invoke(ctx);
                return Task.FromResult<object>(null);
            });

        protected override Action<BeforeSelectPipelineExecutionContext> MakeSync(Func<BeforeSelectPipelineExecutionContext, CancellationToken, Task> action)
           => new Action<BeforeSelectPipelineExecutionContext>(ctx => action.Invoke(ctx, CancellationToken.None).GetAwaiter().GetResult());
    }
}