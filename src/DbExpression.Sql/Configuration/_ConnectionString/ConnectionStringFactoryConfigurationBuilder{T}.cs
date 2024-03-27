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

namespace DbExpression.Sql.Configuration
{
    public class ConnectionStringFactoryConfigurationBuilder<TDatabase> : IConnectionStringFactoryConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly IServiceCollection services;
        #endregion

        #region constructors
        public ConnectionStringFactoryConfigurationBuilder(IServiceCollection services)
        {
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }
        #endregion

        #region methods
        /// <inheritdoc />
        public void Use(string connectionString)
        {
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Connection string cannot be whitespace.");

            services.TryAddSingleton<IConnectionStringFactory>(new DelegateConnectionStringFactory(() => connectionString));
        }

        /// <inheritdoc />
        public void Use(Func<string> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IConnectionStringFactory>(new DelegateConnectionStringFactory(factory));
        }

        /// <inheritdoc />
        public void Use(Func<IServiceProvider, string> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IConnectionStringFactory>(sp => new DelegateConnectionStringFactory(() => factory(sp)));
        }

        /// <inheritdoc />
        public void Use(IConnectionStringFactory factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IConnectionStringFactory>(factory);
        }

        /// <inheritdoc />
        public void Use<TConnectionStringFactory>()
            where TConnectionStringFactory : class, IConnectionStringFactory
        {
            services.TryAddSingleton<IConnectionStringFactory, TConnectionStringFactory>();
        }

        /// <inheritdoc />
        public void Use(Func<IServiceProvider, IConnectionStringFactory> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IConnectionStringFactory>(factory);
        }
        #endregion
    }
}
