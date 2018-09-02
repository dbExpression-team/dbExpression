using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace HatTrick.DbEx.Sql.Executor
{
    public abstract class SqlStatementExecutor : ISqlStatementExecutor
    {
        public virtual int ExecuteNonQuery(SqlStatement statement, SqlConnection connection, int? commandTimeout = null)
        {
            int @return = 0;

            DbCommand cmd = connection.GetDbCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
            cmd.CommandText = statement.ExecutionCommand;
            cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (commandTimeout.HasValue)
            {
                cmd.CommandTimeout = commandTimeout.Value;
            }
            if (statement.Parameters != null) { cmd.Parameters.AddRange(statement.Parameters.ToArray()); }
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

        public virtual SqlStatementExecutionResultSet ExecuteQuery(SqlStatement statement, SqlConnection connection, int? commandTimeout = null)
            => throw new NotImplementedException($"{this.GetType().Name} does not implement ExecuteQuery.");

    }
}
