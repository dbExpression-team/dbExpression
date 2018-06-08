using System.Configuration;

namespace HTL.DbEx.MsSql.Test
{
    public abstract class UnitTestBase
    {
        protected UnitTestBase()
        {
            var databaseName = ConfigurationManager.AppSettings["DefaultDatabase"];
            new Seeder(databaseName, ConfigurationManager.ConnectionStrings[databaseName].ConnectionString).RunScript("Reset.sql");
        }

        protected UnitTestBase(string databaseName)
        {
            new Seeder(databaseName, ConfigurationManager.ConnectionStrings[databaseName].ConnectionString).RunScript("Reset.sql");
        }
    }
}
