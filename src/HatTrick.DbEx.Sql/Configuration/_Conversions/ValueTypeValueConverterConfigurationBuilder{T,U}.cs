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
    public class ValueTypeValueConverterConfigurationBuilder<TDatabase, T> : IValueTypeValueConverterConfigurationBuilder<TDatabase, T>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> caller;
        private readonly IServiceCollection services;
        #endregion

        #region constructors
        public ValueTypeValueConverterConfigurationBuilder(
            IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> caller, 
            IServiceCollection services
        )
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }
        #endregion

        #region methods
        /// <inheritdoc />
        public IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> Use(IValueConverter<T> converter)
        {
            if (converter is null)
                throw new ArgumentNullException(nameof(converter));

            services.TryAddSingleton<IValueConverter<T>>(converter);

            return caller;
        }

        /// <inheritdoc />
        public IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<IServiceProvider, IValueConverter<T>> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            services.TryAddSingleton<IValueConverter<T>>(factory);

            return caller;
        }

        /// <inheritdoc />
        public IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> Use<TConverter>()
            where TConverter : class, IValueConverter<T>, new()
        {
            services.TryAddSingleton<IValueConverter<T>,TConverter>();
            
            return caller;
        }

        /// <inheritdoc />
        public IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<T?, object?> convertToDatabase, Func<object?, T?> convertFromDatabase)
        {
            if (convertToDatabase is null)
                throw new ArgumentNullException(nameof(convertToDatabase));

            if (convertFromDatabase is null)
                throw new ArgumentNullException(nameof(convertFromDatabase));

            services.TryAddSingleton<IValueConverter<T>>(sp => new DelegateValueConverter<T>(convertToDatabase, convertFromDatabase) ?? throw new DbExpressionException($"Conversion returned a <null> value for type {typeof(T)}, expected a non-null value."));
            services.TryAddSingleton<IValueConverter<T?>>(sp => new DelegateValueConverter<T?>(convertToDatabase, convertFromDatabase));

            return caller;
        }

        /// <inheritdoc />
        public IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<IServiceProvider, T?, object?> convertToDatabase, Func<IServiceProvider, object?, T?> convertFromDatabase)
        {
            if (convertToDatabase is null)
                throw new ArgumentNullException(nameof(convertToDatabase));

            if (convertFromDatabase is null)
                throw new ArgumentNullException(nameof(convertFromDatabase));

            services.TryAddSingleton<IValueConverter<T>>(sp => new DelegateValueConverter<T>(t => convertToDatabase(sp, t), t => convertFromDatabase(sp, t) ?? throw new DbExpressionException($"Conversion returned a <null> value for type {typeof(T)}, expected a non-null value.")));
            services.TryAddSingleton<IValueConverter<T?>>(sp => new DelegateValueConverter<T?>(t => convertToDatabase(sp, t), t => convertFromDatabase(sp, t)));

            return caller;
        }
        #endregion
    }
}
