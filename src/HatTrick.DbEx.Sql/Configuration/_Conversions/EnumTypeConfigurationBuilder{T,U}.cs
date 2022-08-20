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
    public class EnumTypeValueConverterConfigurationBuilder<TDatabase, TEnum> : IEnumTypeValueConverterConfigurationBuilder<TDatabase, TEnum>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEnum : struct, Enum, IComparable
    {
        #region internals
        private readonly IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> caller;
        private readonly IServiceCollection services;
        #endregion

        #region constructors
        public EnumTypeValueConverterConfigurationBuilder(
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
        public IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> Use(IValueConverter<TEnum> converter)
        {
            if (converter is null)
                throw new ArgumentNullException(nameof(converter));

            services.TryAddSingleton<IValueConverter<TEnum>>(converter);
            services.TryAddSingleton<IValueConverter<TEnum?>>(new DelegateValueConverter<TEnum?>(@enum => converter.ConvertToDatabase(@enum)!, val => (TEnum)converter.ConvertFromDatabase(val)!));
            
            return caller;
        }

        /// <inheritdoc />
        public IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> Use<TConverter>()
            where TConverter : class, IValueConverter<TEnum>, new()
        {
            var c = new TConverter();
            
            services.TryAddSingleton<IValueConverter<TEnum>, TConverter>();
            services.TryAddSingleton<IValueConverter<TEnum?>>(new DelegateValueConverter<TEnum?>(@enum => @enum is null ? null : c.ConvertToDatabase(@enum), val => val is null ? null : c.ConvertFromDatabase(val)));
            
            return caller;
        }

        /// <inheritdoc />
        public IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<TEnum?, object?> convertToDatabase, Func<object?, TEnum?> convertFromDatabase)
        {
            if (convertToDatabase is null)
                throw new ArgumentNullException(nameof(convertToDatabase));

            if (convertFromDatabase is null)
                throw new ArgumentNullException(nameof(convertFromDatabase));

            services.TryAddSingleton<IValueConverter<TEnum>>(sp => new DelegateValueConverter<TEnum>(t => convertToDatabase(t), t => convertFromDatabase(t) ?? throw new DbExpressionException($"Conversion returned a <null> value for type {typeof(TEnum)}, expected a non-null value.")));
            services.TryAddSingleton<IValueConverter<TEnum?>>(sp => new DelegateValueConverter<TEnum?>(convertToDatabase, convertFromDatabase));

            return caller;
        }

        /// <inheritdoc />
        public IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<IServiceProvider, TEnum?, object?> convertToDatabase, Func<IServiceProvider, object?, TEnum?> convertFromDatabase)
        {
            if (convertToDatabase is null)
                throw new ArgumentNullException(nameof(convertToDatabase));

            if (convertFromDatabase is null)
                throw new ArgumentNullException(nameof(convertFromDatabase));

            services.TryAddSingleton<IValueConverter<TEnum>>(sp => new DelegateValueConverter<TEnum>(t => convertToDatabase(sp, t), t => convertFromDatabase(sp, t) ?? throw new DbExpressionException($"Conversion returned a <null> value for type {typeof(TEnum)}, expected a non-null value.")));
            services.TryAddSingleton<IValueConverter<TEnum?>>(sp => new DelegateValueConverter<TEnum?>(t => convertToDatabase(sp, t), t => convertFromDatabase(sp, t)));

            return caller;
        }

        /// <inheritdoc />
        public IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> PersistAsString()
        {
            services.TryAddSingleton<IValueConverter<TEnum>>(new StringEnumValueConverter<TEnum>());
            services.TryAddSingleton<IValueConverter<TEnum?>>(new StringNullableEnumValueConverter<TEnum>());

            return caller;
        }
        #endregion
    }
}
