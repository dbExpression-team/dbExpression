using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeUpdatePipelineEventActions : PipelineEventActions<Func<BeforeUpdatePipelineExecutionContext, CancellationToken, Task>, Action<BeforeUpdatePipelineExecutionContext>, BeforeUpdatePipelineExecutionContext>
    {
        protected override Func<BeforeUpdatePipelineExecutionContext, CancellationToken, Task> MakeAsync(Action<BeforeUpdatePipelineExecutionContext> action)
            => new Func<BeforeUpdatePipelineExecutionContext, CancellationToken, Task>((ctx, ct) =>
            {
                action.Invoke(ctx);
                return Task.FromResult<object>(null);
            });

        protected override Action<BeforeUpdatePipelineExecutionContext> MakeSync(Func<BeforeUpdatePipelineExecutionContext, CancellationToken, Task> action)
           => new Action<BeforeUpdatePipelineExecutionContext>(ctx => action.Invoke(ctx, CancellationToken.None).GetAwaiter().GetResult());
    }
}