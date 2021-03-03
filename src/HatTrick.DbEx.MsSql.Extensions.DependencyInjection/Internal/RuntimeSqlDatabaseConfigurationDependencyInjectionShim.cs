using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Configuration;
using System;

namespace HatTrick.DbEx.MsSql.Expression.DependencyInjection.Internal
{
    internal class RuntimeSqlDatabaseConfigurationDependencyInjectionShim
    {
        #region interface
        public IRuntimeSqlDatabase Database { get; private set; }
        public Func<RuntimeSqlDatabaseConfiguration> ConfigurationFactory { get; private set; }
        #endregion

        #region constructors
        public RuntimeSqlDatabaseConfigurationDependencyInjectionShim(IRuntimeSqlDatabase database, Func<RuntimeSqlDatabaseConfiguration> configurationFactory)
        {
            this.Database = database ?? throw new ArgumentNullException(nameof(database));
            this.ConfigurationFactory = configurationFactory ?? throw new ArgumentNullException(nameof(configurationFactory));
        }
        #endregion
    }
}
