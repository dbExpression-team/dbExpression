using HatTrick.DbEx.Sql.Mapper;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IEntityFactoryConfigurationBuilder
    {
        /// <summary>
        /// Use a custom factory to create an entity prior to mapping data retrieved from the target database.
        /// </summary>
        IEntitiesConfigurationBuilderMappingGrouping Use(IEntityFactory factory);

        /// <summary>
        /// Use a custom factory to create an entity prior to mapping data retrieved from the target database.
        /// </summary>
        IEntitiesConfigurationBuilderMappingGrouping Use<TEntityFactory>()
            where TEntityFactory : class, IEntityFactory, new();

        /// <summary>
        /// Use a custom factory to create an entity prior to mapping data retrieved from the target database.
        /// </summary>
        /// <param name="configureFactory">A delegate for configuring the <typeparamref name="TEntityFactory"/>.</param>
        IEntitiesConfigurationBuilderMappingGrouping Use<TEntityFactory>(Action<TEntityFactory> configureFactory)
            where TEntityFactory : class, IEntityFactory, new();

        /// <summary>
        /// Use a custom factory to create an entity prior to mapping data retrieved from the target database.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IDbEntity"/>.</param>
        IEntitiesConfigurationBuilderMappingGrouping Use(Func<Type, IDbEntity> factory);

        /// <summary>
        /// Use the default factory to create an entity prior to mapping data retrieved from the target database (default behaviour calls a public parameterless constructor to create an entity instance).
        /// </summary>
        IEntitiesConfigurationBuilderMappingGrouping UseDefaultFactory();

        /// <summary>
        /// Use the default factory to create an entity prior to mapping data retrieved from the target database (default behaviour calls a public parameterless constructor to create an entity instance).
        /// </summary>
        /// <param name="configureFactory">Configure the default factory.</param>
        IEntitiesConfigurationBuilderMappingGrouping UseDefaultFactory(Action<IEntityFactoryContinuationConfigurationBuilder> configureFactory);
    }
}
