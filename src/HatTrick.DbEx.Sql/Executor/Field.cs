using HatTrick.DbEx.Sql.Mapper;
using System;

namespace HatTrick.DbEx.Sql.Executor
{
    public class Field : ISqlField
    {
        protected IValueMapper Mapper { get; private set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
        public T GetValue<T>() => Mapper.Map<T>(Value);

        public Field(int index, string name, object value, IValueMapper mapper)
        {
            Mapper = mapper;
            Index = index;
            Name = name;
            Value = value;
        }
    }
}
