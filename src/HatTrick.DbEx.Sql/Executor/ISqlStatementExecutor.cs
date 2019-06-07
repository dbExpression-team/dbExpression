using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Executor
{
    public interface ISqlStatementExecutor
    {
        int ExecuteNonQuery(SqlStatement statement, SqlConnection connection, Action<DbCommand> configureCommand);
        Task<int> ExecuteNonQueryAsync(SqlStatement statement, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct);
        ISqlRowReader ExecuteQuery(SqlStatement statement, SqlConnection connection, Action<DbCommand> configureCommand);
        Task<IAsyncSqlRowReader> ExecuteQueryAsync(SqlStatement statement, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct);
    }
}
