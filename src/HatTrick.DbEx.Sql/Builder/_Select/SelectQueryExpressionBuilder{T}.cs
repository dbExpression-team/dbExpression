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
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class SelectQueryExpressionBuilder<TDatabase> : QueryExpressionBuilder<TDatabase>,
        UnionSelectAnyInitiation<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        protected readonly Func<UnionSelectAnyInitiation<TDatabase>> union;
        private SelectQueryExpression _expression;
        protected override QueryExpression Expression => SelectQueryExpression;
        #endregion

        #region interface
        public SelectQueryExpression SelectQueryExpression => _expression;
        
        UnionSelectAnyContinuation<TDatabase> UnionSelectAnyInitiation<TDatabase>.Union
            => union!().Union;

        UnionSelectAnyContinuation<TDatabase> UnionSelectAnyInitiation<TDatabase>.UnionAll
            => union!().UnionAll;
        #endregion

        #region constructors
        protected SelectQueryExpressionBuilder(
            SelectQueryExpression expression,
            SqlDatabaseRuntimeConfiguration config, 
            Func<UnionSelectAnyInitiation<TDatabase>> union
        ): base(config)
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
            this.union = union ?? throw new ArgumentNullException(nameof(union));
        }
        #endregion

        #region methods
        protected virtual void ApplyFrom<T>(Table<T> entity)
            where T : class, IDbEntity
        {
            SelectQueryExpression.From = entity ?? throw new ArgumentNullException(nameof(entity));
        }

        protected void ApplyTop(int value)
        {
            SelectQueryExpression.Top = value;
        }

        protected void ApplyDistinct()
        {
            SelectQueryExpression.Distinct = true;
        }

        protected void ApplyWhere(AnyWhereClause? expression)
        {
            if (expression is null)
                return;

            if (expression is FilterExpression single)
            {
                if (SelectQueryExpression.Where is null)
                    SelectQueryExpression.Where = new(single);
                else
                    SelectQueryExpression.Where &= single;
            }
            else if (expression is FilterExpressionSet set)
            {
                if (expression is IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements> provider && provider.Expression?.Args is not null && provider.Expression.Args.Any())
                {
                    if (SelectQueryExpression.Where is null)
                        SelectQueryExpression.Where = set;
                    else
                        SelectQueryExpression.Where &= set;
                }
            }
        }

        protected void ApplyOrderBy(IEnumerable<AnyOrderByClause>? orderBy)
        {
            if (orderBy is null || !orderBy.Any())
                return;

            SelectQueryExpression.OrderBy &= new OrderByExpressionSet(orderBy);
        }

        protected void ApplyGroupBy(IEnumerable<AnyGroupByClause>? groupBy)
        {
            if (groupBy is null || !groupBy.Any())
                return;

            SelectQueryExpression.GroupBy &= new GroupByExpressionSet(groupBy);
        }

        protected void ApplyHaving(AnyHavingClause? having)
        {
            if (having is null)
                return;

            if (having is not FilterExpressionSet set)
                set = new(having);

            SelectQueryExpression.Having &= new HavingExpression(set);
        }

        protected void ApplyCrossJoin(AnyEntity entity)
        {
            SelectQueryExpression.Joins = SelectQueryExpression.Joins is null ?
                new JoinExpressionSet(new JoinExpression(entity, JoinOperationExpressionOperator.CROSS, null))
                :
                new JoinExpressionSet(SelectQueryExpression.Joins.Expressions.Concat(new JoinExpression[1] { new JoinExpression(entity, JoinOperationExpressionOperator.CROSS, null) }));
        }

        protected void ApplyOffset(int value)
            => SelectQueryExpression.Offset = value;

        protected void ApplyLimit(int value)
            => SelectQueryExpression.Limit = value;

        protected virtual ISelectQueryExpressionExecutionPipeline CreateSelectExecutionPipeline()
            => Configuration.ExecutionPipelineFactory?.CreateQueryExecutionPipeline(Configuration, SelectQueryExpression) ?? throw new DbExpressionConfigurationException($"Could not resolve/create an execution pipeline for type '{GetType()}',  please review and ensure the correct configuration for DbExpression.");
        #endregion
    }
}
