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
    public class UpdateEntitiesUpdateQueryExpressionBuilder<TDatabase, TEntity> : UpdateQueryExpressionBuilder<TDatabase>,
        IExpressionBuilder<TDatabase, TEntity>,
        UpdateEntities<TDatabase, TEntity>,
        UpdateEntitiesContinuation<TDatabase, TEntity>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, IDbEntity
    {
        #region constructors
        public UpdateEntitiesUpdateQueryExpressionBuilder(
            UpdateQueryExpression expression,
            Func<IUpdateQueryExpressionExecutionPipeline> executionPipelineFactory
        ) : base(expression, executionPipelineFactory)
        {

        }
        #endregion

        #region methods
        /// <inheritdoc />
        UpdateEntitiesContinuation<TDatabase, TEntity> UpdateEntitiesContinuation<TDatabase, TEntity>.Where(AnyWhereExpression where)
        {
            Where(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<UpdateEntitiesContinuation<TDatabase, TEntity>> UpdateEntitiesContinuation<TDatabase, TEntity>.InnerJoin(AnyEntity entity)
            => new UpdateEntitiesJoinExpressionBuilder<TDatabase, TEntity>(UpdateQueryExpression, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        WithAlias<JoinOn<UpdateEntitiesContinuation<TDatabase, TEntity>>> UpdateEntitiesContinuation<TDatabase, TEntity>.InnerJoin(AnySelectSubquery subquery)
            => new UpdateEntitiesJoinExpressionBuilder<TDatabase, TEntity>(UpdateQueryExpression, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<UpdateEntitiesContinuation<TDatabase, TEntity>> UpdateEntitiesContinuation<TDatabase, TEntity>.LeftJoin(AnyEntity entity)
            => new UpdateEntitiesJoinExpressionBuilder<TDatabase, TEntity>(UpdateQueryExpression, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<UpdateEntitiesContinuation<TDatabase, TEntity>>> UpdateEntitiesContinuation<TDatabase, TEntity>.LeftJoin(AnySelectSubquery subquery)
            => new UpdateEntitiesJoinExpressionBuilder<TDatabase, TEntity>(UpdateQueryExpression, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<UpdateEntitiesContinuation<TDatabase, TEntity>> UpdateEntitiesContinuation<TDatabase, TEntity>.RightJoin(AnyEntity entity)
            => new UpdateEntitiesJoinExpressionBuilder<TDatabase, TEntity>(UpdateQueryExpression, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<UpdateEntitiesContinuation<TDatabase, TEntity>>> UpdateEntitiesContinuation<TDatabase, TEntity>.RightJoin(AnySelectSubquery subquery)
            => new UpdateEntitiesJoinExpressionBuilder<TDatabase, TEntity>(UpdateQueryExpression, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<UpdateEntitiesContinuation<TDatabase, TEntity>> UpdateEntitiesContinuation<TDatabase, TEntity>.FullJoin(AnyEntity entity)
            => new UpdateEntitiesJoinExpressionBuilder<TDatabase, TEntity>(UpdateQueryExpression, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        WithAlias<JoinOn<UpdateEntitiesContinuation<TDatabase, TEntity>>> UpdateEntitiesContinuation<TDatabase, TEntity>.FullJoin(AnySelectSubquery subquery)
            => new UpdateEntitiesJoinExpressionBuilder<TDatabase, TEntity>(UpdateQueryExpression, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        UpdateEntitiesContinuation<TDatabase, TEntity> UpdateEntitiesContinuation<TDatabase, TEntity>.CrossJoin(AnyEntity entity)
        {
            CrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        UpdateEntities<TDatabase, TEntity> UpdateEntities<TDatabase, TEntity>.Top(int value)
        {
            UpdateQueryExpression.Top = value;
            return this;
        }

        /// <inheritdoc />
        UpdateEntitiesContinuation<TDatabase, TEntity> UpdateEntities<TDatabase, TEntity>.From(Table<TEntity> entity)
            => new UpdateEntitiesUpdateQueryExpressionBuilder<TDatabase, TEntity>(UpdateQueryExpression, ExecutionPipelineFactory);

        #region UpdateEntitiesTermination
        /// <inheritdoc />
        int UpdateEntitiesTermination<TDatabase>.Execute()
        {
            return ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        int UpdateEntitiesTermination<TDatabase>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        int UpdateEntitiesTermination<TDatabase>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        int UpdateEntitiesTermination<TDatabase>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        ValueTask<int> UpdateEntitiesTermination<TDatabase>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        ValueTask<int> UpdateEntitiesTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        ValueTask<int> UpdateEntitiesTermination<TDatabase>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        /// <inheritdoc />
        ValueTask<int> UpdateEntitiesTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        private int ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => ExecutionPipelineFactory().ExecuteUpdate(UpdateQueryExpression, connection, configureCommand);

        private ValueTask<int> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => ExecutionPipelineFactory().ExecuteUpdateAsync(UpdateQueryExpression, connection, configureCommand, cancellationToken);
        #endregion
        #endregion
    }
}
