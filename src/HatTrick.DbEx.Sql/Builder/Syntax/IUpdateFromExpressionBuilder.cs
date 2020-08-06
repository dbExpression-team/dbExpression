using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IUpdateFromExpressionBuilder :
        IExpressionBuilder,
        IContinuationExpressionBuilder
    {
        IUpdateContinuationExpressionBuilder<T> From<T>(EntityExpression<T> entity)
            where T: class, IDbEntity;
    }
}
