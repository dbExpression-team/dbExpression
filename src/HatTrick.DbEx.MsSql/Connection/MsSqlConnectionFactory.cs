using HatTrick.DbEx.Sql.Connection;
using System.Data.SqlClient;
using System;
using System.Data;

namespace HatTrick.DbEx.MsSql.Connection
{
    public class MsSqlConnectionFactory : SqlConnectionFactory
    {
        #region methods
        public override IDbConnection CreateSqlConnection(string connectionString) => new SqlConnection(connectionString);
        #endregion
    }
}
