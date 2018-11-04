using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IDeleteContinuationExpressionBuilder :
        IExpressionBuilder,
        IContinuationExpressionBuilder, 
        ITerminationExpressionBuilder
    {
        IDeleteContinuationExpressionBuilder Where(FilterExpression filter);
        IDeleteContinuationExpressionBuilder Where(FilterExpressionSet filter);
        IJoinExpressionBuilder<IDeleteContinuationExpressionBuilder> InnerJoin(EntityExpression joinOn);
        IJoinExpressionBuilder<IDeleteContinuationExpressionBuilder> LeftJoin(EntityExpression joinOn);
        IJoinExpressionBuilder<IDeleteContinuationExpressionBuilder> RightJoin(EntityExpression joinOn);
        IJoinExpressionBuilder<IDeleteContinuationExpressionBuilder> FullJoin(EntityExpression entity);
        IJoinExpressionBuilder<IDeleteContinuationExpressionBuilder> CrossJoin(EntityExpression entity);
    }
}
