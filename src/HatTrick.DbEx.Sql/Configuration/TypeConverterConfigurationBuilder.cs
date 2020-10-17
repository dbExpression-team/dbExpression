using HatTrick.DbEx.Sql.Configuration.Syntax;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class TypeConverterConfigurationBuilder : ITypeConfigurationBuilder
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration config;
        #endregion

        #region constructors
        public TypeConverterConfigurationBuilder(RuntimeSqlDatabaseConfiguration config)
        {
            this.config = config;
        }
        #endregion

        #region methods
        public ITypeConfigurationContinuationBuilder<T> ForType<T>()
            where T : IComparable
            => new TypeConfigurationBuilder<T>(config);

        public IEnumTypeConfigurationContinuationBuilder<T> ForEnumType<T>()
            where T : struct, Enum, IComparable
            => new EnumTypeConfigurationBuilder<T>(config);
        #endregion
    }
}
