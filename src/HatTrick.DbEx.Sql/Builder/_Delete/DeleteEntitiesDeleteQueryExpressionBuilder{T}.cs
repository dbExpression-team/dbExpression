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
    public class DeleteEntitiesDeleteQueryExpressionBuilder<TEntity> : DeleteQueryExpressionBuilder,
        IExpressionBuilder<TEntity>,
        DeleteEntitiesContinuation<TEntity>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public DeleteEntitiesDeleteQueryExpressionBuilder(
            DeleteQueryExpression expression,
            Func<IDeleteQueryExecutionPipeline> executionPipelineFactory,
            Table<TEntity> entity
        ) : base(expression, executionPipelineFactory)
        {
            expression.From = entity ?? throw new ArgumentNullException(nameof(entity));
        }
        #endregion

        #region methods
        /// <inheritdoc />
        DeleteEntitiesContinuation<TEntity> DeleteEntitiesContinuation<TEntity>.Where(AnyWhereExpression where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<DeleteEntitiesContinuation<TEntity>> DeleteEntitiesContinuation<TEntity>.InnerJoin(AnyEntity entity)
            => new DeleteEntitiesJoinExpressionBuilder<TEntity>(DeleteQueryExpression, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        WithAlias<JoinOn<DeleteEntitiesContinuation<TEntity>>> DeleteEntitiesContinuation<TEntity>.InnerJoin(AnySelectSubquery subquery)
            => new DeleteEntitiesJoinExpressionBuilder<TEntity>(DeleteQueryExpression, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<DeleteEntitiesContinuation<TEntity>> DeleteEntitiesContinuation<TEntity>.LeftJoin(AnyEntity entity)
            => new DeleteEntitiesJoinExpressionBuilder<TEntity>(DeleteQueryExpression, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<DeleteEntitiesContinuation<TEntity>>> DeleteEntitiesContinuation<TEntity>.LeftJoin(AnySelectSubquery subquery)
            => new DeleteEntitiesJoinExpressionBuilder<TEntity>(DeleteQueryExpression, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<DeleteEntitiesContinuation<TEntity>> DeleteEntitiesContinuation<TEntity>.RightJoin(AnyEntity entity)
            => new DeleteEntitiesJoinExpressionBuilder<TEntity>(DeleteQueryExpression, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<DeleteEntitiesContinuation<TEntity>>> DeleteEntitiesContinuation<TEntity>.RightJoin(AnySelectSubquery subquery)
            => new DeleteEntitiesJoinExpressionBuilder<TEntity>(DeleteQueryExpression, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<DeleteEntitiesContinuation<TEntity>> DeleteEntitiesContinuation<TEntity>.FullJoin(AnyEntity entity)
            => new DeleteEntitiesJoinExpressionBuilder<TEntity>(DeleteQueryExpression, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        WithAlias<JoinOn<DeleteEntitiesContinuation<TEntity>>> DeleteEntitiesContinuation<TEntity>.FullJoin(AnySelectSubquery subquery)
            => new DeleteEntitiesJoinExpressionBuilder<TEntity>(DeleteQueryExpression, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        DeleteEntitiesContinuation<TEntity> DeleteEntitiesContinuation<TEntity>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        #region DeleteEntitiesTermination
        /// <inheritdoc />
        int DeleteEntitiesTermination.Execute()
        {
            return ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        int DeleteEntitiesTermination.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        int DeleteEntitiesTermination.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        int DeleteEntitiesTermination.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        async Task<int> DeleteEntitiesTermination.ExecuteAsync(CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<int> DeleteEntitiesTermination.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<int> DeleteEntitiesTermination.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        async Task<int> DeleteEntitiesTermination.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
            => ExecutionPipelineFactory().ExecuteDelete(DeleteQueryExpression, connection, configureCommand);

        protected virtual async Task<int> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => await ExecutionPipelineFactory().ExecuteDeleteAsync(DeleteQueryExpression, connection, configureCommand, cancellationToken).ConfigureAwait(false);
        #endregion
        #endregion
    }
}
