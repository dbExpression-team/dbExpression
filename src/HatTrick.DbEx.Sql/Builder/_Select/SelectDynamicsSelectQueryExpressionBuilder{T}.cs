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
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectDynamicsSelectQueryExpressionBuilder<TDatabase> : SelectQueryExpressionBuilder<TDatabase>,
        SelectDynamics<TDatabase>,
        SelectDynamicsContinuation<TDatabase>,
        SelectDynamicsOffsetContinuation<TDatabase>,
        SelectDynamicsOrderByContinuation<TDatabase>,
        SelectDynamicsTermination<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly Func<SelectDynamicsTermination<TDatabase>> _executor;
        private SelectDynamicsTermination<TDatabase> Executor => _executor();
        #endregion

        #region constructors
        public SelectDynamicsSelectQueryExpressionBuilder(
            SelectQueryExpression expression,
            SqlDatabaseRuntimeConfiguration config,
            Func<UnionSelectAnyInitiation<TDatabase>> union,
            Func<SelectDynamicsTermination<TDatabase>> executor
        ) : base(expression, config, union)
        {
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        }
        #endregion

        #region methods
        #region SelectDynamics<TDatabase>
        /// <inheritdoc />
        SelectDynamicsContinuation<TDatabase> SelectDynamics<TDatabase>.From<TEntity>(Table<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }

        /// <inheritdoc />
        SelectDynamics<TDatabase> SelectDynamics<TDatabase>.Top(int value)
        {
            ApplyTop(value);
            return this;
        }

        /// <inheritdoc />
        SelectDynamics<TDatabase> SelectDynamics<TDatabase>.Distinct()
        {
            ApplyDistinct();
            return this;
        }
        #endregion

        #region SelectDynamicsContinuation<TDatabase>
        /// <inheritdoc />
        SelectDynamicsOrderByContinuation<TDatabase> SelectDynamicsContinuation<TDatabase>.OrderBy(params AnyOrderByClause[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation<TDatabase> SelectDynamicsContinuation<TDatabase>.OrderBy(IEnumerable<AnyOrderByClause>? orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsContinuation<TDatabase> SelectDynamicsContinuation<TDatabase>.Where(AnyWhereClause? where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectDynamicsContinuation<TDatabase>> SelectDynamicsContinuation<TDatabase>.InnerJoin(AnyEntity entity)
            => new SelectDynamicsJoinBuilder<TDatabase>(SelectQueryExpression, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectDynamicsContinuation<TDatabase>> SelectDynamicsContinuation<TDatabase>.InnerJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinBuilder<TDatabase>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectDynamicsContinuation<TDatabase>> SelectDynamicsContinuation<TDatabase>.LeftJoin(AnyEntity entity)
            => new SelectDynamicsJoinBuilder<TDatabase>(SelectQueryExpression, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectDynamicsContinuation<TDatabase>> SelectDynamicsContinuation<TDatabase>.LeftJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinBuilder<TDatabase>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectDynamicsContinuation<TDatabase>> SelectDynamicsContinuation<TDatabase>.RightJoin(AnyEntity entity)
            => new SelectDynamicsJoinBuilder<TDatabase>(SelectQueryExpression, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectDynamicsContinuation<TDatabase>> SelectDynamicsContinuation<TDatabase>.RightJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinBuilder<TDatabase>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectDynamicsContinuation<TDatabase>> SelectDynamicsContinuation<TDatabase>.FullJoin(AnyEntity entity)
            => new SelectDynamicsJoinBuilder<TDatabase>(SelectQueryExpression, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectDynamicsContinuation<TDatabase>> SelectDynamicsContinuation<TDatabase>.FullJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinBuilder<TDatabase>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectDynamicsContinuation<TDatabase> SelectDynamicsContinuation<TDatabase>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsContinuation<TDatabase> SelectDynamicsContinuation<TDatabase>.GroupBy(params AnyGroupByClause[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsContinuation<TDatabase> SelectDynamicsContinuation<TDatabase>.GroupBy(IEnumerable<AnyGroupByClause>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsContinuation<TDatabase> SelectDynamicsContinuation<TDatabase>.Having(AnyHavingClause? having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectDynamicsOffsetContinuation<TDatabase>
        /// <inheritdoc />
        SelectDynamicsOrderByContinuation<TDatabase> Limit<SelectDynamicsOrderByContinuation<TDatabase>>.Having(AnyHavingClause? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation<TDatabase> Limit<SelectDynamicsOrderByContinuation<TDatabase>>.Limit(int value)
        {
            ApplyLimit(value);
            return this;
        }
        #endregion

        #region SelectDynamicsOrderByContinuation<TDatabase>
        /// <inheritdoc />
        SelectDynamicsOffsetContinuation<TDatabase> SelectDynamicsOrderByContinuation<TDatabase>.Offset(int value)
        {
            ApplyOffset(value);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation<TDatabase> SelectDynamicsOrderByContinuation<TDatabase>.GroupBy(params AnyGroupByClause[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation<TDatabase> SelectDynamicsOrderByContinuation<TDatabase>.GroupBy(IEnumerable<AnyGroupByClause>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation<TDatabase> SelectDynamicsOrderByContinuation<TDatabase>.Having(AnyHavingClause? having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectDynamicsTermination<TDatabase>
        /// <inheritdoc />
        IList<dynamic> SelectDynamicsTermination<TDatabase>.Execute()
            => Executor.Execute();

        /// <inheritdoc />
        IList<dynamic> SelectDynamicsTermination<TDatabase>.Execute(int commandTimeout)
            => Executor.Execute(commandTimeout);

        /// <inheritdoc />
        IList<dynamic> SelectDynamicsTermination<TDatabase>.Execute(ISqlConnection connection)
            => Executor.Execute(connection);

        /// <inheritdoc />
        IList<dynamic> SelectDynamicsTermination<TDatabase>.Execute(ISqlConnection connection, int commandTimeout)
            => Executor.Execute(connection, commandTimeout);

        /// <inheritdoc />
        async Task<IList<dynamic>> SelectDynamicsTermination<TDatabase>.ExecuteAsync(CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<dynamic>> SelectDynamicsTermination<TDatabase>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<dynamic>> SelectDynamicsTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<dynamic>> SelectDynamicsTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        IList<T> SelectDynamicsTermination<TDatabase>.Execute<T>(Func<ISqlFieldReader, T> map)
            => Executor.Execute(map);

        /// <inheritdoc />
        IList<T> SelectDynamicsTermination<TDatabase>.Execute<T>(int commandTimeout, Func<ISqlFieldReader, T> map)
            => Executor.Execute(commandTimeout, map);

        /// <inheritdoc />
        IList<T> SelectDynamicsTermination<TDatabase>.Execute<T>(ISqlConnection connection, Func<ISqlFieldReader, T> map)
            => Executor.Execute(connection, map);

        /// <inheritdoc />
        IList<T> SelectDynamicsTermination<TDatabase>.Execute<T>(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, T> map)
            => Executor.Execute(connection, commandTimeout, map);

        /// <inheritdoc />
        void SelectDynamicsTermination<TDatabase>.Execute(Action<ISqlFieldReader> map)
            => Executor.Execute(map);

        /// <inheritdoc />
        void SelectDynamicsTermination<TDatabase>.Execute(int commandTimeout, Action<ISqlFieldReader> map)
            => Executor.Execute(commandTimeout, map);

        /// <inheritdoc />
        void SelectDynamicsTermination<TDatabase>.Execute(ISqlConnection connection, Action<ISqlFieldReader> read)
            => Executor.Execute(connection, read);

        /// <inheritdoc />
        void SelectDynamicsTermination<TDatabase>.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read)
            => Executor.Execute(connection, commandTimeout, read);

        /// <inheritdoc />
        async Task<IList<T>> SelectDynamicsTermination<TDatabase>.ExecuteAsync<T>(Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<T>> SelectDynamicsTermination<TDatabase>.ExecuteAsync<T>(int commandTimeout, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<T>> SelectDynamicsTermination<TDatabase>.ExecuteAsync<T>(ISqlConnection connection, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<T>> SelectDynamicsTermination<TDatabase>.ExecuteAsync<T>(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectDynamicsTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, map, cancellationToken).ConfigureAwait(false);
        #endregion
        #endregion
    }
}
