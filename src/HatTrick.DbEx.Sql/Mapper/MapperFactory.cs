using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Concurrent;
using System.Dynamic;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class MapperFactory : IMapperFactory
    {
        #region internals
        private IValueMapper _valueMapper;

        private static readonly PrimitiveMapper<bool> _boolMapper = new PrimitiveMapper<bool>(Convert.ToBoolean);
        private static readonly PrimitiveMapper<bool?> _nullableBoolMapper = new PrimitiveMapper<bool?>((f) => f is null ? default(bool?) : Convert.ToBoolean(f));
        private static readonly PrimitiveMapper<short> _shortMapper = new PrimitiveMapper<short>(Convert.ToInt16);
        private static readonly PrimitiveMapper<short?> _nullableShortMapper = new PrimitiveMapper<short?>((f) => f is null ? default(short?) : Convert.ToInt16(f));
        private static readonly PrimitiveMapper<int> _intMapper = new PrimitiveMapper<int>(Convert.ToInt32);
        private static readonly PrimitiveMapper<int?> _nullableIntMapper = new PrimitiveMapper<int?>((f) => f is null ? default(int?) : Convert.ToInt32(f));
        private static readonly PrimitiveMapper<long> _longMapper = new PrimitiveMapper<long>(Convert.ToInt64);
        private static readonly PrimitiveMapper<long?> _nullableLongMapper = new PrimitiveMapper<long?>((f) => f is null ? default(long?) : Convert.ToInt64(f));
        private static readonly PrimitiveMapper<double> _doubleMapper = new PrimitiveMapper<double>(Convert.ToDouble);
        private static readonly PrimitiveMapper<double?> _nullableDoubleMapper = new PrimitiveMapper<double?>((f) => f is null ? default(double?) : Convert.ToDouble(f));
        private static readonly PrimitiveMapper<decimal> _decimalMapper = new PrimitiveMapper<decimal>(Convert.ToDecimal);
        private static readonly PrimitiveMapper<decimal?> _nullableDecimalMapper = new PrimitiveMapper<decimal?>((f) => f is null ? default(decimal?) : Convert.ToDecimal(f));
        private static readonly PrimitiveMapper<float> _floatMapper = new PrimitiveMapper<float>(Convert.ToSingle);
        private static readonly PrimitiveMapper<float?> _nullableFloatMapper = new PrimitiveMapper<float?>((f) => f is null ? default(float?) : Convert.ToSingle(f));
        private static readonly PrimitiveMapper<DateTime> _dateTimeMapper = new PrimitiveMapper<DateTime>(Convert.ToDateTime);
        private static readonly PrimitiveMapper<DateTime?> _nullableDateTimeMapper = new PrimitiveMapper<DateTime?>((f) => f is null ? default(DateTime?) : Convert.ToDateTime(f));
        private static readonly PrimitiveMapper<DateTimeOffset> _dateTimeOffsetMapper = new PrimitiveMapper<DateTimeOffset>((f) => new DateTimeOffset(Convert.ToDateTime(f)));
        private static readonly PrimitiveMapper<DateTimeOffset?> _nullableDateTimeOffsetMapper = new PrimitiveMapper<DateTimeOffset?>((f) => f is null ? default(DateTimeOffset?) : new DateTimeOffset(Convert.ToDateTime(f)));
        private static readonly PrimitiveMapper<Guid> _guidMapper = new PrimitiveMapper<Guid>((f) => (Guid)f);
        private static readonly PrimitiveMapper<Guid?> _nullableGuidMapper = new PrimitiveMapper<Guid?>((f) => (Guid?)f);
        private static readonly PrimitiveMapper<string> _stringMapper = new PrimitiveMapper<string>(Convert.ToString);
        private static readonly PrimitiveMapper<Enum> _enumMapper = new PrimitiveMapper<Enum>((f) => (Enum)f);
        private static readonly ExpandoObjectMapper _expandoObjectMapper = new ExpandoObjectMapper();
        private static readonly PrimitiveMapper<byte[]> _byteArrayMapper = new PrimitiveMapper<byte[]>((f) => f is null ? default : (byte[])f);

        private readonly ConcurrentDictionary<Type, Func<IMapper>> _valueMaps = new ConcurrentDictionary<Type, Func<IMapper>>();
        private readonly ConcurrentDictionary<Type, Func<IMapper>> _entityMaps = new ConcurrentDictionary<Type, Func<IMapper>>();
        #endregion

        #region constructors
        public void RegisterDefaultMappers()
        {
            _valueMaps.TryAdd(typeof(bool), () => _boolMapper);
            _valueMaps.TryAdd(typeof(bool?), () => _nullableBoolMapper);
            _valueMaps.TryAdd(typeof(short), () => _shortMapper);
            _valueMaps.TryAdd(typeof(short?), () => _nullableShortMapper);
            _valueMaps.TryAdd(typeof(int), () => _intMapper);
            _valueMaps.TryAdd(typeof(int?), () => _nullableIntMapper);
            _valueMaps.TryAdd(typeof(long), () => _longMapper);
            _valueMaps.TryAdd(typeof(long?), () => _nullableLongMapper);
            _valueMaps.TryAdd(typeof(double), () => _doubleMapper);
            _valueMaps.TryAdd(typeof(double?), () => _nullableDoubleMapper);
            _valueMaps.TryAdd(typeof(decimal), () => _decimalMapper);
            _valueMaps.TryAdd(typeof(decimal?), () => _nullableDecimalMapper);
            _valueMaps.TryAdd(typeof(float), () => _floatMapper);
            _valueMaps.TryAdd(typeof(float?), () => _nullableFloatMapper);
            _valueMaps.TryAdd(typeof(DateTime), () => _dateTimeMapper);
            _valueMaps.TryAdd(typeof(DateTime?), () => _nullableDateTimeMapper);
            _valueMaps.TryAdd(typeof(DateTimeOffset), () => _dateTimeOffsetMapper);
            _valueMaps.TryAdd(typeof(DateTimeOffset?), () => _nullableDateTimeOffsetMapper);
            _valueMaps.TryAdd(typeof(Guid), () => _guidMapper);
            _valueMaps.TryAdd(typeof(Guid?), () => _nullableGuidMapper);
            _valueMaps.TryAdd(typeof(string), () => _stringMapper);
            _valueMaps.TryAdd(typeof(Enum), () => _enumMapper);
            _valueMaps.TryAdd(typeof(ExpandoObject), () => _expandoObjectMapper);
            _valueMaps.TryAdd(typeof(byte[]), () => _byteArrayMapper);
        }
        #endregion

        #region methods
        #region entity
        public void RegisterEntityMapper<T>(Action<T, ISqlFieldReader, IValueMapper> mapFunction)
            where T : class, IDbEntity => _entityMaps.AddOrUpdate(typeof(T), () => new EntityMapper<T>(mapFunction), (t, f) => () => new EntityMapper<T>(mapFunction));

        public IEntityMapper<T> CreateEntityMapper<T>(EntityExpression<T> entity)
            where T : class, IDbEntity
        {
            if (_entityMaps.TryGetValue(typeof(T), out Func<IMapper> map))
                return map() as IEntityMapper<T>;

            var entityMap = new EntityMapper<T>((entity as IDbExpressionEntity<T>).HydrateEntity);
            _entityMaps.TryAdd(typeof(T), () => entityMap);

            return entityMap;
        }
        #endregion

        #region value
        public void RegisterValueMapProvider<T>(IValueMapProvider<T> mapper)
            where T : IComparable => RegisterValueMapProvider(() => mapper);

        public void RegisterValueMapProvider<T>(Func<IValueMapProvider<T>> mapper)
            where T : IComparable => _valueMaps.AddOrUpdate(typeof(T), mapper, (t,f) => mapper);

        public IValueMapProvider<T> CreateValueMapper<T>()
        {
            if (_valueMaps.TryGetValue(typeof(T), out Func<IMapper> mapper))
                return mapper() as IValueMapProvider<T>;

            var enumMapper = CreateEnumMapper<T>() ?? throw new DbExpressionConfigurationException($"Could not resolve a mapper for type '{typeof(T)}', please ensure a mapper has been registered for type '{typeof(T)}'");

            _valueMaps.TryAdd(typeof(T), () => enumMapper);

            return _valueMaps[typeof(T)]() as IValueMapProvider<T>;
        }

        public IExpandoObjectMapper CreateExpandoObjectMapper()
        {
            if (!_valueMaps.TryGetValue(typeof(ExpandoObject), out Func<IMapper> xpandoMapper))
            {
                throw new DbExpressionConfigurationException($"Could not resolve a mapper for type '{typeof(ExpandoObject)}', please ensure a mapper has been registered for type '{typeof(ExpandoObject)}'");
            }
            return xpandoMapper() as IExpandoObjectMapper;
        }

        public IValueMapper CreateValueMapper() => _valueMapper ?? (_valueMapper = new ValueMapper(this));

        private IValueMapProvider<T> CreateEnumMapper<T>()
        {
            Type enumType = null;
            if (typeof(T).IsEnum)
            {
                enumType = typeof(T);
            }
            else if (typeof(T).IsGenericType && typeof(T).GetGenericArguments().Length == 1 && typeof(T).GetGenericArguments()[0].IsEnum)
            {
                enumType = typeof(T).GetGenericArguments()[0];
            }
            return enumType is null ? null : new PrimitiveMapper<T>(value => value is null ? default : value is string ? (T)Enum.Parse(enumType, value as string) : (T)Enum.ToObject(enumType, value));
        }
        #endregion
        #endregion
    }
}
