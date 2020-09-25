using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Concurrent;

namespace HatTrick.DbEx.Sql.Converter
{
    public partial class ValueConverterFactory : IValueConverterFactory
    {
        #region internals
        private static readonly IValueConverter _valueConverter = new ValueConverter();
        private static readonly IValueConverter _nullableValueConverter = new NullableValueConverter();
        private readonly ConcurrentDictionary<Type, Func<IValueConverter>> _valueConverters = new ConcurrentDictionary<Type, Func<IValueConverter>>();
        private readonly ConcurrentDictionary<FieldExpression, Func<IValueConverter>> _fieldConverters = new ConcurrentDictionary<FieldExpression, Func<IValueConverter>>();
        #endregion

        #region methods
        public void RegisterDefaultConverters()
        {
            _valueConverters.TryAdd(typeof(bool), () => _valueConverter);
            _valueConverters.TryAdd(typeof(bool?), () => _nullableValueConverter);
            _valueConverters.TryAdd(typeof(short), () => _valueConverter);
            _valueConverters.TryAdd(typeof(short?), () => _nullableValueConverter);
            _valueConverters.TryAdd(typeof(int), () => _valueConverter);
            _valueConverters.TryAdd(typeof(int?), () => _nullableValueConverter);
            _valueConverters.TryAdd(typeof(long), () => _valueConverter);
            _valueConverters.TryAdd(typeof(long?), () => _nullableValueConverter);
            _valueConverters.TryAdd(typeof(double), () => _valueConverter);
            _valueConverters.TryAdd(typeof(double?), () => _nullableValueConverter);
            _valueConverters.TryAdd(typeof(decimal), () => _valueConverter);
            _valueConverters.TryAdd(typeof(decimal?), () => _nullableValueConverter);
            _valueConverters.TryAdd(typeof(float), () => _valueConverter);
            _valueConverters.TryAdd(typeof(float?), () => _nullableValueConverter);
            _valueConverters.TryAdd(typeof(DateTime), () => _valueConverter);
            _valueConverters.TryAdd(typeof(DateTime?), () => _nullableValueConverter);
            _valueConverters.TryAdd(typeof(DateTimeOffset), () => _valueConverter);
            _valueConverters.TryAdd(typeof(DateTimeOffset?), () => _nullableValueConverter);
            _valueConverters.TryAdd(typeof(Guid), () => _valueConverter);
            _valueConverters.TryAdd(typeof(Guid?), () => _nullableValueConverter);
            _valueConverters.TryAdd(typeof(string), () => _valueConverter);
            _valueConverters.TryAdd(typeof(byte[]), () => _valueConverter);
            _valueConverters.TryAdd(typeof(object), () => _valueConverter);
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

        public void RegisterConverter(IValueConverter converter, FieldExpression field)
        {
            if (converter is null)
                throw new ArgumentNullException($"{nameof(converter)} is required.");

            if (field is null)
                throw new ArgumentNullException($"{nameof(field)} is required.");

            _fieldConverters.TryAdd(field, () => converter);
        }

        public IValueConverter CreateConverter(FieldExpression field)
        {
            if (field is null)
                return null;

            if (_fieldConverters.TryGetValue(field, out Func<IValueConverter> converter))
                return converter();

            return CreateConverter((field as IExpressionField).DeclaredType);
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
                    return new NullableEnumValueConverter();
                }
                return new EnumValueConverter();
            }
            enumType = Nullable.GetUnderlyingType(enumType);
            return enumType is null ? null : CreateEnumValueConverter(enumType, rootType, true);
        }
        #endregion
    }
}
