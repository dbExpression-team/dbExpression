using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class SelectEntityQueryExpressionBuilder<TEntity> : SelectQueryExpressionBuilder,
        IExpressionBuilder<TEntity>,
        SelectEntity<TEntity>,
        SelectEntityContinuation<TEntity>
        where TEntity : class, IDbEntity
    {
        #region constructors
        protected SelectEntityQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, SelectQueryExpression expression) : base(config, expression)
        {

        }
        #endregion

        #region methods
        SelectEntityContinuation<TEntity> SelectEntity<TEntity>.From(Entity<TEntity> entity)
        {
            From(entity, true);
            return this;
        }

        SelectEntityContinuation<TEntity> SelectEntityContinuation<TEntity>.OrderBy(params AnyOrderByClause[] orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        SelectEntityContinuation<TEntity> SelectEntityContinuation<TEntity>.OrderBy(IEnumerable<AnyOrderByClause> orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        SelectEntityContinuation<TEntity> SelectEntityContinuation<TEntity>.GroupBy(params AnyGroupByClause[] groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        SelectEntityContinuation<TEntity> SelectEntityContinuation<TEntity>.GroupBy(IEnumerable<AnyGroupByClause> groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        SelectEntityContinuation<TEntity> SelectEntityContinuation<TEntity>.Having(AnyHavingClause having)
        {
            Having(having);
            return this;
        }

        SelectEntityContinuation<TEntity> SelectEntityContinuation<TEntity>.Where(AnyWhereClause where)
        {
            Where(where);
            return this;
        }

        JoinOn<SelectEntityContinuation<TEntity>> SelectEntityContinuation<TEntity>.InnerJoin(AnyEntity entity)
            => new SelectEntityJoinBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.INNER, this);

        JoinOnWithAlias<SelectEntityContinuation<TEntity>> SelectEntityContinuation<TEntity>.InnerJoin(AnySelectSubquery subquery)
            => new SelectEntityJoinBuilder<TEntity>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.INNER, this);

        JoinOn<SelectEntityContinuation<TEntity>> SelectEntityContinuation<TEntity>.LeftJoin(AnyEntity entity)
            => new SelectEntityJoinBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.LEFT, this);

        JoinOnWithAlias<SelectEntityContinuation<TEntity>> SelectEntityContinuation<TEntity>.LeftJoin(AnySelectSubquery subquery)
            => new SelectEntityJoinBuilder<TEntity>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.LEFT, this);

        JoinOn<SelectEntityContinuation<TEntity>> SelectEntityContinuation<TEntity>.RightJoin(AnyEntity entity)
            => new SelectEntityJoinBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.RIGHT, this);

        JoinOnWithAlias<SelectEntityContinuation<TEntity>> SelectEntityContinuation<TEntity>.RightJoin(AnySelectSubquery subquery)
            => new SelectEntityJoinBuilder<TEntity>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.RIGHT, this);

        JoinOn<SelectEntityContinuation<TEntity>> SelectEntityContinuation<TEntity>.FullJoin(AnyEntity entity)
            => new SelectEntityJoinBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.FULL, this);

        JoinOnWithAlias<SelectEntityContinuation<TEntity>> SelectEntityContinuation<TEntity>.FullJoin(AnySelectSubquery subquery)
            => new SelectEntityJoinBuilder<TEntity>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.FULL, this);

        JoinOn<SelectEntityContinuation<TEntity>> SelectEntityContinuation<TEntity>.CrossJoin(AnyEntity entity)
            => new SelectEntityJoinBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.CROSS, this);
        #endregion
    }
}
