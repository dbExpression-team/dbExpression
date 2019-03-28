using HatTrick.DbEx.Sql.Mapper;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class EntityFactoryConfigurationBuilder
    {
        private IEntityFactory _factory;

        public EntityFactoryConfigurationBuilder(IEntityFactory factory)
        {
            _factory = factory;
        }

        public void RegisterFactory<T>(Func<T> factory)
            where T : class, IDbEntity
        {
            _factory.RegisterFactory(factory);
        }
    }
}
