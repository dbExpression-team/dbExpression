using HatTrick.DbEx.MsSql.Extensions.Configuration;
using HatTrick.DbEx.Sql.Configuration;
using System;

namespace HatTrick.DbEx.MsSql.Test
{
    public abstract class TestBase
    {
        public virtual DbExpressionConfiguration ConfigureForMsSqlVersion(int version)
        {
            switch (version)
            {
                case 2014:
                    {
                        var settings = new DbExpressionConfiguration();
                        DbExConfigurationBuilder.Configure(settings, c => c.UseMsSql2014());
                        return settings;
                    }
            }
            throw new NotImplementedException($"MsSql version {version} has not been implemented");
        }
    }
}
