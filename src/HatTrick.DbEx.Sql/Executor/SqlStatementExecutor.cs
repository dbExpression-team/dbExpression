using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Converter;
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
        public virtual int ExecuteNonQuery(SqlStatement statement, ISqlConnection connection, FieldExpressionConverters converters, Action<DbCommand> beforeExecution, Action<DbCommand> afterExecution)
        {
            int @return = 0;

            DbCommand cmd = connection.CreateDbCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (statement.Parameters is object && statement.Parameters.Any()) 
            {
                foreach (var parameter in statement.Parameters)
                {
                    if (parameter.Parameter.Value != DBNull.Value)
                        parameter.Parameter.Value = converters[parameter.Field].Convert(parameter.Parameter.Value);
                    cmd.Parameters.Add(parameter.Parameter);
                }
            }
            beforeExecution?.Invoke(cmd);
            try
            {
                connection.EnsureOpenConnection();
                @return = cmd.ExecuteNonQuery();
                afterExecution?.Invoke(cmd);
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

        public virtual async Task<int> ExecuteNonQueryAsync(SqlStatement statement, ISqlConnection connection, FieldExpressionConverters converters, Action<DbCommand> beforeExecution, Action<DbCommand> afterExecution, CancellationToken ct)
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
            if (statement.Parameters is object && statement.Parameters.Any()) 
            {
                foreach (var parameter in statement.Parameters)
                {
                    if (parameter.Parameter.Value != DBNull.Value)
                        parameter.Parameter.Value = converters[parameter.Field].Convert(parameter.Parameter.Value);
                    cmd.Parameters.Add(parameter.Parameter);
                }
            }
            beforeExecution?.Invoke(cmd);
            try
            {
                await connection.EnsureOpenConnectionAsync(ct).ConfigureAwait(false);
                @return = await cmd.ExecuteNonQueryAsync(ct).ConfigureAwait(false);
                afterExecution?.Invoke(cmd);
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

        public virtual ISqlRowReader ExecuteQuery(SqlStatement statement, ISqlConnection connection, FieldExpressionConverters converters, Action<DbCommand> beforeExecution, Action<DbCommand> afterExecution)
        {
            DbCommand cmd = connection.CreateDbCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (statement.Parameters is object && statement.Parameters.Any())
            {
                foreach (var parameter in statement.Parameters)
                {
                    if (parameter.Parameter.Value != DBNull.Value)
                        parameter.Parameter.Value = converters[parameter.Field].Convert(parameter.Parameter.Value);
                    cmd.Parameters.Add(parameter.Parameter);
                }
            }
            beforeExecution?.Invoke(cmd);
            connection.EnsureOpenConnection();
            var reader = cmd.ExecuteReader();
            afterExecution?.Invoke(cmd);
            return new DataReaderWrapper(connection, reader, converters);
        }

        public virtual async Task<IAsyncSqlRowReader> ExecuteQueryAsync(SqlStatement statement, ISqlConnection connection, FieldExpressionConverters converters, Action<DbCommand> beforeExecution, Action<DbCommand> afterExecution, CancellationToken ct)
        {
            DbCommand cmd = connection.CreateDbCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (statement.Parameters is object && statement.Parameters.Any())
            {
                foreach (var parameter in statement.Parameters)
                {
                    if (parameter.Parameter.Value != DBNull.Value)
                        parameter.Parameter.Value = converters[parameter.Field].Convert(parameter.Parameter.Value);
                    cmd.Parameters.Add(parameter.Parameter);
                }
            }
            beforeExecution?.Invoke(cmd);
            await connection.EnsureOpenConnectionAsync(ct);
            var reader = await cmd.ExecuteReaderAsync(ct).ConfigureAwait(false);
            afterExecution?.Invoke(cmd);
            return new AsyncDataReaderWrapper(connection, reader, converters, ct);
        }

        public virtual T ExecuteScalar<T>(SqlStatement statement, ISqlConnection connection, FieldExpressionConverters converters, IValueConverter converter, Action<DbCommand> beforeExecution, Action<DbCommand> afterExecution)
        {
            DbCommand cmd = connection.CreateDbCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (statement.Parameters is object && statement.Parameters.Any())
            {
                foreach (var parameter in statement.Parameters)
                {
                    if (parameter.Parameter.Value != DBNull.Value)
                        parameter.Parameter.Value = converters[parameter.Field].Convert(parameter.Parameter.Value);
                    cmd.Parameters.Add(parameter.Parameter);
                }
            }
            beforeExecution?.Invoke(cmd);
            connection.EnsureOpenConnection();
            var output = cmd.ExecuteScalar();
            afterExecution?.Invoke(cmd);
            return converter.Convert<T>(output);
        }

        public virtual async Task<T> ExecuteScalarAsync<T>(SqlStatement statement, ISqlConnection connection, FieldExpressionConverters converters, IValueConverter converter, Action<DbCommand> beforeExecution, Action<DbCommand> afterExecution, CancellationToken ct)
        {
            DbCommand cmd = connection.CreateDbCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (statement.Parameters is object && statement.Parameters.Any())
            {
                foreach (var parameter in statement.Parameters)
                {
                    if (parameter.Parameter.Value != DBNull.Value)
                        parameter.Parameter.Value = converters[parameter.Field].Convert(parameter.Parameter.Value);
                    cmd.Parameters.Add(parameter.Parameter);
                }
            }
            beforeExecution?.Invoke(cmd);
            connection.EnsureOpenConnection();
            var output = await cmd.ExecuteScalarAsync(ct).ConfigureAwait(false);
            afterExecution?.Invoke(cmd);
            return converter.Convert<T>(output);
        }
    }
}
