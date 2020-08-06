using HatTrick.DbEx.Sql.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ServerSideBlazorApp
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbExpression(this IServiceCollection services, params Action<RuntimeEnvironmentBuilder>[] databases)
        {
            DbExpressionConfigurationBuilder.AddDbExpression(databases);
        }
    }
}
