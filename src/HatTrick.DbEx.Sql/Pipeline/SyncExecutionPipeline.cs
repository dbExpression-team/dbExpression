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

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class SyncExecutionPipeline : ExecutionPipeline
    {
        private SyncPipeline<BeforeAssemblyPipelineExecutionContext> BeforeAssembly { get; set; }
        private SyncPipeline<AfterAssemblyPipelineExecutionContext> AfterAssembly { get; set; }
        private SyncPipeline<BeforeInsertPipelineExecutionContext> BeforeInsert { get; set; }
        private SyncPipeline<AfterInsertPipelineExecutionContext> AfterInsert { get; set; }
        private SyncPipeline<BeforeExecutionPipelineExecutionContext> BeforeExecution { get; set; }

        public SyncExecutionPipeline(
            DatabaseConfiguration database,
            SyncPipeline<BeforeAssemblyPipelineExecutionContext> beforeAssembly,
            SyncPipeline<AfterAssemblyPipelineExecutionContext> afterAssembly,
            SyncPipeline<BeforeInsertPipelineExecutionContext> beforeInsert,
            SyncPipeline<AfterInsertPipelineExecutionContext> afterInsert,
            SyncPipeline<BeforeExecutionPipelineExecutionContext> beforeExecution
        ) : base(database)
        {
            BeforeAssembly = beforeAssembly;
            AfterAssembly = afterAssembly;
            BeforeInsert = beforeInsert;
            AfterInsert = afterInsert;
            BeforeExecution = beforeExecution;
        }

        #region TerminationExpressionBuilder
        public void ExecuteVoid(ITerminationExpressionBuilder builder, ISqlConnection connection, Action<DbCommand> configureCommand)
            => DoExecute(builder, connection, configureCommand, null);
        #endregion

        #region ValueTerminationExpressionBuilder<T>
        public T ExecuteValue<T>(IValueTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand)
        {
            T value = default;
            var mapper = Database.MapperFactory.CreateValueMapper<T>();
            DoExecute(builder, connection, configureCommand,
                reader =>
                {
                    var field = reader.ReadRow()?.ReadField();
                    if (field is null)
                        return;

                    value = mapper.Map(field.Value);
                }
            );
            return value;
        }

        public T ExecuteValue<T>(IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Action<DbCommand> configureCommand, Func<ISqlField, T> map)
        {
            T value = default;
            DoExecute(builder, connection, configureCommand,
                reader =>
                {
                    var field = reader.ReadRow()?.ReadField();
                    if (field is null)
                        return;

                    value = map(field);
                }
            );
            return value;
        }
        #endregion

        #region ValueListTerminationExpressionBuilder<T>
        public IList<T> ExecuteValueList<T>(IValueListTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand)
        {
            var mapper = Database.MapperFactory.CreateValueMapper<T>();
            var values = new List<T>();
            DoExecute(builder, connection, configureCommand,
                reader =>
                {
                    ISqlRow row;
                    while ((row = reader.ReadRow()) is object)
                    {
                        var field = row.ReadField();
                        if (field is object)
                        {
                            values.Add(mapper.Map(field.Value));
                        }
                    }
                }
            );
            return values;
        }

        public IList<T> ExecuteValueList<T>(IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Action<DbCommand> configureCommand, Func<object, T> map)
        {
            var mapper = Database.MapperFactory.CreateValueMapper<T>();
            var values = new List<T>();
            DoExecute(builder, connection, configureCommand,
                reader =>
                {
                    ISqlRow row;
                    while ((row = reader.ReadRow()) is object)
                    {
                        var field = row.ReadField();
                        if (field is object)
                        {
                            values.Add(map(field.Value));
                        }
                    }
                }
            );
            return values;
        }
        #endregion

        #region ValueTerminationExpressionBuilder<ExpandoObject>
        public dynamic ExecuteDynamic(IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Action<DbCommand> configureCommand)
        {
            dynamic value = default;
            var mapper = Database.MapperFactory.CreateExpandoObjectMapper();
            DoExecute(builder, connection, configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    if (row == default)
                        return;

                    value = new ExpandoObject();
                    mapper.Map(value, row);
                }
            );
            return value;
        }

        public T ExecuteDynamic<T>(IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Action<DbCommand> configureCommand, Func<ISqlRow, T> map)
        {
            T value = default;
            DoExecute(builder, connection, configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
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
                }
            );
            return value;
        }
        #endregion

        #region ValueListTerminationExpressionBuilder<ExpandoObject>
        public IList<dynamic> ExecuteDynamicList(IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Action<DbCommand> configureCommand)
        {
            var mapper = Database.MapperFactory.CreateExpandoObjectMapper();
            var values = new List<dynamic>();
            DoExecute(builder, connection, configureCommand,
                reader =>
                {
                    ISqlRow row;
                    while ((row = reader.ReadRow()) is object)
                    {
                        dynamic value = new ExpandoObject();
                        mapper.Map(value, row);
                        values.Add(value);
                    }
                }
            );
            return values == default ? new List<dynamic>() : values;
        }

        public IList<T> ExecuteDynamicList<T>(IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Action<DbCommand> configureCommand, Func<ISqlRow, T> map)
        {
            var values = new List<T>();
            DoExecute(builder, connection, configureCommand,
                reader =>
                {
                    ISqlRow row;
                    while ((row = reader.ReadRow()) is object)
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
                }
            );
            return values;
        }
        #endregion

        #region TypeTerminationExpressionBuilder<T>
        public T ExecuteType<T>(ITypeTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
        {
            T value = default;
            var mapper = Database.MapperFactory.CreateEntityMapper((builder as IDbExpressionSetProvider).Expression.BaseEntity as EntityExpression<T>);
            var valueMapper = Database.MapperFactory.CreateValueMapper();
            DoExecute(builder, connection, configureCommand,
                reader =>
                {
                    var row = reader.ReadRow();
                    if (row == default)
                        return;

                    value = Database.EntityFactory.CreateEntity<T>();
                    mapper.Map(value, row, valueMapper);
                }
            );
            return value;
        }
        #endregion

        #region TypeListTerminationExpressionBuilder<T>
        public IList<T> ExecuteTypeList<T>(ITypeListTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
        {
            var mapper = Database.MapperFactory.CreateEntityMapper((builder as IDbExpressionSetProvider).Expression.BaseEntity as EntityExpression<T>);
            var valueMapper = Database.MapperFactory.CreateValueMapper();
            var values = new List<T>();
            DoExecute(builder, connection, configureCommand,
                reader =>
                {
                    ISqlRow row;
                    while ((row = reader.ReadRow()) is object)
                    {
                        var entity = Database.EntityFactory.CreateEntity<T>();
                        mapper.Map(entity, row, valueMapper);
                        values.Add(entity);
                    }
                }
            );
            return values;
        }

        public IList<T> ExecuteTypeList<T>(ITypeListTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand, Func<ISqlRow, T> map)
        {
            var values = new List<T>();
            DoExecute(builder, connection, configureCommand,
                reader =>
                {
                    ISqlRow row;
                    while ((row = reader.ReadRow()) is object)
                    {
                        values.Add(map(row));
                    }
                }
            );
            return values;
        }
        #endregion

        private void DoExecute(
            ITerminationExpressionBuilder builder,
            ISqlConnection connection,
            Action<DbCommand> configureCommand,
            Action<ISqlRowReader> transform
        )
        {
            var expression = (builder as IDbExpressionSetProvider).Expression;

            //assembly
            BeforeAssembly.Invoke(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(expression)));

            var appender = Database.AppenderFactory.CreateAppender();
            var parameterBuilder = Database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var statementBuilder = Database.StatementBuilderFactory.CreateSqlStatementBuilder(Database.AssemblerConfiguration, expression, appender, parameterBuilder);

            AfterAssembly.Invoke(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(expression, statementBuilder)));

            var statement = statementBuilder.CreateSqlStatement();

            switch (expression.StatementExecutionType)
            {
                case SqlStatementExecutionType.Insert:
                    BeforeInsert.Invoke(new Lazy<BeforeInsertPipelineExecutionContext>(() => new BeforeInsertPipelineExecutionContext(expression, appender, parameterBuilder)));
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

            if (connection is null)
                connection = CreateConnection(expression);

            if (transform is null)
            {
                executor.ExecuteNonQuery(statement, connection, configureCommand, cmd => BeforeExecution?.Invoke(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(expression, statement, cmd))));

                switch (expression.StatementExecutionType)
                {
                    case SqlStatementExecutionType.Insert:
                        AfterInsert.Invoke(new Lazy<AfterInsertPipelineExecutionContext>(() => new AfterInsertPipelineExecutionContext(expression, parameterBuilder, Database.MapperFactory)));
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

                return;
            }

            var reader = executor.ExecuteQuery(statement, connection, configureCommand, Database.MapperFactory.CreateValueMapper(), cmd => BeforeExecution?.Invoke(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(expression, statement, cmd))));
            //run post-execute pipeline, need switch on type to build up correct wrapper; i.e. (new AfterInsertExecutionContext(executionContext, statement)
            if (reader is null)
                return;
            transform(reader);
        }
    }
}
