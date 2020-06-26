using HatTrick.DbEx.Sql.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSideBlazorApp
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbExpression(this IServiceCollection services, Action<DbExpressionConfigurationBuilder> configure)
        {
            DbExpressionConfigurationBuilder.AddDbExpression(configure);
        }
    }
}
