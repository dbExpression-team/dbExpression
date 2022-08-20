#region license
// Copyright (c) HatTrick Labs, LLC.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/HatTrickLabs/db-ex
#endregion

﻿using HatTrick.DbEx.Sql.Mapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class EntityFactoryConfigurationBuilder<TDatabase> : 
        IEntityFactoryConfigurationBuilder<TDatabase>,
        IEntityFactoryContinuationConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly IEntitiesConfigurationBuilderGrouping<TDatabase> caller;
        private readonly IServiceCollection services;
        #endregion

        #region interface
        public IMapperFactoryConfigurationBuilder<TDatabase> Mapping => caller.Mapping;
        #endregion

        #region constructors
        public EntityFactoryConfigurationBuilder(IEntitiesConfigurationBuilderGrouping<TDatabase> caller, IServiceCollection services)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }
        #endregion

        #region methods
        /// <inheritdoc />
        public IEntitiesConfigurationBuilderMappingGrouping<TDatabase> Use(IEntityFactory factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton(factory);
            return caller;
        }

        /// <inheritdoc />
        public IEntitiesConfigurationBuilderMappingGrouping<TDatabase> Use<TEntityFactory>()
            where TEntityFactory : class, IEntityFactory
        {
            services.TryAddSingleton<IEntityFactory, TEntityFactory>();
            return caller;
        }

        /// <inheritdoc />
        public IEntitiesConfigurationBuilderMappingGrouping<TDatabase> Use(Func<Type, IDbEntity> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IEntityFactory>(sp => new DefaultEntityFactoryWithFallbackConstruction(
                    sp.GetRequiredService<ILogger<DefaultEntityFactoryWithFallbackConstruction>>(), 
                    t => factory(t)
                )
            );
            return caller;
        }

        /// <inheritdoc />
        public IEntitiesConfigurationBuilderMappingGrouping<TDatabase> Use(Func<IServiceProvider, Type, IDbEntity> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IEntityFactory>(sp => new DefaultEntityFactoryWithFallbackConstruction(
                    sp.GetRequiredService<ILogger<DefaultEntityFactoryWithFallbackConstruction>>(),
                    t => factory(sp, t)
                )
            );
            return caller;
        }

        /// <inheritdoc />
        public IEntitiesConfigurationBuilderMappingGrouping<TDatabase> Use(Func<IServiceProvider, Type, IDbEntity> factory, Action<IEntityFactoryContinuationConfigurationBuilder<TDatabase>> configureEntityTypes)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IEntityFactory>(sp => new DefaultEntityFactoryWithFallbackConstruction(
                    sp.GetRequiredService<ILogger<DefaultEntityFactoryWithFallbackConstruction>>(),
                    t => factory(sp, t)
                )
            );
            configureEntityTypes.Invoke(new EntityFactoryConfigurationBuilder<TDatabase>(caller, services));
            return caller;
        }

        /// <inheritdoc />
        public IEntitiesConfigurationBuilderMappingGrouping<TDatabase> Use(Func<IServiceProvider, IEntityFactory> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddTransient<IEntityFactory>(factory);
            return caller;
        }

        /// <inheritdoc />
        public IEntitiesConfigurationBuilderMappingGrouping<TDatabase> Use(Func<IServiceProvider, IEntityFactory> factory, Action<IEntityFactoryContinuationConfigurationBuilder<TDatabase>> configureEntityTypes)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IEntityFactory>(factory);
            configureEntityTypes.Invoke(new EntityFactoryConfigurationBuilder<TDatabase>(caller, services));
            return caller;
        }

        /// <inheritdoc />
        public void ForEntityTypes(Action<IEntityFactoryContinuationConfigurationBuilder<TDatabase>> configureEntityTypes)
        {
            if (configureEntityTypes is null)
                throw new ArgumentNullException(nameof(configureEntityTypes));

            configureEntityTypes.Invoke(new EntityFactoryConfigurationBuilder<TDatabase>(caller, services));
        }

        /// <inheritdoc />
        public IEntityFactoryEntityConfigurationBuilder<TDatabase, TEntity> ForEntityType<TEntity>()
            where TEntity : class, IDbEntity
        {
            return new EntityFactoryEntityConfigurationBuilder<TDatabase, TEntity>(this, services);
        }
        #endregion
    }
}
