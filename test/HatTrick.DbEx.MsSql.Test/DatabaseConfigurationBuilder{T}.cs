using DbEx.Data;
using DbEx.DataService;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HatTrick.DbEx.MsSql.Test
{
    public class DatabaseConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        public virtual (TDatabase db, IServiceProvider serviceProvider) ForMsSqlVersion(int version, Action<ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>>? configure = null)
               => ForMsSqlVersion(version, ConfigurationProvider.ConnectionString, configure);

        public virtual (TDatabase db, IServiceProvider serviceProvider) ForMsSqlVersion(int version, string connectionString)
            => ForMsSqlVersion(version, connectionString, null);

        public virtual (TDatabase db, IServiceProvider serviceProvider) ForMsSqlVersion(int version, string connectionString, Action<ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>>? configure = null)
        {
            var services = new ServiceCollection();
            void configureRuntime(ISqlDatabaseRuntimeConfigurationBuilder<TDatabase> database)
            {
                configure?.Invoke(database);

                database.ConnectionString.Use(connectionString);

                database.SqlStatements.Assembly.ConfigureAssemblyOptions(
                    x => x.PrependCommaOnSelectClause = false
                );

                if (typeof(TDatabase) == typeof(MsSqlDb))
                {
                    database.Conversions.ForTypes(x => x
                    .ForEnumType<PaymentMethodType>().PersistAsString()
                    .ForEnumType<PaymentSourceType>().PersistAsString()
                    .ForReferenceType<ProductDescription>().Use(
                        pd => pd is null ? null : System.Text.Json.JsonSerializer.Serialize(pd),
                        o => string.IsNullOrWhiteSpace(o as string) ? default : System.Text.Json.JsonSerializer.Deserialize<ProductDescription>((o as string)!)
                        )
                    );
                }
            }

            services.AddDbExpression(c => c.AddDatabase<TDatabase>(configureRuntime, version.ToString()));

            var serviceProvider = services.BuildServiceProvider();
            return (serviceProvider.GetRequiredService<TDatabase>(), serviceProvider);
        }
    }
}
