using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public interface IValueMapProvider<T> : IMapper
    {
        Func<object, T> Map { get; }
    }
}
