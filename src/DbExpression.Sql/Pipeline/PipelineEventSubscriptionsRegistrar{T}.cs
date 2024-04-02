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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DbExpression.Sql.Pipeline
{
    public class PipelineEventSubscriptionsRegistrar<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        //common
        public PipelineEventStageSubscriptionRegistrar<Func<BeforeStartPipelineEventContext, CancellationToken, Task>, Action<BeforeStartPipelineEventContext>, BeforeStartPipelineEventContext> OnBeforeStart { get; set; } = new BeforeStartPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<AfterAssemblyPipelineEventContext, CancellationToken, Task>, Action<AfterAssemblyPipelineEventContext>, AfterAssemblyPipelineEventContext> OnAfterAssembly { get; set; } = new AfterAssemblyPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<BeforeCommandPipelineEventContext, CancellationToken, Task>, Action<BeforeCommandPipelineEventContext>, BeforeCommandPipelineEventContext> OnBeforeCommand { get; set; } = new BeforeCommandPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<AfterCommandPipelineEventContext, CancellationToken, Task>, Action<AfterCommandPipelineEventContext>, AfterCommandPipelineEventContext> OnAfterCommand { get; set; } = new AfterCommandPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<AfterCompletePipelineEventContext, CancellationToken, Task>, Action<AfterCompletePipelineEventContext>, AfterCompletePipelineEventContext> OnAfterComplete { get; set; } = new AfterCompletePipelineEventStageSubscriptionRegistrar();

        //select
        public PipelineEventStageSubscriptionRegistrar<Func<BeforeSelectStartPipelineEventContext, CancellationToken, Task>, Action<BeforeSelectStartPipelineEventContext>, BeforeSelectStartPipelineEventContext> OnBeforeSelectStart { get; set; } = new BeforeSelectStartPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<AfterSelectAssemblyPipelineEventContext, CancellationToken, Task>, Action<AfterSelectAssemblyPipelineEventContext>, AfterSelectAssemblyPipelineEventContext> OnAfterSelectAssembly { get; set; } = new AfterSelectAssemblyPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<BeforeSelectCommandPipelineEventContext, CancellationToken, Task>, Action<BeforeSelectCommandPipelineEventContext>, BeforeSelectCommandPipelineEventContext> OnBeforeSelectCommand { get; set; } = new BeforeSelectCommandPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<AfterSelectCommandPipelineEventContext, CancellationToken, Task>, Action<AfterSelectCommandPipelineEventContext>, AfterSelectCommandPipelineEventContext> OnAfterSelectCommand { get; set; } = new AfterSelectCommandPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<AfterSelectCompletePipelineEventContext, CancellationToken, Task>, Action<AfterSelectCompletePipelineEventContext>, AfterSelectCompletePipelineEventContext> OnAfterSelectComplete { get; set; } = new AfterSelectCompletePipelineEventStageSubscriptionRegistrar();

        //insert
        public PipelineEventStageSubscriptionRegistrar<Func<BeforeInsertStartPipelineEventContext, CancellationToken, Task>, Action<BeforeInsertStartPipelineEventContext>, BeforeInsertStartPipelineEventContext> OnBeforeInsertStart { get; set; } = new BeforeInsertStartPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<AfterInsertAssemblyPipelineEventContext, CancellationToken, Task>, Action<AfterInsertAssemblyPipelineEventContext>, AfterInsertAssemblyPipelineEventContext> OnAfterInsertAssembly { get; set; } = new AfterInsertAssemblyPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<BeforeInsertCommandPipelineEventContext, CancellationToken, Task>, Action<BeforeInsertCommandPipelineEventContext>, BeforeInsertCommandPipelineEventContext> OnBeforeInsertCommand { get; set; } = new BeforeInsertCommandPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<AfterInsertCommandPipelineEventContext, CancellationToken, Task>, Action<AfterInsertCommandPipelineEventContext>, AfterInsertCommandPipelineEventContext> OnAfterInsertCommand { get; set; } = new AfterInsertCommandPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<AfterInsertCompletePipelineEventContext, CancellationToken, Task>, Action<AfterInsertCompletePipelineEventContext>, AfterInsertCompletePipelineEventContext> OnAfterInsertComplete { get; set; } = new AfterInsertCompletePipelineEventStageSubscriptionRegistrar();

        //update
        public PipelineEventStageSubscriptionRegistrar<Func<BeforeUpdateStartPipelineEventContext, CancellationToken, Task>, Action<BeforeUpdateStartPipelineEventContext>, BeforeUpdateStartPipelineEventContext> OnBeforeUpdateStart { get; set; } = new BeforeUpdateStartPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<AfterUpdateAssemblyPipelineEventContext, CancellationToken, Task>, Action<AfterUpdateAssemblyPipelineEventContext>, AfterUpdateAssemblyPipelineEventContext> OnAfterUpdateAssembly { get; set; } = new AfterUpdateAssemblyPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<BeforeUpdateCommandPipelineEventContext, CancellationToken, Task>, Action<BeforeUpdateCommandPipelineEventContext>, BeforeUpdateCommandPipelineEventContext> OnBeforeUpdateCommand { get; set; } = new BeforeUpdateCommandPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<AfterUpdateCommandPipelineEventContext, CancellationToken, Task>, Action<AfterUpdateCommandPipelineEventContext>, AfterUpdateCommandPipelineEventContext> OnAfterUpdateCommand { get; set; } = new AfterUpdateCommandPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<AfterUpdateCompletePipelineEventContext, CancellationToken, Task>, Action<AfterUpdateCompletePipelineEventContext>, AfterUpdateCompletePipelineEventContext> OnAfterUpdateComplete { get; set; } = new AfterUpdateCompletePipelineEventStageSubscriptionRegistrar();

        //delete
        public PipelineEventStageSubscriptionRegistrar<Func<BeforeDeleteStartPipelineEventContext, CancellationToken, Task>, Action<BeforeDeleteStartPipelineEventContext>, BeforeDeleteStartPipelineEventContext> OnBeforeDeleteStart { get; set; } = new BeforeDeleteStartPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<AfterDeleteAssemblyPipelineEventContext, CancellationToken, Task>, Action<AfterDeleteAssemblyPipelineEventContext>, AfterDeleteAssemblyPipelineEventContext> OnAfterDeleteAssembly { get; set; } = new AfterDeleteAssemblyPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<BeforeDeleteCommandPipelineEventContext, CancellationToken, Task>, Action<BeforeDeleteCommandPipelineEventContext>, BeforeDeleteCommandPipelineEventContext> OnBeforeDeleteCommand { get; set; } = new BeforeDeleteCommandPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<AfterDeleteCommandPipelineEventContext, CancellationToken, Task>, Action<AfterDeleteCommandPipelineEventContext>, AfterDeleteCommandPipelineEventContext> OnAfterDeleteCommand { get; set; } = new AfterDeleteCommandPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<AfterDeleteCompletePipelineEventContext, CancellationToken, Task>, Action<AfterDeleteCompletePipelineEventContext>, AfterDeleteCompletePipelineEventContext> OnAfterDeleteComplete { get; set; } = new AfterDeleteCompletePipelineEventStageSubscriptionRegistrar();

        //stored procedure
        public PipelineEventStageSubscriptionRegistrar<Func<BeforeStoredProcedureStartPipelineEventContext, CancellationToken, Task>, Action<BeforeStoredProcedureStartPipelineEventContext>, BeforeStoredProcedureStartPipelineEventContext> OnBeforeStoredProcedureStart { get; set; } = new BeforeStoredProcedureStartPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<AfterStoredProcedureAssemblyPipelineEventContext, CancellationToken, Task>, Action<AfterStoredProcedureAssemblyPipelineEventContext>, AfterStoredProcedureAssemblyPipelineEventContext> OnAfterStoredProcedureAssembly { get; set; } = new AfterStoredProcedureAssemblyPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<BeforeStoredProcedureCommandPipelineEventContext, CancellationToken, Task>, Action<BeforeStoredProcedureCommandPipelineEventContext>, BeforeStoredProcedureCommandPipelineEventContext> OnBeforeStoredProcedureCommand { get; set; } = new BeforeStoredProcedureCommandPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<AfterStoredProcedureCommandPipelineEventContext, CancellationToken, Task>, Action<AfterStoredProcedureCommandPipelineEventContext>, AfterStoredProcedureCommandPipelineEventContext> OnAfterStoredProcedureCommand { get; set; } = new AfterStoredProcedureCommandPipelineEventStageSubscriptionRegistrar();
        public PipelineEventStageSubscriptionRegistrar<Func<AfterStoredProcedureCompletePipelineEventContext, CancellationToken, Task>, Action<AfterStoredProcedureCompletePipelineEventContext>, AfterStoredProcedureCompletePipelineEventContext> OnAfterStoredProcedureComplete { get; set; } = new AfterStoredProcedureCompletePipelineEventStageSubscriptionRegistrar();
    }
}
