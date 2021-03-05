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
using System;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class UpdateEntitiesUpdateQueryExpressionBuilder<TEntity> : UpdateQueryExpressionBuilder,
        IExpressionBuilder<TEntity>,
        UpdateEntities<TEntity>,
        UpdateEntitiesContinuation<TEntity>
        where TEntity : class, IDbEntity
    {
        #region constructors
        protected UpdateEntitiesUpdateQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, UpdateQueryExpression expression, EntityExpression<TEntity> entity) : base(config, expression, entity)
        {

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
            => CreateTypedBuilder(Configuration, Expression, entity as EntityExpression<TEntity> ?? throw new DbExpressionException($"Expected {nameof(entity)} to be of type {nameof(EntityExpression<TEntity>)}."));
        #endregion
    }
}
