using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class SqlStatementFactoryConfigurationBuilder : ISqlStatementFactoryConfigurationBuilder
    {
        #region internals
        private readonly ISqlStatementExecutionGroupingConfigurationBuilders caller;
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        #endregion

        #region constructors
        public SqlStatementFactoryConfigurationBuilder(ISqlStatementExecutionGroupingConfigurationBuilders caller, RuntimeSqlDatabaseConfiguration configuration)
        {
            this.caller = caller ?? throw new ArgumentNullException($"{nameof(caller)} is required.");
            this.configuration = configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.");
        }
        #endregion

        #region methods
        public ISqlStatementExecutionGroupingConfigurationBuilders Use(ISqlStatementExecutorFactory factory)
        {
            configuration.ExecutorFactory = factory ?? throw new ArgumentNullException($"{nameof(factory)} is required.");
            return caller;
        }

        public ISqlStatementExecutionGroupingConfigurationBuilders Use<TSqlStatementExecutorFactory>()
            where TSqlStatementExecutorFactory : class, ISqlStatementExecutorFactory, new()
            => Use<TSqlStatementExecutorFactory>(null);

        public ISqlStatementExecutionGroupingConfigurationBuilders Use<TSqlStatementExecutorFactory>(Action<TSqlStatementExecutorFactory> configureFactory)
            where TSqlStatementExecutorFactory : class, ISqlStatementExecutorFactory, new()
        {
            if (!(configuration.ExecutorFactory is TSqlStatementExecutorFactory))
                configuration.ExecutorFactory = new TSqlStatementExecutorFactory();
            configureFactory?.Invoke(configuration.ExecutorFactory as TSqlStatementExecutorFactory);
            return caller;
        }

        public ISqlStatementExecutionGroupingConfigurationBuilders Use(Func<QueryExpression, ISqlStatementExecutor> factory)
        {
            configuration.ExecutorFactory = new DelegateSqlStatementExecutorFactory(factory ?? throw new ArgumentNullException($"{nameof(factory)} is required."));
            return caller;
        }

        public ISqlStatementExecutionGroupingConfigurationBuilders UseDefaultFactory()
        {
            configuration.ExecutorFactory = new SqlStatementExecutorFactory();
            return caller;
        }
        #endregion
    }
}
