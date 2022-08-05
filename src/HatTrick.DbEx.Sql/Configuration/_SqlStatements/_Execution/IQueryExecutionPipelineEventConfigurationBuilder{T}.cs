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
    public interface IQueryExecutionPipelineEventConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region assembly
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementAssembly(Action<BeforeAssemblyPipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementAssembly(Action<BeforeAssemblyPipelineExecutionContext> action, Predicate<BeforeAssemblyPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementAssembly(Func<BeforeAssemblyPipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementAssembly(Func<BeforeAssemblyPipelineExecutionContext, Task> action, Predicate<BeforeAssemblyPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementAssembly(Func<BeforeAssemblyPipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementAssembly(Func<BeforeAssemblyPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeAssemblyPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementAssembly(Action<AfterAssemblyPipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementAssembly(Action<AfterAssemblyPipelineExecutionContext> action, Predicate<AfterAssemblyPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementAssembly(Func<AfterAssemblyPipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementAssembly(Func<AfterAssemblyPipelineExecutionContext, Task> action, Predicate<AfterAssemblyPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementAssembly(Func<AfterAssemblyPipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementAssembly(Func<AfterAssemblyPipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterAssemblyPipelineExecutionContext> predicate);

        #region update
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an UPDATE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateSqlStatementAssembly(Action<BeforeUpdateAssemblyPipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateSqlStatementAssembly(Action<BeforeUpdateAssemblyPipelineExecutionContext> action, Predicate<BeforeUpdateAssemblyPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an UPDATE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateSqlStatementAssembly(Func<BeforeUpdateAssemblyPipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateSqlStatementAssembly(Func<BeforeUpdateAssemblyPipelineExecutionContext, Task> action, Predicate<BeforeUpdateAssemblyPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an UPDATE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateSqlStatementAssembly(Func<BeforeUpdateAssemblyPipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateSqlStatementAssembly(Func<BeforeUpdateAssemblyPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeUpdateAssemblyPipelineExecutionContext> predicate);

        #endregion

        #region insert
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an UPDATE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertSqlStatementAssembly(Action<BeforeInsertAssemblyPipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertSqlStatementAssembly(Action<BeforeInsertAssemblyPipelineExecutionContext> action, Predicate<BeforeInsertAssemblyPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an UPDATE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertSqlStatementAssembly(Func<BeforeInsertAssemblyPipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertSqlStatementAssembly(Func<BeforeInsertAssemblyPipelineExecutionContext, Task> action, Predicate<BeforeInsertAssemblyPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an UPDATE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertSqlStatementAssembly(Func<BeforeInsertAssemblyPipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertSqlStatementAssembly(Func<BeforeInsertAssemblyPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeInsertAssemblyPipelineExecutionContext> predicate);

        #endregion
        #endregion

        #region insert
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an INSERT sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertQueryExecution(Action<BeforeInsertPipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an INSERT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertQueryExecution(Action<BeforeInsertPipelineExecutionContext> action, Predicate<BeforeInsertPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an INSERT sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertQueryExecution(Func<BeforeInsertPipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an INSERT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertQueryExecution(Func<BeforeInsertPipelineExecutionContext, Task> action, Predicate<BeforeInsertPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an INSERT sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertQueryExecution(Func<BeforeInsertPipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an INSERT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertQueryExecution(Func<BeforeInsertPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeInsertPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an INSERT sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertQueryExecution(Action<AfterInsertPipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an INSERT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertQueryExecution(Action<AfterInsertPipelineExecutionContext> action, Predicate<AfterInsertPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an INSERT sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertQueryExecution(Func<AfterInsertPipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an INSERT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertQueryExecution(Func<AfterInsertPipelineExecutionContext, Task> action, Predicate<AfterInsertPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an INSERT sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertQueryExecution(Func<AfterInsertPipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an INSERT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertQueryExecution(Func<AfterInsertPipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterInsertPipelineExecutionContext> predicate);
        #endregion

        #region update
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an UPDATE sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateQueryExecution(Action<BeforeUpdatePipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an UPDATE sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateQueryExecution(Action<BeforeUpdatePipelineExecutionContext> action, Predicate<BeforeUpdatePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an UPDATE sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateQueryExecution(Func<BeforeUpdatePipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an UPDATE sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateQueryExecution(Func<BeforeUpdatePipelineExecutionContext, Task> action, Predicate<BeforeUpdatePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an UPDATE sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateQueryExecution(Func<BeforeUpdatePipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an UPDATE sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateQueryExecution(Func<BeforeUpdatePipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeUpdatePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an UPDATE sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateQueryExecution(Action<AfterUpdatePipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an UPDATE sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateQueryExecution(Action<AfterUpdatePipelineExecutionContext> action, Predicate<AfterUpdatePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an UPDATE sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateQueryExecution(Func<AfterUpdatePipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an UPDATE sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateQueryExecution(Func<AfterUpdatePipelineExecutionContext, Task> action, Predicate<AfterUpdatePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an UPDATE sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateQueryExecution(Func<AfterUpdatePipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an UPDATE sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateQueryExecution(Func<AfterUpdatePipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterUpdatePipelineExecutionContext> predicate);
        #endregion

        #region delete
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an DELETE sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteQueryExecution(Action<BeforeDeletePipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an DELETE sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteQueryExecution(Action<BeforeDeletePipelineExecutionContext> action, Predicate<BeforeDeletePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an DELETE sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteQueryExecution(Func<BeforeDeletePipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an DELETE sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteQueryExecution(Func<BeforeDeletePipelineExecutionContext, Task> action, Predicate<BeforeDeletePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an DELETE sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteQueryExecution(Func<BeforeDeletePipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an DELETE sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteQueryExecution(Func<BeforeDeletePipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeDeletePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an DELETE sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteQueryExecution(Action<AfterDeletePipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an DELETE sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteQueryExecution(Action<AfterDeletePipelineExecutionContext> action, Predicate<AfterDeletePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an DELETE sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteQueryExecution(Func<AfterDeletePipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an DELETE sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteQueryExecution(Func<AfterDeletePipelineExecutionContext, Task> action, Predicate<AfterDeletePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an DELETE sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteQueryExecution(Func<AfterDeletePipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an DELETE sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteQueryExecution(Func<AfterDeletePipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterDeletePipelineExecutionContext> predicate);
        #endregion

        #region select
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an SELECT sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectQueryExecution(Action<BeforeSelectPipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an SELECT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectQueryExecution(Action<BeforeSelectPipelineExecutionContext> action, Predicate<BeforeSelectPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an SELECT sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectQueryExecution(Func<BeforeSelectPipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an SELECT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectQueryExecution(Func<BeforeSelectPipelineExecutionContext, Task> action, Predicate<BeforeSelectPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an SELECT sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectQueryExecution(Func<BeforeSelectPipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an SELECT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectQueryExecution(Func<BeforeSelectPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeSelectPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an SELECT sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectQueryExecution(Action<AfterSelectPipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an SELECT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectQueryExecution(Action<AfterSelectPipelineExecutionContext> action, Predicate<AfterSelectPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an SELECT sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectQueryExecution(Func<AfterSelectPipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an SELECT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectQueryExecution(Func<AfterSelectPipelineExecutionContext, Task> action, Predicate<AfterSelectPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an SELECT sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectQueryExecution(Func<AfterSelectPipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an SELECT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectQueryExecution(Func<AfterSelectPipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterSelectPipelineExecutionContext> predicate);
        #endregion

        #region stored procedure
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a stored procedure against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureExecution(Action<BeforeStoredProcedurePipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a stored procedure against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureExecution(Action<BeforeStoredProcedurePipelineExecutionContext> action, Predicate<BeforeStoredProcedurePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a stored procedure against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureExecution(Func<BeforeStoredProcedurePipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a stored procedure against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureExecution(Func<BeforeStoredProcedurePipelineExecutionContext, Task> action, Predicate<BeforeStoredProcedurePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a stored procedure against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureExecution(Func<BeforeStoredProcedurePipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a stored procedure against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureExecution(Func<BeforeStoredProcedurePipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeStoredProcedurePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a stored procedure against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureExecution(Action<AfterStoredProcedurePipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a stored procedure against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureExecution(Action<AfterStoredProcedurePipelineExecutionContext> action, Predicate<AfterStoredProcedurePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a stored procedure against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureExecution(Func<AfterStoredProcedurePipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a stored procedure against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureExecution(Func<AfterStoredProcedurePipelineExecutionContext, Task> action, Predicate<AfterStoredProcedurePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a stored procedure against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureExecution(Func<AfterStoredProcedurePipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a stored procedure against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureExecution(Func<AfterStoredProcedurePipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterStoredProcedurePipelineExecutionContext> predicate);
        #endregion

        #region execution
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing any sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementExecution(Action<BeforeExecutionPipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing any sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementExecution(Action<BeforeExecutionPipelineExecutionContext> action, Predicate<BeforeExecutionPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing any sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementExecution(Func<BeforeExecutionPipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing any sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementExecution(Func<BeforeExecutionPipelineExecutionContext, Task> action, Predicate<BeforeExecutionPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing any sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementExecution(Func<BeforeExecutionPipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing any sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSqlStatementExecution(Func<BeforeExecutionPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeExecutionPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing any sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementExecution(Action<AfterExecutionPipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing any sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementExecution(Action<AfterExecutionPipelineExecutionContext> action, Predicate<AfterExecutionPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing any sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementExecution(Func<AfterExecutionPipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing any sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementExecution(Func<AfterExecutionPipelineExecutionContext, Task> action, Predicate<AfterExecutionPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing any sql statement against the target database.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementExecution(Func<AfterExecutionPipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing any sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSqlStatementExecution(Func<AfterExecutionPipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterExecutionPipelineExecutionContext> predicate);
        #endregion
    }
}
