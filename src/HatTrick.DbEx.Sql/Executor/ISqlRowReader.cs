using System;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Executor
{
    public interface ISqlRowReader : IDisposable
    {
        ISqlRow ReadRow();
    }
}
