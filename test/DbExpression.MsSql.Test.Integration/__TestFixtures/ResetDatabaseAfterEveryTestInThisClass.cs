using DbExpression.MsSql.Test.Database;
using Xunit;

namespace DbExpression.MsSql.Test.Executor
{
    /// <summary>
    /// Base class when the database data is affected by one or more tests in the class.  Inherting from
    /// this class ensures the database data is reset only after every test in the class has executed (once per class).
    /// </summary>
    public abstract class ResetDatabaseAfterAllTestsInThisClass : ExecutorTestBase, IClassFixture<Seeder>
    {
        public ResetDatabaseAfterAllTestsInThisClass(Seeder fixture) : base(fixture)
        {

        }
    }
}
