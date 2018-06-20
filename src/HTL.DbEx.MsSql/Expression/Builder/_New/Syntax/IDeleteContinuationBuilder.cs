using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression._New
{
    public interface IDeleteContinuationBuilder : IContinuationBuilder
    {
        IDeleteContinuationBuilder Where(DBFilterExpressionSet filter);
        IJoinBuilder<IDeleteContinuationBuilder> InnerJoin(DBExpressionEntity joinOn);
        IJoinBuilder<IDeleteContinuationBuilder> LeftJoin(DBExpressionEntity joinOn);
        IJoinBuilder<IDeleteContinuationBuilder> RightJoin(DBExpressionEntity joinOn);
        IJoinBuilder<IDeleteContinuationBuilder> FullJoin(DBExpressionEntity entity);
        IJoinBuilder<IDeleteContinuationBuilder> CrossJoin(DBExpressionEntity entity);
    }
}
