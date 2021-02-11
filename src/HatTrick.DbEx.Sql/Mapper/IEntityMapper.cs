using HatTrick.DbEx.Sql.Executor;
using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public interface IEntityMapper : IMapper 
    {
        Action<ISqlFieldReader, IDbEntity> Map { get; }
    }
}
