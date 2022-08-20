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
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class PipelineEventActions<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        public PipelineEventActions<Func<BeforeAssemblyPipelineExecutionContext, CancellationToken, Task>, Action<BeforeAssemblyPipelineExecutionContext>, BeforeAssemblyPipelineExecutionContext> BeforeAssembly { get; set; } = new BeforeAssemblyPipelineEventActions();
        public PipelineEventActions<Func<BeforeUpdateAssemblyPipelineExecutionContext, CancellationToken, Task>, Action<BeforeUpdateAssemblyPipelineExecutionContext>, BeforeUpdateAssemblyPipelineExecutionContext> BeforeUpdateAssembly { get; set; } = new BeforeUpdateAssemblyPipelineEventActions();
        public PipelineEventActions<Func<BeforeInsertAssemblyPipelineExecutionContext, CancellationToken, Task>, Action<BeforeInsertAssemblyPipelineExecutionContext>, BeforeInsertAssemblyPipelineExecutionContext> BeforeInsertAssembly { get; set; } = new BeforeInsertAssemblyPipelineEventActions();
        public PipelineEventActions<Func<AfterAssemblyPipelineExecutionContext, CancellationToken, Task>, Action<AfterAssemblyPipelineExecutionContext>, AfterAssemblyPipelineExecutionContext> AfterAssembly { get; set; } = new AfterAssemblyPipelineEventActions();
        public PipelineEventActions<Func<BeforeInsertPipelineExecutionContext, CancellationToken, Task>, Action<BeforeInsertPipelineExecutionContext>, BeforeInsertPipelineExecutionContext> BeforeInsert { get; set; } = new BeforeInsertPipelineEventActions();
        public PipelineEventActions<Func<AfterInsertPipelineExecutionContext, CancellationToken, Task>, Action<AfterInsertPipelineExecutionContext>, AfterInsertPipelineExecutionContext> AfterInsert { get; set; } = new AfterInsertPipelineEventActions();
        public PipelineEventActions<Func<BeforeDeletePipelineExecutionContext, CancellationToken, Task>, Action<BeforeDeletePipelineExecutionContext>, BeforeDeletePipelineExecutionContext> BeforeDelete { get; set; } = new BeforeDeletePipelineEventActions();
        public PipelineEventActions<Func<AfterDeletePipelineExecutionContext, CancellationToken, Task>, Action<AfterDeletePipelineExecutionContext>, AfterDeletePipelineExecutionContext> AfterDelete { get; set; } = new AfterDeletePipelineEventActions();
        public PipelineEventActions<Func<BeforeUpdatePipelineExecutionContext, CancellationToken, Task>, Action<BeforeUpdatePipelineExecutionContext>, BeforeUpdatePipelineExecutionContext> BeforeUpdate { get; set; } = new BeforeUpdatePipelineEventActions();
        public PipelineEventActions<Func<AfterUpdatePipelineExecutionContext, CancellationToken, Task>, Action<AfterUpdatePipelineExecutionContext>, AfterUpdatePipelineExecutionContext> AfterUpdate { get; set; } = new AfterUpdatePipelineEventActions();
        public PipelineEventActions<Func<BeforeSelectPipelineExecutionContext, CancellationToken, Task>, Action<BeforeSelectPipelineExecutionContext>, BeforeSelectPipelineExecutionContext> BeforeSelect { get; set; } = new BeforeSelectPipelineEventActions();
        public PipelineEventActions<Func<AfterSelectPipelineExecutionContext, CancellationToken, Task>, Action<AfterSelectPipelineExecutionContext>, AfterSelectPipelineExecutionContext> AfterSelect { get; set; } = new AfterSelectPipelineEventActions();
        public PipelineEventActions<Func<BeforeStoredProcedurePipelineExecutionContext, CancellationToken, Task>, Action<BeforeStoredProcedurePipelineExecutionContext>, BeforeStoredProcedurePipelineExecutionContext> BeforeStoredProcedure { get; set; } = new BeforeStoredProcedurePipelineEventActions();
        public PipelineEventActions<Func<AfterStoredProcedurePipelineExecutionContext, CancellationToken, Task>, Action<AfterStoredProcedurePipelineExecutionContext>, AfterStoredProcedurePipelineExecutionContext> AfterStoredProcedure { get; set; } = new AfterStoredProcedurePipelineEventActions();
        public PipelineEventActions<Func<BeforeExecutionPipelineExecutionContext, CancellationToken, Task>, Action<BeforeExecutionPipelineExecutionContext>, BeforeExecutionPipelineExecutionContext> BeforeExecution { get; set; } = new BeforeExecutionPipelineEventActions();
        public PipelineEventActions<Func<AfterExecutionPipelineExecutionContext, CancellationToken, Task>, Action<AfterExecutionPipelineExecutionContext>, AfterExecutionPipelineExecutionContext> AfterExecution { get; set; } = new AfterExecutionPipelineEventActions();

    }
}
