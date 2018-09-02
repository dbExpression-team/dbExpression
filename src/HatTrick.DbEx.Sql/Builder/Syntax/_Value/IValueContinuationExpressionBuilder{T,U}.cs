using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IValueContinuationExpressionBuilder<T, U> : IValueContinuationExpressionBuilder<T>, IContinuationExpressionBuilder<T, U>
        where U : class, IContinuationExpressionBuilder<T>
    {
        IValueContinuationExpressionBuilder<T, U> Where(WhereExpression expression);
        IValueContinuationExpressionBuilder<T, U> Where(WhereExpressionSet expression);
        IJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> InnerJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> LeftJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> RightJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> FullJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> CrossJoin(EntityExpression entity);
    }
}
