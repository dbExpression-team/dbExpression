using HatTrick.DbEx.Sql.Executor;
using System;
using System.Dynamic;

namespace HatTrick.DbEx.Sql.Mapper
{
    public interface IExpandoObjectMapper : IMapper
    {
        Action<ExpandoObject, ISqlRow> Map { get; }
    }
}
