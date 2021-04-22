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
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
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
            configuration.EntityFactory = new DelegateEntityFactory(factory ?? throw new ArgumentNullException(nameof(factory)));
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
            (configuration.EntityFactory as EntityFactory).RegisterFactory(entityFactory ?? throw new ArgumentNullException(nameof(entityFactory)));
            return this;
        }
        #endregion
    }
}
