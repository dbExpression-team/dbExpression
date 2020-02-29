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
            if (mapper == null)
                throw new DbExpressionConfigurationException($"The factory returned a null Mapper for entity type {typeof(T)}.");
            return mapper.CreateEntityMapper(entity);
        }

        public IExpandoObjectMapper CreateExpandoObjectMapper()
        {
            var mapper = factory();
            if (mapper == null)
                throw new DbExpressionConfigurationException($"The factory returned a null Mapper for an Expando Object.");
            return mapper.CreateExpandoObjectMapper();
        }

        public IValueMapProvider<T> CreateValueMapper<T>()
        {
            var mapper = factory();
            if (mapper == null)
                throw new DbExpressionConfigurationException($"The factory returned a null Mapper for value type {typeof(T)}.");
            return mapper.CreateValueMapper<T>();
        }

        public IValueMapper CreateValueMapper()
        {
            var mapper = factory();
            if (mapper == null)
                throw new DbExpressionConfigurationException($"The factory returned a null Mapper for Value Types.");
            return mapper.CreateValueMapper();
        }
        #endregion
    }
}
