using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Converter
{
    public interface IValueConverterFactory
    {
        IValueConverter CreateConverter<T>();
        IValueConverter CreateConverter(Type type);
    }
}
