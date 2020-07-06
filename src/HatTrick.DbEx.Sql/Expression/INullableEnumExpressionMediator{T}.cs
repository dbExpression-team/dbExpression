using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface INullableEnumExpressionMediator<TEnum> : IDbExpression
        where TEnum : struct, Enum, IComparable
    {
    }
}
