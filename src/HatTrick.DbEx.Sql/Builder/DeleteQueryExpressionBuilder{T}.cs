using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class DeleteQueryExpressionBuilder<T> : DeleteQueryExpressionBuilder,
            IDeleteContinuationExpressionBuilder<T>
            where T : class, IDbEntity
    {
        protected DeleteQueryExpressionBuilder(DatabaseConfiguration configuration, DeleteQueryExpression expression, EntityExpression<T> entity)
            : base(configuration, expression, entity)
        {

        }

        #region methods
        IDeleteContinuationExpressionBuilder<T> IDeleteContinuationExpressionBuilder<T>.Where(FilterExpression filter)
        {
            return Where<IDeleteContinuationExpressionBuilder<T>>(filter);
        }

        IDeleteContinuationExpressionBuilder<T> IDeleteContinuationExpressionBuilder<T>.Where(FilterExpressionSet filter)
        {
            return Where<IDeleteContinuationExpressionBuilder<T>>(filter);
        }

        IJoinExpressionBuilder<IDeleteContinuationExpressionBuilder<T>> IDeleteContinuationExpressionBuilder<T>.InnerJoin(EntityExpression entity)
        {
            return Join<IDeleteContinuationExpressionBuilder<T>>(entity, JoinOperationExpressionOperator.INNER);
        }

        IJoinExpressionBuilder<IDeleteContinuationExpressionBuilder<T>> IDeleteContinuationExpressionBuilder<T>.LeftJoin(EntityExpression entity)
        {
            return Join<IDeleteContinuationExpressionBuilder<T>>(entity, JoinOperationExpressionOperator.LEFT);
        }

        IJoinExpressionBuilder<IDeleteContinuationExpressionBuilder<T>> IDeleteContinuationExpressionBuilder<T>.RightJoin(EntityExpression entity)
        {
            return Join<IDeleteContinuationExpressionBuilder<T>>(entity, JoinOperationExpressionOperator.RIGHT);
        }

        IJoinExpressionBuilder<IDeleteContinuationExpressionBuilder<T>> IDeleteContinuationExpressionBuilder<T>.FullJoin(EntityExpression entity)
        {
            return Join<IDeleteContinuationExpressionBuilder<T>>(entity, JoinOperationExpressionOperator.FULL);
        }

        IJoinExpressionBuilder<IDeleteContinuationExpressionBuilder<T>> IDeleteContinuationExpressionBuilder<T>.CrossJoin(EntityExpression entity)
        {
            return Join<IDeleteContinuationExpressionBuilder<T>>(entity, JoinOperationExpressionOperator.CROSS);
        }
        #endregion
    }
}
