using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTL.DbEx.Sql.Executor
{
    public class SelectTypeSqlExecutor : SqlExecutor
    {
        public override ResultSet ExecuteQuery(SqlConnection connection, string executionCommand, DbCommandType commandType, IList<DbParameter> parameters, int? commandTimeout = null)
        {
            var @return = new ResultSet();

            DbCommand cmd = connection.GetDbCommand();
            IDataReader dr = null;
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
            cmd.CommandText = executionCommand;
            cmd.CommandType = (commandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (parameters != null && parameters.Any()) { cmd.Parameters.AddRange(parameters.ToArray()); }
            try
            {
                connection.EnsureOpenConnection();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    @return.Rows.Add(new ResultSet.Row());
                    for (var i = 0; i < dr.FieldCount; i++)
                    {
                        var value = dr.GetValue(i);
                        @return.Rows[0].Fields.Add((i, dr.GetName(i), value == DBNull.Value ? null : value));
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
