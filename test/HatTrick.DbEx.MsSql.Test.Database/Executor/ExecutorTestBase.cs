using DataService;
using DataService.Metadata;
using HatTrick.DbEx.MsSql.Extensions.Configuration;
using HatTrick.DbEx.MsSql.Test.Database;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Extensions.Configuration;
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
                                c.UseConnectionStringsFromAppConfig();
                                c.AddMsSql2012Database<MsSqlDbExTestDatabaseMetadataProvider>(
                                    db =>
                                    {
                                        db.ConfigureAssembler(a => a.Minify = false);
                                    });
                            });
                            return DbExpression.Configuration.Databases["MsSqlDbExTest"];
                        }
                    case 2014:
                        {
                            DbExpressionConfigurationBuilder.AddDbExpression(c =>
                            {
                                c.UseConnectionStringsFromAppConfig();
                                c.AddMsSql2014Database<MsSqlDbExTestDatabaseMetadataProvider>(
                                    db =>
                                    {
                                        db.ConfigureAssembler(a => a.Minify = false);
                                    });
                            });
                            return DbExpression.Configuration.Databases["MsSqlDbExTest"];
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
