using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace HatTrick.DbEx.MsSql.Test
{
    public static class ConfigurationProvider
    {
        private static readonly string ConnectionStringKey = "hattrick_dbex_mssql_test";
        private static IConfiguration _configuration;
        private static int? _msSqlVersion;

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

        public static string ConnectionString =>  Configuration.GetConnectionString(ConnectionStringKey);

        public static int? MsSqlVersion
        {
            get
            {
                if (_msSqlVersion != null)
                    return _msSqlVersion;

                return _msSqlVersion = Configuration.GetValue("MsSqlVersion", (int?)null);
            }
        }
    }
}
