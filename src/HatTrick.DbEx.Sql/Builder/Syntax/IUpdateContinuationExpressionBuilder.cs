using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IUpdateContinuationExpressionBuilder : 
        IExpressionBuilder, 
        ITerminationExpressionBuilder
    {
        IUpdateContinuationExpressionBuilder Where(FilterExpression expression);
        IUpdateContinuationExpressionBuilder Where(FilterExpressionSet expression);
        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder> InnerJoin(EntityExpression entity);
        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder> LeftJoin(EntityExpression entity);
        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder> RightJoin(EntityExpression entity);
        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder> FullJoin(EntityExpression entity);
        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder> CrossJoin(EntityExpression entity);
    }
}
