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
