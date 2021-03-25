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
    public abstract class SelectValueSelectQueryExpressionBuilder<TValue> : SelectQueryExpressionBuilder,
        IExpressionBuilder<TValue>,
        SelectValue<TValue>,
        SelectValueContinuation<TValue>
    {
        #region constructors
        protected SelectValueSelectQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, SelectQueryExpression expression) : base(config, expression)
        {

        }
        #endregion

        #region methods
        SelectValueContinuation<TValue> SelectValue<TValue>.From<TEntity>(Entity<TEntity> entity)
        {
            From(entity);
            return this;
        }

        SelectValueContinuation<TValue> SelectValueContinuation<TValue>.OrderBy(params AnyOrderByClause[] orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        SelectValueContinuation<TValue> SelectValueContinuation<TValue>.OrderBy(IEnumerable<AnyOrderByClause> orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        SelectValueContinuation<TValue> SelectValueContinuation<TValue>.GroupBy(params AnyGroupByClause[] groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        SelectValueContinuation<TValue> SelectValueContinuation<TValue>.GroupBy(IEnumerable<AnyGroupByClause> groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        SelectValueContinuation<TValue> SelectValueContinuation<TValue>.Having(AnyHavingClause having)
        {
            Having(having);
            return this;
        }

        SelectValueContinuation<TValue> SelectValueContinuation<TValue>.Where(AnyWhereClause where)
        {
            Where(where);
            return this;
        }

        JoinOn<SelectValueContinuation<TValue>> SelectValueContinuation<TValue>.InnerJoin(AnyEntity entity)
            => new SelectValueJoinBuilder<TValue>(Expression, entity, JoinOperationExpressionOperator.INNER, this);

        JoinOnWithAlias<SelectValueContinuation<TValue>> SelectValueContinuation<TValue>.InnerJoin(AnySelectSubquery subquery)
            => new SelectValueJoinBuilder<TValue>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.INNER, this);

        JoinOn<SelectValueContinuation<TValue>> SelectValueContinuation<TValue>.LeftJoin(AnyEntity entity)
            => new SelectValueJoinBuilder<TValue>(Expression, entity, JoinOperationExpressionOperator.LEFT, this);

        JoinOnWithAlias<SelectValueContinuation<TValue>> SelectValueContinuation<TValue>.LeftJoin(AnySelectSubquery subquery)
            => new SelectValueJoinBuilder<TValue>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.LEFT, this);

        JoinOn<SelectValueContinuation<TValue>> SelectValueContinuation<TValue>.RightJoin(AnyEntity entity)
            => new SelectValueJoinBuilder<TValue>(Expression, entity, JoinOperationExpressionOperator.RIGHT, this);

        JoinOnWithAlias<SelectValueContinuation<TValue>> SelectValueContinuation<TValue>.RightJoin(AnySelectSubquery subquery)
            => new SelectValueJoinBuilder<TValue>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.RIGHT, this);

        JoinOn<SelectValueContinuation<TValue>> SelectValueContinuation<TValue>.FullJoin(AnyEntity entity)
            => new SelectValueJoinBuilder<TValue>(Expression, entity, JoinOperationExpressionOperator.FULL, this);

        JoinOnWithAlias<SelectValueContinuation<TValue>> SelectValueContinuation<TValue>.FullJoin(AnySelectSubquery subquery)
            => new SelectValueJoinBuilder<TValue>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.FULL, this);

        SelectValueContinuation<TValue> SelectValueContinuation<TValue>.CrossJoin(AnyEntity entity)
        {
            CrossJoin(entity);
            return this;
        }
        #endregion
    }
}
