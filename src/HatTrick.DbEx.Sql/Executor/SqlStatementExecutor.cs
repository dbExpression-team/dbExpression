using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Executor
{
    public class SqlStatementExecutor : ISqlStatementExecutor
    {
        public virtual int ExecuteNonQuery(SqlStatement statement, SqlConnection connection, int? commandTimeout = null)
        {
            int @return = 0;

            DbCommand cmd = connection.GetDbCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
            cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
            cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (commandTimeout.HasValue)
            {
                cmd.CommandTimeout = commandTimeout.Value;
            }
            if (statement.Parameters != null && statement.Parameters.Any()) { cmd.Parameters.AddRange(statement.Parameters.Select(p => p.Parameter).ToArray()); }
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
                if (cmd != null) { cmd.Dispose(); }
            }

            return @return;
        }

        public virtual async Task<int> ExecuteNonQueryAsync(SqlStatement statement, SqlConnection connection, int? commandTimeout = null)
        {
            int @return = 0;

            DbCommand cmd = connection.GetDbCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
            cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
            cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (commandTimeout.HasValue)
            {
                cmd.CommandTimeout = commandTimeout.Value;
            }
            if (statement.Parameters != null && statement.Parameters.Any()) { cmd.Parameters.AddRange(statement.Parameters.Select(p => p.Parameter).ToArray()); }
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
                if (cmd != null) { cmd.Dispose(); }
            }

            return @return;
        }

        public virtual ISqlRowReader ExecuteQuery(SqlStatement statement, SqlConnection connection, int? commandTimeout = null)
        {
            DbCommand cmd = connection.GetDbCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
            cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
            cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (statement.Parameters != null && statement.Parameters.Any())
                cmd.Parameters.AddRange(statement.Parameters.Select(p => p.Parameter).ToArray());
            connection.EnsureOpenConnection();
            return new DataReaderWrapper(connection, cmd.ExecuteReader());
        }

        public virtual async Task<ISqlRowReader> ExecuteQueryAsync(SqlStatement statement, SqlConnection connection, int? commandTimeout = null)
        {
            DbCommand cmd = connection.GetDbCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
            cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
            cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (statement.Parameters != null && statement.Parameters.Any())
                cmd.Parameters.AddRange(statement.Parameters.Select(p => p.Parameter).ToArray());
            await connection.EnsureOpenConnectionAsync();
            return new DataReaderWrapper(connection, await cmd.ExecuteReaderAsync().ConfigureAwait(false));
        }
    }
}
