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
    public class SyncExecutionPipeline
    {
        private DbExpressionConfiguration _config;
        private DatabaseConfiguration _database;

        private SyncPipeline<BeforeAssemblyContext> _beforeAssembly { get; set; }
        private SyncPipeline<AfterAssemblyContext> _afterAssembly { get; set; }
        private SyncPipeline<BeforeInsertContext> _beforeInsert { get; set; }
        private SyncPipeline<AfterInsertContext> _afterInsert { get; set; }

        public SyncExecutionPipeline(
            DbExpressionConfiguration config,
            DatabaseConfiguration database,
            SyncPipeline<BeforeAssemblyContext> beforeAssembly,
            SyncPipeline<AfterAssemblyContext> afterAssembly,
            SyncPipeline<BeforeInsertContext> beforeInsert,
            SyncPipeline<AfterInsertContext> afterInsert
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
        public void Execute(ITerminationExpressionBuilder builder)
            => Execute(builder, null);

        public void Execute(ITerminationExpressionBuilder builder, SqlConnection connection)
        {
            Execute(
                builder,
                connection,
                _database.MapperFactory.CreateValueMapper<int>(),
                (Func<ISqlRowReader, IValueMapper<int>, int>)null
            );

        }
        #endregion

        #region ValueTerminationExpressionBuilder
        public T Execute<T>(IValueTerminationExpressionBuilder<T> builder)
            => Execute(builder, null);

        public T Execute<T>(IValueTerminationExpressionBuilder<T> builder, SqlConnection connection)
        {
            return Execute(
                builder,
                connection,
                _database.MapperFactory.CreateValueMapper<T>(),
                (reader, mapper) =>
                {
                    var field = reader.ReadRow()?.ReadField();
                    if (field == null)
                        return default;

                    return mapper.Map(field.Value);
                });
        }
        #endregion

        #region ValueListTerminationExpressionBuilder
        public IList<T> Execute<T>(IValueListTerminationExpressionBuilder<T> builder)
            => Execute(builder, null);

        public IList<T> Execute<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection)
        {
            return Execute(
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
                }
            );
        }
        #endregion

        #region ValueTerminationExpressionBuilder
        public dynamic Execute(IValueTerminationExpressionBuilder<ExpandoObject> builder)
            => Execute(builder, null);

        public dynamic Execute(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
        {
            return Execute(
                builder,
                connection,
                _database.MapperFactory.CreateExpandoObjectMapper(),
                (reader, mapper) =>
                {
                    var value = new ExpandoObject();

                    var row = reader.ReadRow();
                    if (row == null)
                        return value;

                    mapper.Map(value, row);

                    return (dynamic)value;
                }
            );
        }
        #endregion

        #region ValueListTerminationExpressionBuilder
        public IList<dynamic> Execute(IValueListTerminationExpressionBuilder<ExpandoObject> builder)
            => Execute(builder, null);

        public IList<dynamic> Execute(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
        {
            return Execute(
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
                }
            );
        }
        #endregion

        #region TypeTerminationExpressionBuilder
        public T Execute<T>(ITypeTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => Execute(builder, null);

        public T Execute<T>(ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
        {
            return Execute(
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
                }
            );
        }
        #endregion

        #region TypeListTerminationExpressionBuilder
        public IList<T> Execute<T>(ITypeListTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => Execute(builder, null);

        public IList<T> Execute<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
        {
            return Execute(
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
                }
            );
        }
        #endregion

        private T Execute<T, TMapper>(
            ITerminationExpressionBuilder builder,
            SqlConnection connection,
            TMapper mapper,
            Func<ISqlRowReader, TMapper, T> transform
        )
        where TMapper : class, IMapper
        {

            var expression = (builder as IDbExpressionSetProvider).Expression;

            var executionContext = new ExecutionPipelineContext(_config, _database, expression, connection);

            //assembly
            _beforeAssembly.Invoke(new Lazy<BeforeAssemblyContext>(() => new BeforeAssemblyContext(expression)));

            var appender = _database.AppenderFactory.CreateAppender(_database.AssemblerConfiguration);
            var parameterBuilder = _database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var statementBuilder = _database.StatementBuilderFactory.CreateSqlStatementBuilder(_database.AssemblerConfiguration, expression, appender, parameterBuilder);

            _afterAssembly.Invoke(new Lazy<AfterAssemblyContext>(() => new AfterAssemblyContext(expression, statementBuilder)));

            var statement = statementBuilder.CreateSqlStatement();

            switch (expression.StatementExecutionType)
            {
                case SqlStatementExecutionType.Insert:
                    _beforeInsert.Invoke(new Lazy<BeforeInsertContext>(() => new BeforeInsertContext(expression, appender, parameterBuilder)));
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
                        _afterInsert.Invoke(new Lazy<AfterInsertContext>(() => new AfterInsertContext(expression, parameterBuilder, _database.MapperFactory)));
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
