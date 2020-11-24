using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class SelectEntitiesSelectQueryExpressionBuilder<TEntity> : SelectQueryExpressionBuilder,
        IExpressionBuilder<TEntity>,
        SelectEntities<TEntity>,
        SelectEntitiesContinuation<TEntity>,
        SelectEntitiesSkipContinuation<TEntity>,
        SelectEntitiesOrderByContinuation<TEntity>
        where TEntity : class, IDbEntity
    {
        #region constructors
        protected SelectEntitiesSelectQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, SelectQueryExpression expression) : base(config, expression)
        {

        }
        #endregion

        #region methods
        SelectEntities<TEntity> SelectEntities<TEntity>.Top(int value)
        {
            Top(value);
            return this;
        }

        SelectEntities<TEntity> SelectEntities<TEntity>.Distinct()
        {
            Distinct();
            return this;
        }

        SelectEntitiesContinuation<TEntity> SelectEntities<TEntity>.From(Entity<TEntity> entity)
        {
            From(entity, true);
            return this;
        }

        SelectEntitiesOrderByContinuation<TEntity> SelectEntitiesContinuation<TEntity>.OrderBy(params AnyOrderByClause[] orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        SelectEntitiesOrderByContinuation<TEntity> SelectEntitiesContinuation<TEntity>.OrderBy(IEnumerable<AnyOrderByClause> orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        SelectEntitiesContinuation<TEntity> SelectEntitiesContinuation<TEntity>.GroupBy(params AnyGroupByClause[] groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        SelectEntitiesContinuation<TEntity> SelectEntitiesContinuation<TEntity>.GroupBy(IEnumerable<AnyGroupByClause> groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        SelectEntitiesContinuation<TEntity> SelectEntitiesContinuation<TEntity>.Having(AnyHavingClause having)
        {
            Having(having);
            return this;
        }

        SelectEntitiesContinuation<TEntity> SelectEntitiesContinuation<TEntity>.Where(AnyWhereClause where)
        {
            Where(where);
            return this;
        }

        JoinOn<SelectEntitiesContinuation<TEntity>> SelectEntitiesContinuation<TEntity>.InnerJoin(AnyEntity entity)
            => new SelectEntitiesJoinExpressionBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.INNER, this);

        JoinOnWithAlias<SelectEntitiesContinuation<TEntity>> SelectEntitiesContinuation<TEntity>.InnerJoin(AnySelectSubquery subquery)
            => new SelectEntitiesJoinExpressionBuilder<TEntity>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.INNER, this);

        JoinOn<SelectEntitiesContinuation<TEntity>> SelectEntitiesContinuation<TEntity>.LeftJoin(AnyEntity entity)
            => new SelectEntitiesJoinExpressionBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.LEFT, this);

        JoinOnWithAlias<SelectEntitiesContinuation<TEntity>> SelectEntitiesContinuation<TEntity>.LeftJoin(AnySelectSubquery subquery)
            => new SelectEntitiesJoinExpressionBuilder<TEntity>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.LEFT, this);

        JoinOn<SelectEntitiesContinuation<TEntity>> SelectEntitiesContinuation<TEntity>.RightJoin(AnyEntity entity)
            => new SelectEntitiesJoinExpressionBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.RIGHT, this);

        JoinOnWithAlias<SelectEntitiesContinuation<TEntity>> SelectEntitiesContinuation<TEntity>.RightJoin(AnySelectSubquery subquery)
            => new SelectEntitiesJoinExpressionBuilder<TEntity>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.RIGHT, this);

        JoinOn<SelectEntitiesContinuation<TEntity>> SelectEntitiesContinuation<TEntity>.FullJoin(AnyEntity entity)
            => new SelectEntitiesJoinExpressionBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.FULL, this);

        JoinOnWithAlias<SelectEntitiesContinuation<TEntity>> SelectEntitiesContinuation<TEntity>.FullJoin(AnySelectSubquery subquery)
            => new SelectEntitiesJoinExpressionBuilder<TEntity>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.FULL, this);

        JoinOn<SelectEntitiesContinuation<TEntity>> SelectEntitiesContinuation<TEntity>.CrossJoin(AnyEntity entity)
            => new SelectEntitiesJoinExpressionBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.CROSS, this);

        SelectEntitiesSkipContinuation<TEntity> SelectEntitiesOrderByContinuation<TEntity>.Skip(int value)
        {
            Skip(value);
            return this;
        }

        SelectEntitiesOrderByContinuation<TEntity> Limit<SelectEntitiesOrderByContinuation<TEntity>>.Limit(int value)
        {
            Limit(value);
            return this;
        }

        SelectEntitiesOrderByContinuation<TEntity> SelectEntitiesOrderByContinuation<TEntity>.GroupBy(params AnyGroupByClause[] groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        SelectEntitiesOrderByContinuation<TEntity> SelectEntitiesOrderByContinuation<TEntity>.GroupBy(IEnumerable<AnyGroupByClause> groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        SelectEntitiesOrderByContinuation<TEntity> SelectEntitiesOrderByContinuation<TEntity>.Having(AnyHavingClause having)
        {
            Having(having);
            return this;
        }

        SelectEntitiesOrderByContinuation<TEntity> Limit<SelectEntitiesOrderByContinuation<TEntity>>.Having(AnyHavingClause having)
        {
            Having(having);
            return this;
        }
        #endregion
    }
}
