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

using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectValueSelectQueryExpressionBuilder<TValue> : SelectValueSelectQueryExpressionBuilder,
        IExpressionBuilder<TValue>,
        SelectValue<TValue>,
        SelectValueContinuation<TValue>
    {
        #region constructors
        public SelectValueSelectQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, SelectQueryExpression expression) : base(config, expression)
        {

        }
        #endregion

        #region methods
        /// <inheritdoc />
        SelectValueContinuation<TValue> SelectValue<TValue>.From<TEntity>(Table<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }

        /// <inheritdoc />
        SelectValueContinuation<TValue> SelectValueContinuation<TValue>.OrderBy(params AnyOrderByClause[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectValueContinuation<TValue> SelectValueContinuation<TValue>.OrderBy(IEnumerable<AnyOrderByClause>? orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectValueContinuation<TValue> SelectValueContinuation<TValue>.GroupBy(params AnyGroupByClause[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectValueContinuation<TValue> SelectValueContinuation<TValue>.GroupBy(IEnumerable<AnyGroupByClause>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectValueContinuation<TValue> SelectValueContinuation<TValue>.Having(AnyHavingClause? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectValueContinuation<TValue> SelectValueContinuation<TValue>.Where(AnyWhereClause? where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectValueContinuation<TValue>> SelectValueContinuation<TValue>.InnerJoin(AnyEntity entity)
            => new SelectValueJoinBuilder<TValue>(Expression, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectValueContinuation<TValue>> SelectValueContinuation<TValue>.InnerJoin(AnySelectSubquery subquery)
            => new SelectValueJoinBuilder<TValue>(Expression, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectValueContinuation<TValue>> SelectValueContinuation<TValue>.LeftJoin(AnyEntity entity)
            => new SelectValueJoinBuilder<TValue>(Expression, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectValueContinuation<TValue>> SelectValueContinuation<TValue>.LeftJoin(AnySelectSubquery subquery)
            => new SelectValueJoinBuilder<TValue>(Expression, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectValueContinuation<TValue>> SelectValueContinuation<TValue>.RightJoin(AnyEntity entity)
            => new SelectValueJoinBuilder<TValue>(Expression, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectValueContinuation<TValue>> SelectValueContinuation<TValue>.RightJoin(AnySelectSubquery subquery)
            => new SelectValueJoinBuilder<TValue>(Expression, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectValueContinuation<TValue>> SelectValueContinuation<TValue>.FullJoin(AnyEntity entity)
            => new SelectValueJoinBuilder<TValue>(Expression, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectValueContinuation<TValue>> SelectValueContinuation<TValue>.FullJoin(AnySelectSubquery subquery)
            => new SelectValueJoinBuilder<TValue>(Expression, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectValueContinuation<TValue> SelectValueContinuation<TValue>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }
        #endregion

        #region SelectValueTermination<TValue>
        /// <inheritdoc />
        TValue? SelectValueTermination<TValue>.Execute()
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecutePipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
        TValue? SelectValueTermination<TValue>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        TValue? SelectValueTermination<TValue>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        TValue? SelectValueTermination<TValue>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        async Task<TValue?> SelectValueTermination<TValue>.ExecuteAsync(CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TValue?> SelectValueTermination<TValue>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TValue?> SelectValueTermination<TValue>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TValue?> SelectValueTermination<TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        protected virtual TValue? ExecutePipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand)
            => CreateSelectExecutionPipeline().ExecuteSelectValue<TValue>(Expression, connection, configureCommand);

        protected virtual async Task<TValue?> ExecutePipelineAsync( ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => await CreateSelectExecutionPipeline().ExecuteSelectValueAsync<TValue>(Expression, connection, configureCommand, cancellationToken).ConfigureAwait(false);

        protected virtual ISelectQueryExpressionExecutionPipeline CreateSelectExecutionPipeline()
        {
            return Configuration.ExecutionPipelineFactory?.CreateQueryExecutionPipeline(Configuration, Expression) ?? throw new DbExpressionConfigurationException($"Could not resolve/create an execution pipeline for type '{GetType()}',  please review and ensure the correct configuration for DbExpression.");
        }
        #endregion
    }
}
