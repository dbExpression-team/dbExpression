using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IUpdateFromExpressionBuilder<T> :
        IExpressionBuilder,
        IContinuationExpressionBuilder
        where T : class, IDbEntity
    {
        IUpdateContinuationExpressionBuilder<T> From(EntityExpression<T> entity);
    }
}
