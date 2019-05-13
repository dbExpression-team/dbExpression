using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Mapper;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AsyncExecutionPipeline
    {
        private DbExpressionConfiguration _config;
        private DatabaseConfiguration _database;
        private AsyncPipeline<BeforeAssemblyContext> _beforeAssembly { get; set; }
        private AsyncPipeline<AfterAssemblyContext> _afterAssembly { get; set; }
        private AsyncPipeline<BeforeInsertContext> _beforeInsert { get; set; }
        private AsyncPipeline<AfterInsertContext> _afterInsert { get; set; }

        public AsyncExecutionPipeline(
            DbExpressionConfiguration config,
            DatabaseConfiguration database,
            AsyncPipeline<BeforeAssemblyContext> beforeAssembly,
            AsyncPipeline<AfterAssemblyContext> afterAssembly,
            AsyncPipeline<BeforeInsertContext> beforeInsert,
            AsyncPipeline<AfterInsertContext> afterInsert
        )
        {
            _config = config;
            _database = database;
            _beforeAssembly = beforeAssembly;
            _afterAssembly = afterAssembly;
            _beforeInsert = beforeInsert;
            _afterInsert = afterInsert;
        }

        #region TerminationExpressionBuilder
        public async Task ExecuteAsync(ITerminationExpressionBuilder builder)
            => await ExecuteAsync(builder, null, new CancellationToken()).ConfigureAwait(false);

        public async Task ExecuteAsync(ITerminationExpressionBuilder builder, CancellationToken ct)
            => await ExecuteAsync(builder, null, ct).ConfigureAwait(false);

        public async Task ExecuteAsync(ITerminationExpressionBuilder builder, SqlConnection connection)
            => await ExecuteAsync(builder, connection, new CancellationToken()).ConfigureAwait(false);

        public async Task ExecuteAsync(ITerminationExpressionBuilder builder, SqlConnection connection, CancellationToken ct)
        {
            await ExecuteAsync(
                builder,
                connection,
                _database.MapperFactory.CreateValueMapper<int>(),
                (Func<ISqlRowReader, IValueMapper<int>, int>)null,
                ct
            ).ConfigureAwait(false);
            
        }
        #endregion

        #region ValueTerminationExpressionBuilder
        public async Task<T> ExecuteAsync<T>(IValueTerminationExpressionBuilder<T> builder)
            => await ExecuteAsync(builder, null, new CancellationToken()).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(IValueTerminationExpressionBuilder<T> builder, CancellationToken ct)
            => await ExecuteAsync(builder, null, ct).ConfigureAwait(false);

       public async Task<T> ExecuteAsync<T>(IValueTerminationExpressionBuilder<T> builder, SqlConnection connection)
            => await ExecuteAsync(builder, connection, new CancellationToken()).ConfigureAwait(false);

         public async Task<T> ExecuteAsync<T>(IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
        {
            return await ExecuteAsync(
                builder,
                connection,
                _database.MapperFactory.CreateValueMapper<T>(),
                (reader, mapper) =>
                {
                    var field = reader.ReadRow()?.ReadField();
                    if (field == null)
                        return default;

                    return mapper.Map(field.Value);
                },
                ct
            ).ConfigureAwait(false);
        }
        #endregion

        #region ValueListTerminationExpressionBuilder
        public async Task<IList<T>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<T> builder)
            => await ExecuteAsync(builder, new CancellationToken()).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<T> builder, CancellationToken ct)
            => await ExecuteAsync(builder, null, ct).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            => await ExecuteAsync(builder, connection, new CancellationToken()).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
        {
            return await ExecuteAsync(
                builder,
                connection,
                _database.MapperFactory.CreateValueMapper<T>(),
                (reader, mapper) =>
                {
                    var values = new List<T>();

                    ISqlRow row;
                    while ((row = reader.ReadRow()) != null)
                    {
                        var field = row.ReadField();
                        if (field != null)
                        {
                            values.Add(mapper.Map(field.Value));
                        }
                    }

                    return values;
                },
                ct
            ).ConfigureAwait(false);
        }
        #endregion

        #region ValueTerminationExpressionBuilder
        public async Task<dynamic> ExecuteAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, CancellationToken ct)
            => await ExecuteAsync(builder, null, ct).ConfigureAwait(false);

        public async Task<dynamic> ExecuteAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
            => await ExecuteAsync(builder, connection, new CancellationToken()).ConfigureAwait(false);

        public async Task<dynamic> ExecuteAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, CancellationToken ct)
        {
            return await ExecuteAsync(
                builder,
                connection,
                _database.MapperFactory.CreateExpandoObjectMapper(),
                (reader, mapper) =>
                {
                    var value = default(ExpandoObject);

                    var row = reader.ReadRow();
                    if (row == null)
                        return value;

                    mapper.Map(value, row);

                    return (dynamic)value;
                },
                ct
            ).ConfigureAwait(false);
        }
        #endregion

        #region ValueListTerminationExpressionBuilder
        public async Task<IList<dynamic>> ExecuteAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder)
            => await ExecuteAsync(builder, null, new CancellationToken()).ConfigureAwait(false);

        public async Task<IList<dynamic>> ExecuteAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, CancellationToken ct)
            => await ExecuteAsync(builder, null, ct).ConfigureAwait(false);

        public async Task<IList<dynamic>> ExecuteAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
            => await ExecuteAsync(builder, connection, new CancellationToken()).ConfigureAwait(false);

        public async Task<IList<dynamic>> ExecuteAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, CancellationToken ct)
        {
            return await ExecuteAsync(
                builder,
                connection,
                _database.MapperFactory.CreateExpandoObjectMapper(),
                (reader, mapper) =>
                {
                    var values = new List<dynamic>();

                    ISqlRow row = null;
                    while ((row = reader.ReadRow()) != null)
                    {
                        mapper = mapper ?? _database.MapperFactory.CreateExpandoObjectMapper();

                        var value = new ExpandoObject();
                        mapper.Map(value, row);
                        values.Add(value);
                    }

                    return values;
                },
                ct
            ).ConfigureAwait(false);
        }
        #endregion

        #region TypeTerminationExpressionBuilder
        public async Task<T> ExecuteAsync<T>(ITypeTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, null, new CancellationToken()).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(ITypeTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, null, ct).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, connection, new CancellationToken()).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            return await ExecuteAsync(
                builder,
                connection,
                _database.MapperFactory.CreateEntityMapper((builder as IDbExpressionSetProvider).Expression.BaseEntity as EntityExpression<T>),
                (reader, mapper) =>
                {
                    var row = reader.ReadRow();
                    if (row == null)
                        return default;

                    var valueMapper = _database.MapperFactory.CreateValueMapper();
                    var entity = _database.EntityFactory.CreateEntity<T>();

                    mapper.Map(entity, row, valueMapper);

                    return entity;
                },
                ct
            ).ConfigureAwait(false);
        }
        #endregion

        #region TypeListTerminationExpressionBuilder
        public async Task<IList<T>> ExecuteAsync<T>(ITypeListTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, null, new CancellationToken()).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, null, ct).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, connection, new CancellationToken()).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            return await ExecuteAsync(
                builder,
                connection,
                _database.MapperFactory.CreateEntityMapper((builder as IDbExpressionSetProvider).Expression.BaseEntity as EntityExpression<T>),
                (reader, mapper) =>
                {
                    var values = new List<T>();

                    ISqlRow row;
                    IValueMapper valueMapper = null;
                    while ((row = reader.ReadRow()) != null)
                    {
                        valueMapper = valueMapper ?? _database.MapperFactory.CreateValueMapper();

                        var entity = _database.EntityFactory.CreateEntity<T>();
                        mapper.Map(entity, row, valueMapper);
                        values.Add(entity);
                    }

                    return values;
                },
                ct
            ).ConfigureAwait(false);
        }
        #endregion

        private async Task<T> ExecuteAsync<T, TMapper>(
            ITerminationExpressionBuilder builder,
            SqlConnection connection,
            TMapper mapper,
            Func<ISqlRowReader, TMapper, T> transform,
            CancellationToken ct
        )
            where TMapper : class, IMapper
        {

            var expression = (builder as IDbExpressionSetProvider).Expression;

            var executionContext = new ExecutionPipelineContext(_config, _database, expression, connection);

            //assembly
            await _beforeAssembly.InvokeAsync(new Lazy<BeforeAssemblyContext>(() => new BeforeAssemblyContext(expression)), ct).ConfigureAwait(false);

            var appender = _database.AppenderFactory.CreateAppender(_database.AssemblerConfiguration);
            var parameterBuilder = _database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var statementBuilder = _database.StatementBuilderFactory.CreateSqlStatementBuilder(_database.AssemblerConfiguration, expression, appender, parameterBuilder);

            await _afterAssembly.InvokeAsync(new Lazy<AfterAssemblyContext>(() => new AfterAssemblyContext(expression, statementBuilder)), ct).ConfigureAwait(false);

            var statement = statementBuilder.CreateSqlStatement();

            switch (expression.StatementExecutionType)
            {
                case SqlStatementExecutionType.Insert:
                    await _beforeInsert.InvokeAsync(new Lazy<BeforeInsertContext>(() => new BeforeInsertContext(expression, appender, parameterBuilder)), ct).ConfigureAwait(false);
                    break;
                case SqlStatementExecutionType.Update:
                case SqlStatementExecutionType.Delete:
                case SqlStatementExecutionType.SelectOneValue:
                case SqlStatementExecutionType.SelectOneType:
                case SqlStatementExecutionType.SelectOneDynamic:
                case SqlStatementExecutionType.SelectManyValue:
                case SqlStatementExecutionType.SelectManyType:
                case SqlStatementExecutionType.SelectManyDynamic:
                    break;
                default: throw new NotImplementedException($"'{expression.StatementExecutionType}' statement execution type has not been implemented.");
            }

            if (transform == null)
            {
                executionContext.StatementExecutor.ExecuteNonQuery(statement, executionContext.Connection);

                switch (expression.StatementExecutionType)
                {
                    case SqlStatementExecutionType.Insert:
                        await _afterInsert.InvokeAsync(new Lazy<AfterInsertContext>(() => new AfterInsertContext(expression, parameterBuilder, _database.MapperFactory)), ct).ConfigureAwait(false);
                        break;
                    case SqlStatementExecutionType.Update:
                    case SqlStatementExecutionType.Delete:
                    case SqlStatementExecutionType.SelectOneValue:
                    case SqlStatementExecutionType.SelectOneType:
                    case SqlStatementExecutionType.SelectOneDynamic:
                    case SqlStatementExecutionType.SelectManyValue:
                    case SqlStatementExecutionType.SelectManyType:
                    case SqlStatementExecutionType.SelectManyDynamic:
                        break;
                    default: throw new NotImplementedException($"'{expression.StatementExecutionType}' statement execution type has not been implemented.");
                }

                return default;
            }

            using (var reader = executionContext.StatementExecutor.ExecuteQuery(statement, executionContext.Connection))
            {
                //run post-execute pipeline, need switch on type to build up correct wrapper; i.e. (new AfterInsertExecutionContext(executionContext, statement)
                if (reader == null)
                    return default;
                return transform(reader, mapper);
            }
        }
    }
}
