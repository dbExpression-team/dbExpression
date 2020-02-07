using DbEx.DataService;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;

namespace HatTrick.DbEx.MsSql.Test
{
    public abstract class TestBase
    {
        private static readonly object @lock = new object();
        private static readonly string ConnectionStringKey = "hattrick.dbex.mssql.test";
        private static readonly string DatabaseMapName = "MsSqlDbExTest-design";
        private static ConnectionStringSettings _connectionStringSettings;

        protected ConnectionStringSettings ConnectionStringSettings
        {
            get
            {
                if (_connectionStringSettings != null)
                    return _connectionStringSettings;

                var connectionString = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                        .Build()
                        .GetConnectionString(ConnectionStringKey);

                return _connectionStringSettings = new ConnectionStringSettings(ConnectionStringKey, connectionString);
            }
        }

        public virtual DatabaseConfiguration ConfigureForMsSqlVersion(int version)
        {
            lock (@lock)
            {
                switch (version)
                {
                    case 2012:
                        {
                            DbExpressionConfigurationBuilder.AddDbExpression(c =>
                            {
                                c.AddMsSql2012Database<MsSqlDbExTestDatabaseMetadataProvider>(
                                    ConnectionStringSettings,
                                    "MsSqlDbExTest-design"
                                );
                            });
                            return DbExpression.Configuration.Databases[DatabaseMapName].DatabaseConfiguration;
                        }
                    case 2014:
                        {
                            DbExpressionConfigurationBuilder.AddDbExpression(c =>
                            {
                                c.AddMsSql2014Database<MsSqlDbExTestDatabaseMetadataProvider>(
                                    ConnectionStringSettings,
                                    "MsSqlDbExTest-design"
                                );
                            });
                            return DbExpression.Configuration.Databases[DatabaseMapName].DatabaseConfiguration;
                        }
                }
                throw new NotImplementedException($"MsSql version {version} has not been implemented");
            }
        }
    }
}
