using HatTrick.DbEx.Sql.Converter;
using System;

namespace HatTrick.DbEx.Sql.Configuration.Syntax
{
    public interface ITypeConfigurationContinuationBuilder<T>
        where T : IComparable
    {
        ITypeConfigurationContinuationBuilder<T> UseConverter<U>()
            where U : class, IValueConverter, new();

        ITypeConfigurationContinuationBuilder<T> UseConverter(IValueConverter converter);
    }
}
