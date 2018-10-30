using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Mapper
{
    public interface IMapper
    { }

    public interface IValueMapper<T> : IMapper
    {
        Func<SqlStatementExecutionResultSet.Field, T> Map { get; }
    }

    public interface IEntityMapper<T> : IMapper
        where T : class, IDbEntity
    {
        Action<T, SqlStatementExecutionResultSet.Row> Map { get; }
    }

    public interface IExpandoObjectMapper : IMapper
    {
        Action<ExpandoObject, SqlStatementExecutionResultSet.Row> Map { get; }
    }

    public class EntityMapper<T> : IEntityMapper<T>
        where T : class, IDbEntity
    {
        public Action<T, SqlStatementExecutionResultSet.Row> Map { get; }

        public EntityMapper(Action<T, SqlStatementExecutionResultSet.Row> mapper)
        {
            Map = mapper;
        }
    }

    public class ExpandoObjectMapper : IExpandoObjectMapper
    {
        public Action<ExpandoObject, SqlStatementExecutionResultSet.Row> Map { get; } = new Action<ExpandoObject, SqlStatementExecutionResultSet.Row>((e, o) =>
            {
                var expando = e as IDictionary<string, object>;
                for (int i = 0; i < o.Fields.Count(); i++)
                    expando.Add(o.Fields[i].Name, o.Fields[i].Value);
            });
    }

    //public class PrimitiveMapper<T> : IMapper<T>
    //    where T : IComparable
    //{
    //    public Action<T, ResultSet.Row> Map { get; }

    //    public PrimitiveMapper(Action<T, ResultSet.Row> mapper)
    //    {
    //        Map = mapper;
    //    }
    //}

    public class PrimitiveMapper<T> : IValueMapper<T>
    {
        public Func<SqlStatementExecutionResultSet.Field, T> Map { get; }

        public PrimitiveMapper(Func<SqlStatementExecutionResultSet.Field, T> mapper)
        {
            Map = mapper;
        }
    }

    public interface IMapperFactory
    {
        void RegisterDefaultMaps();

        void RegisterEntityMap<T>(Action<T, SqlStatementExecutionResultSet.Row> mapFunction)
            where T : class, IDbEntity;

        IEntityMapper<T> CreateEntityMapper<T>(EntityExpression<T> entity)
            where T : class, IDbEntity;

        IValueMapper<T> CreateValueMapper<T>();

        IExpandoObjectMapper CreateExpandoObjectMapper();
    }

    public class MapperFactory : IMapperFactory
    {
        private IDictionary<Type, Func<IMapper>> maps = new Dictionary<Type, Func<IMapper>>();

        public void RegisterDefaultMaps()
        {
            maps.Add(typeof(bool), () => new PrimitiveMapper<bool>((f) => Convert.ToBoolean(f.Value)));
            maps.Add(typeof(bool?), () => new PrimitiveMapper<bool?>((f) => f.Value == null ? default(bool?) : Convert.ToBoolean(f.Value)));
            maps.Add(typeof(short), () => new PrimitiveMapper<short>((f) => Convert.ToInt16(f.Value)));
            maps.Add(typeof(short?), () => new PrimitiveMapper<short?>((f) => f.Value == null ? default(short?) : Convert.ToInt16(f.Value)));
            maps.Add(typeof(int), () => new PrimitiveMapper<int>((f) => Convert.ToInt32(f.Value)));
            maps.Add(typeof(int?), () => new PrimitiveMapper<int?>((f) => f.Value == null ? default(int?) : Convert.ToInt32(f.Value)));
            maps.Add(typeof(long), () => new PrimitiveMapper<long>((f) => Convert.ToInt64(f.Value)));
            maps.Add(typeof(long?), () => new PrimitiveMapper<long?>((f) => f.Value == null ? default(long?) : Convert.ToInt64(f.Value)));
            maps.Add(typeof(double), () => new PrimitiveMapper<double>((f) => Convert.ToDouble(f.Value)));
            maps.Add(typeof(double?), () => new PrimitiveMapper<double?>((f) => f.Value == null ? default(double?) : Convert.ToDouble(f.Value)));
            maps.Add(typeof(decimal), () => new PrimitiveMapper<decimal>((f) => Convert.ToDecimal(f.Value)));
            maps.Add(typeof(decimal?), () => new PrimitiveMapper<decimal?>((f) => f.Value == null ? default(decimal?) : Convert.ToDecimal(f.Value)));
            maps.Add(typeof(DateTime), () => new PrimitiveMapper<DateTime>((f) => Convert.ToDateTime(f.Value)));
            maps.Add(typeof(DateTime?), () => new PrimitiveMapper<DateTime?>((f) => f.Value == null ? default(DateTime?) : Convert.ToDateTime(f.Value)));
            maps.Add(typeof(Guid), () => new PrimitiveMapper<Guid>((f) => (Guid)new GuidConverter().ConvertFrom(f.Value)));
            maps.Add(typeof(Guid?), () => new PrimitiveMapper<Guid?>((f) => f.Value == null ? default(Guid?) : (Guid)(new GuidConverter().ConvertFrom(f.Value))));
            maps.Add(typeof(string), () => new PrimitiveMapper<string>((f) => Convert.ToString(f.Value)));
            maps.Add(typeof(ExpandoObject), () => new ExpandoObjectMapper());
        }

        public void RegisterEntityMap<T>(Action<T, SqlStatementExecutionResultSet.Row> mapFunction)
            where T : class, IDbEntity
        {
            maps[typeof(T)] = () => new EntityMapper<T>(mapFunction);
        }

        public IEntityMapper<T> CreateEntityMapper<T>(EntityExpression<T> entity)
            where T : class, IDbEntity
        {
            if (!maps.ContainsKey(typeof(T)))
            {
                maps.Add(typeof(T), () => new EntityMapper<T>(entity.FillObject));
            }
            return maps[typeof(T)]() as IEntityMapper<T>;
        }

        public IValueMapper<T> CreateValueMapper<T>()
        {
            return maps[typeof(T)]() as IValueMapper<T>;
        }

        public IExpandoObjectMapper CreateExpandoObjectMapper()
        {
            return maps[typeof(ExpandoObject)]() as IExpandoObjectMapper;
        }

    }
}
