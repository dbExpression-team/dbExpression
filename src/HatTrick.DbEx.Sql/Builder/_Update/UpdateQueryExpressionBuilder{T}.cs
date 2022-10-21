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

using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public class UpdateQueryExpressionBuilder<TDatabase> : QueryExpressionBuilder<TDatabase>,
        UpdateEntities<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly UpdateQueryExpression _expression;
        protected Func<IUpdateQueryExpressionExecutionPipeline> ExecutionPipelineFactory { get; private set; }
        protected override QueryExpression Expression => UpdateQueryExpression;
        public UpdateQueryExpression UpdateQueryExpression => _expression;
        #endregion

        #region constructors
        public UpdateQueryExpressionBuilder(
            UpdateQueryExpression expression,
            Func<IUpdateQueryExpressionExecutionPipeline> executionPipelineFactory
        )
        {
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
            ExecutionPipelineFactory = executionPipelineFactory ?? throw new ArgumentNullException(nameof(executionPipelineFactory));
        }
        #endregion

        #region methods
        #region UpdateEntities<TDatabase>
        /// <inheritdoc />
        UpdateEntitiesContinuation<TDatabase, TEntity> UpdateEntities<TDatabase>.From<TEntity>(Table<TEntity> entity)
        {
            UpdateQueryExpression.From = entity ?? throw new ArgumentNullException(nameof(entity));
            return new UpdateEntitiesUpdateQueryExpressionBuilder<TDatabase, TEntity>(UpdateQueryExpression, ExecutionPipelineFactory);
        }

        /// <inheritdoc />
        UpdateEntities<TDatabase> UpdateEntities<TDatabase>.Top(int value)
        {
            UpdateQueryExpression.Top = value;
            return this;
        }
        #endregion

        protected void Where(AnyWhereExpression expression)
        {
            if (expression is null)
                return;

            if (expression is FilterExpression single)
            {
                if (UpdateQueryExpression.Where is null)
                    UpdateQueryExpression.Where = new(single);
                else
                    UpdateQueryExpression.Where &= single;
            }
            else if (expression is FilterExpressionSet set)
            {
                if (expression is IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements> provider && provider.Expression?.Args is not null && provider.Expression.Args.Any())
                {
                    if (UpdateQueryExpression.Where is null)
                        UpdateQueryExpression.Where = set;
                    else
                        UpdateQueryExpression.Where &= set;
                }
            }
        }

        protected void CrossJoin(AnyEntity entity)
        {
            UpdateQueryExpression.Joins = UpdateQueryExpression.Joins is null ?
                new JoinExpressionSet(new JoinExpression(entity, JoinOperationExpressionOperator.CROSS, null))
                :
                new JoinExpressionSet(UpdateQueryExpression.Joins.Expressions.Concat(new JoinExpression[1] { new JoinExpression(entity, JoinOperationExpressionOperator.CROSS, null) }));
        }
        #endregion
    }
}
