using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IRuntimeEnvironmentBuilder
    {
        RuntimeDatabaseConfigurationBuilder ConfigureSqlDatabase(IRuntimeSqlDatabase database, Action<RuntimeDatabaseConfigurationBuilder> configure);
    }
}
