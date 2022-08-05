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
using HatTrick.DbEx.Sql.Mapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class MapperFactoryConfigurationBuilder<TDatabase> :
        IMapperFactoryConfigurationBuilder<TDatabase>,
        IMapperFactoryContinuationConfigurationBuilder<TDatabase>
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
        public IEntitiesConfigurationBuilderCreationGrouping<TDatabase> Use(IMapperFactory<TDatabase> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton(factory);
            return caller;
        }

        /// <inheritdoc />
        public IEntitiesConfigurationBuilderCreationGrouping<TDatabase> Use<TMapperFactory>()
            where TMapperFactory : class, IMapperFactory<TDatabase>
        {
            services.TryAddSingleton<IMapperFactory<TDatabase>, TMapperFactory>();
            return caller;
        }

        /// <inheritdoc />
        public IEntitiesConfigurationBuilderCreationGrouping<TDatabase> Use(Func<Type, IEntityMapper> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IMapperFactory<TDatabase>>(sp => new DelegateMapperFactory<TDatabase>(factory, () => sp.GetRequiredService<IExpandoObjectMapper>()));
            return caller;
        }

        /// <inheritdoc />
        public IEntitiesConfigurationBuilderCreationGrouping<TDatabase> Use(Func<IServiceProvider, Type, IEntityMapper> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IMapperFactory<TDatabase>>(sp => new DelegateMapperFactory<TDatabase>(t => factory(sp, t), () => sp.GetRequiredService<IExpandoObjectMapper>()));
            return caller;
        }

        /// <inheritdoc />
        public IEntitiesConfigurationBuilderCreationGrouping<TDatabase> Use(Func<IServiceProvider, IMapperFactory<TDatabase>> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IMapperFactory<TDatabase>>(factory);
            return caller;
        }

        /// <inheritdoc />
        public IMapperFactoryContinuationConfigurationBuilder<TDatabase> ForEntityType<TEntity>(Action<ISqlFieldReader, TEntity> mapping)
            where TEntity : class, IDbEntity
        {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));

            services.TryAddSingleton<IEntityMapper<TEntity>>(new EntityMapper<TEntity>(mapping));
            return this;
        }
        #endregion
    }
}
