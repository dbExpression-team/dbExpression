using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Configuration;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class SqlExpressionBuilder :
        IDeleteFromExpressionBuilder,
        IDeleteContinuationExpressionBuilder, 
        IUpdateInitiationExpressionBuilder,
        IUpdateFromExpressionBuilder,
        IUpdateContinuationExpressionBuilder,
        ITerminationExpressionBuilder,
        IExpressionProvider
    {
        public ExpressionSet Expression { get; set; } = new ExpressionSet();

        protected SqlExpressionBuilder(ExpressionSet expression)
        {
            Expression = expression;
        }

        ExpressionSet IExpressionProvider.GetExpression() => Expression;

        #region Delete
        IDeleteContinuationExpressionBuilder IDeleteFromExpressionBuilder.From(EntityExpression entity)
        {
            Expression.BaseEntity = entity;
            return this;
        }

        IDeleteContinuationExpressionBuilder IDeleteContinuationExpressionBuilder.Where(WhereExpression filter)
        {
            return Where<IDeleteContinuationExpressionBuilder>(filter) as IDeleteContinuationExpressionBuilder;
        }

        IDeleteContinuationExpressionBuilder IDeleteContinuationExpressionBuilder.Where(WhereExpressionSet filter)
        {
            return Where<IDeleteContinuationExpressionBuilder>(filter) as IDeleteContinuationExpressionBuilder;
        }

        IJoinExpressionBuilder<IDeleteContinuationExpressionBuilder> IDeleteContinuationExpressionBuilder.InnerJoin(EntityExpression entity)
        {
            return Join<IDeleteContinuationExpressionBuilder>(entity, JoinOperationExpressionOperator.INNER);
        }

        IJoinExpressionBuilder<IDeleteContinuationExpressionBuilder> IDeleteContinuationExpressionBuilder.LeftJoin(EntityExpression entity)
        {
            return Join<IDeleteContinuationExpressionBuilder>(entity, JoinOperationExpressionOperator.LEFT);
        }

        IJoinExpressionBuilder<IDeleteContinuationExpressionBuilder> IDeleteContinuationExpressionBuilder.RightJoin(EntityExpression entity)
        {
            return Join<IDeleteContinuationExpressionBuilder>(entity, JoinOperationExpressionOperator.RIGHT);
        }

        IJoinExpressionBuilder<IDeleteContinuationExpressionBuilder> IDeleteContinuationExpressionBuilder.FullJoin(EntityExpression entity)
        {
            return Join<IDeleteContinuationExpressionBuilder>(entity, JoinOperationExpressionOperator.FULL);
        }

        IJoinExpressionBuilder<IDeleteContinuationExpressionBuilder> IDeleteContinuationExpressionBuilder.CrossJoin(EntityExpression entity)
        {
            return Join<IDeleteContinuationExpressionBuilder>(entity, JoinOperationExpressionOperator.CROSS);
        }
        #endregion

        #region Update
        IUpdateContinuationExpressionBuilder IUpdateFromExpressionBuilder.From(EntityExpression entity)
        {
            Expression.BaseEntity = entity;
            return this as IUpdateContinuationExpressionBuilder;
        }

        IUpdateContinuationExpressionBuilder IUpdateInitiationExpressionBuilder.Update(AssignmentExpression[] assignments)
        {
            foreach (var assignment in assignments)
                Expression &= assignment;
            return this as IUpdateContinuationExpressionBuilder;
        }

        IUpdateContinuationExpressionBuilder IUpdateContinuationExpressionBuilder.Where(WhereExpression filter)
        {
            return Where<IUpdateContinuationExpressionBuilder>(filter) as IUpdateContinuationExpressionBuilder;
        }

        IUpdateContinuationExpressionBuilder IUpdateContinuationExpressionBuilder.Where(WhereExpressionSet filter)
        {
            return Where<IUpdateContinuationExpressionBuilder>(filter) as IUpdateContinuationExpressionBuilder;
        }

        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder> IUpdateContinuationExpressionBuilder.InnerJoin(EntityExpression entity)
        {
            return Join<IUpdateContinuationExpressionBuilder>(entity, JoinOperationExpressionOperator.INNER);
        }

        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder> IUpdateContinuationExpressionBuilder.LeftJoin(EntityExpression entity)
        {
            return Join<IUpdateContinuationExpressionBuilder>(entity, JoinOperationExpressionOperator.LEFT);
        }

        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder> IUpdateContinuationExpressionBuilder.RightJoin(EntityExpression entity)
        {
            return Join<IUpdateContinuationExpressionBuilder>(entity, JoinOperationExpressionOperator.RIGHT);
        }

        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder> IUpdateContinuationExpressionBuilder.FullJoin(EntityExpression entity)
        {
            return Join<IUpdateContinuationExpressionBuilder>(entity, JoinOperationExpressionOperator.FULL);
        }

        IJoinExpressionBuilder<IUpdateContinuationExpressionBuilder> IUpdateContinuationExpressionBuilder.CrossJoin(EntityExpression entity)
        {
            return Join<IUpdateContinuationExpressionBuilder>(entity, JoinOperationExpressionOperator.CROSS);
        }
        #endregion

        protected U Where<U>(WhereExpressionSet expression) where U : class, IExpressionBuilder
        {
            if (Expression.Where == null)
                Expression.Where = expression;
            else
                Expression.Where &= expression;
            return this as U;
        }

        protected U Where<T, U>(WhereExpressionSet expression) where U : class, IExpressionBuilder<T>
        {
            if (Expression.Where == null)
                Expression.Where = expression;
            else
                Expression.Where &= expression;
            return this as U;
        }

        protected IJoinExpressionBuilder<T> Join<T>(EntityExpression joinEntity, JoinOperationExpressionOperator joinType)
            where T : class, IExpressionBuilder
        {
            return new JoinExpressionBuilder<T>(Expression, joinEntity, joinType, this as T);
        }

        protected IJoinExpressionBuilder<T, TBuilder> Join<T, TBuilder>(EntityExpression joinEntity, JoinOperationExpressionOperator joinType)
            where TBuilder : class, IExpressionBuilder<T>
        {
            return new JoinExpressionBuilder<T, TBuilder>(Expression, joinEntity, joinType, this as TBuilder);
        }
    }
}
