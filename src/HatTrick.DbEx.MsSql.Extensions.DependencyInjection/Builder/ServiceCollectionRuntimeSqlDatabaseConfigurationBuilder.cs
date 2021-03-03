using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HatTrick.DbEx.MsSql.Microsoft.Extensions.DependencyInjection.Builder
{
    internal sealed class ServiceCollectionRuntimeSqlDatabaseConfigurationBuilder : RuntimeSqlDatabaseConfigurationBuilder, IDbExpressionConfigurationBuilder
    {
        public IServiceCollection Services { get; private set; }
        public IRuntimeEnvironmentSqlDatabase Environment { get; set; }

        public ServiceCollectionRuntimeSqlDatabaseConfigurationBuilder(IServiceCollection services, RuntimeSqlDatabaseConfiguration configuration) : base(configuration)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }        
    }
}
