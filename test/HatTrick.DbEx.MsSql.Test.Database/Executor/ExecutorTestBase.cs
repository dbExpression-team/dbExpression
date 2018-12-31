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
        protected ExecutorTestBase()
        {
            ResetDatabase();
        }

        public override void ConfigureForMsSqlVersion(int version)
        {
            switch (version)
            {
                case 2014:
                    {
                        DbExConfigurationBuilder.UseDbExpression<MsSqlDbExTestDatabaseMetadataProvider>(c =>
                        {
                            c.UseConnectionStringsFromAppConfig();
                            c.UseMsSql2014();
                        });
                        return;
                    }
            }
            throw new NotImplementedException($"MsSql version {version} has not been implemented");
        }

        public void ResetDatabase()
        {
            var seeder = new Seeder(ConfigurationManager.ConnectionStrings["hattrick.dbex.mssql.test"]);
            seeder.RunScript("data.sql");
        }
    }
}
