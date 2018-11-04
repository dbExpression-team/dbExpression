using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace HatTrick.DbEx.Sql.Executor
{
    public class SelectValueSqlStatementExecutor : SqlStatementExecutor
    {
        public override SqlStatementExecutionResultSet ExecuteQuery(SqlStatement statement, SqlConnection connection, int? commandTimeout = null)
        {
            SqlStatementExecutionResultSet @return = new SqlStatementExecutionResultSet();
            DbCommand cmd = connection.GetDbCommand();

            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
            cmd.CommandText = statement.ExecutionCommand;
            cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (statement.Parameters != null) { cmd.Parameters.AddRange(statement.Parameters.ToArray()); }
            try
            {
                connection.EnsureOpenConnection();
                var val = cmd.ExecuteScalar();
                @return.Rows.Add(new SqlStatementExecutionResultSet.Row(0, new SqlStatementExecutionResultSet.Field(null, val == DBNull.Value ? null : val)));
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
    }
}
