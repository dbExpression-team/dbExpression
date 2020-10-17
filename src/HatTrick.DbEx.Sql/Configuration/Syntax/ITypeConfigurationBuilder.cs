using System;

namespace HatTrick.DbEx.Sql.Configuration.Syntax
{
    public interface ITypeConfigurationBuilder
    {
        ITypeConfigurationContinuationBuilder<T> ForType<T>()
            where T : IComparable;

        IEnumTypeConfigurationContinuationBuilder<T> ForEnumType<T>()
            where T : struct, Enum, IComparable;
    }
}
