using System;
using System.Configuration;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class RuntimeDatabaseMap
    {
        public DatabaseConfiguration DatabaseConfiguration { get; set; }
        public Func<ConnectionStringSettings> ConnectionStringSettings { get; set; }

        public RuntimeDatabaseMap(DatabaseConfiguration config, Func<ConnectionStringSettings> connectionStringSettings)
        {
            DatabaseConfiguration = config;
            ConnectionStringSettings = connectionStringSettings;
        }
    }
}
