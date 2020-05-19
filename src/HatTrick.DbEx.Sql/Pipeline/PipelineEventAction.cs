using System;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate>
    { 
        public TAsyncDelegate AsyncDelegate { get; set; }
        public TSyncDelegate SyncDelegate { get; set; }
        public Predicate<TPredicate> Predicate { get; set; }
    }
}
