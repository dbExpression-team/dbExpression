using DbEx.Data;
using DbEx.DataService;
using DbEx.dboDataService;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Converter;
using System;

namespace HatTrick.DbEx.MsSql.Test
{
    public abstract class TestBase
    {
        public virtual RuntimeSqlDatabaseConfiguration ConfigureForMsSqlVersion(int version, Action<RuntimeSqlDatabaseConfigurationBuilder> postConfigure = null, Action<IFieldExpressionConfigurationBuilder> fieldConfigure = null)
        {
            RuntimeSqlDatabaseConfiguration config = null;
            Action<RuntimeSqlDatabaseConfigurationBuilder> configureDatabase = database =>
            {
                config = (database as IRuntimeSqlDatabaseConfigurationBuilder).Configuration; 
                postConfigure?.Invoke(database);
            };

            Action<IFieldExpressionConfigurationBuilder> configureFields = fields =>
            {
                fields.For(dbo.Purchase.PaymentMethodType).UseConverter<StringEnumValueConverter<PaymentMethodType>>();
            };

            switch (version)
            {
                case 2005:
                    {
                        DbExpressionConfigurationBuilder.AddDbExpression(c =>
                        {
                            c.AddMsSql2005Database<MsSqlDbExTest>(
                                ConfigurationProvider.ConnectionString,
                                configureDatabase,
                                configureFields
                            );
                        });
                        break;
                    }
                case 2008:
                    {
                        DbExpressionConfigurationBuilder.AddDbExpression(c =>
                        {
                            c.AddMsSql2008Database<MsSqlDbExTest>(
                                ConfigurationProvider.ConnectionString,
                                configureDatabase,
                                configureFields
                            );
                        });
                        break;
                    }
                case 2012:
                    {
                        DbExpressionConfigurationBuilder.AddDbExpression(c =>
                        {
                            c.AddMsSql2012Database<MsSqlDbExTest>(
                                ConfigurationProvider.ConnectionString,
                                configureDatabase,
                                configureFields
                            );
                        });
                        break;
                    }
                case 2014:
                    {
                        DbExpressionConfigurationBuilder.AddDbExpression(c =>
                        {
                            c.AddMsSql2014Database<MsSqlDbExTest>(
                                ConfigurationProvider.ConnectionString,
                                configureDatabase,
                                configureFields
                            );
                        });
                        break;
                    }
                case 2016:
                    {
                        DbExpressionConfigurationBuilder.AddDbExpression(c =>
                        {
                            c.AddMsSql2016Database<MsSqlDbExTest>(
                                ConfigurationProvider.ConnectionString,
                                configureDatabase,
                                configureFields
                            );
                        });
                        break;
                    }
                case 2017:
                    {
                        DbExpressionConfigurationBuilder.AddDbExpression(c =>
                        {
                            c.AddMsSql2017Database<MsSqlDbExTest>(
                                ConfigurationProvider.ConnectionString,
                                configureDatabase,
                                configureFields
                            );
                        });
                        break;
                    }
                case 2019:
                    {
                        DbExpressionConfigurationBuilder.AddDbExpression(c =>
                        {
                            c.AddMsSql2019Database<MsSqlDbExTest>(
                                ConfigurationProvider.ConnectionString,
                                configureDatabase,
                                configureFields
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
