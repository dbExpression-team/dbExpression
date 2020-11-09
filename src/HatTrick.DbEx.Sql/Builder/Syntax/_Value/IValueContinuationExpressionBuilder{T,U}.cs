using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IValueContinuationExpressionBuilder<T, U> :
        IExpressionBuilder<T>,
        IValueContinuationExpressionBuilder<T>, 
        IContinuationExpressionBuilder<T, U>
        where U : class, IContinuationExpressionBuilder<T>
    {
        IValueContinuationExpressionBuilder<T, U> Where(FilterExpressionSet expression);
        IJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> InnerJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> LeftJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> RightJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> FullJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> CrossJoin(EntityExpression entity);
        IAliasRequiredJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> InnerJoin(ISubqueryTerminationExpressionBuilder subquery);
        IAliasRequiredJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> LeftJoin(ISubqueryTerminationExpressionBuilder subquery);
        IAliasRequiredJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> RightJoin(ISubqueryTerminationExpressionBuilder subquery);
        IAliasRequiredJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> FullJoin(ISubqueryTerminationExpressionBuilder subquery);
        IValueContinuationExpressionBuilder<T, U> OrderBy(params OrderByExpression[] orderBy);
        IValueContinuationExpressionBuilder<T, U> OrderBy(IEnumerable<OrderByExpression> orderBy);
        IValueContinuationExpressionBuilder<T, U> GroupBy(params GroupByExpression[] groupBy);
        IValueContinuationExpressionBuilder<T, U> GroupBy(IEnumerable<GroupByExpression> groupBy);
        IValueContinuationExpressionBuilder<T, U> Having(HavingExpression havingCondition);
    }
}
