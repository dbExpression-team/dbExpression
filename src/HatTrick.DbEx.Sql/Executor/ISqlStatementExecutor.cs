using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Mapper;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Executor
{
    public interface ISqlStatementExecutor
    {
        int ExecuteNonQuery(SqlStatement statement, ISqlConnection connection, Action<DbCommand> configureCommand, Action<DbCommand> beforeExecution);
        Task<int> ExecuteNonQueryAsync(SqlStatement statement, ISqlConnection connection, Action<DbCommand> configureCommand, Action<DbCommand> beforeExecution, CancellationToken ct);
        ISqlRowReader ExecuteQuery(SqlStatement statement, ISqlConnection connection, Action<DbCommand> configureCommand, IValueMapper mapper, Action<DbCommand> beforeExecution);
        Task<IAsyncSqlRowReader> ExecuteQueryAsync(SqlStatement statement, ISqlConnection connection, Action<DbCommand> configureCommand, IValueMapper mapper, Action<DbCommand> beforeExecution, CancellationToken ct);
    }
}
