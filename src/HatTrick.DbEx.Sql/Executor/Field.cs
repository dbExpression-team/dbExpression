using HatTrick.DbEx.Sql.Converter;

namespace HatTrick.DbEx.Sql.Executor
{
    public class Field : ISqlField
    {
        protected IValueConverter Converter { get; private set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
        public T GetValue<T>() => Converter.Convert<T>(Value);

        public Field(int index, string name, object value, IValueConverter converter)
        {
            Converter = converter;
            Index = index;
            Name = name;
            Value = value;
        }
    }
}
