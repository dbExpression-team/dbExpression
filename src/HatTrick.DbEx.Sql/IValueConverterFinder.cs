using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql
{
    public interface IValueConverterFinder
    {
        IValueConverter FindConverter(FieldExpression field);
        IValueConverter FindConverter(Type declaredType);
        IValueConverter FindConverter(int index);
    }
}
