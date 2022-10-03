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

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class SelectQueryExpressionBuilder<TDatabase> : QueryExpressionBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        protected Func<ISelectQueryExpressionExecutionPipeline> ExecutionPipelineFactory { get; private set; }
        protected override QueryExpression Expression => (Controller as IQueryExpressionProvider).Expression;
        #endregion

        #region interface
        public SelectSetQueryExpressionBuilder<TDatabase> Controller { get; private set; }
        #endregion

        #region constructors
        protected SelectQueryExpressionBuilder(
            Func<ISelectQueryExpressionExecutionPipeline> executionPipelineFactory,
            SelectSetQueryExpressionBuilder<TDatabase> controller
        )
        {
            Controller = controller ?? throw new ArgumentNullException(nameof(controller));
            ExecutionPipelineFactory = executionPipelineFactory ?? throw new ArgumentNullException(nameof(executionPipelineFactory));
        }
        #endregion

        #region methods
        protected virtual void ApplyFrom<T>(Table<T> entity)
            where T : class, IDbEntity
        {
            Controller.Current.From = new FromExpression(entity ?? throw new ArgumentNullException(nameof(entity)));
        }

        protected virtual void ApplyFrom(AnySelectSubquery query)
        {
            Controller.Current.From = new FromExpression((query as IQueryExpressionProvider)?.Expression ?? throw new ArgumentNullException(nameof(query)));
        }

        protected void ApplyTop(int value)
        {
            Controller.Current.Top = value;
        }

        protected void ApplyDistinct()
        {
            Controller.Current.Distinct = true;
        }

        protected void ApplyWhere(AnyWhereExpression? expression)
        {
            if (expression is null)
                return;

            if (expression is FilterExpression single)
            {
                if (Controller.Current.Where is null)
                    Controller.Current.Where = new(single);
                else
                    Controller.Current.Where &= single;
            }
            else if (expression is FilterExpressionSet set)
            {
                if (expression is IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements> provider && provider.Expression?.Args is not null && provider.Expression.Args.Any())
                {
                    if (Controller.Current.Where is null)
                        Controller.Current.Where = set;
                    else
                        Controller.Current.Where &= set;
                }
            }
        }

        protected void ApplyOrderBy(IEnumerable<AnyOrderByExpression>? orderBy)
        {
            if (orderBy is null || !orderBy.Any())
                return;

            Controller.Current.OrderBy &= new OrderByExpressionSet(orderBy);
        }

        protected void ApplyGroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            if (groupBy is null || !groupBy.Any())
                return;

            Controller.Current.GroupBy &= new GroupByExpressionSet(groupBy);
        }

        protected void ApplyHaving(AnyHavingExpression? having)
        {
            if (having is null)
                return;

            if (having is not FilterExpressionSet set)
                set = new(having);

            Controller.Current.Having &= new HavingExpression(set);
        }

        protected void ApplyCrossJoin(AnyEntity entity)
        {
            Controller.Current.Joins = Controller.Current.Joins is null ?
                new JoinExpressionSet(new JoinExpression(entity, JoinOperationExpressionOperator.CROSS, null))
                :
                new JoinExpressionSet(Controller.Current.Joins.Expressions.Concat(new JoinExpression[1] { new JoinExpression(entity, JoinOperationExpressionOperator.CROSS, null) }));
        }

        protected void ApplyOffset(int value)
            => Controller.Current.Offset = value;

        protected void ApplyLimit(int value)
            => Controller.Current.Limit = value;
        #endregion
    }
}
