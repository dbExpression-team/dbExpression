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
    public interface IExecutionPipelineEventConfigurationBuilder
    {
        #region assembly
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementAssembly(Action<BeforeAssemblyPipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementAssembly(Action<BeforeAssemblyPipelineExecutionContext> action, Predicate<BeforeAssemblyPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementAssembly(Func<BeforeAssemblyPipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementAssembly(Func<BeforeAssemblyPipelineExecutionContext, Task> action, Predicate<BeforeAssemblyPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementAssembly(Func<BeforeAssemblyPipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementAssembly(Func<BeforeAssemblyPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeAssemblyPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementAssembly(Action<AfterAssemblyPipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementAssembly(Action<AfterAssemblyPipelineExecutionContext> action, Predicate<AfterAssemblyPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementAssembly(Func<AfterAssemblyPipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementAssembly(Func<AfterAssemblyPipelineExecutionContext, Task> action, Predicate<AfterAssemblyPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementAssembly(Func<AfterAssemblyPipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementAssembly(Func<AfterAssemblyPipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterAssemblyPipelineExecutionContext> predicate);

        #region update
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an UPDATE operation.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeUpdateSqlStatementAssembly(Action<BeforeUpdateAssemblyPipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeUpdateSqlStatementAssembly(Action<BeforeUpdateAssemblyPipelineExecutionContext> action, Predicate<BeforeUpdateAssemblyPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an UPDATE operation.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeUpdateSqlStatementAssembly(Func<BeforeUpdateAssemblyPipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeUpdateSqlStatementAssembly(Func<BeforeUpdateAssemblyPipelineExecutionContext, Task> action, Predicate<BeforeUpdateAssemblyPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an UPDATE operation.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeUpdateSqlStatementAssembly(Func<BeforeUpdateAssemblyPipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeUpdateSqlStatementAssembly(Func<BeforeUpdateAssemblyPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeUpdateAssemblyPipelineExecutionContext> predicate);

        #endregion
        #endregion

        #region insert
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an INSERT sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeInsertQueryExecution(Action<BeforeInsertPipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an INSERT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeInsertQueryExecution(Action<BeforeInsertPipelineExecutionContext> action, Predicate<BeforeInsertPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an INSERT sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeInsertQueryExecution(Func<BeforeInsertPipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an INSERT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeInsertQueryExecution(Func<BeforeInsertPipelineExecutionContext, Task> action, Predicate<BeforeInsertPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an INSERT sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeInsertQueryExecution(Func<BeforeInsertPipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an INSERT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeInsertQueryExecution(Func<BeforeInsertPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeInsertPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an INSERT sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnAfterInsertQueryExecution(Action<AfterInsertPipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an INSERT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnAfterInsertQueryExecution(Action<AfterInsertPipelineExecutionContext> action, Predicate<AfterInsertPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an INSERT sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnAfterInsertQueryExecution(Func<AfterInsertPipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an INSERT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnAfterInsertQueryExecution(Func<AfterInsertPipelineExecutionContext, Task> action, Predicate<AfterInsertPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an INSERT sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnAfterInsertQueryExecution(Func<AfterInsertPipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an INSERT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnAfterInsertQueryExecution(Func<AfterInsertPipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterInsertPipelineExecutionContext> predicate);
        #endregion

        #region update
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an UPDATE sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeUpdateQueryExecution(Action<BeforeUpdatePipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an UPDATE sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeUpdateQueryExecution(Action<BeforeUpdatePipelineExecutionContext> action, Predicate<BeforeUpdatePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an UPDATE sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeUpdateQueryExecution(Func<BeforeUpdatePipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an UPDATE sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeUpdateQueryExecution(Func<BeforeUpdatePipelineExecutionContext, Task> action, Predicate<BeforeUpdatePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an UPDATE sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeUpdateQueryExecution(Func<BeforeUpdatePipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an UPDATE sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeUpdateQueryExecution(Func<BeforeUpdatePipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeUpdatePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an UPDATE sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnAfterUpdateQueryExecution(Action<AfterUpdatePipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an UPDATE sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnAfterUpdateQueryExecution(Action<AfterUpdatePipelineExecutionContext> action, Predicate<AfterUpdatePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an UPDATE sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnAfterUpdateQueryExecution(Func<AfterUpdatePipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an UPDATE sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnAfterUpdateQueryExecution(Func<AfterUpdatePipelineExecutionContext, Task> action, Predicate<AfterUpdatePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an UPDATE sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnAfterUpdateQueryExecution(Func<AfterUpdatePipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an UPDATE sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnAfterUpdateQueryExecution(Func<AfterUpdatePipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterUpdatePipelineExecutionContext> predicate);
        #endregion

        #region delete
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an DELETE sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeDeleteQueryExecution(Action<BeforeDeletePipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an DELETE sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeDeleteQueryExecution(Action<BeforeDeletePipelineExecutionContext> action, Predicate<BeforeDeletePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an DELETE sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeDeleteQueryExecution(Func<BeforeDeletePipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an DELETE sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeDeleteQueryExecution(Func<BeforeDeletePipelineExecutionContext, Task> action, Predicate<BeforeDeletePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an DELETE sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeDeleteQueryExecution(Func<BeforeDeletePipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an DELETE sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeDeleteQueryExecution(Func<BeforeDeletePipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeDeletePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an DELETE sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnAfterDeleteQueryExecution(Action<AfterDeletePipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an DELETE sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnAfterDeleteQueryExecution(Action<AfterDeletePipelineExecutionContext> action, Predicate<AfterDeletePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an DELETE sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnAfterDeleteQueryExecution(Func<AfterDeletePipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an DELETE sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnAfterDeleteQueryExecution(Func<AfterDeletePipelineExecutionContext, Task> action, Predicate<AfterDeletePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an DELETE sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnAfterDeleteQueryExecution(Func<AfterDeletePipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an DELETE sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnAfterDeleteQueryExecution(Func<AfterDeletePipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterDeletePipelineExecutionContext> predicate);
        #endregion

        #region select
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an SELECT sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeSelectQueryExecution(Action<BeforeSelectPipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an SELECT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeSelectQueryExecution(Action<BeforeSelectPipelineExecutionContext> action, Predicate<BeforeSelectPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an SELECT sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeSelectQueryExecution(Func<BeforeSelectPipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an SELECT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeSelectQueryExecution(Func<BeforeSelectPipelineExecutionContext, Task> action, Predicate<BeforeSelectPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an SELECT sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeSelectQueryExecution(Func<BeforeSelectPipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing an SELECT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeSelectQueryExecution(Func<BeforeSelectPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeSelectPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an SELECT sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnAfterSelectQueryExecution(Action<AfterSelectPipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an SELECT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnAfterSelectQueryExecution(Action<AfterSelectPipelineExecutionContext> action, Predicate<AfterSelectPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an SELECT sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnAfterSelectQueryExecution(Func<AfterSelectPipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an SELECT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnAfterSelectQueryExecution(Func<AfterSelectPipelineExecutionContext, Task> action, Predicate<AfterSelectPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an SELECT sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnAfterSelectQueryExecution(Func<AfterSelectPipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing an SELECT sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnAfterSelectQueryExecution(Func<AfterSelectPipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterSelectPipelineExecutionContext> predicate);
        #endregion

        #region stored procedure
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a stored procedure against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeStoredProcedureExecution(Action<BeforeStoredProcedurePipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a stored procedure against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeStoredProcedureExecution(Action<BeforeStoredProcedurePipelineExecutionContext> action, Predicate<BeforeStoredProcedurePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a stored procedure against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeStoredProcedureExecution(Func<BeforeStoredProcedurePipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a stored procedure against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeStoredProcedureExecution(Func<BeforeStoredProcedurePipelineExecutionContext, Task> action, Predicate<BeforeStoredProcedurePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a stored procedure against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeStoredProcedureExecution(Func<BeforeStoredProcedurePipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a stored procedure against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeStoredProcedureExecution(Func<BeforeStoredProcedurePipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeStoredProcedurePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a stored procedure against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnAfterStoredProcedureExecution(Action<AfterStoredProcedurePipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a stored procedure against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnAfterStoredProcedureExecution(Action<AfterStoredProcedurePipelineExecutionContext> action, Predicate<AfterStoredProcedurePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a stored procedure against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnAfterStoredProcedureExecution(Func<AfterStoredProcedurePipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a stored procedure against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnAfterStoredProcedureExecution(Func<AfterStoredProcedurePipelineExecutionContext, Task> action, Predicate<AfterStoredProcedurePipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a stored procedure against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnAfterStoredProcedureExecution(Func<AfterStoredProcedurePipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a stored procedure against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnAfterStoredProcedureExecution(Func<AfterStoredProcedurePipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterStoredProcedurePipelineExecutionContext> predicate);
        #endregion

        #region execution
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing any sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementExecution(Action<BeforeExecutionPipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing any sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementExecution(Action<BeforeExecutionPipelineExecutionContext> action, Predicate<BeforeExecutionPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing any sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementExecution(Func<BeforeExecutionPipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing any sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementExecution(Func<BeforeExecutionPipelineExecutionContext, Task> action, Predicate<BeforeExecutionPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing any sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementExecution(Func<BeforeExecutionPipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing any sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnBeforeSqlStatementExecution(Func<BeforeExecutionPipelineExecutionContext, CancellationToken, Task> action, Predicate<BeforeExecutionPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing any sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementExecution(Action<AfterExecutionPipelineExecutionContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing any sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementExecution(Action<AfterExecutionPipelineExecutionContext> action, Predicate<AfterExecutionPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing any sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementExecution(Func<AfterExecutionPipelineExecutionContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing any sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementExecution(Func<AfterExecutionPipelineExecutionContext, Task> action, Predicate<AfterExecutionPipelineExecutionContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing any sql statement against the target database.
        /// </summary>
        IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementExecution(Func<AfterExecutionPipelineExecutionContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing any sql statement against the target database.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IExecutionPipelineEventConfigurationBuilder OnAfterSqlStatementExecution(Func<AfterExecutionPipelineExecutionContext, CancellationToken, Task> action, Predicate<AfterExecutionPipelineExecutionContext> predicate);
        #endregion
    }
}
