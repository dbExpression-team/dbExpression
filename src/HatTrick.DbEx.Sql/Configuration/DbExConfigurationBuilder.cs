using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class DbExConfigurationBuilder
    {
        public static void UseDbExpression<T>(Action<DbExpressionConfiguration> configure)
            where T : class, IDatabaseMetadataProvider, new()
        {
            var metadata = new T();
            DbExConfigurationSettings.Settings = new DbExpressionConfiguration { Metadata = metadata };
            configure?.Invoke(DbExConfigurationSettings.Settings);
        }
    }
}
