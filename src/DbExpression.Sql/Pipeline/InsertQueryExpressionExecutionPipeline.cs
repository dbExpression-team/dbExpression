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
using DbExpression.Sql.Converter;
using DbExpression.Sql.Executor;
using DbExpression.Sql.Expression;
using DbExpression.Sql.Mapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DbExpression.Sql.Pipeline
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
        #region exec
        public void ExecuteInsert<TEntity>(InsertQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            where TEntity : class, IDbEntity
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            OnBeforeStart(expression);

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for insert query.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? DbExpressionQueryException.ThrowNullValueUnexpectedWithReturn<SqlStatement>(expression);

            OnAfterAssembly(expression, statementBuilder, statement);

            var fields = new List<FieldExpression?> { null }.Concat(expression.Outputs).ToList();

            ISqlConnection local = connection ?? new SqlConnector(connectionFactory);
            ISqlRowReader? reader = null;
            try
            {
                reader = statementExecutor.ExecuteQuery(
                    statement,
                    local,
                    new SqlStatementValueConverterProvider(valueConverterFactory, fields),
                    cmd => {
                        OnBeforeCommand(expression, cmd, statement);
                        configureCommand?.Invoke(cmd);
                    },
                    cmd => OnAfterCommand(expression, cmd)
                );

                var mapper = mapperFactory.CreateEntityMapper(expression.Into as Table<TEntity> ?? DbExpressionQueryException.ThrowWrongTypeWithReturn<Table<TEntity>>(expression, expression.Into?.GetType()));

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
                        DbExpressionQueryException.ThrowInsertExpectedIntegerAsFirstField(expression, e);
                    }
                    var entity = (expression.Inserts.Single(x => x.Key == Convert.ToInt32(index!)).Value.Entity as TEntity)!;
                    try
                    {
                        mapper.Map(row, entity);
                    }
                    catch(Exception e)
                    {
                        DbExpressionMappingException.ThrowDataMappingFailed<TEntity>(expression, e);
                    }
                }
            }
            finally
            {
                reader?.Dispose();
                if (connection is null) //was not provided
                    local.Dispose();
            }

            OnAfterComplete(expression);
        }

        public async Task ExecuteInsertAsync<TEntity>(InsertQueryExpression expression, ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            where TEntity : class, IDbEntity
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            await OnBeforeStartAsync(expression, ct).ConfigureAwait(false);

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for insert query.");
            var statement = statementBuilder.CreateSqlStatement(expression) ?? DbExpressionQueryException.ThrowNullValueUnexpectedWithReturn<SqlStatement>(expression);

            await OnAfterAssemblyAsync(expression, statementBuilder, statement, ct).ConfigureAwait(false);

            ISqlConnection local = connection ?? new SqlConnector(connectionFactory);
            IAsyncSqlRowReader? reader = null;
            try
            {
                reader = await statementExecutor.ExecuteQueryAsync(
                    statement,
                    local,
                    new SqlStatementValueConverterProvider(valueConverterFactory, new List<FieldExpression?> { null }.Concat(expression.Outputs).ToList()),
                    async cmd =>
                    {
                        await OnBeforeCommandAsync(expression, cmd, statement, ct).ConfigureAwait(false);
                        
                        if (!ct.IsCancellationRequested)
                            configureCommand?.Invoke(cmd);
                    },
                    async cmd => await OnAfterCommandAsync(expression, cmd, ct).ConfigureAwait(false),
                    ct
                ).ConfigureAwait(false);

                ct.ThrowIfCancellationRequested();

                var mapper = mapperFactory.CreateEntityMapper(expression.Into as Table<TEntity> ?? DbExpressionQueryException.ThrowWrongTypeWithReturn<Table<TEntity>>(expression, expression.Into?.GetType()));

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
                        DbExpressionQueryException.ThrowInsertExpectedIntegerAsFirstField(expression, e);
                    }
                    var entity = expression.Inserts.Single(x => x.Key == Convert.ToInt32(index!)).Value.Entity;
                    mapper.Map(row, entity as TEntity ?? DbExpressionQueryException.ThrowWrongTypeWithReturn<TEntity>(expression, entity.GetType()));
                }
            }
            finally
            {
                reader?.Dispose();
                if (connection is null) //was not provided
                    local.Dispose();
            }

            await OnAfterCompleteAsync(expression, ct).ConfigureAwait(false);
        }

        #region events
        #region sync
        private void OnBeforeStart(InsertQueryExpression expression)
        {
            try
            {
                if (events.OnBeforeStart is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before start events for insert query.");
                    events.OnBeforeStart.Invoke(new Lazy<BeforeStartPipelineEventContext>(() => new BeforeStartPipelineEventContext(expression, statementBuilder.Parameters)));
                }
                if (events.OnBeforeInsertStart is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before insert start events for insert query.");
                    for (var i = expression.Inserts.Count() - 1; i >= 0; i--)
                        events.OnBeforeInsertStart?.Invoke(new Lazy<BeforeInsertStartPipelineEventContext>(() => new BeforeInsertStartPipelineEventContext(expression, statementBuilder.Parameters, expression.Inserts[i].Entity)));
                }
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnBeforeStart), "INSERT", e);
            }
        }

        private void OnAfterAssembly(InsertQueryExpression expression, ISqlStatementBuilder statementBuilder, SqlStatement statement)
        {
            try
            {
                if (events.OnAfterInsertAssembly is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after insert assembly events for insert query.");
                    for (var i = expression.Inserts.Count() - 1; i >= 0; i--)
                        events.OnAfterInsertAssembly.Invoke(new Lazy<AfterInsertAssemblyPipelineEventContext>(() => new AfterInsertAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement, expression.Inserts[i].Entity)));
                }
                if (events.OnAfterAssembly is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after assembly events for insert query.");
                    events.OnAfterAssembly?.Invoke(new Lazy<AfterAssemblyPipelineEventContext>(() => new AfterAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement)));
                }
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterAssembly), "INSERT", e);
            }
        }

        private void OnBeforeCommand(InsertQueryExpression expression, IDbCommand command, SqlStatement statement)
        {
            try
            {
                if (events.OnBeforeCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before command events for insert query.");
                    events.OnBeforeCommand?.Invoke(new Lazy<BeforeCommandPipelineEventContext>(() => new BeforeCommandPipelineEventContext(expression, command, statement)));
                }
                if (events.OnBeforeInsertCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before insert command events for insert query.");
                    for (var i = expression.Inserts.Count() - 1; i >= 0; i--)
                        events.OnBeforeInsertCommand?.Invoke(new Lazy<BeforeInsertCommandPipelineEventContext>(() => new BeforeInsertCommandPipelineEventContext(expression, command, statement, expression.Inserts[i].Entity)));
                }
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnBeforeCommand), "INSERT", e);
            }
        }

        private void OnAfterCommand(InsertQueryExpression expression, IDbCommand command)
        {
            try
            {
                if (events.OnAfterInsertCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after insert command events for insert query.");
                    for (var i = expression.Inserts.Count() - 1; i >= 0; i--)
                        events.OnAfterInsertCommand?.Invoke(new Lazy<AfterInsertCommandPipelineEventContext>(() => new AfterInsertCommandPipelineEventContext(expression, command, expression.Inserts[i].Entity)));
                }
                if (events.OnAfterCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after command events for insert query.");
                    events.OnAfterCommand?.Invoke(new Lazy<AfterCommandPipelineEventContext>(() => new AfterCommandPipelineEventContext(expression, command)));
                }
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterCommand), "INSERT", e);
            }
        }

        private void OnAfterComplete(InsertQueryExpression expression)
        {
            try
            {
                if (events.OnAfterInsertComplete is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after insert command events for each entity in the insert query.");
                    for (var i = expression.Inserts.Count() - 1; i >= 0; i--)
                        events.OnAfterInsertComplete?.Invoke(new Lazy<AfterInsertCompletePipelineEventContext>(() => new AfterInsertCompletePipelineEventContext(expression, expression.Inserts[i].Entity)));
                }
                if (events.OnAfterComplete is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after complete events for insert query.");
                    events.OnAfterComplete?.Invoke(new Lazy<AfterCompletePipelineEventContext>(() => new AfterCompletePipelineEventContext(expression)));
                }
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterComplete), "INSERT", e);
            }
        }
        #endregion

        #region async
        private async Task OnBeforeStartAsync(InsertQueryExpression expression, CancellationToken ct)
        {
            try
            {
                if (events.OnBeforeStart is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before start events for insert query.");
                    await events.OnBeforeStart.InvokeAsync(new Lazy<BeforeStartPipelineEventContext>(() => new BeforeStartPipelineEventContext(expression, statementBuilder.Parameters)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
                if (events.OnBeforeInsertStart is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before insert start events for insert query.");

                    for (var i = expression.Inserts.Count() - 1; i >= 0; i--)
                    {
                        await events.OnBeforeInsertStart.InvokeAsync(new Lazy<BeforeInsertStartPipelineEventContext>(() => new BeforeInsertStartPipelineEventContext(expression, statementBuilder.Parameters, expression.Inserts[i].Entity)), ct).ConfigureAwait(false);
                        ct.ThrowIfCancellationRequested();
                    }
                    ct.ThrowIfCancellationRequested();
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnBeforeStartAsync), "INSERT", e);
            }
        }

        private async Task OnAfterAssemblyAsync(InsertQueryExpression expression, ISqlStatementBuilder statementBuilder, SqlStatement statement, CancellationToken ct)
        {
            try
            {
                if (events.OnAfterInsertAssembly is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after insert assembly events for insert query.");
                    for (var i = expression.Inserts.Count() - 1; i >= 0; i--)
                    {
                        await events.OnAfterInsertAssembly.InvokeAsync(new Lazy<AfterInsertAssemblyPipelineEventContext>(() => new AfterInsertAssemblyPipelineEventContext(expression, statementBuilder.Parameters, statement, expression.Inserts[i].Entity)), ct).ConfigureAwait(false);
                        ct.ThrowIfCancellationRequested();
                    }
                    ct.ThrowIfCancellationRequested();
                }
                if (events.OnAfterAssembly is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after assembly events for insert query.");
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
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterAssemblyAsync), "INSERT", e);
            }
        }

        private async Task OnBeforeCommandAsync(InsertQueryExpression expression, IDbCommand command, SqlStatement statement, CancellationToken ct)
        {
            try
            {
                if (events.OnBeforeCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before command events for insert query.");
                    await events.OnBeforeCommand.InvokeAsync(new Lazy<BeforeCommandPipelineEventContext>(() => new BeforeCommandPipelineEventContext(expression, command, statement)), ct).ConfigureAwait(false);
                    ct.ThrowIfCancellationRequested();
                }
                if (events.OnBeforeInsertCommand is not null && !ct.IsCancellationRequested)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking before insert command events for insert query.");
                    for (var i = expression.Inserts.Count() - 1; i >= 0; i--)
                    {
                        await events.OnBeforeInsertCommand.InvokeAsync(new Lazy<BeforeInsertCommandPipelineEventContext>(() => new BeforeInsertCommandPipelineEventContext(expression, command, statement, expression.Inserts[i].Entity)), ct).ConfigureAwait(false);
                    }
                    ct.ThrowIfCancellationRequested();
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnBeforeCommandAsync), "INSERT", e);
            }
        }

        private async Task OnAfterCommandAsync(InsertQueryExpression expression, IDbCommand command, CancellationToken ct)
        {
            try
            {
                if (events.OnAfterInsertCommand is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after insert command events for insert query.");
                    for (var i = expression.Inserts.Count() - 1; i >= 0; i--)
                    {
                        await events.OnAfterInsertCommand.InvokeAsync(new Lazy<AfterInsertCommandPipelineEventContext>(() => new AfterInsertCommandPipelineEventContext(expression, command, expression.Inserts[i].Entity)), ct).ConfigureAwait(false);
                    }
                }
                if (events.OnAfterCommand is not null && !ct.IsCancellationRequested)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after command events for insert query.");
                    await events.OnAfterCommand.InvokeAsync(new Lazy<AfterCommandPipelineEventContext>(() => new AfterCommandPipelineEventContext(expression, command)), ct).ConfigureAwait(false);
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterCommandAsync), "INSERT", e);
            }
        }

        private async Task OnAfterCompleteAsync(InsertQueryExpression expression, CancellationToken ct)
        {
            try
            {
                if (events.OnAfterInsertComplete is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after insert complete events for insert query.");
                    for (var i = expression.Inserts.Count() - 1; i >= 0; i--)
                    {
                        await events.OnAfterInsertComplete.InvokeAsync(new Lazy<AfterInsertCompletePipelineEventContext>(() => new AfterInsertCompletePipelineEventContext(expression, expression.Inserts[i].Entity)), ct).ConfigureAwait(false);
                        ct.ThrowIfCancellationRequested();
                    }
                    ct.ThrowIfCancellationRequested();
                }
                if (events.OnAfterComplete is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Invoking after complete events for insert query.");
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
                DbExpressionPipelineEventException.ThrowPipelineEventFailed(expression, nameof(OnAfterCompleteAsync), "INSERT", e);
            }
        }
        #endregion
        #endregion
        #endregion
        #endregion
    }
}
