using HatTrick.DbEx.Sql.Converter;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IValueConverterFactoryContinuationConfigurationBuilder
    {
        /// <summary>
        /// Override the default behaviour of converting <typeparamref name="TEnum"/> values to and from a different value type. 
        /// </summary>
        /// <typeparam name="TEnum">The type of the enumeration.</typeparam>
        IEnumTypeValueConverterConfigurationBuilder<TEnum> OverrideForEnumType<TEnum>()
            where TEnum : struct, Enum, IComparable;

        /// <summary>
        /// Override the default behaviour of converting <typeparamref name="TEnum"/> values to and from a different value type using the provided value converter. 
        /// </summary>
        /// <typeparam name="TEnum">The type of the enumeration.</typeparam>
        /// <param name="converter">The custom converter that will convert data to and from the database.</param>
        IValueConverterFactoryContinuationConfigurationBuilder OverrideForEnumType<TEnum>(IValueConverter converter)
            where TEnum : struct, Enum, IComparable;

        /// <summary>
        /// Override the default behaviour of converting <typeparamref name="TEnum"/> values to and from a different value type using the specified value converter. 
        /// </summary>
        /// <typeparam name="TEnum">The type of the enumeration.</typeparam>
        /// <typeparam name="TConverter">The custom converter that will convert data to and from the database.</param>
        IValueConverterFactoryContinuationConfigurationBuilder OverrideForEnumType<TEnum, TConverter>()
            where TEnum : struct, Enum, IComparable
            where TConverter : class, IValueConverter, new();

        /// <summary>
        /// Override the default behaviour of converting values to and from a different value type using the provided value converter. 
        /// </summary>
        /// <typeparam name="TValue">The type of the value that will be converted to another value type.</typeparam>
        /// <param name="converter">The custom converter that will convert <typeparamref name="TValue"/>(s).</param>
        IValueConverterFactoryContinuationConfigurationBuilder OverrideForType<TValue>(IValueConverter converter)
            where TValue : IComparable;

        /// <summary>
        /// Override the default behaviour of converting values to and from a different value type using the specified value converter. 
        /// </summary>
        /// <typeparam name="TValue">The type of the value that will be converted to another value type.</typeparam>
        /// <typeparam name="TConverter">The custom converter that will convert <typeparamref name="TValue"/>(s).</param>
        IValueConverterFactoryContinuationConfigurationBuilder OverrideForType<TValue, TConverter>()
            where TValue : IComparable
            where TConverter : class, IValueConverter, new();
    }
}
