using System;

namespace HatTrick.DbEx.Sql.Converter
{
    public interface IValueConverter
    {
        object ConvertToDatabase(Type type, object value);
        object ConvertFromDatabase(Type type, object value);
        T ConvertFromDatabase<T>(object value);
    }
}
