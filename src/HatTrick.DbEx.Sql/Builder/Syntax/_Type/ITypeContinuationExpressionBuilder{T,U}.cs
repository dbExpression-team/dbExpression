using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface ITypeContinuationExpressionBuilder<T, U> : ITypeContinuationExpressionBuilder<T>, IContinuationExpressionBuilder<T, U>
        where U : class, IContinuationExpressionBuilder<T>
    {
        ITypeContinuationExpressionBuilder<T, U> Where(FilterExpressionSet expression);
        IJoinExpressionBuilder<T, ITypeContinuationExpressionBuilder<T, U>> InnerJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, ITypeContinuationExpressionBuilder<T, U>> LeftJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, ITypeContinuationExpressionBuilder<T, U>> RightJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, ITypeContinuationExpressionBuilder<T, U>> FullJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, ITypeContinuationExpressionBuilder<T, U>> CrossJoin(EntityExpression entity);
        IAliasRequiredJoinExpressionBuilder<T, ITypeContinuationExpressionBuilder<T, U>> InnerJoin(ISubqueryTerminationExpressionBuilder subquery);
        IAliasRequiredJoinExpressionBuilder<T, ITypeContinuationExpressionBuilder<T, U>> LeftJoin(ISubqueryTerminationExpressionBuilder subquery);
        IAliasRequiredJoinExpressionBuilder<T, ITypeContinuationExpressionBuilder<T, U>> RightJoin(ISubqueryTerminationExpressionBuilder subquery);
        IAliasRequiredJoinExpressionBuilder<T, ITypeContinuationExpressionBuilder<T, U>> FullJoin(ISubqueryTerminationExpressionBuilder subquery);
        ITypeContinuationExpressionBuilder<T, U> OrderBy(params OrderByExpression[] orderBy);
        ITypeContinuationExpressionBuilder<T, U> OrderBy(IEnumerable<OrderByExpression> orderBy);
        ITypeContinuationExpressionBuilder<T, U> GroupBy(params GroupByExpression[] groupBy);
        ITypeContinuationExpressionBuilder<T, U> GroupBy(IEnumerable<GroupByExpression> groupBy);
        ITypeContinuationExpressionBuilder<T, U> Having(HavingExpression havingCondition);
    }
}
