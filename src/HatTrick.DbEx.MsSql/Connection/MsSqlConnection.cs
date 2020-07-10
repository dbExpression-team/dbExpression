using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using ht = HatTrick.DbEx.Sql.Connection;

namespace HatTrick.DbEx.MsSql
{
    public class MsSqlConnection : ht.SqlConnection
    {
        #region constructors
        public MsSqlConnection() : base()
        {
        }

        public MsSqlConnection(Func<string> connectionStringFactory) : base(connectionStringFactory)
        {
        }
        #endregion

        #region concrete connection provider 
        protected override void EnsureConnection()
        {
            if (_dbConnection == null)
            {
                _dbConnection = new SqlConnection(ConnectionStringFactory());
            }
        }
        #endregion

        #region helper methods
        public override DbCommand CreateDbCommand() => new SqlCommand();
        #endregion
    }
}
