using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeDeletePipelineEventActions : PipelineEventActions<Func<BeforeDeletePipelineExecutionContext, CancellationToken, Task>, Action<BeforeDeletePipelineExecutionContext>, BeforeDeletePipelineExecutionContext>
    {
        protected override Func<BeforeDeletePipelineExecutionContext, CancellationToken, Task> MakeAsync(Action<BeforeDeletePipelineExecutionContext> action)
            => new Func<BeforeDeletePipelineExecutionContext, CancellationToken, Task>((ctx, ct) =>
            {
                action.Invoke(ctx);
                return Task.FromResult<object>(null);
            });

        protected override Action<BeforeDeletePipelineExecutionContext> MakeSync(Func<BeforeDeletePipelineExecutionContext, CancellationToken, Task> action)
           => new Action<BeforeDeletePipelineExecutionContext>(ctx => action.Invoke(ctx, CancellationToken.None).GetAwaiter().GetResult());
    }
}