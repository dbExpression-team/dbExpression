using HatTrick.DbEx.Sql.Connection;
using System.Data.SqlClient;
using System;
using System.Data;

namespace HatTrick.DbEx.MsSql.Connection
{
    public class MsSqlConnectionFactory : SqlConnectionFactory
    {
        #region internals
        private readonly Func<string> connectionStringFactory;
        private readonly Func<string, IDbConnection> connectionFactory;
        #endregion

        #region constructors

        public MsSqlConnectionFactory(Func<string> connectionStringFactory) : this(connectionStringFactory, connectionString => new SqlConnection(connectionString))
        {

        }

        public MsSqlConnectionFactory(Func<string> connectionStringFactory, Func<string, IDbConnection> connectionFactory)
        {
            this.connectionStringFactory = connectionStringFactory ?? throw new ArgumentNullException($"{nameof(connectionStringFactory)} is required.");
            this.connectionFactory = connectionFactory ?? throw new ArgumentNullException($"{nameof(connectionFactory)} is required.");
        }
        #endregion

        #region methods
        public override IDbConnection CreateSqlConnection() => connectionFactory(connectionStringFactory());
        #endregion
    }
}
