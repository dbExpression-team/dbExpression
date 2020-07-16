using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IDbExpressionRuntimeEnvironmentBuilder
    {
        RuntimeDatabaseConfigurationBuilder ConfigureSqlDatabase(IRuntimeSqlDatabase database, Action<RuntimeDatabaseConfigurationBuilder> configure);
    }
}
