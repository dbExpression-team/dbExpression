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
    public interface IEntityFactoryConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Use a custom factory to create an entity prior to mapping data retrieved from the target database.
        /// </summary>
        IEntitiesConfigurationBuilderMappingGrouping<TDatabase> Use(IEntityFactory factory);

        /// <summary>
        /// Use a custom factory to create an entity prior to mapping data retrieved from the target database.
        /// </summary>
        IEntitiesConfigurationBuilderMappingGrouping<TDatabase> Use<TEntityFactory>()
            where TEntityFactory : class, IEntityFactory;

        /// <summary>
        /// Use a custom factory to create an entity prior to mapping data retrieved from the target database.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IDbEntity"/>.</param>
        IEntitiesConfigurationBuilderMappingGrouping<TDatabase> Use(Func<IServiceProvider, Type, IDbEntity> factory);

        /// <summary>
        /// Use a custom factory to create an entity prior to mapping data retrieved from the target database.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IDbEntity"/>.</param>
        IEntitiesConfigurationBuilderMappingGrouping<TDatabase> Use(Func<IServiceProvider, Type, IDbEntity> factory, Action<IEntityFactoryContinuationConfigurationBuilder<TDatabase>> configureEntityTypes);

        /// <summary>
        /// Use a custom factory to create an entity prior to mapping data retrieved from the target database.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IDbEntity"/>.</param>
        IEntitiesConfigurationBuilderMappingGrouping<TDatabase> Use(Func<IServiceProvider, IEntityFactory> factory);

        /// <summary>
        /// Use a custom factory to create an entity prior to mapping data retrieved from the target database.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IDbEntity"/>.</param>
        IEntitiesConfigurationBuilderMappingGrouping<TDatabase> Use(Func<IServiceProvider, IEntityFactory> factory, Action<IEntityFactoryContinuationConfigurationBuilder<TDatabase>> configureEntityTypes);

        /// <summary>
        /// Provide overrides for specific entity types.
        /// </summary>
        /// <remarks>
        /// Typically used when the factory has already been specified, and overrides to that factory are needed.
        /// This simply registers each provided type with the service provider.
        /// <para>
        /// <strong>NOTE:</strong> Based on the type of <see cref="IEntityFactory{TDatabase}"/> used, this may or may not provide the desired
        /// results from the overrides - use when you are certain the registered <see cref="IEntityFactory{TDatabase}"/> uses the service
        /// provider to create new instances of entities.  The default <see cref="IEntityFactory{TDatabase}"/> honors the overrides provided.
        /// </para>
        /// </remarks>
        void ForEntityTypes(Action<IEntityFactoryContinuationConfigurationBuilder<TDatabase>> configureEntityTypes);

    }
}
