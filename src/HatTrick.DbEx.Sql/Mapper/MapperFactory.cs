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

        public void RegisterDefaultMappers()
        {
            maps.Add(typeof(bool), () => new PrimitiveMapper<bool>((f) => Convert.ToBoolean(f)));
            maps.Add(typeof(bool?), () => new PrimitiveMapper<bool?>((f) => f == null ? default(bool?) : Convert.ToBoolean(f)));
            maps.Add(typeof(short), () => new PrimitiveMapper<short>((f) => Convert.ToInt16(f)));
            maps.Add(typeof(short?), () => new PrimitiveMapper<short?>((f) => f == null ? default(short?) : Convert.ToInt16(f)));
            maps.Add(typeof(int), () => new PrimitiveMapper<int>((f) => Convert.ToInt32(f)));
            maps.Add(typeof(int?), () => new PrimitiveMapper<int?>((f) => f == null ? default(int?) : Convert.ToInt32(f)));
            maps.Add(typeof(long), () => new PrimitiveMapper<long>((f) => Convert.ToInt64(f)));
            maps.Add(typeof(long?), () => new PrimitiveMapper<long?>((f) => f == null ? default(long?) : Convert.ToInt64(f)));
            maps.Add(typeof(double), () => new PrimitiveMapper<double>((f) => Convert.ToDouble(f)));
            maps.Add(typeof(double?), () => new PrimitiveMapper<double?>((f) => f == null ? default(double?) : Convert.ToDouble(f)));
            maps.Add(typeof(decimal), () => new PrimitiveMapper<decimal>((f) => Convert.ToDecimal(f)));
            maps.Add(typeof(decimal?), () => new PrimitiveMapper<decimal?>((f) => f == null ? default(decimal?) : Convert.ToDecimal(f)));
            maps.Add(typeof(DateTime), () => new PrimitiveMapper<DateTime>((f) => Convert.ToDateTime(f)));
            maps.Add(typeof(DateTime?), () => new PrimitiveMapper<DateTime?>((f) => f == null ? default(DateTime?) : Convert.ToDateTime(f)));
            maps.Add(typeof(Guid), () => new PrimitiveMapper<Guid>((f) => (Guid)new GuidConverter().ConvertFrom(f)));
            maps.Add(typeof(Guid?), () => new PrimitiveMapper<Guid?>((f) => f == null ? default(Guid?) : (Guid)(new GuidConverter().ConvertFrom(f))));
            maps.Add(typeof(string), () => new PrimitiveMapper<string>((f) => Convert.ToString(f)));
            maps.Add(typeof(ExpandoObject), () => new ExpandoObjectMapper());
        }

        public void RegisterValueMapper<T>(IValueMapper<T> mapper)
            where T : IComparable => RegisterValueMapper(() => mapper);

        public void RegisterValueMapper<T>(Func<IValueMapper<T>> mapper)
            where T : IComparable => maps[typeof(T)] = mapper;

        public void RegisterEntityMapper<T>(Action<SqlStatementExecutionResultSet.Row, T, IValueMapper> mapFunction)
            where T : class, IDbEntity => maps[typeof(T)] = () => new EntityMapper<T>(mapFunction);

        public IEntityMapper<T> CreateEntityMapper<T>(EntityExpression<T> entity)
            where T : class, IDbEntity
        {
            if (!maps.ContainsKey(typeof(T)))
            {
                // "auto-fill" on first request any entities that have not been specifically registered
                RegisterEntityMapper<T>(entity.FillObject);
            }
            return maps[typeof(T)]() as IEntityMapper<T>;
        }

        public IValueMapper<T> CreateValueMapper<T>()
            => maps[typeof(T)]() as IValueMapper<T>;

        public IExpandoObjectMapper CreateExpandoObjectMapper()
            => maps[typeof(ExpandoObject)]() as IExpandoObjectMapper;

        public IValueMapper CreateValueMapper() => _valueMapper ?? (_valueMapper = new ValueMapper(this));
    }
}
