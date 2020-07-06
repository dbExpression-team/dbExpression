using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface IEnumExpressionMediator<TEnum> : IDbExpression
        where TEnum : struct, Enum, IComparable
    {
    }
}
