using HatTrick.DbEx.Sql.Converter;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class ValueConverterFactoryContinuationConfigurationBuilder : IValueConverterFactoryContinuationConfigurationBuilder
    {
        #region internals
        private readonly ValueConverterFactory factory;
        #endregion

        #region constructors
        public ValueConverterFactoryContinuationConfigurationBuilder(ValueConverterFactory factory)
        {
            this.factory = factory ?? throw new ArgumentNullException($"{nameof(factory)} is required.");
        }
        #endregion

        #region methods
        public IValueConverterFactoryContinuationConfigurationBuilder OverrideForType<T>(IValueConverter converter)
            where T : IComparable
        {
            factory.RegisterConverter<T>(converter);
            return this;
        }

        public IValueConverterFactoryContinuationConfigurationBuilder OverrideForType<T, TConverter>()
            where T : IComparable
            where TConverter : class, IValueConverter, new()
        {
            factory.RegisterConverter<T,TConverter>();
            return this;
        }

        public IEnumTypeValueConverterConfigurationBuilder<TEnum> OverrideForEnumType<TEnum>()
            where TEnum : struct, Enum, IComparable
        {
            return new EnumTypeValueConverterConfigurationBuilder<TEnum>(this, factory);
        }

        public IValueConverterFactoryContinuationConfigurationBuilder OverrideForEnumType<TEnum>(IValueConverter converter)
            where TEnum : struct, Enum, IComparable
        {
            factory.RegisterConverter<TEnum>(converter);
            return this;
        }

        public IValueConverterFactoryContinuationConfigurationBuilder OverrideForEnumType<TEnum, TConverter>()
            where TEnum : struct, Enum, IComparable
            where TConverter : class, IValueConverter, new()
        {
            factory.RegisterConverter<TEnum, TConverter>();
            return this;
        }
        #endregion
    }
}
