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
    public interface IEnumTypeValueConverterConfigurationBuilder<TDatabase, TEnum>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEnum : struct, Enum, IComparable
    {
        /// <summary>
        /// Override the default behaviour of converting <typeparamref name="TEnum"/> values to and from a different type using the provided value converter. 
        /// </summary>
        /// <param name="converter">The custom converter that will convert data to and from the database.</param>
        IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> Use(IValueConverter<TEnum> converter);

        /// <summary>
        /// Override the default behaviour of converting <typeparamref name="TEnum"/> values to and from a different type using the specified value converter. 
        /// </summary>
        /// <param name="factory">The custom converter that will convert data to and from the database.</param>
        IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<IValueConverter<TEnum>> factory);

        /// <summary>
        /// Override the default behaviour of converting <typeparamref name="TEnum"/> values to and from a different type using the specified value converter. 
        /// </summary>
        /// <param name="factory">The custom converter that will convert data to and from the database.</param>
        IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<IServiceProvider, IValueConverter<TEnum>> factory);

        /// <summary>
        /// Override the default behaviour of converting <typeparamref name="TEnum"/> values to and from a different type using the specified value converter. 
        /// </summary>
        /// <typeparam name="TConverter">The custom converter that will convert data to and from the database.</param>
        IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> Use<TConverter>()
            where TConverter : class, IValueConverter<TEnum>, new();

        /// <summary>
        /// Override the default behaviour of converting <typeparamref name="TEnum"/> values to and from a different type using provided delegates. 
        /// </summary>
        /// <param name="convertToDatabase">A custom delegate that will convert a <typeparamref name="TEnum"/>? into an <see cref="object"/> for persistence in the database.</param>
        /// <param name="convertFromDatabase">A custom delegate that will convert an <see cref="object"/> read from the database into the type <typeparamref name="TEnum"/>?.</param>
        IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<TEnum?, object?> convertToDatabase, Func<object?, TEnum?> convertFromDatabase);

        /// <summary>
        /// Override the default behaviour of converting <typeparamref name="TEnum"/> values to and from a different type using provided delegates. 
        /// </summary>
        /// <param name="convertToDatabase">A custom delegate that will convert a <typeparamref name="TEnum"/>? into an <see cref="object"/> for persistence in the database.</param>
        /// <param name="convertFromDatabase">A custom delegate that will convert an <see cref="object"/> read from the database into the type <typeparamref name="TEnum"/>?.</param>
        IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<IServiceProvider, TEnum?, object?> convertToDatabase, Func<IServiceProvider, object?, TEnum?> convertFromDatabase);

        /// <summary>
        /// Persist enumeration values as strings in the target database.
        /// </summary>
        /// <remarks>
        /// Using this method will register converters for both the nullable and non-nullable versions of the enum.
        /// </remarks>
        IValueConverterFactoryContinuationConfigurationBuilder<TDatabase> PersistAsString();
    }
}
