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
    public class SelectObjectSelectQueryExpressionBuilder<TDatabase, TObject> : SelectQueryExpressionBuilder<TDatabase>,
        SelectObject<TDatabase, TObject>,
        SelectObjectContinuation<TDatabase, TObject>,
        WithAlias<SelectObjectContinuation<TDatabase, TObject>>,
        SelectObjectTermination<TDatabase, TObject>
        where TDatabase : class, ISqlDatabaseRuntime
        where TObject : class?
    {
        #region constructors
        public SelectObjectSelectQueryExpressionBuilder(
            IQueryExpressionFactory queryExpressionFactory,
            IQueryExpressionExecutionPipelineFactory executionPipelineFactory,
            ObjectElement<TObject> element
        ) : base(queryExpressionFactory, executionPipelineFactory)
        {
            ApplyTop(1);
            Current.Select = new(element.ToSelectExpression() ?? throw new ArgumentNullException(nameof(element)));
        }

        public SelectObjectSelectQueryExpressionBuilder(
            IQueryExpressionFactory queryExpressionFactory,
            IQueryExpressionExecutionPipelineFactory executionPipelineFactory,
            SelectQueryExpression rootExpression,
            SelectQueryExpression currentExpression
        ) : base(queryExpressionFactory, executionPipelineFactory, rootExpression, currentExpression)
        {
            ApplyTop(1);
        }
        #endregion

        #region methods
        #region UnionSelectObjectsInitiation<TDatabase>
        UnionSelectObjectsContinuation<TDatabase, TObject> UnionSelectObjectsInitiation<TDatabase, TObject>.Union()
        {
            ApplyUnion();
            return new SelectObjectsSelectQueryExpressionBuilder<TDatabase, TObject>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                SelectQueryExpression,
                Current
            );
        }

        UnionSelectObjectsContinuation<TDatabase, TObject> UnionSelectObjectsInitiation<TDatabase, TObject>.UnionAll()
        {
            ApplyUnion();
            return new SelectObjectsSelectQueryExpressionBuilder<TDatabase, TObject>(
                QueryExpressionFactory,
                ExecutionPipelineFactory,
                SelectQueryExpression,
                Current
            );
        }
        #endregion

        #region SelectObject<TDatabase, TObject>
        /// <inheritdoc />
        SelectObjectContinuation<TDatabase, TObject> SelectObject<TDatabase, TObject>.From<TEntity>(Table<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }

        /// <inheritdoc />
        WithAlias<SelectObjectContinuation<TDatabase, TObject>> SelectObject<TDatabase, TObject>.From(AnySelectSubquery query)
        {
            ApplyFrom(query);
            return this;
        }
        #endregion

        #region SelectObjectContinuation<TDatabase, TObject>
        /// <inheritdoc />
        SelectObjectContinuation<TDatabase, TObject> SelectObjectContinuation<TDatabase, TObject>.OrderBy(params AnyOrderByExpression[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectContinuation<TDatabase, TObject> SelectObjectContinuation<TDatabase, TObject>.OrderBy(IEnumerable<AnyOrderByExpression>? orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectContinuation<TDatabase, TObject> SelectObjectContinuation<TDatabase, TObject>.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectContinuation<TDatabase, TObject> SelectObjectContinuation<TDatabase, TObject>.GroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectContinuation<TDatabase, TObject> SelectObjectContinuation<TDatabase, TObject>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectObjectContinuation<TDatabase, TObject> SelectObjectContinuation<TDatabase, TObject>.Where(AnyWhereExpression? where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectObjectContinuation<TDatabase, TObject>> SelectObjectContinuation<TDatabase, TObject>.InnerJoin(AnyEntity entity)
            => new SelectObjectJoinExpressionBuilder<TDatabase, TObject>(Current, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectObjectContinuation<TDatabase, TObject>>> SelectObjectContinuation<TDatabase, TObject>.InnerJoin(AnySelectSubquery subquery)
            => new SelectObjectJoinExpressionBuilder<TDatabase, TObject>(Current, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectObjectContinuation<TDatabase, TObject>> SelectObjectContinuation<TDatabase, TObject>.LeftJoin(AnyEntity entity)
            => new SelectObjectJoinExpressionBuilder<TDatabase, TObject>(Current, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectObjectContinuation<TDatabase, TObject>>> SelectObjectContinuation<TDatabase, TObject>.LeftJoin(AnySelectSubquery subquery)
            => new SelectObjectJoinExpressionBuilder<TDatabase, TObject>(Current, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectObjectContinuation<TDatabase, TObject>> SelectObjectContinuation<TDatabase, TObject>.RightJoin(AnyEntity entity)
            => new SelectObjectJoinExpressionBuilder<TDatabase, TObject>(Current, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectObjectContinuation<TDatabase, TObject>>> SelectObjectContinuation<TDatabase, TObject>.RightJoin(AnySelectSubquery subquery)
            => new SelectObjectJoinExpressionBuilder<TDatabase, TObject>(Current, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectObjectContinuation<TDatabase, TObject>> SelectObjectContinuation<TDatabase, TObject>.FullJoin(AnyEntity entity)
            => new SelectObjectJoinExpressionBuilder<TDatabase, TObject>(Current, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectObjectContinuation<TDatabase, TObject>>> SelectObjectContinuation<TDatabase, TObject>.FullJoin(AnySelectSubquery subquery)
            => new SelectObjectJoinExpressionBuilder<TDatabase, TObject>(Current, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectObjectContinuation<TDatabase, TObject> SelectObjectContinuation<TDatabase, TObject>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        SelectObjectContinuation<TDatabase, TObject> WithAlias<SelectObjectContinuation<TDatabase, TObject>>.As(string alias)
        {
            Current.From!.As(alias);
            return this;
        }
        #endregion

        #region SelectObjectTermination<TDatabase, TObject>
        /// <inheritdoc />
        TObject? SelectObjectTermination<TDatabase, TObject>.Execute()
        {
            return ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        TObject? SelectObjectTermination<TDatabase, TObject>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        TObject? SelectObjectTermination<TDatabase, TObject>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        TObject? SelectObjectTermination<TDatabase, TObject>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        Task<TObject?> SelectObjectTermination<TDatabase, TObject>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<TObject?> SelectObjectTermination<TDatabase, TObject>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        Task<TObject?> SelectObjectTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
        Task<TObject?> SelectObjectTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        private TObject? ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => ExecutionPipelineFactory.CreateSelectQueryExecutionPipeline().ExecuteSelectValue<TObject>(Current, connection, configureCommand);

        private Task<TObject?> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => ExecutionPipelineFactory.CreateSelectQueryExecutionPipeline().ExecuteSelectValueAsync<TObject>(Current, connection, configureCommand, cancellationToken);

        #endregion
        #endregion
    }
}
