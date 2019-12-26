using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public interface IEntityFactory
    {
        T CreateEntity<T>() where T : class, IDbEntity, new();
    }
}
