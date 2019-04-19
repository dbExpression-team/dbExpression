using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class DbExpressionConfigurationBuilder
    {
        public DbExpressionConfigurationBuilder(DbExpressionConfiguration config)
        {
            Configuration = config;
        }

        public DbExpressionConfiguration Configuration { get; set; }

        public void AddDatabase(string name, DatabaseConfiguration config)
        {
            Configuration.Databases.Add(name, config);
        }

        public void AddConnectionString(string name, string connectionString)
        {
            Configuration.ConnectionStringSettings.Add(name, new ConnectionStringSettings(name, connectionString));
        }

        public void AddConnectionString(ConnectionStringSettings connectionString)
        {
            Configuration.ConnectionStringSettings.Add(connectionString.Name, connectionString);
        }

        public void AddConnectionString(ConnectionStringSettingsCollection connectionStrings)
        {
            foreach (ConnectionStringSettings connectionString in connectionStrings)
                Configuration.ConnectionStringSettings.Add(connectionString.Name, connectionString);
        }

        public static void AddDbExpression(Action<DbExpressionConfigurationBuilder> configure)
        {
            DbExpression.Configuration = new DbExpressionConfiguration();
            configure?.Invoke(new DbExpressionConfigurationBuilder(DbExpression.Configuration));
        }
    }
}
