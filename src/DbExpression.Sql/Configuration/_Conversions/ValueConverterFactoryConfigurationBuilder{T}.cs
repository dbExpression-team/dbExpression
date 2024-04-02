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

using DbExpression.Sql.Converter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace DbExpression.Sql.Configuration
{
    public class ValueConverterFactoryConfigurationBuilder<TDatabase> : IValueConverterFactoryConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly IServiceCollection services;

        #endregion

        #region constructors
        public ValueConverterFactoryConfigurationBuilder(IServiceCollection services)
        {
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }
        #endregion

        #region methods
        /// <inheritdoc />
        public void Use(IValueConverterFactory factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton(factory);
        }

        /// <inheritdoc />
        public void Use<TValueConverterFactory>()
            where TValueConverterFactory : class, IValueConverterFactory
        {
            services.TryAddSingleton<IValueConverterFactory, TValueConverterFactory>();
        }

        /// <inheritdoc />
        public void Use(Func<Type, IValueConverter> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IValueConverterFactory>(sp => new DelegateValueConverterFactory(factory));
        }

        /// <inheritdoc />
        public void Use(Func<IServiceProvider, Type, IValueConverter> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IValueConverterFactory>(sp => new DelegateValueConverterFactory(t => factory(sp, t)));
        }

        /// <inheritdoc />
        public void Use(Func<IServiceProvider, Type, IValueConverter> factory, Action<IValueConverterFactoryContinuationConfigurationBuilder<TDatabase>> configureTypes)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            if (configureTypes is null)
                throw new ArgumentNullException(nameof(configureTypes));

            configureTypes.Invoke(new ValueConverterFactoryContinuationConfigurationBuilder<TDatabase>(services));
            services.TryAddSingleton<IValueConverterFactory>(sp => new DelegateValueConverterFactory(t => factory(sp, t)));
        }

        /// <inheritdoc />
        public void Use(Func<IValueConverterFactory> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IValueConverterFactory>(sp => factory());
        }

        /// <inheritdoc />
        public void Use(Func<IServiceProvider, IValueConverterFactory> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IValueConverterFactory>(factory);
        }

        /// <inheritdoc />
        public void Use(Func<IServiceProvider, IValueConverterFactory> factory, Action<IValueConverterFactoryContinuationConfigurationBuilder<TDatabase>> configureTypes)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            if (configureTypes is null)
                throw new ArgumentNullException(nameof(configureTypes));

            configureTypes.Invoke(new ValueConverterFactoryContinuationConfigurationBuilder<TDatabase>(services));
            services.TryAddSingleton<IValueConverterFactory>(factory);
        }

        /// <inheritdoc />
        public void ForTypes(Action<IValueConverterFactoryContinuationConfigurationBuilder<TDatabase>> configureTypes)
        {
            if (configureTypes is null)
                throw new ArgumentNullException(nameof(configureTypes));

            configureTypes.Invoke(new ValueConverterFactoryContinuationConfigurationBuilder<TDatabase>(services));
        }
        #endregion
    }
}
 