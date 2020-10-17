using HatTrick.DbEx.Sql.Configuration.Syntax;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Mapper;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class RuntimeSqlDatabaseMappingConfigurationBuilder : IRuntimeSqlDatabaseMappingConfigurationBuilder
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        #endregion

        #region constructors
        public RuntimeSqlDatabaseMappingConfigurationBuilder(RuntimeSqlDatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion

        #region methods
        #region mapper factory
        public IRuntimeSqlDatabaseMappingConfigurationBuilder UseThisToCreateNewEntityAndDynamicMappers(IMapperFactory factory)
        {
            configuration.MapperFactory = factory;
            return this;
        }

        public IRuntimeSqlDatabaseMappingConfigurationBuilder UseThisToCreateNewEntityAndDynamicMappers<T>()
            where T : class, IMapperFactory, new()
        {
            configuration.MapperFactory = new T();
            return this;
        }

        public IRuntimeSqlDatabaseMappingConfigurationBuilder UseThisToGetAFactoryForCreatingNewEntityAndDynamicMappers(Func<IMapperFactory> factory)
        {
            configuration.MapperFactory = new DelegateMapperFactory(factory);
            return this;
        }

        #endregion

        #region value converter factory
        public IValueConverterFactoryConfigurationBuilder UseThisToCreateNewValueConverters(IValueConverterFactory factory)
        {
            configuration.ValueConverterFactory = factory;
            return new ValueConverterFactoryConfigurationBuilder(this, configuration.ValueConverterFactory);
        }

        public IValueConverterFactoryConfigurationBuilder UseThisToCreateNewValueConverters<T>()
            where T : class, IValueConverterFactory, new()
        {
            var factory = new T();
            if (factory is ValueConverterFactory defaultValueConverterFactory)
                defaultValueConverterFactory.RegisterDefaultConverters();
            configuration.ValueConverterFactory = factory;
            return new ValueConverterFactoryConfigurationBuilder(this, configuration.ValueConverterFactory);
        }

        public IValueConverterFactoryConfigurationBuilder UseValueConverterFactory<T>(Action<ValueConverterFactoryConfigurationBuilder> configure)
            where T : IValueConverterFactory, new()
        {
            var factory = new T();
            if (factory is ValueConverterFactory defaultValueConverterFactory)
                defaultValueConverterFactory.RegisterDefaultConverters();

            var builder = new ValueConverterFactoryConfigurationBuilder(this, factory);

            configure?.Invoke(builder);
            configuration.ValueConverterFactory = factory;
            return builder;
        }

        public IValueConverterFactoryConfigurationBuilder UseTheDefaultToCreateNewValueConverters()
        {
            if (!(configuration.ValueConverterFactory is ValueConverterFactory))
            {
                var factory = new ValueConverterFactory();
                factory.RegisterDefaultConverters();
                configuration.ValueConverterFactory = factory;
            }
            return new ValueConverterFactoryConfigurationBuilder(this, configuration.ValueConverterFactory as ValueConverterFactory);
        }
        #endregion

        #region type configuration
        public ITypeConfigurationContinuationBuilder<T> ForType<T>()
            where T : IComparable
            => new TypeConfigurationBuilder<T>(configuration);

        public IEnumTypeConfigurationContinuationBuilder<T> ForEnumType<T>()
            where T : struct, Enum, IComparable
            => new EnumTypeConfigurationBuilder<T>(configuration);
        #endregion
        #endregion
    }
}
