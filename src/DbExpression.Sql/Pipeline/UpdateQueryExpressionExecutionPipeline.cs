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

using DbExpression.Sql.Assembler;
using DbExpression.Sql.Connection;
using DbExpression.Sql.Executor;
using DbExpression.Sql.Expression;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DbExpression.Sql.Pipeline
{
    public sealed class UpdateQueryExpressionExecutionPipeline : IUpdateQueryExpressionExecutionPipeline
    {
        #region internals
        private readonly ILogger<UpdateQueryExpressionExecutionPipeline> logger;
        private readonly IDbConnectionFactory connectionFactory;
        private readonly ISqlStatementExecutor statementExecutor;
        private readonly ISqlStatementBuilder statementBuilder;
        private readonly PipelineEventSubscriptions events;
        #endregion

        #region constructors
        public UpdateQueryExpressionExecutionPipeline(
            ILogger<UpdateQueryExpressionExecutionPipeline> logger,
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
        public int ExecuteUpdate(UpdateQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            OnBeforeStart(expression);

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for update query.");
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

        public async ValueTask<int> ExecuteUpdateAsync(UpdateQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            await OnBeforeStartAsync(expression, ct).ConfigureAwait(false);

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for update query.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? DbExpressionQueryException.ThrowNullValueUnexpectedWithReturn<SqlStatement>(expression);

            await OnAfterAssemblyAsync(expression, statementBuilder, statement, ct).ConfigureAwait(false);

            var rowsAffected = 0;
            var local = connection ?? new SqlConnector(connectionFactory);
            try
            {
                rowsAffected = await statementExecutor.ExecuteScalarAsync<int>(
                    statement,
                    local,
                    async cmd => {
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

            await OnAfterCompleteAsync(expression, ct).ConfigureAwait(false);

            return rowsAffected;
        }

        #region events
        #region sync
        private void OnBeforeStart(UpdateQueryExpression expression)
        {
            try
            {
                if (events.OnBeforeStart is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before start events for update query.");
                    events.OnBeforeStart.Invoke(new Lazy<BeforeStartPipelineEventContext>(() => new BeforeStartPipelineEventContext(expression, statementBuilder.Parameters)));
                }
                if (events.OnBeforeUpdateStart is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before update start events for update query.");
                    events.OnBeforeUpdateStart.Invoke(new Lazy<BeforeUpdateStartPipelineEventContext>(() => new BeforeUpdateStartPipelineEventContext(expression, statementBuilder.Parameters)));
                }
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnBeforeStart), "UPDATE", e);
            }
        }

        private void OnAfterAssembly(UpdateQueryExpression expression, ISqlStatementBuilder statementBuilder, SqlStatement statement)
        {
            try
            {
                if (events.OnAfterUpdateAssembly is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after update assembly events for update query.");
                    events.OnAfterUpdateAssembly?.Invoke(new Lazy<AfterUpdateAssemblyPipelineEventContext>(() => new AfterUpdateAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement)));
                }
                if (events.OnAfterAssembly is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after assembly events for update query.");
                    events.OnAfterAssembly?.Invoke(new Lazy<AfterAssemblyPipelineEventContext>(() => new AfterAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement)));
                }
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterAssembly), "UPDATE", e);
            }
        }

        private void OnBeforeCommand(UpdateQueryExpression expression, IDbCommand command, SqlStatement statement)
        {
            try
            {
                if (events.OnBeforeCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before command events for update query.");
                    events.OnBeforeCommand?.Invoke(new Lazy<BeforeCommandPipelineEventContext>(() => new BeforeCommandPipelineEventContext(expression, command, statement)));
                }
                if (events.OnBeforeUpdateCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before update command events for update query.");
                    events.OnBeforeUpdateCommand?.Invoke(new Lazy<BeforeUpdateCommandPipelineEventContext>(() => new BeforeUpdateCommandPipelineEventContext(expression, command, statement)));
                }
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnBeforeCommand), "UPDATE", e);
            }
        }

        private void OnAfterCommand(UpdateQueryExpression expression, IDbCommand command)
        {
            try
            {
                if (events.OnAfterUpdateCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after update command events for update query.");
                    events.OnAfterUpdateCommand?.Invoke(new Lazy<AfterUpdateCommandPipelineEventContext>(() => new AfterUpdateCommandPipelineEventContext(expression, command)));
                }
                if (events.OnAfterCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after command events for update query.");
                    events.OnAfterCommand?.Invoke(new Lazy<AfterCommandPipelineEventContext>(() => new AfterCommandPipelineEventContext(expression, command)));
                }
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterCommand), "UPDATE", e);
            }
        }

        private void OnAfterComplete(UpdateQueryExpression expression)
        {
            try
            {
                if (events.OnAfterUpdateComplete is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after update complete events for update query.");
                    events.OnAfterUpdateComplete?.Invoke(new Lazy<AfterUpdateCompletePipelineEventContext>(() => new AfterUpdateCompletePipelineEventContext(expression)));
                }
                if (events.OnAfterComplete is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after complete events for update query.");
                    events.OnAfterComplete?.Invoke(new Lazy<AfterCompletePipelineEventContext>(() => new AfterCompletePipelineEventContext(expression)));
                }
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterComplete), "UPDATE", e);
            }
        }
        #endregion

        #region async
        private async Task OnBeforeStartAsync(UpdateQueryExpression expression, CancellationToken ct)
        {
            try
            {
                if (events.OnBeforeStart is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before start events for update query.");
                    await events.OnBeforeStart.InvokeAsync(new Lazy<BeforeStartPipelineEventContext>(() => new BeforeStartPipelineEventContext(expression, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
                if (events.OnBeforeUpdateStart is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before update start events for update query.");
                    await events.OnBeforeUpdateStart.InvokeAsync(new Lazy<BeforeUpdateStartPipelineEventContext>(() => new BeforeUpdateStartPipelineEventContext(expression, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
            }
            catch (Exception e) when (e is OperationCanceledException || e is TaskCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnBeforeStartAsync), "UPDATE", e);
            }
        }

        private async Task OnAfterAssemblyAsync(UpdateQueryExpression expression, ISqlStatementBuilder statementBuilder, SqlStatement statement, CancellationToken ct)
        {
            try
            {
                if (events.OnAfterUpdateAssembly is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after update assembly events for update query.");
                    await events.OnAfterUpdateAssembly.InvokeAsync(new Lazy<AfterUpdateAssemblyPipelineEventContext>(() => new AfterUpdateAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
                if (events.OnAfterAssembly is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after assembly events for update query.");
                    await events.OnAfterAssembly.InvokeAsync(new Lazy<AfterAssemblyPipelineEventContext>(() => new AfterAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
            }
            catch (Exception e) when (e is OperationCanceledException || e is TaskCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterAssemblyAsync), "UPDATE", e);
            }
        }

        private async Task OnBeforeCommandAsync(UpdateQueryExpression expression, IDbCommand command, SqlStatement statement, CancellationToken ct)
        {
            try
            {
                if (events.OnBeforeCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before command events for update query.");
                    await events.OnBeforeCommand.InvokeAsync(new Lazy<BeforeCommandPipelineEventContext>(() => new BeforeCommandPipelineEventContext(expression, command, statement)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
                if (events.OnBeforeUpdateCommand is not null && !ct.IsCancellationRequested)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before update command events for update query.");
                    await events.OnBeforeUpdateCommand.InvokeAsync(new Lazy<BeforeUpdateCommandPipelineEventContext>(() => new BeforeUpdateCommandPipelineEventContext(expression, command, statement)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
            }
            catch (Exception e) when (e is OperationCanceledException || e is TaskCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnBeforeCommandAsync), "UPDATE", e);
            }
        }

        private async Task OnAfterCommandAsync(UpdateQueryExpression expression, IDbCommand command, CancellationToken ct)
        {
            try
            {
                if (events.OnAfterUpdateCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after update command events for update query.");
                    await events.OnAfterUpdateCommand.InvokeAsync(new Lazy<AfterUpdateCommandPipelineEventContext>(() => new AfterUpdateCommandPipelineEventContext(expression, command)), ct).ConfigureAwait(false);
                }
                if (events.OnAfterCommand is not null && !ct.IsCancellationRequested)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after command events for update query.");
                    await events.OnAfterCommand.InvokeAsync(new Lazy<AfterCommandPipelineEventContext>(() => new AfterCommandPipelineEventContext(expression, command)), ct).ConfigureAwait(false);
                }
            }
            catch (Exception e) when (e is OperationCanceledException || e is TaskCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterCommandAsync), "UPDATE", e);
            }
        }

        private async Task OnAfterCompleteAsync(UpdateQueryExpression expression, CancellationToken ct)
        {
            try
            {
                if (events.OnAfterUpdateComplete is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after update complete events for update query.");
                    await events.OnAfterUpdateComplete.InvokeAsync(new Lazy<AfterUpdateCompletePipelineEventContext>(() => new AfterUpdateCompletePipelineEventContext(expression)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
                if (events.OnAfterComplete is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after complete events for update query.");
                    await events.OnAfterComplete.InvokeAsync(new Lazy<AfterCompletePipelineEventContext>(() => new AfterCompletePipelineEventContext(expression)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
            }
            catch (Exception e) when (e is OperationCanceledException || e is TaskCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterCompleteAsync), "UPDATE", e);
            }
        }
        #endregion
        #endregion
        #endregion
        #endregion
    }
}
