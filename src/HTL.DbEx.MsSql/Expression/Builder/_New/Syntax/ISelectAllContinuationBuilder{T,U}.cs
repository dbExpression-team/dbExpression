using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression._New
{
    public interface ISelectAllContinuationBuilder<T,U> : ISelectAllContinuationBuilder<T>,
        IContinuationBuilder<T,U>
        where U : class, IContinuationBuilder<T>
    {
        ISelectAllContinuationBuilder<T, U> Distinct();
        ISelectAllContinuationBuilder<T, U> Where(DBFilterExpression expression);
        IJoinBuilder<T, ISelectAllContinuationBuilder<T, U>> InnerJoin(DBExpressionEntity entity);
        IJoinBuilder<T, ISelectAllContinuationBuilder<T, U>> LeftJoin(DBExpressionEntity entity);
        IJoinBuilder<T, ISelectAllContinuationBuilder<T, U>> RightJoin(DBExpressionEntity entity);
        IJoinBuilder<T, ISelectAllContinuationBuilder<T, U>> FullJoin(DBExpressionEntity entity);
        IJoinBuilder<T, ISelectAllContinuationBuilder<T, U>> CrossJoin(DBExpressionEntity entity);
        ISelectAllContinuationBuilder<T, U> OrderBy(DBOrderByExpressionSet orderBy);
        ISelectAllContinuationBuilder<T, U> GroupBy(params DBGroupByExpression[] groupBy);
        ISelectAllContinuationBuilder<T, U> Having(DBHavingExpression havingCondition);
        ISelectAllSkipContinuationBuilder<T, U> Skip(int skipValue);
        ISelectAllContinuationBuilder<T, U> Top(int count);
    }
}
