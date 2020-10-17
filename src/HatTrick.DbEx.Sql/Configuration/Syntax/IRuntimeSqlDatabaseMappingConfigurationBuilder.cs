using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Mapper;
using System;

namespace HatTrick.DbEx.Sql.Configuration.Syntax
{
    public interface IRuntimeSqlDatabaseMappingConfigurationBuilder
    {
        IRuntimeSqlDatabaseMappingConfigurationBuilder UseThisToCreateNewEntityAndDynamicMappers(IMapperFactory factory);

        IRuntimeSqlDatabaseMappingConfigurationBuilder UseThisToCreateNewEntityAndDynamicMappers<T>()
            where T : class, IMapperFactory, new();

        IRuntimeSqlDatabaseMappingConfigurationBuilder UseThisToGetAFactoryForCreatingNewEntityAndDynamicMappers(Func<IMapperFactory> factory);

        IValueConverterFactoryConfigurationBuilder UseThisToCreateNewValueConverters(IValueConverterFactory factory);
        IValueConverterFactoryConfigurationBuilder UseThisToCreateNewValueConverters<T>()
            where T : class, IValueConverterFactory, new();

        IValueConverterFactoryConfigurationBuilder UseTheDefaultToCreateNewValueConverters();

        ITypeConfigurationContinuationBuilder<T> ForType<T>()
            where T : IComparable;

        IEnumTypeConfigurationContinuationBuilder<T> ForEnumType<T>()
            where T : struct, Enum, IComparable;
    }
}
