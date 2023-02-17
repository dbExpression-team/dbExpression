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
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public class UpdateQueryExpressionBuilder<TDatabase> : QueryExpressionBuilder<TDatabase>,
        UpdateEntities<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly UpdateQueryExpression _expression;
        protected IQueryExpressionExecutionPipelineFactory ExecutionPipelineFactory { get; private set; }
        protected override QueryExpression Expression => UpdateQueryExpression;
        public UpdateQueryExpression UpdateQueryExpression => _expression;
        #endregion

        #region constructors
        public UpdateQueryExpressionBuilder(
            IQueryExpressionFactory queryExpressionFactory,
            IQueryExpressionExecutionPipelineFactory executionPipelineFactory,
            IEnumerable<EntityFieldAssignment> assignments
        )
        {
            ExecutionPipelineFactory = executionPipelineFactory ?? throw new ArgumentNullException(nameof(executionPipelineFactory));
            _expression = queryExpressionFactory.CreateQueryExpression<UpdateQueryExpression>();
            _expression.Assign = new AssignmentExpressionSet(assignments.Select(x => x as AssignmentExpression ?? throw new DbExpressionQueryException(x, $"Expected all {nameof(assignments)} to be assignable to {typeof(AssignmentExpression)}.")));
        }

        protected UpdateQueryExpressionBuilder(
            IQueryExpressionExecutionPipelineFactory executionPipelineFactory,
            UpdateQueryExpression expression
        )
        {
            ExecutionPipelineFactory = executionPipelineFactory ?? throw new ArgumentNullException(nameof(executionPipelineFactory));
            _expression = expression;
        }
        #endregion

        #region methods
        #region UpdateEntities<TDatabase>
        /// <inheritdoc />
        UpdateEntitiesContinuation<TDatabase, TEntity> UpdateEntities<TDatabase>.From<TEntity>(Table<TEntity> entity)
        {
            UpdateQueryExpression.From = entity ?? throw new ArgumentNullException(nameof(entity));
            return new UpdateEntitiesUpdateQueryExpressionBuilder<TDatabase, TEntity>(ExecutionPipelineFactory, UpdateQueryExpression);
        }

        /// <inheritdoc />
        UpdateEntities<TDatabase> UpdateEntities<TDatabase>.Top(int value)
        {
            UpdateQueryExpression.Top = value;
            return this;
        }
        #endregion
        #endregion
    }
}
