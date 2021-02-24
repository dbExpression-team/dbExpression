using System;

namespace HatTrick.DbEx.Sql.Connection
{
    public class DelegateConnectionStringFactory : IConnectionStringFactory
    {
        #region internals
        private readonly Func<string> factory;
        #endregion

        #region constructors
        public DelegateConnectionStringFactory(Func<string> factory)
        {
            this.factory = factory ?? throw new DbExpressionConfigurationException($"{nameof(factory)} is required."); ;
        }

        public DelegateConnectionStringFactory(Func<IConnectionStringFactory> factory)
        {
            if (factory is null)
                throw new DbExpressionConfigurationException($"{nameof(factory)} is required.");

            this.factory = () => factory()?.GetConnectionString() ?? throw new DbExpressionException("Cannot get a connection string: The factory returned a null value.");
        }
        #endregion

        #region methods
        public string GetConnectionString()
            => factory();
        #endregion
    }
}
