using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class DelegateEntityFactory : IEntityFactory
    {
        #region internals
        private readonly Func<Type, IDbEntity> factory;
        #endregion

        #region constructors
        public DelegateEntityFactory(Func<Type, IDbEntity> factory)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        #endregion

        #region methods
        public virtual void RegisterFactory<TEntity>(Func<TEntity> entityFactory)
            where TEntity : class, IDbEntity
            => throw new InvalidOperationException("Entity initialization is deferred to a delegate that doesn't support registration of an entity-specific factory.");

        public TEntity CreateEntity<TEntity>()
            where TEntity : class, IDbEntity, new()
            => factory.Invoke(typeof(TEntity)) as TEntity;
        #endregion
    }
}
