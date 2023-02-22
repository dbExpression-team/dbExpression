using HatTrick.DbEx.MsSql.Test.Database;

namespace HatTrick.DbEx.MsSql.Test.Executor
{
    /// <summary>
    /// Base class when the database data is not affected by any test in the class.  Inherting from
    /// this class when no methods in a class affect any database data.
    /// </summary>
    public abstract class ResetDatabaseNotRequired : ExecutorTestBase
    {
        protected ResetDatabaseNotRequired() : base(new Seeder())
        { }

        public ResetDatabaseNotRequired(Seeder fixture) : base(fixture)
        {

        }
    }
}
