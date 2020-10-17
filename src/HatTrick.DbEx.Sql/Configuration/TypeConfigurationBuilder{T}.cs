using HatTrick.DbEx.Sql.Configuration.Syntax;
using HatTrick.DbEx.Sql.Converter;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class TypeConfigurationBuilder<T> : ITypeConfigurationContinuationBuilder<T>
        where T : IComparable
    {
        #region internals
        protected RuntimeSqlDatabaseConfiguration Configuration { get; private set; }
        #endregion

        #region constructors
        public TypeConfigurationBuilder(RuntimeSqlDatabaseConfiguration config)
        {
            Configuration = config;
        }
        #endregion

        #region methods
        public ITypeConfigurationContinuationBuilder<T> UseConverter<U>()
            where U : class, IValueConverter, new()
        {
            Configuration.ValueConverterFactory.RegisterConverter<T, U>();
            return this;
        }

        public ITypeConfigurationContinuationBuilder<T> UseConverter(IValueConverter converter)
        {
            Configuration.ValueConverterFactory.RegisterConverter<T>(converter);
            return this;
        }
        #endregion
    }
}
