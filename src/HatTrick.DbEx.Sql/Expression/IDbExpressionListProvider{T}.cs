using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface IDbExpressionListProvider<T>
        where T : IDbExpression
    {
        IList<T> Expressions { get; }
    }
}
