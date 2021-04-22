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
    public class ValueConverterFactoryContinuationConfigurationBuilder : IValueConverterFactoryContinuationConfigurationBuilder
    {
        #region internals
        private readonly ValueConverterFactory factory;
        #endregion

        #region constructors
        public ValueConverterFactoryContinuationConfigurationBuilder(ValueConverterFactory factory)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        #endregion

        #region methods
        public IValueConverterFactoryContinuationConfigurationBuilder OverrideForType<T>(IValueConverter converter)
            where T : IComparable
        {
            factory.RegisterConverter<T>(converter);
            return this;
        }

        public IValueConverterFactoryContinuationConfigurationBuilder OverrideForType<T, TConverter>()
            where T : IComparable
            where TConverter : class, IValueConverter, new()
        {
            factory.RegisterConverter<T,TConverter>();
            return this;
        }

        public IEnumTypeValueConverterConfigurationBuilder<TEnum> OverrideForEnumType<TEnum>()
            where TEnum : struct, Enum, IComparable
        {
            return new EnumTypeValueConverterConfigurationBuilder<TEnum>(this, factory);
        }

        public IValueConverterFactoryContinuationConfigurationBuilder OverrideForEnumType<TEnum>(IValueConverter converter)
            where TEnum : struct, Enum, IComparable
        {
            factory.RegisterConverter<TEnum>(converter);
            return this;
        }

        public IValueConverterFactoryContinuationConfigurationBuilder OverrideForEnumType<TEnum, TConverter>()
            where TEnum : struct, Enum, IComparable
            where TConverter : class, IValueConverter, new()
        {
            factory.RegisterConverter<TEnum, TConverter>();
            return this;
        }
        #endregion
    }
}
