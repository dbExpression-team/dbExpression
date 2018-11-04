using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public interface IValueMapper<T> : IMapper
    {
        Func<object, T> Map { get; }
    }
}
