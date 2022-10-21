using HatTrick.DbEx.MsSql.Test.Database;
using System;

namespace HatTrick.DbEx.MsSql.Test.Executor
{
    /// <summary>
    /// Base class when the database data is affected by one or more tests in the class.  Inherting from
    /// this class ensures the database data is reset after every test in the class is executed (once per method).
    /// </summary>
    public abstract class ResetDatabaseAfterEveryTest : ExecutorTestBase, IDisposable
    {
        private bool disposedValue;

        public ResetDatabaseAfterEveryTest() : base(new Seeder())
        {
            Seeder.ResetDatabase();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    ResetDatabase();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
