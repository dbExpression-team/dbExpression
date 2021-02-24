using System.Data;

namespace HatTrick.DbEx.Sql.Connection
{
    public abstract class SqlConnectionFactory : ISqlConnectionFactory
    {
        public abstract IDbConnection CreateSqlConnection(string connectionString);
    }
}
