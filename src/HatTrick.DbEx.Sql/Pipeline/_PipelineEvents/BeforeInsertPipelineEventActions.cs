using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeInsertPipelineEventActions : PipelineEventActions<Func<BeforeInsertContext, CancellationToken, Task>, Action<BeforeInsertContext>, BeforeInsertContext>
    {
        protected override Func<BeforeInsertContext, CancellationToken, Task> MakeAsync(Action<BeforeInsertContext> action)
            => new Func<BeforeInsertContext, CancellationToken, Task>((ctx, ct) =>
            {
                action.Invoke(ctx);
                return Task.FromResult<object>(null);
            });

        protected override Action<BeforeInsertContext> MakeSync(Func<BeforeInsertContext, CancellationToken, Task> action)
           => new Action<BeforeInsertContext>(ctx => action.Invoke(ctx, CancellationToken.None).GetAwaiter().GetResult());
    }
}