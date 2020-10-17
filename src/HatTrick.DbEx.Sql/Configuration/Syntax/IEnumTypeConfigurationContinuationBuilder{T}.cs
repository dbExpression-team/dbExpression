using System;

namespace HatTrick.DbEx.Sql.Configuration.Syntax
{
    public interface IEnumTypeConfigurationContinuationBuilder<T> : ITypeConfigurationContinuationBuilder<T>
        where T : struct, IComparable
    {
        IEnumTypeConfigurationContinuationBuilder<T> PersistTheEnumValueAsString();
    }
}
