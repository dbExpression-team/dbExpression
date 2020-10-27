using HatTrick.DbEx.Sql.Connection;
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
        public virtual int ExecuteNonQuery(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution)
        {
            int @return = 0;

            IDbCommand cmd = connection.CreateCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            (cmd.Parameters as DbParameterCollection).AddRange(statement.Parameters.Select(x => x.Parameter).ToArray());

            beforeExecution?.Invoke(cmd);
            try
            {
                connection.EnsureOpen();
                @return = cmd.ExecuteNonQuery();
                afterExecution?.Invoke(cmd);
            }
            finally
            {
                if (cmd is object) { cmd.Dispose(); }
            }

            return @return;
        }

        public virtual async Task<int> ExecuteNonQueryAsync(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution, CancellationToken ct)
        {
            int @return = 0;

            ct.ThrowIfCancellationRequested();

            IDbCommand cmd = connection.CreateCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            (cmd.Parameters as DbParameterCollection).AddRange(statement.Parameters.Select(x => x.Parameter).ToArray());

            beforeExecution?.Invoke(cmd);
            try
            {
                await connection.EnsureOpenAsync(ct).ConfigureAwait(false);
                @return = await (cmd as DbCommand).ExecuteNonQueryAsync(ct).ConfigureAwait(false);
                afterExecution?.Invoke(cmd);
            }
            finally
            {
                if (cmd is object) { cmd.Dispose(); }
            }

            return @return;
        }

        public virtual ISqlRowReader ExecuteQuery(SqlStatement statement, ISqlConnection connection, IValueConverterFinder finder, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution)
        {
            IDbCommand cmd = connection.CreateCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            (cmd.Parameters as DbParameterCollection).AddRange(statement.Parameters.Select(x => x.Parameter).ToArray());

            beforeExecution?.Invoke(cmd);
            connection.EnsureOpen();
            var reader = cmd.ExecuteReader();
            afterExecution?.Invoke(cmd);
            return new DataReaderWrapper(connection, reader, finder);
        }

        public virtual async Task<IAsyncSqlRowReader> ExecuteQueryAsync(SqlStatement statement, ISqlConnection connection, IValueConverterFinder finder, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution, CancellationToken ct)
        {
            IDbCommand cmd = connection.CreateCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            (cmd.Parameters as DbParameterCollection).AddRange(statement.Parameters.Select(x => x.Parameter).ToArray());

            beforeExecution?.Invoke(cmd);
            await connection.EnsureOpenAsync(ct);
            var reader = await (cmd as DbCommand).ExecuteReaderAsync(ct).ConfigureAwait(false);
            afterExecution?.Invoke(cmd);
            return new AsyncDataReaderWrapper(connection, reader, finder, ct);
        }

        public virtual T ExecuteScalar<T>(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution)
        {
            IDbCommand cmd = connection.CreateCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            (cmd.Parameters as DbParameterCollection).AddRange(statement.Parameters.Select(x => x.Parameter).ToArray());

            beforeExecution?.Invoke(cmd);
            connection.EnsureOpen();
            var output = cmd.ExecuteScalar();
            afterExecution?.Invoke(cmd);
            return (T)Convert.ChangeType(output, typeof(T));
        }

        public virtual async Task<T> ExecuteScalarAsync<T>(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution, CancellationToken ct)
        {
            IDbCommand cmd = connection.CreateCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            (cmd.Parameters as DbParameterCollection).AddRange(statement.Parameters.Select(x => x.Parameter).ToArray());

            beforeExecution?.Invoke(cmd);
            connection.EnsureOpen();
            var output = await (cmd as DbCommand).ExecuteScalarAsync(ct).ConfigureAwait(false);
            afterExecution?.Invoke(cmd);
            return (T)Convert.ChangeType(output, typeof(T));
        }
    }
}
