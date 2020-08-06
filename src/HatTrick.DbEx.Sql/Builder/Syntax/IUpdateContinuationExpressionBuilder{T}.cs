using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IUpdateContinuationExpressionBuilder<T> : 
        IExpressionBuilder, 
        IUpdateTerminationExpressionBuilder<T>
        where T : class, IDbEntity
    {
        IUpdateContinuationExpressionBuilder<T> Where(FilterExpression expression);
        IUpdateContinuationExpressionBuilder<T> Where(FilterExpressionSet expression);
        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder<T>> InnerJoin(EntityExpression entity);
        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder<T>> LeftJoin(EntityExpression entity);
        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder<T>> RightJoin(EntityExpression entity);
        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder<T>> FullJoin(EntityExpression entity);
        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder<T>> CrossJoin(EntityExpression entity);
    }
}
