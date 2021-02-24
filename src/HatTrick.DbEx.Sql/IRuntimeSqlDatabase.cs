using HatTrick.DbEx.Sql.Configuration;
using System;

namespace HatTrick.DbEx.Sql
{
    public interface IRuntimeSqlDatabase
    {
        void UseConfigurationFactory(IRuntimeSqlDatabaseConfigurationFactory configurationFactory);
    }
}
