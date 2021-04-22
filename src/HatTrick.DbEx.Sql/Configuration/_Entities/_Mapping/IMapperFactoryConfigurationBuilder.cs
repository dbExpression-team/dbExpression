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
