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
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectObjectSelectQueryExpressionBuilder<TDatabase, TObject> : SelectQueryExpressionBuilder<TDatabase>,
        SelectObject<TDatabase, TObject>,
        SelectObjectContinuation<TDatabase, TObject>,
        SelectObjectTermination<TDatabase, TObject>
        where TDatabase : class, ISqlDatabaseRuntime
        where TObject : class?
    {
        #region internals
        private readonly Func<SelectObjectTermination<TDatabase, TObject>> _executor;
        private SelectObjectTermination<TDatabase, TObject> Executor => _executor();
        #endregion

        #region constructors
        public SelectObjectSelectQueryExpressionBuilder(
            SelectQueryExpression expression,
            SqlDatabaseRuntimeConfiguration config,
            Func<UnionSelectAnyInitiation<TDatabase>> union,
            Func<SelectObjectTermination<TDatabase, TObject>> executor
        ) : base(expression, config, union)
        {
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        }
        #endregion

        #region methods
        #region SelectObject<TDatabase, TObject>
        /// <inheritdoc />
        SelectObjectContinuation<TDatabase, TObject> SelectObject<TDatabase, TObject>.From<TEntity>(Table<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }
        #endregion

        #region SelectObjectContinuation<TDatabase, TObject>
        /// <inheritdoc />
        SelectObjectContinuation<TDatabase, TObject> SelectObjectContinuation<TDatabase, TObject>.OrderBy(params AnyOrderByClause[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectContinuation<TDatabase, TObject> SelectObjectContinuation<TDatabase, TObject>.OrderBy(IEnumerable<AnyOrderByClause>? orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectContinuation<TDatabase, TObject> SelectObjectContinuation<TDatabase, TObject>.GroupBy(params AnyGroupByClause[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectContinuation<TDatabase, TObject> SelectObjectContinuation<TDatabase, TObject>.GroupBy(IEnumerable<AnyGroupByClause>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectContinuation<TDatabase, TObject> SelectObjectContinuation<TDatabase, TObject>.Having(AnyHavingClause? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectObjectContinuation<TDatabase, TObject> SelectObjectContinuation<TDatabase, TObject>.Where(AnyWhereClause? where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectObjectContinuation<TDatabase, TObject>> SelectObjectContinuation<TDatabase, TObject>.InnerJoin(AnyEntity entity)
            => new SelectObjectJoinExpressionBuilder<TDatabase, TObject>(SelectQueryExpression, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectObjectContinuation<TDatabase, TObject>> SelectObjectContinuation<TDatabase, TObject>.InnerJoin(AnySelectSubquery subquery)
            => new SelectObjectJoinExpressionBuilder<TDatabase, TObject>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectObjectContinuation<TDatabase, TObject>> SelectObjectContinuation<TDatabase, TObject>.LeftJoin(AnyEntity entity)
            => new SelectObjectJoinExpressionBuilder<TDatabase, TObject>(SelectQueryExpression, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectObjectContinuation<TDatabase, TObject>> SelectObjectContinuation<TDatabase, TObject>.LeftJoin(AnySelectSubquery subquery)
            => new SelectObjectJoinExpressionBuilder<TDatabase, TObject>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectObjectContinuation<TDatabase, TObject>> SelectObjectContinuation<TDatabase, TObject>.RightJoin(AnyEntity entity)
            => new SelectObjectJoinExpressionBuilder<TDatabase, TObject>(SelectQueryExpression, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectObjectContinuation<TDatabase, TObject>> SelectObjectContinuation<TDatabase, TObject>.RightJoin(AnySelectSubquery subquery)
            => new SelectObjectJoinExpressionBuilder<TDatabase, TObject>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectObjectContinuation<TDatabase, TObject>> SelectObjectContinuation<TDatabase, TObject>.FullJoin(AnyEntity entity)
            => new SelectObjectJoinExpressionBuilder<TDatabase, TObject>(SelectQueryExpression, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectObjectContinuation<TDatabase, TObject>> SelectObjectContinuation<TDatabase, TObject>.FullJoin(AnySelectSubquery subquery)
            => new SelectObjectJoinExpressionBuilder<TDatabase, TObject>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectObjectContinuation<TDatabase, TObject> SelectObjectContinuation<TDatabase, TObject>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }
        #endregion

        #region SelectObjectTermination<TDatabase, TObject>
        /// <inheritdoc />
        TObject? SelectObjectTermination<TDatabase, TObject>.Execute()
            => Executor.Execute();

        /// <inheritdoc />
        TObject? SelectObjectTermination<TDatabase, TObject>.Execute(int commandTimeout)
            => Executor.Execute(commandTimeout);

        /// <inheritdoc />
        TObject? SelectObjectTermination<TDatabase, TObject>.Execute(ISqlConnection connection)
            => Executor.Execute(connection);

        /// <inheritdoc />
        TObject? SelectObjectTermination<TDatabase, TObject>.Execute(ISqlConnection connection, int commandTimeout)
            => Executor.Execute(connection, commandTimeout);

        /// <inheritdoc />
        async Task<TObject?> SelectObjectTermination<TDatabase, TObject>.ExecuteAsync(CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<TObject?> SelectObjectTermination<TDatabase, TObject>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<TObject?> SelectObjectTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<TObject?> SelectObjectTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, cancellationToken).ConfigureAwait(false);
        #endregion
        #endregion
    }
}
