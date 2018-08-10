using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Builder.Syntax
{
    public interface ITypeListContinuationBuilder<T,U> : ITypeListContinuationBuilder<T>, IContinuationBuilder<T,U>
        where U : class, IContinuationBuilder<T>
    {
        ITypeListContinuationBuilder<T, U> Distinct();
        ITypeListContinuationBuilder<T, U> Where(DBFilterExpression expression);
        ITypeListContinuationBuilder<T, U> Where(DBFilterExpressionSet expression);
        IJoinBuilder<T, ITypeListContinuationBuilder<T, U>> InnerJoin(DBExpressionEntity entity);
        IJoinBuilder<T, ITypeListContinuationBuilder<T, U>> LeftJoin(DBExpressionEntity entity);
        IJoinBuilder<T, ITypeListContinuationBuilder<T, U>> RightJoin(DBExpressionEntity entity);
        IJoinBuilder<T, ITypeListContinuationBuilder<T, U>> FullJoin(DBExpressionEntity entity);
        IJoinBuilder<T, ITypeListContinuationBuilder<T, U>> CrossJoin(DBExpressionEntity entity);
        ITypeListContinuationBuilder<T, U> OrderBy(DBOrderByExpressionSet orderBy);
        ITypeListContinuationBuilder<T, U> OrderBy(params DBOrderByExpression[] orderBy);
        ITypeListContinuationBuilder<T, U> GroupBy(params DBGroupByExpression[] groupBy);
        ITypeListContinuationBuilder<T, U> Having(DBHavingExpression havingCondition);
        ITypeListSkipContinuationBuilder<T, U> Skip(int skipValue);
        ITypeListContinuationBuilder<T, U> Top(int count);
    }
}
