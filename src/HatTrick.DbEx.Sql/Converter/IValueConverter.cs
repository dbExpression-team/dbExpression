using System;

namespace HatTrick.DbEx.Sql.Converter
{
    public interface IValueConverter : IConverter
    {
        T Convert<T>(object value);
        object Convert<T>(T value);
    }
}
