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
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public class UpdateEntitiesUpdateQueryExpressionBuilder<TEntity> : UpdateQueryExpressionBuilder,
        IExpressionBuilder<TEntity>,
        UpdateEntities<TEntity>,
        UpdateEntitiesContinuation<TEntity>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public UpdateEntitiesUpdateQueryExpressionBuilder(
            UpdateQueryExpression expression,
            Func<IUpdateQueryExecutionPipeline> executionPipelineFactory
        ) : base(expression, executionPipelineFactory)
        {

        }
        #endregion

        #region methods
        /// <inheritdoc />
        UpdateEntitiesContinuation<TEntity> UpdateEntitiesContinuation<TEntity>.Where(AnyWhereExpression where)
        {
            Where(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<UpdateEntitiesContinuation<TEntity>> UpdateEntitiesContinuation<TEntity>.InnerJoin(AnyEntity entity)
            => new UpdateEntitiesJoinExpressionBuilder<TEntity>(UpdateQueryExpression, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        WithAlias<JoinOn<UpdateEntitiesContinuation<TEntity>>> UpdateEntitiesContinuation<TEntity>.InnerJoin(AnySelectSubquery subquery)
            => new UpdateEntitiesJoinExpressionBuilder<TEntity>(UpdateQueryExpression, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<UpdateEntitiesContinuation<TEntity>> UpdateEntitiesContinuation<TEntity>.LeftJoin(AnyEntity entity)
            => new UpdateEntitiesJoinExpressionBuilder<TEntity>(UpdateQueryExpression, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<UpdateEntitiesContinuation<TEntity>>> UpdateEntitiesContinuation<TEntity>.LeftJoin(AnySelectSubquery subquery)
            => new UpdateEntitiesJoinExpressionBuilder<TEntity>(UpdateQueryExpression, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<UpdateEntitiesContinuation<TEntity>> UpdateEntitiesContinuation<TEntity>.RightJoin(AnyEntity entity)
            => new UpdateEntitiesJoinExpressionBuilder<TEntity>(UpdateQueryExpression, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<UpdateEntitiesContinuation<TEntity>>> UpdateEntitiesContinuation<TEntity>.RightJoin(AnySelectSubquery subquery)
            => new UpdateEntitiesJoinExpressionBuilder<TEntity>(UpdateQueryExpression, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<UpdateEntitiesContinuation<TEntity>> UpdateEntitiesContinuation<TEntity>.FullJoin(AnyEntity entity)
            => new UpdateEntitiesJoinExpressionBuilder<TEntity>(UpdateQueryExpression, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        WithAlias<JoinOn<UpdateEntitiesContinuation<TEntity>>> UpdateEntitiesContinuation<TEntity>.FullJoin(AnySelectSubquery subquery)
            => new UpdateEntitiesJoinExpressionBuilder<TEntity>(UpdateQueryExpression, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        UpdateEntitiesContinuation<TEntity> UpdateEntitiesContinuation<TEntity>.CrossJoin(AnyEntity entity)
        {
            CrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        UpdateEntities<TEntity> UpdateEntities<TEntity>.Top(int value)
        {
            UpdateQueryExpression.Top = value;
            return this;
        }

        /// <inheritdoc />
        UpdateEntitiesContinuation<TEntity> UpdateEntities<TEntity>.From(Table<TEntity> entity)
            => new UpdateEntitiesUpdateQueryExpressionBuilder<TEntity>(UpdateQueryExpression, ExecutionPipelineFactory);

        #region UpdateEntitiesTermination
        /// <inheritdoc />
        int UpdateEntitiesTermination.Execute()
        {
            return ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        int UpdateEntitiesTermination.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        int UpdateEntitiesTermination.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        int UpdateEntitiesTermination.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        async Task<int> UpdateEntitiesTermination.ExecuteAsync(CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<int> UpdateEntitiesTermination.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<int> UpdateEntitiesTermination.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<int> UpdateEntitiesTermination.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        protected virtual int ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => ExecutionPipelineFactory().ExecuteUpdate(UpdateQueryExpression, connection, configureCommand);

        protected virtual async Task<int> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => await ExecutionPipelineFactory().ExecuteUpdateAsync(UpdateQueryExpression, connection, configureCommand, cancellationToken).ConfigureAwait(false);
        #endregion
        #endregion
    }
}
