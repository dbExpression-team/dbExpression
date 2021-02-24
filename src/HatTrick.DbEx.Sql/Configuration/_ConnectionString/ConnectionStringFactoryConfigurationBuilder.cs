using HatTrick.DbEx.Sql.Connection;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class ConnectionStringFactoryConfigurationBuilder : IConnectionStringFactoryConfigurationBuilder
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        #endregion

        #region constructors
        public ConnectionStringFactoryConfigurationBuilder(RuntimeSqlDatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion

        #region methods
        public void Use(string connectionString)
        {
            configuration.ConnectionStringFactory = new DelegateConnectionStringFactory(() => connectionString);
        }

        public void Use(Func<string> factory)
        {
            configuration.ConnectionStringFactory = new DelegateConnectionStringFactory(factory);
        }

        public void Use(IConnectionStringFactory factory)
        {
            configuration.ConnectionStringFactory = factory;
        }

        public void Use<TConnectionStringFactory>()
            where TConnectionStringFactory : class, IConnectionStringFactory, new()
        {
            if (!(configuration.ConnectionStringFactory is TConnectionStringFactory))
                configuration.ConnectionStringFactory = new TConnectionStringFactory();
        }
        #endregion
    }
}
