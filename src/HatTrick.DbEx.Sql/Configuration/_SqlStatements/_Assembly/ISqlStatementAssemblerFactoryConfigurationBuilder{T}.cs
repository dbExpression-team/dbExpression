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

using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface ISqlStatementAssemblerFactoryConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Use the provided factory to for creating an assembler for assembling a sql statement.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating a <see cref="ISqlStatementAssembler"/>.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(ISqlStatementAssemblerFactory<TDatabase> factory);

        /// <summary>
        /// Use the service provider to provide a custom factory for creating an assembler for assembling a sql statement.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating a <see cref="ISqlStatementAssembler"/>.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, ISqlStatementAssemblerFactory<TDatabase>> factory);

        /// <summary>
        /// Use the service provider to provide a custom factory for creating an assembler for assembling a sql statement.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating a <see cref="ISqlStatementAssembler"/>.</param>
        /// <param name="configureQueryTypes">A delegate to specify assemblers for specific query types.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, ISqlStatementAssemblerFactory<TDatabase>> factory, Action<ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase>> configureQueryTypes);

        /// <summary>
        /// Use the specified factory to create an assembler for assembling a sql statement.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use<TSqlStatementAssemblerFactory>()
            where TSqlStatementAssemblerFactory : class, ISqlStatementAssemblerFactory<TDatabase>;

        /// <summary>
        /// Use the provided delegate to create an assembler for assembling a sql statement.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating a <see cref="ISqlStatementAssembler"/>.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<Type, ISqlStatementAssembler<TDatabase>> factory);

        /// <summary>
        /// Use the provided delegate to create an assembler for assembling a sql statement.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating a <see cref="ISqlStatementAssembler"/>.</param>
        /// <param name="configureQueryTypes">A delegate to specify assemblers for specific query types.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<Type, ISqlStatementAssembler<TDatabase>> factory, Action<ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase>> configureQueryTypes);

        /// <summary>
        /// Use the service provider to create an assembler for assembling a sql statement.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating a <see cref="ISqlStatementAssembler"/>.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, Type, ISqlStatementAssembler<TDatabase>> factory);

        /// <summary>
        /// Use the service provider to create an assembler for assembling a sql statement.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating a <see cref="ISqlStatementAssembler"/>.</param>
        /// <param name="configureQueryTypes">A delegate to specify assemblers for specific query types.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, Type, ISqlStatementAssembler<TDatabase>> factory, Action<ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase>> configureQueryTypes);

        /// <summary>
        /// Given an already registered service to provide sql statement assemblers, specify assemblers for specific query types the service should use.
        /// </summary>
        /// <param name="configureQueryTypes">A delegate to specify assemblers for specific query types.</param>
        /// <remarks>
        /// <para>
        /// <strong>NOTE:</strong> Based on the type of <see cref="ISqlStatementAssembler{TDatabase}"/> used, this may or may not provide the desired
        /// results from the overrides - use when you are certain the registered <see cref="ISqlStatementAssembler{TDatabase}"/> uses the service
        /// provider to create new instances of statement assemblers.  The default <see cref="ISqlStatementAssembler{TDatabase}"/> honors the overrides provided.
        /// </para>
        /// </remarks>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> ForQueryTypes(Action<ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase>> configureQueryTypes);
    }
}
