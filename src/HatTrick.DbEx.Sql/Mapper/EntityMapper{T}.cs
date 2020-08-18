using HatTrick.DbEx.Sql.Executor;
using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class EntityMapper<T> : IEntityMapper<T>
        where T : class, IDbEntity
    {
        public Action<T, ISqlFieldReader> Map { get; private set; }

        public EntityMapper(Action<T, ISqlFieldReader> map)
        {
            Map = map;
        }
    }
}
