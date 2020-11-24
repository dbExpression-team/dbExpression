using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class DeleteEntitiesDeleteQueryExpressionBuilder<TEntity> : DeleteQueryExpressionBuilder,
        IExpressionBuilder<TEntity>,
        DeleteEntitiesContinuation<TEntity>
        where TEntity : class, IDbEntity
    {
        #region constructors
        protected DeleteEntitiesDeleteQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, DeleteQueryExpression expression, EntityExpression<TEntity> entity) : base(config, expression, entity)
        {

        }
        #endregion

        #region methods
        DeleteEntitiesContinuation<TEntity> DeleteEntitiesContinuation<TEntity>.Where(AnyWhereClause where)
        {
            Where(where);
            return this;
        }

        JoinOn<DeleteEntitiesContinuation<TEntity>> DeleteEntitiesContinuation<TEntity>.InnerJoin(AnyEntity entity)
            => new DeleteEntitiesJoinExpressionBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.INNER, this);

        JoinOnWithAlias<DeleteEntitiesContinuation<TEntity>> DeleteEntitiesContinuation<TEntity>.InnerJoin(AnySelectSubquery subquery)
            => new DeleteEntitiesJoinExpressionBuilder<TEntity>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.INNER, this);

        JoinOn<DeleteEntitiesContinuation<TEntity>> DeleteEntitiesContinuation<TEntity>.LeftJoin(AnyEntity entity)
            => new DeleteEntitiesJoinExpressionBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.LEFT, this);

        JoinOnWithAlias<DeleteEntitiesContinuation<TEntity>> DeleteEntitiesContinuation<TEntity>.LeftJoin(AnySelectSubquery subquery)
            => new DeleteEntitiesJoinExpressionBuilder<TEntity>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.LEFT, this);

        JoinOn<DeleteEntitiesContinuation<TEntity>> DeleteEntitiesContinuation<TEntity>.RightJoin(AnyEntity entity)
            => new DeleteEntitiesJoinExpressionBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.RIGHT, this);

        JoinOnWithAlias<DeleteEntitiesContinuation<TEntity>> DeleteEntitiesContinuation<TEntity>.RightJoin(AnySelectSubquery subquery)
            => new DeleteEntitiesJoinExpressionBuilder<TEntity>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.RIGHT, this);

        JoinOn<DeleteEntitiesContinuation<TEntity>> DeleteEntitiesContinuation<TEntity>.FullJoin(AnyEntity entity)
            => new DeleteEntitiesJoinExpressionBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.FULL, this);

        JoinOnWithAlias<DeleteEntitiesContinuation<TEntity>> DeleteEntitiesContinuation<TEntity>.FullJoin(AnySelectSubquery subquery)
            => new DeleteEntitiesJoinExpressionBuilder<TEntity>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.FULL, this);

        JoinOn<DeleteEntitiesContinuation<TEntity>> DeleteEntitiesContinuation<TEntity>.CrossJoin(AnyEntity entity)
            => new DeleteEntitiesJoinExpressionBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.CROSS, this);
        #endregion
    }
}
