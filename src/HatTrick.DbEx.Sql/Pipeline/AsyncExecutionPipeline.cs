using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AsyncExecutionPipeline : ExecutionPipeline
    {
        private AsyncPipeline<BeforeAssemblyContext> BeforeAssembly { get; set; }
        private AsyncPipeline<AfterAssemblyContext> AfterAssembly { get; set; }
        private AsyncPipeline<BeforeInsertContext> BeforeInsert { get; set; }
        private AsyncPipeline<AfterInsertContext> AfterInsert { get; set; }

        public AsyncExecutionPipeline(
            DbExpressionConfiguration config,
            DatabaseConfiguration database,
            AsyncPipeline<BeforeAssemblyContext> beforeAssembly,
            AsyncPipeline<AfterAssemblyContext> afterAssembly,
            AsyncPipeline<BeforeInsertContext> beforeInsert,
            AsyncPipeline<AfterInsertContext> afterInsert
        ) : base(config, database)
        {
            BeforeAssembly = beforeAssembly;
            AfterAssembly = afterAssembly;
            BeforeInsert = beforeInsert;
            AfterInsert = afterInsert;
        }

        #region TerminationExpressionBuilder
        public async Task ExecuteAsync(ITerminationExpressionBuilder builder)
            => await ExecuteAsync(builder, (SqlConnection)null, _ => { }, CancellationToken.None).ConfigureAwait(false);

        public async Task ExecuteAsync(ITerminationExpressionBuilder builder, CancellationToken ct)
            => await ExecuteAsync(builder, (SqlConnection)null, _ => { }, ct).ConfigureAwait(false);

        public async Task ExecuteAsync(ITerminationExpressionBuilder builder, Action<DbCommand> configureCommand, CancellationToken ct)
            => await ExecuteAsync(builder, (SqlConnection)null, configureCommand, ct).ConfigureAwait(false);

        public async Task ExecuteAsync(ITerminationExpressionBuilder builder, Action<DbCommand> configureCommand)
            => await ExecuteAsync(builder, (SqlConnection)null, configureCommand, CancellationToken.None).ConfigureAwait(false);

        public async Task ExecuteAsync(ITerminationExpressionBuilder builder, SqlConnection connection)
            => await ExecuteAsync(builder, connection, _ => { }, CancellationToken.None).ConfigureAwait(false);

        public async Task ExecuteAsync(ITerminationExpressionBuilder builder, SqlConnection connection, Action<DbCommand> configureCommand)
            => await ExecuteAsync(builder, connection, configureCommand, CancellationToken.None).ConfigureAwait(false);

        public async Task ExecuteAsync(ITerminationExpressionBuilder builder, SqlConnection connection, CancellationToken ct)
            => await ExecuteAsync(builder, connection, _ => { }, ct).ConfigureAwait(false);

        public async Task ExecuteAsync(ITerminationExpressionBuilder builder, SqlConnection connection, int commandTimeout)
            => await ExecuteAsync(builder, connection, c => c.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public async Task ExecuteAsync(ITerminationExpressionBuilder builder, int commandTimeout)
            => await ExecuteAsync(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public async Task ExecuteAsync(ITerminationExpressionBuilder builder, int commandTimeout, CancellationToken ct)
            => await ExecuteAsync(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public async Task ExecuteAsync(ITerminationExpressionBuilder builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            => await ExecuteAsync(builder, connection, c => c.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public async Task ExecuteAsync(ITerminationExpressionBuilder builder, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
        {
            await ExecuteAsync(
                builder,
                connection,
                configureCommand,
                (Func<ISqlRowReader, int>)null,
                ct
            ).ConfigureAwait(false);
            
        }
        #endregion

        #region ValueTerminationExpressionBuilder
        public async Task<T> ExecuteAsync<T>(IValueTerminationExpressionBuilder<T> builder)
            => await ExecuteAsync(builder, (SqlConnection)null, _ => { }, CancellationToken.None).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(IValueTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand)
            => await ExecuteAsync(builder, (SqlConnection)null, configureCommand, CancellationToken.None).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(IValueTerminationExpressionBuilder<T> builder, CancellationToken ct)
            => await ExecuteAsync(builder, (SqlConnection)null, _ => { }, ct).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(IValueTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand, CancellationToken ct)
            => await ExecuteAsync(builder, (SqlConnection)null, configureCommand, ct).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(IValueTerminationExpressionBuilder<T> builder, SqlConnection connection)
            => await ExecuteAsync(builder, connection, _ => { }, CancellationToken.None).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand)
            => await ExecuteAsync(builder, connection, configureCommand, CancellationToken.None).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
            => await ExecuteAsync(builder, connection, _ => { }, ct).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            => await ExecuteAsync(builder, connection, c => c.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(IValueTerminationExpressionBuilder<T> builder, int commandTimeout)
            => await ExecuteAsync(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(IValueTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            => await ExecuteAsync(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            => await ExecuteAsync(builder, connection, c => c.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
        {
            return await ExecuteAsync(
                builder,
                connection,
                configureCommand,
                reader =>
                {
                    var field = reader.ReadRow()?.ReadField();
                    if (field == null)
                        return default;

                    var mapper = Database.MapperFactory.CreateValueMapper<T>();
                    return mapper.Map(field.Value);
                },
                ct
            ).ConfigureAwait(false);
        }
        #endregion

        #region ValueListTerminationExpressionBuilder
        public async Task<IList<T>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<T> builder)
            => await ExecuteAsync(builder, (SqlConnection)null, _ => { }, CancellationToken.None).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand)
            => await ExecuteAsync(builder, (SqlConnection)null, configureCommand, CancellationToken.None).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<T> builder, CancellationToken ct)
            => await ExecuteAsync(builder, (SqlConnection)null, _ => { }, ct).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand, CancellationToken ct)
            => await ExecuteAsync(builder, (SqlConnection)null, configureCommand, ct).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            => await ExecuteAsync(builder, connection, _ => { }, CancellationToken.None).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand)
            => await ExecuteAsync(builder, connection, configureCommand, CancellationToken.None).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
            => await ExecuteAsync(builder, connection, _ => { }, ct).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            => await ExecuteAsync(builder, connection, c => c.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<T> builder, int commandTimeout)
            => await ExecuteAsync(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            => await ExecuteAsync(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            => await ExecuteAsync(builder, connection, c => c.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
        {
            return await ExecuteAsync(
                builder,
                connection,
                configureCommand,
                reader =>
                {
                    var values = new List<T>();

                    var mapper = Database.MapperFactory.CreateValueMapper<T>();
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
        public async Task<dynamic> ExecuteAsync<T>(IValueTerminationExpressionBuilder<ExpandoObject> builder)
            => await ExecuteAsync(builder, (SqlConnection)null, _ => { }, CancellationToken.None).ConfigureAwait(false);

        public async Task<dynamic> ExecuteAsync<T>(IValueTerminationExpressionBuilder<ExpandoObject> builder, CancellationToken ct)
            => await ExecuteAsync(builder, (SqlConnection)null, _ => { }, ct).ConfigureAwait(false);

        public async Task<dynamic> ExecuteAsync<T>(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
            => await ExecuteAsync(builder, connection, _ => { }, CancellationToken.None).ConfigureAwait(false);

        public async Task<dynamic> ExecuteAsync<T>(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, CancellationToken ct)
            => await ExecuteAsync(builder, connection, _ => { }, ct).ConfigureAwait(false);

        public async Task<dynamic> ExecuteAsync<T>(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout)
            => await ExecuteAsync(builder, connection, c => c.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public async Task<dynamic> ExecuteAsync<T>(IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => await ExecuteAsync(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public async Task<dynamic> ExecuteAsync<T>(IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, CancellationToken ct)
            => await ExecuteAsync(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public async Task<dynamic> ExecuteAsync<T>(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            => await ExecuteAsync(builder, connection, c => c.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public async Task<dynamic> ExecuteAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
        {
            return await ExecuteAsync(
                builder,
                connection,
                configureCommand,
                reader =>
                {
                    var value = default(ExpandoObject);

                    var row = reader.ReadRow();
                    if (row == null)
                        return value;

                    var mapper = Database.MapperFactory.CreateExpandoObjectMapper();
                    mapper.Map(value, row);

                    return (dynamic)value;
                },
                ct
            ).ConfigureAwait(false);
        }
        #endregion

        #region ValueListTerminationExpressionBuilder
        public async Task<IList<dynamic>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<ExpandoObject> builder)
            => await ExecuteAsync(builder, (SqlConnection)null, _ => { }, CancellationToken.None).ConfigureAwait(false);

        public async Task<IList<dynamic>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<ExpandoObject> builder, CancellationToken ct)
            => await ExecuteAsync(builder, (SqlConnection)null, _ => { }, ct).ConfigureAwait(false);

        public async Task<IList<dynamic>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
            => await ExecuteAsync(builder, connection, _ => { }, CancellationToken.None).ConfigureAwait(false);

        public async Task<IList<dynamic>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, CancellationToken ct)
            => await ExecuteAsync(builder, connection, _ => { }, ct).ConfigureAwait(false);

        public async Task<IList<dynamic>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout)
            => await ExecuteAsync(builder, connection, c => c.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public async Task<IList<dynamic>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => await ExecuteAsync(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public async Task<IList<dynamic>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, CancellationToken ct)
            => await ExecuteAsync(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public async Task<IList<dynamic>> ExecuteAsync<T>(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            => await ExecuteAsync(builder, connection, c => c.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public async Task<IList<dynamic>> ExecuteAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
        {
            return await ExecuteAsync(
                builder,
                connection,
                configureCommand,
                reader =>
                {
                    var values = new List<dynamic>();

                    var mapper = Database.MapperFactory.CreateExpandoObjectMapper();
                    ISqlRow row = null;
                    while ((row = reader.ReadRow()) != null)
                    {
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
            => await ExecuteAsync(builder, (SqlConnection)null, _ => { }, CancellationToken.None).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(ITypeTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, (SqlConnection)null, configureCommand, CancellationToken.None).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(ITypeTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, (SqlConnection)null, _ => { }, ct).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(ITypeTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, (SqlConnection)null, configureCommand, ct).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, connection, _ => { }, CancellationToken.None).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, connection, configureCommand, CancellationToken.None).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, connection, _ => { }, ct).ConfigureAwait(false);
        
        public async Task<T> ExecuteAsync<T>(ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, connection, c => c.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(ITypeTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(ITypeTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, connection, c => c.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public async Task<T> ExecuteAsync<T>(ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            return await ExecuteAsync(
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
                },
                ct
            ).ConfigureAwait(false);
        }
        #endregion

        #region TypeListTerminationExpressionBuilder
        public async Task<IList<T>> ExecuteAsync<T>(ITypeListTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, (SqlConnection)null, _ => { }, CancellationToken.None).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, (SqlConnection)null, configureCommand, CancellationToken.None).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, (SqlConnection)null, _ => { }, ct).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, (SqlConnection)null, configureCommand, ct).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, connection, _ => { }, CancellationToken.None).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, connection, configureCommand, CancellationToken.None).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, connection, _ => { }, ct).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, connection, c => c.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, (SqlConnection)null, c => c.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await ExecuteAsync(builder, connection, c => c.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public async Task<IList<T>> ExecuteAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            return await ExecuteAsync(
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
                },
                ct
            ).ConfigureAwait(false);
        }
        #endregion

        private async Task<T> ExecuteAsync<T>(
            ITerminationExpressionBuilder builder,
            SqlConnection connection,
            Action<DbCommand> configureCommand,
            Func<ISqlRowReader, T> transform,
            CancellationToken ct
        )
        {
            if (ct == null)
                throw new ArgumentNullException("Cancellation token cannot be null");

            ct.ThrowIfCancellationRequested();

            var expression = (builder as IDbExpressionSetProvider).Expression;

            //assembly
            await BeforeAssembly.InvokeAsync(new Lazy<BeforeAssemblyContext>(() => new BeforeAssemblyContext(expression)), ct).ConfigureAwait(false);

            var appender = Database.AppenderFactory.CreateAppender(Database.AssemblerConfiguration.Minify);
            var parameterBuilder = Database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var statementBuilder = Database.StatementBuilderFactory.CreateSqlStatementBuilder(Database.AssemblerConfiguration, expression, appender, parameterBuilder);

            await AfterAssembly.InvokeAsync(new Lazy<AfterAssemblyContext>(() => new AfterAssemblyContext(expression, statementBuilder)), ct).ConfigureAwait(false);

            var statement = statementBuilder.CreateSqlStatement();

            switch (expression.StatementExecutionType)
            {
                case SqlStatementExecutionType.Insert:
                    await BeforeInsert.InvokeAsync(new Lazy<BeforeInsertContext>(() => new BeforeInsertContext(expression, appender, parameterBuilder)), ct).ConfigureAwait(false);
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
                await executor.ExecuteNonQueryAsync(statement, connection, configureCommand, ct);

                switch (expression.StatementExecutionType)
                {
                    case SqlStatementExecutionType.Insert:
                        await AfterInsert.InvokeAsync(new Lazy<AfterInsertContext>(() => new AfterInsertContext(expression, parameterBuilder, Database.MapperFactory)), ct).ConfigureAwait(false);
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

            using (var reader = await executor.ExecuteQueryAsync(statement, connection, configureCommand, ct))
            {
                //run post-execute pipeline, need switch on type to build up correct wrapper; i.e. (new AfterInsertExecutionContext(executionContext, statement)
                if (reader == null)
                    return default;
                return transform(reader);
            }
        }
    }
}
