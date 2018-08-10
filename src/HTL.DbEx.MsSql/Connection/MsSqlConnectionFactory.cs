using HTL.DbEx.Sql;
using HTL.DbEx.Sql.Connection;
using System.Configuration;

namespace HTL.DbEx.MsSql.Connection
{
    public class MsSqlConnectionFactory : SqlConnectionFactory
    {
        public override SqlConnection CreateSqlConnection(ConnectionStringSettings connectionStringSettings) => new MsSqlConnection(connectionStringSettings);
    }
}
