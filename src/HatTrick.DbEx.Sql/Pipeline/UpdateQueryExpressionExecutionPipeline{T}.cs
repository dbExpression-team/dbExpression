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
    public class UpdateQueryExpressionExecutionPipeline<TDatabase> : IUpdateQueryExecutionPipeline<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly ILogger<UpdateQueryExpressionExecutionPipeline<TDatabase>> logger;
        private readonly ISqlStatementExecutor<TDatabase> statementExecutor;
        private readonly ISqlStatementBuilder<TDatabase> statementBuilder;
        private readonly PipelineEventHooks<TDatabase> events;
        #endregion

        #region constructors
        public UpdateQueryExpressionExecutionPipeline(
            ILoggerFactory loggerFactory,
            ISqlStatementExecutor<TDatabase> statementExecutor,
            ISqlStatementBuilder<TDatabase> statementBuilder,
            PipelineEventHooks<TDatabase> events
        )
        {
            this.logger = (loggerFactory ?? throw new ArgumentNullException(nameof(logger))).CreateLogger<UpdateQueryExpressionExecutionPipeline<TDatabase>>();
            this.statementExecutor = statementExecutor ?? throw new ArgumentNullException(nameof(statementExecutor));
            this.statementBuilder = statementBuilder ?? throw new ArgumentNullException(nameof(statementBuilder));
            this.events = events ?? throw new ArgumentNullException(nameof(events));
        }
        #endregion

        #region methods
        public virtual int ExecuteUpdate(UpdateQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (connection is null)
                throw new ArgumentNullException(nameof(connection));

            if (events.BeforeAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before assembly events for update query.");
                events.BeforeAssembly?.Invoke(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(expression, statementBuilder.Parameters)));
            }

            if (events.BeforeUpdateAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before update assembly events for update query.");
                events.BeforeUpdateAssembly?.Invoke(new Lazy<BeforeUpdateAssemblyPipelineExecutionContext>(() => new BeforeUpdateAssemblyPipelineExecutionContext(expression, statementBuilder.Parameters)));
            }

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for update query.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? throw new DbExpressionException("The sql statement builder returned a null value, cannot execute an update query without a sql statement.");

            if (events.AfterAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after assembly events for update query.");
                events.AfterAssembly?.Invoke(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(expression, statementBuilder.Parameters, statement)));
            }

            if (events.BeforeUpdate is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before update events for update query.");
                events.BeforeUpdate?.Invoke(new Lazy<BeforeUpdatePipelineExecutionContext>(() => new BeforeUpdatePipelineExecutionContext(expression, statement, statementBuilder.Parameters)));
            }

            var rowsAffected = statementExecutor.ExecuteScalar<int>(
                statement,
                connection,
                cmd => {
                    if (events.BeforeExecution is not null)
                    {
                        if (logger.IsEnabled(LogLevel.Trace))
                            logger.LogTrace("Invoking before execution events for update query.");
                        events.BeforeExecution?.Invoke(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(expression, cmd, statement)));
                    }
                    configureCommand?.Invoke(cmd); 
                },
                cmd =>
                {
                    if (events.AfterExecution is not null)
                    {
                        if (logger.IsEnabled(LogLevel.Trace))
                            logger.LogTrace("Invoking after execution events for update query.");
                        events.AfterExecution?.Invoke(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(expression, cmd)));
                    }
                }
            );

            if (events.AfterUpdate is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after update events for update query.");
                events.AfterUpdate?.Invoke(new Lazy<AfterUpdatePipelineExecutionContext>(() => new AfterUpdatePipelineExecutionContext(expression, statement)));
            }

            return rowsAffected;
        }

        public virtual async Task<int> ExecuteUpdateAsync(UpdateQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (connection is null)
                throw new ArgumentNullException(nameof(connection));

            if (events.BeforeAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before assembly events for update query.");
                await events.BeforeAssembly.InvokeAsync(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(expression, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            if (events.BeforeUpdateAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before update assembly events for update query.");
                await events.BeforeUpdateAssembly.InvokeAsync(new Lazy<BeforeUpdateAssemblyPipelineExecutionContext>(() => new BeforeUpdateAssemblyPipelineExecutionContext(expression, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for update query.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? throw new DbExpressionException("The sql statement builder returned a null value, cannot execute an update query without a sql statement.");
            
            if (events.AfterAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after assembly events for update query.");
                await events.AfterAssembly.InvokeAsync(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(expression, statementBuilder.Parameters, statement)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            if (events.BeforeUpdate is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before update events for update query.");
                await events.BeforeUpdate.InvokeAsync(new Lazy<BeforeUpdatePipelineExecutionContext>(() => new BeforeUpdatePipelineExecutionContext(expression, statement, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            var rowsAffected = await statementExecutor.ExecuteScalarAsync<int>(
                statement,
                connection,
                async cmd => {
                    if (events.BeforeExecution is not null)
                    {
                        if (logger.IsEnabled(LogLevel.Trace))
                            logger.LogTrace("Invoking before execution events for update query.");
                        await events.BeforeExecution.InvokeAsync(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(expression, cmd, statement)), ct).ConfigureAwait(false);
                    }
                    configureCommand?.Invoke(cmd);
                },
                async cmd =>
                {
                    if (events.AfterExecution is not null)
                    {
                        if (logger.IsEnabled(LogLevel.Trace))
                            logger.LogTrace("Invoking after execution events for update query.");
                        await events.AfterExecution.InvokeAsync(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(expression, cmd)), ct).ConfigureAwait(false);
                    }
                },
                ct
            ).ConfigureAwait(false);

            ct.ThrowIfCancellationRequested();

            if (events.AfterUpdate is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after update events for update query.");
                await events.AfterUpdate.InvokeAsync(new Lazy<AfterUpdatePipelineExecutionContext>(() => new AfterUpdatePipelineExecutionContext(expression, statement)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            return rowsAffected;
        }
        #endregion
    }
}
