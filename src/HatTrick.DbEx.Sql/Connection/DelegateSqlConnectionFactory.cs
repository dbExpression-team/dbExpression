using HatTrick.DbEx.Sql.Expression;
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

            this.factory = new Func<IDbConnection>(() =>
            {
                var f = factory().CreateSqlConnection();
                if (f is null)
                    throw new DbExpressionException("Cannot create a Sql Connection: The factory returned a null value.");
                return f;
            });
        }
        #endregion

        #region methods
        public IDbConnection CreateSqlConnection()
            => factory();
        #endregion
    }
}
