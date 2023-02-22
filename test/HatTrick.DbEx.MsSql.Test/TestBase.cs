using DbEx.Data;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using HatTrick.DbEx.MsSql.Configuration;

namespace HatTrick.DbEx.MsSql.Test
{
    public abstract class TestBase
    {
        protected TestBase()
        {
            v2005DbEx.DataService.db.DiscardDatabase();
            v2008DbEx.DataService.db.DiscardDatabase();
            v2012DbEx.DataService.db.DiscardDatabase();
            v2014DbEx.DataService.db.DiscardDatabase();
            v2016DbEx.DataService.db.DiscardDatabase();
            v2017DbEx.DataService.db.DiscardDatabase();
            v2019DbEx.DataService.db.DiscardDatabase();
            v2022DbEx.DataService.db.DiscardDatabase();
        }

        public static (TDatabase db, IServiceProvider serviceProvider) Configure<TDatabase>(Action<ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>>? configure = null)
               where TDatabase : class, ISqlDatabaseRuntime
            => Configure<TDatabase>(ConfigurationProvider.ConnectionString, configure);

        public static (TDatabase db, IServiceProvider serviceProvider) Configure<TDatabase>(string connectionString)
            where TDatabase : class, ISqlDatabaseRuntime
            => Configure<TDatabase>(connectionString, null);

        public static (TDatabase db, IServiceProvider serviceProvider) Configure<TDatabase>(string connectionString, Action<ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>>? configure = null)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            var services = new ServiceCollection();
            void configureRuntime(ISqlDatabaseRuntimeConfigurationBuilder<TDatabase> database)
            {
                configure?.Invoke(database);

                database.ConnectionString.Use(connectionString);

                database.SqlStatements.Assembly.ConfigureAssemblyOptions(
                    x => x.PrependCommaOnSelectClause = false
                );

                database.Conversions.ForTypes(x => x
                    .ForEnumType<PaymentMethodType>().PersistAsString()
                    .ForEnumType<PaymentSourceType>().PersistAsString()
                    .ForReferenceType<ProductDescription>().Use(
                        pd => pd is null ? null : System.Text.Json.JsonSerializer.Serialize(pd),
                        o => string.IsNullOrWhiteSpace(o as string) ? default : System.Text.Json.JsonSerializer.Deserialize<ProductDescription>((o as string)!)
                        )
                    );
            }

            services.AddDbExpression(c => c.AddDatabase<TDatabase>(configureRuntime));

            var serviceProvider = services.BuildServiceProvider();
            return (serviceProvider.GetRequiredService<TDatabase>(), serviceProvider);
        }
    }
}
