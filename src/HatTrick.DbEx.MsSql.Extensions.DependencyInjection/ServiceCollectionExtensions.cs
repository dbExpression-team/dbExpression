using HatTrick.DbEx.MsSql.Microsoft.Extensions.DependencyInjection.Builder;
using HatTrick.DbEx.Sql.Configuration;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbExpression(this IServiceCollection services, params Action<IDbExpressionConfigurationBuilder>[] databases)
        {
            foreach (var database in databases)
                database.Invoke(new ServiceCollectionRuntimeSqlDatabaseConfigurationBuilder(services, new RuntimeSqlDatabaseConfiguration()));
        }
    }
}
