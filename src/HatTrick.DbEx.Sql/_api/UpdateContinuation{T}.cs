using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
    public interface UpdateContinuation<T> : 
        UpdateTermination<T>
        where T : class, IDbEntity
    {
        UpdateContinuation<T> Where(FilterExpression expression);
        UpdateContinuation<T> Where(FilterExpressionSet expression);
        JoinOn<UpdateContinuation<T>> InnerJoin(EntityExpression entity);
        JoinOn<UpdateContinuation<T>> LeftJoin(EntityExpression entity);
        JoinOn<UpdateContinuation<T>> RightJoin(EntityExpression entity);
        JoinOn<UpdateContinuation<T>> FullJoin(EntityExpression entity);
        JoinOn<UpdateContinuation<T>> CrossJoin(EntityExpression entity);
    }
}
