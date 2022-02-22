using DbEx.Data;
using DbEx.DataService;
using DbEx.dboDataService;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Test
{
    public abstract class TestBase
    {
        public virtual RuntimeSqlDatabaseConfiguration ConfigureForMsSqlVersion(int version, Action<IRuntimeSqlDatabaseConfigurationBuilder> postConfigure = null)
            => ConfigureForMsSqlVersion(version, ConfigurationProvider.ConnectionString, postConfigure);

        public virtual RuntimeSqlDatabaseConfiguration ConfigureForMsSqlVersion(int version, string connectionString)
            => ConfigureForMsSqlVersion(version, connectionString, null);

        public virtual RuntimeSqlDatabaseConfiguration ConfigureForMsSqlVersion(int version, string connectionString, Action<IRuntimeSqlDatabaseConfigurationBuilder> postConfigure = null)
        {
            RuntimeSqlDatabaseConfiguration config = default;
            Action<IRuntimeSqlDatabaseConfigurationBuilder> configureRuntime = database =>
            {
                config = database.Configuration;
                database.ConnectionString.Use(connectionString);

                database.SqlStatements.Assembly.ConfigureOutputSettings(
                    x => x.PrependCommaOnSelectClause = true
                );

                database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForEnumType<PaymentMethodType>().PersistAsString()
                        .OverrideForEnumType<PaymentSourceType>().PersistAsString()
                );

                database.Conversions.UseDefaultFactory(x =>
                    x.OverrideForReferenceType<ProductDescription>().Use(
                        pd => pd is null ? null : System.Text.Json.JsonSerializer.Serialize(pd), 
                        o => string.IsNullOrWhiteSpace(o as string) ? default : System.Text.Json.JsonSerializer.Deserialize<ProductDescription>(o as string))
                    );

                postConfigure?.Invoke(database);
            };

            switch (version)
            {
                case 2005:
                    {
                        dbExpression.Configure(c => c.AddMsSql2005Database<MsSqlDb>(configureRuntime));
                        break;
                    }
                case 2008:
                    {
                        dbExpression.Configure(c => c.AddMsSql2008Database<MsSqlDb>(configureRuntime));
                        break;
                    }
                case 2012:
                    {
                        dbExpression.Configure(c => c.AddMsSql2012Database<MsSqlDb>(configureRuntime));
                        break;
                    }
                case 2014:
                    {
                        dbExpression.Configure(c => c.AddMsSql2014Database<MsSqlDb>(configureRuntime));
                        break;
                    }
                case 2016:
                    {
                        dbExpression.Configure(c => c.AddMsSql2016Database<MsSqlDb>(configureRuntime));
                        break;
                    }
                case 2017:
                    {
                        dbExpression.Configure(c => c.AddMsSql2017Database<MsSqlDb>(configureRuntime));
                        break;
                    }
                case 2019:
                    {
                        dbExpression.Configure(c => c.AddMsSql2019Database<MsSqlDb>(configureRuntime));
                        break;
                    }
                default: throw new NotImplementedException($"MsSql version {version} has not been implemented");
            }
            return config;
        }
    }
}
