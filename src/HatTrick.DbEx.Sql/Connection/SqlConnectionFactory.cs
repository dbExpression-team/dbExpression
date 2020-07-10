namespace HatTrick.DbEx.Sql.Connection
{
    public abstract class SqlConnectionFactory : ISqlConnectionFactory
    {
        public abstract ISqlConnection CreateSqlConnection();
    }
}
