using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface IEnumExpressionMediator<TEnum>
        where TEnum : struct, Enum, IComparable
    {
    }
}
