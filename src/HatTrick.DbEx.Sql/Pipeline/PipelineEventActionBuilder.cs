using System;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class PipelineEventActionBuilder<TAsyncDelegate, TSyncDelegate, TPredicate> : IPipelineEventActionBuilder<TPredicate>
    {
        private PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> pipelineEventAction;

        public PipelineEventActionBuilder(PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> pipelineEventAction)
        {
            this.pipelineEventAction = pipelineEventAction;
        }

        public void When(Predicate<TPredicate> predicate)
        {
            pipelineEventAction.Predicate = predicate;
        }
    }
}
