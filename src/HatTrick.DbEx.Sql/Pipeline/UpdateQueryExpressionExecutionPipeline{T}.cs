using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class UpdateQueryExpressionExecutionPipeline<T> : IUpdateQueryExpressionExecutionPipeline<T>
        where T : class, IDbEntity
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration database;
        private readonly PipelineEventHook<BeforeAssemblyPipelineExecutionContext> beforeAssembly;
        private readonly PipelineEventHook<AfterAssemblyPipelineExecutionContext> afterAssembly;
        private readonly PipelineEventHook<BeforeExecutionPipelineExecutionContext> beforeExecution;
        private readonly PipelineEventHook<AfterExecutionPipelineExecutionContext> afterExecution;
        private readonly PipelineEventHook<BeforeUpdatePipelineExecutionContext> beforeUpdate;
        private readonly PipelineEventHook<AfterUpdatePipelineExecutionContext> afterUpdate;
        #endregion

        #region constructors
        public UpdateQueryExpressionExecutionPipeline(
            RuntimeSqlDatabaseConfiguration database,
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
        public int ExecuteUpdate(UpdateQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand)
        {
            var appender = database.AppenderFactory.CreateAppender();
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.ExpressionElementAppenderFactory, database.AssemblerConfiguration, expression, appender, parameterBuilder);

            beforeAssembly?.Invoke(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(database, expression, parameterBuilder)));
            var statement = statementBuilder.CreateSqlStatement();
            afterAssembly?.Invoke(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(database, expression, parameterBuilder, statement)));

            beforeUpdate?.Invoke(new Lazy<BeforeUpdatePipelineExecutionContext>(() => new BeforeUpdatePipelineExecutionContext(database, expression, statement, parameterBuilder)));

            var rowsAffected = database.StatementExecutorFactory.CreateSqlStatementExecutor(expression).ExecuteScalar<int>(
                statement,
                connection,
                cmd => { 
                    beforeExecution?.Invoke(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, cmd, statement))); 
                    configureCommand?.Invoke(cmd); 
                },
                cmd => afterExecution?.Invoke(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(database, expression, cmd)))
            );

            afterUpdate?.Invoke(new Lazy<AfterUpdatePipelineExecutionContext>(() => new AfterUpdatePipelineExecutionContext(database, expression, statement)));

            return rowsAffected;
        }

        public async Task<int> ExecuteUpdateAsync(UpdateQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
        {
            var appender = database.AppenderFactory.CreateAppender();
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.ExpressionElementAppenderFactory, database.AssemblerConfiguration, expression, appender, parameterBuilder);

            if (beforeAssembly is object)
            {
                await beforeAssembly.InvokeAsync(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(database, expression, parameterBuilder)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }
            var statement = statementBuilder.CreateSqlStatement();
            if (afterAssembly is object)
            {
                await afterAssembly.InvokeAsync(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(database, expression, parameterBuilder, statement)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            if (beforeUpdate is object)
            {
                await beforeUpdate.InvokeAsync(new Lazy<BeforeUpdatePipelineExecutionContext>(() => new BeforeUpdatePipelineExecutionContext(database, expression, statement, parameterBuilder)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            var rowsAffected = await database.StatementExecutorFactory.CreateSqlStatementExecutor(expression).ExecuteScalarAsync<int>(
                statement,
                connection,
                async cmd =>
                {
                    if (beforeExecution is object)
                    {
                        await beforeExecution.InvokeAsync(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, cmd, statement)), ct).ConfigureAwait(false);
                    }
                    configureCommand?.Invoke(cmd);
                },
                async cmd =>
                {
                    if (afterExecution is object)
                    {
                        await afterExecution.InvokeAsync(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(database, expression, cmd)), ct).ConfigureAwait(false);
                    }
                },
                ct
            ).ConfigureAwait(false);

            ct.ThrowIfCancellationRequested();

            if (afterUpdate is object)
            {
                await afterUpdate.InvokeAsync(new Lazy<AfterUpdatePipelineExecutionContext>(() => new AfterUpdatePipelineExecutionContext(database, expression, statement)), ct).ConfigureAwait(false);
                ct.ThrowIfCancellationRequested();
            }

            return rowsAffected;
        }
        #endregion
    }
}
