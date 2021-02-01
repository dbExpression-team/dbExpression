using HatTrick.DbEx.Sql.Mapper;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IMapperFactoryConfigurationBuilder
    {
        /// <summary>
        /// Use a custom factory to create a <see cref="IEntityMapper"/> used to map data retrieved from the target database.
        /// </summary>
        IEntitiesConfigurationBuilderCreationGrouping Use(IMapperFactory factory);

        /// <summary>
        /// Use a custom factory to create a <see cref="IEntityMapper"/> used to map data retrieved from the target database.
        /// </summary>
        IEntitiesConfigurationBuilderCreationGrouping Use<TMapperFactory>()
            where TMapperFactory : class, IMapperFactory, new();

        /// <summary>
        /// Use a custom factory to create a <see cref="IEntityMapper"/> used to map data retrieved from the target database.
        /// </summary>
        /// <param name="configureFactory">A delegate for configuring the <typeparamref name="TMapperFactory"/>.</param>
        IEntitiesConfigurationBuilderCreationGrouping Use<TMapperFactory>(Action<TMapperFactory> configureFactory)
            where TMapperFactory : class, IMapperFactory, new();

        /// <summary>
        /// Use a custom factory to create a <see cref="IEntityMapper"/> used to map data retrieved from the target database.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IEntityMapper"/>.</param>
        IEntitiesConfigurationBuilderCreationGrouping Use(Func<Type, IEntityMapper> factory);

        /// <summary>
        /// Use a custom factory to create a <see cref="IEntityMapper"/> used to map data retrieved from the target database.
        /// </summary>
        IEntitiesConfigurationBuilderCreationGrouping UseDefaultFactory();

        /// <summary>
        /// Use a custom factory to create a <see cref="IEntityMapper"/> used to map data retrieved from the target database.
        /// </summary>
        /// <param name="configureFactory">Configure the default factory.</param>
        IEntitiesConfigurationBuilderCreationGrouping UseDefaultFactory(Action<IMapperFactoryContinuationConfigurationBuilder> configureFactory);
    }
}
