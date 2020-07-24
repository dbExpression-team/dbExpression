using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AsyncExecutionPipeline : ExecutionPipeline
    {
        private AsyncPipeline<BeforeAssemblyPipelineExecutionContext> BeforeAssembly { get; set; }
        private AsyncPipeline<AfterAssemblyPipelineExecutionContext> AfterAssembly { get; set; }
        private AsyncPipeline<BeforeInsertPipelineExecutionContext> BeforeInsert { get; set; }
        private AsyncPipeline<AfterInsertPipelineExecutionContext> AfterInsert { get; set; }
        private AsyncPipeline<BeforeExecutionPipelineExecutionContext> BeforeExecution { get; set; }

        public AsyncExecutionPipeline(
            DatabaseConfiguration database,
            AsyncPipeline<BeforeAssemblyPipelineExecutionContext> beforeAssembly,
            AsyncPipeline<AfterAssemblyPipelineExecutionContext> afterAssembly,
            AsyncPipeline<BeforeInsertPipelineExecutionContext> beforeInsert,
            AsyncPipeline<AfterInsertPipelineExecutionContext> afterInsert,
            AsyncPipeline<BeforeExecutionPipelineExecutionContext> beforeExecution
        ) : base(database)
        {
            BeforeAssembly = beforeAssembly;
            AfterAssembly = afterAssembly;
            BeforeInsert = beforeInsert;
            AfterInsert = afterInsert;
            BeforeExecution = beforeExecution;
        }

        #region TerminationExpressionBuilder
        public async Task ExecuteVoidAsync(ITerminationExpressionBuilder builder, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            => await DoExecuteAsync(builder, connection, configureCommand, null, ct);
        #endregion

        #region ValueTerminationExpressionBuilder<T>
        public async Task<T> ExecuteValueAsync<T>(IValueTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
        {
            T value = default;
            var mapper = Database.MapperFactory.CreateValueMapper<T>();
            await DoExecuteAsync(builder, connection, configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync();
                    if (row == default)
                        return;

                    var field = row.ReadField();
                    if (field == default)
                        return;

                    value = mapper.Map(field.Value);
                }, ct
            );
            return value;
        }

        public async Task<T> ExecuteValueAsync<T>(IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Action<DbCommand> configureCommand, Func<ISqlField, T> map, CancellationToken ct)
        {
            T value = default;
            var mapper = Database.MapperFactory.CreateValueMapper<T>();
            await DoExecuteAsync(builder, connection, configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync();
                    if (row == default)
                        return;

                    var field = row.ReadField();
                    if (field == default)
                        return;

                    value = map(field);
                }, ct
            );
            return value;
        }
        #endregion

        #region ValueListTerminationExpressionBuilder<T>
        public async Task<IList<T>> ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
        {
            var mapper = Database.MapperFactory.CreateValueMapper<T>();
            var values = new List<T>();
            await DoExecuteAsync(builder, connection, configureCommand,
                async reader =>
                {
                    ISqlRow row;
                    while ((row = await reader.ReadRowAsync()) is object)
                    {
                        var field = row.ReadField();
                        if (field != null)
                        {
                            values.Add(mapper.Map(field.Value));
                        }
                    }
                }, ct
            );
            return values;
        }

        public async Task<IList<T>> ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Action<DbCommand> configureCommand, Func<object, T> map, CancellationToken ct)
        {
            var mapper = Database.MapperFactory.CreateValueMapper<T>();
            var values = new List<T>();
            await DoExecuteAsync(builder, connection, configureCommand,
                async reader =>
                {
                    ISqlRow row;
                    while ((row = await reader.ReadRowAsync()) is object)
                    {
                        var field = row.ReadField();
                        if (field != null)
                        {
                            values.Add(map(field.Value));
                        }
                    }
                }, ct
            );
            return values;
        }
        #endregion

        #region ValueTerminationExpressionBuilder<ExpandoObject>
        public async Task<dynamic> ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
        {
            dynamic value = default;
            var mapper = Database.MapperFactory.CreateExpandoObjectMapper();
            await DoExecuteAsync(builder, connection, configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync();
                    if (row == default)
                        return;

                    value = new ExpandoObject();
                    mapper.Map(value, row);
                }, ct
            );
            return value;
        }

        public async Task<T> ExecuteDynamicAsync<T>(IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Action<DbCommand> configureCommand, Func<ISqlRow, T> map, CancellationToken ct)
        {
            T value = default;
            await DoExecuteAsync(builder, connection, configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync();
                    if (row == default)
                        return;

                    try
                    {
                        value = map(row);
                    }
                    catch (Exception e)
                    {
                        throw new DbExpressionException($"Error mapping value of data reader.", e);
                    }
                }, ct
            );
            return value;
        }
        #endregion

        #region ValueListTerminationExpressionBuilder<ExpandoObject>
        public async Task<IList<dynamic>> ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
        {
            var mapper = Database.MapperFactory.CreateExpandoObjectMapper();
            var values = new List<dynamic>();
            await DoExecuteAsync(builder, connection, configureCommand,
                async reader =>
                {
                    ISqlRow row;
                    while ((row = await reader.ReadRowAsync()) is object)
                    {
                        dynamic value = new ExpandoObject();
                        mapper.Map(value, row);
                        values.Add(value);
                    }
                }, ct
            );
            return values;
        }

        public async Task<IList<T>> ExecuteDynamicListAsync<T>(IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Action<DbCommand> configureCommand, Func<ISqlRow, T> map, CancellationToken ct)
        {
            var values = new List<T>();
            await DoExecuteAsync(builder, connection, configureCommand,
                async reader =>
                {
                    ISqlRow row;
                    while ((row = await reader.ReadRowAsync()) is object)
                    {
                        try
                        {
                            values.Add(map(row));
                        }
                        catch (Exception e)
                        {
                            throw new DbExpressionException($"Error mapping value in row {row.Index} of data reader.", e);
                        }
                    }
                }, ct
            ); 
            return values;
        }
        #endregion

        #region TypeTerminationExpressionBuilder<T>
        public async Task<T> ExecuteTypeAsync<T>(ITypeTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            T value = default;
            var mapper = Database.MapperFactory.CreateEntityMapper((builder as IDbExpressionSetProvider).Expression.BaseEntity as EntityExpression<T>);
            var valueMapper = Database.MapperFactory.CreateValueMapper();
            await DoExecuteAsync(builder, connection, configureCommand,
                async reader =>
                {
                    var row = await reader.ReadRowAsync();
                    if (row == default)
                        return;

                    value = Database.EntityFactory.CreateEntity<T>();
                    mapper.Map(value, row, valueMapper);
                }, ct
            );
            return value;
        }
        #endregion

        #region TypeListTerminationExpressionBuilder<T>
        public async Task<IList<T>> ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            var mapper = Database.MapperFactory.CreateEntityMapper((builder as IDbExpressionSetProvider).Expression.BaseEntity as EntityExpression<T>);
            var valueMapper = Database.MapperFactory.CreateValueMapper();
            var values = new List<T>();
            await DoExecuteAsync(builder, connection, configureCommand,
                async reader =>
                {
                    ISqlRow row;
                    while ((row = await reader.ReadRowAsync()) is object)
                    {
                        var entity = Database.EntityFactory.CreateEntity<T>();
                        mapper.Map(entity, row, valueMapper);
                        values.Add(entity);
                    }
                }, ct
            );
            return values;
        }

        public async Task<IList<T>> ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand, Func<ISqlRow, T> map, CancellationToken ct)
        {
            var values = new List<T>();
            await DoExecuteAsync(builder, connection, configureCommand,
                async reader =>
                {
                    ISqlRow row;
                    while ((row = await reader.ReadRowAsync()) is object)
                    {
                        values.Add(map(row));
                    }
                }, ct
            );
            return values;
        }
        #endregion

        private async Task DoExecuteAsync(
            ITerminationExpressionBuilder builder,
            ISqlConnection connection,
            Action<DbCommand> configureCommand,
            Func<IAsyncSqlRowReader, Task> transform,
            CancellationToken ct
        )
        {
            if (ct == null)
                throw new ArgumentNullException("Cancellation token cannot be null");

            ct.ThrowIfCancellationRequested();

            var expression = (builder as IDbExpressionSetProvider).Expression;

            //assembly
            await BeforeAssembly.InvokeAsync(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(expression)), ct).ConfigureAwait(false);

            var appender = Database.AppenderFactory.CreateAppender();
            var parameterBuilder = Database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var statementBuilder = Database.StatementBuilderFactory.CreateSqlStatementBuilder(Database.AssemblerConfiguration, expression, appender, parameterBuilder);

            await AfterAssembly.InvokeAsync(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(expression, statementBuilder)), ct).ConfigureAwait(false);

            var statement = statementBuilder.CreateSqlStatement();

            //switch (expression.StatementExecutionType)
            //{
            //    case SqlStatementExecutionType.Insert:
            //        await BeforeInsert.InvokeAsync(new Lazy<BeforeInsertPipelineExecutionContext>(() => new BeforeInsertPipelineExecutionContext(expression, appender, parameterBuilder)), ct).ConfigureAwait(false);
            //        break;
            //    case SqlStatementExecutionType.Update:
            //    case SqlStatementExecutionType.Delete:
            //    case SqlStatementExecutionType.SelectOneValue:
            //    case SqlStatementExecutionType.SelectOneType:
            //    case SqlStatementExecutionType.SelectOneDynamic:
            //    case SqlStatementExecutionType.SelectManyValue:
            //    case SqlStatementExecutionType.SelectManyType:
            //    case SqlStatementExecutionType.SelectManyDynamic:
            //        break;
            //    default: throw new NotImplementedException($"'{expression.StatementExecutionType}' statement execution type has not been implemented.");
            //}

            var executor = Database.ExecutorFactory.CreateSqlStatementExecutor(expression);

            if (connection is null)
                connection = CreateConnection(expression);

            //if (transform is null)
            //{
            //    await executor.ExecuteNonQueryAsync(statement, connection, configureCommand, cmd => BeforeExecution?.InvokeAsync(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(expression, statement, cmd)), ct), ct);

            //    switch (expression.StatementExecutionType)
            //    {
            //        case SqlStatementExecutionType.Insert:
            //            await AfterInsert.InvokeAsync(new Lazy<AfterInsertPipelineExecutionContext>(() => new AfterInsertPipelineExecutionContext(expression, parameterBuilder, Database.MapperFactory)), ct).ConfigureAwait(false);
            //            break;
            //        case SqlStatementExecutionType.Update:
            //        case SqlStatementExecutionType.Delete:
            //        case SqlStatementExecutionType.SelectOneValue:
            //        case SqlStatementExecutionType.SelectOneType:
            //        case SqlStatementExecutionType.SelectOneDynamic:
            //        case SqlStatementExecutionType.SelectManyValue:
            //        case SqlStatementExecutionType.SelectManyType:
            //        case SqlStatementExecutionType.SelectManyDynamic:
            //            break;
            //        default: throw new NotImplementedException($"'{expression.StatementExecutionType}' statement execution type has not been implemented.");
            //    }

            //    return;
            //}

            var reader = await executor.ExecuteQueryAsync(statement, connection, configureCommand, Database.MapperFactory.CreateValueMapper(), cmd => BeforeExecution?.InvokeAsync(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(expression, statement, cmd)), ct), ct);
            //run post-execute pipeline, need switch on type to build up correct wrapper; i.e. (new AfterInsertExecutionContext(executionContext, statement)
            if (reader is null)
                return;
            await transform(reader);
        }
    }
}
