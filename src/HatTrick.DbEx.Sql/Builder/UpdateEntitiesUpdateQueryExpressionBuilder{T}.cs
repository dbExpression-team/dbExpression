using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class UpdateEntitiesUpdateQueryExpressionBuilder<TEntity> : UpdateQueryExpressionBuilder,
        IExpressionBuilder<TEntity>,
        UpdateEntities<TEntity>,
        UpdateEntitiesContinuation<TEntity>
        where TEntity : class, IDbEntity
    {
        #region internals
        protected TEntity Target { get; set; }
        protected TEntity Source { get; set; }
        #endregion

        #region constructors
        protected UpdateEntitiesUpdateQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, UpdateQueryExpression expression, EntityExpression<TEntity> entity) : base(config, expression, entity)
        {

        }

        protected UpdateEntitiesUpdateQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, UpdateQueryExpression expression, TEntity target, TEntity source)
            : base(configuration, expression)
        {
            Target = target ?? throw new ArgumentNullException($"{target} is required.");
            Source = source ?? throw new ArgumentNullException($"{source} is required.");
        }
        #endregion

        #region methods
        UpdateEntitiesContinuation<TEntity> UpdateEntitiesContinuation<TEntity>.Where(AnyWhereClause where)
        {
            Where(where);
            return this;
        }

        JoinOn<UpdateEntitiesContinuation<TEntity>> UpdateEntitiesContinuation<TEntity>.InnerJoin(AnyEntity entity)
            => new UpdateEntitiesJoinBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.INNER, this);

        JoinOnWithAlias<UpdateEntitiesContinuation<TEntity>> UpdateEntitiesContinuation<TEntity>.InnerJoin(AnySelectSubquery subquery)
            => new UpdateEntitiesJoinBuilder<TEntity>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.INNER, this);

        JoinOn<UpdateEntitiesContinuation<TEntity>> UpdateEntitiesContinuation<TEntity>.LeftJoin(AnyEntity entity)
            => new UpdateEntitiesJoinBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.LEFT, this);

        JoinOnWithAlias<UpdateEntitiesContinuation<TEntity>> UpdateEntitiesContinuation<TEntity>.LeftJoin(AnySelectSubquery subquery)
            => new UpdateEntitiesJoinBuilder<TEntity>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.LEFT, this);

        JoinOn<UpdateEntitiesContinuation<TEntity>> UpdateEntitiesContinuation<TEntity>.RightJoin(AnyEntity entity)
            => new UpdateEntitiesJoinBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.RIGHT, this);

        JoinOnWithAlias<UpdateEntitiesContinuation<TEntity>> UpdateEntitiesContinuation<TEntity>.RightJoin(AnySelectSubquery subquery)
            => new UpdateEntitiesJoinBuilder<TEntity>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.RIGHT, this);

        JoinOn<UpdateEntitiesContinuation<TEntity>> UpdateEntitiesContinuation<TEntity>.FullJoin(AnyEntity entity)
            => new UpdateEntitiesJoinBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.FULL, this);

        JoinOnWithAlias<UpdateEntitiesContinuation<TEntity>> UpdateEntitiesContinuation<TEntity>.FullJoin(AnySelectSubquery subquery)
            => new UpdateEntitiesJoinBuilder<TEntity>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.FULL, this);

        JoinOn<UpdateEntitiesContinuation<TEntity>> UpdateEntitiesContinuation<TEntity>.CrossJoin(AnyEntity entity)
            => new UpdateEntitiesJoinBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.CROSS, this);

        UpdateEntities<TEntity> UpdateEntities<TEntity>.Top(int value)
        {
            Expression.Top = value;
            return this;
        }

        UpdateEntitiesContinuation<TEntity> UpdateEntities<TEntity>.From(Entity<TEntity> entity)
        {
            var builder = CreateTypedBuilder(Configuration, Expression, entity as EntityExpression<TEntity> ?? throw new DbExpressionException($"Expected {nameof(entity)} to be of type {nameof(EntityExpression<TEntity>)}."));
            Expression.Assign = entity.BuildAssignmentExpression(Target, Source);
            return builder;
        }
        #endregion
    }
}
