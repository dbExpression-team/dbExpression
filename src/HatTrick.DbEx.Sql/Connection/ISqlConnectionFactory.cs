using System.Configuration;

namespace HatTrick.DbEx.Sql.Connection
{
    public interface ISqlConnectionFactory
    {
        SqlConnection CreateSqlConnection(ConnectionStringSettings connectionStringSettings);
    }
}
