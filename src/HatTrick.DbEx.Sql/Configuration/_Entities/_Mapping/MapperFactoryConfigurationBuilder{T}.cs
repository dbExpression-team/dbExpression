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

﻿using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Mapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class MapperFactoryConfigurationBuilder<TDatabase> :
        IMapperFactoryConfigurationBuilder<TDatabase>,
        IEntityMapperContinuationConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly IEntitiesConfigurationBuilderGrouping<TDatabase> caller;
        private readonly IServiceCollection services;
        #endregion

        #region interface
        public IEntityFactoryConfigurationBuilder<TDatabase> Creation => caller.Creation;
        #endregion

        #region constructors
        public MapperFactoryConfigurationBuilder(IEntitiesConfigurationBuilderGrouping<TDatabase> caller, IServiceCollection services)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }
        #endregion

        #region methods
        /// <inheritdoc />
        public IEntitiesConfigurationBuilderCreationGrouping<TDatabase> Use(IMapperFactory factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton(factory);
            return caller;
        }

        /// <inheritdoc />
        public IEntitiesConfigurationBuilderCreationGrouping<TDatabase> Use(Func<IMapperFactory> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton(factory);
            return caller;
        }
        
        /// <inheritdoc />
        public IEntitiesConfigurationBuilderCreationGrouping<TDatabase> Use<TMapperFactory>()
            where TMapperFactory : class, IMapperFactory
        {
            services.TryAddSingleton<IMapperFactory, TMapperFactory>();
            return caller;
        }

        /// <inheritdoc />
        public IEntitiesConfigurationBuilderCreationGrouping<TDatabase> Use(Func<Type, IEntityMapper> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IMapperFactory>(sp => new DelegateMapperFactory(factory, () => sp.GetRequiredService<IExpandoObjectMapper>()));
            return caller;
        }

        /// <inheritdoc />
        public IEntitiesConfigurationBuilderCreationGrouping<TDatabase> Use(Func<IServiceProvider, Type, IEntityMapper> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IMapperFactory>(sp => new DelegateMapperFactory(t => factory(sp, t), () => sp.GetRequiredService<IExpandoObjectMapper>()));
            return caller;
        }

        /// <inheritdoc />
        public IEntitiesConfigurationBuilderCreationGrouping<TDatabase> Use(Func<IServiceProvider, IMapperFactory> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IMapperFactory>(factory);
            return caller;
        }

        /// <inheritdoc />
        public IEntityMapperContinuationConfigurationBuilder<TDatabase> ForEntityTypes(Action<IEntityMapperContinuationConfigurationBuilder<TDatabase>> configureEntityTypes)
        {
            if (configureEntityTypes is null)
                throw new ArgumentNullException(nameof(configureEntityTypes));

            configureEntityTypes.Invoke(this);

            return this;
        }

        /// <inheritdoc />
        public IEntityTypeMapperContinuationConfigurationBuilder<TDatabase, TEntity> ForEntityType<TEntity>()
            where TEntity : class, IDbEntity
        {
            return new EntityTypeMapperContinuationConfigurationBuilder<TDatabase, TEntity>(this, services);
        }
        #endregion
    }
}
