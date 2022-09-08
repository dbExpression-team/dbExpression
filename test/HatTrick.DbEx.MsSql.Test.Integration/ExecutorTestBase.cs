using HatTrick.DbEx.MsSql.Test.Database;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Data.Common;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Executor
{
    [Collection("Sequential")]
    public abstract class ExecutorTestBase : TestBase
    {
        private static string? _databaseName;
        private static int _testsExecutedCount;

        protected ExecutorTestBase()
        {
            ResetDatabase();
        }

        public static void ResetDatabase()
        {
            var seeder = new Seeder(ConfigurationProvider.ConnectionString);
            _testsExecutedCount++;
            if (_testsExecutedCount % 250 == 0)
            {
                seeder.Run($"BACKUP DATABASE [{GetDatabaseName()}] TO DISK = N'NUL';");
            }
            seeder.RunScript("data.sql");
        }

        public static void AppendImagesToProductsInDatabase()
        {
            var seeder = new Seeder(ConfigurationProvider.ConnectionString);
            seeder.RunScript("images.sql");
        }

        public static string GetDatabaseName()
        {
            if (_databaseName == null)
            {
                var builder = new DbConnectionStringBuilder();
                builder.ConnectionString = ConfigurationProvider.ConnectionString;
                if (builder.ContainsKey("database"))
                    _databaseName = builder["database"] as string;
                else if (builder.ContainsKey("initial catalog"))
                    _databaseName = builder["initial catalog"] as string;
                else throw new InvalidOperationException("Could not resolve the database name from the connection string from the configuration provider.");
            }

            return _databaseName!;
        }
    }
}
