using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class EntityFactory : IEntityFactory
    {
        private IDictionary<Type, Func<IEntityFactory>> factories = new Dictionary<Type, Func<IEntityFactory>>();

        public void RegisteFactory<T>(IEntityFactory factory)
            where T : class, IDbEntity
        {
            factories[typeof(T)] = () => factory;
        }

        public void RegisterFactory<T>(Func<IEntityFactory> factory)
            where T : class, IDbEntity
        {
            factories[typeof(T)] = factory;
        }

        public void RegisterDefaultFactories()
        {
        }

        public T CreateEntity<T>() where T : class, IDbEntity, new() 
            => factories.ContainsKey(typeof(T)) ? factories[typeof(T)]().CreateEntity<T>() : new T();
    }
}
