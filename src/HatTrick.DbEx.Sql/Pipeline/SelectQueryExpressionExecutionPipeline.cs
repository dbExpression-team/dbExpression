using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class SelectQueryExpressionExecutionPipeline : ISelectQueryExpressionExecutionPipeline
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration database;
        private readonly PipelineEventHook<BeforeAssemblyPipelineExecutionContext> beforeAssembly;
        private readonly PipelineEventHook<AfterAssemblyPipelineExecutionContext> afterAssembly;
        private readonly PipelineEventHook<BeforeExecutionPipelineExecutionContext> beforeExecution;
        private readonly PipelineEventHook<AfterExecutionPipelineExecutionContext> afterExecution;
        private readonly PipelineEventHook<BeforeSelectPipelineExecutionContext> beforeSelect;
        private readonly PipelineEventHook<AfterSelectPipelineExecutionContext> afterSelect;
        #endregion

        #region constructors
        public SelectQueryExpressionExecutionPipeline(
            RuntimeSqlDatabaseConfiguration database,
            PipelineEventHook<BeforeAssemblyPipelineExecutionContext> beforeAssembly,
            PipelineEventHook<AfterAssemblyPipelineExecutionContext> afterAssembly,
            PipelineEventHook<BeforeExecutionPipelineExecutionContext> beforeExecution,
            PipelineEventHook<AfterExecutionPipelineExecutionContext> afterExecution,
            PipelineEventHook<BeforeSelectPipelineExecutionContext> beforeSelect,
            PipelineEventHook<AfterSelectPipelineExecutionContext> afterSelect
        )
        {
            this.database = database;
            this.beforeAssembly = beforeAssembly;
            this.afterAssembly = afterAssembly;
            this.beforeExecution = beforeExecution;
            this.afterExecution = afterExecution;
            this.beforeSelect = beforeSelect;
            this.afterSelect = afterSelect;
        }
        #endregion

        #region methods
        public T ExecuteSelectEntity<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand)
            where T : class, IDbEntity, new()
        {
            T entity = default;
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    if (row == default)
                        return;
                    else
                        reader.Close();

                    entity = database.EntityFactory.CreateEntity<T>();
                    var mapper = database.MapperFactory.CreateEntityMapper(expression.BaseEntity as EntityExpression<T>);
                    mapper.Map(entity, row);
                }
            );
            return entity;
        }

        public async Task<T> ExecuteSelectEntityAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            T value = default;
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    if (row == default)
                        return;
                    else
                        reader.Close();

                    value = database.EntityFactory.CreateEntity<T>();
                    var mapper = database.MapperFactory.CreateEntityMapper(expression.BaseEntity as EntityExpression<T>);
                    mapper.Map(value, row);
                },
                ct
            ).ConfigureAwait(false);
            return value;
        }

        public IList<T> ExecuteSelectEntityList<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand)
            where T : class, IDbEntity, new()
        {
            var values = new List<T>();
            var mapper = database.MapperFactory.CreateEntityMapper(expression.BaseEntity as EntityExpression<T>);
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    ISqlRow row;
                    while ((row = reader.ReadRow()) is object)
                    {
                        var entity = database.EntityFactory.CreateEntity<T>();
                        mapper.Map(entity, row);
                        values.Add(entity);
                    }
                }
            );
            return values;
        }

        public async Task<IList<T>> ExecuteSelectEntityListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            var values = new List<T>();
            var mapper = database.MapperFactory.CreateEntityMapper(expression.BaseEntity as EntityExpression<T>);
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlRow row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
                    {
                        var value = database.EntityFactory.CreateEntity<T>();
                        mapper.Map(value, row);
                        values.Add(value);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }

        public T ExecuteSelectValue<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand)
        {
            T value = default;
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    var field = reader.ReadRow()?.ReadField();
                    if (field is null)
                        return;
                    else
                        reader.Close();

                    value = field.GetValue<T>();
                }
            );
            return value;
        }

        public async Task<T> ExecuteSelectValueAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
        {
            T value = default;
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    if (row is null)
                        return;

                    var field = row.ReadField();
                    if (field is null)
                        return;
                    else
                        reader.Close();

                    value = field.GetValue<T>();
                },
                ct
            ).ConfigureAwait(false);
            return value;
        }

        public IList<T> ExecuteSelectValueList<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand)
        {
            var values = new List<T>();
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    ISqlRow row;
                    while ((row = reader.ReadRow()) is object)
                    {
                        var field = row.ReadField();
                        if (field is null)
                            return;

                        values.Add(field.GetValue<T>());
                    }
                }
            );
            return values;
        }

        public async Task<IList<T>> ExecuteSelectValueListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
        {
            var values = new List<T>();
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlRow row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
                    {
                        var field = row.ReadField();
                        if (field is null)
                            return;

                        values.Add(field.GetValue<T>());
                    }
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }

        public dynamic ExecuteSelectDynamic(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand)
        {
            dynamic value = default;
            var converters = new SqlStatementValueConverterResolver(expression.Select, database.ValueConverterFactory);
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    if (row == default)
                        return;
                    else
                        reader.Close();

                    value = new ExpandoObject();
                    var mapper = database.MapperFactory.CreateExpandoObjectMapper();
                    mapper.Map(value, row, converters);
                }
            );
            return value;
        }

        public async Task<dynamic> ExecuteSelectDynamicAsync(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
        {
            dynamic value = default;
            var converters = new SqlStatementValueConverterResolver(expression.Select, database.ValueConverterFactory);
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    if (row == default)
                        return;
                    else
                        reader.Close();

                    value = new ExpandoObject();
                    var mapper = database.MapperFactory.CreateExpandoObjectMapper();
                    mapper.Map(value, row, converters);
                },
                ct
            ).ConfigureAwait(false);
            return value;
        }

        public IList<dynamic> ExecuteSelectDynamicList(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand)
        {
            var values = new List<dynamic>();
            var mapper = database.MapperFactory.CreateExpandoObjectMapper();
            var converters = new SqlStatementValueConverterResolver(expression.Select, database.ValueConverterFactory);
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    ISqlRow row;
                    while ((row = reader.ReadRow()) is object)
                    {
                        var value = new ExpandoObject();
                        mapper.Map(value, row, converters);
                        values.Add(value);
                    }
                }
            );
            return values;
        }

        public async Task<IList<dynamic>> ExecuteSelectDynamicListAsync(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
        {
            var values = new List<dynamic>();
            var mapper = database.MapperFactory.CreateExpandoObjectMapper();
            var converters = new SqlStatementValueConverterResolver(expression.Select, database.ValueConverterFactory);
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlRow row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
                    {
                        var value = new ExpandoObject();
                        mapper.Map(value, row, converters);
                        values.Add(value);
                    }
                },
                ct
            );
            return values;
        }

        public T ExecuteSelectObject<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlRow, T> map)
        {
            T value = default;
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    if (row is null)
                        return;
                    else
                        reader.Close();

                    try
                    {
                        value = map(row);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping value of data reader.", e);
                    }
                }
            );
            return value;
        }

        public async Task<T> ExecuteSelectObjectAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlRow, T> map, CancellationToken ct)
        {
            T value = default;
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync().ConfigureAwait(false);
                    if (row is null)
                        return;
                    else
                        reader.Close();

                    try
                    {
                        value = map(row);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping value of data reader.", e);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return value;
        }

        public IList<T> ExecuteSelectObjectList<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlRow, T> map)
        {
            var values = new List<T>();
            ExecuteSelectQuery(
                expression,
                connection,
                configureCommand,
                reader =>
                {
                    ISqlRow row;
                    while ((row = reader.ReadRow()) is object)
                    {
                        T value = default;
                        try
                        {
                            value = map(row);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error mapping value of data reader.", e);
                        }
                        values.Add(value);
                    }
                }
            );
            return values;
        }

        public async Task<IList<T>> ExecuteSelectObjectListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlRow, T> map, CancellationToken ct)
        {
            var values = new List<T>();
            await ExecuteSelectQueryAsync(
                expression,
                connection,
                configureCommand,
                async reader =>
                {
                    ISqlRow row;
                    while ((row = await reader.ReadRowAsync().ConfigureAwait(false)) is object)
                    {
                        T value = default;
                        try
                        {
                            value = map(row);
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error mapping value of data reader.", e);
                        }
                        values.Add(value);
                    }
                },
                ct
            ).ConfigureAwait(false);
            return values;
        }


        private void ExecuteSelectQuery(
            SelectQueryExpression expression,
            ISqlConnection connection,
            Action<IDbCommand> configureCommand,
            Action<ISqlRowReader> transform
        )
        {
            var appender = database.AppenderFactory.CreateAppender();
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.AssemblyPartAppenderFactory, database.AssemblerConfiguration, expression, appender, parameterBuilder);

            beforeAssembly?.Invoke(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(database, expression)));
            var statement = statementBuilder.CreateSqlStatement();
            afterAssembly?.Invoke(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(database, expression, statementBuilder)));

            var executor = database.ExecutorFactory.CreateSqlStatementExecutor(expression);

            beforeSelect?.Invoke(new Lazy<BeforeSelectPipelineExecutionContext>(() => new BeforeSelectPipelineExecutionContext(database, expression, appender, parameterBuilder)));

            var reader = executor.ExecuteQuery(
                statement, 
                connection,
                new SqlStatementValueConverterResolver(expression.Select, database.ValueConverterFactory),
                cmd => { 
                    beforeExecution?.Invoke(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, statement, cmd))); 
                    configureCommand?.Invoke(cmd); 
                },
                cmd => afterExecution?.Invoke(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(database, expression, statement, cmd)))
            );

            if (reader is null)
                return;

            transform(reader);

            afterSelect?.Invoke(new Lazy<AfterSelectPipelineExecutionContext>(() => new AfterSelectPipelineExecutionContext(database, expression, statement)));
        }

        private async Task ExecuteSelectQueryAsync(
            SelectQueryExpression expression,
            ISqlConnection connection,
            Action<IDbCommand> configureCommand,
            Func<IAsyncSqlRowReader, Task> transform,
            CancellationToken ct
        )
        {
            var appender = database.AppenderFactory.CreateAppender();
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.AssemblyPartAppenderFactory, database.AssemblerConfiguration, expression, appender, parameterBuilder);

            await beforeAssembly?.InvokeAsync(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(database, expression)), ct);
            var statement = statementBuilder.CreateSqlStatement();
            await afterAssembly?.InvokeAsync(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(database, expression, statementBuilder)), ct);

            var executor = database.ExecutorFactory.CreateSqlStatementExecutor(expression);

            var reader = await executor.ExecuteQueryAsync(
                statement,
                connection,
                new SqlStatementValueConverterResolver(expression.Select, database.ValueConverterFactory),
                async cmd => { 
                    await beforeExecution?.InvokeAsync(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, statementBuilder.CreateSqlStatement(), cmd)), ct); 
                    configureCommand?.Invoke(cmd); 
                },
                async cmd => {
                    if (afterExecution is object)
                    {
                        await afterExecution.InvokeAsync(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(database, expression, statement, cmd)), ct).ConfigureAwait(false);
                    }
                }, 
                ct
            ).ConfigureAwait(false);

            if (reader is null)
                return;

            await transform(reader).ConfigureAwait(false);

            if (afterSelect is object)
            {
                await afterSelect.InvokeAsync(new Lazy<AfterSelectPipelineExecutionContext>(() => new AfterSelectPipelineExecutionContext(database, expression, statement)), ct).ConfigureAwait(false);
            }
        }
    }
    #endregion
}
