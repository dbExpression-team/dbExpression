using HatTrick.DbEx.Sql;
using htl = HatTrick.DbEx.Sql.Connection;
using System.Data.SqlClient;
using System.Data.Common;
using System;
using System.Configuration;
using System.Data;
using System.Net.Http;

namespace HatTrick.DbEx.MsSql.Connection
{
    public class MsSqlConnectionFactory : htl.SqlConnectionFactory
    {
        private Func<string> connectionStringFactory;

        public MsSqlConnectionFactory(Func<string> connectionStringFactory)
        {
            this.connectionStringFactory = connectionStringFactory;
        }

        public override IDbConnection CreateSqlConnection() => new SqlConnection(connectionStringFactory());
    }
}
