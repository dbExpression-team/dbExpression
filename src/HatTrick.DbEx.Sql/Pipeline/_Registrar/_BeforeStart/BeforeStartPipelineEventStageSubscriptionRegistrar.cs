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

﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeStartPipelineEventStageSubscriptionRegistrar : PipelineEventStageSubscriptionRegistrar<Func<BeforeStartPipelineEventContext, CancellationToken, Task>, Action<BeforeStartPipelineEventContext>, BeforeStartPipelineEventContext>
    {
        protected override Func<BeforeStartPipelineEventContext, CancellationToken, Task> MakeAsync(Action<BeforeStartPipelineEventContext> action)
            => new((ctx, ct) =>
            {
                action.Invoke(ctx);
                return Task.CompletedTask;
            });

        protected override Action<BeforeStartPipelineEventContext> MakeSync(Func<BeforeStartPipelineEventContext, CancellationToken, Task> action)
           => new(ctx => action.Invoke(ctx, CancellationToken.None).GetAwaiter().GetResult());
    }
}
