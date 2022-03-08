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
    public class EnumTypeValueConverterConfigurationBuilder<TEnum> : IEnumTypeValueConverterConfigurationBuilder<TEnum>
        where TEnum : struct, Enum, IComparable
    {
        #region internals
        private readonly IValueConverterFactoryContinuationConfigurationBuilder caller;
        private readonly ValueConverterFactory factory;
        #endregion

        #region constructors
        public EnumTypeValueConverterConfigurationBuilder(IValueConverterFactoryContinuationConfigurationBuilder caller, ValueConverterFactory factory)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        #endregion

        #region methods
        public IValueConverterFactoryContinuationConfigurationBuilder Use(IValueConverter converter)
        {
            factory.RegisterConverter<TEnum>(converter);
            return caller;
        }

        public IValueConverterFactoryContinuationConfigurationBuilder Use<TConverter>()
            where TConverter : class, IValueConverter, new()
        {
            factory.RegisterConverter<TEnum, TConverter>();
            return caller;
        }

        public IValueConverterFactoryContinuationConfigurationBuilder Use(Func<TEnum?, object?> convertToDatabase, Func<object?, TEnum?> convertFromDatabase)
        {
            var converter = new DelegateValueConverter<TEnum?>(convertToDatabase, convertFromDatabase);
            factory.RegisterConverter<TEnum>(converter);
            factory.RegisterConverter<TEnum?>(converter);
            return caller;
        }

        public IValueConverterFactoryContinuationConfigurationBuilder PersistAsString()
        {
            //ensure to register both the enum type and the nullable version of the enum type
            var enumType = typeof(TEnum);
            if (enumType.IsNullableType() && enumType.GetGenericArguments()[0].IsEnum)
            {
                var converter = new StringNullableEnumValueConverter<TEnum>();
                factory.RegisterConverter(enumType, converter);
                factory.RegisterConverter(enumType.GetGenericArguments()[0], converter);
            }
            else if (enumType.IsEnum)
            {
                var nullableEnumType = typeof(Nullable<>).MakeGenericType(enumType);
                var converter = new StringNullableEnumValueConverter(enumType);
                factory.RegisterConverter(enumType, converter);
                factory.RegisterConverter(nullableEnumType, converter);
            }
            return caller;
        }
        #endregion
    }
}
