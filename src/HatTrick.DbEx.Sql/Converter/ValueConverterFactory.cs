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

using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Concurrent;

namespace HatTrick.DbEx.Sql.Converter
{
    public partial class ValueConverterFactory : IValueConverterFactory
    {
        #region internals
        private static readonly IValueConverter boolConverter = new ValueConverter(typeof(bool));
        private static readonly IValueConverter byteConverter = new ValueConverter(typeof(byte));
        private static readonly IValueConverter dateTimeConverter = new ValueConverter(typeof(DateTime));
        private static readonly IValueConverter dateTimeOffsetConverter = new ValueConverter(typeof(DateTimeOffset));
        private static readonly IValueConverter decimalConverter = new ValueConverter(typeof(decimal));
        private static readonly IValueConverter doubleConverter = new ValueConverter(typeof(double));
        private static readonly IValueConverter floatConverter = new ValueConverter(typeof(float));
        private static readonly IValueConverter guidConverter = new ValueConverter(typeof(Guid));
        private static readonly IValueConverter intConverter = new ValueConverter(typeof(int));
        private static readonly IValueConverter longConverter = new ValueConverter(typeof(long));
        private static readonly IValueConverter shortConverter = new ValueConverter(typeof(short));
        private static readonly IValueConverter timeSpanConverter = new ValueConverter(typeof(TimeSpan));

        private static readonly IValueConverter nullableBoolConverter = new NullableValueConverter(typeof(bool?));
        private static readonly IValueConverter nullableByteConverter = new NullableValueConverter(typeof(byte?));
        private static readonly IValueConverter nullableDateTimeConverter = new NullableValueConverter(typeof(DateTime?));
        private static readonly IValueConverter nullableDateTimeOffsetConverter = new NullableValueConverter(typeof(DateTimeOffset?));
        private static readonly IValueConverter nullableDecimalConverter = new NullableValueConverter(typeof(decimal?));
        private static readonly IValueConverter nullableDoubleConverter = new NullableValueConverter(typeof(double?));
        private static readonly IValueConverter nullableFloatConverter = new NullableValueConverter(typeof(float?));
        private static readonly IValueConverter nullableGuidConverter = new NullableValueConverter(typeof(Guid?));
        private static readonly IValueConverter nullableIntConverter = new NullableValueConverter(typeof(int?));
        private static readonly IValueConverter nullableLongConverter = new NullableValueConverter(typeof(long?));
        private static readonly IValueConverter nullableShortConverter = new NullableValueConverter(typeof(short?));
        private static readonly IValueConverter nullableTimeSpanConverter = new NullableValueConverter(typeof(TimeSpan?));
        
        private static readonly IValueConverter stringConverter = new StringValueConverter();
        private static readonly IValueConverter byteArrayConverter = new NullableValueConverter(typeof(byte[]));

        private static readonly IValueConverter objectConverter = new ObjectConverter();

        private readonly ConcurrentDictionary<Type, Func<IValueConverter>> valueConverters = new();
        #endregion

        #region methods
        public ValueConverterFactory()
        {
            RegisterConverter<bool>(boolConverter);
            RegisterConverter<bool?>(nullableBoolConverter);
            RegisterConverter<byte>(byteConverter);
            RegisterConverter<byte?>(nullableByteConverter);
            RegisterConverter<short>(shortConverter);
            RegisterConverter<short?>(nullableShortConverter);
            RegisterConverter<int>(intConverter);
            RegisterConverter<int?>(nullableIntConverter);
            RegisterConverter<long>(longConverter);
            RegisterConverter<long?>(nullableLongConverter);
            RegisterConverter<double>(doubleConverter);
            RegisterConverter<double?>(nullableDoubleConverter);
            RegisterConverter<decimal>(decimalConverter);
            RegisterConverter<decimal?>(nullableDecimalConverter);
            RegisterConverter<float>(floatConverter);
            RegisterConverter<float?>(nullableFloatConverter);
            RegisterConverter<DateTime>(dateTimeConverter);
            RegisterConverter<DateTime?>(nullableDateTimeConverter);
            RegisterConverter<DateTimeOffset>(dateTimeOffsetConverter);
            RegisterConverter<DateTimeOffset?>(nullableDateTimeOffsetConverter);
            RegisterConverter<Guid>(guidConverter);
            RegisterConverter<Guid?>(nullableGuidConverter);
            RegisterConverter<string>(stringConverter);
            RegisterConverter<byte[]>(byteArrayConverter);
            RegisterConverter<object>(objectConverter);
            RegisterConverter<TimeSpan>(timeSpanConverter);
            RegisterConverter<TimeSpan?>(nullableTimeSpanConverter);
        }

        public virtual void RegisterConverter<T>(IValueConverter converter)
        {
            if (converter is null)
                throw new ArgumentNullException(nameof(converter));

            RegisterConverter<T>(() => converter);
        }

        public virtual void RegisterConverter(Type type, IValueConverter converter)
        {
            if (converter is null)
                throw new ArgumentNullException(nameof(converter));

            RegisterConverter(type, () => converter);
        }

        public virtual void RegisterConverter<T, U>()
            where U : class, IValueConverter, new()
            => RegisterConverter<T>(new U());

        public virtual void RegisterConverter<T>(Func<IValueConverter> converter)
            =>  RegisterConverter(typeof(T), converter);

        public virtual void RegisterConverter(Type type, Func<IValueConverter> converter)
        {
            if (converter is null)
                throw new ArgumentNullException(nameof(converter));

            valueConverters.AddOrUpdate(type, converter, (_, @return) => converter);
        }

        public virtual IValueConverter CreateConverter(Type type)
        {
            if (valueConverters.TryGetValue(type, out Func<IValueConverter>? converter))
                return converter();

            if (TryCreateEnumValueConverter(type, out IValueConverter? enumConverter))
            {
                valueConverters.TryAdd(type, () => enumConverter!);
                return enumConverter!;
            }

            throw new DbExpressionConfigurationException($"Could not resolve a converter for type '{type}', please ensure a converter has been registered.");
        }

        public virtual IValueConverter CreateConverter<T>()
            => CreateConverter(typeof(T));

        protected virtual bool TryCreateEnumValueConverter(Type enumType, out IValueConverter? converter)
        {
            converter = default;
            try
            {
                converter = CreateEnumValueConverter(enumType);
                return converter is not null;
            }
            catch
            {
                return false;
            }
        }

        protected virtual IValueConverter? CreateEnumValueConverter(Type enumType)
            => CreateEnumValueConverter(enumType, enumType, false);

        protected virtual IValueConverter? CreateEnumValueConverter(Type enumType, Type rootType, bool isNullable)
        {
            if (enumType.IsEnum)
                return isNullable ? new NullableEnumValueConverter(enumType) : new EnumValueConverter(rootType);

            var underlying = Nullable.GetUnderlyingType(enumType);
            return underlying is null ? null : CreateEnumValueConverter(underlying, rootType, true);
        }
        #endregion
    }
}
