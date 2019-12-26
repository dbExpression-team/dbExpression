using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Mapper;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class MapperFactoryConfigurationBuilder
    {
        private MapperFactory factory;

        public MapperFactoryConfigurationBuilder(MapperFactory factory)
        {
            this.factory = factory;
        }

        public void RegisterEntityMapper<T>(Action<T, ISqlFieldReader, IValueMapper> mapper)
            where T : class, IDbEntity
        {
            factory.RegisterEntityMapper(mapper);
        }

        public void RegisterValueMapper<T>(IValueMapper<T> mapper)
            where T : IComparable
        {
            factory.RegisterValueMapper(mapper);
        }
    }
}
