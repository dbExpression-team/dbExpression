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
using HatTrick.DbEx.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class SqlStatementAssemblerFactoryConfigurationBuilder<TDatabase> : 
        ISqlStatementAssemblerFactoryConfigurationBuilder<TDatabase>,
        ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> caller;
        private readonly IServiceCollection services;
        #endregion

        #region constructors
        public SqlStatementAssemblerFactoryConfigurationBuilder(ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> caller, IServiceCollection services)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }
        #endregion

        #region methods
        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(ISqlStatementAssemblerFactory<TDatabase> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton(factory);
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use<TSqlStatementAssemblerFactory>()
            where TSqlStatementAssemblerFactory : class, ISqlStatementAssemblerFactory<TDatabase>
        {
            services.TryAddSingleton<ISqlStatementAssemblerFactory<TDatabase>, TSqlStatementAssemblerFactory>();
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<Type, ISqlStatementAssembler<TDatabase>> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<ISqlStatementAssemblerFactory<TDatabase>>(sp => new DelegateSqlStatementAssemblerFactory<TDatabase>(factory));
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<Type, ISqlStatementAssembler<TDatabase>> factory, Action<ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase>> configureQueryTypes)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            if (configureQueryTypes is null)
                throw new ArgumentNullException(nameof(configureQueryTypes));

            services.TryAddSingleton<ISqlStatementAssemblerFactory<TDatabase>>(sp => new SqlStatementAssemblerFactoryWithDiscovery<TDatabase>(factory));
            configureQueryTypes.Invoke(new SqlStatementAssemblerFactoryConfigurationBuilder<TDatabase>(caller, services));
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, Type, ISqlStatementAssembler<TDatabase>> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<ISqlStatementAssemblerFactory<TDatabase>>(sp => new DelegateSqlStatementAssemblerFactory<TDatabase>(t => factory(sp, t)));
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, Type, ISqlStatementAssembler<TDatabase>> factory, Action<ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase>> configureQueryTypes)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            if (configureQueryTypes is null)
                throw new ArgumentNullException(nameof(configureQueryTypes));

            services.TryAddSingleton<ISqlStatementAssemblerFactory<TDatabase>>(sp => new SqlStatementAssemblerFactoryWithDiscovery<TDatabase>(t => factory(sp, t)));
            configureQueryTypes.Invoke(new SqlStatementAssemblerFactoryConfigurationBuilder<TDatabase>(caller, services));
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> ForQueryTypes(Action<ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase>> configureQueryTypes)
        {
            if (configureQueryTypes is null)
                throw new ArgumentNullException(nameof(configureQueryTypes));

            configureQueryTypes.Invoke(new SqlStatementAssemblerFactoryConfigurationBuilder<TDatabase>(caller, services));
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, ISqlStatementAssemblerFactory<TDatabase>> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<ISqlStatementAssemblerFactory<TDatabase>>(factory);
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, ISqlStatementAssemblerFactory<TDatabase>> factory, Action<ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase>> configureQueryTypes)
        {

            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            if (configureQueryTypes is null)
                throw new ArgumentNullException(nameof(configureQueryTypes));

            services.TryAddSingleton<ISqlStatementAssemblerFactory<TDatabase>>(factory);
            configureQueryTypes.Invoke(new SqlStatementAssemblerFactoryConfigurationBuilder<TDatabase>(caller, services));
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase, TQuery> ForQueryType<TQuery>()
            where TQuery : QueryExpression
        {
            return new SqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase, TQuery>(this, services);
        }

        /// <inheritdoc />
        public ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase, SelectQueryExpression> ForSelect()
        {
            return new SqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase, SelectQueryExpression>(this, services);
        }

        /// <inheritdoc />
        public ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase, InsertQueryExpression> ForInsert()
        {
            return new SqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase, InsertQueryExpression>(this, services);
        }

        /// <inheritdoc />
        public ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase, UpdateQueryExpression> ForUpdate()
        {
            return new SqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase, UpdateQueryExpression>(this, services);
        }

        /// <inheritdoc />
        public ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase, DeleteQueryExpression> ForDelete()
        {
            return new SqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase, DeleteQueryExpression>(this, services);
        }
        #endregion
    }
}
