using System;

namespace HatTrick.DbEx.Sql.Converter
{
    public interface IValueConverter
    {
        object ConvertToDatabase(object value);
        object ConvertFromDatabase(object value);
        T ConvertFromDatabase<T>(object value);
    }
}
