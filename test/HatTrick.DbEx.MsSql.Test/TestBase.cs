using DataService;
using DataService.Metadata;
using HatTrick.DbEx.MsSql.Extensions.Configuration;
using HatTrick.DbEx.Sql.Configuration;
using System;

namespace HatTrick.DbEx.MsSql.Test
{
    public abstract class TestBase
    {
        public virtual DatabaseConfiguration ConfigureForMsSqlVersion(int version)
        {
            switch (version)
            {
                case 2012:
                    {
                        DbExpressionConfigurationBuilder.AddDbExpression(c =>
                        {
                            c.AddMsSql2012Database<MsSqlDbExTestDatabaseMetadataProvider>();
                        });
                        return DbExpression.Configuration.Databases["MsSqlDbExTest"];
                    }
                case 2014:
                    {
                        DbExpressionConfigurationBuilder.AddDbExpression(c =>
                        {
                            c.AddMsSql2014Database<MsSqlDbExTestDatabaseMetadataProvider>();
                        });
                        return DbExpression.Configuration.Databases["MsSqlDbExTest"];
                    }
            }
            throw new NotImplementedException($"MsSql version {version} has not been implemented");
        }
    }
}
