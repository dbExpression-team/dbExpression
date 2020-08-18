using System;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Executor
{
    public interface IAsyncSqlRowReader : IDisposable
    {
        Task<ISqlRow> ReadRowAsync();
    }
}