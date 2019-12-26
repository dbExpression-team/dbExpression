using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;
using System.Threading;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class SyncExecutionPipeline : ExecutionPipeline
    {
        private SyncPipeline<BeforeAssemblyContext> BeforeAssembly { get; set; }
        private SyncPipeline<AfterAssemblyContext> AfterAssembly { get; set; }
        private SyncPipeline<BeforeInsertContext> BeforeInsert { get; set; }
        private SyncPipeline<AfterInsertContext> AfterInsert { get; set; }

        public SyncExecutionPipeline(
            DbExpressionRuntimeConfiguration config,
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
        public void ExecuteVoid(ITerminationExpressionBuilder builder)
            => DoExecuteVoid(builder, null, _ => { });

        public void ExecuteVoid(ITerminationExpressionBuilder builder, SqlConnection connection)
            => DoExecuteVoid(builder, connection, _ => { });

        public void ExecuteVoid(ITerminationExpressionBuilder builder, int commandTimeout)
            => DoExecuteVoid(builder, null, c => c.CommandTimeout = commandTimeout);

        public void ExecuteVoid(ITerminationExpressionBuilder builder, SqlConnection connection, int commandTimeout)
            => DoExecuteVoid(builder, connection, c => c.CommandTimeout = commandTimeout);

        private void DoExecuteVoid(ITerminationExpressionBuilder builder, SqlConnection connection, Action<DbCommand> configureCommand)
            => DoExecute(builder, connection, configureCommand, null);
        #endregion

        #region ValueTerminationExpressionBuilder
        public T ExecuteValue<T>(IValueTerminationExpressionBuilder<T> builder)
            => DoExecuteValue(builder, (SqlConnection)null, _ => { });

        public T ExecuteValue<T>(IValueTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand)
            => DoExecuteValue(builder, (SqlConnection)null, configureCommand);

        public T ExecuteValue<T>(IValueTerminationExpressionBuilder<T> builder, SqlConnection connection)
            => DoExecuteValue(builder, connection, _ => { });

        public T ExecuteValue<T>(IValueTerminationExpressionBuilder<T> builder, int commandTimeout)
            => DoExecuteValue(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout);

        public T ExecuteValue<T>(IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            => DoExecuteValue(builder, connection, c => c.CommandTimeout = commandTimeout);

        private T DoExecuteValue<T>(IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand)
        {
            T t = default;
            DoExecute(builder, connection, configureCommand, reader => ManageValueReader<T>(reader, v => t = v));
            return t;
        }
        #endregion

        #region ValueListTerminationExpressionBuilder
        public IList<T> ExecuteValueList<T>(IValueListTerminationExpressionBuilder<T> builder)
            => DoExecuteValueList(builder, null, _ => { });

        public IList<T> ExecuteValueList<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            => DoExecuteValueList(builder, connection, _ => { });

        public IList<T> ExecuteValueList<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            => DoExecuteValueList(builder, connection, c => c.CommandTimeout = commandTimeout);

        public IList<T> ExecuteValueList<T>(IValueListTerminationExpressionBuilder<T> builder, int commandTimeout)
            => DoExecuteValueList(builder, null, c => c.CommandTimeout = commandTimeout);

        private IList<T> DoExecuteValueList<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand)
        {
            var list = new List<T>();
            DoExecuteValueList(builder, connection, configureCommand, t => list.Add(t));
            return list;
        }

        public void ExecuteValueList<T>(IValueListTerminationExpressionBuilder<T> builder, Action<T> onValueMaterialized)
            => DoExecuteValueList(builder, null, _ => { }, onValueMaterialized);

        public void ExecuteValueList<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<T> onValueMaterialized)
            => DoExecuteValueList(builder, connection, _ => { }, onValueMaterialized);

        public void ExecuteValueList<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, Action<T> onValueMaterialized)
            => DoExecuteValueList(builder, connection, c => c.CommandTimeout = commandTimeout, onValueMaterialized);

        public void ExecuteValueList<T>(IValueListTerminationExpressionBuilder<T> builder, int commandTimeout, Action<T> onValueMaterialized)
            => DoExecuteValueList(builder, null, c => c.CommandTimeout = commandTimeout, onValueMaterialized);

        private void DoExecuteValueList<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand, Action<T> onValueMaterialized)
            => DoExecute(builder, connection, configureCommand, reader => ManageValueListReader(reader, onValueMaterialized));
        #endregion

        #region ValueTerminationExpressionBuilder-dynamic
        public dynamic ExecuteDynamic(IValueTerminationExpressionBuilder<ExpandoObject> builder)
            => DoExecuteDynamic(builder, (SqlConnection)null, _ => { });

        public dynamic ExecuteDynamic(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
            => DoExecuteDynamic(builder, connection, _ => { });

        public dynamic ExecuteDynamic(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout)
            => DoExecuteDynamic(builder, connection, c => c.CommandTimeout = commandTimeout);

        public dynamic ExecuteDynamic(IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => DoExecuteDynamic(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout);

        private dynamic DoExecuteDynamic(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<DbCommand> configureCommand)
        {
            ExpandoObject t = default;
            DoExecute(builder, connection, configureCommand, reader => ManageDynamicReader(reader, v => t = v));
            return t;
        }
        #endregion

        #region ValueListTerminationExpressionBuilder
        public IList<dynamic> ExecuteDynamicList(IValueListTerminationExpressionBuilder<ExpandoObject> builder)
            => DoExecuteDynamicList(builder, null, _ => { });

        public IList<dynamic> ExecuteDynamicList(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
            => DoExecuteDynamicList(builder, connection, _ => { });

        public IList<dynamic> ExecuteDynamicList(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout)
           => DoExecuteDynamicList(builder, connection, c => c.CommandTimeout = commandTimeout);

        public IList<dynamic> ExecuteDynamicList(IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => DoExecuteDynamicList(builder, null, c => c.CommandTimeout = commandTimeout);

        private IList<dynamic> DoExecuteDynamicList(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<DbCommand> configureCommand)
        {
            var list = new List<dynamic>();
            DoExecuteDynamicList(builder, connection, configureCommand, t => list.Add(t));
            return list;
        }

        public void ExecuteDynamicList(IValueListTerminationExpressionBuilder<ExpandoObject> builder, Action<ExpandoObject> onDynamicMaterialized)
            => DoExecuteDynamicList(builder, null, _ => { }, onDynamicMaterialized);

        public void ExecuteDynamicList(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<ExpandoObject> onDynamicMaterialized)
            => DoExecuteDynamicList(builder, connection, _ => { }, onDynamicMaterialized);

        public void ExecuteDynamicList(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout, Action<ExpandoObject> onDynamicMaterialized)
            => DoExecuteDynamicList(builder, connection, c => c.CommandTimeout = commandTimeout, onDynamicMaterialized);

        public void ExecuteDynamicList(IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Action<ExpandoObject> onDynamicMaterialized)
            => DoExecuteDynamicList(builder, null, c => c.CommandTimeout = commandTimeout, onDynamicMaterialized);

        private void DoExecuteDynamicList(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<DbCommand> configureCommand, Action<ExpandoObject> onDynamicMaterialized)
            => DoExecute(builder, connection, configureCommand, reader => ManageDynamicListReader(reader, onDynamicMaterialized));
        #endregion

        #region TypeTerminationExpressionBuilder
        public T ExecuteType<T>(ITypeTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => DoExecuteType(builder, null, _ => { });

        public T ExecuteType<T>(ITypeTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => DoExecuteType(builder, null, configureCommand);

        public T ExecuteType<T>(ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
            => DoExecuteType(builder, connection, _ => { });

        public T ExecuteType<T>(ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => DoExecuteType(builder, connection, c => c.CommandTimeout = commandTimeout);

        public T ExecuteType<T>(ITypeTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => DoExecuteType(builder, null, c => c.CommandTimeout = commandTimeout);

        private T DoExecuteType<T>(ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
        {
            T t = default;
            DoExecute(builder, connection, configureCommand, reader => ManageTypeReader(reader, v => t = v, (builder as IDbExpressionSetProvider).Expression.BaseEntity as EntityExpression<T>));
            return t;
        } 
        #endregion

        #region TypeListTerminationExpressionBuilder
        public IList<T> ExecuteTypeList<T>(ITypeListTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => DoExecuteTypeList(builder, null, _ => { });

        public IList<T> ExecuteTypeList<T>(ITypeListTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => DoExecuteTypeList(builder, null, configureCommand);

        public IList<T> ExecuteTypeList<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
            => DoExecuteTypeList(builder, connection, _ => { });

        public IList<T> ExecuteTypeList<T>(ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => DoExecuteTypeList(builder, null, c => c.CommandTimeout = commandTimeout);

        public IList<T> ExecuteTypeList<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => DoExecuteTypeList(builder, connection, c => c.CommandTimeout = commandTimeout);

        private IList<T> DoExecuteTypeList<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
        {
            var list = new List<T>();
            DoExecuteTypeList(builder, connection, configureCommand, t => list.Add(t));
            return list;
        }

        public void ExecuteTypeList<T>(ITypeListTerminationExpressionBuilder<T> builder, Action<T> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => DoExecuteTypeList(builder, null, _ => { }, onEntityMaterialized);

        public void ExecuteTypeList<T>(ITypeListTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand, Action<T> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => DoExecuteTypeList(builder, null, configureCommand, onEntityMaterialized);

        public void ExecuteTypeList<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<T> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => DoExecuteTypeList(builder, connection, _ => { }, onEntityMaterialized);

        public void ExecuteTypeList<T>(ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout, Action<T> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => DoExecuteTypeList(builder, null, c => c.CommandTimeout = commandTimeout, onEntityMaterialized);

        public void ExecuteTypeList<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, Action<T> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => DoExecuteTypeList(builder, connection, c => c.CommandTimeout = commandTimeout, onEntityMaterialized);

        private void DoExecuteTypeList<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand, Action<T> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => DoExecute(builder, connection, configureCommand, reader => ManageTypeListReader((ISqlRowReader)reader, onEntityMaterialized, (builder as IDbExpressionSetProvider).Expression.BaseEntity as EntityExpression<T>));
        #endregion

        private void DoExecute(
            ITerminationExpressionBuilder builder,
            SqlConnection connection,
            Action<DbCommand> configureCommand,
            Action<ISqlRowReader> transform
        )
        {
            var expression = (builder as IDbExpressionSetProvider).Expression;

            //assembly
            BeforeAssembly.Invoke(new Lazy<BeforeAssemblyContext>(() => new BeforeAssemblyContext(expression)));

            var appender = Database.AppenderFactory.CreateAppender();
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
                connection = CreateConnection(expression);

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

                return;
            }

            var reader = executor.ExecuteQuery(statement, connection, configureCommand);
            //run post-execute pipeline, need switch on type to build up correct wrapper; i.e. (new AfterInsertExecutionContext(executionContext, statement)
            if (reader == null)
                return;
            transform(reader);
        }
    }
}
