using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Mapper;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class MapperFactoryConfigurationBuilder
    {
        private IMapperFactory _factory;

        public MapperFactoryConfigurationBuilder(IMapperFactory factory)
        {
            _factory = factory;
        }

        public void RegisterEntityMapper<T>(Action<T, ISqlFieldReader, IValueMapper> mapper)
            where T : class, IDbEntity
        {
            _factory.RegisterEntityMapper(mapper);
        }

        public void RegisterValueMapper<T>(IValueMapper<T> mapper)
            where T : IComparable
        {
            _factory.RegisterValueMapper(mapper);
        }
    }
}
