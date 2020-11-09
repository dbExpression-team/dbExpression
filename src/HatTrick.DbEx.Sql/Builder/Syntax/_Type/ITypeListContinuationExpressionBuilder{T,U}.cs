using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface ITypeListContinuationExpressionBuilder<T,U> : ITypeListContinuationExpressionBuilder<T>, IContinuationExpressionBuilder<T,U>
        where U : class, IContinuationExpressionBuilder<T>
    {
        ITypeListContinuationExpressionBuilder<T, U> Where(FilterExpressionSet expression);
        IJoinExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T, U>> InnerJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T, U>> LeftJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T, U>> RightJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T, U>> FullJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T, U>> CrossJoin(EntityExpression entity);
        IAliasRequiredJoinExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T, U>> InnerJoin(ISubqueryTerminationExpressionBuilder subquery);
        IAliasRequiredJoinExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T, U>> LeftJoin(ISubqueryTerminationExpressionBuilder subquery);
        IAliasRequiredJoinExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T, U>> RightJoin(ISubqueryTerminationExpressionBuilder subquery);
        IAliasRequiredJoinExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T, U>> FullJoin(ISubqueryTerminationExpressionBuilder subquery);
        ITypeListContinuationExpressionBuilder<T, U> OrderBy(params OrderByExpression[] orderBy);
        ITypeListContinuationExpressionBuilder<T, U> OrderBy(IEnumerable<OrderByExpression> orderBy);
        ITypeListContinuationExpressionBuilder<T, U> GroupBy(params GroupByExpression[] groupBy);
        ITypeListContinuationExpressionBuilder<T, U> GroupBy(IEnumerable<GroupByExpression> groupBy);
        ITypeListContinuationExpressionBuilder<T, U> Having(HavingExpression havingCondition);
        ITypeListSkipContinuationExpressionBuilder<T, U> Skip(int skipValue);
    }
}
