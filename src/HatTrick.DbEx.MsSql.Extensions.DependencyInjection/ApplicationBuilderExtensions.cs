using HatTrick.DbEx.MsSql.Expression.DependencyInjection.Internal;
using HatTrick.DbEx.Sql.Configuration;
using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseDbExpression(this IApplicationBuilder builder)
        {
            foreach (var runtime in builder.ApplicationServices.GetServices<RuntimeSqlDatabaseConfigurationDependencyInjectionShim>())
            {
                runtime.Database.UseConfigurationFactory(new DelegateRuntimeSqlDatabaseConfigurationFactory(runtime.ConfigurationFactory));
            }
        }
    }
}
