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
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public class UpdateQueryExpressionBuilder : QueryExpressionBuilder,
        UpdateEntities
    {
        #region internals
        protected UpdateQueryExpression Expression { get; private set; }
        #endregion

        #region constructors
        public UpdateQueryExpressionBuilder(SqlDatabaseRuntimeConfiguration config, UpdateQueryExpression expression)
            : base(config, expression)
        {
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }

        protected UpdateQueryExpressionBuilder(SqlDatabaseRuntimeConfiguration config, UpdateQueryExpression expression, Table entity)
            : base(config, expression)
        {
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
            Expression.BaseEntity = entity ?? throw new ArgumentNullException(nameof(entity));
        }
        #endregion

        #region methods
        /// <inheritdoc />
        UpdateEntitiesContinuation<TEntity> UpdateEntities.From<TEntity>(Table<TEntity> entity)
            => CreateTypedBuilder(Configuration, Expression, entity as EntityExpression<TEntity> ?? throw new DbExpressionException($"Expected {nameof(entity)} to be of type {nameof(EntityExpression)}."));

        /// <inheritdoc />
        UpdateEntities UpdateEntities.Top(int value)
        {
            Expression.Top = value;
            return this;
        }

        protected static UpdateEntitiesContinuation<TEntity> CreateTypedBuilder<TEntity>(SqlDatabaseRuntimeConfiguration configuration, UpdateQueryExpression expression, EntityExpression<TEntity> entity)
            where TEntity : class, IDbEntity
            => new UpdateEntitiesUpdateQueryExpressionBuilder<TEntity>(configuration, expression, entity);

        protected void Where(AnyWhereClause expression)
        {
            if (expression is null)
                return;

            if (expression is not FilterExpressionSet set)
                throw new DbExpressionException($"Expected {nameof(expression)} to be of type {nameof(FilterExpressionSet)}.");

            var where = (Expression.Where as IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements>)?.Expression;
            if (where is null || where.IsEmpty || Expression.Where is null)
                Expression.Where = set;
            else
                Expression.Where &= set;
        }

        protected void CrossJoin(AnyEntity entity)
        {
            Expression.Joins = Expression.Joins is null ?
                new JoinExpressionSet(new JoinExpression(entity, JoinOperationExpressionOperator.CROSS, null))
                :
                new JoinExpressionSet(Expression.Joins.Expressions.Concat(new JoinExpression[1] { new JoinExpression(entity, JoinOperationExpressionOperator.CROSS, null) }));
        }
        #endregion
    }
}
