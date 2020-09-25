using System;

namespace HatTrick.DbEx.Sql.Converter
{
    public class StringEnumValueConverter : IValueConverter
    {
        public object ConvertFromDatabase(Type type, object value)
            => value is null ? default : Enum.Parse(type, value as string);

        public T ConvertFromDatabase<T>(object value)
            => (T)Enum.Parse(typeof(T), value as string);

        public object ConvertToDatabase(Type type, object value)
            => value is null ? null : value.ToString();
    }
}
