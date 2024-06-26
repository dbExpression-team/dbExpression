﻿#region license
// Copyright (c) dbExpression.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace DbExpression.Sql.Pipeline
{
    public abstract class PipelineEventStageSubscriptionRegistrar<TAsyncDelegate, TSyncDelegate, TPredicate>
    {
        protected readonly List<PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate>> Subscriptions = new();

        public IEnumerable<(TAsyncDelegate, Predicate<TPredicate>?)> AsyncActions
            => Subscriptions.Select(pipelineItem => (pipelineItem.AsyncDelegate, pipelineItem.Predicate));

        public IEnumerable<(TSyncDelegate, Predicate<TPredicate>?)> SyncActions
            => Subscriptions.Select(pipelineItem => (pipelineItem.SyncDelegate, pipelineItem.Predicate));

        public PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate> AddToStart(TAsyncDelegate asyncAction)
            => InsertItem(0, asyncAction, MakeSync(asyncAction));

        public PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate> AddToStart(TAsyncDelegate asyncAction, Predicate<TPredicate> predicate)
            => InsertItem(0, asyncAction, MakeSync(asyncAction), predicate);

        public PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate> AddToStart(TSyncDelegate syncAction)
            => AddToStart(MakeAsync(syncAction), syncAction);

        public PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate> AddToStart(TSyncDelegate syncAction, Predicate<TPredicate> predicate)
            => AddToStart(MakeAsync(syncAction), syncAction, predicate);

        public PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate> AddToStart(TAsyncDelegate asyncAction, TSyncDelegate syncAction)
            => InsertItem(0, asyncAction, syncAction);

        public PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate> AddToStart(TAsyncDelegate asyncAction, TSyncDelegate syncAction, Predicate<TPredicate> predicate)
            => InsertItem(0, asyncAction, syncAction, predicate);

        public PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate> AddToEnd(TAsyncDelegate asyncAction)
            => AddToEnd(asyncAction, MakeSync(asyncAction));

        public PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate> AddToEnd(TAsyncDelegate asyncAction, Predicate<TPredicate> predicate)
            => AddToEnd(asyncAction, MakeSync(asyncAction), predicate);

        public PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate> AddToEnd(TSyncDelegate syncAction)
            => AddToEnd(MakeAsync(syncAction), syncAction);

        public PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate> AddToEnd(TSyncDelegate syncAction, Predicate<TPredicate> predicate)
            => AddToEnd(MakeAsync(syncAction), syncAction, predicate);

        public PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate> AddToEnd(TAsyncDelegate asyncAction, TSyncDelegate syncAction)
        {
            var pipelineEventAction = new PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate>(asyncAction, syncAction);
            Subscriptions.Add(pipelineEventAction);
            return pipelineEventAction;
        }

        public PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate> AddToEnd(TAsyncDelegate asyncAction, TSyncDelegate syncAction, Predicate<TPredicate> predicate)
        {
            var pipelineEventAction = new PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate>(asyncAction, syncAction, predicate);
            Subscriptions.Add(pipelineEventAction);
            return pipelineEventAction;
        }

        public PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate> InsertItem(int index, TAsyncDelegate asyncAction)
            => InsertItem(index, asyncAction, MakeSync(asyncAction));

        public PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate> InsertItem(int index, TAsyncDelegate asyncAction, Predicate<TPredicate> predicate)
            => InsertItem(index, asyncAction, MakeSync(asyncAction), predicate);

        public PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate> InsertItem(int index, TSyncDelegate syncAction)
            => InsertItem(index, MakeAsync(syncAction), syncAction);

        public PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate> InsertItem(int index, TSyncDelegate syncAction, Predicate<TPredicate> predicate)
            => InsertItem(index, MakeAsync(syncAction), syncAction, predicate);

        public PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate> InsertItem(int index, TAsyncDelegate asyncAction, TSyncDelegate syncAction)
        {
            var pipelineEventAction = new PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate>(asyncAction, syncAction);
            Subscriptions.Insert(index, pipelineEventAction);
            return pipelineEventAction;
        }

        public PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate> InsertItem(int index, TAsyncDelegate asyncAction, TSyncDelegate syncAction, Predicate<TPredicate> predicate)
        {
            var pipelineEventAction = new PipelineEventStageSubscription<TAsyncDelegate, TSyncDelegate, TPredicate>(asyncAction, syncAction, predicate);
            Subscriptions.Insert(index, pipelineEventAction);
            return pipelineEventAction;
        }

        protected abstract TAsyncDelegate MakeAsync(TSyncDelegate syncDelegate);
        protected abstract TSyncDelegate MakeSync(TAsyncDelegate asyncDelegate);

        protected virtual Func<TContext, CancellationToken, Task> MakeAsync<TContext>(Action<TContext> action)
            => new((ctx, ct) =>
            {
                var source = new TaskCompletionSource<object?>();
                ct.Register(() => source.TrySetCanceled());
                try
                {
                    action.Invoke(ctx);
                    source.TrySetResult(null);
                }
                catch (Exception e)
                {
                    source.TrySetException(e);
                }
                return source.Task;
            });

        protected virtual Action<TContext> MakeSync<TContext>(Func<TContext, CancellationToken, Task> action)
            => new(ctx => action.Invoke(ctx, CancellationToken.None).GetAwaiter().GetResult());
    }
}
