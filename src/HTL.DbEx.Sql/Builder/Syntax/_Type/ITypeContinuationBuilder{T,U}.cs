using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Builder.Syntax
{
    public interface ITypeContinuationBuilder<T, U> : ITypeContinuationBuilder<T>, IContinuationBuilder<T, U>
        where U : class, IContinuationBuilder<T>
    {
        ITypeContinuationBuilder<T, U> Where(DBWhereExpression expression);
        ITypeContinuationBuilder<T, U> Where(DBWhereExpressionSet expression);
        IJoinBuilder<T, ITypeContinuationBuilder<T, U>> InnerJoin(DBExpressionEntity entity);
        IJoinBuilder<T, ITypeContinuationBuilder<T, U>> LeftJoin(DBExpressionEntity entity);
        IJoinBuilder<T, ITypeContinuationBuilder<T, U>> RightJoin(DBExpressionEntity entity);
        IJoinBuilder<T, ITypeContinuationBuilder<T, U>> FullJoin(DBExpressionEntity entity);
        IJoinBuilder<T, ITypeContinuationBuilder<T, U>> CrossJoin(DBExpressionEntity entity);
    }
}
