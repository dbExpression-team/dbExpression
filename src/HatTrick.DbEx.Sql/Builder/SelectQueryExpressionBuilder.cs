#region license
// Copyright (c) HatTrick Labs, LLC.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/HatTrickLabs/db-ex
#endregion

﻿using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class SelectQueryExpressionBuilder : QueryExpressionBuilder,
        SelectDynamic,
        SelectDynamics,
        SelectDynamicContinuation,
        SelectDynamicsContinuation,
        SelectDynamicsOffsetContinuation,
        SelectDynamicsOrderByContinuation
    {
        #region internals
        protected SelectQueryExpression Expression { get; private set; }
        #endregion

        #region constructors
        protected SelectQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, SelectQueryExpression expression)
            : base(config, expression)
        {
            Expression = expression;
        }
        #endregion

        #region methods
        #region dynamics
        SelectDynamics SelectDynamics.Top(int value)
        {
            Top(value);
            return this;
        }

        SelectDynamics SelectDynamics.Distinct()
        {
            Distinct();
            return this;
        }

        SelectDynamicsContinuation SelectDynamics.From<TEntity>(Entity<TEntity> entity)
        {
            From(entity);
            return this;
        }

        SelectDynamicsOrderByContinuation SelectDynamicsContinuation.OrderBy(params AnyOrderByClause[] orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        SelectDynamicsOrderByContinuation SelectDynamicsContinuation.OrderBy(IEnumerable<AnyOrderByClause> orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        SelectDynamicsContinuation SelectDynamicsContinuation.GroupBy(params AnyGroupByClause[] groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        SelectDynamicsContinuation SelectDynamicsContinuation.GroupBy(IEnumerable<AnyGroupByClause> groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        SelectDynamicsContinuation SelectDynamicsContinuation.Having(AnyHavingClause having)
        {
            Having(having);
            return this;
        }

        SelectDynamicsContinuation SelectDynamicsContinuation.Where(AnyWhereClause where)
        {
            Where(where);
            return this;
        }

        JoinOn<SelectDynamicsContinuation> SelectDynamicsContinuation.InnerJoin(AnyEntity entity)
            => new SelectDynamicsJoinBuilder(Expression, entity, JoinOperationExpressionOperator.INNER, this);

        JoinOnWithAlias<SelectDynamicsContinuation> SelectDynamicsContinuation.InnerJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinBuilder(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.INNER, this);

        JoinOn<SelectDynamicsContinuation> SelectDynamicsContinuation.LeftJoin(AnyEntity entity)
            => new SelectDynamicsJoinBuilder(Expression, entity, JoinOperationExpressionOperator.LEFT, this);

        JoinOnWithAlias<SelectDynamicsContinuation> SelectDynamicsContinuation.LeftJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinBuilder(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.LEFT, this);

        JoinOn<SelectDynamicsContinuation> SelectDynamicsContinuation.RightJoin(AnyEntity entity)
            => new SelectDynamicsJoinBuilder(Expression, entity, JoinOperationExpressionOperator.RIGHT, this);

        JoinOnWithAlias<SelectDynamicsContinuation> SelectDynamicsContinuation.RightJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinBuilder(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.RIGHT, this);

        JoinOn<SelectDynamicsContinuation> SelectDynamicsContinuation.FullJoin(AnyEntity entity)
            => new SelectDynamicsJoinBuilder(Expression, entity, JoinOperationExpressionOperator.FULL, this);

        JoinOnWithAlias<SelectDynamicsContinuation> SelectDynamicsContinuation.FullJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinBuilder(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.FULL, this);

        SelectDynamicsContinuation SelectDynamicsContinuation.CrossJoin(AnyEntity entity)
        {
            CrossJoin(entity);
            return this;
        }

        SelectDynamicsOffsetContinuation SelectDynamicsOrderByContinuation.Offset(int value)
        {
            Offset(value);
            return this;
        }

        SelectDynamicsOrderByContinuation Limit<SelectDynamicsOrderByContinuation>.Limit(int value)
        {
            Limit(value);
            return this;
        }

        SelectDynamicsOrderByContinuation SelectDynamicsOrderByContinuation.GroupBy(params AnyGroupByClause[] groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        SelectDynamicsOrderByContinuation SelectDynamicsOrderByContinuation.GroupBy(IEnumerable<AnyGroupByClause> groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        SelectDynamicsOrderByContinuation SelectDynamicsOrderByContinuation.Having(AnyHavingClause having)
        {
            Having(having);
            return this;
        }
        #endregion

        #region dynamic
        SelectDynamicContinuation SelectDynamic.From<TEntity>(Entity<TEntity> entity)
        {
            From(entity);
            return this;
        }

        SelectDynamicContinuation SelectDynamicContinuation.OrderBy(params AnyOrderByClause[] orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        SelectDynamicContinuation SelectDynamicContinuation.OrderBy(IEnumerable<AnyOrderByClause> orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        SelectDynamicContinuation SelectDynamicContinuation.Where(AnyWhereClause where)
        {
            Where(where);
            return this;
        }

        SelectDynamicsOrderByContinuation Limit<SelectDynamicsOrderByContinuation>.Having(AnyHavingClause having)
        {
            Having(having);
            return this;
        }

        JoinOn<SelectDynamicContinuation> SelectDynamicContinuation.InnerJoin(AnyEntity entity)
            => new SelectDynamicJoinBuilder(Expression, entity, JoinOperationExpressionOperator.INNER, this);

        JoinOnWithAlias<SelectDynamicContinuation> SelectDynamicContinuation.InnerJoin(AnySelectSubquery subquery)
            => new SelectDynamicJoinBuilder(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.INNER, this);

        JoinOn<SelectDynamicContinuation> SelectDynamicContinuation.LeftJoin(AnyEntity entity)
            => new SelectDynamicJoinBuilder(Expression, entity, JoinOperationExpressionOperator.LEFT, this);

        JoinOnWithAlias<SelectDynamicContinuation> SelectDynamicContinuation.LeftJoin(AnySelectSubquery subquery)
            => new SelectDynamicJoinBuilder(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.LEFT, this);

        JoinOn<SelectDynamicContinuation> SelectDynamicContinuation.RightJoin(AnyEntity entity)
            => new SelectDynamicJoinBuilder(Expression, entity, JoinOperationExpressionOperator.RIGHT, this);

        JoinOnWithAlias<SelectDynamicContinuation> SelectDynamicContinuation.RightJoin(AnySelectSubquery subquery)
            => new SelectDynamicJoinBuilder(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.RIGHT, this);

        JoinOn<SelectDynamicContinuation> SelectDynamicContinuation.FullJoin(AnyEntity entity)
            => new SelectDynamicJoinBuilder(Expression, entity, JoinOperationExpressionOperator.FULL, this);

        JoinOnWithAlias<SelectDynamicContinuation> SelectDynamicContinuation.FullJoin(AnySelectSubquery subquery)
            => new SelectDynamicJoinBuilder(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.FULL, this);

        SelectDynamicContinuation SelectDynamicContinuation.CrossJoin(AnyEntity entity)
        {
            CrossJoin(entity);
            return this;
        }

        SelectDynamicContinuation SelectDynamicContinuation.GroupBy(params AnyGroupByClause[] groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        SelectDynamicContinuation SelectDynamicContinuation.GroupBy(IEnumerable<AnyGroupByClause> groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        SelectDynamicContinuation SelectDynamicContinuation.Having(AnyHavingClause having)
        {
            Having(having);
            return this;
        }
        #endregion

        protected virtual void From<T>(Entity<T> entity)
            where T : class, IDbEntity
        {
            if (!(entity is EntityExpression e))
                throw new DbExpressionException($"Expected {nameof(entity)} to be of type {nameof(EntityExpression)}.");          
            Expression.BaseEntity = e;
        }

        protected void Top(int value)
        {
            Expression.Top = value;
        }

        protected void Distinct()
        {
            Expression.Distinct = true;
        }


        protected void Where(AnyWhereClause expression)
        {
            if (expression is null)
                return;

            if (!(expression is FilterExpressionSet set))
                throw new DbExpressionException($"Expected {nameof(expression)} to be of type {nameof(FilterExpressionSet)}.");

            if (Expression.Where is null || Expression.Where.IsEmpty)
                Expression.Where = set;
            else
                Expression.Where &= set;
        }

        protected void OrderBy(IEnumerable<AnyOrderByClause> orderBy)
        {
            if (orderBy is null || !orderBy.Any())
                return;

            Expression.OrderBy &= new OrderByExpressionSet(orderBy);
        }

        protected void GroupBy(IEnumerable<AnyGroupByClause> groupBy)
        {
            if (groupBy is null || !groupBy.Any())
                return;

            Expression.GroupBy &= new GroupByExpressionSet(groupBy);
        }

        protected void Having(AnyHavingClause having)
        {
            if (having is null)
                return;

            if (!(having is FilterExpressionSet set))
                throw new DbExpressionException($"Expected {nameof(having)} to be of type {nameof(FilterExpressionSet)}.");

            Expression.Having &= new HavingExpression(set);
        }

        protected void CrossJoin(AnyEntity entity)
        {
            Expression.Joins = Expression.Joins is null ?
                new JoinExpressionSet(new JoinExpression(entity, JoinOperationExpressionOperator.CROSS, null))
                :
                new JoinExpressionSet(Expression.Joins.Expressions.Concat(new JoinExpression[1] { new JoinExpression(entity, JoinOperationExpressionOperator.CROSS, null) }));
        }

        protected void Offset(int value)
            => Expression.Offset = value;

        protected void Limit(int value)
            => Expression.Limit = value;
        #endregion
    }
}
