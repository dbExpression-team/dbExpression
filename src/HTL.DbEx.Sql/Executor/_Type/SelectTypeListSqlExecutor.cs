using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace HTL.DbEx.Sql.Executor
{
    public class SelectTypeListSqlExecutor : SqlExecutor
    {
        public override ResultSet ExecuteQuery(SqlConnection connection, string executionCommand, DbCommandType commandType, IList<DbParameter> parameters, int? commandTimeout = null)
        {
            var list = new ResultSet();

            DbCommand cmd = connection.GetDbCommand();
            IDataReader dr = null;
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
            cmd.CommandText = executionCommand;
            cmd.CommandType = (commandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (parameters != null) { cmd.Parameters.AddRange(parameters.ToArray()); }
            try
            {
                connection.EnsureOpenConnection();
                dr = cmd.ExecuteReader();
                var index = 0;
                while (dr.Read())
                {
                    var row = new ResultSet.Row();
                    for (var i = 0; i < dr.FieldCount; i++)
                    {
                        var value = dr.GetValue(i);
                        row.Fields.Add((i, dr.GetName(i), value == DBNull.Value ? null : value));
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
            return list;
        }

    }
}
