using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class DbExpressionConfigurationBuilder
    {
        public DbExpressionConfigurationBuilder(DbExpressionRuntimeConfiguration config)
        {
            Configuration = config;
        }

        public DbExpressionRuntimeConfiguration Configuration { get; set; }

        public void AddDatabase(string name, DatabaseConfiguration config)
        {
            Configuration.Databases.Add(name, config);
        }

        public static void AddDbExpression(Action<DbExpressionConfigurationBuilder> configure)
        {
            DbExpression.Configuration = new DbExpressionRuntimeConfiguration();
            configure?.Invoke(new DbExpressionConfigurationBuilder(DbExpression.Configuration));
        }
    }
}
