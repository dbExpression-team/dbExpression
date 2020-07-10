using DbEx.DataService;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql.Configuration;
using System;
using System.Security.Policy;

namespace HatTrick.DbEx.MsSql.Test
{
    public abstract class TestBase
    {
        private static readonly object @lock = new object();

        public virtual DatabaseConfiguration ConfigureForMsSqlVersion(int version, Action<DatabaseConfigurationBuilder> postConfigure = null)
        {
            lock (@lock)
            {
                switch (version)
                {
                    case 2005:
                        {
                            DbExpressionConfigurationBuilder.AddDbExpression(c =>
                            {
                                c.AddMsSql2005Database<MsSqlDbExTestDatabaseMetadataProvider>(
                                    ConfigurationProvider.ConnectionString,
                                    ConfigurationProvider.MetadataKey, 
                                    postConfigure
                                );
                            });
                            break;
                        }
                    case 2008:
                        {
                            DbExpressionConfigurationBuilder.AddDbExpression(c =>
                            {
                                c.AddMsSql2008Database<MsSqlDbExTestDatabaseMetadataProvider>(
                                    ConfigurationProvider.ConnectionString,
                                    ConfigurationProvider.MetadataKey,
                                    postConfigure
                                );
                            });
                            break;
                        }
                    case 2012:
                        {
                            DbExpressionConfigurationBuilder.AddDbExpression(c =>
                            {
                                c.AddMsSql2012Database<MsSqlDbExTestDatabaseMetadataProvider>(
                                    ConfigurationProvider.ConnectionString,
                                    ConfigurationProvider.MetadataKey,
                                    postConfigure
                                );
                            });
                            break;
                        }
                    case 2014:
                        {
                            DbExpressionConfigurationBuilder.AddDbExpression(c =>
                            {
                                c.AddMsSql2014Database<MsSqlDbExTestDatabaseMetadataProvider>(
                                    ConfigurationProvider.ConnectionString,
                                    ConfigurationProvider.MetadataKey,
                                    postConfigure
                                );
                            });
                            break;
                        }
                    case 2016:
                        {
                            DbExpressionConfigurationBuilder.AddDbExpression(c =>
                            {
                                c.AddMsSql2016Database<MsSqlDbExTestDatabaseMetadataProvider>(
                                    ConfigurationProvider.ConnectionString,
                                    ConfigurationProvider.MetadataKey,
                                    postConfigure
                                );
                            });
                            break;
                        }
                    case 2017:
                        {
                            DbExpressionConfigurationBuilder.AddDbExpression(c =>
                            {
                                c.AddMsSql2017Database<MsSqlDbExTestDatabaseMetadataProvider>(
                                    ConfigurationProvider.ConnectionString,
                                    ConfigurationProvider.MetadataKey,
                                    postConfigure
                                );
                            });
                            break;
                        }
                    case 2019:
                        {
                            DbExpressionConfigurationBuilder.AddDbExpression(c =>
                            {
                                c.AddMsSql2019Database<MsSqlDbExTestDatabaseMetadataProvider>(
                                    ConfigurationProvider.ConnectionString,
                                    ConfigurationProvider.MetadataKey,
                                    postConfigure
                                );
                            });
                            break;
                        }
                    default: throw new NotImplementedException($"MsSql version {version} has not been implemented");
                }

                return DbExpression.Configuration.Databases[ConfigurationProvider.MetadataKey];
            }
        }
    }
}
