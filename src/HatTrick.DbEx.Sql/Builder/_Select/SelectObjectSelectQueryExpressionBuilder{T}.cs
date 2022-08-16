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
    public class SelectObjectSelectQueryExpressionBuilder<TObject> : SelectQueryExpressionBuilder,
        SelectObject<TObject>,
        SelectObjectContinuation<TObject>,
        WithAlias<SelectObjectContinuation<TObject>>,
        SelectObjectTermination<TObject>
        where TObject : class?
    {
        #region constructors
        public SelectObjectSelectQueryExpressionBuilder(
            Func<ISelectQueryExecutionPipeline> executionPipelineFactory,
            SelectSetQueryExpressionBuilder controller
        ) : base(executionPipelineFactory, controller)
        {

        }
        #endregion

        #region methods
        #region UnionSelectObjectsInitiation
        UnionSelectObjectsContinuation<TObject> UnionSelectObjectsInitiation<TObject>.Union()
        {
            Controller.ApplyUnion();
            return new SelectObjectsSelectQueryExpressionBuilder<TObject>(
                ExecutionPipelineFactory,
                Controller
            );
        }

        UnionSelectObjectsContinuation<TObject> UnionSelectObjectsInitiation<TObject>.UnionAll()
        {
            Controller.ApplyUnion();
            return new SelectObjectsSelectQueryExpressionBuilder<TObject>(
                ExecutionPipelineFactory,
                Controller
            );
        }
        #endregion

        #region SelectObject<TObject>
        /// <inheritdoc />
        SelectObjectContinuation<TObject> SelectObject<TObject>.From<TEntity>(Table<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }

        /// <inheritdoc />
        WithAlias<SelectObjectContinuation<TObject>> SelectObject<TObject>.From(AnySelectSubquery query)
        {
            ApplyFrom(query);
            return this;
        }
        #endregion

        #region SelectObjectContinuation<TObject>
        /// <inheritdoc />
        SelectObjectContinuation<TObject> SelectObjectContinuation<TObject>.OrderBy(params AnyOrderByExpression[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectContinuation<TObject> SelectObjectContinuation<TObject>.OrderBy(IEnumerable<AnyOrderByExpression>? orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectContinuation<TObject> SelectObjectContinuation<TObject>.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectContinuation<TObject> SelectObjectContinuation<TObject>.GroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectContinuation<TObject> SelectObjectContinuation<TObject>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectObjectContinuation<TObject> SelectObjectContinuation<TObject>.Where(AnyWhereExpression? where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectObjectContinuation<TObject>> SelectObjectContinuation<TObject>.InnerJoin(AnyEntity entity)
            => new SelectObjectJoinExpressionBuilder<TObject>(Controller.Current, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectObjectContinuation<TObject>>> SelectObjectContinuation<TObject>.InnerJoin(AnySelectSubquery subquery)
            => new SelectObjectJoinExpressionBuilder<TObject>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectObjectContinuation<TObject>> SelectObjectContinuation<TObject>.LeftJoin(AnyEntity entity)
            => new SelectObjectJoinExpressionBuilder<TObject>(Controller.Current, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectObjectContinuation<TObject>>> SelectObjectContinuation<TObject>.LeftJoin(AnySelectSubquery subquery)
            => new SelectObjectJoinExpressionBuilder<TObject>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectObjectContinuation<TObject>> SelectObjectContinuation<TObject>.RightJoin(AnyEntity entity)
            => new SelectObjectJoinExpressionBuilder<TObject>(Controller.Current, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectObjectContinuation<TObject>>> SelectObjectContinuation<TObject>.RightJoin(AnySelectSubquery subquery)
            => new SelectObjectJoinExpressionBuilder<TObject>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectObjectContinuation<TObject>> SelectObjectContinuation<TObject>.FullJoin(AnyEntity entity)
            => new SelectObjectJoinExpressionBuilder<TObject>(Controller.Current, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectObjectContinuation<TObject>>> SelectObjectContinuation<TObject>.FullJoin(AnySelectSubquery subquery)
            => new SelectObjectJoinExpressionBuilder<TObject>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectObjectContinuation<TObject> SelectObjectContinuation<TObject>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        SelectObjectContinuation<TObject> WithAlias<SelectObjectContinuation<TObject>>.As(string alias)
        {
            Controller.Current.From!.As(alias);
            return this;
        }
        #endregion

        #region SelectObjectTermination<TObject>
        /// <inheritdoc />
        TObject? SelectObjectTermination<TObject>.Execute()
        {
            return ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        TObject? SelectObjectTermination<TObject>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        TObject? SelectObjectTermination<TObject>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        TObject? SelectObjectTermination<TObject>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        async Task<TObject?> SelectObjectTermination<TObject>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TObject?> SelectObjectTermination<TObject>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        async Task<TObject?> SelectObjectTermination<TObject>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TObject?> SelectObjectTermination<TObject>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        protected virtual TObject? ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => ExecutionPipelineFactory().ExecuteSelectValue<TObject>(Controller.Current, connection, configureCommand);

        protected virtual async Task<TObject?> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => await ExecutionPipelineFactory().ExecuteSelectValueAsync<TObject>(Controller.Current, connection, configureCommand, cancellationToken).ConfigureAwait(false);

        #endregion
        #endregion
    }
}
