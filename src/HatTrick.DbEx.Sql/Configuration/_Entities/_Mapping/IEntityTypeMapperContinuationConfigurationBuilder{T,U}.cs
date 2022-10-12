using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IEntityTypeMapperContinuationConfigurationBuilder<TDatabase, TEntity>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, IDbEntity
    {
        /// <summary>
        /// Override the default behaviour of mapping retrieved rowsets from the database to a <typeparamref name="TEntity"/> instance. 
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="mapping">The delegate that iterates a field reader and maps the field values to <typeparamref name="TEntity"/> properties.</typeparam>
        IEntityMapperContinuationConfigurationBuilder<TDatabase> Use(Action<ISqlFieldReader, TEntity> mapping);

        /// <summary>
        /// Override the default behaviour of mapping retrieved rowsets from the database to a <typeparamref name="TEntity"/> instance. 
        /// </summary>
        /// <typeparam name="T">The entity mapper type to use for mapping data to an <see cref="TEntity"/>.</typeparam>
        IEntityMapperContinuationConfigurationBuilder<TDatabase> Use<T>()
            where T : class, IEntityMapper<TEntity>;

        /// <summary>
        /// Override the default behaviour of mapping retrieved rowsets from the database to a <typeparamref name="TEntity"/> instance. 
        /// </summary>
        /// <param name="mapper">The entity mapper to use for mapping data to an <see cref="TEntity"/>.</param>
        IEntityMapperContinuationConfigurationBuilder<TDatabase> Use(IEntityMapper<TEntity> mapper);

        /// <summary>
        /// Override the default behaviour of mapping retrieved rowsets from the database to a <typeparamref name="TEntity"/> instance. 
        /// </summary>
        /// <param name="factory">A delegate that returns an entity mapper to use for mapping data to an <see cref="TEntity"/>.</param>
        IEntityMapperContinuationConfigurationBuilder<TDatabase> Use(Func<IEntityMapper<TEntity>> factory);

        /// <summary>
        /// Override the default behaviour of mapping retrieved rowsets from the database to a <typeparamref name="TEntity"/> instance. 
        /// </summary>
        /// <param name="factory">A delegate that returns an entity mapper to use for mapping data to an <see cref="TEntity"/>.</param>
        IEntityMapperContinuationConfigurationBuilder<TDatabase> Use(Func<IServiceProvider, IEntityMapper<TEntity>> factory);
    }
}
