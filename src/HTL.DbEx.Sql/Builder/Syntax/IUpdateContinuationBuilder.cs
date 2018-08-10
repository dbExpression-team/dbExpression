using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Builder.Syntax
{
    public interface IUpdateContinuationBuilder : IBuilder, ITerminationBuilder
    {
        IUpdateContinuationBuilder Where(DBFilterExpressionSet expression);
        IJoinBuilder<IUpdateContinuationBuilder> InnerJoin(DBExpressionEntity entity);
        IJoinBuilder<IUpdateContinuationBuilder> LeftJoin(DBExpressionEntity entity);
        IJoinBuilder<IUpdateContinuationBuilder> RightJoin(DBExpressionEntity entity);
        IJoinBuilder<IUpdateContinuationBuilder> FullJoin(DBExpressionEntity entity);
        IJoinBuilder<IUpdateContinuationBuilder> CrossJoin(DBExpressionEntity entity);
    }
}
