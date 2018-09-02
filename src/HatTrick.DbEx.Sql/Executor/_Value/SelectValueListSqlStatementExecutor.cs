using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Executor
{
    public class SelectValueListSqlStatementExecutor : SqlStatementExecutor
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
                while (dr.Read())
                {
                    var val = dr.GetValue(0);
                    @return.Rows.Add(new SqlStatementExecutionResultSet.Row((0, dr.GetName(0), val == DBNull.Value ? null : val)));
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
