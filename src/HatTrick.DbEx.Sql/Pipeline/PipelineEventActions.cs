using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public abstract class PipelineEventActions<TAsyncDelegate, TSyncDelegate, TPredicate>
    {
        protected List<PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate>> PipelineItems { get; } = new List<PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate>>();

        public IEnumerable<(TAsyncDelegate, Predicate<TPredicate>)> AsyncActions
            => PipelineItems.Select(pipelineItem => (pipelineItem.AsyncDelegate, pipelineItem.Predicate));

        public IEnumerable<(TSyncDelegate, Predicate<TPredicate>)> SyncActions
            => PipelineItems.Select(pipelineItem => (pipelineItem.SyncDelegate, pipelineItem.Predicate));

        public virtual IPipelineEventActionBuilder<TPredicate> AddToStart(TAsyncDelegate asyncAction)
            => InsertItem(0, asyncAction, MakeSync(asyncAction));

        public virtual IPipelineEventActionBuilder<TPredicate> AddToStart(TSyncDelegate syncAction)
            => AddToStart(MakeAsync(syncAction), syncAction);

        public virtual IPipelineEventActionBuilder<TPredicate> AddToStart(TAsyncDelegate asyncAction, TSyncDelegate syncAction)
            => InsertItem(0, asyncAction, syncAction);

        public virtual IPipelineEventActionBuilder<TPredicate> AddToEnd(TAsyncDelegate asyncAction)
            => AddToEnd(asyncAction, MakeSync(asyncAction));

        public virtual IPipelineEventActionBuilder<TPredicate> AddToEnd(TSyncDelegate syncAction)
            => AddToEnd(MakeAsync(syncAction), syncAction);

        public virtual IPipelineEventActionBuilder<TPredicate> AddToEnd(TAsyncDelegate asyncAction, TSyncDelegate syncAction)
        {
            var pipelineEventAction = new PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> { AsyncDelegate = asyncAction, SyncDelegate = syncAction };
            PipelineItems.Add(pipelineEventAction);
            return new PipelineEventActionBuilder<TAsyncDelegate, TSyncDelegate, TPredicate>(pipelineEventAction);
        }

        public virtual IPipelineEventActionBuilder<TPredicate> InsertItem(int index, TAsyncDelegate asyncAction)
            => InsertItem(index, asyncAction, MakeSync(asyncAction));

        public virtual void InsertItem(int index, TSyncDelegate syncAction)
            => InsertItem(index, MakeAsync(syncAction), syncAction);

        public virtual IPipelineEventActionBuilder<TPredicate> InsertItem(int index, TAsyncDelegate asyncAction, TSyncDelegate syncAction)
        {
            var pipelineEventAction = new PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> { AsyncDelegate = asyncAction, SyncDelegate = syncAction };
            PipelineItems.Insert(index, pipelineEventAction);
            return new PipelineEventActionBuilder<TAsyncDelegate, TSyncDelegate, TPredicate>(pipelineEventAction);
        }

        protected abstract TAsyncDelegate MakeAsync(TSyncDelegate syncDelegate);
        protected abstract TSyncDelegate MakeSync(TAsyncDelegate asyncDelegate);
    }
}
