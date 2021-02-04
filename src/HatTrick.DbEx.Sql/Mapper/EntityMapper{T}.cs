using HatTrick.DbEx.Sql.Executor;
using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class EntityMapper<T> : IEntityMapper<T>
        where T : class, IDbEntity
    {
        Action<T, ISqlFieldReader> map;

        Action<T, ISqlFieldReader> IEntityMapper<T>.Map => map;

        public Action<IDbEntity, ISqlFieldReader> Map => (entity, reader) => map(entity as T, reader);

        public EntityMapper(Action<T, ISqlFieldReader> map)
        {
            this.map = map ?? throw new ArgumentNullException($"{nameof(map)} is required.");
        }
    }
}
