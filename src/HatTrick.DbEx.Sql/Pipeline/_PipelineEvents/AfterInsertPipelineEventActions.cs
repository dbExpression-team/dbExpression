using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterInsertPipelineEventActions : PipelineEventActions<Func<AfterInsertContext, CancellationToken, Task>, Action<AfterInsertContext>, AfterInsertContext>
    {
        protected override Func<AfterInsertContext, CancellationToken, Task> MakeAsync(Action<AfterInsertContext> action)
            => new Func<AfterInsertContext, CancellationToken, Task>((ctx, ct) =>
            {
                action.Invoke(ctx);
                return Task.FromResult<object>(null);
            });

        protected override Action<AfterInsertContext> MakeSync(Func<AfterInsertContext, CancellationToken, Task> action)
           => new Action<AfterInsertContext>(ctx => action.Invoke(ctx, CancellationToken.None).GetAwaiter().GetResult());
    }
}