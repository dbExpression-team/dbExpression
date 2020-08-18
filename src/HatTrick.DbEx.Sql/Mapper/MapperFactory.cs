using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Concurrent;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class MapperFactory : IMapperFactory
    {
        #region internals
        private readonly ConcurrentDictionary<Type, Func<IMapper>> _entityMaps = new ConcurrentDictionary<Type, Func<IMapper>>();
        #endregion

        #region methods
        public void RegisterEntityMapper<T>(Action<T, ISqlFieldReader> converter)
            where T : class, IDbEntity => _entityMaps.AddOrUpdate(typeof(T), () => new EntityMapper<T>(converter), (t, f) => () => new EntityMapper<T>(converter));

        public IEntityMapper<T> CreateEntityMapper<T>(EntityExpression<T> entity)
            where T : class, IDbEntity
        {
            if (_entityMaps.TryGetValue(typeof(T), out Func<IMapper> map))
                return map() as IEntityMapper<T>;

            var entityMap = new EntityMapper<T>((entity as IExpressionEntity<T>).HydrateEntity);
            _entityMaps.TryAdd(typeof(T), () => entityMap);

            return entityMap;
        }

        public IExpandoObjectMapper CreateExpandoObjectMapper()
            => new ExpandoObjectMapper();
        #endregion
    }
}
