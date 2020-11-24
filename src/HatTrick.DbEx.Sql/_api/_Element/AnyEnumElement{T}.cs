using System;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface AnyEnumElement<TEnum> : AnyElement
#pragma warning restore IDE1006 // Naming Styles
        where TEnum : struct, Enum, IComparable
    {

    }
}
