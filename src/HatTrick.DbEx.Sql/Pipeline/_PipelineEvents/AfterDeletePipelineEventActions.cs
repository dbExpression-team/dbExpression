using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterDeletePipelineEventActions : PipelineEventActions<Func<AfterDeletePipelineExecutionContext, CancellationToken, Task>, Action<AfterDeletePipelineExecutionContext>, AfterDeletePipelineExecutionContext>
    {
        protected override Func<AfterDeletePipelineExecutionContext, CancellationToken, Task> MakeAsync(Action<AfterDeletePipelineExecutionContext> action)
            => new Func<AfterDeletePipelineExecutionContext, CancellationToken, Task>((ctx, ct) =>
            {
                action.Invoke(ctx);
                return Task.FromResult<object>(null);
            });

        protected override Action<AfterDeletePipelineExecutionContext> MakeSync(Func<AfterDeletePipelineExecutionContext, CancellationToken, Task> action)
           => new Action<AfterDeletePipelineExecutionContext>(ctx => action.Invoke(ctx, CancellationToken.None).GetAwaiter().GetResult());
    }
}