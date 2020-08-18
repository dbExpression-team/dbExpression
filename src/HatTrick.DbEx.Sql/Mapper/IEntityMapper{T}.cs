using HatTrick.DbEx.Sql.Executor;
using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public interface IEntityMapper<T> : IMapper
        where T : class, IDbEntity
    {
        Action<T, ISqlFieldReader> Map { get; }
    }
}
