using HTL.DbEx.Sql.Executor;
using HTL.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTL.DbEx.Sql.Mapper
{
    public interface IMapper
    { }

    public interface IMapper<T> : IMapper
    {
        Action<T, ResultSet.Row> Map { get; }
    }

    public interface IEntityMapper<T> : IMapper<T>
        where T : class, IDBEntity
    {
    }

    public class EntityMapper<T> : IEntityMapper<T>
        where T : class, IDBEntity
    {
        public Action<T, ResultSet.Row> Map { get; }

        public EntityMapper(Action<T, ResultSet.Row> mapper)
        {
            Map = mapper;
        }
    }

    public class ExpandoObjectMapper : IMapper<ExpandoObject>
    {
        public Action<ExpandoObject, ResultSet.Row> Map { get; } = new Action<ExpandoObject, ResultSet.Row>((e, o) =>
            {
                var expando = e as IDictionary<string, object>;
                for (int i = 0; i < o.Fields.Count(); i++)
                    expando.Add(o.Fields[i].Item2, o.Fields[i].Item3);
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

    public class PrimitiveMapper<T> : IMapper<T>
    {
        public Action<T, ResultSet.Row> Map { get; }

        public PrimitiveMapper(Action<T, ResultSet.Row> mapper)
        {
            Map = mapper;
        }
    }

    public interface IMapperFactory
    {
        void RegisterDefaultMaps();

        void RegisterEntityMap<T>(Action<T, ResultSet.Row> mapFunction)
            where T : class, IDBEntity;

        IMapper<T> CreateMapper<T>(DBExpressionEntity<T> entity)
            where T : class, IDBEntity;

        IMapper<T> CreateMapper<T>();
    }

    public class MapperFactory : IMapperFactory
    {
        private IDictionary<Type, Func<IMapper>> maps = new Dictionary<Type, Func<IMapper>>();

        public void RegisterDefaultMaps()
        {
            maps.Add(typeof(bool), () => new PrimitiveMapper<bool>((o, r) => Convert.ToBoolean(r.Fields[0].Item3)));
            maps.Add(typeof(bool?), () => new PrimitiveMapper<bool?>((o, r) => o = r.Fields[0].Item3 == null ? default(bool?) : Convert.ToBoolean(r.Fields[0].Item3)));
            maps.Add(typeof(short), () => new PrimitiveMapper<short>((o, r) => Convert.ToInt16(r.Fields[0].Item3)));
            maps.Add(typeof(short?), () => new PrimitiveMapper<short?>((o, r) => o = r.Fields[0].Item3 == null ? default(short?) : Convert.ToInt16(r.Fields[0].Item3)));
            maps.Add(typeof(int), () => new PrimitiveMapper<int>((o,r) => Convert.ToInt32(r.Fields[0].Item3)));
            maps.Add(typeof(int?), () => new PrimitiveMapper<int?>((o, r) => o = r.Fields[0].Item3 == null ? default(int?) : Convert.ToInt32(r.Fields[0].Item3)));
            maps.Add(typeof(long), () => new PrimitiveMapper<long>((o, r) => Convert.ToInt64(r.Fields[0].Item3)));
            maps.Add(typeof(long?), () => new PrimitiveMapper<long?>((o, r) => o = r.Fields[0].Item3 == null ? default(long?) : Convert.ToInt64(r.Fields[0].Item3)));
            maps.Add(typeof(double), () => new PrimitiveMapper<double>((o, r) => Convert.ToDouble(r.Fields[0].Item3)));
            maps.Add(typeof(double?), () => new PrimitiveMapper<double?>((o, r) => o = r.Fields[0].Item3 == null ? default(double?) : Convert.ToDouble(r.Fields[0].Item3)));
            maps.Add(typeof(decimal), () => new PrimitiveMapper<decimal>((o, r) => Convert.ToDecimal(r.Fields[0].Item3)));
            maps.Add(typeof(decimal?), () => new PrimitiveMapper<decimal?>((o, r) => o = r.Fields[0].Item3 == null ? default(decimal?) : Convert.ToDecimal(r.Fields[0].Item3)));
            maps.Add(typeof(DateTime), () => new PrimitiveMapper<DateTime>((o, r) => Convert.ToDateTime(r.Fields[0].Item3)));
            maps.Add(typeof(DateTime?), () => new PrimitiveMapper<DateTime?>((o, r) => o = r.Fields[0].Item3 == null ? default(DateTime?) : Convert.ToDateTime(r.Fields[0].Item3)));
            maps.Add(typeof(Guid), () => new PrimitiveMapper<Guid>((o, r) => new GuidConverter().ConvertFrom(r.Fields[0].Item3)));
            maps.Add(typeof(Guid?), () => new PrimitiveMapper<Guid?>((o, r) => o = r.Fields[0].Item3 == null ? default(Guid?) : (Guid)(new GuidConverter().ConvertFrom(r.Fields[0].Item3))));
            maps.Add(typeof(string), () => new PrimitiveMapper<string>((o, r) => Convert.ToString(r.Fields[0].Item3)));
            maps.Add(typeof(ExpandoObject), () => new ExpandoObjectMapper());
        }

        public void RegisterEntityMap<T>(Action<T, ResultSet.Row> mapFunction)
            where T : class, IDBEntity
        {
            maps[typeof(T)] = () => new EntityMapper<T>(mapFunction);
        }

        public IMapper<T> CreateMapper<T>(DBExpressionEntity<T> entity)
            where T : class, IDBEntity
        {
            if (!maps.ContainsKey(typeof(T)))
            {
                maps.Add(typeof(T), () => new EntityMapper<T>(entity.FillObject));
            }
            return maps[typeof(T)]() as IMapper<T>;
        }

        public IMapper<T> CreateMapper<T>()
        {
            return maps[typeof(T)]() as IMapper<T>;
        }

    }
}
