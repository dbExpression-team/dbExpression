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
        public override DbExpressionConfiguration ConfigureForMsSqlVersion(int version)
        {
            switch (version)
            {
                case 2014:
                    {
                        DbExConfigurationBuilder.Configure(c =>
                        {
                            c.UseConnectionStringsFromAppConfig();
                            c.UseMsSql2014();
                        });
                        return DbExConfigurationSettings.Settings;
                    }
            }
            throw new NotImplementedException($"MsSql version {version} has not been implemented");
        }
    }
}
