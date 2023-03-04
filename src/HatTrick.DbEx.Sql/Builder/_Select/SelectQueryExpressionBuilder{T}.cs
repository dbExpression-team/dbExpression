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

using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectQueryExpressionBuilder<TDatabase> : QueryExpressionBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private SelectQueryExpression _rootExpression;
        protected override QueryExpression Expression => _rootExpression;
        protected SelectQueryExpression Current { get; private set; }
        protected IQueryExpressionFactory QueryExpressionFactory { get; private set; }
        protected IQueryExpressionExecutionPipelineFactory ExecutionPipelineFactory { get; private set; }
        #endregion

        #region interface
        public SelectQueryExpression SelectQueryExpression => _rootExpression;
        #endregion

        #region constructors
        public SelectQueryExpressionBuilder(
            IQueryExpressionFactory queryExpressionFactory,
            IQueryExpressionExecutionPipelineFactory executionPipelineFactory
        )
        {
            QueryExpressionFactory = queryExpressionFactory ?? throw new ArgumentNullException(nameof(queryExpressionFactory));
            ExecutionPipelineFactory = executionPipelineFactory ?? throw new ArgumentNullException(nameof(executionPipelineFactory));

            Current = _rootExpression = queryExpressionFactory.CreateQueryExpression<SelectQueryExpression>();
        }

        protected SelectQueryExpressionBuilder(
            IQueryExpressionFactory queryExpressionFactory,
            IQueryExpressionExecutionPipelineFactory executionPipelineFactory,
            SelectQueryExpression rootExpression,
            SelectQueryExpression currentExpression
        )
        {
            QueryExpressionFactory = queryExpressionFactory ?? throw new ArgumentNullException(nameof(queryExpressionFactory));
            ExecutionPipelineFactory = executionPipelineFactory ?? throw new ArgumentNullException(nameof(executionPipelineFactory));

            _rootExpression = rootExpression;
            Current = currentExpression;
        }
        #endregion

        #region methods
        protected virtual void ApplyFrom<T>(Table<T> entity)
            where T : class, IDbEntity
        {
            Current.From = new FromExpression(entity ?? throw new ArgumentNullException(nameof(entity)));
        }

        protected virtual void ApplyFrom(AnySelectSubquery query)
        {
            Current.From = new FromExpression((query as IQueryExpressionProvider)?.Expression ?? throw new ArgumentNullException(nameof(query)));
        }

        protected void ApplyTop(int value)
        {
            Current.Top = value;
        }

        protected void ApplyDistinct()
        {
            Current.Distinct = true;
        }

        protected void ApplyWhere(AnyWhereExpression? expression)
        {
            if (expression is null)
                return;

            if (expression is FilterExpression single)
            {
                if (Current.Where is null)
                    Current.Where = new(single);
                else
                    Current.Where &= single;
            }
            else if (expression is FilterExpressionSet set)
            {
                if (expression is IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements> provider && provider.Expression?.Args is not null && provider.Expression.Args.Any())
                {
                    if (Current.Where is null)
                        Current.Where = set;
                    else
                        Current.Where &= set;
                }
            }
        }

        protected void ApplyOrderBy(IEnumerable<AnyOrderByExpression>? orderBy)
        {
            if (orderBy is null || !orderBy.Any())
                return;

            Current.OrderBy &= new OrderByExpressionSet(orderBy);
        }

        protected void ApplyGroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            if (groupBy is null || !groupBy.Any())
                return;

            Current.GroupBy &= new GroupByExpressionSet(groupBy);
        }

        protected void ApplyHaving(AnyHavingExpression? having)
        {
            if (having is null)
                return;

            if (having is not FilterExpressionSet set)
                set = new(having);

            Current.Having &= new HavingExpression(set);
        }

        protected void ApplyCrossJoin(AnyEntity entity)
        {
            Current.Joins = Current.Joins is null ?
                new JoinExpressionSet(new JoinExpression(entity, JoinOperationExpressionOperator.CROSS, null))
                :
                new JoinExpressionSet(Current.Joins.Expressions.Concat(new JoinExpression[1] { new JoinExpression(entity, JoinOperationExpressionOperator.CROSS, null) }));
        }

        protected void ApplyOffset(int value)
            => Current.Offset = value;

        protected void ApplyLimit(int value)
            => Current.Limit = value;
        #endregion

        #region methods
        #region UnionSelectAnyInitiation<TDatabase>
        protected void ApplyUnion()
        {
            var exp = QueryExpressionFactory.CreateQueryExpression<SelectQueryExpression>();
            Current.ContinuationExpression = new QueryExpressionContinuationExpression(exp, new UnionExpression());
            Current = exp;
        }

        protected void ApplyUnionAll()
        {
            var exp = QueryExpressionFactory.CreateQueryExpression<SelectQueryExpression>();
            Current.ContinuationExpression = new QueryExpressionContinuationExpression(exp, new UnionAllExpression());
            Current = exp;
        }
        #endregion

        protected ISelectQueryExpressionExecutionPipeline CreateExecutionPipeline()
            => ExecutionPipelineFactory.CreateSelectQueryExecutionPipeline() ?? DbExpressionConfigurationException.ThrowServiceResolutionWithReturn<ISelectQueryExpressionExecutionPipeline>();
        #endregion
    }
}
