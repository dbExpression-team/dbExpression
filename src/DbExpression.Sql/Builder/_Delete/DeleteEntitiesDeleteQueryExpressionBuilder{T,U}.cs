#region license
// Copyright (c) dbExpression.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion

using DbExpression.Sql.Connection;
using DbExpression.Sql.Expression;
using DbExpression.Sql.Pipeline;
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DbExpression.Sql.Builder
{
    public class DeleteEntitiesDeleteQueryExpressionBuilder<TDatabase, TEntity> : DeleteQueryExpressionBuilder<TDatabase>,
        IExpressionBuilder<TDatabase, TEntity>,
        DeleteEntitiesContinuation<TDatabase, TEntity>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, IDbEntity
    {
        #region constructors
        public DeleteEntitiesDeleteQueryExpressionBuilder(
            IQueryExpressionFactory queryExpressionFactory,
            IQueryExpressionExecutionPipelineFactory executionPipelineFactory,
            DeleteQueryExpression expression,
            Table<TEntity> entity
        ) : base(queryExpressionFactory, executionPipelineFactory, expression)
        {
            expression.From = entity ?? throw new ArgumentNullException(nameof(entity));
        }
        #endregion

        #region methods
        /// <inheritdoc />
        DeleteEntitiesContinuation<TDatabase, TEntity> DeleteEntitiesContinuation<TDatabase, TEntity>.Where(AnyWhereExpression where)
        {
            if (where is null)
                return this;

            if (where is FilterExpression single)
            {
                if (DeleteQueryExpression.Where is null)
                    DeleteQueryExpression.Where = new(single);
                else
                    DeleteQueryExpression.Where &= single;
            }
            else if (where is FilterExpressionSet set)
            {
                if (where is IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements> provider && provider.Expression?.Args is not null && provider.Expression.Args.Any())
                {
                    if (DeleteQueryExpression.Where is null)
                        DeleteQueryExpression.Where = set;
                    else
                        DeleteQueryExpression.Where &= set;
                }
            }
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
            DeleteQueryExpression.Joins = DeleteQueryExpression.Joins is null ?
                new JoinExpressionSet(new JoinExpression(entity, JoinOperationExpressionOperator.CROSS, null))
                :
                new JoinExpressionSet(DeleteQueryExpression.Joins.Expressions.Concat(new JoinExpression[1] { new JoinExpression(entity, JoinOperationExpressionOperator.CROSS, null) }));

            return this;
        }

        #region DeleteEntitiesTermination
        /// <inheritdoc />
        int DeleteEntitiesTermination<TDatabase>.Execute()
        {
            return ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        int DeleteEntitiesTermination<TDatabase>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
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
        ValueTask<int> DeleteEntitiesTermination<TDatabase>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        ValueTask<int> DeleteEntitiesTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        ValueTask<int> DeleteEntitiesTermination<TDatabase>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        ValueTask<int> DeleteEntitiesTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
            => ExecutionPipelineFactory.CreateDeleteQueryExecutionPipeline().ExecuteDelete(DeleteQueryExpression, connection, configureCommand);

        private ValueTask<int> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => ExecutionPipelineFactory.CreateDeleteQueryExecutionPipeline().ExecuteDeleteAsync(DeleteQueryExpression, connection, configureCommand, cancellationToken);
        #endregion
        #endregion
    }
}
