using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterUpdatePipelineEventActions : PipelineEventActions<Func<AfterUpdatePipelineExecutionContext, CancellationToken, Task>, Action<AfterUpdatePipelineExecutionContext>, AfterUpdatePipelineExecutionContext>
    {
        protected override Func<AfterUpdatePipelineExecutionContext, CancellationToken, Task> MakeAsync(Action<AfterUpdatePipelineExecutionContext> action)
            => new Func<AfterUpdatePipelineExecutionContext, CancellationToken, Task>((ctx, ct) =>
            {
                action.Invoke(ctx);
                return Task.FromResult<object>(null);
            });

        protected override Action<AfterUpdatePipelineExecutionContext> MakeSync(Func<AfterUpdatePipelineExecutionContext, CancellationToken, Task> action)
           => new Action<AfterUpdatePipelineExecutionContext>(ctx => action.Invoke(ctx, CancellationToken.None).GetAwaiter().GetResult());
    }
}