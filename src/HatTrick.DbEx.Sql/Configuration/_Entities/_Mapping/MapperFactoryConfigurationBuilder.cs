using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Mapper;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class MapperFactoryConfigurationBuilder : 
        IMapperFactoryConfigurationBuilder,
        IMapperFactoryContinuationConfigurationBuilder
    {
        #region internals
        private readonly IEntitiesConfigurationBuilderGrouping caller;
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        #endregion

        #region interface
        public IEntityFactoryConfigurationBuilder Creation => caller.Creation;
        #endregion

        #region constructors
        public MapperFactoryConfigurationBuilder(IEntitiesConfigurationBuilderGrouping caller, RuntimeSqlDatabaseConfiguration configuration)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        #endregion

        #region methods
        public IEntitiesConfigurationBuilderCreationGrouping Use(IMapperFactory factory)
        {
            configuration.MapperFactory = factory;
            return caller;
        }

        public IEntitiesConfigurationBuilderCreationGrouping Use<TMapperFactory>()
            where TMapperFactory : class, IMapperFactory, new()
            => Use<TMapperFactory>(null);

        public IEntitiesConfigurationBuilderCreationGrouping Use<TMapperFactory>(Action<TMapperFactory> configureFactory)
            where TMapperFactory : class, IMapperFactory, new()
        {
            if (!(configuration.MapperFactory is TMapperFactory))
                configuration.MapperFactory = new TMapperFactory();
            configureFactory?.Invoke(configuration.MapperFactory as TMapperFactory);
            return caller;
        }

        public IEntitiesConfigurationBuilderCreationGrouping Use(Func<Type, IEntityMapper> factory)
        {
            var expando = new ExpandoObjectMapper();
            configuration.MapperFactory = new DelegateMapperFactory(factory ?? throw new ArgumentNullException(nameof(factory)), () => expando);
            return caller;
        }

        public IEntitiesConfigurationBuilderCreationGrouping UseDefaultFactory()
            => UseDefaultFactory(null);

        public IEntitiesConfigurationBuilderCreationGrouping UseDefaultFactory(Action<IMapperFactoryContinuationConfigurationBuilder> configureFactory)
        {
            if (!(configuration.MapperFactory is MapperFactory))
                configuration.MapperFactory = new MapperFactory();
            configureFactory?.Invoke(this);
            return caller;
        }

        public IMapperFactoryContinuationConfigurationBuilder OverrideForEntity<TEntity>(Action<ISqlFieldReader, TEntity> mapping)
            where TEntity : class, IDbEntity
        {
            (configuration.EntityFactory as MapperFactory).RegisterEntityMapper(mapping);
            return this;
        }
        #endregion
    }
}
