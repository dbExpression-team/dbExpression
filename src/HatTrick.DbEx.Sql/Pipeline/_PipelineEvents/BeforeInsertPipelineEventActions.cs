using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeInsertPipelineEventActions : PipelineEventActions<Func<BeforeInsertPipelineExecutionContext, CancellationToken, Task>, Action<BeforeInsertPipelineExecutionContext>, BeforeInsertPipelineExecutionContext>
    {
        protected override Func<BeforeInsertPipelineExecutionContext, CancellationToken, Task> MakeAsync(Action<BeforeInsertPipelineExecutionContext> action)
            => new Func<BeforeInsertPipelineExecutionContext, CancellationToken, Task>((ctx, ct) =>
            {
                action.Invoke(ctx);
                return Task.FromResult<object>(null);
            });

        protected override Action<BeforeInsertPipelineExecutionContext> MakeSync(Func<BeforeInsertPipelineExecutionContext, CancellationToken, Task> action)
           => new Action<BeforeInsertPipelineExecutionContext>(ctx => action.Invoke(ctx, CancellationToken.None).GetAwaiter().GetResult());
    }
}