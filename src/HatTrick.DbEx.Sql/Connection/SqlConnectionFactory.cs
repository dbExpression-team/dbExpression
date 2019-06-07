using System;
using System.Configuration;

namespace HatTrick.DbEx.Sql.Connection
{
    public abstract class SqlConnectionFactory : ISqlConnectionFactory
    {
        public abstract SqlConnection CreateSqlConnection();
        public virtual SqlConnection CreateSqlConnection(ConnectionStringSettings connectionStringSettings) => throw new NotImplementedException("Connection factory requires database platform specific implementation");
    }
}
