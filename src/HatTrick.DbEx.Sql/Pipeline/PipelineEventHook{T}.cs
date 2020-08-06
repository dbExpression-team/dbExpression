using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class PipelineEventHook<TContext>
        where TContext : class, IPipelineExecutionContext
    {
        private IEnumerable<(Action<TContext> Action, Predicate<TContext> Predicate)> SyncHooks { get; set; }
        private IEnumerable<(Func<TContext, CancellationToken, Task> Action, Predicate<TContext> Predicate)> AsyncHooks { get; set; }

        public PipelineEventHook(IEnumerable<(Action<TContext> Action, Predicate<TContext> Predicate)> syncHooks, IEnumerable<(Func<TContext, CancellationToken, Task> Action, Predicate<TContext> Predicate)> asyncHooks)
        {
            SyncHooks = syncHooks;
            AsyncHooks = asyncHooks;
        }

        public async Task InvokeAsync(Lazy<TContext> context, CancellationToken cancellationToken)
        {
            foreach (var hook in AsyncHooks)
            {
                if (hook.Predicate?.Invoke(context.Value) ?? true)
                {
                    await hook.Action.Invoke(context.Value, cancellationToken);
                }
            }
        }

        public void Invoke(Lazy<TContext> context)
        {
            foreach (var hook in SyncHooks)
            {
                if (hook.Predicate?.Invoke(context.Value) ?? true)
                {
                    hook.Action.Invoke(context.Value);
                }
            }
        }
    }
}