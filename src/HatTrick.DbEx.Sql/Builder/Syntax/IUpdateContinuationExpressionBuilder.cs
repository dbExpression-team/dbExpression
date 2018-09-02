using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IUpdateContinuationExpressionBuilder : IExpressionBuilder, ITerminationExpressionBuilder
    {
        IUpdateContinuationExpressionBuilder Where(WhereExpression expression);
        IUpdateContinuationExpressionBuilder Where(WhereExpressionSet expression);
        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder> InnerJoin(EntityExpression entity);
        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder> LeftJoin(EntityExpression entity);
        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder> RightJoin(EntityExpression entity);
        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder> FullJoin(EntityExpression entity);
        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder> CrossJoin(EntityExpression entity);
    }
}
