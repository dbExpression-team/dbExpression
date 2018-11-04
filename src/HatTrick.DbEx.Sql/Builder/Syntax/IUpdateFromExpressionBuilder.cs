using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IUpdateFromExpressionBuilder :
        IExpressionBuilder,
        IContinuationExpressionBuilder
    {
        IUpdateContinuationExpressionBuilder From(EntityExpression entity);
    }
}
