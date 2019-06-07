using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class DbExpressionConfigurationBuilder
    {
        public DbExpressionConfigurationBuilder(DbExpressionRuntimeConfiguration config)
        {
            Configuration = config;
        }

        public DbExpressionRuntimeConfiguration Configuration { get; set; }

        public void AddDatabase(string name, DatabaseConfiguration config, Func<ConnectionStringSettings> connectionStringSettingsFactory)
        {
            Configuration.Databases.Add(name, new RuntimeDatabaseMap(config, connectionStringSettingsFactory));
        }

        public static void AddDbExpression(Action<DbExpressionConfigurationBuilder> configure)
        {
            DbExpression.Configuration = new DbExpressionRuntimeConfiguration();
            configure?.Invoke(new DbExpressionConfigurationBuilder(DbExpression.Configuration));
        }
    }
}
