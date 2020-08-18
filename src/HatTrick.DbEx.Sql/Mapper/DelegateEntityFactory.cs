using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class DelegateEntityFactory : IEntityFactory
    {
        #region internals
        private readonly Func<IEntityFactory> factory;
        #endregion

        #region constructors
        public DelegateEntityFactory(Func<IEntityFactory> factory)
        {
            this.factory = factory ?? throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize a Mapper.");
        }
        #endregion

        #region methods
        public T CreateEntity<T>()
            where T : class, IDbEntity, new()
            => factory().CreateEntity<T>();
        #endregion
    }
}
