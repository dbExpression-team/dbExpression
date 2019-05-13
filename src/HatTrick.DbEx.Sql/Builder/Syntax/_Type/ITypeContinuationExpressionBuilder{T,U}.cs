using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface ITypeContinuationBuilder<T, U> : ITypeContinuationExpressionBuilder<T>, IContinuationExpressionBuilder<T, U>
        where U : class, IContinuationExpressionBuilder<T>
    {
        ITypeContinuationBuilder<T, U> Where(FilterExpression expression);
        ITypeContinuationBuilder<T, U> Where(FilterExpressionSet expression);
        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> InnerJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> LeftJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> RightJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> FullJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> CrossJoin(EntityExpression entity);
        IAliasRequiredJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> InnerJoin(ISubqueryTerminationExpressionBuilder subquery);
        IAliasRequiredJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> LeftJoin(ISubqueryTerminationExpressionBuilder subquery);
        IAliasRequiredJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> RightJoin(ISubqueryTerminationExpressionBuilder subquery);
        IAliasRequiredJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> FullJoin(ISubqueryTerminationExpressionBuilder subquery);

    }
}
