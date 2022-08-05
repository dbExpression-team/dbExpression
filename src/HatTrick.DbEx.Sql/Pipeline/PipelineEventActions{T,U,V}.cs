#region license
// Copyright (c) HatTrick Labs, LLC.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/HatTrickLabs/db-ex
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public abstract class PipelineEventActions<TAsyncDelegate, TSyncDelegate, TPredicate>
    {
        protected readonly List<PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate>> PipelineItems = new();

        public IEnumerable<(TAsyncDelegate, Predicate<TPredicate>?)> AsyncActions
            => PipelineItems.Select(pipelineItem => (pipelineItem.AsyncDelegate, pipelineItem.Predicate));

        public IEnumerable<(TSyncDelegate, Predicate<TPredicate>?)> SyncActions
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
            var pipelineEventAction = new PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate>(asyncAction, syncAction);
            PipelineItems.Add(pipelineEventAction);
            return pipelineEventAction;
        }

        public virtual PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> AddToEnd(TAsyncDelegate asyncAction, TSyncDelegate syncAction, Predicate<TPredicate> predicate)
        {
            var pipelineEventAction = new PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate>(asyncAction, syncAction, predicate);
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
            var pipelineEventAction = new PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate>(asyncAction, syncAction);
            PipelineItems.Insert(index, pipelineEventAction);
            return pipelineEventAction;
        }

        public virtual PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate> InsertItem(int index, TAsyncDelegate asyncAction, TSyncDelegate syncAction, Predicate<TPredicate> predicate)
        {
            var pipelineEventAction = new PipelineEventAction<TAsyncDelegate, TSyncDelegate, TPredicate>(asyncAction, syncAction, predicate);
            PipelineItems.Insert(index, pipelineEventAction);
            return pipelineEventAction;
        }

        protected abstract TAsyncDelegate MakeAsync(TSyncDelegate syncDelegate);
        protected abstract TSyncDelegate MakeSync(TAsyncDelegate asyncDelegate);
    }
}
