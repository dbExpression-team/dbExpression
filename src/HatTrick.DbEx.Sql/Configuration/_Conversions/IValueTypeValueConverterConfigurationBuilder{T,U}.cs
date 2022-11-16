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
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IValueTypeValueConverterConfigurationBuilder<TDatabase, T>
        where TDatabase : class, ISqlDatabaseRuntime
   {
        /// <summary>
        /// Override the default behaviour of converting a <typeparamref name="T"/> to and from a different value type using the specified value converter. 
        /// </summary>
        /// <param name="converter">The custom converter that will convert data to and from the database.</param>
        IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> Use(IValueConverter<T> converter);

        /// <summary>
        /// Override the default behaviour of converting a <typeparamref name="T"/> to and from a different value type using the specified value converter. 
        /// </summary>
        /// <param name="factory">The custom converter that will convert data to and from the database.</param>
        IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<IValueConverter<T>> factory);

        /// <summary>
        /// Override the default behaviour of converting a <typeparamref name="T"/> to and from a different value type using the specified value converter. 
        /// </summary>
        /// <param name="factory">The custom converter that will convert data to and from the database.</param>
        IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<IServiceProvider, IValueConverter<T>> factory);

        /// <summary>
        /// Override the default behaviour of converting a <typeparamref name="T"/> to and from a different value type using the specified value converter. 
        /// </summary>
        /// <typeparam name="TConverter">The custom converter that will convert <typeparamref name="T"/>(s).</param>
        IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> Use<TConverter>()
            where TConverter : class, IValueConverter<T>, new();

        /// <summary>
        /// Override the default behaviour of converting a <typeparamref name="T"/> to and from a different value type using the specified value converter. 
        /// </summary>
        /// <param name="convertToDatabase">A custom delegate that will convert a <typeparamref name="T"/> into an <see cref="object"/> for persistence in the database.</param>
        /// <param name="convertFromDatabase">A custom delegate that will convert an <see cref="object"/> read from the database into the type <typeparamref name="T"/>.</param>
        IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<T?, object?> convertToDatabase, Func<object?, T?> convertFromDatabase);

        /// <summary>
        /// Override the default behaviour of converting a <typeparamref name="T"/> to and from a different value type using the specified value converter. 
        /// </summary>
        /// <param name="convertToDatabase">A custom delegate that will convert a <typeparamref name="T"/> into an <see cref="object"/> for persistence in the database.</param>
        /// <param name="convertFromDatabase">A custom delegate that will convert an <see cref="object"/> read from the database into the type <typeparamref name="T"/>.</param>
        IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<IServiceProvider, T?, object?> convertToDatabase, Func<IServiceProvider, object?, T?> convertFromDatabase);
    }
}
