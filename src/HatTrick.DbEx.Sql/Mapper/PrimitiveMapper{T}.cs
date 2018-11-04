using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class PrimitiveMapper<T> : IValueMapper<T>
    {
        public Func<object, T> Map { get; }

        public PrimitiveMapper(Func<object, T> mapper)
        {
            Map = mapper;
        }
    }
}
