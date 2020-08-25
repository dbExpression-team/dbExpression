using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IRuntimeEnvironmentBuilder
    {
        RuntimeSqlDatabaseConfigurationBuilder ConfigureSqlDatabase(IRuntimeSqlDatabase database, Action<RuntimeSqlDatabaseConfigurationBuilder> configure);
    }
}
