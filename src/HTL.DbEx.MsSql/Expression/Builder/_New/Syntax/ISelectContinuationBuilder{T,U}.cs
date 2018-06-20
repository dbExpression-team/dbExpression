using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression._New
{
    public interface ISelectContinuationBuilder<T, U> : ISelectContinuationBuilder<T>, 
        IContinuationBuilder<T, U>
        where U : class, IContinuationBuilder<T>
    {
        ISelectContinuationBuilder<T, U> Where(DBFilterExpression expression);
        IJoinBuilder<T, ISelectContinuationBuilder<T, U>> InnerJoin(DBExpressionEntity entity);
        IJoinBuilder<T, ISelectContinuationBuilder<T, U>> LeftJoin(DBExpressionEntity entity);
        IJoinBuilder<T, ISelectContinuationBuilder<T, U>> RightJoin(DBExpressionEntity entity);
        IJoinBuilder<T, ISelectContinuationBuilder<T, U>> FullJoin(DBExpressionEntity entity);
        IJoinBuilder<T, ISelectContinuationBuilder<T, U>> CrossJoin(DBExpressionEntity entity);
    }
}
