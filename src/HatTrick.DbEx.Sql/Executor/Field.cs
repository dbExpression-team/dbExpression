using System;

namespace HatTrick.DbEx.Sql.Executor
{
    public class Field : ISqlField
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
        public T GetValue<T>()
        {
            return (T)Convert.ChangeType(Value, typeof(T));
        }

        public Field(int index, string name, object value)
        {
            Index = index;
            Name = name;
            Value = value;
        }
    }
}
