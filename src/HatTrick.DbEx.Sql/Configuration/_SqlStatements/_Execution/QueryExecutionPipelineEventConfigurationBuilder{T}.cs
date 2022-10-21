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

using HatTrick.DbEx.Sql.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class QueryExecutionPipelineEventConfigurationBuilder<TDatabase> : IQueryExecutionPipelineEventConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly IServiceCollection services;
        private readonly PipelineEventSubscriptionsRegistrar<TDatabase> events = new();
        #endregion

        #region constructors
        public QueryExecutionPipelineEventConfigurationBuilder(IServiceCollection services)
        {
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }
        #endregion

        #region methods
        public void Build()
        {
            var subscriptions = new PipelineEventSubscriptions();
            
            //common
            if (events.OnBeforeStart.SyncActions.Any() || events.OnBeforeStart.AsyncActions.Any()) subscriptions.OnBeforeStart = new PipelineEventStageSubscriptions<BeforeStartPipelineEventContext>(events.OnBeforeStart.SyncActions, events.OnBeforeStart.AsyncActions);
            if (events.OnAfterAssembly.SyncActions.Any() || events.OnAfterAssembly.AsyncActions.Any()) subscriptions.OnAfterAssembly = new PipelineEventStageSubscriptions<AfterAssemblyPipelineEventContext>(events.OnAfterAssembly.SyncActions, events.OnAfterAssembly.AsyncActions);
            if (events.OnBeforeCommand.SyncActions.Any() || events.OnBeforeCommand.AsyncActions.Any()) subscriptions.OnBeforeCommand = new PipelineEventStageSubscriptions<BeforeCommandPipelineEventContext>(events.OnBeforeCommand.SyncActions, events.OnBeforeCommand.AsyncActions);
            if (events.OnAfterCommand.SyncActions.Any() || events.OnAfterCommand.AsyncActions.Any()) subscriptions.OnAfterCommand = new PipelineEventStageSubscriptions<AfterCommandPipelineEventContext>(events.OnAfterCommand.SyncActions, events.OnAfterCommand.AsyncActions);
            if (events.OnAfterComplete.SyncActions.Any() || events.OnAfterComplete.AsyncActions.Any()) subscriptions.OnAfterComplete = new PipelineEventStageSubscriptions<AfterCompletePipelineEventContext>(events.OnAfterComplete.SyncActions, events.OnAfterComplete.AsyncActions);

            //select
            if (events.OnBeforeSelectStart.SyncActions.Any() || events.OnBeforeSelectStart.AsyncActions.Any()) subscriptions.OnBeforeSelectStart = new PipelineEventStageSubscriptions<BeforeSelectStartPipelineEventContext>(events.OnBeforeSelectStart.SyncActions, events.OnBeforeSelectStart.AsyncActions);
            if (events.OnAfterSelectAssembly.SyncActions.Any() || events.OnAfterSelectAssembly.AsyncActions.Any()) subscriptions.OnAfterSelectAssembly = new PipelineEventStageSubscriptions<AfterSelectAssemblyPipelineEventContext>(events.OnAfterSelectAssembly.SyncActions, events.OnAfterSelectAssembly.AsyncActions);
            if (events.OnBeforeSelectCommand.SyncActions.Any() || events.OnBeforeSelectCommand.AsyncActions.Any()) subscriptions.OnBeforeSelectCommand = new PipelineEventStageSubscriptions<BeforeSelectCommandPipelineEventContext>(events.OnBeforeSelectCommand.SyncActions, events.OnBeforeSelectCommand.AsyncActions);
            if (events.OnAfterSelectCommand.SyncActions.Any() || events.OnAfterSelectCommand.AsyncActions.Any()) subscriptions.OnAfterSelectCommand = new PipelineEventStageSubscriptions<AfterSelectCommandPipelineEventContext>(events.OnAfterSelectCommand.SyncActions, events.OnAfterSelectCommand.AsyncActions);
            if (events.OnAfterSelectComplete.SyncActions.Any() || events.OnAfterSelectComplete.AsyncActions.Any()) subscriptions.OnAfterSelectComplete = new PipelineEventStageSubscriptions<AfterSelectCompletePipelineEventContext>(events.OnAfterSelectComplete.SyncActions, events.OnAfterSelectComplete.AsyncActions);

            //insert
            if (events.OnBeforeInsertStart.SyncActions.Any() || events.OnBeforeInsertStart.AsyncActions.Any()) subscriptions.OnBeforeInsertStart = new PipelineEventStageSubscriptions<BeforeInsertStartPipelineEventContext>(events.OnBeforeInsertStart.SyncActions, events.OnBeforeInsertStart.AsyncActions);
            if (events.OnAfterInsertAssembly.SyncActions.Any() || events.OnAfterInsertAssembly.AsyncActions.Any()) subscriptions.OnAfterInsertAssembly = new PipelineEventStageSubscriptions<AfterInsertAssemblyPipelineEventContext>(events.OnAfterInsertAssembly.SyncActions, events.OnAfterInsertAssembly.AsyncActions);
            if (events.OnBeforeInsertCommand.SyncActions.Any() || events.OnBeforeInsertCommand.AsyncActions.Any()) subscriptions.OnBeforeInsertCommand = new PipelineEventStageSubscriptions<BeforeInsertCommandPipelineEventContext>(events.OnBeforeInsertCommand.SyncActions, events.OnBeforeInsertCommand.AsyncActions);
            if (events.OnAfterInsertCommand.SyncActions.Any() || events.OnAfterInsertCommand.AsyncActions.Any()) subscriptions.OnAfterInsertCommand = new PipelineEventStageSubscriptions<AfterInsertCommandPipelineEventContext>(events.OnAfterInsertCommand.SyncActions, events.OnAfterInsertCommand.AsyncActions);
            if (events.OnAfterInsertComplete.SyncActions.Any() || events.OnAfterInsertComplete.AsyncActions.Any()) subscriptions.OnAfterInsertComplete = new PipelineEventStageSubscriptions<AfterInsertCompletePipelineEventContext>(events.OnAfterInsertComplete.SyncActions, events.OnAfterInsertComplete.AsyncActions);

            //update
            if (events.OnBeforeUpdateStart.SyncActions.Any() || events.OnBeforeUpdateStart.AsyncActions.Any()) subscriptions.OnBeforeUpdateStart = new PipelineEventStageSubscriptions<BeforeUpdateStartPipelineEventContext>(events.OnBeforeUpdateStart.SyncActions, events.OnBeforeUpdateStart.AsyncActions);
            if (events.OnAfterUpdateAssembly.SyncActions.Any() || events.OnAfterUpdateAssembly.AsyncActions.Any()) subscriptions.OnAfterUpdateAssembly = new PipelineEventStageSubscriptions<AfterUpdateAssemblyPipelineEventContext>(events.OnAfterUpdateAssembly.SyncActions, events.OnAfterUpdateAssembly.AsyncActions);
            if (events.OnBeforeUpdateCommand.SyncActions.Any() || events.OnBeforeUpdateCommand.AsyncActions.Any()) subscriptions.OnBeforeUpdateCommand = new PipelineEventStageSubscriptions<BeforeUpdateCommandPipelineEventContext>(events.OnBeforeUpdateCommand.SyncActions, events.OnBeforeUpdateCommand.AsyncActions);
            if (events.OnAfterUpdateCommand.SyncActions.Any() || events.OnAfterUpdateCommand.AsyncActions.Any()) subscriptions.OnAfterUpdateCommand = new PipelineEventStageSubscriptions<AfterUpdateCommandPipelineEventContext>(events.OnAfterUpdateCommand.SyncActions, events.OnAfterUpdateCommand.AsyncActions);
            if (events.OnAfterUpdateComplete.SyncActions.Any() || events.OnAfterUpdateComplete.AsyncActions.Any()) subscriptions.OnAfterUpdateComplete = new PipelineEventStageSubscriptions<AfterUpdateCompletePipelineEventContext>(events.OnAfterUpdateComplete.SyncActions, events.OnAfterUpdateComplete.AsyncActions);

            //delete
            if (events.OnBeforeDeleteStart.SyncActions.Any() || events.OnBeforeDeleteStart.AsyncActions.Any()) subscriptions.OnBeforeDeleteStart = new PipelineEventStageSubscriptions<BeforeDeleteStartPipelineEventContext>(events.OnBeforeDeleteStart.SyncActions, events.OnBeforeDeleteStart.AsyncActions);
            if (events.OnAfterDeleteAssembly.SyncActions.Any() || events.OnAfterDeleteAssembly.AsyncActions.Any()) subscriptions.OnAfterDeleteAssembly = new PipelineEventStageSubscriptions<AfterDeleteAssemblyPipelineEventContext>(events.OnAfterDeleteAssembly.SyncActions, events.OnAfterDeleteAssembly.AsyncActions);
            if (events.OnBeforeDeleteCommand.SyncActions.Any() || events.OnBeforeDeleteCommand.AsyncActions.Any()) subscriptions.OnBeforeDeleteCommand = new PipelineEventStageSubscriptions<BeforeDeleteCommandPipelineEventContext>(events.OnBeforeDeleteCommand.SyncActions, events.OnBeforeDeleteCommand.AsyncActions);
            if (events.OnAfterDeleteCommand.SyncActions.Any() || events.OnAfterDeleteCommand.AsyncActions.Any()) subscriptions.OnAfterDeleteCommand = new PipelineEventStageSubscriptions<AfterDeleteCommandPipelineEventContext>(events.OnAfterDeleteCommand.SyncActions, events.OnAfterDeleteCommand.AsyncActions);
            if (events.OnAfterDeleteComplete.SyncActions.Any() || events.OnAfterDeleteComplete.AsyncActions.Any()) subscriptions.OnAfterDeleteComplete = new PipelineEventStageSubscriptions<AfterDeleteCompletePipelineEventContext>(events.OnAfterDeleteComplete.SyncActions, events.OnAfterDeleteComplete.AsyncActions);

            //stored procedure
            if (events.OnBeforeStoredProcedureStart.SyncActions.Any() || events.OnBeforeStoredProcedureStart.AsyncActions.Any()) subscriptions.OnBeforeStoredProcedureStart = new PipelineEventStageSubscriptions<BeforeStoredProcedureStartPipelineEventContext>(events.OnBeforeStoredProcedureStart.SyncActions, events.OnBeforeStoredProcedureStart.AsyncActions);
            if (events.OnAfterStoredProcedureAssembly.SyncActions.Any() || events.OnAfterStoredProcedureAssembly.AsyncActions.Any()) subscriptions.OnAfterStoredProcedureAssembly = new PipelineEventStageSubscriptions<AfterStoredProcedureAssemblyPipelineEventContext>(events.OnAfterStoredProcedureAssembly.SyncActions, events.OnAfterStoredProcedureAssembly.AsyncActions);
            if (events.OnBeforeStoredProcedureCommand.SyncActions.Any() || events.OnBeforeStoredProcedureCommand.AsyncActions.Any()) subscriptions.OnBeforeStoredProcedureCommand = new PipelineEventStageSubscriptions<BeforeStoredProcedureCommandPipelineEventContext>(events.OnBeforeStoredProcedureCommand.SyncActions, events.OnBeforeStoredProcedureCommand.AsyncActions);
            if (events.OnAfterStoredProcedureCommand.SyncActions.Any() || events.OnAfterStoredProcedureCommand.AsyncActions.Any()) subscriptions.OnAfterStoredProcedureCommand = new PipelineEventStageSubscriptions<AfterStoredProcedureCommandPipelineEventContext>(events.OnAfterStoredProcedureCommand.SyncActions, events.OnAfterStoredProcedureCommand.AsyncActions);
            if (events.OnAfterStoredProcedureComplete.SyncActions.Any() || events.OnAfterStoredProcedureComplete.AsyncActions.Any()) subscriptions.OnAfterStoredProcedureComplete = new PipelineEventStageSubscriptions<AfterStoredProcedureCompletePipelineEventContext>(events.OnAfterStoredProcedureComplete.SyncActions, events.OnAfterStoredProcedureComplete.AsyncActions);

            services.TryAddSingleton<PipelineEventSubscriptions>(subscriptions);
        }

        #region assembly
        #region common
        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStart(Action<BeforeStartPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeStart.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStart(Action<BeforeStartPipelineEventContext> action, Predicate<BeforeStartPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeStart.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStart(Func<BeforeStartPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeStart.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStart(Func<BeforeStartPipelineEventContext, Task> action, Predicate<BeforeStartPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeStart.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStart(Func<BeforeStartPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeStart.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStart(Func<BeforeStartPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeStartPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeStart.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterAssembly(Action<AfterAssemblyPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterAssembly.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterAssembly(Action<AfterAssemblyPipelineEventContext> action, Predicate<AfterAssemblyPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterAssembly.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterAssembly(Func<AfterAssemblyPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterAssembly.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterAssembly(Func<AfterAssemblyPipelineEventContext, Task> action, Predicate<AfterAssemblyPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterAssembly.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterAssembly(Func<AfterAssemblyPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterAssembly.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterAssembly(Func<AfterAssemblyPipelineEventContext, CancellationToken, Task> action, Predicate<AfterAssemblyPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterAssembly.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeCommand(Action<BeforeCommandPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeCommand(Action<BeforeCommandPipelineEventContext> action, Predicate<BeforeCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeCommand(Func<BeforeCommandPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeCommand.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeCommand(Func<BeforeCommandPipelineEventContext, Task> action, Predicate<BeforeCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeCommand.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeCommand(Func<BeforeCommandPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeCommand(Func<BeforeCommandPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterCommand(Action<AfterCommandPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterCommand(Action<AfterCommandPipelineEventContext> action, Predicate<AfterCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterCommand(Func<AfterCommandPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterCommand.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterCommand(Func<AfterCommandPipelineEventContext, Task> action, Predicate<AfterCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterCommand.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterCommand(Func<AfterCommandPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterCommand(Func<AfterCommandPipelineEventContext, CancellationToken, Task> action, Predicate<AfterCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterComplete(Action<AfterCompletePipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterComplete.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterComplete(Action<AfterCompletePipelineEventContext> action, Predicate<AfterCompletePipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterComplete.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterComplete(Func<AfterCompletePipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterComplete.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterComplete(Func<AfterCompletePipelineEventContext, Task> action, Predicate<AfterCompletePipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterComplete.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterComplete(Func<AfterCompletePipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterComplete.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterComplete(Func<AfterCompletePipelineEventContext, CancellationToken, Task> action, Predicate<AfterCompletePipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterComplete.AddToEnd(action, predicate);
            return this;
        }
        #endregion

        #region select
        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectStart(Action<BeforeSelectStartPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeSelectStart.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectStart(Action<BeforeSelectStartPipelineEventContext> action, Predicate<BeforeSelectStartPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeSelectStart.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectStart(Func<BeforeSelectStartPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeSelectStart.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectStart(Func<BeforeSelectStartPipelineEventContext, Task> action, Predicate<BeforeSelectStartPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeSelectStart.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectStart(Func<BeforeSelectStartPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeSelectStart.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectStart(Func<BeforeSelectStartPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeSelectStartPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeSelectStart.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectAssembly(Action<AfterSelectAssemblyPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterSelectAssembly.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectAssembly(Action<AfterSelectAssemblyPipelineEventContext> action, Predicate<AfterSelectAssemblyPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterSelectAssembly.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectAssembly(Func<AfterSelectAssemblyPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterSelectAssembly.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectAssembly(Func<AfterSelectAssemblyPipelineEventContext, Task> action, Predicate<AfterSelectAssemblyPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterSelectAssembly.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectAssembly(Func<AfterSelectAssemblyPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterSelectAssembly.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectAssembly(Func<AfterSelectAssemblyPipelineEventContext, CancellationToken, Task> action, Predicate<AfterSelectAssemblyPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterSelectAssembly.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectCommand(Action<BeforeSelectCommandPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeSelectCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectCommand(Action<BeforeSelectCommandPipelineEventContext> action, Predicate<BeforeSelectCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeSelectCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectCommand(Func<BeforeSelectCommandPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeSelectCommand.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectCommand(Func<BeforeSelectCommandPipelineEventContext, Task> action, Predicate<BeforeSelectCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeSelectCommand.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectCommand(Func<BeforeSelectCommandPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeSelectCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectCommand(Func<BeforeSelectCommandPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeSelectCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeSelectCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectCommand(Action<AfterSelectCommandPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterSelectCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectCommand(Action<AfterSelectCommandPipelineEventContext> action, Predicate<AfterSelectCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterSelectCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectCommand(Func<AfterSelectCommandPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterSelectCommand.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectCommand(Func<AfterSelectCommandPipelineEventContext, Task> action, Predicate<AfterSelectCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterSelectCommand.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectCommand(Func<AfterSelectCommandPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterSelectCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectCommand(Func<AfterSelectCommandPipelineEventContext, CancellationToken, Task> action, Predicate<AfterSelectCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterSelectCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectComplete(Action<AfterSelectCompletePipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterSelectComplete.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectComplete(Action<AfterSelectCompletePipelineEventContext> action, Predicate<AfterSelectCompletePipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterSelectComplete.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectComplete(Func<AfterSelectCompletePipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterSelectComplete.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectComplete(Func<AfterSelectCompletePipelineEventContext, Task> action, Predicate<AfterSelectCompletePipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterSelectComplete.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectComplete(Func<AfterSelectCompletePipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterSelectComplete.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectComplete(Func<AfterSelectCompletePipelineEventContext, CancellationToken, Task> action, Predicate<AfterSelectCompletePipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterSelectComplete.AddToEnd(action, predicate);
            return this;
        }
        #endregion

        #region insert
        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertStart(Action<BeforeInsertStartPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeInsertStart.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertStart(Action<BeforeInsertStartPipelineEventContext> action, Predicate<BeforeInsertStartPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeInsertStart.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertStart(Func<BeforeInsertStartPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeInsertStart.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertStart(Func<BeforeInsertStartPipelineEventContext, Task> action, Predicate<BeforeInsertStartPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeInsertStart.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertStart(Func<BeforeInsertStartPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeInsertStart.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertStart(Func<BeforeInsertStartPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeInsertStartPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeInsertStart.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertAssembly(Action<AfterInsertAssemblyPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterInsertAssembly.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertAssembly(Action<AfterInsertAssemblyPipelineEventContext> action, Predicate<AfterInsertAssemblyPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterInsertAssembly.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertAssembly(Func<AfterInsertAssemblyPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterInsertAssembly.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertAssembly(Func<AfterInsertAssemblyPipelineEventContext, Task> action, Predicate<AfterInsertAssemblyPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterInsertAssembly.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertAssembly(Func<AfterInsertAssemblyPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterInsertAssembly.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertAssembly(Func<AfterInsertAssemblyPipelineEventContext, CancellationToken, Task> action, Predicate<AfterInsertAssemblyPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterInsertAssembly.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertCommand(Action<BeforeInsertCommandPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeInsertCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertCommand(Action<BeforeInsertCommandPipelineEventContext> action, Predicate<BeforeInsertCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeInsertCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertCommand(Func<BeforeInsertCommandPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeInsertCommand.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertCommand(Func<BeforeInsertCommandPipelineEventContext, Task> action, Predicate<BeforeInsertCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeInsertCommand.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertCommand(Func<BeforeInsertCommandPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeInsertCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertCommand(Func<BeforeInsertCommandPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeInsertCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeInsertCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertCommand(Action<AfterInsertCommandPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterInsertCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertCommand(Action<AfterInsertCommandPipelineEventContext> action, Predicate<AfterInsertCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterInsertCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertCommand(Func<AfterInsertCommandPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterInsertCommand.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertCommand(Func<AfterInsertCommandPipelineEventContext, Task> action, Predicate<AfterInsertCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterInsertCommand.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertCommand(Func<AfterInsertCommandPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterInsertCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertCommand(Func<AfterInsertCommandPipelineEventContext, CancellationToken, Task> action, Predicate<AfterInsertCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterInsertCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertComplete(Action<AfterInsertCompletePipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterInsertComplete.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertComplete(Action<AfterInsertCompletePipelineEventContext> action, Predicate<AfterInsertCompletePipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterInsertComplete.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertComplete(Func<AfterInsertCompletePipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterInsertComplete.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertComplete(Func<AfterInsertCompletePipelineEventContext, Task> action, Predicate<AfterInsertCompletePipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterInsertComplete.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertComplete(Func<AfterInsertCompletePipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterInsertComplete.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertComplete(Func<AfterInsertCompletePipelineEventContext, CancellationToken, Task> action, Predicate<AfterInsertCompletePipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterInsertComplete.AddToEnd(action, predicate);
            return this;
        }
        #endregion

        #region update
        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateStart(Action<BeforeUpdateStartPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeUpdateStart.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateStart(Action<BeforeUpdateStartPipelineEventContext> action, Predicate<BeforeUpdateStartPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeUpdateStart.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateStart(Func<BeforeUpdateStartPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeUpdateStart.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateStart(Func<BeforeUpdateStartPipelineEventContext, Task> action, Predicate<BeforeUpdateStartPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeUpdateStart.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateStart(Func<BeforeUpdateStartPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeUpdateStart.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateStart(Func<BeforeUpdateStartPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeUpdateStartPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeUpdateStart.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateAssembly(Action<AfterUpdateAssemblyPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterUpdateAssembly.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateAssembly(Action<AfterUpdateAssemblyPipelineEventContext> action, Predicate<AfterUpdateAssemblyPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterUpdateAssembly.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateAssembly(Func<AfterUpdateAssemblyPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterUpdateAssembly.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateAssembly(Func<AfterUpdateAssemblyPipelineEventContext, Task> action, Predicate<AfterUpdateAssemblyPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterUpdateAssembly.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateAssembly(Func<AfterUpdateAssemblyPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterUpdateAssembly.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateAssembly(Func<AfterUpdateAssemblyPipelineEventContext, CancellationToken, Task> action, Predicate<AfterUpdateAssemblyPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterUpdateAssembly.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateCommand(Action<BeforeUpdateCommandPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeUpdateCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateCommand(Action<BeforeUpdateCommandPipelineEventContext> action, Predicate<BeforeUpdateCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeUpdateCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateCommand(Func<BeforeUpdateCommandPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeUpdateCommand.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateCommand(Func<BeforeUpdateCommandPipelineEventContext, Task> action, Predicate<BeforeUpdateCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeUpdateCommand.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateCommand(Func<BeforeUpdateCommandPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeUpdateCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateCommand(Func<BeforeUpdateCommandPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeUpdateCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeUpdateCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateCommand(Action<AfterUpdateCommandPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterUpdateCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateCommand(Action<AfterUpdateCommandPipelineEventContext> action, Predicate<AfterUpdateCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterUpdateCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateCommand(Func<AfterUpdateCommandPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterUpdateCommand.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateCommand(Func<AfterUpdateCommandPipelineEventContext, Task> action, Predicate<AfterUpdateCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterUpdateCommand.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateCommand(Func<AfterUpdateCommandPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterUpdateCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateCommand(Func<AfterUpdateCommandPipelineEventContext, CancellationToken, Task> action, Predicate<AfterUpdateCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterUpdateCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateComplete(Action<AfterUpdateCompletePipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterUpdateComplete.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateComplete(Action<AfterUpdateCompletePipelineEventContext> action, Predicate<AfterUpdateCompletePipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterUpdateComplete.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateComplete(Func<AfterUpdateCompletePipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterUpdateComplete.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateComplete(Func<AfterUpdateCompletePipelineEventContext, Task> action, Predicate<AfterUpdateCompletePipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterUpdateComplete.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateComplete(Func<AfterUpdateCompletePipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterUpdateComplete.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateComplete(Func<AfterUpdateCompletePipelineEventContext, CancellationToken, Task> action, Predicate<AfterUpdateCompletePipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterUpdateComplete.AddToEnd(action, predicate);
            return this;
        }
        #endregion

        #region delete
        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteStart(Action<BeforeDeleteStartPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeDeleteStart.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteStart(Action<BeforeDeleteStartPipelineEventContext> action, Predicate<BeforeDeleteStartPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeDeleteStart.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteStart(Func<BeforeDeleteStartPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeDeleteStart.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteStart(Func<BeforeDeleteStartPipelineEventContext, Task> action, Predicate<BeforeDeleteStartPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeDeleteStart.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteStart(Func<BeforeDeleteStartPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeDeleteStart.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteStart(Func<BeforeDeleteStartPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeDeleteStartPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeDeleteStart.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteAssembly(Action<AfterDeleteAssemblyPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterDeleteAssembly.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteAssembly(Action<AfterDeleteAssemblyPipelineEventContext> action, Predicate<AfterDeleteAssemblyPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterDeleteAssembly.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteAssembly(Func<AfterDeleteAssemblyPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterDeleteAssembly.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteAssembly(Func<AfterDeleteAssemblyPipelineEventContext, Task> action, Predicate<AfterDeleteAssemblyPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterDeleteAssembly.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteAssembly(Func<AfterDeleteAssemblyPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterDeleteAssembly.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteAssembly(Func<AfterDeleteAssemblyPipelineEventContext, CancellationToken, Task> action, Predicate<AfterDeleteAssemblyPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterDeleteAssembly.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteCommand(Action<BeforeDeleteCommandPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeDeleteCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteCommand(Action<BeforeDeleteCommandPipelineEventContext> action, Predicate<BeforeDeleteCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeDeleteCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteCommand(Func<BeforeDeleteCommandPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeDeleteCommand.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteCommand(Func<BeforeDeleteCommandPipelineEventContext, Task> action, Predicate<BeforeDeleteCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeDeleteCommand.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteCommand(Func<BeforeDeleteCommandPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeDeleteCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteCommand(Func<BeforeDeleteCommandPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeDeleteCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeDeleteCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteCommand(Action<AfterDeleteCommandPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterDeleteCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteCommand(Action<AfterDeleteCommandPipelineEventContext> action, Predicate<AfterDeleteCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterDeleteCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteCommand(Func<AfterDeleteCommandPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterDeleteCommand.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteCommand(Func<AfterDeleteCommandPipelineEventContext, Task> action, Predicate<AfterDeleteCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterDeleteCommand.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteCommand(Func<AfterDeleteCommandPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterDeleteCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteCommand(Func<AfterDeleteCommandPipelineEventContext, CancellationToken, Task> action, Predicate<AfterDeleteCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterDeleteCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteComplete(Action<AfterDeleteCompletePipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterDeleteComplete.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteComplete(Action<AfterDeleteCompletePipelineEventContext> action, Predicate<AfterDeleteCompletePipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterDeleteComplete.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteComplete(Func<AfterDeleteCompletePipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterDeleteComplete.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteComplete(Func<AfterDeleteCompletePipelineEventContext, Task> action, Predicate<AfterDeleteCompletePipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterDeleteComplete.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteComplete(Func<AfterDeleteCompletePipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterDeleteComplete.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteComplete(Func<AfterDeleteCompletePipelineEventContext, CancellationToken, Task> action, Predicate<AfterDeleteCompletePipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterDeleteComplete.AddToEnd(action, predicate);
            return this;
        }
        #endregion

        #region stored procedure
        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureStart(Action<BeforeStoredProcedureStartPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeStoredProcedureStart.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureStart(Action<BeforeStoredProcedureStartPipelineEventContext> action, Predicate<BeforeStoredProcedureStartPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeStoredProcedureStart.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureStart(Func<BeforeStoredProcedureStartPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeStoredProcedureStart.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureStart(Func<BeforeStoredProcedureStartPipelineEventContext, Task> action, Predicate<BeforeStoredProcedureStartPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeStoredProcedureStart.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureStart(Func<BeforeStoredProcedureStartPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeStoredProcedureStart.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureStart(Func<BeforeStoredProcedureStartPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeStoredProcedureStartPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeStoredProcedureStart.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureAssembly(Action<AfterStoredProcedureAssemblyPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterStoredProcedureAssembly.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureAssembly(Action<AfterStoredProcedureAssemblyPipelineEventContext> action, Predicate<AfterStoredProcedureAssemblyPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterStoredProcedureAssembly.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureAssembly(Func<AfterStoredProcedureAssemblyPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterStoredProcedureAssembly.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureAssembly(Func<AfterStoredProcedureAssemblyPipelineEventContext, Task> action, Predicate<AfterStoredProcedureAssemblyPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterStoredProcedureAssembly.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureAssembly(Func<AfterStoredProcedureAssemblyPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterStoredProcedureAssembly.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureAssembly(Func<AfterStoredProcedureAssemblyPipelineEventContext, CancellationToken, Task> action, Predicate<AfterStoredProcedureAssemblyPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterStoredProcedureAssembly.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureCommand(Action<BeforeStoredProcedureCommandPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeStoredProcedureCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureCommand(Action<BeforeStoredProcedureCommandPipelineEventContext> action, Predicate<BeforeStoredProcedureCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeStoredProcedureCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureCommand(Func<BeforeStoredProcedureCommandPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeStoredProcedureCommand.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureCommand(Func<BeforeStoredProcedureCommandPipelineEventContext, Task> action, Predicate<BeforeStoredProcedureCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeStoredProcedureCommand.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureCommand(Func<BeforeStoredProcedureCommandPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnBeforeStoredProcedureCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureCommand(Func<BeforeStoredProcedureCommandPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeStoredProcedureCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnBeforeStoredProcedureCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureCommand(Action<AfterStoredProcedureCommandPipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterStoredProcedureCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureCommand(Action<AfterStoredProcedureCommandPipelineEventContext> action, Predicate<AfterStoredProcedureCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterStoredProcedureCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureCommand(Func<AfterStoredProcedureCommandPipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterStoredProcedureCommand.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureCommand(Func<AfterStoredProcedureCommandPipelineEventContext, Task> action, Predicate<AfterStoredProcedureCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterStoredProcedureCommand.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureCommand(Func<AfterStoredProcedureCommandPipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterStoredProcedureCommand.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureCommand(Func<AfterStoredProcedureCommandPipelineEventContext, CancellationToken, Task> action, Predicate<AfterStoredProcedureCommandPipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterStoredProcedureCommand.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureComplete(Action<AfterStoredProcedureCompletePipelineEventContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterStoredProcedureComplete.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureComplete(Action<AfterStoredProcedureCompletePipelineEventContext> action, Predicate<AfterStoredProcedureCompletePipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterStoredProcedureComplete.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureComplete(Func<AfterStoredProcedureCompletePipelineEventContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterStoredProcedureComplete.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureComplete(Func<AfterStoredProcedureCompletePipelineEventContext, Task> action, Predicate<AfterStoredProcedureCompletePipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterStoredProcedureComplete.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureComplete(Func<AfterStoredProcedureCompletePipelineEventContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.OnAfterStoredProcedureComplete.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureComplete(Func<AfterStoredProcedureCompletePipelineEventContext, CancellationToken, Task> action, Predicate<AfterStoredProcedureCompletePipelineEventContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.OnAfterStoredProcedureComplete.AddToEnd(action, predicate);
            return this;
        }
        #endregion
        #endregion
        #endregion
    }
}
