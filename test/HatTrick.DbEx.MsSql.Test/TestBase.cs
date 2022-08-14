using DbEx.Data;
using DbEx.DataService;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HatTrick.DbEx.MsSql.Test
{
    public abstract class TestBase
    {
        public virtual (TDatabase db, IServiceProvider serviceProvider) ConfigureForMsSqlVersion<TDatabase>(int version, Action<ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>>? configure = null)
            where TDatabase : class, ISqlDatabaseRuntime
            => ConfigureForMsSqlVersion<TDatabase>(version, ConfigurationProvider.ConnectionString, configure);

        public virtual (TDatabase db, IServiceProvider serviceProvider) ConfigureForMsSqlVersion<TDatabase>(int version, string connectionString)
            where TDatabase : class, ISqlDatabaseRuntime
            => ConfigureForMsSqlVersion<TDatabase>(version, connectionString, null);

        public virtual (TDatabase db, IServiceProvider serviceProvider) ConfigureForMsSqlVersion<TDatabase>(int version, string connectionString, Action<ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>>? configure = null)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            var services = new ServiceCollection();
            void configureRuntime(ISqlDatabaseRuntimeConfigurationBuilder<TDatabase> database)
            {
                configure?.Invoke(database);

                database.ConnectionString.Use(connectionString);

                database.SqlStatements.Assembly.ConfigureOutputSettings(
                    x => x.PrependCommaOnSelectClause = true
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

            switch (version)
            {
                case 2005: services.AddDbExpression(c => c.AddMsSql2005Database<TDatabase>(configureRuntime)); break;
                case 2008: services.AddDbExpression(c => c.AddMsSql2008Database<TDatabase>(configureRuntime)); break;
                case 2012: services.AddDbExpression(c => c.AddMsSql2012Database<TDatabase>(configureRuntime)); break;
                case 2014: services.AddDbExpression(c => c.AddMsSql2014Database<TDatabase>(configureRuntime)); break;
                case 2016: services.AddDbExpression(c => c.AddMsSql2016Database<TDatabase>(configureRuntime)); break;
                case 2017: services.AddDbExpression(c => c.AddMsSql2017Database<TDatabase>(configureRuntime)); break;
                case 2019: services.AddDbExpression(c => c.AddMsSql2019Database<TDatabase>(configureRuntime)); break;
                default: throw new NotImplementedException($"MsSql version {version} has not been implemented");
            };

            var serviceProvider = services.BuildServiceProvider();
            return (serviceProvider.GetRequiredService<TDatabase>(), serviceProvider);
        }
    }
}
