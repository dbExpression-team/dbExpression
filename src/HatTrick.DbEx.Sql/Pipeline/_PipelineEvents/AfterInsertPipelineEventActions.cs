using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterInsertPipelineEventActions : PipelineEventActions<Func<AfterInsertPipelineExecutionContext, CancellationToken, Task>, Action<AfterInsertPipelineExecutionContext>, AfterInsertPipelineExecutionContext>
    {
        protected override Func<AfterInsertPipelineExecutionContext, CancellationToken, Task> MakeAsync(Action<AfterInsertPipelineExecutionContext> action)
            => new Func<AfterInsertPipelineExecutionContext, CancellationToken, Task>((ctx, ct) =>
            {
                action.Invoke(ctx);
                return Task.FromResult<object>(null);
            });

        protected override Action<AfterInsertPipelineExecutionContext> MakeSync(Func<AfterInsertPipelineExecutionContext, CancellationToken, Task> action)
           => new Action<AfterInsertPipelineExecutionContext>(ctx => action.Invoke(ctx, CancellationToken.None).GetAwaiter().GetResult());
    }
}