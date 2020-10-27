using HatTrick.DbEx.Sql.Connection;
using System.Data.SqlClient;
using System;
using System.Data;

namespace HatTrick.DbEx.MsSql.Connection
{
    public class MsSqlConnectionFactory : SqlConnectionFactory
    {
        private Func<string> connectionStringFactory;

        public MsSqlConnectionFactory(Func<string> connectionStringFactory)
        {
            this.connectionStringFactory = connectionStringFactory;
        }

        public override IDbConnection CreateSqlConnection() => new SqlConnection(connectionStringFactory());
    }
}
