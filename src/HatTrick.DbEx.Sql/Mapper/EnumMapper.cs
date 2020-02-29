using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class EnumMapper<T> : IValueMapProvider<T>
        where T : Enum
    {
        public Func<object, T> Map { get; }

        public EnumMapper(Func<object, T> mapper)
        {
            Map = mapper;
        }
    }
}
