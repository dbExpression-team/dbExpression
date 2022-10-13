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
    public sealed class InsertQueryExpressionExecutionPipeline : IInsertQueryExpressionExecutionPipeline
    {
        #region internals
        private readonly ILogger<InsertQueryExpressionExecutionPipeline> logger;
        private readonly IDbConnectionFactory connectionFactory;
        private readonly ISqlStatementExecutor statementExecutor;
        private readonly IValueConverterFactory valueConverterFactory;
        private readonly IMapperFactory mapperFactory;
        private readonly ISqlStatementBuilder statementBuilder;
        private readonly PipelineEventSubscriptions events;
        #endregion

        #region constructors
        public InsertQueryExpressionExecutionPipeline(
            ILogger<InsertQueryExpressionExecutionPipeline> logger,
            IDbConnectionFactory connectionFactory,
            ISqlStatementExecutor statementExecutor,
            IValueConverterFactory valueConverterFactory,
            IMapperFactory mapperFactory,
            ISqlStatementBuilder statementBuilder,
            PipelineEventSubscriptions events
        )
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
            this.statementExecutor = statementExecutor ?? throw new ArgumentNullException(nameof(statementExecutor));
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException(nameof(valueConverterFactory));
            this.mapperFactory = mapperFactory ?? throw new ArgumentNullException(nameof(mapperFactory));
            this.statementBuilder = statementBuilder ?? throw new ArgumentNullException(nameof(statementBuilder));
            this.events = events ?? throw new ArgumentNullException(nameof(events));
        }
        #endregion

        #region methods
        public void ExecuteInsert<TEntity>(InsertQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            where TEntity : class, IDbEntity
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            #region before start events
            if (events.OnBeforeStart is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before start events for the insert query.");
                events.OnBeforeStart?.Invoke(new Lazy<BeforeStartPipelineEventContext>(() => new BeforeStartPipelineEventContext(expression, statementBuilder.Parameters)));
            }

            if (events.OnBeforeInsertStart is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before insert start events for each entity in the insert query.");
                foreach (var insert in expression.Inserts.Values)
                    events.OnBeforeInsertStart?.Invoke(new Lazy<BeforeInsertStartPipelineEventContext>(() => new BeforeInsertStartPipelineEventContext(expression, statementBuilder.Parameters, insert.Entity)));
            }
            #endregion

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for insert query.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? throw new DbExpressionException("The sql statement builder returned a null value, cannot execute an insert query without a sql statement.");

            #region after assembly events
            if (events.OnAfterInsertAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after insert assembly events for each entity in the insert query.");
                foreach (var insert in expression.Inserts.Values)
                    events.OnAfterInsertAssembly.Invoke(new Lazy<AfterInsertAssemblyPipelineEventContext>(() => new AfterInsertAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement, insert.Entity)));
            }
            if (events.OnAfterAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after assembly events for each entity in the insert query.");
                events.OnAfterAssembly.Invoke(new Lazy<AfterAssemblyPipelineEventContext>(() => new AfterAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement)));
            }
            #endregion

            var fields = new List<FieldExpression?> { null }.Concat(expression.Outputs).ToList();

            var local = connection ?? new SqlConnector(connectionFactory);
            try
            {
                var reader = statementExecutor.ExecuteQuery(
                    statement,
                    local,
                    new SqlStatementValueConverterProvider(valueConverterFactory, fields),
                    cmd => {
                        #region before command events
                        if (events.OnBeforeCommand is not null)
                        {
                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Invoking before command events for each entity in the insert query.");
                            events.OnBeforeCommand?.Invoke(new Lazy<BeforeCommandPipelineEventContext>(() => new BeforeCommandPipelineEventContext(expression, cmd, statement)));
                        }
                        if (events.OnBeforeInsertCommand is not null)
                        {
                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Invoking before insert command events for each entity in the insert query.");
                            foreach (var insert in expression.Inserts.Values)
                                events.OnBeforeInsertCommand?.Invoke(new Lazy<BeforeInsertCommandPipelineEventContext>(() => new BeforeInsertCommandPipelineEventContext(expression, cmd, statement, insert.Entity)));
                        }                        
                        #endregion

                        configureCommand?.Invoke(cmd);
                    },
                    cmd =>
                    {
                        #region after command events
                        if (events.OnAfterInsertCommand is not null)
                        {
                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Invoking after insert command events for each entity in the insert query.");
                            foreach (var insert in expression.Inserts.Values)
                                events.OnAfterInsertCommand?.Invoke(new Lazy<AfterInsertCommandPipelineEventContext>(() => new AfterInsertCommandPipelineEventContext(expression, cmd, insert.Entity)));
                        }
                        if (events.OnAfterCommand is not null)
                        {
                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Invoking after command events for each entity in the insert query.");
                            events.OnAfterCommand?.Invoke(new Lazy<AfterCommandPipelineEventContext>(() => new AfterCommandPipelineEventContext(expression, cmd)));
                        }
                        #endregion
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
            }
            finally
            {
                if (connection is null) //was not provided
                    local.Dispose();
            }

            #region after complete events
            if (events.OnAfterInsertComplete is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after insert command events for each entity in the insert query.");
                foreach (var insert in expression.Inserts.Values)
                    events.OnAfterInsertComplete?.Invoke(new Lazy<AfterInsertCompletePipelineEventContext>(() => new AfterInsertCompletePipelineEventContext(expression, insert.Entity)));
            }
            if (events.OnAfterComplete is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after command events for each entity in the insert query.");
                events.OnAfterComplete?.Invoke(new Lazy<AfterCompletePipelineEventContext>(() => new AfterCompletePipelineEventContext(expression)));
            }
            #endregion
        }

        public async Task ExecuteInsertAsync<TEntity>(InsertQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            where TEntity : class, IDbEntity
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            #region before assembly events
            if (events.OnBeforeStart is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before start events for the insert query.");
                await events.OnBeforeStart.InvokeAsync(new Lazy<BeforeStartPipelineEventContext>(() => new BeforeStartPipelineEventContext(expression, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            if (events.OnBeforeInsertStart is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking before insert assembly events for insert query.");
                foreach (var insert in expression.Inserts.Values)
                {
                    await events.OnBeforeInsertStart.InvokeAsync(new Lazy<BeforeInsertStartPipelineEventContext>(() => new BeforeInsertStartPipelineEventContext(expression, statementBuilder.Parameters, insert.Entity)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
            }
            #endregion

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for insert query.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? throw new DbExpressionException("The sql statement builder returned a null value, cannot execute an insert query without a sql statement.");

            #region after assembly events
            if (events.OnAfterInsertAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after insert assembly events for the insert query.");
                foreach (var insert in expression.Inserts.Values)
                {
                    await events.OnAfterInsertAssembly.InvokeAsync(new Lazy<AfterInsertAssemblyPipelineEventContext>(() => new AfterInsertAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement, insert.Entity)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
            }
            if (events.OnAfterAssembly is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after assembly events for the insert query.");
                await events.OnAfterAssembly.InvokeAsync(new Lazy<AfterAssemblyPipelineEventContext>(() => new AfterAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }
            #endregion

            var local = connection ?? new SqlConnector(connectionFactory);
            try
            {
                var reader = await statementExecutor.ExecuteQueryAsync(
                    statement,
                    local,
                    new SqlStatementValueConverterProvider(valueConverterFactory, new List<FieldExpression?> { null }.Concat(expression.Outputs).ToList()),
                    async cmd =>
                    {
                        #region before execution events
                        if (events.OnBeforeCommand is not null)
                        {
                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Invoking before command events for the insert query.");
                            await events.OnBeforeCommand.InvokeAsync(new Lazy<BeforeCommandPipelineEventContext>(() => new BeforeCommandPipelineEventContext(expression, cmd, statement)), ct).ConfigureAwait(false);
                        }
                        if (events.OnBeforeInsertCommand is not null && !ct.IsCancellationRequested)
                        {
                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Invoking before insert command events for each entity in the insert query.");
                            foreach (var insert in expression.Inserts.Values)
                            {
                                await events.OnBeforeInsertCommand.InvokeAsync(new Lazy<BeforeInsertCommandPipelineEventContext>(() => new BeforeInsertCommandPipelineEventContext(expression, cmd, statement, insert.Entity)), ct).ConfigureAwait(false);
                            }
                        }
                        #endregion
                        
                        if (!ct.IsCancellationRequested)
                            configureCommand?.Invoke(cmd);
                    },
                    async cmd =>
                    {
                        #region after execution events
                        if (events.OnAfterInsertCommand is not null)
                        {
                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Invoking after insert command events for each entity in the insert query.");
                            foreach (var insert in expression.Inserts.Values)
                            {
                                await events.OnAfterInsertCommand.InvokeAsync(new Lazy<AfterInsertCommandPipelineEventContext>(() => new AfterInsertCommandPipelineEventContext(expression, cmd, insert.Entity)), ct).ConfigureAwait(false);
                            }
                        }
                        if (events.OnAfterCommand is not null && !ct.IsCancellationRequested)
                        {
                            if (logger.IsEnabled(LogLevel.Trace))
                                logger.LogTrace("Invoking after command events for insert query.");
                            await events.OnAfterCommand.InvokeAsync(new Lazy<AfterCommandPipelineEventContext>(() => new AfterCommandPipelineEventContext(expression, cmd)), ct).ConfigureAwait(false);
                        }
                        #endregion
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
            }
            finally
            {
                if (connection is null) //was not provided
                    local.Dispose();
            }

            #region after complete events
            if (events.OnAfterInsertComplete is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after insert complete events for each entity in the insert query.");
                foreach (var insert in expression.Inserts.Values)
                {
                    await events.OnAfterInsertComplete.InvokeAsync(new Lazy<AfterInsertCompletePipelineEventContext>(() => new AfterInsertCompletePipelineEventContext(expression, insert.Entity)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
            }
            if (events.OnAfterComplete is not null)
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Invoking after complete events for insert query.");
                await events.OnAfterComplete.InvokeAsync(new Lazy<AfterCompletePipelineEventContext>(() => new AfterCompletePipelineEventContext(expression)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }
            #endregion
        }
        #endregion
    }
}
