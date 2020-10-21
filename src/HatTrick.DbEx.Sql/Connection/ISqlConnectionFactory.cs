using System.Data;

namespace HatTrick.DbEx.Sql.Connection
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateSqlConnection();
    }
}
