using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class UpdateQueryExpressionBuilder<T> : UpdateQueryExpressionBuilder,
        IUpdateInitiationExpressionBuilder,
        IUpdateFromExpressionBuilder<T>,
        IUpdateContinuationExpressionBuilder<T>
        where T : class, IDbEntity
    {
        #region internals
        protected T Target { get; set; }
        protected T Source { get; set; }
        #endregion

        #region constructors
        protected UpdateQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, UpdateQueryExpression expression, EntityExpression<T> entity)
            : base(configuration, expression, entity)
        {

        }

        protected UpdateQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, UpdateQueryExpression expression, T target, T source)
            : base(configuration, expression)
        {
            Target = target ?? throw new ArgumentNullException($"{target} is required.");
            Source = source ?? throw new ArgumentNullException($"{source} is required.");
        }
        #endregion

        #region methods
        IUpdateContinuationExpressionBuilder<T> IUpdateFromExpressionBuilder<T>.From(EntityExpression<T> entity)
        {
            Expression.BaseEntity = entity;
            Expression.Assign = (entity as IExpressionEntity<T>).BuildAssignmentExpression(Source, Target);
            return this;
        }

        IUpdateFromExpressionBuilder IUpdateInitiationExpressionBuilder.Update(AssignmentExpression[] assignments)
        {
            Expression.Assign = new AssignmentExpressionSet(Expression.Assign.Expressions.Concat(assignments));
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
