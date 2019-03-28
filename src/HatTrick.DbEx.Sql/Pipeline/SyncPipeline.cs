using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class SyncPipeline<TContext>
        where TContext : class, IPipelineExecutionContext
    {
        private IEnumerable<Action<TContext>> Actions { get; set; }

        public void Invoke(Lazy<TContext> context)
        {
            foreach (var action in Actions)
                action.Invoke(context.Value);
        }

        public SyncPipeline(IEnumerable<Action<TContext>> actions)
        {
            Actions = actions;
        }
    }
}
