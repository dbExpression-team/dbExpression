using HatTrick.DbEx.Sql.Executor;
using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public interface IEntityMapper : IMapper 
    {
        Action<IDbEntity, ISqlFieldReader> Map { get; }
    }
}
