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
using System;

namespace DbExpression.Sql.Configuration
{
    public interface IValueConverterFactoryConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Use a custom factory to create a value converter used to convert data to and from the target database.
        /// </summary>
        /// </remarks>
        void Use(IValueConverterFactory converter);

        /// <summary>
        /// Use a custom factory to create a value converter used to convert data to and from the target database.
        /// </summary>
        /// </remarks>
        void Use<TValueConverterFactory>()
            where TValueConverterFactory : class, IValueConverterFactory;

        /// <summary>
        /// Use the provided delegate to create a value converter used to convert data to and from the target database.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IValueConverter"/> for the provided type.</param>
        void Use(Func<Type, IValueConverter> factory);

        /// <summary>
        /// Use the service provider to create a value converter used to convert data to and from the target database.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IValueConverter"/> for the provided type.</param>
        void Use(Func<IServiceProvider, Type, IValueConverter> factory);

        /// <summary>
        /// Use the service provider to create a value converter used to convert data to and from the target database.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IValueConverter"/> for the provided type.</param>
        /// <param name="configureTypes">A delegate allowing configuration of specific value, enum or reference type.</param>
        void Use(Func<IServiceProvider, Type, IValueConverter> factory, Action<IValueConverterFactoryContinuationConfigurationBuilder<TDatabase>> configureTypes);

        /// <summary>
        /// Use the provided delegate to create a value converter used to convert data to and from the target database.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IValueConverter"/> for the provided type.</param>
        void Use(Func<IValueConverterFactory> factory);

        /// <summary>
        /// Use the service provider to create a value converter used to convert data to and from the target database.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IValueConverter"/> for the provided type.</param>
        /// <param name="configureTypes">A delegate allowing configuration of specific value, enum or reference type.</param>
        void Use(Func<IServiceProvider, IValueConverterFactory> factory);

        /// <summary>
        /// Use the service provider to create a value converter used to convert data to and from the target database.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IValueConverter"/> for the provided type.</param>
        /// <param name="configureTypes">A delegate allowing configuration of specific value, enum or reference type.</param>
        void Use(Func<IServiceProvider, IValueConverterFactory> factory, Action<IValueConverterFactoryContinuationConfigurationBuilder<TDatabase>> configureTypes);

        /// <summary>
        /// Provide overrides for specific enum, value, and reference types.
        /// </summary>
        /// <remarks>
        /// Typically used when the factory has already been specified, and overrides to that factory are needed.
        /// This simply registers each provided type with the service provider.
        /// <para>
        /// <strong>NOTE:</strong> Based on the type of <see cref="IValueConverterFactory{TDatabase}"/> used, this may or may not provide the desired
        /// results from the overrides - use when you are certain the registered <see cref="IValueConverterFactory{TDatabase}"/> uses the service
        /// provider to create new instances of entities.  The default <see cref="IValueConverterFactory{TDatabase}"/> honors the overrides provided.
        /// </para>
        /// </remarks>
        void ForTypes(Action<IValueConverterFactoryContinuationConfigurationBuilder<TDatabase>> configureTypes);        
    }
}
