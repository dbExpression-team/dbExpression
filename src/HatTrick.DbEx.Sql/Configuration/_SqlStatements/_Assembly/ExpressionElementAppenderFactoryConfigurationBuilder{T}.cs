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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class ExpressionElementAppenderFactoryConfigurationBuilder<TDatabase> : IExpressionElementAppenderFactoryConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> caller;
        private readonly IServiceCollection services;
        #endregion

        #region constructors
        public ExpressionElementAppenderFactoryConfigurationBuilder(ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> caller, IServiceCollection services)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }
        #endregion

        #region methods
        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(IExpressionElementAppenderFactory<TDatabase> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton(factory);
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<IExpressionElementAppenderFactory<TDatabase>> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton(factory);
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use<TExpressionElementAppenderFactory>()
            where TExpressionElementAppenderFactory : class, IExpressionElementAppenderFactory<TDatabase>
        {
            services.TryAddSingleton<IExpressionElementAppenderFactory<TDatabase>, TExpressionElementAppenderFactory>();
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<Type, IExpressionElementAppender> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IExpressionElementAppenderFactory<TDatabase>>(sp => new DefaultExpressionElementAppenderFactoryWithDiscovery<TDatabase>(
                    sp.GetRequiredService<ILoggerFactory>().CreateLogger<DefaultExpressionElementAppenderFactoryWithDiscovery<TDatabase>>(),
                    factory
                )
            );
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, Type, IExpressionElementAppender> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IExpressionElementAppenderFactory<TDatabase>>(sp => new DefaultExpressionElementAppenderFactoryWithDiscovery<TDatabase>(
                    sp.GetRequiredService<ILoggerFactory>().CreateLogger<DefaultExpressionElementAppenderFactoryWithDiscovery<TDatabase>>(),
                    t => factory(sp, t)
                )
            );
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, Type, IExpressionElementAppender> factory, Action<IExpressionElementAppenderFactoryContinuationConfigurationBuilder<TDatabase>> configureElementTypes)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            if (configureElementTypes is null)
                throw new ArgumentNullException(nameof(configureElementTypes));

            services.TryAddSingleton<IExpressionElementAppenderFactory<TDatabase>>(sp => new DefaultExpressionElementAppenderFactoryWithDiscovery<TDatabase>(
                    sp.GetRequiredService<ILoggerFactory>().CreateLogger<DefaultExpressionElementAppenderFactoryWithDiscovery<TDatabase>>(),
                    t => factory(sp, t)
                )
            );
            configureElementTypes.Invoke(new ExpressionElementAppenderFactoryContinuationConfigurationBuilder<TDatabase>(services));
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> ForElementTypes(Action<IExpressionElementAppenderFactoryContinuationConfigurationBuilder<TDatabase>> configureElementTypes)
        {
            if (configureElementTypes is null)
                throw new ArgumentNullException(nameof(configureElementTypes));

            configureElementTypes.Invoke(new ExpressionElementAppenderFactoryContinuationConfigurationBuilder<TDatabase>(services));
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, IExpressionElementAppenderFactory<TDatabase>> factory, Action<IExpressionElementAppenderFactoryContinuationConfigurationBuilder<TDatabase>> configureElementTypes)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IExpressionElementAppenderFactory<TDatabase>>(sp => factory(sp));
            configureElementTypes.Invoke(new ExpressionElementAppenderFactoryContinuationConfigurationBuilder<TDatabase>(services));
            return caller;
        }

        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, IExpressionElementAppenderFactory<TDatabase>> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IExpressionElementAppenderFactory<TDatabase>>(sp => factory(sp));
            return caller;
        }
        #endregion
    }
}
