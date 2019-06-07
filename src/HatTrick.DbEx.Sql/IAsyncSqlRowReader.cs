using HatTrick.DbEx.Sql.Executor;
using System;
using System.Threading.Tasks;

public interface IAsyncSqlRowReader : IDisposable
{
    Task<ISqlRow> ReadRowAsync();
}