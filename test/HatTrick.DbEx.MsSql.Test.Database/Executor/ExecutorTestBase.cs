﻿using HatTrick.DbEx.MsSql.Test.Database;

namespace HatTrick.DbEx.MsSql.Test.Executor
{
    public abstract class ExecutorTestBase : TestBase
    {
        protected ExecutorTestBase()
        {
            ResetDatabase();
        }

        public void ResetDatabase()
        {
            var seeder = new Seeder(ConfigurationProvider.ConnectionStringSettings);
            seeder.RunScript("data.sql");
        }
    }
}
