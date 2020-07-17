using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class EntityFactory : IEntityFactory
    {
        #region interface
        protected IDictionary<Type, Func<IDbEntity>> TypeFactories { get; private set; } = new Dictionary<Type, Func<IDbEntity>>();
        protected IEntityFactory GlobalFactory { get; private set; }
        #endregion

        #region methods
        public virtual void RegisterFactory(IEntityFactory factory)
        {
            GlobalFactory = factory;
        }

        public virtual void RegisterFactory<T>(Func<T> factory)
            where T : class, IDbEntity
        {
            TypeFactories[typeof(T)] = factory;
        }

        public virtual void RegisterDefaultFactories()
        {
        }

        public virtual T CreateEntity<T>()
            where T : class, IDbEntity, new()
        {
            if (TypeFactories.TryGetValue(typeof(T), out var factory))
                return factory.Invoke() as T;

            var entity = GlobalFactory?.CreateEntity<T>();
            if (entity is object)
                return entity;

            return new T();
        }
        #endregion
    }
}
