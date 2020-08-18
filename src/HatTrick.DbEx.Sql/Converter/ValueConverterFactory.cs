using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Concurrent;

namespace HatTrick.DbEx.Sql.Converter
{
    public class ValueConverterFactory : IValueConverterFactory
    {
        #region internals
        private IValueConverter _valueConverter;

        private static readonly PrimitiveValueConverter<bool> _boolConverter = new PrimitiveValueConverter<bool>(Convert.ToBoolean, x => x);
        private static readonly PrimitiveValueConverter<bool?> _nullableBoolConverter = new PrimitiveValueConverter<bool?>((f) => f is null ? default(bool?) : Convert.ToBoolean(f), x => x);
        private static readonly PrimitiveValueConverter<short> _shortConverter = new PrimitiveValueConverter<short>(Convert.ToInt16, x => x);
        private static readonly PrimitiveValueConverter<short?> _nullableShortConverter = new PrimitiveValueConverter<short?>((f) => f is null ? default(short?) : Convert.ToInt16(f), x => x);
        private static readonly PrimitiveValueConverter<int> _intConverter = new PrimitiveValueConverter<int>(Convert.ToInt32, x => x);
        private static readonly PrimitiveValueConverter<int?> _nullableIntConverter = new PrimitiveValueConverter<int?>((f) => f is null ? default(int?) : Convert.ToInt32(f), x => x);
        private static readonly PrimitiveValueConverter<long> _longConverter = new PrimitiveValueConverter<long>(Convert.ToInt64, x => x);
        private static readonly PrimitiveValueConverter<long?> _nullableLongConverter = new PrimitiveValueConverter<long?>((f) => f is null ? default(long?) : Convert.ToInt64(f), x => x);
        private static readonly PrimitiveValueConverter<double> _doubleConverter = new PrimitiveValueConverter<double>(Convert.ToDouble, x => x);
        private static readonly PrimitiveValueConverter<double?> _nullableDoubleConverter = new PrimitiveValueConverter<double?>((f) => f is null ? default(double?) : Convert.ToDouble(f), x => x);
        private static readonly PrimitiveValueConverter<decimal> _decimalConverter = new PrimitiveValueConverter<decimal>(Convert.ToDecimal, x => x);
        private static readonly PrimitiveValueConverter<decimal?> _nullableDecimalConverter = new PrimitiveValueConverter<decimal?>((f) => f is null ? default(decimal?) : Convert.ToDecimal(f), x => x);
        private static readonly PrimitiveValueConverter<float> _floatConverter = new PrimitiveValueConverter<float>(Convert.ToSingle, x => x);
        private static readonly PrimitiveValueConverter<float?> _nullableFloatConverter = new PrimitiveValueConverter<float?>((f) => f is null ? default(float?) : Convert.ToSingle(f), x => x);
        private static readonly PrimitiveValueConverter<DateTime> _dateTimeConverter = new PrimitiveValueConverter<DateTime>(Convert.ToDateTime, x => x);
        private static readonly PrimitiveValueConverter<DateTime?> _nullableDateTimeConverter = new PrimitiveValueConverter<DateTime?>((f) => f is null ? default(DateTime?) : Convert.ToDateTime(f), x => x);
        private static readonly PrimitiveValueConverter<DateTimeOffset> _dateTimeOffsetConverter = new PrimitiveValueConverter<DateTimeOffset>((f) => new DateTimeOffset(Convert.ToDateTime(f)), x => x);
        private static readonly PrimitiveValueConverter<DateTimeOffset?> _nullableDateTimeOffsetConverter = new PrimitiveValueConverter<DateTimeOffset?>((f) => f is null ? default(DateTimeOffset?) : new DateTimeOffset(Convert.ToDateTime(f)), x => x);
        private static readonly PrimitiveValueConverter<Guid> _guidConverter = new PrimitiveValueConverter<Guid>((f) => (Guid)f, x => x);
        private static readonly PrimitiveValueConverter<Guid?> _nullableGuidConverter = new PrimitiveValueConverter<Guid?>((f) => (Guid?)f, x => x);
        private static readonly PrimitiveValueConverter<string> _stringConverter = new PrimitiveValueConverter<string>(Convert.ToString, x => x);
        private static readonly PrimitiveValueConverter<byte[]> _byteArrayConverter = new PrimitiveValueConverter<byte[]>((f) => f is null ? default : (byte[])f, x => x);
        private static readonly PrimitiveValueConverter<object> _objectConverter = new PrimitiveValueConverter<object>(o => o, x => x);

        private readonly ConcurrentDictionary<Type, Func<IConverter>> _valueConverters = new ConcurrentDictionary<Type, Func<IConverter>>();
        private readonly ConcurrentDictionary<FieldExpression, Func<IValueConverter>> _fieldConverters = new ConcurrentDictionary<FieldExpression, Func<IValueConverter>>();
        #endregion

        #region methods
        public void RegisterDefaultConverters()
        {
            _valueConverters.TryAdd(typeof(bool), () => _boolConverter);
            _valueConverters.TryAdd(typeof(bool?), () => _nullableBoolConverter);
            _valueConverters.TryAdd(typeof(short), () => _shortConverter);
            _valueConverters.TryAdd(typeof(short?), () => _nullableShortConverter);
            _valueConverters.TryAdd(typeof(int), () => _intConverter);
            _valueConverters.TryAdd(typeof(int?), () => _nullableIntConverter);
            _valueConverters.TryAdd(typeof(long), () => _longConverter);
            _valueConverters.TryAdd(typeof(long?), () => _nullableLongConverter);
            _valueConverters.TryAdd(typeof(double), () => _doubleConverter);
            _valueConverters.TryAdd(typeof(double?), () => _nullableDoubleConverter);
            _valueConverters.TryAdd(typeof(decimal), () => _decimalConverter);
            _valueConverters.TryAdd(typeof(decimal?), () => _nullableDecimalConverter);
            _valueConverters.TryAdd(typeof(float), () => _floatConverter);
            _valueConverters.TryAdd(typeof(float?), () => _nullableFloatConverter);
            _valueConverters.TryAdd(typeof(DateTime), () => _dateTimeConverter);
            _valueConverters.TryAdd(typeof(DateTime?), () => _nullableDateTimeConverter);
            _valueConverters.TryAdd(typeof(DateTimeOffset), () => _dateTimeOffsetConverter);
            _valueConverters.TryAdd(typeof(DateTimeOffset?), () => _nullableDateTimeOffsetConverter);
            _valueConverters.TryAdd(typeof(Guid), () => _guidConverter);
            _valueConverters.TryAdd(typeof(Guid?), () => _nullableGuidConverter);
            _valueConverters.TryAdd(typeof(string), () => _stringConverter);
            _valueConverters.TryAdd(typeof(byte[]), () => _byteArrayConverter);
            _valueConverters.TryAdd(typeof(object), () => _objectConverter);
        }
   
        public void RegisterConverter<T>(IValueConverter<T> converter)
            where T : IConvertible => RegisterConverter(() => converter);

        public void RegisterConverter<T>(Func<IValueConverter<T>> converter)
            where T : IConvertible => _valueConverters.AddOrUpdate(typeof(T), converter, (t, f) => converter);

        public void RegisterConverter(IValueConverter converter, FieldExpression field)
        {
            _fieldConverters.TryAdd(field, () => converter);
        }

        public IValueConverter CreateConverter(FieldExpression field)
        {
            if (_fieldConverters.TryGetValue(field, out Func<IValueConverter> converter))
                return converter();
            return CreateConverter();
        }

        public IValueConverter<T> CreateConverter<T>()
        {
            if (_valueConverters.TryGetValue(typeof(T), out Func<IConverter> converter))
                return converter() as IValueConverter<T>;

            var enumConverter = CreateEnumValueConverter(typeof(T)) 
                ?? throw new DbExpressionConfigurationException($"Could not resolve a converter for type '{typeof(T)}', please ensure a mapper has been registered for type '{typeof(T)}'");

            _valueConverters.TryAdd(typeof(T), () => enumConverter);

            return _valueConverters[typeof(T)]() as IValueConverter<T>;
        }

        public IValueConverter CreateConverter()
            => _valueConverter ?? (_valueConverter = new ValueConverter(this));

        private EnumValueConverter CreateEnumValueConverter(Type enumType)
            => CreateEnumValueConverter(enumType, enumType, false);

        private EnumValueConverter CreateEnumValueConverter(Type enumType, Type rootType, bool isNullable)
        {
            if (enumType.IsEnum)
            {
                Type converterType;
                if (isNullable)
                {
                    converterType = typeof(NullableEnumValueConverter<,>).MakeGenericType(rootType, enumType);
                }
                else
                {
                    converterType = typeof(EnumValueConverter<>).MakeGenericType(rootType);
                }
                var newUpConverter = System.Linq.Expressions.Expression.New(converterType);
                var lambda = System.Linq.Expressions.Expression.Lambda(newUpConverter);
                var invoked = lambda.Compile().DynamicInvoke();
                return invoked as EnumValueConverter;
            }
            enumType = Nullable.GetUnderlyingType(enumType);
            return enumType is null ? null : CreateEnumValueConverter(enumType, rootType, true);
        }
        #endregion

        #region classes
        protected class ValueConverter : IValueConverter
        {
            public IValueConverterFactory factory;

            public ValueConverter(IValueConverterFactory factory)
            {
                this.factory = factory;
            }

            public T Convert<T>(object value)
                => factory.CreateConverter<T>().Convert(value);

            public object Convert<T>(T value)
                => factory.CreateConverter<T>().Convert(value);
        }
        #endregion
    }
}
