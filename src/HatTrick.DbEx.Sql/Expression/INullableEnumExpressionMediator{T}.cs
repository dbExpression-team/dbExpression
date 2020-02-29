using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface INullableEnumExpressionMediator<TEnum>
        where TEnum : struct, Enum, IComparable
    {
    }
}
