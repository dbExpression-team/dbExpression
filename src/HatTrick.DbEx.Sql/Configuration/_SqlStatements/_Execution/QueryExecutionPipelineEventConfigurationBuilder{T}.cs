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
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class QueryExecutionPipelineEventConfigurationBuilder<TDatabase> : IQueryExecutionPipelineEventConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly IServiceCollection services;
        private readonly PipelineEventActions<TDatabase> events = new();
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
            var hooks = new PipelineEventHooks<TDatabase>()
            {
                BeforeAssembly = new PipelineEventHook<BeforeAssemblyPipelineExecutionContext>(events.BeforeAssembly.SyncActions, events.BeforeAssembly.AsyncActions),
                BeforeUpdateAssembly = new PipelineEventHook<BeforeUpdateAssemblyPipelineExecutionContext>(events.BeforeUpdateAssembly.SyncActions, events.BeforeUpdateAssembly.AsyncActions),
                BeforeInsertAssembly = new PipelineEventHook<BeforeInsertAssemblyPipelineExecutionContext>(events.BeforeInsertAssembly.SyncActions, events.BeforeInsertAssembly.AsyncActions),
                AfterAssembly = new PipelineEventHook<AfterAssemblyPipelineExecutionContext>(events.AfterAssembly.SyncActions, events.AfterAssembly.AsyncActions),
                BeforeExecution = new PipelineEventHook<BeforeExecutionPipelineExecutionContext>(events.BeforeExecution.SyncActions, events.BeforeExecution.AsyncActions),
                AfterExecution = new PipelineEventHook<AfterExecutionPipelineExecutionContext>(events.AfterExecution.SyncActions, events.AfterExecution.AsyncActions),
                BeforeInsert = new PipelineEventHook<BeforeInsertPipelineExecutionContext>(events.BeforeInsert.SyncActions, events.BeforeInsert.AsyncActions),
                AfterInsert = new PipelineEventHook<AfterInsertPipelineExecutionContext>(events.AfterInsert.SyncActions, events.AfterInsert.AsyncActions),
                BeforeDelete = new PipelineEventHook<BeforeDeletePipelineExecutionContext>(events.BeforeDelete.SyncActions, events.BeforeDelete.AsyncActions),
                AfterDelete = new PipelineEventHook<AfterDeletePipelineExecutionContext>(events.AfterDelete.SyncActions, events.AfterDelete.AsyncActions),
                BeforeUpdate = new PipelineEventHook<BeforeUpdatePipelineExecutionContext>(events.BeforeUpdate.SyncActions, events.BeforeUpdate.AsyncActions),
                AfterUpdate = new PipelineEventHook<AfterUpdatePipelineExecutionContext>(events.AfterUpdate.SyncActions, events.AfterUpdate.AsyncActions),
                BeforeSelect = new PipelineEventHook<BeforeSelectPipelineExecutionContext>(events.BeforeSelect.SyncActions, events.BeforeSelect.AsyncActions),
                AfterSelect = new PipelineEventHook<AfterSelectPipelineExecutionContext>(events.AfterSelect.SyncActions, events.AfterSelect.AsyncActions),
                BeforeStoredProcedure = new PipelineEventHook<BeforeStoredProcedurePipelineExecutionContext>(events.BeforeStoredProcedure.SyncActions, events.BeforeStoredProcedure.AsyncActions),
                AfterStoredProcedure = new PipelineEventHook<AfterStoredProcedurePipelineExecutionContext>(events.AfterStoredProcedure.SyncActions, events.AfterStoredProcedure.AsyncActions)
            };
            services.TryAddSingleton<PipelineEventHooks<TDatabase>>(hooks);
        }

        #region assembly
        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementAssembly(Action<BeforeAssemblyPipelineExecutionContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeAssembly.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementAssembly(Action<BeforeAssemblyPipelineExecutionContext> action, Predicate<BeforeAssemblyPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeAssembly.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementAssembly(Func<BeforeAssemblyPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeAssembly.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementAssembly(Func<BeforeAssemblyPipelineExecutionContext, Task> action, Predicate<BeforeAssemblyPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeAssembly.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementAssembly(Func<BeforeAssemblyPipelineExecutionContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeAssembly.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementAssembly(Func<BeforeAssemblyPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeAssemblyPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeAssembly.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementAssembly(Action<AfterAssemblyPipelineExecutionContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.AfterAssembly.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementAssembly(Action<AfterAssemblyPipelineExecutionContext> action, Predicate<AfterAssemblyPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.AfterAssembly.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementAssembly(Func<AfterAssemblyPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.AfterAssembly.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementAssembly(Func<AfterAssemblyPipelineExecutionContext, Task> action, Predicate<AfterAssemblyPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.AfterAssembly.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementAssembly(Func<AfterAssemblyPipelineExecutionContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.AfterAssembly.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementAssembly(Func<AfterAssemblyPipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterAssemblyPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.AfterAssembly.AddToEnd(action, predicate);
            return this;
        }

        #region update
        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateSqlStatementAssembly(Action<BeforeUpdateAssemblyPipelineExecutionContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeUpdateAssembly.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateSqlStatementAssembly(Action<BeforeUpdateAssemblyPipelineExecutionContext> action, Predicate<BeforeUpdateAssemblyPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeUpdateAssembly.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateSqlStatementAssembly(Func<BeforeUpdateAssemblyPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeUpdateAssembly.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateSqlStatementAssembly(Func<BeforeUpdateAssemblyPipelineExecutionContext, Task> action, Predicate<BeforeUpdateAssemblyPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeUpdateAssembly.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateSqlStatementAssembly(Func<BeforeUpdateAssemblyPipelineExecutionContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeUpdateAssembly.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateSqlStatementAssembly(Func<BeforeUpdateAssemblyPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeUpdateAssemblyPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeUpdateAssembly.AddToEnd(action, predicate);
            return this;
        }
        #endregion

        #region insert
        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertSqlStatementAssembly(Action<BeforeInsertAssemblyPipelineExecutionContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeInsertAssembly.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertSqlStatementAssembly(Action<BeforeInsertAssemblyPipelineExecutionContext> action, Predicate<BeforeInsertAssemblyPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeInsertAssembly.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertSqlStatementAssembly(Func<BeforeInsertAssemblyPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeInsertAssembly.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertSqlStatementAssembly(Func<BeforeInsertAssemblyPipelineExecutionContext, Task> action, Predicate<BeforeInsertAssemblyPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeInsertAssembly.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertSqlStatementAssembly(Func<BeforeInsertAssemblyPipelineExecutionContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeInsertAssembly.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertSqlStatementAssembly(Func<BeforeInsertAssemblyPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeInsertAssemblyPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeInsertAssembly.AddToEnd(action, predicate);
            return this;
        }
        #endregion
        #endregion

        #region insert
        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertQueryExecution(Action<BeforeInsertPipelineExecutionContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeInsert.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertQueryExecution(Action<BeforeInsertPipelineExecutionContext> action, Predicate<BeforeInsertPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeInsert.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertQueryExecution(Func<BeforeInsertPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeInsert.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertQueryExecution(Func<BeforeInsertPipelineExecutionContext, Task> action, Predicate<BeforeInsertPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeInsert.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertQueryExecution(Func<BeforeInsertPipelineExecutionContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeInsert.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertQueryExecution(Func<BeforeInsertPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeInsertPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeInsert.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertQueryExecution(Action<AfterInsertPipelineExecutionContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.AfterInsert.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertQueryExecution(Action<AfterInsertPipelineExecutionContext> action, Predicate<AfterInsertPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.AfterInsert.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertQueryExecution(Func<AfterInsertPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.AfterInsert.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertQueryExecution(Func<AfterInsertPipelineExecutionContext, Task> action, Predicate<AfterInsertPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.AfterInsert.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertQueryExecution(Func<AfterInsertPipelineExecutionContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.AfterInsert.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertQueryExecution(Func<AfterInsertPipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterInsertPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.AfterInsert.AddToEnd(action, predicate);
            return this;
        }
        #endregion

        #region update
        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateQueryExecution(Action<BeforeUpdatePipelineExecutionContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeUpdate.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateQueryExecution(Action<BeforeUpdatePipelineExecutionContext> action, Predicate<BeforeUpdatePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeUpdate.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateQueryExecution(Func<BeforeUpdatePipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeUpdate.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateQueryExecution(Func<BeforeUpdatePipelineExecutionContext, Task> action, Predicate<BeforeUpdatePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeUpdate.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateQueryExecution(Func<BeforeUpdatePipelineExecutionContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeUpdate.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateQueryExecution(Func<BeforeUpdatePipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeUpdatePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeUpdate.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateQueryExecution(Action<AfterUpdatePipelineExecutionContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.AfterUpdate.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateQueryExecution(Action<AfterUpdatePipelineExecutionContext> action, Predicate<AfterUpdatePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.AfterUpdate.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateQueryExecution(Func<AfterUpdatePipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.AfterUpdate.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateQueryExecution(Func<AfterUpdatePipelineExecutionContext, Task> action, Predicate<AfterUpdatePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.AfterUpdate.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateQueryExecution(Func<AfterUpdatePipelineExecutionContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.AfterUpdate.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateQueryExecution(Func<AfterUpdatePipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterUpdatePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.AfterUpdate.AddToEnd(action, predicate);
            return this;
        }
        #endregion

        #region delete
        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteQueryExecution(Action<BeforeDeletePipelineExecutionContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeDelete.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteQueryExecution(Action<BeforeDeletePipelineExecutionContext> action, Predicate<BeforeDeletePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeDelete.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteQueryExecution(Func<BeforeDeletePipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeDelete.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteQueryExecution(Func<BeforeDeletePipelineExecutionContext, Task> action, Predicate<BeforeDeletePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeDelete.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteQueryExecution(Func<BeforeDeletePipelineExecutionContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeDelete.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteQueryExecution(Func<BeforeDeletePipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeDeletePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeDelete.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteQueryExecution(Action<AfterDeletePipelineExecutionContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.AfterDelete.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteQueryExecution(Action<AfterDeletePipelineExecutionContext> action, Predicate<AfterDeletePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.AfterDelete.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteQueryExecution(Func<AfterDeletePipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.AfterDelete.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteQueryExecution(Func<AfterDeletePipelineExecutionContext, Task> action, Predicate<AfterDeletePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.AfterDelete.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteQueryExecution(Func<AfterDeletePipelineExecutionContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.AfterDelete.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteQueryExecution(Func<AfterDeletePipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterDeletePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.AfterDelete.AddToEnd(action, predicate);
            return this;
        }
        #endregion

        #region select
        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectQueryExecution(Action<BeforeSelectPipelineExecutionContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeSelect.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectQueryExecution(Action<BeforeSelectPipelineExecutionContext> action, Predicate<BeforeSelectPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeSelect.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectQueryExecution(Func<BeforeSelectPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeSelect.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectQueryExecution(Func<BeforeSelectPipelineExecutionContext, Task> action, Predicate<BeforeSelectPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeSelect.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectQueryExecution(Func<BeforeSelectPipelineExecutionContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeSelect.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectQueryExecution(Func<BeforeSelectPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeSelectPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeSelect.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectQueryExecution(Action<AfterSelectPipelineExecutionContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.AfterSelect.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectQueryExecution(Action<AfterSelectPipelineExecutionContext> action, Predicate<AfterSelectPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.AfterSelect.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectQueryExecution(Func<AfterSelectPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.AfterSelect.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectQueryExecution(Func<AfterSelectPipelineExecutionContext, Task> action, Predicate<AfterSelectPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.AfterSelect.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectQueryExecution(Func<AfterSelectPipelineExecutionContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.AfterSelect.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectQueryExecution(Func<AfterSelectPipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterSelectPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.AfterSelect.AddToEnd(action, predicate);
            return this;
        }
        #endregion

        #region stored procedure
        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureExecution(Action<BeforeStoredProcedurePipelineExecutionContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeStoredProcedure.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureExecution(Action<BeforeStoredProcedurePipelineExecutionContext> action, Predicate<BeforeStoredProcedurePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeStoredProcedure.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureExecution(Func<BeforeStoredProcedurePipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeStoredProcedure.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureExecution(Func<BeforeStoredProcedurePipelineExecutionContext, Task> action, Predicate<BeforeStoredProcedurePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeStoredProcedure.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureExecution(Func<BeforeStoredProcedurePipelineExecutionContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeStoredProcedure.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureExecution(Func<BeforeStoredProcedurePipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeStoredProcedurePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeStoredProcedure.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureExecution(Action<AfterStoredProcedurePipelineExecutionContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.AfterStoredProcedure.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureExecution(Action<AfterStoredProcedurePipelineExecutionContext> action, Predicate<AfterStoredProcedurePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.AfterStoredProcedure.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureExecution(Func<AfterStoredProcedurePipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.AfterStoredProcedure.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureExecution(Func<AfterStoredProcedurePipelineExecutionContext, Task> action, Predicate<AfterStoredProcedurePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.AfterStoredProcedure.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureExecution(Func<AfterStoredProcedurePipelineExecutionContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.AfterStoredProcedure.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureExecution(Func<AfterStoredProcedurePipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterStoredProcedurePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.AfterStoredProcedure.AddToEnd(action, predicate);
            return this;
        }
        #endregion

        #region execution
        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementExecution(Action<BeforeExecutionPipelineExecutionContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeExecution.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementExecution(Action<BeforeExecutionPipelineExecutionContext> action, Predicate<BeforeExecutionPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeExecution.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementExecution(Func<BeforeExecutionPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeExecution.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementExecution(Func<BeforeExecutionPipelineExecutionContext, Task> action, Predicate<BeforeExecutionPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeExecution.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementExecution(Func<BeforeExecutionPipelineExecutionContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.BeforeExecution.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementExecution(Func<BeforeExecutionPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeExecutionPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.BeforeExecution.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementExecution(Action<AfterExecutionPipelineExecutionContext> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.AfterExecution.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementExecution(Action<AfterExecutionPipelineExecutionContext> action, Predicate<AfterExecutionPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.AfterExecution.AddToEnd(action, predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementExecution(Func<AfterExecutionPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.AfterExecution.AddToEnd((c, ct) => action(c));
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementExecution(Func<AfterExecutionPipelineExecutionContext, Task> action, Predicate<AfterExecutionPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.AfterExecution.AddToEnd((c, ct) => action(c), predicate);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementExecution(Func<AfterExecutionPipelineExecutionContext, CancellationToken, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            events.AfterExecution.AddToEnd(action);
            return this;
        }

        /// <inheritdoc />
        public IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementExecution(Func<AfterExecutionPipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterExecutionPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            events.AfterExecution.AddToEnd(action, predicate);            
            return this;
        }
        #endregion
        #endregion
    }
}
