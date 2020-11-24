using System.Collections.Generic;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectEntitiesContinuation<TEntity> : SelectEntitiesTermination<TEntity>
#pragma warning restore IDE1006 // Naming Styles
        where TEntity : class, IDbEntity
    {
        SelectEntitiesContinuation<TEntity> Where(AnyWhereClause where);
        SelectEntitiesOrderByContinuation<TEntity> OrderBy(params AnyOrderByClause[] orderBy);
        SelectEntitiesOrderByContinuation<TEntity> OrderBy(IEnumerable<AnyOrderByClause> orderBy);
        SelectEntitiesContinuation<TEntity> GroupBy(params AnyGroupByClause[] groupBy);
        SelectEntitiesContinuation<TEntity> GroupBy(IEnumerable<AnyGroupByClause> groupBy);
        SelectEntitiesContinuation<TEntity> Having(AnyHavingClause having);
        JoinOn<SelectEntitiesContinuation<TEntity>> InnerJoin(AnyEntity entity);
        JoinOnWithAlias<SelectEntitiesContinuation<TEntity>> InnerJoin(AnySelectSubquery subquery);
        JoinOn<SelectEntitiesContinuation<TEntity>> LeftJoin(AnyEntity entity);
        JoinOnWithAlias<SelectEntitiesContinuation<TEntity>> LeftJoin(AnySelectSubquery subquery);
        JoinOn<SelectEntitiesContinuation<TEntity>> RightJoin(AnyEntity entity);
        JoinOnWithAlias<SelectEntitiesContinuation<TEntity>> RightJoin(AnySelectSubquery subquery);
        JoinOn<SelectEntitiesContinuation<TEntity>> FullJoin(AnyEntity entity);
        JoinOnWithAlias<SelectEntitiesContinuation<TEntity>> FullJoin(AnySelectSubquery subquery);
        JoinOn<SelectEntitiesContinuation<TEntity>> CrossJoin(AnyEntity entity);
    }
}
