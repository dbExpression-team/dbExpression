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

﻿using DbExpression.Sql.Connection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Data;

namespace DbExpression.Sql.Configuration
{
    public class SqlConnectionFactoryConfigurationBuilder<TDatabase> : IDbConnectionFactoryConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> caller;
        private readonly IServiceCollection services;
        #endregion

        #region constructors
        public SqlConnectionFactoryConfigurationBuilder(ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> caller, IServiceCollection services)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }
        #endregion

        #region methods
        /// <inheritdoc />
        public ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> Use(IDbConnectionFactory factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IDbConnectionFactory>(factory);

            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, IDbConnectionFactory> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IDbConnectionFactory>(factory);

            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> Use<TSqlConnectionFactory>()
            where TSqlConnectionFactory : class, IDbConnectionFactory
        {
            services.TryAddSingleton<IDbConnectionFactory, TSqlConnectionFactory>();
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> Use(Func<IDbConnection> factory)
        {
            services.TryAddSingleton<IDbConnectionFactory>(new DelegateSqlConnectionFactory(factory));
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, IDbConnection> factory)
        {
            services.TryAddSingleton<IDbConnectionFactory>(sp => new DelegateSqlConnectionFactory(() => factory(sp)));
            return caller;
        }
        #endregion
    }
}
