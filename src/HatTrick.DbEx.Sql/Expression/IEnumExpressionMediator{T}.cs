using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface IEnumExpressionMediator<TEnum> : IExpression
        where TEnum : struct, Enum, IComparable
    {
    }
}
