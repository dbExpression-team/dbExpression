using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IDeleteFromExpressionBuilder : 
        IExpressionBuilder
    {
        IDeleteContinuationExpressionBuilder From(EntityExpression entity);
    }
}
