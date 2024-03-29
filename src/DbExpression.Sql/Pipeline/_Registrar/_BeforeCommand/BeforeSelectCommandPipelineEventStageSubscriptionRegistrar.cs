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
    public class BeforeSelectCommandPipelineEventStageSubscriptionRegistrar : PipelineEventStageSubscriptionRegistrar<Func<BeforeSelectCommandPipelineEventContext, CancellationToken, Task>, Action<BeforeSelectCommandPipelineEventContext>, BeforeSelectCommandPipelineEventContext>
    {
        protected override Func<BeforeSelectCommandPipelineEventContext, CancellationToken, Task> MakeAsync(Action<BeforeSelectCommandPipelineEventContext> action)
            => MakeAsync<BeforeSelectCommandPipelineEventContext>(action);

        protected override Action<BeforeSelectCommandPipelineEventContext> MakeSync(Func<BeforeSelectCommandPipelineEventContext, CancellationToken, Task> action)
            => MakeSync<BeforeSelectCommandPipelineEventContext>(action);
    }
}