using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Connection;
using System.Configuration;

namespace HatTrick.DbEx.MsSql.Connection
{
    public class MsSqlConnectionFactory : SqlConnectionFactory
    {
        public override SqlConnection CreateSqlConnection(ConnectionStringSettings connectionStringSettings) => new MsSqlConnection(connectionStringSettings);
    }
}
