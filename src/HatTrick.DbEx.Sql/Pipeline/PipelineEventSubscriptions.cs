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
    public class PipelineEventSubscriptions
    {
        //common events
        public PipelineEventStageSubscriptions<BeforeStartPipelineEventContext>? OnBeforeStart { get; set; }
        public PipelineEventStageSubscriptions<AfterAssemblyPipelineEventContext>? OnAfterAssembly { get; set; }
        public PipelineEventStageSubscriptions<BeforeCommandPipelineEventContext>? OnBeforeCommand { get; set; }
        public PipelineEventStageSubscriptions<AfterCommandPipelineEventContext>? OnAfterCommand { get; set; }
        public PipelineEventStageSubscriptions<AfterCompletePipelineEventContext>? OnAfterComplete { get; set; }

        //select events
        public PipelineEventStageSubscriptions<BeforeSelectStartPipelineEventContext>? OnBeforeSelectStart { get; set; }
        public PipelineEventStageSubscriptions<AfterSelectAssemblyPipelineEventContext>? OnAfterSelectAssembly { get; set; }
        public PipelineEventStageSubscriptions<BeforeSelectCommandPipelineEventContext>? OnBeforeSelectCommand { get; set; }
        public PipelineEventStageSubscriptions<AfterSelectCommandPipelineEventContext>? OnAfterSelectCommand { get; set; }
        public PipelineEventStageSubscriptions<AfterSelectCompletePipelineEventContext>? OnAfterSelectComplete { get; set; }

        //insert events
        public PipelineEventStageSubscriptions<BeforeInsertStartPipelineEventContext>? OnBeforeInsertStart { get; set; }
        public PipelineEventStageSubscriptions<AfterInsertAssemblyPipelineEventContext>? OnAfterInsertAssembly { get; set; }
        public PipelineEventStageSubscriptions<BeforeInsertCommandPipelineEventContext>? OnBeforeInsertCommand { get; set; }
        public PipelineEventStageSubscriptions<AfterInsertCommandPipelineEventContext>? OnAfterInsertCommand { get; set; }
        public PipelineEventStageSubscriptions<AfterInsertCompletePipelineEventContext>? OnAfterInsertComplete { get; set; }

        //update events
        public PipelineEventStageSubscriptions<BeforeUpdateStartPipelineEventContext>? OnBeforeUpdateStart { get; set; }
        public PipelineEventStageSubscriptions<AfterUpdateAssemblyPipelineEventContext>? OnAfterUpdateAssembly { get; set; }
        public PipelineEventStageSubscriptions<BeforeUpdateCommandPipelineEventContext>? OnBeforeUpdateCommand { get; set; }
        public PipelineEventStageSubscriptions<AfterUpdateCommandPipelineEventContext>? OnAfterUpdateCommand { get; set; }
        public PipelineEventStageSubscriptions<AfterUpdateCompletePipelineEventContext>? OnAfterUpdateComplete { get; set; }

        //delete events
        public PipelineEventStageSubscriptions<BeforeDeleteStartPipelineEventContext>? OnBeforeDeleteStart { get; set; }
        public PipelineEventStageSubscriptions<AfterDeleteAssemblyPipelineEventContext>? OnAfterDeleteAssembly { get; set; }
        public PipelineEventStageSubscriptions<BeforeDeleteCommandPipelineEventContext>? OnBeforeDeleteCommand { get; set; }
        public PipelineEventStageSubscriptions<AfterDeleteCommandPipelineEventContext>? OnAfterDeleteCommand { get; set; }
        public PipelineEventStageSubscriptions<AfterDeleteCompletePipelineEventContext>? OnAfterDeleteComplete { get; set; }

        //stored procedure events
        public PipelineEventStageSubscriptions<BeforeStoredProcedureStartPipelineEventContext>? OnBeforeStoredProcedureStart { get; set; }
        public PipelineEventStageSubscriptions<AfterStoredProcedureAssemblyPipelineEventContext>? OnAfterStoredProcedureAssembly { get; set; }
        public PipelineEventStageSubscriptions<BeforeStoredProcedureCommandPipelineEventContext>? OnBeforeStoredProcedureCommand { get; set; }
        public PipelineEventStageSubscriptions<AfterStoredProcedureCommandPipelineEventContext>? OnAfterStoredProcedureCommand { get; set; }
        public PipelineEventStageSubscriptions<AfterStoredProcedureCompletePipelineEventContext>? OnAfterStoredProcedureComplete { get; set; }
    }
}
