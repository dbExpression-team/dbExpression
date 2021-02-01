using HatTrick.DbEx.Sql.Executor;
using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public interface IEntityMapper<T> : IEntityMapper
        where T : class, IDbEntity
    {
        new Action<T, ISqlFieldReader> Map { get; }
    }
}
