using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Converter;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Executor
{
    public interface ISqlStatementExecutor
    {
        int ExecuteNonQuery(SqlStatement statement, ISqlConnection connection, IValueConverterFinder finder, Action<DbCommand> beforeExecution, Action<DbCommand> afterExecution);
        Task<int> ExecuteNonQueryAsync(SqlStatement statement, ISqlConnection connection, IValueConverterFinder finder, Action<DbCommand> beforeExecution, Action<DbCommand> afterExecution, CancellationToken ct);
        ISqlRowReader ExecuteQuery(SqlStatement statement, ISqlConnection connection, IValueConverterFinder finder, Action<DbCommand> beforeExecution, Action<DbCommand> afterExecution);
        Task<IAsyncSqlRowReader> ExecuteQueryAsync(SqlStatement statement, ISqlConnection connection, IValueConverterFinder finder, Action<DbCommand> beforeExecution, Action<DbCommand> afterExecution, CancellationToken ct);
        T ExecuteScalar<T>(SqlStatement statement, ISqlConnection connection, IValueConverterFinder converfinderters, Action<DbCommand> beforeExecution, Action<DbCommand> afterExecution);
        Task<T> ExecuteScalarAsync<T>(SqlStatement statement, ISqlConnection connection, IValueConverterFinder cfinderonverters, Action<DbCommand> beforeExecution, Action<DbCommand> afterExecution, CancellationToken ct);
    }
}
