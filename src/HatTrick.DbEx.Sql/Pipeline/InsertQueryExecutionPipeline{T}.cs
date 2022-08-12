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
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Mapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class InsertQueryExecutionPipeline<TDatabase> : IInsertQueryExecutionPipeline<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly ILogger<InsertQueryExecutionPipeline<TDatabase>> logger;
        private readonly ISqlStatementExecutor<TDatabase> statementExecutor;
        private readonly IValueConverterFactory<TDatabase> valueConverterFactory;
        private readonly IMapperFactory<TDatabase> mapperFactory;
        private readonly ISqlStatementBuilder<TDatabase> statementBuilder;
        private readonly PipelineEventHooks<TDatabase> events;
        #endregion

        #region constructors
        public InsertQueryExecutionPipeline(
            ILoggerFactory loggerFactory,
            ISqlStatementExecutor<TDatabase> statementExecutor,
            IValueConverterFactory<TDatabase> valueConverterFactory,
            IMapperFactory<TDatabase> mapperFactory,
            ISqlStatementBuilder<TDatabase> statementBuilder,
            PipelineEventHooks<TDatabase> events
        )
        {
            this.logger = (loggerFactory ?? throw new ArgumentNullException(nameof(logger))).CreateLogger<InsertQueryExecutionPipeline<TDatabase>>();
            this.statementExecutor = statementExecutor ?? throw new ArgumentNullException(nameof(statementExecutor));
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException(nameof(valueConverterFactory));
            this.mapperFactory = mapperFactory ?? throw new ArgumentNullException(nameof(mapperFactory));
            this.statementBuilder = statementBuilder ?? throw new ArgumentNullException(nameof(statementBuilder));
            this.events = events ?? throw new ArgumentNullException(nameof(events));
        }
        #endregion

        #region methods
        public virtual void ExecuteInsert<TEntity>(InsertQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand)
            where TEntity : class, IDbEntity
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (connection is null)
                throw new ArgumentNullException(nameof(connection));

            if (events.BeforeAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before assembly events for insert query.");
                events.BeforeAssembly?.Invoke(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(expression, statementBuilder.Parameters)));
            }

            if (events.BeforeInsertAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before insert assembly events for insert query.");
                events.BeforeInsertAssembly?.Invoke(new Lazy<BeforeInsertAssemblyPipelineExecutionContext>(() => new BeforeInsertAssemblyPipelineExecutionContext(expression, statementBuilder.Parameters)));
            }

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for insert query.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? throw new DbExpressionException("The sql statement builder returned a null value, cannot execute an insert query without a sql statement.");

            if (events.AfterAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after assembly events for insert query.");
                events.AfterAssembly?.Invoke(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(expression, statementBuilder.Parameters, statement)));
            }

            if (events.BeforeInsert is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before insert events for each entity in the insert query.");
                foreach (var insert in expression.Inserts.Values)
                    events.BeforeInsert?.Invoke(new Lazy<BeforeInsertPipelineExecutionContext>(() => new BeforeInsertPipelineExecutionContext(expression, insert.Entity, statementBuilder.Parameters, statement)));
            }

            var fields = new List<FieldExpression?> { null }.Concat(expression.Outputs).ToList();

            var reader = statementExecutor.ExecuteQuery(
                statement,
                connection,
                new SqlStatementValueConverterProvider(valueConverterFactory, fields),
                cmd => {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before execution events for insert query.");
                    events.BeforeExecution?.Invoke(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(expression, cmd, statement)));
                    configureCommand?.Invoke(cmd);
                },
                cmd =>
                {
                    if (events.AfterExecution is not null)
                    {
                        if (logger.IsEnabled(LogLevel.Trace))
                            logger.LogTrace("Invoking after execution events for insert query.");
                        events.AfterExecution?.Invoke(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(expression, cmd)));
                    }
                }
            );

            var mapper = mapperFactory.CreateEntityMapper(expression.Into as Table<TEntity> ?? throw new InvalidOperationException($"Expected base entity to be type {typeof(Table<TEntity>)}."));

            ISqlFieldReader? row;
            while ((row = reader.ReadRow()) is not null)
            {
                int? index = null;
                try
                {
                    index = row.ReadField()?.GetValue<int>();
                }
                catch (InvalidCastException e)
                {
                    throw new DbExpressionException("Expected the execution of the insert statement to return a reader where the first field in the reader is an integer used to locate the in-memory entity for hydrating values.", e);
                }
                if (index is null)
                    throw new DbExpressionException("Expected the execution of the insert statement to return a reader where the first field in the reader is an integer used to locate the in-memory entity for hydrating values.");
                var entity = expression.Inserts.Single(x => x.Key == Convert.ToInt32(index)).Value.Entity;
                mapper.Map(row, (entity as TEntity) ?? throw new DbExpressionException($"Expected entity to by type {typeof(TEntity)}, but was actually {entity.GetType()}"));
            }

            if (events.AfterInsert is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after insert events for each entity in the insert query.");
                foreach (var insert in expression.Inserts.Values)
                    events.AfterInsert?.Invoke(new Lazy<AfterInsertPipelineExecutionContext>(() => new AfterInsertPipelineExecutionContext(expression, insert.Entity)));
            }
        }

        public virtual async Task ExecuteInsertAsync<TEntity>(InsertQueryExpression expression, ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            where TEntity : class, IDbEntity
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (connection is null)
                throw new ArgumentNullException(nameof(connection));

            if (events.BeforeAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before assembly events for insert query.");
                await events.BeforeAssembly.InvokeAsync(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(expression, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            if (events.BeforeInsertAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before insert assembly events for insert query.");
                await events.BeforeInsertAssembly.InvokeAsync(new Lazy<BeforeInsertAssemblyPipelineExecutionContext>(() => new BeforeInsertAssemblyPipelineExecutionContext(expression, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for insert query.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? throw new DbExpressionException("The sql statement builder returned a null value, cannot execute an insert query without a sql statement.");
            
            if (events.AfterAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after assembly events for insert query.");
                await events.AfterAssembly.InvokeAsync(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(expression, statementBuilder.Parameters, statement)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            if (events.BeforeInsert is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before insert events for each entity in the insert query.");
                foreach (var insert in expression.Inserts.Values)
                {
                    await events.BeforeInsert.InvokeAsync(new Lazy<BeforeInsertPipelineExecutionContext>(() => new BeforeInsertPipelineExecutionContext(expression, insert.Entity, statementBuilder.Parameters, statement)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
            }

            var reader = await statementExecutor.ExecuteQueryAsync(
                statement,
                connection,
                new SqlStatementValueConverterProvider(valueConverterFactory, new List<FieldExpression?> { null }.Concat(expression.Outputs).ToList()),
                async cmd =>
                {
                    if (events.BeforeExecution is not null)
                    {
                        if (logger.IsEnabled(LogLevel.Trace))
                            logger.LogTrace("Invoking before execution events for insert query.");
                        await events.BeforeExecution.InvokeAsync(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(expression, cmd, statement)), ct).ConfigureAwait(false);
                    }
                    configureCommand?.Invoke(cmd);
                },
                async cmd =>
                {
                    if (events.AfterExecution is not null)
                    {
                        if (logger.IsEnabled(LogLevel.Trace))
                            logger.LogTrace("Invoking after execution events for insert query.");
                        await events.AfterExecution.InvokeAsync(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(expression, cmd)), ct).ConfigureAwait(false);
                    }
                },
                ct
            ).ConfigureAwait(false);

            ct.ThrowIfCancellationRequested();

            var mapper = mapperFactory.CreateEntityMapper(expression.Into as Table<TEntity> ?? throw new InvalidOperationException($"Expected base entity to be type {typeof(Table<TEntity>)}.")) 
                ?? throw new DbExpressionException("The mapper is null, cannot execute an insert query without a mapper to map return values to entity instances.");

            ISqlFieldReader? row;
            while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is not null)
            {
                int? index = null;
                try
                {
                    index = row.ReadField()?.GetValue<int>();
                }
                catch (InvalidCastException e)
                {
                    throw new DbExpressionException("Expected the execution of the insert statement to return a reader where the first field in the reader is an integer used to locate the in-memory entity for hydrating values.", e);
                }
                if (index is null)
                    throw new DbExpressionException("Expected the execution of the insert statement to return a reader where the first field in the reader is an integer used to locate the in-memory entity for hydrating values.");
                var entity = expression.Inserts.Single(x => x.Key == Convert.ToInt32(index)).Value.Entity;
                mapper.Map(row, entity as TEntity ?? throw new InvalidOperationException($"Expected entity to be type {typeof(TEntity)}."));
            }

            if (events.AfterInsert is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after insert events for each entity in the insert query.");
                foreach (var insert in expression.Inserts.Values)
                {
                    await events.AfterInsert.InvokeAsync(new Lazy<AfterInsertPipelineExecutionContext>(() => new AfterInsertPipelineExecutionContext(expression, insert.Entity)), ct).ConfigureAwait(false);
                }
                ct.ThrowIfCancellationRequested();
            }
        }
        #endregion
    }
}
