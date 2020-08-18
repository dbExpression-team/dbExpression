using HatTrick.DbEx.Sql.Converter;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IFieldExpressionConfigurationContinuationBuilder<T>
    {
        void UseConverter<U>()
            where U : class, IValueConverter, new();

        void UseConverter(IValueConverter converter);
    }
}
