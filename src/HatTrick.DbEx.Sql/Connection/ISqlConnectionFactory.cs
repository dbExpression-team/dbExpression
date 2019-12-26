using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Connection
{
    public interface ISqlConnectionFactory
    {
        SqlConnection CreateSqlConnection();
    }
}
