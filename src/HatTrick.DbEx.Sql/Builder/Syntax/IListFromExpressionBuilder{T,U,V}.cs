using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IListFromExpressionBuilder<T, U, V> : IExpressionBuilder<T>
        where U : class, IContinuationExpressionBuilder<T>
        where V : class, IContinuationExpressionBuilder<T, U>
    {
        V From(EntityExpression entity);
        IFromExpressionBuilder<T, U, V> Distinct();
    }
}
