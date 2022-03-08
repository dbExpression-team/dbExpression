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

﻿using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class QueryExecutionPipelineEventConfigurationBuilder : IQueryExecutionPipelineEventConfigurationBuilder
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        #endregion

        #region constructors
        public QueryExecutionPipelineEventConfigurationBuilder(RuntimeSqlDatabaseConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        #endregion

        #region methods
        #region assembly
        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementAssembly(Action<BeforeAssemblyPipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.BeforeAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementAssembly(Action<BeforeAssemblyPipelineExecutionContext> action, Predicate<BeforeAssemblyPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementAssembly(Func<BeforeAssemblyPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeAssembly.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementAssembly(Func<BeforeAssemblyPipelineExecutionContext, Task> action, Predicate<BeforeAssemblyPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeAssembly.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementAssembly(Func<BeforeAssemblyPipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.BeforeAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementAssembly(Func<BeforeAssemblyPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeAssemblyPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementAssembly(Action<AfterAssemblyPipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.AfterAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementAssembly(Action<AfterAssemblyPipelineExecutionContext> action, Predicate<AfterAssemblyPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementAssembly(Func<AfterAssemblyPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterAssembly.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementAssembly(Func<AfterAssemblyPipelineExecutionContext, Task> action, Predicate<AfterAssemblyPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterAssembly.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementAssembly(Func<AfterAssemblyPipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.AfterAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementAssembly(Func<AfterAssemblyPipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterAssemblyPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        #region update
        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeUpdateSqlStatementAssembly(Action<BeforeUpdateAssemblyPipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.BeforeUpdateAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeUpdateSqlStatementAssembly(Action<BeforeUpdateAssemblyPipelineExecutionContext> action, Predicate<BeforeUpdateAssemblyPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeUpdateAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeUpdateSqlStatementAssembly(Func<BeforeUpdateAssemblyPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeUpdateAssembly.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeUpdateSqlStatementAssembly(Func<BeforeUpdateAssemblyPipelineExecutionContext, Task> action, Predicate<BeforeUpdateAssemblyPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeUpdateAssembly.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeUpdateSqlStatementAssembly(Func<BeforeUpdateAssemblyPipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.BeforeUpdateAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeUpdateSqlStatementAssembly(Func<BeforeUpdateAssemblyPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeUpdateAssemblyPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeUpdateAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }
        #endregion

        #region insert
        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeInsertSqlStatementAssembly(Action<BeforeInsertAssemblyPipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.BeforeInsertAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeInsertSqlStatementAssembly(Action<BeforeInsertAssemblyPipelineExecutionContext> action, Predicate<BeforeInsertAssemblyPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeInsertAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeInsertSqlStatementAssembly(Func<BeforeInsertAssemblyPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeInsertAssembly.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeInsertSqlStatementAssembly(Func<BeforeInsertAssemblyPipelineExecutionContext, Task> action, Predicate<BeforeInsertAssemblyPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeInsertAssembly.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeInsertSqlStatementAssembly(Func<BeforeInsertAssemblyPipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.BeforeInsertAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeInsertSqlStatementAssembly(Func<BeforeInsertAssemblyPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeInsertAssemblyPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeInsertAssembly.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }
        #endregion
        #endregion

        #region insert
        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeInsertQueryExecution(Action<BeforeInsertPipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.BeforeInsert.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeInsertQueryExecution(Action<BeforeInsertPipelineExecutionContext> action, Predicate<BeforeInsertPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeInsert.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeInsertQueryExecution(Func<BeforeInsertPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeInsert.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeInsertQueryExecution(Func<BeforeInsertPipelineExecutionContext, Task> action, Predicate<BeforeInsertPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeInsert.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeInsertQueryExecution(Func<BeforeInsertPipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.BeforeInsert.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeInsertQueryExecution(Func<BeforeInsertPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeInsertPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeInsert.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterInsertQueryExecution(Action<AfterInsertPipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.AfterInsert.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterInsertQueryExecution(Action<AfterInsertPipelineExecutionContext> action, Predicate<AfterInsertPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterInsert.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterInsertQueryExecution(Func<AfterInsertPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterInsert.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterInsertQueryExecution(Func<AfterInsertPipelineExecutionContext, Task> action, Predicate<AfterInsertPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterInsert.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterInsertQueryExecution(Func<AfterInsertPipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.AfterInsert.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterInsertQueryExecution(Func<AfterInsertPipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterInsertPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterInsert.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }
        #endregion

        #region update
        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeUpdateQueryExecution(Action<BeforeUpdatePipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.BeforeUpdate.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeUpdateQueryExecution(Action<BeforeUpdatePipelineExecutionContext> action, Predicate<BeforeUpdatePipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeUpdate.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeUpdateQueryExecution(Func<BeforeUpdatePipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeUpdate.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeUpdateQueryExecution(Func<BeforeUpdatePipelineExecutionContext, Task> action, Predicate<BeforeUpdatePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeUpdate.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeUpdateQueryExecution(Func<BeforeUpdatePipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.BeforeUpdate.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeUpdateQueryExecution(Func<BeforeUpdatePipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeUpdatePipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeUpdate.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterUpdateQueryExecution(Action<AfterUpdatePipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.AfterUpdate.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterUpdateQueryExecution(Action<AfterUpdatePipelineExecutionContext> action, Predicate<AfterUpdatePipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterUpdate.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterUpdateQueryExecution(Func<AfterUpdatePipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterUpdate.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterUpdateQueryExecution(Func<AfterUpdatePipelineExecutionContext, Task> action, Predicate<AfterUpdatePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterUpdate.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterUpdateQueryExecution(Func<AfterUpdatePipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.AfterUpdate.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterUpdateQueryExecution(Func<AfterUpdatePipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterUpdatePipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterUpdate.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }
        #endregion

        #region delete
        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeDeleteQueryExecution(Action<BeforeDeletePipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.BeforeDelete.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeDeleteQueryExecution(Action<BeforeDeletePipelineExecutionContext> action, Predicate<BeforeDeletePipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeDelete.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeDeleteQueryExecution(Func<BeforeDeletePipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeDelete.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeDeleteQueryExecution(Func<BeforeDeletePipelineExecutionContext, Task> action, Predicate<BeforeDeletePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeDelete.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeDeleteQueryExecution(Func<BeforeDeletePipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.BeforeDelete.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeDeleteQueryExecution(Func<BeforeDeletePipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeDeletePipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeDelete.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterDeleteQueryExecution(Action<AfterDeletePipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.AfterDelete.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterDeleteQueryExecution(Action<AfterDeletePipelineExecutionContext> action, Predicate<AfterDeletePipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterDelete.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterDeleteQueryExecution(Func<AfterDeletePipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterDelete.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterDeleteQueryExecution(Func<AfterDeletePipelineExecutionContext, Task> action, Predicate<AfterDeletePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterDelete.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterDeleteQueryExecution(Func<AfterDeletePipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.AfterDelete.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterDeleteQueryExecution(Func<AfterDeletePipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterDeletePipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterDelete.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }
        #endregion

        #region select
        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeSelectQueryExecution(Action<BeforeSelectPipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.BeforeSelect.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeSelectQueryExecution(Action<BeforeSelectPipelineExecutionContext> action, Predicate<BeforeSelectPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeSelect.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeSelectQueryExecution(Func<BeforeSelectPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeSelect.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeSelectQueryExecution(Func<BeforeSelectPipelineExecutionContext, Task> action, Predicate<BeforeSelectPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeSelect.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeSelectQueryExecution(Func<BeforeSelectPipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.BeforeSelect.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeSelectQueryExecution(Func<BeforeSelectPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeSelectPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeSelect.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterSelectQueryExecution(Action<AfterSelectPipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.AfterSelect.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterSelectQueryExecution(Action<AfterSelectPipelineExecutionContext> action, Predicate<AfterSelectPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterSelect.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterSelectQueryExecution(Func<AfterSelectPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterSelect.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterSelectQueryExecution(Func<AfterSelectPipelineExecutionContext, Task> action, Predicate<AfterSelectPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterSelect.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterSelectQueryExecution(Func<AfterSelectPipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.AfterSelect.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterSelectQueryExecution(Func<AfterSelectPipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterSelectPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterSelect.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }
        #endregion

        #region stored procedure
        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeStoredProcedureExecution(Action<BeforeStoredProcedurePipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.BeforeStoredProcedure.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeStoredProcedureExecution(Action<BeforeStoredProcedurePipelineExecutionContext> action, Predicate<BeforeStoredProcedurePipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeStoredProcedure.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeStoredProcedureExecution(Func<BeforeStoredProcedurePipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeStoredProcedure.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeStoredProcedureExecution(Func<BeforeStoredProcedurePipelineExecutionContext, Task> action, Predicate<BeforeStoredProcedurePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeStoredProcedure.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeStoredProcedureExecution(Func<BeforeStoredProcedurePipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.BeforeStoredProcedure.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeStoredProcedureExecution(Func<BeforeStoredProcedurePipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeStoredProcedurePipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeStoredProcedure.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterStoredProcedureExecution(Action<AfterStoredProcedurePipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.AfterStoredProcedure.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterStoredProcedureExecution(Action<AfterStoredProcedurePipelineExecutionContext> action, Predicate<AfterStoredProcedurePipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterStoredProcedure.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterStoredProcedureExecution(Func<AfterStoredProcedurePipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterStoredProcedure.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterStoredProcedureExecution(Func<AfterStoredProcedurePipelineExecutionContext, Task> action, Predicate<AfterStoredProcedurePipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterStoredProcedure.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterStoredProcedureExecution(Func<AfterStoredProcedurePipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.AfterStoredProcedure.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterStoredProcedureExecution(Func<AfterStoredProcedurePipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterStoredProcedurePipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterStoredProcedure.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }
        #endregion

        #region execution
        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementExecution(Action<BeforeExecutionPipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.BeforeExecution.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementExecution(Action<BeforeExecutionPipelineExecutionContext> action, Predicate<BeforeExecutionPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeExecution.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementExecution(Func<BeforeExecutionPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeExecution.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementExecution(Func<BeforeExecutionPipelineExecutionContext, Task> action, Predicate<BeforeExecutionPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.BeforeExecution.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementExecution(Func<BeforeExecutionPipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.BeforeExecution.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementExecution(Func<BeforeExecutionPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeExecutionPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.BeforeExecution.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementExecution(Action<AfterExecutionPipelineExecutionContext> action)
        {
            configuration.ExecutionPipelineFactory.AfterExecution.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementExecution(Action<AfterExecutionPipelineExecutionContext> action, Predicate<AfterExecutionPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterExecution.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementExecution(Func<AfterExecutionPipelineExecutionContext, Task> action)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterExecution.AddToEnd((c, ct) => action(c));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementExecution(Func<AfterExecutionPipelineExecutionContext, Task> action, Predicate<AfterExecutionPipelineExecutionContext> predicate)
        {
            if (action is null)
                throw new ArgumentNullException(nameof(action));
            configuration.ExecutionPipelineFactory.AfterExecution.AddToEnd((c, ct) => action(c), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementExecution(Func<AfterExecutionPipelineExecutionContext, CancellationToken, Task> action)
        {
            configuration.ExecutionPipelineFactory.AfterExecution.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)));
            return this;
        }

        public IQueryExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementExecution(Func<AfterExecutionPipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterExecutionPipelineExecutionContext> predicate)
        {
            configuration.ExecutionPipelineFactory.AfterExecution.AddToEnd(action ?? throw new ArgumentNullException(nameof(action)), predicate ?? throw new ArgumentNullException(nameof(predicate)));
            return this;
        }
        #endregion
        #endregion
    }
}
