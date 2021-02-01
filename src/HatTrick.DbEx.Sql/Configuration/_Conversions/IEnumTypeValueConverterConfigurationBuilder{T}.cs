using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IEnumTypeValueConverterConfigurationBuilder<TEnum>
        where TEnum : struct, Enum, IComparable
    {
        /// <summary>
        /// Persist enumeration values as strings in the target database.
        /// </summary>
        IValueConverterFactoryContinuationConfigurationBuilder PersistAsString();
    }
}
