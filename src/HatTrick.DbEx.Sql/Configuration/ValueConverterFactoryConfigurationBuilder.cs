using HatTrick.DbEx.Sql.Converter;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class ValueConverterFactoryConfigurationBuilder
    {
        private readonly IValueConverterFactory factory;

        public ValueConverterFactoryConfigurationBuilder(IValueConverterFactory factory)
        {
            this.factory = factory;
        }

        public void RegisterValueConverter<T>(IValueConverter<T> converter)
            where T : IConvertible
            => factory.RegisterConverter(converter);
    }
}
