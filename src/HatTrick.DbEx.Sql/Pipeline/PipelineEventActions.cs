using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public abstract class PipelineEventActions<TAsyncDelegate, TSyncDelegate>
    {
        protected List<(TAsyncDelegate asyncAction, TSyncDelegate syncAction)> PipelineItems { get; } = new List<(TAsyncDelegate, TSyncDelegate)>();

        public IEnumerable<(TAsyncDelegate asyncAction, TSyncDelegate syncAction)> Items
            => PipelineItems.AsReadOnly();

        public IEnumerable<TAsyncDelegate> AsyncActions
            => PipelineItems.Select(pipelineItem => pipelineItem.asyncAction);

        public IEnumerable<TSyncDelegate> SyncActions
            => PipelineItems.Select(pipelineItem => pipelineItem.syncAction);

        public virtual void AddToStart(TAsyncDelegate asyncAction)
            => InsertItem(0, asyncAction, MakeSync(asyncAction));

        public virtual void AddToStart(TSyncDelegate syncAction)
            => AddToStart(MakeAsync(syncAction), syncAction);

        public virtual void AddToStart(TAsyncDelegate asyncAction, TSyncDelegate syncAction)
            => InsertItem(0, asyncAction, syncAction);

        public virtual void AddToEnd(TAsyncDelegate asyncAction)
            => AddToEnd(asyncAction, MakeSync(asyncAction));

        public virtual void AddToEnd(TSyncDelegate syncAction)
            => AddToEnd(MakeAsync(syncAction), syncAction);

        public virtual void AddToEnd(TAsyncDelegate asyncAction, TSyncDelegate syncAction)
            => PipelineItems.Add((asyncAction, syncAction));

        public virtual void InsertItem(int index, TAsyncDelegate asyncAction)
            => InsertItem(index, asyncAction, MakeSync(asyncAction));

        public virtual void InsertItem(int index, TSyncDelegate syncAction)
            => InsertItem(index, MakeAsync(syncAction), syncAction);

        public virtual void InsertItem(int index, TAsyncDelegate asyncAction, TSyncDelegate syncAction)
            => PipelineItems.Insert(index, (asyncAction, syncAction));

        protected abstract TAsyncDelegate MakeAsync(TSyncDelegate syncDelegate);
        protected abstract TSyncDelegate MakeSync(TAsyncDelegate asyncDelegate);
    }
}
