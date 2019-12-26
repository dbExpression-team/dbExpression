using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Configuration;

namespace HatTrick.DbEx.MsSql.Connection
{
    public class MsSqlConnectionFactory : SqlConnectionFactory
    {
        private Func<ConnectionStringSettings> ConnectionStringSettingsFactory { get; set; }

        public MsSqlConnectionFactory(Func<ConnectionStringSettings> factory)
        {
            ConnectionStringSettingsFactory = factory;
        }

        public override SqlConnection CreateSqlConnection() => new MsSqlConnection(ConnectionStringSettingsFactory());
    }
}
