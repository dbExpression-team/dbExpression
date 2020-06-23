using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace HatTrick.DbEx.MsSql.Test
{
    public static class ConfigurationProvider
    {
        private static readonly string ConnectionStringKey = "hattrick_dbex_mssql_test";
        private static IConfiguration _configuration;
        private static ConnectionStringSettings _connectionStringSettings;
        private static int? _msSqlVersion;
        private static string _databaseMapName;

        public static IConfiguration Configuration
        {
            get
            {
                if (_configuration != null)
                    return _configuration;

                return _configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                        .AddEnvironmentVariables()
                        .Build();
            }
        }

        public static ConnectionStringSettings ConnectionStringSettings
        {
            get
            {
                if (_connectionStringSettings != null)
                    return _connectionStringSettings;

                var connectionString = Configuration.GetConnectionString(ConnectionStringKey);

                return _connectionStringSettings = new ConnectionStringSettings(ConnectionStringKey, connectionString);
            }
        }

        public static int? MsSqlVersion
        {
            get
            {
                if (_msSqlVersion != null)
                    return _msSqlVersion;

                return _msSqlVersion = Configuration.GetValue("MsSqlVersion", (int?)null);
            }
        }

        public static string DatabaseMapName
        {
            get
            {
                if (_databaseMapName != null)
                    return _databaseMapName;

                return _databaseMapName = Configuration.GetValue("DatabaseMapName", "MsSqlDbExTest-design");
            }
        }
    }
}
