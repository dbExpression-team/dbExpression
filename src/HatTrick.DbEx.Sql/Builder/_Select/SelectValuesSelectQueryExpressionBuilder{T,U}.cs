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

﻿using HatTrick.DbEx.Sql.Configuration;
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
    public class SelectValuesSelectQueryExpressionBuilder<TDatabase, TValue> : SelectQueryExpressionBuilder<TDatabase>,
        SelectValues<TDatabase, TValue>,
        SelectValuesContinuation<TDatabase, TValue>,
        SelectValuesOffsetContinuation<TDatabase, TValue>,
        SelectValuesOrderByContinuation<TDatabase, TValue>,
        SelectValuesTermination<TDatabase, TValue>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly Func<SelectValuesTermination<TDatabase, TValue>> _executor;
        private SelectValuesTermination<TDatabase, TValue> Executor => _executor();
        #endregion

        #region constructors
        public SelectValuesSelectQueryExpressionBuilder(
            SelectQueryExpression expression,
            SqlDatabaseRuntimeConfiguration config,
            Func<UnionSelectAnyInitiation<TDatabase>> union,
            Func<SelectValuesTermination<TDatabase, TValue>> executor
        ) : base(expression, config, union)
        {
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        }
        #endregion

        #region methods
        #region SelectValues<TDatabase, TValue>
        /// <inheritdoc />
        SelectValues<TDatabase, TValue> SelectValues<TDatabase, TValue>.Top(int value)
        {
            ApplyTop(value);
            return this;
        }

        /// <inheritdoc />
        SelectValues<TDatabase, TValue> SelectValues<TDatabase, TValue>.Distinct()
        {
            ApplyDistinct();
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TDatabase, TValue> SelectValues<TDatabase, TValue>.From<TEntity>(Table<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }
        #endregion

        #region SelectValuesContinuation<TDatabase, TValue>
        /// <inheritdoc />
        SelectValuesOrderByContinuation<TDatabase, TValue> SelectValuesContinuation<TDatabase, TValue>.OrderBy(params AnyOrderByClause[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOrderByContinuation<TDatabase, TValue> SelectValuesContinuation<TDatabase, TValue>.OrderBy(IEnumerable<AnyOrderByClause>? orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TDatabase, TValue> SelectValuesContinuation<TDatabase, TValue>.GroupBy(params AnyGroupByClause[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TDatabase, TValue> SelectValuesContinuation<TDatabase, TValue>.GroupBy(IEnumerable<AnyGroupByClause>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TDatabase, TValue> SelectValuesContinuation<TDatabase, TValue>.Having(AnyHavingClause? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TDatabase, TValue> SelectValuesContinuation<TDatabase, TValue>.Where(AnyWhereClause? where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectValuesContinuation<TDatabase, TValue>> SelectValuesContinuation<TDatabase, TValue>.InnerJoin(AnyEntity entity)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(SelectQueryExpression, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectValuesContinuation<TDatabase, TValue>> SelectValuesContinuation<TDatabase, TValue>.InnerJoin(AnySelectSubquery subquery)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectValuesContinuation<TDatabase, TValue>> SelectValuesContinuation<TDatabase, TValue>.LeftJoin(AnyEntity entity)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(SelectQueryExpression, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectValuesContinuation<TDatabase, TValue>> SelectValuesContinuation<TDatabase, TValue>.LeftJoin(AnySelectSubquery subquery)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectValuesContinuation<TDatabase, TValue>> SelectValuesContinuation<TDatabase, TValue>.RightJoin(AnyEntity entity)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(SelectQueryExpression, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectValuesContinuation<TDatabase, TValue>> SelectValuesContinuation<TDatabase, TValue>.RightJoin(AnySelectSubquery subquery)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectValuesContinuation<TDatabase, TValue>> SelectValuesContinuation<TDatabase, TValue>.FullJoin(AnyEntity entity)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(SelectQueryExpression, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectValuesContinuation<TDatabase, TValue>> SelectValuesContinuation<TDatabase, TValue>.FullJoin(AnySelectSubquery subquery)
            => new SelectValuesJoinExpressionBuilder<TDatabase, TValue>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectValuesContinuation<TDatabase, TValue> SelectValuesContinuation<TDatabase, TValue>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }
        #endregion

        #region SelectValuesOrderByContinuation<TDatabase, TValue>
        /// <inheritdoc />
        SelectValuesOffsetContinuation<TDatabase, TValue> SelectValuesOrderByContinuation<TDatabase, TValue>.Offset(int value)
        {
            ApplyOffset(value);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOrderByContinuation<TDatabase, TValue> Limit<SelectValuesOrderByContinuation<TDatabase, TValue>>.Limit(int value)
        {
            ApplyLimit(value);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOrderByContinuation<TDatabase, TValue> SelectValuesOrderByContinuation<TDatabase, TValue>.GroupBy(params AnyGroupByClause[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOrderByContinuation<TDatabase, TValue> SelectValuesOrderByContinuation<TDatabase, TValue>.GroupBy(IEnumerable<AnyGroupByClause>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOrderByContinuation<TDatabase, TValue> SelectValuesOrderByContinuation<TDatabase, TValue>.Having(AnyHavingClause? having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectValuesOffsetContinuation<TDatabase, TValue>
        /// <inheritdoc />
        SelectValuesOrderByContinuation<TDatabase, TValue> Limit<SelectValuesOrderByContinuation<TDatabase, TValue>>.Having(AnyHavingClause? having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectValuesTermination<TValue>
        /// <inheritdoc />
        IList<TValue> SelectValuesTermination<TDatabase, TValue>.Execute()
            => Executor.Execute();

        /// <inheritdoc />
        IList<TValue> SelectValuesTermination<TDatabase, TValue>.Execute(int commandTimeout)
            => Executor.Execute(commandTimeout);


        /// <inheritdoc />
        IList<TValue> SelectValuesTermination<TDatabase, TValue>.Execute(ISqlConnection connection)
            => Executor.Execute(connection);

        /// <inheritdoc />
        IList<TValue> SelectValuesTermination<TDatabase, TValue>.Execute(ISqlConnection connection, int commandTimeout)
            => Executor.Execute(connection, commandTimeout);

        /// <inheritdoc />
        void SelectValuesTermination<TDatabase, TValue>.Execute(Action<TValue?> read)
            => Executor.Execute(read);

        /// <inheritdoc />
        void SelectValuesTermination<TDatabase, TValue>.Execute(int commandTimeout, Action<TValue?> read)
            => Executor.Execute(commandTimeout, read);

        /// <inheritdoc />
        void SelectValuesTermination<TDatabase, TValue>.Execute(ISqlConnection connection, Action<TValue?> read)
            => Executor.Execute(connection, read);

        /// <inheritdoc />
        void SelectValuesTermination<TDatabase, TValue>.Execute(ISqlConnection connection, int commandTimeout, Action<TValue?> read)
            => Executor.Execute(connection, commandTimeout, read);

        /// <inheritdoc />
        async Task<IList<TValue>> SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<TValue>> SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<TValue>> SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<TValue>> SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(Action<TValue?> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(int commandTimeout, Action<TValue?> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, Action<TValue?> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<TValue?> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(Func<TValue?, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(int commandTimeout, Func<TValue?, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, Func<TValue?, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<TValue?, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, read, cancellationToken).ConfigureAwait(false);
        #endregion
        #endregion
    }
}
