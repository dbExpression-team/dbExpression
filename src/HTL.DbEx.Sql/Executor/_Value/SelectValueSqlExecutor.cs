using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace HTL.DbEx.Sql.Executor
{
    public class SelectValueSqlExecutor : SqlExecutor
    {
        public override ResultSet ExecuteQuery(SqlConnection connection, string executionCommand, DbCommandType commandType, IList<DbParameter> parameters, int? commandTimeout = null)
        {
            ResultSet @return = new ResultSet();
            DbCommand cmd = connection.GetDbCommand();

            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
            cmd.CommandText = executionCommand;
            cmd.CommandType = (commandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (parameters != null && parameters.Any()) { cmd.Parameters.AddRange(parameters.ToArray()); }
            try
            {
                connection.EnsureOpenConnection();
                var val = cmd.ExecuteScalar();
                @return.Rows.Add(new ResultSet.Row((0, null, val == DBNull.Value ? null : val)));
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
