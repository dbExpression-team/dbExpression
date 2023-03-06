using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using System;

namespace HatTrick.DbEx.MsSql.Test
{
    public static class ConfigurationProvider
    {
        private static readonly string ConnectionStringKey = "hattrick_dbex_mssql_test";
        private static IConfiguration? _configuration;

#if NETCOREAPP
        public static IConfiguration Configuration =>  _configuration ?? (_configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                        .AddEnvironmentVariables()
                        .Build());
#else
        public static IConfiguration Configuration
        {

            get
            {
                if (_configuration is not null) return _configuration;
                using var reader = new StreamReader(Directory.GetCurrentDirectory() + "\\appsettings.json");
                _configuration = JsonConvert.DeserializeObject<NetFrameworkConfigurationShim>(reader.ReadToEnd());
                return _configuration!;
            }
        }
#endif

        public static string ConnectionString => Configuration.GetConnectionString(ConnectionStringKey)!;


#if !NETCOREAPP
        /// <summary>
        /// Total kludge to enable use of appsettings.json with net framework test paths.  it's ugly,
        /// brittle, and will require maintenance if appsettings.json changes
        /// </summary>
        public class NetFrameworkConfigurationShim : IConfiguration
        {
            public ConnectionStringsSection ConnectionStrings { get; set; } = new ConnectionStringsSection();

            public string? this[string key] { get => throw new InvalidOperationException($"requested section {key} is not handled by configuration."); set { } }

            public IEnumerable<IConfigurationSection> GetChildren() => throw new System.NotImplementedException();
            public IChangeToken GetReloadToken() => throw new System.NotImplementedException();

            public IConfigurationSection GetSection(string key)
            {
                if (string.Compare(key, nameof(ConnectionStrings), true) == 0)
                    return ConnectionStrings;
                throw new InvalidOperationException($"requested section {key} is not handled by configuration.");
            }

            public class ConnectionStringsSection : IConfigurationSection
            {
                public string hattrick_dbex_mssql_test { get; set; }
                public string? this[string key] { get => hattrick_dbex_mssql_test; set { } }

                public ConnectionStringsSection()
                {
                    hattrick_dbex_mssql_test = Environment.GetEnvironmentVariable(ConnectionStringKey) ?? string.Empty;
                }

                public string Key { get; } = ConnectionStringKey;
                public string Path { get; } = "";
                public string? Value { get => hattrick_dbex_mssql_test; set { } }

                public IEnumerable<IConfigurationSection> GetChildren() => throw new System.NotImplementedException();
                public IChangeToken GetReloadToken() => throw new System.NotImplementedException();
                public IConfigurationSection GetSection(string key) => throw new System.NotImplementedException();
            }
        }
#endif
    }
}
