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
    public abstract class UpdateQueryExpressionBuilder : QueryExpressionBuilder,
        UpdateEntities
    {
        protected UpdateQueryExpression Expression { get; private set; }

        protected UpdateQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, UpdateQueryExpression expression)
            : base(config, expression)
        {
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }

        protected UpdateQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, UpdateQueryExpression expression, EntityExpression entity)
            : base(config, expression)
        {
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
            Expression.BaseEntity = entity ?? throw new ArgumentNullException(nameof(entity));
        }



        UpdateEntitiesContinuation<TEntity> UpdateEntities.From<TEntity>(Entity<TEntity> entity)
            => CreateTypedBuilder(Configuration, Expression, entity as EntityExpression<TEntity> ?? throw new DbExpressionException($"Expected {nameof(entity)} to be of type {nameof(EntityExpression)}."));

        UpdateEntities UpdateEntities.Top(int value)
        {
            Expression.Top = value;
            return this;
        }

        protected abstract UpdateEntitiesContinuation<TEntity> CreateTypedBuilder<TEntity>(RuntimeSqlDatabaseConfiguration configuration, UpdateQueryExpression expression, EntityExpression<TEntity> entity)
            where TEntity : class, IDbEntity;

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
    }
}
