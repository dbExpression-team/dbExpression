using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Converter
{
    public interface IValueConverterFactory
    {
        IValueConverter CreateConverter<T>();
        IValueConverter CreateConverter(Type type);
        IValueConverter CreateConverter(FieldExpression field);
        void RegisterConverter<T>(IValueConverter converter);
        void RegisterConverter<T, U>()
            where U : class, IValueConverter, new();
        void RegisterConverter(IValueConverter converter, FieldExpression field);
    }
}
