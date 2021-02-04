using System;
using System.Data;

namespace HatTrick.DbEx.Sql.Connection
{
    public class DelegateSqlConnectionFactory : ISqlConnectionFactory
    {
        #region internals
        private readonly Func<IDbConnection> factory;
        #endregion

        #region constructors
        public DelegateSqlConnectionFactory(Func<IDbConnection> factory)
        {
            this.factory = factory ?? throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize a Sql Connection."); ;
        }

        public DelegateSqlConnectionFactory(Func<ISqlConnectionFactory> factory)
        {
            if (factory is null)
                throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize a Sql Connection.");

            this.factory = () => factory()?.CreateSqlConnection() ?? throw new DbExpressionException("Cannot create a Sql Connection: The factory returned a null value.");
        }
        #endregion

        #region methods
        public IDbConnection CreateSqlConnection()
            => factory();
        #endregion
    }
}
