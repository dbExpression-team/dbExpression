using DbEx.DataService;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.MsSql.Test.Database;
using HatTrick.DbEx.Sql.Configuration;
using System;
using System.Configuration;
using System.IO;

namespace HatTrick.DbEx.MsSql.Test.Executor
{
    public abstract class ExecutorTestBase : TestBase
    {
        private static readonly object _lock = new object();
        protected ExecutorTestBase()
        {
            ResetDatabase();
        }

        public override DatabaseConfiguration ConfigureForMsSqlVersion(int version)
        {
            lock (_lock)
            {
                switch (version)
                {
                    case 2012:
                        {
                            DbExpressionConfigurationBuilder.AddDbExpression(c =>
                            {
                                c.AddMsSql2012Database<MsSqlDbExTestDatabaseMetadataProvider>(
                                    ConfigurationManager.ConnectionStrings["hattrick.dbex.mssql.test"],
                                    "MsSqlDbExTest-design",
                                    db =>
                                    {
                                        db.ConfigureAssembler(a => a.Minify = false);
                                    });
                            });
                            return DbExpression.Configuration.Databases["MsSqlDbExTest-design"].DatabaseConfiguration;
                        }
                    case 2014:
                        {
                            DbExpressionConfigurationBuilder.AddDbExpression(c =>
                            {
                                c.AddMsSql2014Database<MsSqlDbExTestDatabaseMetadataProvider>(
                                    ConfigurationManager.ConnectionStrings["hattrick.dbex.mssql.test"],
                                    "MsSqlDbExTest-design",
                                    db =>
                                    {
                                        db.ConfigureAssembler(a => a.Minify = false);
                                    });
                            });
                            return DbExpression.Configuration.Databases["MsSqlDbExTest-design"].DatabaseConfiguration;
                        }
                }
                throw new NotImplementedException($"MsSql version {version} has not been implemented");
            }
        }

        public void ResetDatabase()
        {
            var seeder = new Seeder(ConfigurationManager.ConnectionStrings["hattrick.dbex.mssql.test"]);
            seeder.RunScript("data.sql");
        }
    }
}
