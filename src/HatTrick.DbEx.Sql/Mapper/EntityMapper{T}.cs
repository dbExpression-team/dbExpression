using HatTrick.DbEx.Sql.Executor;
using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class EntityMapper<T> : IEntityMapper<T>
        where T : class, IDbEntity
    {
        Action<ISqlFieldReader, T> map;

        Action<ISqlFieldReader, T> IEntityMapper<T>.Map => map;

        public Action<ISqlFieldReader, IDbEntity> Map => (reader, entity) => map(reader, entity as T);

        public EntityMapper(Action<ISqlFieldReader, T> map)
        {
            this.map = map ?? throw new ArgumentNullException(nameof(map));
        }
    }
}
