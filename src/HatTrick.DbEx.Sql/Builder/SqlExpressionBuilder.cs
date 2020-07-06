﻿using HatTrick.DbEx.Sql.Builder.Syntax;
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
        IDbExpressionSetProvider
    {
        public ExpressionSet Expression { get; protected set; } = new ExpressionSet();

        protected SqlExpressionBuilder(ExpressionSet expression)
        {
            Expression = expression;
        }

        protected SqlExpressionBuilder()
        {
        }

        ExpressionSet IDbExpressionSetProvider.Expression => Expression;

        #region Delete
        IDeleteContinuationExpressionBuilder IDeleteFromExpressionBuilder.From(EntityExpression entity)
        {
            Expression.BaseEntity = entity;
            return this;
        }

        IDeleteContinuationExpressionBuilder IDeleteContinuationExpressionBuilder.Where(FilterExpression filter)
        {
            return Where<IDeleteContinuationExpressionBuilder>(filter);
        }

        IDeleteContinuationExpressionBuilder IDeleteContinuationExpressionBuilder.Where(FilterExpressionSet filter)
        {
            return Where<IDeleteContinuationExpressionBuilder>(filter);
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
            return this;
        }

        IUpdateContinuationExpressionBuilder IUpdateContinuationExpressionBuilder.Where(FilterExpression filter)
        {
            return Where<IUpdateContinuationExpressionBuilder>(filter);
        }

        IUpdateContinuationExpressionBuilder IUpdateContinuationExpressionBuilder.Where(FilterExpressionSet filter)
        {
            return Where<IUpdateContinuationExpressionBuilder>(filter);
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

        protected U Where<U>(FilterExpressionSet expression) where U : class, IExpressionBuilder
        {
            if (expression == null)
                return this as U;

            if (Expression.Where?.LeftArg == null)
                Expression.Where = expression;
            else
                Expression.Where &= expression;
            return this as U;
        }

        protected U Where<T, U>(FilterExpressionSet expression) where U : class, IExpressionBuilder<T>
        {
            if (expression == null)
                return this as U;

            if (Expression.Where?.LeftArg == null)
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

        protected IAliasRequiredJoinExpressionBuilder<T, TBuilder> Join<T, TBuilder>(ISubqueryTerminationExpressionBuilder subquery, JoinOperationExpressionOperator joinType)
            where TBuilder : class, IExpressionBuilder<T>
        {
            return new JoinExpressionBuilder<T, TBuilder>(Expression, (subquery as IDbExpressionSetProvider).Expression, joinType, this as TBuilder);
        }
    }
}
