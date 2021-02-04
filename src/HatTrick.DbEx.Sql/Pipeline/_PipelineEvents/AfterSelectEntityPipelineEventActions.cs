using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterSelectEntityPipelineEventActions : PipelineEventActions<Func<AfterSelectPipelineExecutionContext, CancellationToken, Task>, Action<AfterSelectPipelineExecutionContext>, AfterSelectPipelineExecutionContext>
    {
        protected override Func<AfterSelectPipelineExecutionContext, CancellationToken, Task> MakeAsync(Action<AfterSelectPipelineExecutionContext> action)
            => new Func<AfterSelectPipelineExecutionContext, CancellationToken, Task>((ctx, ct) =>
            {
                action.Invoke(ctx);
                return Task.FromResult<object>(null);
            });

        protected override Action<AfterSelectPipelineExecutionContext> MakeSync(Func<AfterSelectPipelineExecutionContext, CancellationToken, Task> action)
           => new Action<AfterSelectPipelineExecutionContext>(ctx => action.Invoke(ctx, CancellationToken.None).GetAwaiter().GetResult());
    }
}