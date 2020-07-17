using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Mapper;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Executor
{
    public class SqlStatementExecutor : ISqlStatementExecutor
    {
        public virtual int ExecuteNonQuery(SqlStatement statement, ISqlConnection connection, Action<DbCommand> configureCommand, Action<DbCommand> beforeExecution)
        {
            int @return = 0;

            DbCommand cmd = connection.CreateDbCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (statement.Parameters is object && statement.Parameters.Any()) { cmd.Parameters.AddRange(statement.Parameters.Select(p => p.Parameter).ToArray()); }
            configureCommand?.Invoke(cmd);
            beforeExecution?.Invoke(cmd);
            try
            {
                connection.EnsureOpenConnection();
                @return = cmd.ExecuteNonQuery();
                if (!connection.IsTransactional) { connection.Disconnect(); }
            }
            catch
            {
                if (connection.IsTransactional)
                {
                    connection.RollbackTransaction();
                }
                else
                {
                    connection.Disconnect();
                }
                throw;
            }
            finally
            {
                if (cmd is object) { cmd.Dispose(); }
            }

            return @return;
        }

        public virtual async Task<int> ExecuteNonQueryAsync(SqlStatement statement, ISqlConnection connection, Action<DbCommand> configureCommand, Action<DbCommand> beforeExecution, CancellationToken ct)
        {
            int @return = 0;

            ct.ThrowIfCancellationRequested();

            DbCommand cmd = connection.CreateDbCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (statement.Parameters is object && statement.Parameters.Any()) { cmd.Parameters.AddRange(statement.Parameters.Select(p => p.Parameter).ToArray()); }
            configureCommand?.Invoke(cmd);
            beforeExecution?.Invoke(cmd);
            try
            {
                await connection.EnsureOpenConnectionAsync().ConfigureAwait(false);
                @return = await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                if (!connection.IsTransactional) { connection.Disconnect(); }
            }
            catch
            {
                if (connection.IsTransactional)
                {
                    connection.RollbackTransaction();
                }
                else
                {
                    connection.Disconnect();
                }
                throw;
            }
            finally
            {
                if (cmd is object) { cmd.Dispose(); }
            }

            return @return;
        }

        public virtual ISqlRowReader ExecuteQuery(SqlStatement statement, ISqlConnection connection, Action<DbCommand> configureCommand, IValueMapper mapper, Action<DbCommand> beforeExecution)
        {
            DbCommand cmd = connection.CreateDbCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (statement.Parameters is object && statement.Parameters.Any())
                cmd.Parameters.AddRange(statement.Parameters.Select(p => p.Parameter).ToArray());
            configureCommand?.Invoke(cmd);
            beforeExecution?.Invoke(cmd);
            connection.EnsureOpenConnection();
            return new DataReaderWrapper(connection, cmd.ExecuteReader(), mapper);
        }

        public virtual async Task<IAsyncSqlRowReader> ExecuteQueryAsync(SqlStatement statement, ISqlConnection connection, Action<DbCommand> configureCommand, IValueMapper mapper, Action<DbCommand> beforeExecution, CancellationToken ct)
        {
            DbCommand cmd = connection.CreateDbCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (statement.Parameters is object && statement.Parameters.Any())
                cmd.Parameters.AddRange(statement.Parameters.Select(p => p.Parameter).ToArray());
            configureCommand?.Invoke(cmd);
            beforeExecution?.Invoke(cmd);
            await connection.EnsureOpenConnectionAsync();
            return new AsyncDataReaderWrapper(connection, await cmd.ExecuteReaderAsync(ct).ConfigureAwait(false), mapper, ct);
        }
    }
}
