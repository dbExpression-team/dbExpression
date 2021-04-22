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
        protected override void From<T>(Entity<T> entity)
        {
            base.From(entity);
            Expression.Select = new SelectExpressionSet(entity.BuildInclusiveSelectExpression());
        }

        SelectEntityContinuation<TEntity> SelectEntity<TEntity>.From(Entity<TEntity> entity)
        {
            From(entity);
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

        SelectEntityContinuation<TEntity> SelectEntityContinuation<TEntity>.CrossJoin(AnyEntity entity)
        {
            CrossJoin(entity);
            return this;
        }
        #endregion
    }
}
