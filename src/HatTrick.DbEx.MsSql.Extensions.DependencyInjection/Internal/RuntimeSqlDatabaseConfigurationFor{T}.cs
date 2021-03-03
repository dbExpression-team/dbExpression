using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Configuration;
using System;

namespace HatTrick.DbEx.MsSql.Expression.DependencyInjection.Internal
{
    internal class RuntimeSqlDatabaseConfigurationFor<T>
        where T : class, IRuntimeEnvironmentSqlDatabase
    {
        #region interface
        public T Database { get; private set; }
        public RuntimeSqlDatabaseConfiguration Configuration { get; private set; }
        #endregion

        #region constructors
        public RuntimeSqlDatabaseConfigurationFor(T database, RuntimeSqlDatabaseConfiguration configuration)
        {
            this.Database = database ?? throw new ArgumentNullException(nameof(database));
            this.Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        #endregion
    }
}
