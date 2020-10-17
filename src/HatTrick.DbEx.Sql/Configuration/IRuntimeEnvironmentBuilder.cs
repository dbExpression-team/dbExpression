using HatTrick.DbEx.Sql.Configuration.Syntax;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IRuntimeEnvironmentBuilder
    {
        IRuntimeSqlDatabaseConfigurationBuilder ConfigureSqlDatabase(IRuntimeSqlDatabase database, Action<IRuntimeSqlDatabaseConfigurationBuilder> configure);
    }
}
