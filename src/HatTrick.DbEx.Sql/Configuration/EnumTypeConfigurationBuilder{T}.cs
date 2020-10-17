using HatTrick.DbEx.Sql.Configuration.Syntax;
using HatTrick.DbEx.Sql.Converter;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class EnumTypeConfigurationBuilder<T> : TypeConfigurationBuilder<T>, 
        IEnumTypeConfigurationContinuationBuilder<T>
        where T : struct, Enum, IComparable
    {
        public EnumTypeConfigurationBuilder(RuntimeSqlDatabaseConfiguration config) : base(config)
        {

        }

        public IEnumTypeConfigurationContinuationBuilder<T> PersistTheEnumValueAsString()
        {
            Configuration.ValueConverterFactory.RegisterConverter<T, StringEnumValueConverter>();
            return this;
        }
    }
}
