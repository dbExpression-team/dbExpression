using System.Configuration;

namespace HTL.DbEx.Sql.Connection
{
    public interface ISqlConnectionFactory
    {
        SqlConnection CreateSqlConnection(ConnectionStringSettings connectionStringSettings);
    }
}
