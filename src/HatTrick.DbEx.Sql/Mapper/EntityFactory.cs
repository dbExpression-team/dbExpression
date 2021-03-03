using System;
using System.Collections.Concurrent;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class EntityFactory : IEntityFactory
    {
        #region interface
        private readonly ConcurrentDictionary<Type, Func<IDbEntity>> typeFactories = new ConcurrentDictionary<Type, Func<IDbEntity>>();
        #endregion

        #region methods
        public virtual void RegisterFactory<TEntity>(Func<TEntity> factory)
            where TEntity : class, IDbEntity
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            typeFactories.AddOrUpdate(typeof(TEntity), factory, (t, f) => factory);
        }

        public virtual TEntity CreateEntity<TEntity>()
            where TEntity : class, IDbEntity, new()
        {
            if (typeFactories.TryGetValue(typeof(TEntity), out var factory))
                return factory.Invoke() as TEntity;

            return new TEntity();
        }
        #endregion
    }
}
