using HatTrick.DbEx.Sql.Configuration;
using System.Collections.Generic;
using System.Configuration;

namespace HatTrick.DbEx.Sql.Extensions.Configuration
{
    public static class DbExpressionConfigurationExtensions
    {
        public static void UseConnectionStringsFromAppConfig(this DbExpressionConfiguration settings)
        {
            settings.ConnectionStringSettings = new Dictionary<string, ConnectionStringSettings>();
            foreach (ConnectionStringSettings cs in ConfigurationManager.ConnectionStrings)
                settings.ConnectionStringSettings.Add(cs.Name, cs);
        }
    }
}
