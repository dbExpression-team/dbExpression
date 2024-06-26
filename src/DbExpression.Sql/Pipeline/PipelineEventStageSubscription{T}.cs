#region license
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

﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DbExpression.Sql.Pipeline
{
    public class PipelineEventStageSubscriptions<TContext>
        where TContext : class, IPipelineEventContext
    {
        private IEnumerable<(Action<TContext> Action, Predicate<TContext>? Predicate)> SyncHooks { get; set; }
        private IEnumerable<(Func<TContext, CancellationToken, Task> Action, Predicate<TContext>? Predicate)> AsyncHooks { get; set; }

        public PipelineEventStageSubscriptions(IEnumerable<(Action<TContext> Action, Predicate<TContext>? Predicate)> syncHooks, IEnumerable<(Func<TContext, CancellationToken, Task> Action, Predicate<TContext>? Predicate)> asyncHooks)
        {
            SyncHooks = syncHooks;
            AsyncHooks = asyncHooks;
        }

        public async Task InvokeAsync(Lazy<TContext> context, CancellationToken cancellationToken)
        {
            foreach (var hook in AsyncHooks)
            {
                if (hook.Predicate?.Invoke(context.Value) ?? true)
                {
                    await hook.Action.Invoke(context.Value, cancellationToken);
                }
            }
        }

        public void Invoke(Lazy<TContext> context)
        {
            foreach (var hook in SyncHooks)
            {
                if (hook.Predicate?.Invoke(context.Value) ?? true)
                {
                    hook.Action.Invoke(context.Value);
                }
            }
        }
    }
}