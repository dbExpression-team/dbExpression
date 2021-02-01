using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class DelegateMapperFactory : IMapperFactory
    {
        #region internals
        private readonly Func<Type,IEntityMapper> entityMapperFactory;
        private readonly Func<IExpandoObjectMapper> expandoObjectMapperFactory;
        #endregion

        #region constructors
        public DelegateMapperFactory(Func<Type, IEntityMapper> entityMapperFactory, Func<IExpandoObjectMapper> expandoObjectMapperFactory)
        {
            this.entityMapperFactory = entityMapperFactory ?? throw new DbExpressionConfigurationException($"{nameof(entityMapperFactory)} is required to initialize a Mapper.");
            this.expandoObjectMapperFactory = expandoObjectMapperFactory ?? throw new DbExpressionConfigurationException($"{nameof(expandoObjectMapperFactory)} is required to initialize a Mapper.");
        }
        #endregion

        #region methods
        public IEntityMapper<TEntity> CreateEntityMapper<TEntity>(EntityExpression<TEntity> entity)
            where TEntity : class, IDbEntity
        {
            var mapper = entityMapperFactory(typeof(TEntity));
            if (mapper is IEntityMapper<TEntity> entityMapper)
                return entityMapper;
            if (mapper is null)
                throw new DbExpressionConfigurationException($"The factory returned a null mapper for entity type {typeof(TEntity)}.");
            throw new DbExpressionConfigurationException($"The factory is not an {typeof(IEntityMapper<TEntity>).Name}, cannot use the factory to create a mapper for entity type {typeof(TEntity)}.");
        }

        public IExpandoObjectMapper CreateExpandoObjectMapper()
        {
            var mapper = expandoObjectMapperFactory();
            if (mapper is object)
                return mapper;
            throw new DbExpressionConfigurationException($"The factory returned a null mapper for an {typeof(IExpandoObjectMapper).Name}");
        }
        #endregion
    }
}
