using HatTrick.DbEx.MsSql.Test.Database;
using Microsoft.SqlServer.Management.Smo;
using System.Data.Common;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Executor
{
    /// <summary>
    /// Base class that performs startup operations regardless of whether the tests effect data or not.
    /// Use one of the types that derive from this when adding/modifying test classes, 
    /// i.e. one of <see cref="ResetDatabaseAfterEveryTest"/>, <see cref="ResetDatabaseAfterAllTestsInThisClass"/>, or <see cref="ResetDatabaseNotRequired"/>.
    /// </summary>
    [Collection("Sequential")]
    public abstract class ExecutorTestBase : TestBase
    {
        private static bool _isFirstTest = true;

        protected Seeder Seeder { get; private set; }

        private ExecutorTestBase() : this(new Seeder())
        { 
        
        }

        public ExecutorTestBase(Seeder seeder)
        {
            Seeder = seeder;
            if (_isFirstTest)
            {
                seeder.ResetDatabase();
                seeder.AppendImagesToProductsInDatabase();
                _isFirstTest = false;
            }
        }

        protected void AppendImagesToProductsInDatabase()
        {
            Seeder.AppendImagesToProductsInDatabase();
        }

        protected void ResetDatabase()
        {
            Seeder.ResetDatabase();
        }
    }
}
