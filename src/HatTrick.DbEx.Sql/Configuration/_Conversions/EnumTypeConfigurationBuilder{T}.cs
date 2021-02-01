using HatTrick.DbEx.Sql.Converter;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class EnumTypeValueConverterConfigurationBuilder<T> : IEnumTypeValueConverterConfigurationBuilder<T>
        where T : struct, Enum, IComparable
    {
        #region internals
        private readonly IValueConverterFactoryContinuationConfigurationBuilder caller;
        private readonly ValueConverterFactory factory;
        #endregion

        #region constructors
        public EnumTypeValueConverterConfigurationBuilder(IValueConverterFactoryContinuationConfigurationBuilder caller, ValueConverterFactory factory)
        {
            this.caller = caller ?? throw new ArgumentNullException($"{nameof(caller)} is required.");
            this.factory = factory ?? throw new ArgumentNullException($"{nameof(factory)} is required.");
        }
        #endregion

        #region methods
        public IValueConverterFactoryContinuationConfigurationBuilder PersistAsString()
        {
            factory.RegisterConverter<T, StringEnumValueConverter>();
            return caller;
        }
        #endregion
    }
}
