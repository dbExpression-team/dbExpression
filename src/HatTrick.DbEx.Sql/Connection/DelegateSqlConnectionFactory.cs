using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Connection
{
    public class DelegateSqlConnectionFactory : ISqlConnectionFactory
    {
        #region internals
        private readonly Func<ISqlConnection> factory;
        #endregion

        #region constructors
        public DelegateSqlConnectionFactory(Func<SqlConnection> factory)
        {
            this.factory = factory ?? throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize a Sql Connection."); ;
        }

        public DelegateSqlConnectionFactory(Func<ISqlConnectionFactory> factory)
        {
            if (factory == null)
                throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize a Sql Connection.");

            this.factory = new Func<ISqlConnection>(() =>
            {
                var f = factory().CreateSqlConnection();
                if (f == null)
                    throw new DbExpressionException("Cannot create a Sql Connection: The factory returned a null value.");
                return f;
            });
        }
        #endregion

        #region methods
        public ISqlConnection CreateSqlConnection()
            => factory();
        #endregion
    }
}
