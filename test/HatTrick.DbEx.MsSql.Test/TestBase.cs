using DbEx.Data;
using DbEx.DataService;
using DbEx.dboDataService;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Configuration.Syntax;
using HatTrick.DbEx.Sql.Converter;
using System;

namespace HatTrick.DbEx.MsSql.Test
{
    public abstract class TestBase
    {
        public virtual RuntimeSqlDatabaseConfiguration ConfigureForMsSqlVersion(int version, Action<IRuntimeSqlDatabaseConfigurationBuilder> postConfigure = null)
        {
            RuntimeSqlDatabaseConfiguration config = null;
            Action<IRuntimeSqlDatabaseConfigurationBuilder> configureRuntime = database =>
            {
                config = (database as IRuntimeSqlDatabaseConfigurationProvider).Configuration;

                database.WhenAssemblingSqlStatements.ConfigureAttributesOfAssemblingSqlStatements(a => a.PrependCommaOnSelectClauseParts = true);

                database.WhenMappingData.ForType<PaymentMethodType>().UseConverter<StringEnumValueConverter>();
                database.WhenMappingData.ForEnumType<PaymentSourceType>().PersistTheEnumValueAsString();

                postConfigure?.Invoke(database);
            };

            switch (version)
            {
                case 2005:
                    {
                        dbExpression.ConfigureRuntime(c =>
                        {
                            c.AddMsSql2005Database<MsSqlDb>(
                                ConfigurationProvider.ConnectionString,
                                configureRuntime
                            );
                        });
                        break;
                    }
                case 2008:
                    {
                        dbExpression.ConfigureRuntime(c =>
                        {
                            c.AddMsSql2008Database<MsSqlDb>(
                                ConfigurationProvider.ConnectionString,
                                configureRuntime
                            );
                        });
                        break;
                    }
                case 2012:
                    {
                        dbExpression.ConfigureRuntime(c =>
                        {
                            c.AddMsSql2012Database<MsSqlDb>(
                                ConfigurationProvider.ConnectionString,
                                configureRuntime
                            );
                        });
                        break;
                    }
                case 2014:
                    {
                        dbExpression.ConfigureRuntime(c =>
                        {
                            c.AddMsSql2014Database<MsSqlDb>(
                                ConfigurationProvider.ConnectionString,
                                configureRuntime
                            );
                        });
                        break;
                    }
                case 2016:
                    {
                        dbExpression.ConfigureRuntime(c =>
                        {
                            c.AddMsSql2016Database<MsSqlDb>(
                                ConfigurationProvider.ConnectionString,
                                configureRuntime
                            );
                        });
                        break;
                    }
                case 2017:
                    {
                        dbExpression.ConfigureRuntime(c =>
                        {
                            c.AddMsSql2017Database<MsSqlDb>(
                                ConfigurationProvider.ConnectionString,
                                configureRuntime
                            );
                        });
                        break;
                    }
                case 2019:
                    {
                        dbExpression.ConfigureRuntime(c =>
                        {
                            c.AddMsSql2019Database<MsSqlDb>(
                                ConfigurationProvider.ConnectionString,
                                configureRuntime
                            );
                        });
                        break;
                    }
                default: throw new NotImplementedException($"MsSql version {version} has not been implemented");
            }
            return config;
        }
    }
}
