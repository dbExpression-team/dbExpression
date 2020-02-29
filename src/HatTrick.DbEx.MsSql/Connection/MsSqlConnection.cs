using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using ht = HatTrick.DbEx.Sql;

namespace HatTrick.DbEx.MsSql
{
    public class MsSqlConnection : ht.SqlConnection
    {
        #region constructors
        public MsSqlConnection() : base()
        {
        }

        public MsSqlConnection(string connectionStringName) : base(connectionStringName)
        {
        }

        public MsSqlConnection(ConnectionStringSettings settings) : base(settings)
        {
        }
        #endregion

        #region concrete connection provider 
        protected override void EnsureConnection()
        {
            if (_dbConnection == null)
            {
                _dbConnection = new SqlConnection(ConnectionSettings.ConnectionString);
            }
        }
        #endregion

        #region helper methods
        public override DbCommand GetDbCommand() => new SqlCommand();
        #endregion
    }
}
