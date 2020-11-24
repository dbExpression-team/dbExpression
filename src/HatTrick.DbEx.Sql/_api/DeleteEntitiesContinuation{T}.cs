using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface DeleteEntitiesContinuation<TEntity> : DeleteEntitiesTermination<TEntity>
#pragma warning restore IDE1006 // Naming Styles
        where TEntity : class, IDbEntity
    {
        DeleteEntitiesContinuation<TEntity> Where(AnyWhereClause where);
        JoinOn<DeleteEntitiesContinuation<TEntity>> InnerJoin(AnyEntity entity);
        JoinOnWithAlias<DeleteEntitiesContinuation<TEntity>> InnerJoin(AnySelectSubquery subquery);
        JoinOn<DeleteEntitiesContinuation<TEntity>> LeftJoin(AnyEntity entity);
        JoinOnWithAlias<DeleteEntitiesContinuation<TEntity>> LeftJoin(AnySelectSubquery subquery);
        JoinOn<DeleteEntitiesContinuation<TEntity>> RightJoin(AnyEntity entity);
        JoinOnWithAlias<DeleteEntitiesContinuation<TEntity>> RightJoin(AnySelectSubquery subquery);
        JoinOn<DeleteEntitiesContinuation<TEntity>> FullJoin(AnyEntity entity);
        JoinOnWithAlias<DeleteEntitiesContinuation<TEntity>> FullJoin(AnySelectSubquery subquery);
        JoinOn<DeleteEntitiesContinuation<TEntity>> CrossJoin(AnyEntity entity);
    }
}
