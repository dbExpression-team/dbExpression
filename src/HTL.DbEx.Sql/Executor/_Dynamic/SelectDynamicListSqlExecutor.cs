using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTL.DbEx.Sql.Executor
{
    public class SelectDynamicListSqlExecutor : SqlExecutor
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
            if (parameters != null) { cmd.Parameters.AddRange(parameters.ToArray()); }

            try
            {
                connection.EnsureOpenConnection();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    @return.Rows.Add(new ResultSet.Row(this.GetColumns(dr)));
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

        private IList<(int, string, object)> GetColumns(IDataReader dr)
        {
            int @count = dr.FieldCount;
            if (count == 0)
                return null;

            var columns = new List<(int, string, object)>();
            for (int i = 0; i < @count; i++)
            {
                object value = dr.GetValue(i);
                columns[i] = ((i, dr.GetName(i), value == DBNull.Value ? null : value));
            }

            return columns;
        }
    }
}
