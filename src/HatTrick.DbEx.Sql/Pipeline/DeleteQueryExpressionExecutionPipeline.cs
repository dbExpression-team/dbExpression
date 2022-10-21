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
        public int ExecuteDelete(DeleteQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            #region before start events
            if (events.OnBeforeStart is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before start events for delete query.");
                events.OnBeforeStart?.Invoke(new Lazy<BeforeStartPipelineEventContext>(() => new BeforeStartPipelineEventContext(expression, statementBuilder.Parameters)));
            }

            if (events.OnBeforeDeleteStart is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before delete start events for delete query.");
                events.OnBeforeDeleteStart?.Invoke(new Lazy<BeforeDeleteStartPipelineEventContext>(() => new BeforeDeleteStartPipelineEventContext(expression, statementBuilder.Parameters)));
            }
            #endregion

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for delete query.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? throw new DbExpressionException("The sql statement builder returned a null value, cannot execute a delete query without a sql statement.");

            #region after assembly events
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
            #endregion

            var rowsAffected = 0;
            var local = connection ?? new SqlConnector(connectionFactory);
            try
            {
                rowsAffected = statementExecutor.ExecuteScalar<int>(
                    statement,
                    local,
                    cmd => {
                        #region before command events
                        if (events.OnBeforeCommand is not null)
                        {
                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Invoking before command events for delete query.");
                            events.OnBeforeCommand.Invoke(new Lazy<BeforeCommandPipelineEventContext>(() => new BeforeCommandPipelineEventContext(expression, cmd, statement)));
                        }
                        if (events.OnBeforeDeleteCommand is not null)
                        {
                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Invoking before delete command events for delete query.");
                            events.OnBeforeDeleteCommand.Invoke(new Lazy<BeforeDeleteCommandPipelineEventContext>(() => new BeforeDeleteCommandPipelineEventContext(expression, cmd, statement)));
                        }
                        #endregion
                        configureCommand?.Invoke(cmd); 
                    },
                    cmd =>
                    {
                        #region after command events
                        if (events.OnAfterDeleteCommand is not null)
                        {
                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Invoking after delete command events for delete query.");
                            events.OnAfterDeleteCommand.Invoke(new Lazy<AfterDeleteCommandPipelineEventContext>(() => new AfterDeleteCommandPipelineEventContext(expression, cmd)));
                        }
                        if (events.OnAfterCommand is not null)
                        {
                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Invoking after command events for delete query.");
                            events.OnAfterCommand?.Invoke(new Lazy<AfterCommandPipelineEventContext>(() => new AfterCommandPipelineEventContext(expression, cmd)));
                        }
                        #endregion
                    }
                );
            }
            finally
            {
                if (connection is null) //was not provided
                    local.Dispose();
            }

            #region after command events
            if (events.OnAfterDeleteComplete is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after delete complete events for delete query.");
                events.OnAfterDeleteComplete.Invoke(new Lazy<AfterDeleteCompletePipelineEventContext>(() => new AfterDeleteCompletePipelineEventContext(expression)));
            }
            if (events.OnAfterComplete is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after complete events for delete query.");
                events.OnAfterComplete?.Invoke(new Lazy<AfterCompletePipelineEventContext>(() => new AfterCompletePipelineEventContext(expression)));
            }
            #endregion

            return rowsAffected;
        }

        public async Task<int> ExecuteDeleteAsync(DeleteQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            #region before start events
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
            #endregion

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for delete query.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? throw new DbExpressionException("The sql statement builder returned a null value, cannot execute a delete query without a sql statement.");

            #region after assembly events
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
            #endregion

            var rowsAffected = 0;
            var local = connection ?? new SqlConnector(connectionFactory);
            try
            {
                rowsAffected = await statementExecutor.ExecuteScalarAsync<int>(
                    statement,
                    local,
                    async cmd =>
                    {
                        #region before command events
                        if (events.OnBeforeCommand is not null)
                        {
                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Invoking before command events for delete query.");
                            await events.OnBeforeCommand.InvokeAsync(new Lazy<BeforeCommandPipelineEventContext>(() => new BeforeCommandPipelineEventContext(expression, cmd, statement)), ct).ConfigureAwait(false);
                        }
                        if (events.OnBeforeDeleteCommand is not null && !ct.IsCancellationRequested)
                        {
                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Invoking before delete command events for delete query.");
                            await events.OnBeforeDeleteCommand.InvokeAsync(new Lazy<BeforeDeleteCommandPipelineEventContext>(() => new BeforeDeleteCommandPipelineEventContext(expression, cmd, statement)), ct).ConfigureAwait(false);
                        }
                        #endregion

                        if (!ct.IsCancellationRequested)
                            configureCommand?.Invoke(cmd);
                    },
                    async cmd =>
                    {
                        #region after command events
                        if (events.OnAfterDeleteCommand is not null)
                        {
                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Invoking after delete command events for delete query.");
                            await events.OnAfterDeleteCommand.InvokeAsync(new Lazy<AfterDeleteCommandPipelineEventContext>(() => new AfterDeleteCommandPipelineEventContext(expression, cmd)), ct).ConfigureAwait(false);
                        }
                        if (events.OnAfterCommand is not null && !ct.IsCancellationRequested)
                        {
                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Invoking after command events for delete query.");
                            await events.OnAfterCommand.InvokeAsync(new Lazy<AfterCommandPipelineEventContext>(() => new AfterCommandPipelineEventContext(expression, cmd)), ct).ConfigureAwait(false);
                        }
                        #endregion
                    },
                    ct
                ).ConfigureAwait(false);
            }
            finally
            {
                if (connection is null) //was not provided
                    local.Dispose();
            }

            ct.ThrowIfCancellationRequested();

            #region after complete events
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
            #endregion

            return rowsAffected;
        }
        #endregion
    }
}
