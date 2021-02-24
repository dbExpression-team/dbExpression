using HatTrick.DbEx.Sql.Connection;
using System;
using System.Data;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class SqlConnectionFactoryConfigurationBuilder : ISqlConnectionFactoryConfigurationBuilder
    {
        #region internals
        private readonly ISqlStatementExecutionGroupingConfigurationBuilders caller;
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        #endregion

        #region constructors
        public SqlConnectionFactoryConfigurationBuilder(ISqlStatementExecutionGroupingConfigurationBuilders caller, RuntimeSqlDatabaseConfiguration configuration)
        {
            this.caller = caller ?? throw new ArgumentNullException($"{nameof(caller)} is required.");
            this.configuration = configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.");
        }
        #endregion

        #region methods
        public ISqlStatementExecutionGroupingConfigurationBuilders Use(ISqlConnectionFactory factory)
        {
            configuration.ConnectionFactory = factory;
            return caller;
        }

        public ISqlStatementExecutionGroupingConfigurationBuilders Use<TSqlConnectionFactory>()
            where TSqlConnectionFactory : class, ISqlConnectionFactory, new()
            => Use<TSqlConnectionFactory>(null);

        public ISqlStatementExecutionGroupingConfigurationBuilders Use<TSqlConnectionFactory>(Action<TSqlConnectionFactory> configureFactory)
            where TSqlConnectionFactory : class, ISqlConnectionFactory, new()
        {
            if (!(configuration.ConnectionFactory is TSqlConnectionFactory))
                configuration.ConnectionFactory = new TSqlConnectionFactory();
            configureFactory?.Invoke(configuration.ConnectionFactory as TSqlConnectionFactory);
            return caller;
        }

        public ISqlStatementExecutionGroupingConfigurationBuilders Use(Func<string, IDbConnection> factory)
        {
            configuration.ConnectionFactory = new DelegateSqlConnectionFactory(factory ?? throw new ArgumentNullException($"{nameof(factory)} is required."));
            return caller;
        }
        #endregion
    }
}
