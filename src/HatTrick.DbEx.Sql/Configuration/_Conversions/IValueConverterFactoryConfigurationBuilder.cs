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

﻿using HatTrick.DbEx.Sql.Converter;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IValueConverterFactoryConfigurationBuilder
    {
        /// <summary>
        /// Use a custom factory to create a value converter used to convert data to and from the target database.
        /// </summary>
        void Use(IValueConverterFactory factory);

        /// <summary>
        /// Use a custom factory to create a value converter used to convert data to and from the target database.
        /// </summary>
        void Use<TValueConverterFactory>()
            where TValueConverterFactory : class, IValueConverterFactory, new();

        /// <summary>
        /// Use a custom factory to create a value converter used to convert data to and from the target database.
        /// </summary>
        /// <param name="configureFactory">A delegate for configuring the <typeparamref name="TValueConverterFactory"/>.</param>
        void Use<TValueConverterFactory>(Action<TValueConverterFactory> configureFactory)
            where TValueConverterFactory : class, IValueConverterFactory, new();

        /// <summary>
        /// Use a custom factory to create a value converter used to convert data to and from the target database.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IValueConverter"/> for the provided value type.</param>
        void Use(Func<Type, IValueConverter> factory);

        /// <summary>
        /// Use the default factory to create a value converter used to convert data to and from the target database.
        /// </summary>
        void UseDefaultFactory();

        /// <summary>
        /// Use the default factory to create a value converter used to convert data to and from the target database.
        /// </summary>
        /// <param name="configureFactory">Configure custom converters for specific data types.</param>
        void UseDefaultFactory(Action<IValueConverterFactoryContinuationConfigurationBuilder> configureFactory);
    }
}
