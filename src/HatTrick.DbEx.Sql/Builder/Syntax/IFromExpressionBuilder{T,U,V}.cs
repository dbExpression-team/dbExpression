using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IFromExpressionBuilder<T, U, V> : IExpressionBuilder<T>
        where U : class, IContinuationExpressionBuilder<T>
        where V : class, IContinuationExpressionBuilder<T, U>
    {
        V From(EntityExpression entity);
    }
}
