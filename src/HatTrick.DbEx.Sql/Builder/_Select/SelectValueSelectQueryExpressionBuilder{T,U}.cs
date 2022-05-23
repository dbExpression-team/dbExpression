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
    public class SelectValueSelectQueryExpressionBuilder<TDatabase, TValue> : SelectQueryExpressionBuilder<TDatabase>,
        SelectValue<TDatabase, TValue>,
        SelectValueContinuation<TDatabase, TValue>,
        SelectValueTermination<TDatabase, TValue>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly Func<SelectValueTermination<TDatabase, TValue>> _executor;
        private SelectValueTermination<TDatabase, TValue> Executor => _executor();
        #endregion

        #region constructors
        public SelectValueSelectQueryExpressionBuilder(
            SelectQueryExpression expression,
            SqlDatabaseRuntimeConfiguration config,
            Func<UnionSelectAnyInitiation<TDatabase>> union,
            Func<SelectValueTermination<TDatabase, TValue>> executor
        ) : base(expression, config, union)
        {
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        }
        #endregion

        #region methods
        #region SelectValue<TDatabase, TValue>
        /// <inheritdoc />
        SelectValueContinuation<TDatabase, TValue> SelectValue<TDatabase, TValue>.From<TEntity>(Table<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }
        #endregion

        #region SelectValueContinuation<TDatabase, TValue>
        /// <inheritdoc />
        SelectValueContinuation<TDatabase, TValue> SelectValueContinuation<TDatabase, TValue>.OrderBy(params AnyOrderByClause[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectValueContinuation<TDatabase, TValue> SelectValueContinuation<TDatabase, TValue>.OrderBy(IEnumerable<AnyOrderByClause>? orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectValueContinuation<TDatabase, TValue> SelectValueContinuation<TDatabase, TValue>.GroupBy(params AnyGroupByClause[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectValueContinuation<TDatabase, TValue> SelectValueContinuation<TDatabase, TValue>.GroupBy(IEnumerable<AnyGroupByClause>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectValueContinuation<TDatabase, TValue> SelectValueContinuation<TDatabase, TValue>.Having(AnyHavingClause? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectValueContinuation<TDatabase, TValue> SelectValueContinuation<TDatabase, TValue>.Where(AnyWhereClause? where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectValueContinuation<TDatabase, TValue>> SelectValueContinuation<TDatabase, TValue>.InnerJoin(AnyEntity entity)
            => new SelectValueJoinExpressionBuilder<TDatabase, TValue>(SelectQueryExpression, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectValueContinuation<TDatabase, TValue>> SelectValueContinuation<TDatabase, TValue>.InnerJoin(AnySelectSubquery subquery)
            => new SelectValueJoinExpressionBuilder<TDatabase, TValue>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectValueContinuation<TDatabase, TValue>> SelectValueContinuation<TDatabase, TValue>.LeftJoin(AnyEntity entity)
            => new SelectValueJoinExpressionBuilder<TDatabase, TValue>(SelectQueryExpression, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectValueContinuation<TDatabase, TValue>> SelectValueContinuation<TDatabase, TValue>.LeftJoin(AnySelectSubquery subquery)
            => new SelectValueJoinExpressionBuilder<TDatabase, TValue>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectValueContinuation<TDatabase, TValue>> SelectValueContinuation<TDatabase, TValue>.RightJoin(AnyEntity entity)
            => new SelectValueJoinExpressionBuilder<TDatabase, TValue>(SelectQueryExpression, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectValueContinuation<TDatabase, TValue>> SelectValueContinuation<TDatabase, TValue>.RightJoin(AnySelectSubquery subquery)
            => new SelectValueJoinExpressionBuilder<TDatabase, TValue>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectValueContinuation<TDatabase, TValue>> SelectValueContinuation<TDatabase, TValue>.FullJoin(AnyEntity entity)
            => new SelectValueJoinExpressionBuilder<TDatabase, TValue>(SelectQueryExpression, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectValueContinuation<TDatabase, TValue>> SelectValueContinuation<TDatabase, TValue>.FullJoin(AnySelectSubquery subquery)
            => new SelectValueJoinExpressionBuilder<TDatabase, TValue>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectValueContinuation<TDatabase, TValue> SelectValueContinuation<TDatabase, TValue>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }
        #endregion

        #region SelectValueTermination<TDatabase, TValue>
        /// <inheritdoc />
        TValue? SelectValueTermination<TDatabase, TValue>.Execute()
            => Executor.Execute();

        /// <inheritdoc />
        TValue? SelectValueTermination<TDatabase, TValue>.Execute(int commandTimeout)
            => Executor.Execute(commandTimeout);

        /// <inheritdoc />
        TValue? SelectValueTermination<TDatabase, TValue>.Execute(ISqlConnection connection)
            => Executor.Execute(connection);

        /// <inheritdoc />
        TValue? SelectValueTermination<TDatabase, TValue>.Execute(ISqlConnection connection, int commandTimeout)
            => Executor.Execute(connection, commandTimeout);

        /// <inheritdoc />
        async Task<TValue?> SelectValueTermination<TDatabase, TValue>.ExecuteAsync(CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<TValue?> SelectValueTermination<TDatabase, TValue>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<TValue?> SelectValueTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<TValue?> SelectValueTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, cancellationToken).ConfigureAwait(false);
        #endregion
        #endregion
    }
}
