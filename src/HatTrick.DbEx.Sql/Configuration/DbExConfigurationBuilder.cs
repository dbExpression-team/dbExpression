using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class DbExConfigurationBuilder
    {
        public static void Configure(Action<DbExpressionConfiguration> configure)
        {
            Configure(DbExConfigurationSettings.Settings = new DbExpressionConfiguration(), configure);
        }

        public static void Configure(DbExpressionConfiguration config, Action<DbExpressionConfiguration> configure)
        {
            configure(config);
        }
    }
}
