using HatTrick.DbEx.Sql.Configuration;
using System.Configuration;

namespace HatTrick.DbEx.Sql.Extensions.Configuration
{
    public static class DbExpressionConfigurationBuilderExtensions
    {
        public static void UseConnectionStringsFromAppConfig(this DbExpressionConfigurationBuilder config)
        {
            config.AddConnectionString(ConfigurationManager.ConnectionStrings);
        }
    }
}
