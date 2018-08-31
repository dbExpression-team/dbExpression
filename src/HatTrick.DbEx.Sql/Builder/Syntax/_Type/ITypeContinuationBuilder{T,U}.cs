using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface ITypeContinuationBuilder<T, U> : ITypeContinuationBuilder<T>, IContinuationExpressionBuilder<T, U>
        where U : class, IContinuationExpressionBuilder<T>
    {
        ITypeContinuationBuilder<T, U> Where(WhereExpression expression);
        ITypeContinuationBuilder<T, U> Where(WhereExpressionSet expression);
        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> InnerJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> LeftJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> RightJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> FullJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> CrossJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> InnerJoin(ISubqueryTerminationExpressionBuilder subquery);
        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> LeftJoin(ISubqueryTerminationExpressionBuilder subquery);
        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> RightJoin(ISubqueryTerminationExpressionBuilder subquery);
        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> FullJoin(ISubqueryTerminationExpressionBuilder subquery);

    }
}
