using HatTrick.DbEx.Sql.Executor;
using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class EntityMapper<T> : IEntityMapper<T>
        where T : class, IDbEntity
    {
        public Action<T, ISqlFieldReader, IValueMapper> Map { get; private set; }

        public EntityMapper(Action<T, ISqlFieldReader, IValueMapper> mapper)
        {
            Map = mapper;
        }
    }
}
