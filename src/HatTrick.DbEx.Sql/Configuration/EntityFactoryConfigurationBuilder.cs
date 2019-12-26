using HatTrick.DbEx.Sql.Mapper;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class EntityFactoryConfigurationBuilder
    {
        private EntityFactory factory;

        public EntityFactoryConfigurationBuilder(EntityFactory factory)
        {
            this.factory = factory;
        }

        public void RegisterFactory<T>(Func<T> factory)
            where T : class, IDbEntity
        {
            this.factory.RegisterFactory(factory);
        }
    }
}
