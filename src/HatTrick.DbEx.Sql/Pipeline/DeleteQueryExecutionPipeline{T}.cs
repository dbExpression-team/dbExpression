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
    public class DeleteQueryExecutionPipeline<TDatabase> : IDeleteQueryExecutionPipeline<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly ILogger<DeleteQueryExecutionPipeline<TDatabase>> logger;
        private readonly ISqlStatementExecutor<TDatabase> statementExecutor;
        private readonly ISqlStatementBuilder<TDatabase> statementBuilder;
        private readonly PipelineEventHooks<TDatabase> events;
        #endregion

        #region constructors
        public DeleteQueryExecutionPipeline(
            ILogger<DeleteQueryExecutionPipeline<TDatabase>> logger,
            ISqlStatementExecutor<TDatabase> statementExecutor,
            ISqlStatementBuilder<TDatabase> statementBuilder,
            PipelineEventHooks<TDatabase> events
        )
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.statementExecutor = statementExecutor ?? throw new ArgumentNullException(nameof(statementExecutor));
            this.statementBuilder = statementBuilder ?? throw new ArgumentNullException(nameof(statementBuilder));
            this.events = events ?? throw new ArgumentNullException(nameof(events));
        }
        #endregion

        #region methods
        public virtual int ExecuteDelete(DeleteQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (connection is null)
                throw new ArgumentNullException(nameof(connection));

            if (events.BeforeAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before assembly events for delete query.");
                events.BeforeAssembly?.Invoke(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(expression, statementBuilder.Parameters)));
            }

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for delete query.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? throw new DbExpressionException("The sql statement builder returned a null value, cannot execute a delete query without a sql statement.");

            if (events.AfterAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after assembly events for delete query.");
                events.AfterAssembly?.Invoke(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(expression, statementBuilder.Parameters, statement)));
            }

            if (events.BeforeDelete is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before delete events for delete query.");
                events.BeforeDelete?.Invoke(new Lazy<BeforeDeletePipelineExecutionContext>(() => new BeforeDeletePipelineExecutionContext(expression, statementBuilder.Parameters, statement)));
            }

            var rowsAffected = statementExecutor.ExecuteScalar<int>(
                statement,
                connection,
                cmd => {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before execution events for delete query.");
                    events.BeforeExecution?.Invoke(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(expression, cmd, statement))); 
                    configureCommand?.Invoke(cmd); 
                },
                cmd =>
                {
                    if (events.AfterExecution is not null)
                    {
                        if (logger.IsEnabled(LogLevel.Trace))
                            logger.LogTrace("Invoking after execution events for delete query.");
                        events.AfterExecution?.Invoke(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(expression, cmd)));
                    }
                }
            );

            if (events.AfterDelete is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after update events for delete query.");
                events.AfterDelete?.Invoke(new Lazy<AfterDeletePipelineExecutionContext>(() => new AfterDeletePipelineExecutionContext(expression)));
            }

            return rowsAffected;
        }

        public virtual async Task<int> ExecuteDeleteAsync(DeleteQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (connection is null)
                throw new ArgumentNullException(nameof(connection));

            if (events.BeforeAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before assembly events for delete query.");
                await events.BeforeAssembly.InvokeAsync(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(expression, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for delete query.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? throw new DbExpressionException("The sql statement builder returned a null value, cannot execute a delete query without a sql statement.");
            
            if (events.AfterAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after assembly events for delete query.");
                await events.AfterAssembly.InvokeAsync(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(expression, statementBuilder.Parameters, statement)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            if (events.BeforeDelete is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before delete events for delete query.");
                await events.BeforeDelete.InvokeAsync(new Lazy<BeforeDeletePipelineExecutionContext>(() => new BeforeDeletePipelineExecutionContext(expression, statementBuilder.Parameters, statement)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            var rowsAffected = await statementExecutor.ExecuteScalarAsync<int>(
                statement,
                connection,
                async cmd =>
                {
                    if (events.BeforeExecution is not null)
                    {
                        if (logger.IsEnabled(LogLevel.Trace))
                            logger.LogTrace("Invoking before execution events for delete query.");
                        await events.BeforeExecution.InvokeAsync(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(expression, cmd, statement)), ct).ConfigureAwait(false);
                    }
                    configureCommand?.Invoke(cmd);
                },
                async cmd =>
                {
                    if (events.AfterExecution is not null)
                    {
                        if (logger.IsEnabled(LogLevel.Trace))
                            logger.LogTrace("Invoking after execution events for delete query.");
                        await events.AfterExecution.InvokeAsync(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(expression, cmd)), ct).ConfigureAwait(false);
                    }
                },
                ct
            ).ConfigureAwait(false);

            ct.ThrowIfCancellationRequested();

            if (events.AfterDelete is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after update events for delete query.");
                await events.AfterDelete.InvokeAsync(new Lazy<AfterDeletePipelineExecutionContext>(() => new AfterDeletePipelineExecutionContext(expression)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            return rowsAffected;
        }
        #endregion
    }
}
