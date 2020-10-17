using HatTrick.DbEx.Sql.Converter;
using System;

namespace HatTrick.DbEx.Sql.Executor
{
    public class Field : ISqlField
    {
        #region internals
        protected IValueConverter ValueConverter { get; private set; }
        #endregion

        #region interface
        public int Index { get; private set; }
        public string Name { get; private set; }
        public Type DataType { get; private set; }
        public object Value { get; private set; }
        #endregion

        #region constructors
        public Field(int index, string name, Type dataType, object value, IValueConverter valueConverter)
        {
            Index = index;
            Name = name;
            DataType = dataType;
            Value = value;
            ValueConverter = valueConverter;
        }
        #endregion

        #region methods
        public T GetValue<T>() 
            => ValueConverter.ConvertFromDatabase<T>(Value);
        #endregion
    }
}
