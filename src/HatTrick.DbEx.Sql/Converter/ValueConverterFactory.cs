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
        
        private static readonly IValueConverter stringConverter = new NullableValueConverter(typeof(string));
        private static readonly IValueConverter byteArrayConverter = new NullableValueConverter(typeof(byte[]));

        private static readonly IValueConverter objectConverter = new ObjectConverter();

        private readonly ConcurrentDictionary<Type, Func<IValueConverter>> _valueConverters = new ConcurrentDictionary<Type, Func<IValueConverter>>();
        #endregion

        #region methods
        public void RegisterDefaultConverters()
        {
            _valueConverters.TryAdd(typeof(bool), () => boolConverter);
            _valueConverters.TryAdd(typeof(bool?), () => nullableBoolConverter);
            _valueConverters.TryAdd(typeof(byte), () => byteConverter);
            _valueConverters.TryAdd(typeof(byte?), () => nullableByteConverter);
            _valueConverters.TryAdd(typeof(short), () => shortConverter);
            _valueConverters.TryAdd(typeof(short?), () => nullableShortConverter);
            _valueConverters.TryAdd(typeof(int), () => intConverter);
            _valueConverters.TryAdd(typeof(int?), () => nullableIntConverter);
            _valueConverters.TryAdd(typeof(long), () => longConverter);
            _valueConverters.TryAdd(typeof(long?), () => nullableLongConverter);
            _valueConverters.TryAdd(typeof(double), () => doubleConverter);
            _valueConverters.TryAdd(typeof(double?), () => nullableDoubleConverter);
            _valueConverters.TryAdd(typeof(decimal), () => decimalConverter);
            _valueConverters.TryAdd(typeof(decimal?), () => nullableDecimalConverter);
            _valueConverters.TryAdd(typeof(float), () => floatConverter);
            _valueConverters.TryAdd(typeof(float?), () => nullableFloatConverter);
            _valueConverters.TryAdd(typeof(DateTime), () => dateTimeConverter);
            _valueConverters.TryAdd(typeof(DateTime?), () => nullableDateTimeConverter);
            _valueConverters.TryAdd(typeof(DateTimeOffset), () => dateTimeOffsetConverter);
            _valueConverters.TryAdd(typeof(DateTimeOffset?), () => nullableDateTimeOffsetConverter);
            _valueConverters.TryAdd(typeof(Guid), () => guidConverter);
            _valueConverters.TryAdd(typeof(Guid?), () => nullableGuidConverter);
            _valueConverters.TryAdd(typeof(string), () => stringConverter);
            _valueConverters.TryAdd(typeof(byte[]), () => byteArrayConverter);
            _valueConverters.TryAdd(typeof(object), () => objectConverter);
            _valueConverters.TryAdd(typeof(TimeSpan), () => timeSpanConverter);
            _valueConverters.TryAdd(typeof(TimeSpan?), () => nullableTimeSpanConverter);
        }

        public void RegisterConverter<T>(IValueConverter converter)
        {
            if (converter is null)
                throw new ArgumentNullException($"{nameof(converter)} is required.");

            RegisterConverter<T>(() => converter);
        }

        public void RegisterConverter<T, U>()
            where U : class, IValueConverter, new()
            => RegisterConverter<T>(new U());

        public void RegisterConverter<T>(Func<IValueConverter> converter)
        {
            if (converter is null)
                throw new ArgumentNullException($"{nameof(converter)} is required.");

            _valueConverters.AddOrUpdate(typeof(T), converter, (type, @return) => converter);
        }

        public IValueConverter CreateConverter(Type type)
        {
            if (_valueConverters.TryGetValue(type, out Func<IValueConverter> converter))
                return converter();

            if (TryCreateEnumValueConverter(type, out IValueConverter enumConverter))
            {
                _valueConverters.TryAdd(type, () => enumConverter);
                return enumConverter;
            }

            throw new DbExpressionConfigurationException($"Could not resolve a converter for type '{type}', please ensure a converter has been registered.");
        }

        public IValueConverter CreateConverter<T>()
            => CreateConverter(typeof(T));

        private bool TryCreateEnumValueConverter(Type enumType, out IValueConverter converter)
        {
            converter = null;
            try
            {
                converter = CreateEnumValueConverter(enumType);
                return converter is object;
            }
            catch
            {
                return false;
            }
        }

        private EnumValueConverter CreateEnumValueConverter(Type enumType)
            => CreateEnumValueConverter(enumType, enumType, false);

        private EnumValueConverter CreateEnumValueConverter(Type enumType, Type rootType, bool isNullable)
        {
            if (enumType.IsEnum)
            {
                if (isNullable)
                {
                    return new NullableEnumValueConverter(rootType);
                }
                return new EnumValueConverter(rootType);
            }
            enumType = Nullable.GetUnderlyingType(enumType);
            return enumType is null ? null : CreateEnumValueConverter(enumType, rootType, true);
        }
        #endregion
    }
}
