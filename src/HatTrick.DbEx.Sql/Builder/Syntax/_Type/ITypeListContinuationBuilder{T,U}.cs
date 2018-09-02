using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface ITypeListContinuationBuilder<T,U> : ITypeListContinuationBuilder<T>, IContinuationExpressionBuilder<T,U>
        where U : class, IContinuationExpressionBuilder<T>
    {
        ITypeListContinuationBuilder<T, U> Where(WhereExpression expression);
        ITypeListContinuationBuilder<T, U> Where(WhereExpressionSet expression);
        IJoinExpressionBuilder<T, ITypeListContinuationBuilder<T, U>> InnerJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, ITypeListContinuationBuilder<T, U>> LeftJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, ITypeListContinuationBuilder<T, U>> RightJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, ITypeListContinuationBuilder<T, U>> FullJoin(EntityExpression entity);
        IJoinExpressionBuilder<T, ITypeListContinuationBuilder<T, U>> CrossJoin(EntityExpression entity);
        ITypeListContinuationBuilder<T, U> OrderBy(OrderByExpressionSet orderBy);
        ITypeListContinuationBuilder<T, U> OrderBy(params OrderByExpression[] orderBy);
        ITypeListContinuationBuilder<T, U> GroupBy(params GroupByExpression[] groupBy);
        ITypeListContinuationBuilder<T, U> Having(HavingExpression havingCondition);
        ITypeListSkipContinuationBuilder<T, U> Skip(int skipValue);
        ITypeListContinuationBuilder<T, U> Top(int count);
    }
}
