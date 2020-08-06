using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class UpdateSqlExpressionBuilder : SqlExpressionBuilder,
        IUpdateFromExpressionBuilder
    {
        #region constructors
        protected UpdateSqlExpressionBuilder(DatabaseConfiguration configuration, UpdateQueryExpression expression) : base(configuration, expression)
        {

        }

        protected UpdateSqlExpressionBuilder(DatabaseConfiguration configuration, UpdateQueryExpression expression, EntityExpression entity) : base(configuration, expression)
        {
            Expression.BaseEntity = entity;
        }
        #endregion

        IUpdateContinuationExpressionBuilder<T> IUpdateFromExpressionBuilder.From<T>(EntityExpression<T> entity)
        {
            return CreateTypedBuilder(Configuration, Expression as UpdateQueryExpression, entity);
        }

        protected abstract IUpdateContinuationExpressionBuilder<T> CreateTypedBuilder<T>(DatabaseConfiguration configuration, UpdateQueryExpression expression, EntityExpression<T> entity) where T : class, IDbEntity;
    }

    public abstract class UpdateSqlExpressionBuilder<T> : UpdateSqlExpressionBuilder,
        IUpdateInitiationExpressionBuilder,
        IUpdateContinuationExpressionBuilder<T>
        where T : class, IDbEntity
    {
        protected UpdateSqlExpressionBuilder(DatabaseConfiguration configuration, UpdateQueryExpression expression, EntityExpression<T> entity)
            : base(configuration, expression, entity)
        {

        }

        #region methods
        IUpdateFromExpressionBuilder IUpdateInitiationExpressionBuilder.Update(AssignmentExpression[] assignments)
        {
            if (!(Expression is UpdateQueryExpression update))
                throw new DbExpressionException($"Expected {nameof(Expression)} to be of type {nameof(UpdateQueryExpression)}, but is actually type {Expression.GetType()}");
            foreach (var assignment in assignments)
                update.Assign &= assignment;
            return this;
        }

        IUpdateContinuationExpressionBuilder<T> IUpdateContinuationExpressionBuilder<T>.Where(FilterExpression filter)
        {
            return Where<IUpdateContinuationExpressionBuilder<T>>(filter);
        }

        IUpdateContinuationExpressionBuilder<T> IUpdateContinuationExpressionBuilder<T>.Where(FilterExpressionSet filter)
        {
            return Where<IUpdateContinuationExpressionBuilder<T>>(filter);
        }

        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder<T>> IUpdateContinuationExpressionBuilder<T>.InnerJoin(EntityExpression entity)
        {
            return Join<IUpdateContinuationExpressionBuilder<T>>(entity, JoinOperationExpressionOperator.INNER);
        }

        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder<T>> IUpdateContinuationExpressionBuilder<T>.LeftJoin(EntityExpression entity)
        {
            return Join<IUpdateContinuationExpressionBuilder<T>>(entity, JoinOperationExpressionOperator.LEFT);
        }

        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder<T>> IUpdateContinuationExpressionBuilder<T>.RightJoin(EntityExpression entity)
        {
            return Join<IUpdateContinuationExpressionBuilder<T>>(entity, JoinOperationExpressionOperator.RIGHT);
        }

        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder<T>> IUpdateContinuationExpressionBuilder<T>.FullJoin(EntityExpression entity)
        {
            return Join<IUpdateContinuationExpressionBuilder<T>>(entity, JoinOperationExpressionOperator.FULL);
        }

        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder<T>> IUpdateContinuationExpressionBuilder<T>.CrossJoin(EntityExpression entity)
        {
            return Join<IUpdateContinuationExpressionBuilder<T>>(entity, JoinOperationExpressionOperator.CROSS);
        }
        #endregion
    }
}
