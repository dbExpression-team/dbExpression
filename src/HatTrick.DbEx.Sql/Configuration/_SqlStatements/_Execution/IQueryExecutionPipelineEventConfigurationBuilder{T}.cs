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
        #region common
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStart(Action<BeforeStartPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStart(Action<BeforeStartPipelineEventContext> action, Predicate<BeforeStartPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStart(Func<BeforeStartPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStart(Func<BeforeStartPipelineEventContext, Task> action, Predicate<BeforeStartPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStart(Func<BeforeStartPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStart(Func<BeforeStartPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeStartPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterAssembly(Action<AfterAssemblyPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterAssembly(Action<AfterAssemblyPipelineEventContext> action, Predicate<AfterAssemblyPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterAssembly(Func<AfterAssemblyPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterAssembly(Func<AfterAssemblyPipelineEventContext, Task> action, Predicate<AfterAssemblyPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterAssembly(Func<AfterAssemblyPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterAssembly(Func<AfterAssemblyPipelineEventContext, CancellationToken, Task> action, Predicate<AfterAssemblyPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeCommand(Action<BeforeCommandPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeCommand(Action<BeforeCommandPipelineEventContext> action, Predicate<BeforeCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeCommand(Func<BeforeCommandPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeCommand(Func<BeforeCommandPipelineEventContext, Task> action, Predicate<BeforeCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeCommand(Func<BeforeCommandPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeCommand(Func<BeforeCommandPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterCommand(Action<AfterCommandPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterCommand(Action<AfterCommandPipelineEventContext> action, Predicate<AfterCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterCommand(Func<AfterCommandPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterCommand(Func<AfterCommandPipelineEventContext, Task> action, Predicate<AfterCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterCommand(Func<AfterCommandPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterCommand(Func<AfterCommandPipelineEventContext, CancellationToken, Task> action, Predicate<AfterCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterComplete(Action<AfterCompletePipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterComplete(Action<AfterCompletePipelineEventContext> action, Predicate<AfterCompletePipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterComplete(Func<AfterCompletePipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterComplete(Func<AfterCompletePipelineEventContext, Task> action, Predicate<AfterCompletePipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterComplete(Func<AfterCompletePipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterComplete(Func<AfterCompletePipelineEventContext, CancellationToken, Task> action, Predicate<AfterCompletePipelineEventContext> predicate);
        #endregion

        #region select
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a SELECT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectStart(Action<BeforeSelectStartPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a SELECT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectStart(Action<BeforeSelectStartPipelineEventContext> action, Predicate<BeforeSelectStartPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a SELECT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectStart(Func<BeforeSelectStartPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a SELECT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectStart(Func<BeforeSelectStartPipelineEventContext, Task> action, Predicate<BeforeSelectStartPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a SELECT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectStart(Func<BeforeSelectStartPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a SELECT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectStart(Func<BeforeSelectStartPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeSelectStartPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a SELECT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectAssembly(Action<AfterSelectAssemblyPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a SELECT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectAssembly(Action<AfterSelectAssemblyPipelineEventContext> action, Predicate<AfterSelectAssemblyPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a SELECT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectAssembly(Func<AfterSelectAssemblyPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a SELECT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectAssembly(Func<AfterSelectAssemblyPipelineEventContext, Task> action, Predicate<AfterSelectAssemblyPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a SELECT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectAssembly(Func<AfterSelectAssemblyPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a SELECT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectAssembly(Func<AfterSelectAssemblyPipelineEventContext, CancellationToken, Task> action, Predicate<AfterSelectAssemblyPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a SELECT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectCommand(Action<BeforeSelectCommandPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a SELECT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectCommand(Action<BeforeSelectCommandPipelineEventContext> action, Predicate<BeforeSelectCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a SELECT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectCommand(Func<BeforeSelectCommandPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a SELECT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectCommand(Func<BeforeSelectCommandPipelineEventContext, Task> action, Predicate<BeforeSelectCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a SELECT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectCommand(Func<BeforeSelectCommandPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a SELECT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeSelectCommand(Func<BeforeSelectCommandPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeSelectCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a SELECT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectCommand(Action<AfterSelectCommandPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a SELECT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectCommand(Action<AfterSelectCommandPipelineEventContext> action, Predicate<AfterSelectCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a SELECT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectCommand(Func<AfterSelectCommandPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a SELECT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectCommand(Func<AfterSelectCommandPipelineEventContext, Task> action, Predicate<AfterSelectCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a SELECT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectCommand(Func<AfterSelectCommandPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a SELECT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectCommand(Func<AfterSelectCommandPipelineEventContext, CancellationToken, Task> action, Predicate<AfterSelectCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a SELECT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectComplete(Action<AfterSelectCompletePipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a SELECT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectComplete(Action<AfterSelectCompletePipelineEventContext> action, Predicate<AfterSelectCompletePipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a SELECT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectComplete(Func<AfterSelectCompletePipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a SELECT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectComplete(Func<AfterSelectCompletePipelineEventContext, Task> action, Predicate<AfterSelectCompletePipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a SELECT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectComplete(Func<AfterSelectCompletePipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a SELECT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterSelectComplete(Func<AfterSelectCompletePipelineEventContext, CancellationToken, Task> action, Predicate<AfterSelectCompletePipelineEventContext> predicate);
        #endregion

        #region insert
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an INSERT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertStart(Action<BeforeInsertStartPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an INSERT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertStart(Action<BeforeInsertStartPipelineEventContext> action, Predicate<BeforeInsertStartPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an INSERT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertStart(Func<BeforeInsertStartPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an INSERT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertStart(Func<BeforeInsertStartPipelineEventContext, Task> action, Predicate<BeforeInsertStartPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an INSERT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertStart(Func<BeforeInsertStartPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for an INSERT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertStart(Func<BeforeInsertStartPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeInsertStartPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for an INSERT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertAssembly(Action<AfterInsertAssemblyPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for an INSERT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertAssembly(Action<AfterInsertAssemblyPipelineEventContext> action, Predicate<AfterInsertAssemblyPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for an INSERT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertAssembly(Func<AfterInsertAssemblyPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for an INSERT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertAssembly(Func<AfterInsertAssemblyPipelineEventContext, Task> action, Predicate<AfterInsertAssemblyPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for an INSERT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertAssembly(Func<AfterInsertAssemblyPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for an INSERT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertAssembly(Func<AfterInsertAssemblyPipelineEventContext, CancellationToken, Task> action, Predicate<AfterInsertAssemblyPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for an INSERT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertCommand(Action<BeforeInsertCommandPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for an INSERT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertCommand(Action<BeforeInsertCommandPipelineEventContext> action, Predicate<BeforeInsertCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for an INSERT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertCommand(Func<BeforeInsertCommandPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for an INSERT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertCommand(Func<BeforeInsertCommandPipelineEventContext, Task> action, Predicate<BeforeInsertCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for an INSERT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertCommand(Func<BeforeInsertCommandPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for an INSERT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeInsertCommand(Func<BeforeInsertCommandPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeInsertCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for an INSERT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertCommand(Action<AfterInsertCommandPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for an INSERT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertCommand(Action<AfterInsertCommandPipelineEventContext> action, Predicate<AfterInsertCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for an INSERT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertCommand(Func<AfterInsertCommandPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for an INSERT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertCommand(Func<AfterInsertCommandPipelineEventContext, Task> action, Predicate<AfterInsertCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for an INSERT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertCommand(Func<AfterInsertCommandPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for an INSERT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertCommand(Func<AfterInsertCommandPipelineEventContext, CancellationToken, Task> action, Predicate<AfterInsertCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for an INSERT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertComplete(Action<AfterInsertCompletePipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for an INSERT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertComplete(Action<AfterInsertCompletePipelineEventContext> action, Predicate<AfterInsertCompletePipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for an INSERT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertComplete(Func<AfterInsertCompletePipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for an INSERT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertComplete(Func<AfterInsertCompletePipelineEventContext, Task> action, Predicate<AfterInsertCompletePipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for an INSERT operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertComplete(Func<AfterInsertCompletePipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for an INSERT operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterInsertComplete(Func<AfterInsertCompletePipelineEventContext, CancellationToken, Task> action, Predicate<AfterInsertCompletePipelineEventContext> predicate);
        #endregion

        #region update
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a UPDATE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateStart(Action<BeforeUpdateStartPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateStart(Action<BeforeUpdateStartPipelineEventContext> action, Predicate<BeforeUpdateStartPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a UPDATE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateStart(Func<BeforeUpdateStartPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateStart(Func<BeforeUpdateStartPipelineEventContext, Task> action, Predicate<BeforeUpdateStartPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a UPDATE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateStart(Func<BeforeUpdateStartPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateStart(Func<BeforeUpdateStartPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeUpdateStartPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateAssembly(Action<AfterUpdateAssemblyPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateAssembly(Action<AfterUpdateAssemblyPipelineEventContext> action, Predicate<AfterUpdateAssemblyPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateAssembly(Func<AfterUpdateAssemblyPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateAssembly(Func<AfterUpdateAssemblyPipelineEventContext, Task> action, Predicate<AfterUpdateAssemblyPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateAssembly(Func<AfterUpdateAssemblyPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateAssembly(Func<AfterUpdateAssemblyPipelineEventContext, CancellationToken, Task> action, Predicate<AfterUpdateAssemblyPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a UPDATE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateCommand(Action<BeforeUpdateCommandPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateCommand(Action<BeforeUpdateCommandPipelineEventContext> action, Predicate<BeforeUpdateCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a UPDATE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateCommand(Func<BeforeUpdateCommandPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateCommand(Func<BeforeUpdateCommandPipelineEventContext, Task> action, Predicate<BeforeUpdateCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a UPDATE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateCommand(Func<BeforeUpdateCommandPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeUpdateCommand(Func<BeforeUpdateCommandPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeUpdateCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a UPDATE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateCommand(Action<AfterUpdateCommandPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateCommand(Action<AfterUpdateCommandPipelineEventContext> action, Predicate<AfterUpdateCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a UPDATE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateCommand(Func<AfterUpdateCommandPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateCommand(Func<AfterUpdateCommandPipelineEventContext, Task> action, Predicate<AfterUpdateCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a UPDATE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateCommand(Func<AfterUpdateCommandPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateCommand(Func<AfterUpdateCommandPipelineEventContext, CancellationToken, Task> action, Predicate<AfterUpdateCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a UPDATE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateComplete(Action<AfterUpdateCompletePipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateComplete(Action<AfterUpdateCompletePipelineEventContext> action, Predicate<AfterUpdateCompletePipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a UPDATE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateComplete(Func<AfterUpdateCompletePipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateComplete(Func<AfterUpdateCompletePipelineEventContext, Task> action, Predicate<AfterUpdateCompletePipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a UPDATE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateComplete(Func<AfterUpdateCompletePipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterUpdateComplete(Func<AfterUpdateCompletePipelineEventContext, CancellationToken, Task> action, Predicate<AfterUpdateCompletePipelineEventContext> predicate);
        #endregion

        #region delete
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteStart(Action<BeforeDeleteStartPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteStart(Action<BeforeDeleteStartPipelineEventContext> action, Predicate<BeforeDeleteStartPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteStart(Func<BeforeDeleteStartPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteStart(Func<BeforeDeleteStartPipelineEventContext, Task> action, Predicate<BeforeDeleteStartPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteStart(Func<BeforeDeleteStartPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteStart(Func<BeforeDeleteStartPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeDeleteStartPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteAssembly(Action<AfterDeleteAssemblyPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteAssembly(Action<AfterDeleteAssemblyPipelineEventContext> action, Predicate<AfterDeleteAssemblyPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteAssembly(Func<AfterDeleteAssemblyPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteAssembly(Func<AfterDeleteAssemblyPipelineEventContext, Task> action, Predicate<AfterDeleteAssemblyPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteAssembly(Func<AfterDeleteAssemblyPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteAssembly(Func<AfterDeleteAssemblyPipelineEventContext, CancellationToken, Task> action, Predicate<AfterDeleteAssemblyPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a DELETE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteCommand(Action<BeforeDeleteCommandPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a DELETE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteCommand(Action<BeforeDeleteCommandPipelineEventContext> action, Predicate<BeforeDeleteCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a DELETE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteCommand(Func<BeforeDeleteCommandPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a DELETE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteCommand(Func<BeforeDeleteCommandPipelineEventContext, Task> action, Predicate<BeforeDeleteCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a DELETE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteCommand(Func<BeforeDeleteCommandPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a DELETE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeDeleteCommand(Func<BeforeDeleteCommandPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeDeleteCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a DELETE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteCommand(Action<AfterDeleteCommandPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a DELETE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteCommand(Action<AfterDeleteCommandPipelineEventContext> action, Predicate<AfterDeleteCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a DELETE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteCommand(Func<AfterDeleteCommandPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a DELETE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteCommand(Func<AfterDeleteCommandPipelineEventContext, Task> action, Predicate<AfterDeleteCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a DELETE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteCommand(Func<AfterDeleteCommandPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a DELETE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteCommand(Func<AfterDeleteCommandPipelineEventContext, CancellationToken, Task> action, Predicate<AfterDeleteCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a DELETE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteComplete(Action<AfterDeleteCompletePipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a DELETE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteComplete(Action<AfterDeleteCompletePipelineEventContext> action, Predicate<AfterDeleteCompletePipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a DELETE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteComplete(Func<AfterDeleteCompletePipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a DELETE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteComplete(Func<AfterDeleteCompletePipelineEventContext, Task> action, Predicate<AfterDeleteCompletePipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a DELETE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteComplete(Func<AfterDeleteCompletePipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a DELETE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterDeleteComplete(Func<AfterDeleteCompletePipelineEventContext, CancellationToken, Task> action, Predicate<AfterDeleteCompletePipelineEventContext> predicate);
        #endregion

        #region stored procedure
        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a stored procedure.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureStart(Action<BeforeStoredProcedureStartPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a stored procedure.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureStart(Action<BeforeStoredProcedureStartPipelineEventContext> action, Predicate<BeforeStoredProcedureStartPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a stored procedure.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureStart(Func<BeforeStoredProcedureStartPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a stored procedure.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureStart(Func<BeforeStoredProcedureStartPipelineEventContext, Task> action, Predicate<BeforeStoredProcedureStartPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a stored procedure.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureStart(Func<BeforeStoredProcedureStartPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to assembling a sql statement from a query expression for a stored procedure.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureStart(Func<BeforeStoredProcedureStartPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeStoredProcedureStartPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureAssembly(Action<AfterStoredProcedureAssemblyPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureAssembly(Action<AfterStoredProcedureAssemblyPipelineEventContext> action, Predicate<AfterStoredProcedureAssemblyPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureAssembly(Func<AfterStoredProcedureAssemblyPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureAssembly(Func<AfterStoredProcedureAssemblyPipelineEventContext, Task> action, Predicate<AfterStoredProcedureAssemblyPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a DELETE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureAssembly(Func<AfterStoredProcedureAssemblyPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after assembling a sql statement from a query expression for a stored procedure.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureAssembly(Func<AfterStoredProcedureAssemblyPipelineEventContext, CancellationToken, Task> action, Predicate<AfterStoredProcedureAssemblyPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a stored procedure.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureCommand(Action<BeforeStoredProcedureCommandPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a stored procedure.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureCommand(Action<BeforeStoredProcedureCommandPipelineEventContext> action, Predicate<BeforeStoredProcedureCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a stored procedure.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureCommand(Func<BeforeStoredProcedureCommandPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a stored procedure.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureCommand(Func<BeforeStoredProcedureCommandPipelineEventContext, Task> action, Predicate<BeforeStoredProcedureCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a stored procedure.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureCommand(Func<BeforeStoredProcedureCommandPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> prior to executing a sql statement for a stored procedure.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnBeforeStoredProcedureCommand(Func<BeforeStoredProcedureCommandPipelineEventContext, CancellationToken, Task> action, Predicate<BeforeStoredProcedureCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a stored procedure.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureCommand(Action<AfterStoredProcedureCommandPipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a stored procedure.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureCommand(Action<AfterStoredProcedureCommandPipelineEventContext> action, Predicate<AfterStoredProcedureCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a stored procedure.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureCommand(Func<AfterStoredProcedureCommandPipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a stored procedure.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureCommand(Func<AfterStoredProcedureCommandPipelineEventContext, Task> action, Predicate<AfterStoredProcedureCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a stored procedure.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureCommand(Func<AfterStoredProcedureCommandPipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after executing a sql statement for a stored procedure.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureCommand(Func<AfterStoredProcedureCommandPipelineEventContext, CancellationToken, Task> action, Predicate<AfterStoredProcedureCommandPipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a UPDATE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureComplete(Action<AfterStoredProcedureCompletePipelineEventContext> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureComplete(Action<AfterStoredProcedureCompletePipelineEventContext> action, Predicate<AfterStoredProcedureCompletePipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a UPDATE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureComplete(Func<AfterStoredProcedureCompletePipelineEventContext, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a stored procedure.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureComplete(Func<AfterStoredProcedureCompletePipelineEventContext, Task> action, Predicate<AfterStoredProcedureCompletePipelineEventContext> predicate);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a UPDATE operation.
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureComplete(Func<AfterStoredProcedureCompletePipelineEventContext, CancellationToken, Task> action);

        /// <summary>
        /// Execute the delegate <paramref name="action"/> after all activities for a UPDATE operation.
        /// </summary>
        /// <param name="predicate">A predicate used to determine if the <paramref name="action"/> is executed.</param>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> OnAfterStoredProcedureComplete(Func<AfterStoredProcedureCompletePipelineEventContext, CancellationToken, Task> action, Predicate<AfterStoredProcedureCompletePipelineEventContext> predicate);
        #endregion
    }
}
