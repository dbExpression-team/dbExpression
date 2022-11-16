using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace HatTrick.DbEx.MsSql.Test
{
    public static class ConfigurationProvider
    {
        private static readonly string ConnectionStringKey = "hattrick_dbex_mssql_test";
        private static IConfiguration? _configuration;
        private static int? _msSqlVersion;

        public static IConfiguration Configuration =>  _configuration ??= new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                        .AddEnvironmentVariables()
                        .Build();

        public static string ConnectionString => Configuration.GetConnectionString(ConnectionStringKey)!;

        public static int? MsSqlVersion =>  _msSqlVersion ??= Configuration.GetValue("MSSQL_VERSION", (int?)null);
    }
}
