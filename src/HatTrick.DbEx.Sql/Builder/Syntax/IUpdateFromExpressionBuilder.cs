using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IUpdateFromExpressionBuilder : IContinuationExpressionBuilder
    {
        IUpdateContinuationExpressionBuilder From(EntityExpression entity);
    }
}
