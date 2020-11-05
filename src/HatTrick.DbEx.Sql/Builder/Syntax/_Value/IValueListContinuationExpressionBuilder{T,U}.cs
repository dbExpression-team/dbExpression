using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IValueListContinuationExpressionBuilder<T,U> :
        IExpressionBuilder<T>,
        IValueListContinuationExpressionBuilder<T>, 
        IContinuationExpressionBuilder<T,U>
        where U : class, IContinuationExpressionBuilder<T>
    {
        IValueListContinuationExpressionBuilder<T, U> Where(FilterExpression expression);
        IValueListContinuationExpressionBuilder<T, U> Where(FilterExpressionSet expression);
        IJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> InnerJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> LeftJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> RightJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> FullJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> CrossJoin(EntityExpression entity);
        IAliasRequiredJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> InnerJoin(ISubqueryTerminationExpressionBuilder subquery);
        IAliasRequiredJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> LeftJoin(ISubqueryTerminationExpressionBuilder subquery);
        IAliasRequiredJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> RightJoin(ISubqueryTerminationExpressionBuilder subquery);
        IAliasRequiredJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> FullJoin(ISubqueryTerminationExpressionBuilder subquery);
        IValueListContinuationExpressionBuilder<T, U> OrderBy(params OrderByExpression[] orderBy);
        IValueListContinuationExpressionBuilder<T, U> OrderBy(IEnumerable<OrderByExpression> orderBy);
        IValueListContinuationExpressionBuilder<T, U> GroupBy(params GroupByExpression[] groupBy);
        IValueListContinuationExpressionBuilder<T, U> Having(HavingExpression havingCondition);
        IValueListSkipContinuationExpressionBuilder<T, U> Skip(int skipValue);
    }
}
