using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class DelegateRuntimeSqlDatabaseConfigurationFactory : IRuntimeSqlDatabaseConfigurationFactory
    {
        #region interface
        public Func<RuntimeSqlDatabaseConfiguration> ConfigurationFactory { get; private set; }
        #endregion

        #region constructors
        public DelegateRuntimeSqlDatabaseConfigurationFactory(Func<RuntimeSqlDatabaseConfiguration> configurationFactory)
        {
            this.ConfigurationFactory = configurationFactory ?? throw new ArgumentNullException($"{nameof(configurationFactory)} is required.");
        }
        #endregion

        #region methods
        public virtual RuntimeSqlDatabaseConfiguration CreateConfiguration() => ConfigurationFactory();
        #endregion
    }
}
