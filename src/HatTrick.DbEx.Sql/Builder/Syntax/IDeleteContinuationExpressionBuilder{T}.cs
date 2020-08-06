using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IDeleteContinuationExpressionBuilder<T> :
        IExpressionBuilder,
        IContinuationExpressionBuilder, 
        IDeleteTerminationExpressionBuilder<T>
        where T : class, IDbEntity
    {
        IDeleteContinuationExpressionBuilder<T> Where(FilterExpression filter);
        IDeleteContinuationExpressionBuilder<T> Where(FilterExpressionSet filter);
        IJoinExpressionBuilder<IDeleteContinuationExpressionBuilder<T>> InnerJoin(EntityExpression joinOn);
        IJoinExpressionBuilder<IDeleteContinuationExpressionBuilder<T>> LeftJoin(EntityExpression joinOn);
        IJoinExpressionBuilder<IDeleteContinuationExpressionBuilder<T>> RightJoin(EntityExpression joinOn);
        IJoinExpressionBuilder<IDeleteContinuationExpressionBuilder<T>> FullJoin(EntityExpression entity);
        IJoinExpressionBuilder<IDeleteContinuationExpressionBuilder<T>> CrossJoin(EntityExpression entity);
    }
}
