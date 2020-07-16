using DbEx.DataService;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Configuration;
using System;

namespace HatTrick.DbEx.MsSql.Test
{
    public abstract class TestBase
    {
        private static readonly object @lock = new object();

        public virtual DatabaseConfiguration ConfigureForMsSqlVersion(int version, Action<RuntimeDatabaseConfigurationBuilder> postConfigure = null)
        {
            DatabaseConfiguration config = null;
            //lock (@lock)
            //{
                switch (version)
                {
                    case 2005:
                        {
                            DbExpressionConfigurationBuilder.AddDbExpression(c =>
                            {
                                c.AddMsSql2005Database<MsSqlDbExTest>(
                                    ConfigurationProvider.ConnectionString,
                                    d => { config = (d as IRuntimeSqlDatabaseConfigurationBuilder).Configuration; postConfigure?.Invoke(d); }
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
                                    d => { config = (d as IRuntimeSqlDatabaseConfigurationBuilder).Configuration; postConfigure?.Invoke(d); }
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
                                    d => { config = (d as IRuntimeSqlDatabaseConfigurationBuilder).Configuration; postConfigure?.Invoke(d); }
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
                                    d => { config = (d as IRuntimeSqlDatabaseConfigurationBuilder).Configuration; postConfigure?.Invoke(d); }
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
                                    d => { config = (d as IRuntimeSqlDatabaseConfigurationBuilder).Configuration; postConfigure?.Invoke(d); }
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
                                    d => { config = (d as IRuntimeSqlDatabaseConfigurationBuilder).Configuration; postConfigure?.Invoke(d); }
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
                                    d => { config = (d as IRuntimeSqlDatabaseConfigurationBuilder).Configuration; postConfigure?.Invoke(d); }
                                );                                
                            });
                            break;
                        }
                    default: throw new NotImplementedException($"MsSql version {version} has not been implemented");
                }
                return config;
            //}
        }
    }
}
