using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public abstract class PipelineEventActions<TAsyncDelegate, TSyncDelegate, TPredicate>
    {
        protected readonly List<PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate>> PipelineItems = new List<PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate>>();

        public IEnumerable<(TAsyncDelegate, Predicate<TPredicate>)> AsyncActions
            => PipelineItems.Select(pipelineItem => (pipelineItem.AsyncDelegate, pipelineItem.Predicate));

        public IEnumerable<(TSyncDelegate, Predicate<TPredicate>)> SyncActions
            => PipelineItems.Select(pipelineItem => (pipelineItem.SyncDelegate, pipelineItem.Predicate));

        public virtual PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> AddToStart(TAsyncDelegate asyncAction)
            => InsertItem(0, asyncAction, MakeSync(asyncAction));

        public virtual PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> AddToStart(TAsyncDelegate asyncAction, Predicate<TPredicate> predicate)
            => InsertItem(0, asyncAction, MakeSync(asyncAction), predicate);

        public virtual PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> AddToStart(TSyncDelegate syncAction)
            => AddToStart(MakeAsync(syncAction), syncAction);

        public virtual PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> AddToStart(TSyncDelegate syncAction, Predicate<TPredicate> predicate)
            => AddToStart(MakeAsync(syncAction), syncAction, predicate);

        public virtual PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> AddToStart(TAsyncDelegate asyncAction, TSyncDelegate syncAction)
            => InsertItem(0, asyncAction, syncAction);

        public virtual PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> AddToStart(TAsyncDelegate asyncAction, TSyncDelegate syncAction, Predicate<TPredicate> predicate)
            => InsertItem(0, asyncAction, syncAction, predicate);

        public virtual PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> AddToEnd(TAsyncDelegate asyncAction)
            => AddToEnd(asyncAction, MakeSync(asyncAction));

        public virtual PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> AddToEnd(TAsyncDelegate asyncAction, Predicate<TPredicate> predicate)
            => AddToEnd(asyncAction, MakeSync(asyncAction), predicate);

        public virtual PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> AddToEnd(TSyncDelegate syncAction)
            => AddToEnd(MakeAsync(syncAction), syncAction);

        public virtual PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> AddToEnd(TSyncDelegate syncAction, Predicate<TPredicate> predicate)
            => AddToEnd(MakeAsync(syncAction), syncAction, predicate);

        public virtual PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> AddToEnd(TAsyncDelegate asyncAction, TSyncDelegate syncAction)
        {
            var pipelineEventAction = new PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> { AsyncDelegate = asyncAction, SyncDelegate = syncAction };
            PipelineItems.Add(pipelineEventAction);
            return pipelineEventAction;
        }

        public virtual PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> AddToEnd(TAsyncDelegate asyncAction, TSyncDelegate syncAction, Predicate<TPredicate> predicate)
        {
            var pipelineEventAction = new PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> { AsyncDelegate = asyncAction, SyncDelegate = syncAction, Predicate = predicate };
            PipelineItems.Add(pipelineEventAction);
            return pipelineEventAction;
        }

        public virtual PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> InsertItem(int index, TAsyncDelegate asyncAction)
            => InsertItem(index, asyncAction, MakeSync(asyncAction));

        public virtual PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> InsertItem(int index, TAsyncDelegate asyncAction, Predicate<TPredicate> predicate)
            => InsertItem(index, asyncAction, MakeSync(asyncAction), predicate);

        public virtual PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> InsertItem(int index, TSyncDelegate syncAction)
            => InsertItem(index, MakeAsync(syncAction), syncAction);

        public virtual PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> InsertItem(int index, TSyncDelegate syncAction, Predicate<TPredicate> predicate)
            => InsertItem(index, MakeAsync(syncAction), syncAction, predicate);

        public virtual PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> InsertItem(int index, TAsyncDelegate asyncAction, TSyncDelegate syncAction)
        {
            var pipelineEventAction = new PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> { AsyncDelegate = asyncAction, SyncDelegate = syncAction };
            PipelineItems.Insert(index, pipelineEventAction);
            return pipelineEventAction;
        }

        public virtual PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> InsertItem(int index, TAsyncDelegate asyncAction, TSyncDelegate syncAction, Predicate<TPredicate> predicate)
        {
            var pipelineEventAction = new PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> { AsyncDelegate = asyncAction, SyncDelegate = syncAction, Predicate = predicate };
            PipelineItems.Insert(index, pipelineEventAction);
            return pipelineEventAction;
        }

        protected abstract TAsyncDelegate MakeAsync(TSyncDelegate syncDelegate);
        protected abstract TSyncDelegate MakeSync(TAsyncDelegate asyncDelegate);
    }
}
