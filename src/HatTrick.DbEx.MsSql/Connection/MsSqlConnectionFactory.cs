using HatTrick.DbEx.Sql.Connection;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HatTrick.DbEx.MsSql.Connection
{
    public class MsSqlConnectionFactory : ISqlConnectionFactory
    {
        #region methods
        public IDbConnection CreateSqlConnection(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("The provided connection string is null or empty.  Cannot create a database connection.");
            return new SqlConnection(connectionString);
        }
        #endregion
    }
}
