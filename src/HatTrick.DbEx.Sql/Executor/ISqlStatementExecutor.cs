using HatTrick.DbEx.Sql.Connection;
using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Executor
{
    public interface ISqlStatementExecutor
    {
        int ExecuteNonQuery(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution);
        Task<int> ExecuteNonQueryAsync(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution, CancellationToken ct);
        ISqlRowReader ExecuteQuery(SqlStatement statement, ISqlConnection connection, IValueConverterFinder finder, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution);
        Task<IAsyncSqlRowReader> ExecuteQueryAsync(SqlStatement statement, ISqlConnection connection, IValueConverterFinder finder, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution, CancellationToken ct);
        T ExecuteScalar<T>(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution);
        Task<T> ExecuteScalarAsync<T>(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution, CancellationToken ct);
    }
}
