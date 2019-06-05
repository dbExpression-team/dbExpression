using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class SyncExecutionPipeline : ExecutionPipeline
    {
        private SyncPipeline<BeforeAssemblyContext> BeforeAssembly { get; set; }
        private SyncPipeline<AfterAssemblyContext> AfterAssembly { get; set; }
        private SyncPipeline<BeforeInsertContext> BeforeInsert { get; set; }
        private SyncPipeline<AfterInsertContext> AfterInsert { get; set; }

        public SyncExecutionPipeline(
            DbExpressionConfiguration config,
            DatabaseConfiguration database,
            SyncPipeline<BeforeAssemblyContext> beforeAssembly,
            SyncPipeline<AfterAssemblyContext> afterAssembly,
            SyncPipeline<BeforeInsertContext> beforeInsert,
            SyncPipeline<AfterInsertContext> afterInsert
        ) : base(config, database)
        {
            BeforeAssembly = beforeAssembly;
            AfterAssembly = afterAssembly;
            BeforeInsert = beforeInsert;
            AfterInsert = afterInsert;
        }

        #region TerminationExpressionBuilder
        public void Execute(ITerminationExpressionBuilder builder)
            => Execute(builder, (SqlConnection)null, _ => { });

        public void Execute(ITerminationExpressionBuilder builder, Action<DbCommand> configureCommand)
            => Execute(builder, (SqlConnection)null, configureCommand);

        public void Execute(ITerminationExpressionBuilder builder, SqlConnection connection)
            => Execute(builder, connection, _ => { });

        public void Execute(ITerminationExpressionBuilder builder, int commandTimeout)
            => Execute(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout);

        public void Execute(ITerminationExpressionBuilder builder, SqlConnection connection, int commandTimeout)
            => Execute(builder, connection, c => c.CommandTimeout = commandTimeout);

        public void Execute(ITerminationExpressionBuilder builder, SqlConnection connection, Action<DbCommand> configureCommand)
            => Execute(builder, connection, configureCommand, (Func<ISqlRowReader, int>)null);
        #endregion

        #region ValueTerminationExpressionBuilder
        public T Execute<T>(IValueTerminationExpressionBuilder<T> builder)
            => Execute(builder, (SqlConnection)null, _ => { });

        public T Execute<T>(IValueTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand)
            => Execute(builder, (SqlConnection)null, configureCommand);

        public T Execute<T>(IValueTerminationExpressionBuilder<T> builder, SqlConnection connection)
            => Execute(builder, connection, _ => { });

        public T Execute<T>(IValueTerminationExpressionBuilder<T> builder, int commandTimeout)
            => Execute(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout);

        public T Execute<T>(IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            => Execute(builder, connection, c => c.CommandTimeout = commandTimeout);

        public T Execute<T>(IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand)
        {
            return Execute(
                builder,
                connection,
                configureCommand,
                reader =>
                {
                    var mapper = Database.MapperFactory.CreateValueMapper<T>();
                    var field = reader.ReadRow()?.ReadField();
                    if (field == null)
                        return default;

                    return mapper.Map(field.Value);
                });
        }
        #endregion

        #region ValueListTerminationExpressionBuilder
        public IList<T> Execute<T>(IValueListTerminationExpressionBuilder<T> builder)
            => Execute(builder, (SqlConnection)null, _ => { });

        public IList<T> Execute<T>(IValueListTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand)
            => Execute(builder, (SqlConnection)null, configureCommand);

        public IList<T> Execute<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            => Execute(builder, connection, _ => { });

        public IList<T> Execute<T>(IValueListTerminationExpressionBuilder<T> builder, int commandTimeout)
            => Execute(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout);

        public IList<T> Execute<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            => Execute(builder, connection, c => c.CommandTimeout = commandTimeout);

        public IList<T> Execute<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand)
        {
            return Execute(
                builder,
                connection,
                configureCommand,
                reader =>
                {
                    var mapper = Database.MapperFactory.CreateValueMapper<T>();
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
            => Execute(builder, (SqlConnection)null, _ => { });

        public dynamic Execute(IValueTerminationExpressionBuilder<ExpandoObject> builder, Action<DbCommand> configureCommand)
            => Execute(builder, (SqlConnection)null, configureCommand);

        public dynamic Execute(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
            => Execute(builder, connection, _ => { });

        public dynamic Execute(IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => Execute(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout);

        public dynamic Execute(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout)
            => Execute(builder, connection, c => c.CommandTimeout = commandTimeout);

        public dynamic Execute(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<DbCommand> configureCommand)
        {
            return Execute(
                builder,
                connection,
                configureCommand,
                reader =>
                {
                    var value = new ExpandoObject();

                    var row = reader.ReadRow();
                    if (row == null)
                        return value;

                    var mapper = Database.MapperFactory.CreateExpandoObjectMapper();
                    mapper.Map(value, row);

                    return (dynamic)value;
                }
            );
        }
        #endregion

        #region ValueListTerminationExpressionBuilder
        public IList<dynamic> Execute(IValueListTerminationExpressionBuilder<ExpandoObject> builder)
            => Execute(builder, (SqlConnection)null, _ => { });

        public IList<dynamic> Execute(IValueListTerminationExpressionBuilder<ExpandoObject> builder, Action<DbCommand> configureCommand)
            => Execute(builder, (SqlConnection)null, configureCommand);

        public IList<dynamic> Execute(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
            => Execute(builder, connection, _ => { });

        public IList<dynamic> Execute(IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => Execute(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout);

        public IList<dynamic> Execute(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout)
            => Execute(builder, connection, c => c.CommandTimeout = commandTimeout);

        public IList<dynamic> Execute(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<DbCommand> configureCommand)
        {
            return Execute(
                builder,
                connection,
                configureCommand,
                reader =>
                {
                    var mapper = Database.MapperFactory.CreateExpandoObjectMapper();
                    var values = new List<dynamic>();

                    ISqlRow row = null;
                    while ((row = reader.ReadRow()) != null)
                    {
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
            => Execute(builder, (SqlConnection)null, _ => { });

        public T Execute<T>(ITypeTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => Execute(builder, (SqlConnection)null, configureCommand);

        public T Execute<T>(ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
            => Execute(builder, connection, _ => { });

        public T Execute<T>(ITypeTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => Execute(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout);

        public T Execute<T>(ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => Execute(builder, connection, c => c.CommandTimeout = commandTimeout);

        public T Execute<T>(ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
        {
            return Execute(
                builder,
                connection,
                configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    if (row == null)
                        return default;

                    var mapper = Database.MapperFactory.CreateEntityMapper((builder as IDbExpressionSetProvider).Expression.BaseEntity as EntityExpression<T>);
                    var valueMapper = Database.MapperFactory.CreateValueMapper();
                    var entity = Database.EntityFactory.CreateEntity<T>();

                    mapper.Map(entity, row, valueMapper);

                    return entity;
                }
            );
        }
        #endregion

        #region TypeListTerminationExpressionBuilder
        public IList<T> Execute<T>(ITypeListTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => Execute(builder, (SqlConnection)null, _ => { });

        public IList<T> Execute<T>(ITypeListTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => Execute(builder, (SqlConnection)null, configureCommand);

        public IList<T> Execute<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
            => Execute(builder, connection, _ => { });

        public IList<T> Execute<T>(ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => Execute(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout);

        public IList<T> Execute<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => Execute(builder, connection, c => c.CommandTimeout = commandTimeout);

        public IList<T> Execute<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
        {
            return Execute(
                builder,
                connection,
                configureCommand,
                reader =>
                {
                    var values = new List<T>();

                    ISqlRow row;
                    var mapper = Database.MapperFactory.CreateEntityMapper((builder as IDbExpressionSetProvider).Expression.BaseEntity as EntityExpression<T>);
                    var valueMapper = Database.MapperFactory.CreateValueMapper();
                    while ((row = reader.ReadRow()) != null)
                    {
                        var entity = Database.EntityFactory.CreateEntity<T>();
                        mapper.Map(entity, row, valueMapper);
                        values.Add(entity);
                    }

                    return values;
                }
            );
        }
        #endregion

        private T Execute<T>(
            ITerminationExpressionBuilder builder,
            SqlConnection connection,
            Action<DbCommand> configureCommand,
            Func<ISqlRowReader,T> transform
        )
        {
            var expression = (builder as IDbExpressionSetProvider).Expression;

            //assembly
            BeforeAssembly.Invoke(new Lazy<BeforeAssemblyContext>(() => new BeforeAssemblyContext(expression)));

            var appender = Database.AppenderFactory.CreateAppender(Database.AssemblerConfiguration.Minify);
            var parameterBuilder = Database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var statementBuilder = Database.StatementBuilderFactory.CreateSqlStatementBuilder(Database.AssemblerConfiguration, expression, appender, parameterBuilder);

            AfterAssembly.Invoke(new Lazy<AfterAssemblyContext>(() => new AfterAssemblyContext(expression, statementBuilder)));

            var statement = statementBuilder.CreateSqlStatement();

            switch (expression.StatementExecutionType)
            {
                case SqlStatementExecutionType.Insert:
                    BeforeInsert.Invoke(new Lazy<BeforeInsertContext>(() => new BeforeInsertContext(expression, appender, parameterBuilder)));
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

            var executor = Database.ExecutorFactory.CreateSqlStatementExecutor(expression);

            if (connection == null)
                connection = Database.ConnectionFactory.CreateSqlConnection(Config.ConnectionStringSettings[(expression.BaseEntity as IDbExpressionMetadataProvider<ISqlEntityMetadata>).Metadata.Schema.Database.ConnectionName]);

            if (transform == null)
            {
                executor.ExecuteNonQuery(statement, connection, configureCommand);

                switch (expression.StatementExecutionType)
                {
                    case SqlStatementExecutionType.Insert:
                        AfterInsert.Invoke(new Lazy<AfterInsertContext>(() => new AfterInsertContext(expression, parameterBuilder, Database.MapperFactory)));
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

            using (var reader = executor.ExecuteQuery(statement, connection, configureCommand))
            {
                //run post-execute pipeline, need switch on type to build up correct wrapper; i.e. (new AfterInsertExecutionContext(executionContext, statement)
                if (reader == null)
                    return default;
                return transform(reader);
            }
        }
    }
}
