using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace HatTrick.DbEx.Sql.Executor
{
    public class SelectTypeSqlStatementExecutor : SqlStatementExecutor
    {
        public override SqlStatementExecutionResultSet ExecuteQuery(SqlStatement statement, SqlConnection connection, int? commandTimeout = null)
        {
            var @return = new SqlStatementExecutionResultSet();

            DbCommand cmd = connection.GetDbCommand();
            IDataReader dr = null;
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
            cmd.CommandText = statement.ExecutionCommand;
            cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (statement.Parameters != null) { cmd.Parameters.AddRange(statement.Parameters.ToArray()); }
            try
            {
                connection.EnsureOpenConnection();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    @return.Rows.Add(new SqlStatementExecutionResultSet.Row());
                    for (var i = 0; i < dr.FieldCount; i++)
                    {
                        var value = dr.GetValue(i);
                        @return.Rows[0].Fields.Add(i, new SqlStatementExecutionResultSet.Field(dr.GetName(i), value == DBNull.Value ? null : value));
                    }
                }
                dr.Close();
                if (!connection.IsTransactional) { connection.Disconnect(); }
            }
            catch
            {
                if (dr != null && !dr.IsClosed) { dr.Close(); } //redundant, but required for sqlCe before rollback...
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
                if (dr != null && !dr.IsClosed) { dr.Close(); }
                if (cmd != null) { cmd.Dispose(); }
            }
            return @return;
        }

    }
}
