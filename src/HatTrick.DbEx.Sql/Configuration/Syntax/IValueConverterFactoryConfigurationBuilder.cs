using HatTrick.DbEx.Sql.Converter;
using System;

namespace HatTrick.DbEx.Sql.Configuration.Syntax
{
    public interface IValueConverterFactoryConfigurationBuilder : IRuntimeSqlDatabaseMappingConfigurationBuilder
    {
        void RegisterValueConverter<T>(IValueConverter converter)
                where T : IConvertible;
    }
}
