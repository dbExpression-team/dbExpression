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

using HatTrick.DbEx.Sql.Converter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace HatTrick.DbEx.Sql.Configuration
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
        public void Use(IValueConverterFactory<TDatabase> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton(factory);
        }

        /// <inheritdoc />
        public void Use<TValueConverterFactory>()
            where TValueConverterFactory : class, IValueConverterFactory<TDatabase>
        {
            services.TryAddSingleton<IValueConverterFactory<TDatabase>, TValueConverterFactory>();
        }

        /// <inheritdoc />
        public void Use(Func<Type, IValueConverter> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IValueConverterFactory<TDatabase>>(sp => new DelegateValueConverterFactory<TDatabase>(factory));
        }

        /// <inheritdoc />
        public void Use(Func<IServiceProvider, Type, IValueConverter> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IValueConverterFactory<TDatabase>>(sp => new DelegateValueConverterFactory<TDatabase>(t => factory(sp, t)));
        }

        /// <inheritdoc />
        public void Use(Func<IServiceProvider, Type, IValueConverter> factory, Action<IValueConverterFactoryContinuationConfigurationBuilder<TDatabase>> configureTypes)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            if (configureTypes is null)
                throw new ArgumentNullException(nameof(configureTypes));

            configureTypes.Invoke(new ValueConverterFactoryContinuationConfigurationBuilder<TDatabase>(services));
            services.TryAddSingleton<IValueConverterFactory<TDatabase>>(sp => new DelegateValueConverterFactory<TDatabase>(t => factory(sp, t)));
        }

        /// <inheritdoc />
        public void Use(Func<IValueConverterFactory<TDatabase>> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IValueConverterFactory<TDatabase>>(sp => factory());
        }

        /// <inheritdoc />
        public void Use(Func<IServiceProvider, IValueConverterFactory<TDatabase>> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IValueConverterFactory<TDatabase>>(factory);
        }

        /// <inheritdoc />
        public void Use(Func<IServiceProvider, IValueConverterFactory<TDatabase>> factory, Action<IValueConverterFactoryContinuationConfigurationBuilder<TDatabase>> configureTypes)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            if (configureTypes is null)
                throw new ArgumentNullException(nameof(configureTypes));

            configureTypes.Invoke(new ValueConverterFactoryContinuationConfigurationBuilder<TDatabase>(services));
            services.TryAddSingleton<IValueConverterFactory<TDatabase>>(factory);
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
 