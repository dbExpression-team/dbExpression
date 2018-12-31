using DataService;
using DataService.Metadata;
using HatTrick.DbEx.MsSql.Extensions.Configuration;
using HatTrick.DbEx.Sql.Configuration;
using System;

namespace HatTrick.DbEx.MsSql.Test
{
    public abstract class TestBase
    {
        public virtual void ConfigureForMsSqlVersion(int version)
        {
            switch (version)
            {
                case 2014:
                    {
                        DbExConfigurationBuilder.UseDbExpression<MsSqlDbExTestDatabaseMetadataProvider>(c =>
                        {
                            c.UseMsSql2014();
                        });
                        return;
                    }
            }
            throw new NotImplementedException($"MsSql version {version} has not been implemented");
        }
    }
}
