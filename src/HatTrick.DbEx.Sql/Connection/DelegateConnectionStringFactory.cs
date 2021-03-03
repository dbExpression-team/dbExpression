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
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public DelegateConnectionStringFactory(Func<IConnectionStringFactory> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            this.factory = () => factory()?.GetConnectionString() ?? throw new DbExpressionException("Cannot get a connection string: The factory returned a null value.");
        }
        #endregion

        #region methods
        public string GetConnectionString()
            => factory();
        #endregion
    }
}
