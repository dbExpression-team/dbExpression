using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface UpdateEntitiesContinuation<TEntity> : IUpdateTerminationExpressionBuilder<TEntity>
#pragma warning restore IDE1006 // Naming Styles
        where TEntity : class, IDbEntity
    {
        UpdateEntitiesContinuation<TEntity> Where(AnyWhereClause where);
        JoinOn<UpdateEntitiesContinuation<TEntity>> InnerJoin(AnyEntity entity);
        JoinOnWithAlias<UpdateEntitiesContinuation<TEntity>> InnerJoin(AnySelectSubquery subquery);
        JoinOn<UpdateEntitiesContinuation<TEntity>> LeftJoin(AnyEntity entity);
        JoinOnWithAlias<UpdateEntitiesContinuation<TEntity>> LeftJoin(AnySelectSubquery subquery);
        JoinOn<UpdateEntitiesContinuation<TEntity>> RightJoin(AnyEntity entity);
        JoinOnWithAlias<UpdateEntitiesContinuation<TEntity>> RightJoin(AnySelectSubquery subquery);
        JoinOn<UpdateEntitiesContinuation<TEntity>> FullJoin(AnyEntity entity);
        JoinOnWithAlias<UpdateEntitiesContinuation<TEntity>> FullJoin(AnySelectSubquery subquery);
        JoinOn<UpdateEntitiesContinuation<TEntity>> CrossJoin(AnyEntity entity);
    }
}
