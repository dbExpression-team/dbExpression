using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class MapperFactory : IMapperFactory
    {
        private IDictionary<Type, Func<IMapper>> maps = new Dictionary<Type, Func<IMapper>>();
        private IValueMapper _valueMapper;

        private static readonly PrimitiveMapper<bool> _boolMapper = new PrimitiveMapper<bool>((f) => Convert.ToBoolean(f));
        private static readonly PrimitiveMapper<bool?> _nullableBoolMapper = new PrimitiveMapper<bool?>((f) => f == null ? default(bool?) : Convert.ToBoolean(f));
        private static readonly PrimitiveMapper<short> _shortMapper = new PrimitiveMapper<short>((f) => Convert.ToInt16(f));
        private static readonly PrimitiveMapper<short?> _nullableShortMapper = new PrimitiveMapper<short?>((f) => f == null ? default(short?) : Convert.ToInt16(f));
        private static readonly PrimitiveMapper<int> _intMapper = new PrimitiveMapper<int>((f) => Convert.ToInt32(f));
        private static readonly PrimitiveMapper<int?> _nullableIntMapper = new PrimitiveMapper<int?>((f) => f == null ? default(int?) : Convert.ToInt32(f));
        private static readonly PrimitiveMapper<long> _longMapper = new PrimitiveMapper<long>((f) => Convert.ToInt64(f));
        private static readonly PrimitiveMapper<long?> _nullableLongMapper = new PrimitiveMapper<long?>((f) => f == null ? default(long?) : Convert.ToInt64(f));
        private static readonly PrimitiveMapper<double> _doubleMapper = new PrimitiveMapper<double>((f) => Convert.ToDouble(f));
        private static readonly PrimitiveMapper<double?> _nullableDoubleMapper = new PrimitiveMapper<double?>((f) => f == null ? default(double?) : Convert.ToDouble(f));
        private static readonly PrimitiveMapper<decimal> _decimalMapper = new PrimitiveMapper<decimal>((f) => Convert.ToDecimal(f));
        private static readonly PrimitiveMapper<decimal?> _nullableDecimalMapper = new PrimitiveMapper<decimal?>((f) => f == null ? default(decimal?) : Convert.ToDecimal(f));
        private static readonly PrimitiveMapper<float> _floatMapper = new PrimitiveMapper<float>((f) => Convert.ToSingle(f));
        private static readonly PrimitiveMapper<float?> _nullableFloatMapper = new PrimitiveMapper<float?>((f) => f == null ? default(float?) : Convert.ToSingle(f));
        private static readonly PrimitiveMapper<DateTime> _dateTimeMapper = new PrimitiveMapper<DateTime>((f) => Convert.ToDateTime(f));
        private static readonly PrimitiveMapper<DateTime?> _nullableDateTimeMapper = new PrimitiveMapper<DateTime?>((f) => f == null ? default(DateTime?) : Convert.ToDateTime(f));
        private static readonly PrimitiveMapper<DateTimeOffset> _dateTimeOffsetMapper = new PrimitiveMapper<DateTimeOffset>((f) => new DateTimeOffset(Convert.ToDateTime(f)));
        private static readonly PrimitiveMapper<DateTimeOffset?> _nullableDateTimeOffsetMapper = new PrimitiveMapper<DateTimeOffset?>((f) => f == null ? default(DateTimeOffset?) : new DateTimeOffset(Convert.ToDateTime(f)));
        private static readonly PrimitiveMapper<Guid> _guidMapper = new PrimitiveMapper<Guid>((f) => (Guid)new GuidConverter().ConvertFrom(f));
        private static readonly PrimitiveMapper<Guid?> _nullableGuidMapper = new PrimitiveMapper<Guid?>((f) => f == null ? default(Guid?) : (Guid)new GuidConverter().ConvertFrom(f));
        private static readonly PrimitiveMapper<string> _stringMapper = new PrimitiveMapper<string>((f) => Convert.ToString(f));
        private static readonly ExpandoObjectMapper _expandoObjectMapper = new ExpandoObjectMapper();
        //NOTE: JRod, byte[] is not a primitive, but is handled exactly the same ...
        private static readonly PrimitiveMapper<byte[]> _byteArrayMapper = new PrimitiveMapper<byte[]>((f) => f == null ? default : (byte[])f);

        public void RegisterDefaultMappers()
        {
            maps.Add(typeof(bool), () => _boolMapper);
            maps.Add(typeof(bool?), () => _nullableBoolMapper);
            maps.Add(typeof(short), () => _shortMapper);
            maps.Add(typeof(short?), () => _nullableShortMapper);
            maps.Add(typeof(int), () => _intMapper);
            maps.Add(typeof(int?), () => _nullableIntMapper);
            maps.Add(typeof(long), () => _longMapper);
            maps.Add(typeof(long?), () => _nullableLongMapper);
            maps.Add(typeof(double), () => _doubleMapper);
            maps.Add(typeof(double?), () => _nullableDoubleMapper);
            maps.Add(typeof(decimal), () => _decimalMapper);
            maps.Add(typeof(decimal?), () => _nullableDecimalMapper);
            maps.Add(typeof(float), () => _floatMapper);
            maps.Add(typeof(float?), () => _nullableFloatMapper);
            maps.Add(typeof(DateTime), () => _dateTimeMapper);
            maps.Add(typeof(DateTime?), () => _nullableDateTimeMapper);
            maps.Add(typeof(DateTimeOffset), () => _dateTimeOffsetMapper);
            maps.Add(typeof(DateTimeOffset?), () => _nullableDateTimeOffsetMapper);
            maps.Add(typeof(Guid), () => _guidMapper);
            maps.Add(typeof(Guid?), () => _nullableGuidMapper);
            maps.Add(typeof(string), () => _stringMapper);
            maps.Add(typeof(ExpandoObject), () => _expandoObjectMapper);
            maps.Add(typeof(byte[]), () => _byteArrayMapper);
        }

        public void RegisterValueMapper<T>(IValueMapper<T> mapper)
            where T : IComparable => RegisterValueMapper(() => mapper);

        public void RegisterValueMapper<T>(Func<IValueMapper<T>> mapper)
            where T : IComparable => maps[typeof(T)] = mapper;

        public void RegisterEntityMapper<T>(Action<T, ISqlFieldReader, IValueMapper> mapFunction)
            where T : class, IDbEntity => maps[typeof(T)] = () => new EntityMapper<T>(mapFunction);

        public IEntityMapper<T> CreateEntityMapper<T>(EntityExpression<T> entity)
            where T : class, IDbEntity
        {
            if (maps.TryGetValue(typeof(T), out Func<IMapper> map))
                return map() as IEntityMapper<T>;

            var entityMap = new EntityMapper<T>((entity as IDbExpressionEntity<T>).HydrateEntity);
            maps.Add(typeof(T), () => entityMap);

            return entityMap;
        }

        public IValueMapper<T> CreateValueMapper<T>()
            => maps[typeof(T)]() as IValueMapper<T>;

        public IExpandoObjectMapper CreateExpandoObjectMapper()
            => maps[typeof(ExpandoObject)]() as IExpandoObjectMapper;

        public IValueMapper CreateValueMapper() => _valueMapper ?? (_valueMapper = new ValueMapper(this));
    }
}
