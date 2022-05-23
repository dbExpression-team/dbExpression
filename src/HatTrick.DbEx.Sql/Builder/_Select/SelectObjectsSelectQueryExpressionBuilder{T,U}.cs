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
    public class SelectObjectsSelectQueryExpressionBuilder<TDatabase, TObject> : SelectQueryExpressionBuilder<TDatabase>,
        SelectObjects<TDatabase, TObject>,
        SelectObjectsContinuation<TDatabase, TObject>,
        SelectObjectsOffsetContinuation<TDatabase, TObject>,
        SelectObjectsOrderByContinuation<TDatabase, TObject>,
        SelectObjectsTermination<TDatabase, TObject>
        where TDatabase : class, ISqlDatabaseRuntime
        where TObject : class?
    {
        #region internals
        private readonly Func<SelectObjectsTermination<TDatabase, TObject>> _executor;
        private SelectObjectsTermination<TDatabase, TObject> Executor => _executor();
        #endregion

        #region constructors
        public SelectObjectsSelectQueryExpressionBuilder(
            SelectQueryExpression expression,
            SqlDatabaseRuntimeConfiguration config,
            Func<UnionSelectAnyInitiation<TDatabase>> union,
            Func<SelectObjectsTermination<TDatabase, TObject>> executor
        ) : base(expression, config, union)
        {
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        }
        #endregion

        #region methods
        #region SelectObjects<TDatabase, TObject>
        /// <inheritdoc />
        SelectObjects<TDatabase, TObject> SelectObjects<TDatabase, TObject>.Top(int Object)
        {
            ApplyTop(Object);
            return this;
        }

        /// <inheritdoc />
        SelectObjects<TDatabase, TObject> SelectObjects<TDatabase, TObject>.Distinct()
        {
            ApplyDistinct();
            return this;
        }

        /// <inheritdoc />
        SelectObjectsContinuation<TDatabase, TObject> SelectObjects<TDatabase, TObject>.From<TEntity>(Table<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }
        #endregion

        #region SelectObjectsContinuation<TDatabase, TObject>
        /// <inheritdoc />
        SelectObjectsOrderByContinuation<TDatabase, TObject> SelectObjectsContinuation<TDatabase, TObject>.OrderBy(params AnyOrderByClause[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsOrderByContinuation<TDatabase, TObject> SelectObjectsContinuation<TDatabase, TObject>.OrderBy(IEnumerable<AnyOrderByClause>? orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsContinuation<TDatabase, TObject> SelectObjectsContinuation<TDatabase, TObject>.GroupBy(params AnyGroupByClause[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsContinuation<TDatabase, TObject> SelectObjectsContinuation<TDatabase, TObject>.GroupBy(IEnumerable<AnyGroupByClause>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsContinuation<TDatabase, TObject> SelectObjectsContinuation<TDatabase, TObject>.Having(AnyHavingClause? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsContinuation<TDatabase, TObject> SelectObjectsContinuation<TDatabase, TObject>.Where(AnyWhereClause? where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectObjectsContinuation<TDatabase, TObject>> SelectObjectsContinuation<TDatabase, TObject>.InnerJoin(AnyEntity entity)
            => new SelectObjectsJoinExpressionBuilder<TDatabase, TObject>(SelectQueryExpression, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectObjectsContinuation<TDatabase, TObject>> SelectObjectsContinuation<TDatabase, TObject>.InnerJoin(AnySelectSubquery subquery)
            => new SelectObjectsJoinExpressionBuilder<TDatabase, TObject>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectObjectsContinuation<TDatabase, TObject>> SelectObjectsContinuation<TDatabase, TObject>.LeftJoin(AnyEntity entity)
            => new SelectObjectsJoinExpressionBuilder<TDatabase, TObject>(SelectQueryExpression, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectObjectsContinuation<TDatabase, TObject>> SelectObjectsContinuation<TDatabase, TObject>.LeftJoin(AnySelectSubquery subquery)
            => new SelectObjectsJoinExpressionBuilder<TDatabase, TObject>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectObjectsContinuation<TDatabase, TObject>> SelectObjectsContinuation<TDatabase, TObject>.RightJoin(AnyEntity entity)
            => new SelectObjectsJoinExpressionBuilder<TDatabase, TObject>(SelectQueryExpression, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectObjectsContinuation<TDatabase, TObject>> SelectObjectsContinuation<TDatabase, TObject>.RightJoin(AnySelectSubquery subquery)
            => new SelectObjectsJoinExpressionBuilder<TDatabase, TObject>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectObjectsContinuation<TDatabase, TObject>> SelectObjectsContinuation<TDatabase, TObject>.FullJoin(AnyEntity entity)
            => new SelectObjectsJoinExpressionBuilder<TDatabase, TObject>(SelectQueryExpression, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectObjectsContinuation<TDatabase, TObject>> SelectObjectsContinuation<TDatabase, TObject>.FullJoin(AnySelectSubquery subquery)
            => new SelectObjectsJoinExpressionBuilder<TDatabase, TObject>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectObjectsContinuation<TDatabase, TObject> SelectObjectsContinuation<TDatabase, TObject>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }
        #endregion

        #region SelectObjectsOrderByContinuation<TDatabase, TObject>
        /// <inheritdoc />
        SelectObjectsOffsetContinuation<TDatabase, TObject> SelectObjectsOrderByContinuation<TDatabase, TObject>.Offset(int Object)
        {
            ApplyOffset(Object);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsOrderByContinuation<TDatabase, TObject> Limit<SelectObjectsOrderByContinuation<TDatabase, TObject>>.Limit(int Object)
        {
            ApplyLimit(Object);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsOrderByContinuation<TDatabase, TObject> SelectObjectsOrderByContinuation<TDatabase, TObject>.GroupBy(params AnyGroupByClause[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsOrderByContinuation<TDatabase, TObject> SelectObjectsOrderByContinuation<TDatabase, TObject>.GroupBy(IEnumerable<AnyGroupByClause>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectObjectsOrderByContinuation<TDatabase, TObject> SelectObjectsOrderByContinuation<TDatabase, TObject>.Having(AnyHavingClause? having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectObjectsOffsetContinuation<TDatabase, TObject>
        /// <inheritdoc />
        SelectObjectsOrderByContinuation<TDatabase, TObject> Limit<SelectObjectsOrderByContinuation<TDatabase, TObject>>.Having(AnyHavingClause? having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectObjectsTermination<TObject>
        /// <inheritdoc />
        IList<TObject> SelectObjectsTermination<TDatabase, TObject>.Execute()
            => Executor.Execute();

        /// <inheritdoc />
        IList<TObject> SelectObjectsTermination<TDatabase, TObject>.Execute(int commandTimeout)
            => Executor.Execute(commandTimeout);


        /// <inheritdoc />
        IList<TObject> SelectObjectsTermination<TDatabase, TObject>.Execute(ISqlConnection connection)
            => Executor.Execute(connection);

        /// <inheritdoc />
        IList<TObject> SelectObjectsTermination<TDatabase, TObject>.Execute(ISqlConnection connection, int commandTimeout)
            => Executor.Execute(connection, commandTimeout);

        /// <inheritdoc />
        void SelectObjectsTermination<TDatabase, TObject>.Execute(Action<TObject?> read)
            => Executor.Execute(read);

        /// <inheritdoc />
        void SelectObjectsTermination<TDatabase, TObject>.Execute(int commandTimeout, Action<TObject?> read)
            => Executor.Execute(commandTimeout, read);

        /// <inheritdoc />
        void SelectObjectsTermination<TDatabase, TObject>.Execute(ISqlConnection connection, Action<TObject?> read)
            => Executor.Execute(connection, read);

        /// <inheritdoc />
        void SelectObjectsTermination<TDatabase, TObject>.Execute(ISqlConnection connection, int commandTimeout, Action<TObject?> read)
            => Executor.Execute(connection, commandTimeout, read);

        /// <inheritdoc />
        async Task<IList<TObject>> SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<TObject>> SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<TObject>> SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<TObject>> SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(Action<TObject?> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(int commandTimeout, Action<TObject?> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, Action<TObject?> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<TObject?> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(Func<TObject?, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(int commandTimeout, Func<TObject?, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, Func<TObject?, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<TObject?, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, read, cancellationToken).ConfigureAwait(false);
        #endregion
        #endregion
    }
}
