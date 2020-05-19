using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class SyncPipeline<TContext>
        where TContext : class, IPipelineExecutionContext
    {
        private IEnumerable<(Action<TContext>, Predicate<TContext>)> Actions { get; set; }

        public void Invoke(Lazy<TContext> context)
        {
            foreach (var action in Actions)
            {
                if (action.Item2?.Invoke(context.Value) ?? true)
                {
                    action.Item1.Invoke(context.Value);
                }
            }
        }

        public SyncPipeline(IEnumerable<(Action<TContext>, Predicate<TContext>)> actions)
        {
            Actions = actions;
        }
    }
}
