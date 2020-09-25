using HatTrick.DbEx.Sql.Converter;
using System;

namespace HatTrick.DbEx.Sql.Executor
{
    public class Field : ISqlField
    {
        protected IValueConverterFinder Converters { get; private set; }
        public int Index { get; private set; }
        public string Name { get; private set; }
        public Type DataType { get; private set; }
        public object Value { get; private set; }
        public T GetValue<T>() 
            => (Converters.FindConverter(Index) ?? Converters.FindConverter(typeof(T))).ConvertFromDatabase<T>(Value);

        public Field(int index, string name, Type dataType, object value, IValueConverterFinder finder)
        {
            Converters = finder;
            Index = index;
            Name = name;
            DataType = dataType;
            Value = value;
        }
    }
}
