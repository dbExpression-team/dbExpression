using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectEntityContinuation<TEntity> :
#pragma warning restore IDE1006 // Naming Styles
        SelectEntityTermination<TEntity>
        where TEntity : class, IDbEntity
    {
        SelectEntityContinuation<TEntity> Where(AnyWhereClause where);
        SelectEntityContinuation<TEntity> OrderBy(params AnyOrderByClause[] orderBy);
        SelectEntityContinuation<TEntity> OrderBy(IEnumerable<AnyOrderByClause> orderBy);
        SelectEntityContinuation<TEntity> GroupBy(params AnyGroupByClause[] groupBy);
        SelectEntityContinuation<TEntity> GroupBy(IEnumerable<AnyGroupByClause> groupBy);
        SelectEntityContinuation<TEntity> Having(AnyHavingClause having);
        JoinOn<SelectEntityContinuation<TEntity>> InnerJoin(AnyEntity entity);
        JoinOnWithAlias<SelectEntityContinuation<TEntity>> InnerJoin(AnySelectSubquery subquery);
        JoinOn<SelectEntityContinuation<TEntity>> LeftJoin(AnyEntity entity);
        JoinOnWithAlias<SelectEntityContinuation<TEntity>> LeftJoin(AnySelectSubquery subquery);
        JoinOn<SelectEntityContinuation<TEntity>> RightJoin(AnyEntity entity);
        JoinOnWithAlias<SelectEntityContinuation<TEntity>> RightJoin(AnySelectSubquery subquery);
        JoinOn<SelectEntityContinuation<TEntity>> FullJoin(AnyEntity entity);
        JoinOnWithAlias<SelectEntityContinuation<TEntity>> FullJoin(AnySelectSubquery subquery);
        JoinOn<SelectEntityContinuation<TEntity>> CrossJoin(AnyEntity entity);
    }
}
