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
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public class DeleteQueryExpressionBuilder<TDatabase> : QueryExpressionBuilder<TDatabase>,
        DeleteEntities<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        protected IQueryExpressionFactory QueryExpressionFactory { get; private set; }
        protected IQueryExpressionExecutionPipelineFactory ExecutionPipelineFactory { get; private set; }
        private readonly DeleteQueryExpression _expression;
        protected override QueryExpression Expression => DeleteQueryExpression;
        public DeleteQueryExpression DeleteQueryExpression => _expression;
        #endregion

        #region constructors
        public DeleteQueryExpressionBuilder(
            IQueryExpressionFactory queryExpressionFactory,
            IQueryExpressionExecutionPipelineFactory executionPipelineFactory
        )
        {
            QueryExpressionFactory = queryExpressionFactory ?? throw new ArgumentNullException(nameof(queryExpressionFactory));
            ExecutionPipelineFactory = executionPipelineFactory ?? throw new ArgumentNullException(nameof(executionPipelineFactory));
            _expression = queryExpressionFactory.CreateQueryExpression<DeleteQueryExpression>();
        }

        protected DeleteQueryExpressionBuilder(
            IQueryExpressionFactory queryExpressionFactory,
            IQueryExpressionExecutionPipelineFactory executionPipelineFactory,
            DeleteQueryExpression expression
        )
        {
            QueryExpressionFactory = queryExpressionFactory ?? throw new ArgumentNullException(nameof(queryExpressionFactory));
            ExecutionPipelineFactory = executionPipelineFactory ?? throw new ArgumentNullException(nameof(executionPipelineFactory));
            _expression = expression ?? throw new ArgumentNullException(nameof(executionPipelineFactory));
        }
        #endregion

        #region methods
        /// <inheritdoc />
        DeleteEntitiesContinuation<TDatabase, TEntity> DeleteEntities<TDatabase>.From<TEntity>(Table<TEntity> entity)
            => new DeleteEntitiesDeleteQueryExpressionBuilder<TDatabase, TEntity>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                DeleteQueryExpression,
                entity
            );

        /// <inheritdoc />
        DeleteEntities<TDatabase> DeleteEntities<TDatabase>.Top(int value)
        {
            DeleteQueryExpression.Top = value;
            return this;
        }
        #endregion
    }
}
