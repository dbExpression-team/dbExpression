using System;
using System.Data;

namespace HatTrick.DbEx.Sql.Connection
{
    public class DelegateSqlConnectionFactory : ISqlConnectionFactory
    {
        #region internals
        private readonly Func<string, IDbConnection> factory;
        #endregion

        #region constructors
        public DelegateSqlConnectionFactory(Func<string, IDbConnection> factory)
        {
            this.factory = factory ?? throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize a Sql Connection."); ;
        }
        #endregion

        #region methods
        public IDbConnection CreateSqlConnection(string connectionString)
            => factory(connectionString);
        #endregion
    }
}
