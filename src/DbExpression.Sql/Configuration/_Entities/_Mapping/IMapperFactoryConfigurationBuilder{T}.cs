#region license
// Copyright (c) dbExpression.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion

using DbExpression.Sql.Mapper;
using System;

namespace DbExpression.Sql.Configuration
{
    public interface IMapperFactoryConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Use a custom factory to create a <see cref="IMapperFactory"/> used to map data retrieved from the target database.
        /// </summary>
        IEntitiesConfigurationBuilderCreationGrouping<TDatabase> Use(IMapperFactory factory);

        /// <summary>
        /// Use a custom <see cref="IMapperFactory"/> to map data retrieved from the target database.
        /// </summary>
        IEntitiesConfigurationBuilderCreationGrouping<TDatabase> Use<TMapperFactory>()
            where TMapperFactory : class, IMapperFactory;

        /// <summary>
        /// Use a custom <see cref="IMapperFactory"/>.
        /// </summary>
        IEntitiesConfigurationBuilderCreationGrouping<TDatabase> Use(Func<IMapperFactory> factory);

        /// <summary>
        /// Use a custom factory to create a <see cref="IEntityMapper"/> used to map data retrieved from the target database.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IEntityMapper"/>.</param>
        IEntitiesConfigurationBuilderCreationGrouping<TDatabase> Use(Func<Type, IEntityMapper> factory);

        /// <summary>
        /// Use the service provider to create a <see cref="IEntityMapper"/> used to map data retrieved from the target database.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IEntityMapper"/>.</param>
        IEntitiesConfigurationBuilderCreationGrouping<TDatabase> Use(Func<IServiceProvider, Type, IEntityMapper> factory);

        /// <summary>
        /// Use the service provider to resolve a <see cref="IMapperFactory"/>.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IMapperFactory"/>.</param>
        IEntitiesConfigurationBuilderCreationGrouping<TDatabase> Use(Func<IServiceProvider, IMapperFactory> factory);

        /// <summary>
        /// Override the default behaviour of mapping retrieved rowsets from the database for specific entity types. 
        /// </summary>
        /// <param name="configureEntityTypes">The delegate to configure mapping for specific entity types.</typeparam>
        IEntityMapperContinuationConfigurationBuilder<TDatabase> ForEntityTypes(Action<IEntityMapperContinuationConfigurationBuilder<TDatabase>> configureEntityTypes);
    }
}
