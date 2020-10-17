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
    public class DeleteQueryExpressionExecutionPipeline<T> : IDeleteQueryExpressionExecutionPipeline<T>
        where T : class, IDbEntity
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration database;
        private readonly PipelineEventHook<BeforeAssemblyPipelineExecutionContext> beforeAssembly;
        private readonly PipelineEventHook<AfterAssemblyPipelineExecutionContext> afterAssembly;
        private readonly PipelineEventHook<BeforeExecutionPipelineExecutionContext> beforeExecution;
        private readonly PipelineEventHook<AfterExecutionPipelineExecutionContext> afterExecution;
        private readonly PipelineEventHook<BeforeDeletePipelineExecutionContext> beforeDelete;
        private readonly PipelineEventHook<AfterDeletePipelineExecutionContext> afterDelete;
        #endregion

        #region constructors
        public DeleteQueryExpressionExecutionPipeline(
            RuntimeSqlDatabaseConfiguration database,
            PipelineEventHook<BeforeAssemblyPipelineExecutionContext> beforeAssembly,
            PipelineEventHook<AfterAssemblyPipelineExecutionContext> afterAssembly,
            PipelineEventHook<BeforeExecutionPipelineExecutionContext> beforeExecution,
            PipelineEventHook<AfterExecutionPipelineExecutionContext> afterExecution,
            PipelineEventHook<BeforeDeletePipelineExecutionContext> beforeDelete,
            PipelineEventHook<AfterDeletePipelineExecutionContext> afterDelete
        )
        {
            this.database = database;
            this.beforeAssembly = beforeAssembly;
            this.afterAssembly = afterAssembly;
            this.beforeExecution = beforeExecution;
            this.afterExecution = afterExecution;
            this.beforeDelete = beforeDelete;
            this.afterDelete = afterDelete;
        }
        #endregion

        #region methods
        public int ExecuteDelete(DeleteQueryExpression expression, ISqlConnection connection, Action<DbCommand> configureCommand)
        {
            var appender = database.AppenderFactory.CreateAppender();
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.AssemblyPartAppenderFactory, database.AssemblerConfiguration, expression, appender, parameterBuilder);
            if (connection is null)
                connection = database.ConnectionFactory.CreateSqlConnection();

            beforeAssembly?.Invoke(new Lazy<BeforeAssemblyPipelineExecutionContext>(() => new BeforeAssemblyPipelineExecutionContext(database, expression)));
            var statement = statementBuilder.CreateSqlStatement();
            afterAssembly?.Invoke(new Lazy<AfterAssemblyPipelineExecutionContext>(() => new AfterAssemblyPipelineExecutionContext(database, expression, statementBuilder)));

            beforeDelete?.Invoke(new Lazy<BeforeDeletePipelineExecutionContext>(() => new BeforeDeletePipelineExecutionContext(database, expression, appender, parameterBuilder)));

            var rowsAffected = database.ExecutorFactory.CreateSqlStatementExecutor(expression).ExecuteScalar<int>(
                statement,
                connection,
                cmd => { 
                    beforeExecution?.Invoke(new Lazy<BeforeExecutionPipelineExecutionContext>(() => new BeforeExecutionPipelineExecutionContext(database, expression, statement, cmd))); 
                    configureCommand?.Invoke(cmd); 
                },
                cmd => afterExecution?.Invoke(new Lazy<AfterExecutionPipelineExecutionContext>(() => new AfterExecutionPipelineExecutionContext(database, expression, statement, cmd)))
            );

            afterDelete?.Invoke(new Lazy<AfterDeletePipelineExecutionContext>(() => new AfterDeletePipelineExecutionContext(database, expression, statement)));

            return rowsAffected;
        }

        public async Task<int> ExecuteDeleteAsync(DeleteQueryExpression expression, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
        {
            var appender = database.AppenderFactory.CreateAppender();
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var statementBuilder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.AssemblyPartAppenderFactory, database.AssemblerConfiguration, expression, appender, parameterBuilder);
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

            if (beforeDelete is object)
            {
                await beforeDelete.InvokeAsync(new Lazy<BeforeDeletePipelineExecutionContext>(() => new BeforeDeletePipelineExecutionContext(database, expression, appender, parameterBuilder)), ct).ConfigureAwait(false);
            }

            var rowsAffected = await database.ExecutorFactory.CreateSqlStatementExecutor(expression).ExecuteScalarAsync<int>(
                statement,
                connection,
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

            if (afterDelete is object)
            {
                await afterDelete.InvokeAsync(new Lazy<AfterDeletePipelineExecutionContext>(() => new AfterDeletePipelineExecutionContext(database, expression, statement)), ct).ConfigureAwait(false);
            }

            return rowsAffected;
        }
        #endregion
    }
}
