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
        private static readonly string MsSqlVersion_Variant1 = "MSSQL_VERSION";
        private static readonly string MsSqlVersion_Variant2 = "MsSqlVersion";
        private static IConfiguration? _configuration;
        private static int? _msSqlVersion;

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

        public static int? MsSqlVersion => _msSqlVersion ?? (_msSqlVersion = Configuration.GetValue(MsSqlVersion_Variant1, Configuration.GetValue(MsSqlVersion_Variant2,
            (int?)null)));


#if !NETCOREAPP
        /// <summary>
        /// Total kludge to enable use of appsettings.json with net framework test paths.  it's ugly,
        /// brittle, and will require maintenance if appsettings.json or env variables change
        /// </summary>
        public class NetFrameworkConfigurationShim : IConfiguration
        {
            public ConnectionStringsSection ConnectionStrings { get; set; } = new ConnectionStringsSection();
            public string MsSqlVersion { get; set; } = string.Empty;
            private MsSqlVersionSection _msSqlVersionSection => new MsSqlVersionSection(MsSqlVersion ?? Environment.GetEnvironmentVariable(MsSqlVersion_Variant1) ?? Environment.GetEnvironmentVariable(MsSqlVersion_Variant2));

            public string? this[string key] { get => throw new InvalidOperationException($"requested section {key} is not handled by configuration."); set { } }

            public IEnumerable<IConfigurationSection> GetChildren() => throw new System.NotImplementedException();
            public IChangeToken GetReloadToken() => throw new System.NotImplementedException();

            public IConfigurationSection GetSection(string key)
            {
                if (string.Compare(key, MsSqlVersion_Variant1, true) == 0 || string.Compare(key, MsSqlVersion_Variant2, true) == 0)
                    return _msSqlVersionSection;
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

            public class MsSqlVersionSection : IConfigurationSection
            {
                public string MsSqlVersion { get; set; }
                public string? this[string key] { get => MsSqlVersion; set { } }

                public MsSqlVersionSection()
                {
                    MsSqlVersion = Environment.GetEnvironmentVariable(MsSqlVersion_Variant1) ?? Environment.GetEnvironmentVariable(MsSqlVersion_Variant2);
                }

                public MsSqlVersionSection(string version)
                {
                    MsSqlVersion = version;
                }

                public string Key { get; } = string.Empty;
                public string Path { get; } = string.Empty;
                public string? Value { get; set; } = string.Empty;

                public IEnumerable<IConfigurationSection> GetChildren() => throw new System.NotImplementedException();
                public IChangeToken GetReloadToken() => throw new System.NotImplementedException();
                public IConfigurationSection GetSection(string key) => throw new System.NotImplementedException();
            }
        }
#endif
    }
}
