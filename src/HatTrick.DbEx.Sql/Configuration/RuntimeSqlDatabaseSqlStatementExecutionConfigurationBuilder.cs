using HatTrick.DbEx.Sql.Configuration.Syntax;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class RuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder : IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        #endregion

        #region constructors
        public RuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder(RuntimeSqlDatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion

        #region methods
        #region execution
        public IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder UseThisToCreateNewSqlStatementExecutors(ISqlStatementExecutorFactory factory)
        {
            configuration.ExecutorFactory = factory;
            return this;
        }

        public IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder UseThisToCreateNewSqlStatementExecutors<T>()
            where T : class, ISqlStatementExecutorFactory, new()
        {
            configuration.ExecutorFactory = new T();
            if (configuration.ExecutorFactory is SqlStatementExecutorFactory defaultFactory)
                defaultFactory.RegisterDefaultExecutors();
            return this;
        }

        public IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder UseThisToCreateNewSqlStatementExecutors(Func<QueryExpression,ISqlStatementExecutor> factory)
        {
            configuration.ExecutorFactory = new DelegateSqlStatementExecutorFactory(factory);
            return this;
        }

        public IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder UseThisToCreateNewSqlStatementExecutors(Func<ISqlStatementExecutorFactory> factory)
        {
            configuration.ExecutorFactory = new DelegateSqlStatementExecutorFactory(factory);
            return this;
        }

        public IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder UseThisToCreateNewExecutionPipelines(IExecutionPipelineFactory factory)
        {
            configuration.ExecutionPipelineFactory = factory;
            return this;
        }

        public IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder UseThisToCreateNewExecutionPipelines<T>()
            where T : class, IExecutionPipelineFactory, new()
        {
            var factory = new T();
            configuration.ExecutionPipelineFactory = factory;
            return this;
        }
        #endregion

        #region connection
        public IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder UseThisToCreateNewSqlConnections(ISqlConnectionFactory factory)
        {
            configuration.ConnectionFactory = factory;
            return this;
        }

        public IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder UseThisToCreateNewSqlConnections<T>()
            where T : ISqlConnectionFactory, new()
        {
            var factory = new T();
            configuration.ConnectionFactory = factory;
            return this;
        }

        public IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder UseThisToCreateNewSqlConnections(Func<SqlConnection> factory)
        {
            configuration.ConnectionFactory = new DelegateSqlConnectionFactory(factory);
            return this;
        }

        public IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder UseThisToAccessAConnectionFactoryToCreateNewSqlConnections(Func<ISqlConnectionFactory> factory)
        {
            configuration.ConnectionFactory = new DelegateSqlConnectionFactory(factory);
            return this;
        }
        #endregion

        #region events
        public IPipelineEventActionBuilder<BeforeAssemblyPipelineExecutionContext> BeforeAssemblingSqlStatement(Action<BeforeAssemblyPipelineExecutionContext> action)
            => new PipelineEventActionBuilder<Func<BeforeAssemblyPipelineExecutionContext, CancellationToken, Task>,Action<BeforeAssemblyPipelineExecutionContext>, BeforeAssemblyPipelineExecutionContext>(
                    this, 
                    configuration.ExecutionPipelineFactory.BeforeAssembly.AddToEnd(action)
                );

        public IPipelineEventActionBuilder<AfterAssemblyPipelineExecutionContext> AfterAssemblingSqlStatement(Action<AfterAssemblyPipelineExecutionContext> action)
            => new PipelineEventActionBuilder<Func<AfterAssemblyPipelineExecutionContext, CancellationToken, Task>, Action<AfterAssemblyPipelineExecutionContext>, AfterAssemblyPipelineExecutionContext>(
                    this, 
                    configuration.ExecutionPipelineFactory.AfterAssembly.AddToEnd(action)
                );

        public IPipelineEventActionBuilder<BeforeInsertPipelineExecutionContext> BeforeInsertingEntity(Action<BeforeInsertPipelineExecutionContext> action)
            => new PipelineEventActionBuilder<Func<BeforeInsertPipelineExecutionContext, CancellationToken, Task>, Action<BeforeInsertPipelineExecutionContext>, BeforeInsertPipelineExecutionContext>(
                    this, 
                    configuration.ExecutionPipelineFactory.BeforeInsert.AddToEnd(action)
                );

        public IPipelineEventActionBuilder<AfterInsertPipelineExecutionContext> AfterInsertingEntity(Action<AfterInsertPipelineExecutionContext> action)
            => new PipelineEventActionBuilder<Func<AfterInsertPipelineExecutionContext, CancellationToken, Task>, Action<AfterInsertPipelineExecutionContext>, AfterInsertPipelineExecutionContext>(
                    this, 
                    configuration.ExecutionPipelineFactory.AfterInsert.AddToEnd(action)
                );

        public IPipelineEventActionBuilder<BeforeUpdatePipelineExecutionContext> BeforeUpdatingEntity(Action<BeforeUpdatePipelineExecutionContext> action)
            => new PipelineEventActionBuilder<Func<BeforeUpdatePipelineExecutionContext, CancellationToken, Task>, Action<BeforeUpdatePipelineExecutionContext>, BeforeUpdatePipelineExecutionContext>(
                    this, 
                    configuration.ExecutionPipelineFactory.BeforeUpdate.AddToEnd(action)
                );

        public IPipelineEventActionBuilder<AfterUpdatePipelineExecutionContext> AfterUpdatingEntity(Action<AfterUpdatePipelineExecutionContext> action)
            => new PipelineEventActionBuilder<Func<AfterUpdatePipelineExecutionContext, CancellationToken, Task>, Action<AfterUpdatePipelineExecutionContext>, AfterUpdatePipelineExecutionContext>(
                    this, 
                    configuration.ExecutionPipelineFactory.AfterUpdate.AddToEnd(action)
                );

        public IPipelineEventActionBuilder<BeforeDeletePipelineExecutionContext> BeforeDeletingEntity(Action<BeforeDeletePipelineExecutionContext> action)
            => new PipelineEventActionBuilder<Func<BeforeDeletePipelineExecutionContext, CancellationToken, Task>, Action<BeforeDeletePipelineExecutionContext>, BeforeDeletePipelineExecutionContext>(
                    this, 
                    configuration.ExecutionPipelineFactory.BeforeDelete.AddToEnd(action)
                );

        public IPipelineEventActionBuilder<AfterDeletePipelineExecutionContext> AfterDeletingEntity(Action<AfterDeletePipelineExecutionContext> action)
            => new PipelineEventActionBuilder<Func<AfterDeletePipelineExecutionContext, CancellationToken, Task>, Action<AfterDeletePipelineExecutionContext>, AfterDeletePipelineExecutionContext>(
                    this,
                    configuration.ExecutionPipelineFactory.AfterDelete.AddToEnd(action)
                );

        public IPipelineEventActionBuilder<BeforeSelectPipelineExecutionContext> BeforeSelectingEntity(Action<BeforeSelectPipelineExecutionContext> action)
            => new PipelineEventActionBuilder<Func<BeforeSelectPipelineExecutionContext, CancellationToken, Task>, Action<BeforeSelectPipelineExecutionContext>, BeforeSelectPipelineExecutionContext>(
                    this,
                    configuration.ExecutionPipelineFactory.BeforeSelect.AddToEnd(action)
                );

        public IPipelineEventActionBuilder<AfterSelectPipelineExecutionContext> AfterSelectingEntity(Action<AfterSelectPipelineExecutionContext> action)
             => new PipelineEventActionBuilder<Func<AfterSelectPipelineExecutionContext, CancellationToken, Task>, Action<AfterSelectPipelineExecutionContext>, AfterSelectPipelineExecutionContext>(
                    this,
                    configuration.ExecutionPipelineFactory.AfterSelect.AddToEnd(action)
                );

        public IPipelineEventActionBuilder<BeforeExecutionPipelineExecutionContext> BeforeExecutingCommand(Action<BeforeExecutionPipelineExecutionContext> action)
             => new PipelineEventActionBuilder<Func<BeforeExecutionPipelineExecutionContext, CancellationToken, Task>, Action<BeforeExecutionPipelineExecutionContext>, BeforeExecutionPipelineExecutionContext>(
                    this,
                    configuration.ExecutionPipelineFactory.BeforeExecution.AddToEnd(action)
                );

        public IPipelineEventActionBuilder<AfterExecutionPipelineExecutionContext> AfterExecutingCommand(Action<AfterExecutionPipelineExecutionContext> action)
             => new PipelineEventActionBuilder<Func<AfterExecutionPipelineExecutionContext, CancellationToken, Task>, Action<AfterExecutionPipelineExecutionContext>, AfterExecutionPipelineExecutionContext>(
                    this,
                    configuration.ExecutionPipelineFactory.AfterExecution.AddToEnd(action)
                );
        #endregion
        #endregion
    }
}
