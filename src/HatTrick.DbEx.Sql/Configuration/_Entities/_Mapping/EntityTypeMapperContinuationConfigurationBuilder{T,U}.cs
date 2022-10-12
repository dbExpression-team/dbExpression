using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Mapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class EntityTypeMapperContinuationConfigurationBuilder<TDatabase, TEntity> : IEntityTypeMapperContinuationConfigurationBuilder<TDatabase, TEntity>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, IDbEntity
    {
        private readonly IEntityMapperContinuationConfigurationBuilder<TDatabase> caller;
        private readonly IServiceCollection services;

        public EntityTypeMapperContinuationConfigurationBuilder(IEntityMapperContinuationConfigurationBuilder<TDatabase> caller, IServiceCollection services)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }

        /// <inheritdoc/>
        public IEntityMapperContinuationConfigurationBuilder<TDatabase> Use(Action<ISqlFieldReader, TEntity> mapping)
        {
            services.TryAddSingleton<IEntityMapper<TEntity>>(new EntityMapper<TEntity>(mapping));
            return caller;
        }

        /// <inheritdoc/>
        public IEntityMapperContinuationConfigurationBuilder<TDatabase> Use<T>()
            where T : class, IEntityMapper<TEntity>
        {
            services.TryAddSingleton<IEntityMapper<TEntity>, T>();
            return caller;
        }

        /// <inheritdoc/>
        public IEntityMapperContinuationConfigurationBuilder<TDatabase> Use(IEntityMapper<TEntity> mapper)
        {
            services.TryAddSingleton<IEntityMapper<TEntity>>(mapper);
            return caller;
        }

        /// <inheritdoc/>
        public IEntityMapperContinuationConfigurationBuilder<TDatabase> Use(Func<IEntityMapper<TEntity>> factory)
        {
            services.TryAddSingleton<IEntityMapper<TEntity>>(sp => factory());
            return caller;
        }

        /// <inheritdoc/>
        public IEntityMapperContinuationConfigurationBuilder<TDatabase> Use(Func<IServiceProvider, IEntityMapper<TEntity>> factory)
        {
            services.TryAddSingleton<IEntityMapper<TEntity>>(factory);
            return caller;
        }
    }
}
