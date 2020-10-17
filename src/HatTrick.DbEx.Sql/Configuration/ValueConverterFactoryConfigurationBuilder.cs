using HatTrick.DbEx.Sql.Configuration.Syntax;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Mapper;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class ValueConverterFactoryConfigurationBuilder : IValueConverterFactoryConfigurationBuilder
    {
        #region internals
        private readonly IRuntimeSqlDatabaseMappingConfigurationBuilder caller;
        private readonly IValueConverterFactory factory;
        #endregion

        #region constructors
        public ValueConverterFactoryConfigurationBuilder(IRuntimeSqlDatabaseMappingConfigurationBuilder caller, IValueConverterFactory factory)
        {
            this.caller = caller;
            this.factory = factory;
        }
        #endregion

        #region methods
        public void RegisterValueConverter<T>(IValueConverter converter)
            where T : IConvertible
            => factory.RegisterConverter<T>(converter);

        public ITypeConfigurationContinuationBuilder<T> ForType<T>() 
            where T : IComparable
            => caller.ForType<T>();

        public IRuntimeSqlDatabaseMappingConfigurationBuilder UseThisToGetAFactoryForCreatingNewEntityAndDynamicMappers(Func<IMapperFactory> factory)
            => caller.UseThisToGetAFactoryForCreatingNewEntityAndDynamicMappers(factory);

        public IRuntimeSqlDatabaseMappingConfigurationBuilder UseThisToCreateNewEntityAndDynamicMappers(IMapperFactory factory)
            => caller.UseThisToCreateNewEntityAndDynamicMappers(factory);

        public IValueConverterFactoryConfigurationBuilder UseThisToCreateNewValueConverters(IValueConverterFactory factory)
            => caller.UseThisToCreateNewValueConverters(factory);

        public IValueConverterFactoryConfigurationBuilder UseTheDefaultToCreateNewValueConverters()
            => caller.UseTheDefaultToCreateNewValueConverters();

        public IEnumTypeConfigurationContinuationBuilder<T> ForEnumType<T>()
            where T : struct, Enum, IComparable
            => caller.ForEnumType<T>();

        public IRuntimeSqlDatabaseMappingConfigurationBuilder UseThisToCreateNewEntityAndDynamicMappers<T>()
            where T : class, IMapperFactory, new()
            => caller.UseThisToCreateNewEntityAndDynamicMappers<T>();

        public IValueConverterFactoryConfigurationBuilder UseThisToCreateNewValueConverters<T>()
            where T : class, IValueConverterFactory, new()
            => caller.UseThisToCreateNewValueConverters<T>();
        #endregion
    }
}
