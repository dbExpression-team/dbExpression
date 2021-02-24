using HatTrick.DbEx.Sql.Mapper;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class EntityFactoryConfigurationBuilder : 
        IEntityFactoryConfigurationBuilder,
        IEntityFactoryContinuationConfigurationBuilder
    {
        #region internals
        private readonly IEntitiesConfigurationBuilderGrouping caller;
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        #endregion

        #region interface
        public IMapperFactoryConfigurationBuilder Mapping => caller.Mapping;
        #endregion

        #region constructors
        public EntityFactoryConfigurationBuilder(IEntitiesConfigurationBuilderGrouping caller, RuntimeSqlDatabaseConfiguration configuration)
        {
            this.caller = caller ?? throw new ArgumentNullException($"{nameof(caller)} is required.");
            this.configuration = configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.");
        }
        #endregion

        #region methods
        public IEntitiesConfigurationBuilderMappingGrouping Use(IEntityFactory factory)
        {
            configuration.EntityFactory = factory;
            return caller;
        }

        public IEntitiesConfigurationBuilderMappingGrouping Use<TEntityFactory>()
            where TEntityFactory : class, IEntityFactory, new()
            => Use<TEntityFactory>(null);

        public IEntitiesConfigurationBuilderMappingGrouping Use<TEntityFactory>(Action<TEntityFactory> configureFactory)
            where TEntityFactory : class, IEntityFactory, new()
        {
            if (!(configuration.EntityFactory is TEntityFactory))
                configuration.EntityFactory = new TEntityFactory();
            configureFactory?.Invoke(configuration.MapperFactory as TEntityFactory);
            return caller;
        }

        public IEntitiesConfigurationBuilderMappingGrouping Use(Func<Type, IDbEntity> factory)
        {
            configuration.EntityFactory = new DelegateEntityFactory(factory ?? throw new ArgumentNullException($"{nameof(factory)} is required."));
            return caller;
        }

        public IEntitiesConfigurationBuilderMappingGrouping UseDefaultFactory()
            => UseDefaultFactory(null);

        public IEntitiesConfigurationBuilderMappingGrouping UseDefaultFactory(Action<IEntityFactoryContinuationConfigurationBuilder> configureFactory)
        {
            if (!(configuration.EntityFactory is EntityFactory))
                configuration.EntityFactory = new EntityFactory();
            configureFactory?.Invoke(this);
            return caller;
        }

        public IEntityFactoryContinuationConfigurationBuilder OverrideForEntity<T>(Func<T> entityFactory)
            where T : class, IDbEntity
        {
            (configuration.EntityFactory as EntityFactory).RegisterFactory(entityFactory ?? throw new ArgumentNullException($"{nameof(entityFactory)} is required."));
            return this;
        }
        #endregion
    }
}
