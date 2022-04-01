using HatTrick.DbEx.MsSql.Test.Database;

namespace HatTrick.DbEx.MsSql.Test.Executor
{
    public abstract class ExecutorTestBase : TestBase
    {
        protected ExecutorTestBase()
        {
            ResetDatabase();
        }

        public static void ResetDatabase()
        {
            var seeder = new Seeder(ConfigurationProvider.ConnectionString);
            seeder.RunScript("data.sql");
        }

        public static void AppendImagesToProductsInDatabase()
        {
            var seeder = new Seeder(ConfigurationProvider.ConnectionString);
            seeder.RunScript("images.sql");
        }
    }
}
