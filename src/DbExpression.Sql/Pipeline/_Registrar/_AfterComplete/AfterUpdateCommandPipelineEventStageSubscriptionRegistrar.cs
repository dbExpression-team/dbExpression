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
using System.Threading;
using System.Threading.Tasks;

namespace DbExpression.Sql.Pipeline
{
    public class AfterUpdateCompletePipelineEventStageSubscriptionRegistrar : PipelineEventStageSubscriptionRegistrar<Func<AfterUpdateCompletePipelineEventContext, CancellationToken, Task>, Action<AfterUpdateCompletePipelineEventContext>, AfterUpdateCompletePipelineEventContext>
    {
        protected override Func<AfterUpdateCompletePipelineEventContext, CancellationToken, Task> MakeAsync(Action<AfterUpdateCompletePipelineEventContext> action)
            => MakeAsync<AfterUpdateCompletePipelineEventContext>(action);

        protected override Action<AfterUpdateCompletePipelineEventContext> MakeSync(Func<AfterUpdateCompletePipelineEventContext, CancellationToken, Task> action)
            => MakeSync<AfterUpdateCompletePipelineEventContext>(action);
    }
}