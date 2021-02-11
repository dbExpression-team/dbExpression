using System;

namespace HatTrick.DbEx.Sql.Executor
{
    public interface ISqlRowReader : IDisposable
    {
        ISqlFieldReader ReadRow();
        void Close();
    }
}
