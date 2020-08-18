using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class DelegateMapperFactory : IMapperFactory
    {
        #region internals
        private readonly Func<IMapperFactory> factory;
        #endregion

        #region constructors
        public DelegateMapperFactory(Func<IMapperFactory> factory)
        {
            this.factory = factory ?? throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize a Mapper.");
        }
        #endregion

        #region methods
        public IEntityMapper<T> CreateEntityMapper<T>(EntityExpression<T> entity)
            where T : class, IDbEntity
        {
            var mapper = factory();
            if (mapper is null)
                throw new DbExpressionConfigurationException($"The factory returned a null Converter for entity type {typeof(T)}.");
            return mapper.CreateEntityMapper(entity);
        }

        public IExpandoObjectMapper CreateExpandoObjectMapper()
        {
            var mapper = factory();
            if (mapper is null)
                throw new DbExpressionConfigurationException($"The factory returned a null Converter for an Expando Object.");
            return mapper.CreateExpandoObjectMapper();
        }
        #endregion
    }
}
