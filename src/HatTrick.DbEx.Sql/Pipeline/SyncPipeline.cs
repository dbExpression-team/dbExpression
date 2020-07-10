using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class SyncPipeline<TContext>
        where TContext : class, IPipelineExecutionContext
    {
        private IEnumerable<(Action<TContext> Action, Predicate<TContext> Predicate)> Actions { get; set; }

        public void Invoke(Lazy<TContext> context)
        {
            foreach (var action in Actions)
            {
                if (action.Predicate?.Invoke(context.Value) ?? true)
                {
                    action.Action.Invoke(context.Value);
                }
            }
        }

        public SyncPipeline(IEnumerable<(Action<TContext> Action, Predicate<TContext> Predicate)> actions)
        {
            Actions = actions;
        }
    }
}
