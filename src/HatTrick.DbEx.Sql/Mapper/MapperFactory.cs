using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Concurrent;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class MapperFactory : IMapperFactory
    {
        #region internals
        private readonly ConcurrentDictionary<Type, Func<IMapper>> entityMappers = new ConcurrentDictionary<Type, Func<IMapper>>();
        #endregion

        #region methods
        public void RegisterEntityMapper<TEntity>(Action<ISqlFieldReader, TEntity> converter)
            where TEntity : class, IDbEntity
        {
            if (converter is null)
                throw new ArgumentNullException($"{nameof(converter)} is required.");

            entityMappers.AddOrUpdate(typeof(TEntity), () => new EntityMapper<TEntity>(converter), (t, f) => () => new EntityMapper<TEntity>(converter));
        }

        public IEntityMapper<TEntity> CreateEntityMapper<TEntity>(IEntityExpression<TEntity> entity)
            where TEntity : class, IDbEntity
        {
            if (entityMappers.TryGetValue(typeof(TEntity), out Func<IMapper> map))
                return map() as IEntityMapper<TEntity>;

            var entityMap = new EntityMapper<TEntity>(entity.HydrateEntity);
            entityMappers.TryAdd(typeof(TEntity), () => entityMap);

            return entityMap;
        }

        public IExpandoObjectMapper CreateExpandoObjectMapper()
            => new ExpandoObjectMapper();
        #endregion
    }
}
