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
    public class ValueConverterFactoryConfigurationBuilder : IValueConverterFactoryConfigurationBuilder
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        #endregion

        #region constructors
        public ValueConverterFactoryConfigurationBuilder(RuntimeSqlDatabaseConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        #endregion

        #region methods
        public void Use(IValueConverterFactory factory)
            => configuration.ValueConverterFactory = factory;

        public void Use<TValueConverterFactory>()
            where TValueConverterFactory : class, IValueConverterFactory, new()
            => Use<TValueConverterFactory>(null);

        public void Use<TValueConverterFactory>(Action<TValueConverterFactory> configureFactory)
            where TValueConverterFactory : class, IValueConverterFactory, new()
        {
            if (!(configuration.ValueConverterFactory is TValueConverterFactory))
                configuration.ValueConverterFactory = new TValueConverterFactory();
            configureFactory?.Invoke(configuration.ValueConverterFactory as TValueConverterFactory);
        }

        public void Use(Func<Type, IValueConverter> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));
            configuration.ValueConverterFactory = new DelegateValueConverterFactory(factory);
        }

        public void UseDefaultFactory()
            => UseDefaultFactory(null);

        public void UseDefaultFactory(Action<IValueConverterFactoryContinuationConfigurationBuilder> configureFactory)
        {
            if (!(configuration.ValueConverterFactory is ValueConverterFactory))
                configuration.ValueConverterFactory = new ValueConverterFactory();
            configureFactory?.Invoke(new ValueConverterFactoryContinuationConfigurationBuilder(configuration.ValueConverterFactory as ValueConverterFactory));
        }
        #endregion
    }
}
