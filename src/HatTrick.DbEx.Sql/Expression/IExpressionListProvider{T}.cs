using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface IExpressionListProvider<T>
        where T : IExpression
    {
        IList<T> Expressions { get; }
    }
}
