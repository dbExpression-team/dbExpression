using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Converter
{
    public interface IValueConverterFactory
    {
        IValueConverter CreateConverter();
        IValueConverter<T> CreateConverter<T>();
        IValueConverter CreateConverter(FieldExpression field);
        void RegisterConverter<T>(IValueConverter<T> converter)
            where T : IConvertible;
        void RegisterConverter(IValueConverter converter, FieldExpression field);
    }
}
