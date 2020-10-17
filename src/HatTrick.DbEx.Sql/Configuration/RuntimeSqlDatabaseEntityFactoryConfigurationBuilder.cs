using HatTrick.DbEx.Sql.Configuration.Syntax;
using HatTrick.DbEx.Sql.Mapper;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class RuntimeSqlDatabaseEntityFactoryConfigurationBuilder : IRuntimeSqlDatabaseEntityFactoryConfigurationBuilder
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        #endregion

        #region constructors
        public RuntimeSqlDatabaseEntityFactoryConfigurationBuilder(RuntimeSqlDatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion

        #region methods
        public void UseThisToInstantiateNewEntities(IEntityFactory factory)
        {
            configuration.EntityFactory = factory;
        }

        public void UseThisToInstantiateNewEntities<T>()
            where T : class, IEntityFactory, new()
        {
            var factory = new T();
            if (factory is EntityFactory defaultFactory)
                defaultFactory.RegisterDefaultFactories();
            configuration.EntityFactory = factory;

        }

        public void UseThisToGetAFactoryForInstantiatingNewEntities<T>(Func<IEntityFactory> factory)
            where T : class, IDbEntity, new()
        {
            configuration.EntityFactory = new DelegateEntityFactory(factory);
        }
        #endregion
    }
}
