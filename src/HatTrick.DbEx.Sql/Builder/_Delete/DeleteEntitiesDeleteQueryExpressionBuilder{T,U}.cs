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
    public class DeleteEntitiesDeleteQueryExpressionBuilder<TDatabase, TEntity> : DeleteQueryExpressionBuilder<TDatabase>,
        IExpressionBuilder<TDatabase, TEntity>,
        DeleteEntitiesContinuation<TDatabase, TEntity>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, IDbEntity
    {
        #region constructors
        public DeleteEntitiesDeleteQueryExpressionBuilder(
            ISqlDatabaseRuntime database,
            DeleteQueryExpression expression,
            Func<IDeleteQueryExecutionPipeline<TDatabase>> executionPipelineFactory,
            Table<TEntity> entity
        ) : base(database, expression, executionPipelineFactory)
        {
            expression.From = entity ?? throw new ArgumentNullException(nameof(entity));
        }
        #endregion

        #region methods
        /// <inheritdoc />
        DeleteEntitiesContinuation<TDatabase, TEntity> DeleteEntitiesContinuation<TDatabase, TEntity>.Where(AnyWhereExpression where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<DeleteEntitiesContinuation<TDatabase, TEntity>> DeleteEntitiesContinuation<TDatabase, TEntity>.InnerJoin(AnyEntity entity)
            => new DeleteEntitiesJoinExpressionBuilder<TDatabase, TEntity>(DeleteQueryExpression, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        WithAlias<JoinOn<DeleteEntitiesContinuation<TDatabase, TEntity>>> DeleteEntitiesContinuation<TDatabase, TEntity>.InnerJoin(AnySelectSubquery subquery)
            => new DeleteEntitiesJoinExpressionBuilder<TDatabase, TEntity>(DeleteQueryExpression, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<DeleteEntitiesContinuation<TDatabase, TEntity>> DeleteEntitiesContinuation<TDatabase, TEntity>.LeftJoin(AnyEntity entity)
            => new DeleteEntitiesJoinExpressionBuilder<TDatabase, TEntity>(DeleteQueryExpression, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<DeleteEntitiesContinuation<TDatabase, TEntity>>> DeleteEntitiesContinuation<TDatabase, TEntity>.LeftJoin(AnySelectSubquery subquery)
            => new DeleteEntitiesJoinExpressionBuilder<TDatabase, TEntity>(DeleteQueryExpression, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<DeleteEntitiesContinuation<TDatabase, TEntity>> DeleteEntitiesContinuation<TDatabase, TEntity>.RightJoin(AnyEntity entity)
            => new DeleteEntitiesJoinExpressionBuilder<TDatabase, TEntity>(DeleteQueryExpression, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<DeleteEntitiesContinuation<TDatabase, TEntity>>> DeleteEntitiesContinuation<TDatabase, TEntity>.RightJoin(AnySelectSubquery subquery)
            => new DeleteEntitiesJoinExpressionBuilder<TDatabase, TEntity>(DeleteQueryExpression, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<DeleteEntitiesContinuation<TDatabase, TEntity>> DeleteEntitiesContinuation<TDatabase, TEntity>.FullJoin(AnyEntity entity)
            => new DeleteEntitiesJoinExpressionBuilder<TDatabase, TEntity>(DeleteQueryExpression, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        WithAlias<JoinOn<DeleteEntitiesContinuation<TDatabase, TEntity>>> DeleteEntitiesContinuation<TDatabase, TEntity>.FullJoin(AnySelectSubquery subquery)
            => new DeleteEntitiesJoinExpressionBuilder<TDatabase, TEntity>(DeleteQueryExpression, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        DeleteEntitiesContinuation<TDatabase, TEntity> DeleteEntitiesContinuation<TDatabase, TEntity>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        #region DeleteEntitiesTermination
        /// <inheritdoc />
        int DeleteEntitiesTermination<TDatabase>.Execute()
        {
            using var connection = Database.GetConnection();
            return ExecutePipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
        int DeleteEntitiesTermination<TDatabase>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = Database.GetConnection();
            return ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        int DeleteEntitiesTermination<TDatabase>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        int DeleteEntitiesTermination<TDatabase>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        async Task<int> DeleteEntitiesTermination<TDatabase>.ExecuteAsync(CancellationToken cancellationToken)
        {
            using var connection = Database.GetConnection();
            return await ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<int> DeleteEntitiesTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<int> DeleteEntitiesTermination<TDatabase>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = Database.GetConnection();
            return await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<int> DeleteEntitiesTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        protected virtual int ExecutePipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand)
            => ExecutionPipelineFactory().ExecuteDelete(DeleteQueryExpression, connection, configureCommand);

        protected virtual async Task<int> ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => await ExecutionPipelineFactory().ExecuteDeleteAsync(DeleteQueryExpression, connection, configureCommand, cancellationToken).ConfigureAwait(false);
        #endregion
        #endregion
    }
}
