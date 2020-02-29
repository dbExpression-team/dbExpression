using System;

namespace HatTrick.DbEx.Sql.Mapper
{
    public class StringMapper : IValueMapProvider<string>
    {
        public Func<object, string> Map { get; }

        public StringMapper(Func<object, string> mapper)
        {
            Map = mapper;
        }
    }
}
