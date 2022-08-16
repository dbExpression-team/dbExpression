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


namespace HatTrick.DbEx.Sql.Pipeline
{
    public class PipelineEventHooks
    {
        public PipelineEventHook<BeforeAssemblyPipelineExecutionContext>? BeforeAssembly { get; set; }
        public PipelineEventHook<BeforeUpdateAssemblyPipelineExecutionContext>? BeforeUpdateAssembly { get; set; }
        public PipelineEventHook<BeforeInsertAssemblyPipelineExecutionContext>? BeforeInsertAssembly { get; set; }
        public PipelineEventHook<AfterAssemblyPipelineExecutionContext>? AfterAssembly { get; set; }
        public PipelineEventHook<BeforeInsertPipelineExecutionContext>? BeforeInsert { get; set; }
        public PipelineEventHook<AfterInsertPipelineExecutionContext>? AfterInsert { get; set; }
        public PipelineEventHook<BeforeDeletePipelineExecutionContext>? BeforeDelete { get; set; }
        public PipelineEventHook<AfterDeletePipelineExecutionContext>? AfterDelete { get; set; }
        public PipelineEventHook<BeforeUpdatePipelineExecutionContext>? BeforeUpdate { get; set; }
        public PipelineEventHook<AfterUpdatePipelineExecutionContext>? AfterUpdate { get; set; }
        public PipelineEventHook<BeforeSelectPipelineExecutionContext>? BeforeSelect { get; set; }
        public PipelineEventHook<AfterSelectPipelineExecutionContext>? AfterSelect { get; set; }
        public PipelineEventHook<BeforeStoredProcedurePipelineExecutionContext>? BeforeStoredProcedure { get; set; }
        public PipelineEventHook<AfterStoredProcedurePipelineExecutionContext>? AfterStoredProcedure { get; set; }
        public PipelineEventHook<BeforeExecutionPipelineExecutionContext>? BeforeExecution { get; set; }
        public PipelineEventHook<AfterExecutionPipelineExecutionContext>? AfterExecution { get; set; }

    }
}
