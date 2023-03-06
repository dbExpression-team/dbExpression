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

using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public sealed class DeleteQueryExpressionExecutionPipeline : IDeleteQueryExpressionExecutionPipeline
    {
        #region internals
        private readonly ILogger<DeleteQueryExpressionExecutionPipeline> logger;
        private readonly IDbConnectionFactory connectionFactory;
        private readonly ISqlStatementExecutor statementExecutor;
        private readonly ISqlStatementBuilder statementBuilder;
        private readonly PipelineEventSubscriptions events;
        #endregion

        #region constructors
        public DeleteQueryExpressionExecutionPipeline(
            ILogger<DeleteQueryExpressionExecutionPipeline> logger,
            IDbConnectionFactory connectionFactory,
            ISqlStatementExecutor statementExecutor,
            ISqlStatementBuilder statementBuilder,
            PipelineEventSubscriptions events
        )
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
            this.statementExecutor = statementExecutor ?? throw new ArgumentNullException(nameof(statementExecutor));
            this.statementBuilder = statementBuilder ?? throw new ArgumentNullException(nameof(statementBuilder));
            this.events = events ?? throw new ArgumentNullException(nameof(events));
        }
        #endregion

        #region methods
        #region exec
        public int ExecuteDelete(DeleteQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            OnBeforeStart(expression);

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for delete query.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? DbExpressionQueryException.ThrowNullValueUnexpectedWithReturn<SqlStatement>(expression);

            OnAfterAssembly(expression, statementBuilder, statement);

            var rowsAffected = 0;
            var local = connection ?? new SqlConnector(connectionFactory);
            try
            {
                rowsAffected = statementExecutor.ExecuteScalar<int>(
                    statement,
                    local,
                    cmd => {
                        OnBeforeCommand(expression, cmd, statement);
                        configureCommand?.Invoke(cmd); 
                    },
                    cmd => OnAfterCommand(expression, cmd)
                );
            }
            finally
            {
                if (connection is null) //was not provided
                    local.Dispose();
            }

            OnAfterComplete(expression);

            return rowsAffected;
        }

        public async ValueTask<int> ExecuteDeleteAsync(DeleteQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            await OnBeforeStartAsync(expression, ct).ConfigureAwait(false);

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for delete query.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? DbExpressionQueryException.ThrowNullValueUnexpectedWithReturn<SqlStatement>(expression);

            await OnAfterAssemblyAsync(expression, statementBuilder, statement, ct).ConfigureAwait(false);

            var rowsAffected = 0;
            var local = connection ?? new SqlConnector(connectionFactory);
            try
            {
                rowsAffected = await statementExecutor.ExecuteScalarAsync<int>(
                    statement,
                    local,
                    async cmd =>
                    {
                        await OnBeforeCommandAsync(expression, cmd, statement, ct).ConfigureAwait(false);

                        if (!ct.IsCancellationRequested)
                            configureCommand?.Invoke(cmd);
                    },
                    async cmd => await OnAfterCommandAsync(expression, cmd, ct).ConfigureAwait(false),
                    ct
                ).ConfigureAwait(false);
            }
            finally
            {
                if (connection is null) //was not provided
                    local.Dispose();
            }

            ct.ThrowIfCancellationRequested();

            await OnAfterCompleteAsync(expression, ct);

            return rowsAffected;
        }

        #region events
        #region sync
        private void OnBeforeStart(DeleteQueryExpression expression)
        {
            try
            {
                if (events.OnBeforeStart is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before start events for delete query.");
                    events.OnBeforeStart.Invoke(new Lazy<BeforeStartPipelineEventContext>(() => new BeforeStartPipelineEventContext(expression, statementBuilder.Parameters)));
                }
                if (events.OnBeforeDeleteStart is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before delete start events for delete query.");
                    events.OnBeforeDeleteStart.Invoke(new Lazy<BeforeDeleteStartPipelineEventContext>(() => new BeforeDeleteStartPipelineEventContext(expression, statementBuilder.Parameters)));
                }
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnBeforeStart), "DELETE", e);
            }
        }

        private void OnAfterAssembly(DeleteQueryExpression expression, ISqlStatementBuilder statementBuilder, SqlStatement statement)
        {
            try
            {
                if (events.OnAfterDeleteAssembly is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after delete assembly events for delete query.");
                    events.OnAfterDeleteAssembly?.Invoke(new Lazy<AfterDeleteAssemblyPipelineEventContext>(() => new AfterDeleteAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement)));
                }
                if (events.OnAfterAssembly is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after assembly events for delete query.");
                    events.OnAfterAssembly?.Invoke(new Lazy<AfterAssemblyPipelineEventContext>(() => new AfterAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement)));
                }
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterAssembly), "DELETE", e);
            }
        }

        private void OnBeforeCommand(DeleteQueryExpression expression, IDbCommand command, SqlStatement statement)
        {
            try
            {
                if (events.OnBeforeCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before command events for delete query.");
                    events.OnBeforeCommand?.Invoke(new Lazy<BeforeCommandPipelineEventContext>(() => new BeforeCommandPipelineEventContext(expression, command, statement)));
                }
                if (events.OnBeforeDeleteCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before delete command events for delete query.");
                    events.OnBeforeDeleteCommand?.Invoke(new Lazy<BeforeDeleteCommandPipelineEventContext>(() => new BeforeDeleteCommandPipelineEventContext(expression, command, statement)));
                }
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnBeforeCommand), "DELETE", e);
            }
        }

        private void OnAfterCommand(DeleteQueryExpression expression, IDbCommand command)
        {
            try
            {
                if (events.OnAfterDeleteCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after delete command events for delete query.");
                    events.OnAfterDeleteCommand?.Invoke(new Lazy<AfterDeleteCommandPipelineEventContext>(() => new AfterDeleteCommandPipelineEventContext(expression, command)));
                }
                if (events.OnAfterCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after command events for delete query.");
                    events.OnAfterCommand?.Invoke(new Lazy<AfterCommandPipelineEventContext>(() => new AfterCommandPipelineEventContext(expression, command)));
                }
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterCommand), "DELETE", e);
            }
        }

        private void OnAfterComplete(DeleteQueryExpression expression)
        {
            try
            {
                if (events.OnAfterDeleteComplete is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after delete complete events for delete query.");
                    events.OnAfterDeleteComplete?.Invoke(new Lazy<AfterDeleteCompletePipelineEventContext>(() => new AfterDeleteCompletePipelineEventContext(expression)));
                }
                if (events.OnAfterComplete is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after complete events for delete query.");
                    events.OnAfterComplete?.Invoke(new Lazy<AfterCompletePipelineEventContext>(() => new AfterCompletePipelineEventContext(expression)));
                }
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterComplete), "DELETE", e);
            }
        }
        #endregion

        #region async
        private async Task OnBeforeStartAsync(DeleteQueryExpression expression, CancellationToken ct)
        {
            try
            {
                if (events.OnBeforeStart is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before start events for delete query.");
                    await events.OnBeforeStart.InvokeAsync(new Lazy<BeforeStartPipelineEventContext>(() => new BeforeStartPipelineEventContext(expression, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
                if (events.OnBeforeDeleteStart is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before delete start events for delete query.");
                    await events.OnBeforeDeleteStart.InvokeAsync(new Lazy<BeforeDeleteStartPipelineEventContext>(() => new BeforeDeleteStartPipelineEventContext(expression, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnBeforeStartAsync), "DELETE", e);
            }
        }

        private async Task OnAfterAssemblyAsync(DeleteQueryExpression expression, ISqlStatementBuilder statementBuilder, SqlStatement statement, CancellationToken ct)
        {
            try
            {
                if (events.OnAfterDeleteAssembly is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after delete assembly events for delete query.");
                    await events.OnAfterDeleteAssembly.InvokeAsync(new Lazy<AfterDeleteAssemblyPipelineEventContext>(() => new AfterDeleteAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
                if (events.OnAfterAssembly is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after assembly events for delete query.");
                    await events.OnAfterAssembly.InvokeAsync(new Lazy<AfterAssemblyPipelineEventContext>(() => new AfterAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterAssemblyAsync), "DELETE", e);
            }
        }

        private async Task OnBeforeCommandAsync(DeleteQueryExpression expression, IDbCommand command, SqlStatement statement, CancellationToken ct)
        {
            try
            {
                if (events.OnBeforeCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before command events for delete query.");
                    await events.OnBeforeCommand.InvokeAsync(new Lazy<BeforeCommandPipelineEventContext>(() => new BeforeCommandPipelineEventContext(expression, command, statement)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
                if (events.OnBeforeDeleteCommand is not null && !ct.IsCancellationRequested)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before delete command events for delete query.");
                    await events.OnBeforeDeleteCommand.InvokeAsync(new Lazy<BeforeDeleteCommandPipelineEventContext>(() => new BeforeDeleteCommandPipelineEventContext(expression, command, statement)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnBeforeCommandAsync), "DELETE", e);
            }
        }

        private async Task OnAfterCommandAsync(DeleteQueryExpression expression, IDbCommand command, CancellationToken ct)
        {
            try
            {
                if (events.OnAfterDeleteCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after delete command events for delete query.");
                    await events.OnAfterDeleteCommand.InvokeAsync(new Lazy<AfterDeleteCommandPipelineEventContext>(() => new AfterDeleteCommandPipelineEventContext(expression, command)), ct).ConfigureAwait(false);
                }
                if (events.OnAfterCommand is not null && !ct.IsCancellationRequested)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after command events for delete query.");
                    await events.OnAfterCommand.InvokeAsync(new Lazy<AfterCommandPipelineEventContext>(() => new AfterCommandPipelineEventContext(expression, command)), ct).ConfigureAwait(false);
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterCommandAsync), "DELETE", e);
            }
        }

        private async Task OnAfterCompleteAsync(DeleteQueryExpression expression, CancellationToken ct)
        {
            try
            {
                if (events.OnAfterDeleteComplete is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after delete complete events for delete query.");
                    await events.OnAfterDeleteComplete.InvokeAsync(new Lazy<AfterDeleteCompletePipelineEventContext>(() => new AfterDeleteCompletePipelineEventContext(expression)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
                if (events.OnAfterComplete is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after complete events for delete query.");
                    await events.OnAfterComplete.InvokeAsync(new Lazy<AfterCompletePipelineEventContext>(() => new AfterCompletePipelineEventContext(expression)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterCompleteAsync), "DELETE", e);
            }
        }
        #endregion
        #endregion
        #endregion
        #endregion
    }
}
