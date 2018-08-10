using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace HTL.DbEx.Sql.Executor
{
    public abstract class SqlExecutor : ISqlExecutor
    {
        public virtual int ExecuteNonQuery(SqlConnection connection, string executionCommand, DbCommandType commandType, IList<DbParameter> param, int? commandTimeout = null)
        {
            int @return = 0;

            DbCommand cmd = connection.GetDbCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
            cmd.CommandText = executionCommand;
            cmd.CommandType = (commandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (commandTimeout.HasValue)
            {
                cmd.CommandTimeout = commandTimeout.Value;
            }
            if (param != null) { cmd.Parameters.AddRange(param.ToArray()); }
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

        public virtual ResultSet ExecuteQuery(SqlConnection connection, string executionCommand, DbCommandType commandType, IList<DbParameter> param, int? commandTimeout = null)
            => throw new NotImplementedException($"{this.GetType().Name} does not implement ExecuteQuery.");

    }
}
