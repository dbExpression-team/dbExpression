using HatTrick.DbEx.Sql.Converter;
using System;

namespace HatTrick.DbEx.Sql.Executor
{
    public class Field : ISqlField
    {
        protected IValueConverter Converter { get; private set; }
        public int Index { get; private set; }
        public string Name { get; private set; }
        public Type DataType { get; private set; }
        public object Value { get; private set; }
        public T GetValue<T>() => Converter.Convert<T>(Value);

        public Field(int index, string name, Type dataType, object value, IValueConverter converter)
        {
            Converter = converter;
            Index = index;
            Name = name;
            DataType = dataType;
            Value = value;
        }
    }
}
