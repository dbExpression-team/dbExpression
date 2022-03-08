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

using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class SelectQueryExpressionBuilder : QueryExpressionBuilder
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
        protected virtual void ApplyFrom<T>(Entity<T> entity)
            where T : class, IDbEntity
        {
            if (entity is not EntityExpression e)
                throw new DbExpressionException($"Expected {nameof(entity)} to be of type {nameof(EntityExpression)}.");          
            Expression.BaseEntity = e;
        }

        protected void ApplyTop(int value)
        {
            Expression.Top = value;
        }

        protected void ApplyDistinct()
        {
            Expression.Distinct = true;
        }

        protected void ApplyWhere(AnyWhereClause? expression)
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

        protected void ApplyOrderBy(IEnumerable<AnyOrderByClause>? orderBy)
        {
            if (orderBy is null || !orderBy.Any())
                return;

            Expression.OrderBy &= new OrderByExpressionSet(orderBy);
        }

        protected void ApplyGroupBy(IEnumerable<AnyGroupByClause>? groupBy)
        {
            if (groupBy is null || !groupBy.Any())
                return;

            Expression.GroupBy &= new GroupByExpressionSet(groupBy);
        }

        protected void ApplyHaving(AnyHavingClause? having)
        {
            if (having is null)
                return;

            if (having is not FilterExpressionSet set)
                throw new DbExpressionException($"Expected {nameof(having)} to be of type {nameof(FilterExpressionSet)}.");

            Expression.Having &= new HavingExpression(set);
        }

        protected void ApplyCrossJoin(AnyEntity entity)
        {
            Expression.Joins = Expression.Joins is null ?
                new JoinExpressionSet(new JoinExpression(entity, JoinOperationExpressionOperator.CROSS, null))
                :
                new JoinExpressionSet(Expression.Joins.Expressions.Concat(new JoinExpression[1] { new JoinExpression(entity, JoinOperationExpressionOperator.CROSS, null) }));
        }

        protected void ApplyOffset(int value)
            => Expression.Offset = value;

        protected void ApplyLimit(int value)
            => Expression.Limit = value;
        #endregion
    }
}
