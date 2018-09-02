using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IValueListContinuationExpressionBuilder<T,U> : IValueListContinuationBuilder<T>, IContinuationExpressionBuilder<T,U>
        where U : class, IContinuationExpressionBuilder<T>
    {
        IValueListContinuationExpressionBuilder<T, U> Where(WhereExpression expression);
        IValueListContinuationExpressionBuilder<T, U> Where(WhereExpressionSet expression);
        IJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> InnerJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> LeftJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> RightJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> FullJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> CrossJoin(EntityExpression entity);
        IValueListContinuationExpressionBuilder<T, U> OrderBy(OrderByExpressionSet orderBy);
        IValueListContinuationExpressionBuilder<T, U> OrderBy(params OrderByExpression[] orderBy);
        IValueListContinuationExpressionBuilder<T, U> GroupBy(params GroupByExpression[] groupBy);
        IValueListContinuationExpressionBuilder<T, U> Having(HavingExpression havingCondition);
        IValueListSkipContinuationExpressionBuilder<T, U> Skip(int skipValue);
        IValueListContinuationExpressionBuilder<T, U> Top(int count);
    }
}
