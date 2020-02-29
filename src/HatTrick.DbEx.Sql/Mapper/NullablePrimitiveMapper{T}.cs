using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class NullablePrimitiveMapper<T> : IValueMapProvider<T>
    {
        public Func<object, T> Map { get; }

        public NullablePrimitiveMapper(Func<object, T> mapper)
        {
            Map = mapper;
        }
    }
}
