using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface IDbExpressionSet<T> : IDbExpressionSet
        where T : class, IDbExpression
    {
        IList<T> Expressions { get; }
    }
}
