using System;

namespace HatTrick.DbEx.Sql.Expression
{
#pragma warning disable IDE1006 // Naming Styles
    public interface NullEnumElement<TEnum> : AnyNullElement
#pragma warning restore IDE1006 // Naming Styles
        where TEnum : struct, Enum, IComparable
    {
        NullEnumElement<TEnum> As(string alias);
    }
}
