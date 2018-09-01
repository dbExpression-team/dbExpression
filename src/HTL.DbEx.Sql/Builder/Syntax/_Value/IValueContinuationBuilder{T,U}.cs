using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Builder.Syntax
{
    public interface IValueContinuationBuilder<T, U> : IValueContinuationBuilder<T>, IContinuationBuilder<T, U>
        where U : class, IContinuationBuilder<T>
    {
        IValueContinuationBuilder<T, U> Where(DBWhereExpression expression);
        IValueContinuationBuilder<T, U> Where(DBWhereExpressionSet expression);
        IJoinBuilder<T, IValueContinuationBuilder<T, U>> InnerJoin(DBExpressionEntity entity);
        IJoinBuilder<T, IValueContinuationBuilder<T, U>> LeftJoin(DBExpressionEntity entity);
        IJoinBuilder<T, IValueContinuationBuilder<T, U>> RightJoin(DBExpressionEntity entity);
        IJoinBuilder<T, IValueContinuationBuilder<T, U>> FullJoin(DBExpressionEntity entity);
        IJoinBuilder<T, IValueContinuationBuilder<T, U>> CrossJoin(DBExpressionEntity entity);
    }
}
