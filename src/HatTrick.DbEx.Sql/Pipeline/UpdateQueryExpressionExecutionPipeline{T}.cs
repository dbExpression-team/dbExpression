using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class UpdateQueryExpressionExecutionPipeline<T> : IUpdateQueryExpressionExecutionPipeline<T>
        where T : class, IDbEntity
    {
        #region internals
        private readonly DatabaseConfiguration database;
        private readonly PipelineEventHook<BeforeAssemblyPipelineExecutionContext> beforeAssembly;
        private readonly PipelineEventHook<AfterAssemblyPipelineExecutionContext> afterAssembly;
        private readonly PipelineEventHook<BeforeExecutionPipelineExecutionContext> beforeExecution;
        private readonly PipelineEventHook<AfterExecutionPipelineExecutionContext> afterExecution;
        private readonly PipelineEventHook<BeforeUpdatePipelineExecutionContext> beforeUpdate;
        private readonly PipelineEventHook<AfterUpdatePipelineExecutionContext> afterUpdate;
        #endregion

        #region constructors
        public UpdateQueryExpressionExecutionPipeline(
            DatabaseConfiguration database,
            PipelineEventHook<BeforeAssemblyPipelineExecutionContext> beforeAssembly,
            PipelineEventHook<AfterAssemblyPipelineExecutionContext> afterAssembly,
            PipelineEventHook<BeforeExecutionPipelineExecutionContext> beforeExecution,
            PipelineEventHook<AfterExecutionPipelineExecutionContext> afterExecution,
            PipelineEventHook<BeforeUpdatePipelineExecutionContext> beforeUpdate,
            PipelineEventHook<AfterUpdatePipelineExecutionContext> afterUpdate
        )
        {
            this.database = database;
            this.beforeAssembly = beforeAssembly;
            this.afterAssembly = afterAssembly;
            this.beforeExecution = beforeExecution;
            this.afterExecution = afterExecution;
            this.beforeUpdate = beforeUpdate;
            this.afterUpdate = afterUpdate;
        }
        #endregion

        #region methods
        public int ExecuteUpdate(UpdateQueryExpression expression, ISqlConnection connection, Action<DbCommand> configureCommand)
        {
            var appender = database.AppenderFactory.CreateAppender();
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.AssemblyPartAppenderFactory, database.AssemblerConfiguration, expression, appender, parameterBuilder);
            if (connection is null)
                connection = database.ConnectionFactory.CreateSqlConnection();

            beforeAssembly?.Invoke(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(database, expression)));
            var statement = statementBuilder.CreateSqlStatement();
            afterAssembly?.Invoke(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(database, expression, statementBuilder)));

            beforeUpdate?.Invoke(new Lazy<BeforeUpdatePipelineExecutionContext>(() => new BeforeUpdatePipelineExecutionContext(database, expression, appender, parameterBuilder)));

            var fields = statement.Parameters.Where(x => x.Field is object).Select(x => x.Field);

            var rowsAffected = database.ExecutorFactory.CreateSqlStatementExecutor(expression).ExecuteScalar<int>(
                statement,
                connection,
                new FieldExpressionConverters(fields, database.ValueConverterFactory),
                database.ValueConverterFactory.CreateConverter(),
                cmd => { 
                    beforeExecution?.Invoke(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, statement, cmd))); 
                    configureCommand?.Invoke(cmd); 
                },
                cmd => afterExecution?.Invoke(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(database, expression, statement, cmd)))
            );

            afterUpdate?.Invoke(new Lazy<AfterUpdatePipelineExecutionContext>(() => new AfterUpdatePipelineExecutionContext(database, expression, statement)));

            return rowsAffected;
        }

        public async Task<int> ExecuteUpdateAsync(UpdateQueryExpression expression, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
        {
            var appender = database.AppenderFactory.CreateAppender();
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.AssemblyPartAppenderFactory, database.AssemblerConfiguration, expression, appender, parameterBuilder);
            if (connection is null)
                connection = database.ConnectionFactory.CreateSqlConnection();

            if (beforeAssembly is object)
            {
                await beforeAssembly.InvokeAsync(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(database, expression)), ct).ConfigureAwait(false);
            }
            var statement = statementBuilder.CreateSqlStatement();
            if (afterAssembly is object)
            {
                await afterAssembly.InvokeAsync(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(database, expression, statementBuilder)), ct).ConfigureAwait(false);
            }

            if (beforeUpdate is object)
            {
                await beforeUpdate.InvokeAsync(new Lazy<BeforeUpdatePipelineExecutionContext>(() => new BeforeUpdatePipelineExecutionContext(database, expression, appender, parameterBuilder)), ct).ConfigureAwait(false);
            }

            var fields = statement.Parameters.Where(x => x.Field is object).Select(x => x.Field);

            var rowsAffected = await database.ExecutorFactory.CreateSqlStatementExecutor(expression).ExecuteScalarAsync<int>(
                statement,
                connection,
                new FieldExpressionConverters(fields, database.ValueConverterFactory),
                database.ValueConverterFactory.CreateConverter(),
                async cmd => {
                    if (beforeExecution is object)
                    {
                        await beforeExecution.InvokeAsync(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, statement, cmd)), ct).ConfigureAwait(false);
                    }
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

            if (afterUpdate is object)
            {
                await afterUpdate.InvokeAsync(new Lazy<AfterUpdatePipelineExecutionContext>(() => new AfterUpdatePipelineExecutionContext(database, expression, statement)), ct).ConfigureAwait(false);
            }

            return rowsAffected;
        }
        #endregion
    }
}
