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
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectValueSelectQueryExpressionBuilder<TDatabase, TValue> : SelectQueryExpressionBuilder<TDatabase>,
        SelectValue<TDatabase, TValue>,
        SelectValueContinuation<TDatabase, TValue>,
        WithAlias<SelectValueContinuation<TDatabase, TValue>>,
        SelectValueTermination<TDatabase, TValue>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region constructors
        public SelectValueSelectQueryExpressionBuilder(
            Func<ISelectQueryExecutionPipeline> executionPipelineFactory,
            SelectSetQueryExpressionBuilder<TDatabase> controller
        ) : base(executionPipelineFactory, controller)
        {

        }
        #endregion

        #region methods
        #region UnionSelectValuesInitiation<TDatabase>
        UnionSelectValuesContinuation<TDatabase, TValue> UnionSelectValuesInitiation<TDatabase, TValue>.Union()
        {
            Controller.ApplyUnion();
            return new SelectValuesSelectQueryExpressionBuilder<TDatabase, TValue>(
                ExecutionPipelineFactory,
                Controller
            );
        }

        UnionSelectValuesContinuation<TDatabase, TValue> UnionSelectValuesInitiation<TDatabase, TValue>.UnionAll()
        {
            Controller.ApplyUnionAll();
            return new SelectValuesSelectQueryExpressionBuilder<TDatabase, TValue>(
                ExecutionPipelineFactory,
                Controller
            );
        }
        #endregion

        #region SelectValue<TDatabase, TValue>
        /// <inheritdoc />
        SelectValueContinuation<TDatabase, TValue> SelectValue<TDatabase, TValue>.From<TEntity>(Table<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }

        /// <inheritdoc />
        WithAlias<SelectValueContinuation<TDatabase, TValue>> SelectValue<TDatabase, TValue>.From(AnySelectSubquery query)
        {
            ApplyFrom(query);
            return this;
        }
        #endregion

        #region SelectValueContinuation<TDatabase, TValue>
        /// <inheritdoc />
        SelectValueContinuation<TDatabase, TValue> SelectValueContinuation<TDatabase, TValue>.OrderBy(params AnyOrderByExpression[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectValueContinuation<TDatabase, TValue> SelectValueContinuation<TDatabase, TValue>.OrderBy(IEnumerable<AnyOrderByExpression>? orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectValueContinuation<TDatabase, TValue> SelectValueContinuation<TDatabase, TValue>.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectValueContinuation<TDatabase, TValue> SelectValueContinuation<TDatabase, TValue>.GroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectValueContinuation<TDatabase, TValue> SelectValueContinuation<TDatabase, TValue>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectValueContinuation<TDatabase, TValue> SelectValueContinuation<TDatabase, TValue>.Where(AnyWhereExpression? where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectValueContinuation<TDatabase, TValue>> SelectValueContinuation<TDatabase, TValue>.InnerJoin(AnyEntity entity)
            => new SelectValueJoinExpressionBuilder<TDatabase, TValue>(Controller.Current, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectValueContinuation<TDatabase, TValue>>> SelectValueContinuation<TDatabase, TValue>.InnerJoin(AnySelectSubquery subquery)
            => new SelectValueJoinExpressionBuilder<TDatabase, TValue>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectValueContinuation<TDatabase, TValue>> SelectValueContinuation<TDatabase, TValue>.LeftJoin(AnyEntity entity)
            => new SelectValueJoinExpressionBuilder<TDatabase, TValue>(Controller.Current, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectValueContinuation<TDatabase, TValue>>> SelectValueContinuation<TDatabase, TValue>.LeftJoin(AnySelectSubquery subquery)
            => new SelectValueJoinExpressionBuilder<TDatabase, TValue>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectValueContinuation<TDatabase, TValue>> SelectValueContinuation<TDatabase, TValue>.RightJoin(AnyEntity entity)
            => new SelectValueJoinExpressionBuilder<TDatabase, TValue>(Controller.Current, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectValueContinuation<TDatabase, TValue>>> SelectValueContinuation<TDatabase, TValue>.RightJoin(AnySelectSubquery subquery)
            => new SelectValueJoinExpressionBuilder<TDatabase, TValue>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectValueContinuation<TDatabase, TValue>> SelectValueContinuation<TDatabase, TValue>.FullJoin(AnyEntity entity)
            => new SelectValueJoinExpressionBuilder<TDatabase, TValue>(Controller.Current, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectValueContinuation<TDatabase, TValue>>> SelectValueContinuation<TDatabase, TValue>.FullJoin(AnySelectSubquery subquery)
            => new SelectValueJoinExpressionBuilder<TDatabase, TValue>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectValueContinuation<TDatabase, TValue> SelectValueContinuation<TDatabase, TValue>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        SelectValueContinuation<TDatabase, TValue> WithAlias<SelectValueContinuation<TDatabase, TValue>>.As(string alias)
        {
            Controller.Current.From!.As(alias);
            return this;
        }
        #endregion

        #region SelectValueTermination<TDatabase, TValue>
        /// <inheritdoc />
        TValue? SelectValueTermination<TDatabase, TValue>.Execute()
        {
            return ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        TValue? SelectValueTermination<TDatabase, TValue>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        TValue? SelectValueTermination<TDatabase, TValue>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        TValue? SelectValueTermination<TDatabase, TValue>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        async Task<TValue?> SelectValueTermination<TDatabase, TValue>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TValue?> SelectValueTermination<TDatabase, TValue>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        async Task<TValue?> SelectValueTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TValue?> SelectValueTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        protected virtual TValue? ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => ExecutionPipelineFactory().ExecuteSelectValue<TValue>(Controller.Current, connection, configureCommand);

        protected virtual async Task<TValue?> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => await ExecutionPipelineFactory().ExecuteSelectValueAsync<TValue>(Controller.Current, connection, configureCommand, cancellationToken).ConfigureAwait(false);
        #endregion
        #endregion
    }
}
