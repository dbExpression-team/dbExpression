using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Connection;
using System;
using System.Configuration;

namespace HatTrick.DbEx.MsSql.Connection
{
    public class MsSqlConnectionFactory : SqlConnectionFactory
    {
        private Func<string> connectionStringFactory;

        public MsSqlConnectionFactory(Func<string> connectionStringFactory)
        {
            this.connectionStringFactory = connectionStringFactory;
        }

        public override SqlConnection CreateSqlConnection() => new MsSqlConnection(connectionStringFactory);
    }
}
