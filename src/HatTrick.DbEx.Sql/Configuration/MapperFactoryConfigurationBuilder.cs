using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Mapper;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class MapperFactoryConfigurationBuilder
    {
        private readonly MapperFactory factory;

        public MapperFactoryConfigurationBuilder(MapperFactory factory)
        {
            this.factory = factory;
        }

        public void RegisterEntityMapper<T>(Action<T, ISqlFieldReader> map)
            where T : class, IDbEntity
            => factory.RegisterEntityMapper(map);
    }
}
