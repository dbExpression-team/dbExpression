using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface INullableEnumExpressionMediator<TEnum> : IExpression
        where TEnum : struct, Enum, IComparable
    {
    }
}
