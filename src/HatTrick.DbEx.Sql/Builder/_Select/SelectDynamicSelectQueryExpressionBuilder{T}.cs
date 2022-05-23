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
    public class SelectDynamicSelectQueryExpressionBuilder<TDatabase> : SelectQueryExpressionBuilder<TDatabase>,
        SelectDynamic<TDatabase>,
        SelectDynamicContinuation<TDatabase>,
        SelectDynamicTermination<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly Func<SelectDynamicTermination<TDatabase>> _executor;
        private SelectDynamicTermination<TDatabase> Executor => _executor();
        #endregion

        #region constructors
        public SelectDynamicSelectQueryExpressionBuilder(
            SelectQueryExpression expression, 
            SqlDatabaseRuntimeConfiguration config,
            Func<UnionSelectAnyInitiation<TDatabase>> union,
            Func<SelectDynamicTermination<TDatabase>> executor
        ) : base(expression, config, union)
        {
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        }
        #endregion

        #region methods
        #region SelectDynamic
        /// <inheritdoc />
        SelectDynamicContinuation<TDatabase> SelectDynamic<TDatabase>.From<TEntity>(Table<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }
        #endregion

        #region SelectDynamicContinuation
        /// <inheritdoc />
        SelectDynamicContinuation<TDatabase> SelectDynamicContinuation<TDatabase>.OrderBy(params AnyOrderByClause[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicContinuation<TDatabase> SelectDynamicContinuation<TDatabase>.OrderBy(IEnumerable<AnyOrderByClause> orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicContinuation<TDatabase> SelectDynamicContinuation<TDatabase>.Where(AnyWhereClause where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectDynamicContinuation<TDatabase>> SelectDynamicContinuation<TDatabase>.InnerJoin(AnyEntity entity)
            => new SelectDynamicJoinBuilder<TDatabase>(SelectQueryExpression, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectDynamicContinuation<TDatabase>> SelectDynamicContinuation<TDatabase>.InnerJoin(AnySelectSubquery subquery)
            => new SelectDynamicJoinBuilder<TDatabase>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.INNER, this); 

        /// <inheritdoc />
        JoinOn<SelectDynamicContinuation<TDatabase>> SelectDynamicContinuation<TDatabase>.LeftJoin(AnyEntity entity)
            => new SelectDynamicJoinBuilder<TDatabase>(SelectQueryExpression, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectDynamicContinuation<TDatabase>> SelectDynamicContinuation<TDatabase>.LeftJoin(AnySelectSubquery subquery)
            => new SelectDynamicJoinBuilder<TDatabase>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectDynamicContinuation<TDatabase>> SelectDynamicContinuation<TDatabase>.RightJoin(AnyEntity entity)
            => new SelectDynamicJoinBuilder<TDatabase>(SelectQueryExpression, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectDynamicContinuation<TDatabase>> SelectDynamicContinuation<TDatabase>.RightJoin(AnySelectSubquery subquery)
            => new SelectDynamicJoinBuilder<TDatabase>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectDynamicContinuation<TDatabase>> SelectDynamicContinuation<TDatabase>.FullJoin(AnyEntity entity)
            => new SelectDynamicJoinBuilder<TDatabase>(SelectQueryExpression, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectDynamicContinuation<TDatabase>> SelectDynamicContinuation<TDatabase>.FullJoin(AnySelectSubquery subquery)
            => new SelectDynamicJoinBuilder<TDatabase>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectDynamicContinuation<TDatabase> SelectDynamicContinuation<TDatabase>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicContinuation<TDatabase> SelectDynamicContinuation<TDatabase>.GroupBy(params AnyGroupByClause[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicContinuation<TDatabase> SelectDynamicContinuation<TDatabase>.GroupBy(IEnumerable<AnyGroupByClause> groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicContinuation<TDatabase> SelectDynamicContinuation<TDatabase>.Having(AnyHavingClause having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectDynamicTermination
        dynamic? SelectDynamicTermination<TDatabase>.Execute()
            => Executor.Execute();


        /// <inheritdoc />
        dynamic? SelectDynamicTermination<TDatabase>.Execute(int commandTimeout)
            => Executor.Execute(commandTimeout);

        /// <inheritdoc />
        dynamic? SelectDynamicTermination<TDatabase>.Execute(ISqlConnection connection)
            => Executor.Execute(connection);

        /// <inheritdoc />
        dynamic? SelectDynamicTermination<TDatabase>.Execute(ISqlConnection connection, int commandTimeout)
            => Executor.Execute(connection, commandTimeout);

        /// <inheritdoc />
        dynamic? SelectDynamicTermination<TDatabase>.Execute(Func<ISqlFieldReader, dynamic> map)
            => Executor.Execute(map);

        /// <inheritdoc />
        dynamic? SelectDynamicTermination<TDatabase>.Execute(ISqlConnection connection, Func<ISqlFieldReader, dynamic> map)
            => Executor.Execute(connection, map);

        /// <inheritdoc />
        dynamic? SelectDynamicTermination<TDatabase>.Execute(int commandTimeout, Func<ISqlFieldReader, dynamic> map)
            => Executor.Execute(commandTimeout, map);

        /// <inheritdoc />
        dynamic? SelectDynamicTermination<TDatabase>.Execute(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, dynamic> map)
            => Executor.Execute(connection, commandTimeout, map);

        /// <inheritdoc />
        async Task<dynamic?> SelectDynamicTermination<TDatabase>.ExecuteAsync(CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<dynamic?> SelectDynamicTermination<TDatabase>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<dynamic?> SelectDynamicTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<dynamic?> SelectDynamicTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        void SelectDynamicTermination<TDatabase>.Execute(Action<ISqlFieldReader> read)
            => Executor.Execute(read);

        /// <inheritdoc />
        void SelectDynamicTermination<TDatabase>.Execute(int commandTimeout, Action<ISqlFieldReader> read)
            => Executor.Execute(commandTimeout, read);

        /// <inheritdoc />
        void SelectDynamicTermination<TDatabase>.Execute(ISqlConnection connection, Action<ISqlFieldReader> read)
            => Executor.Execute(connection, read);

        /// <inheritdoc />
        void SelectDynamicTermination<TDatabase>.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read)
            => Executor.Execute(connection, commandTimeout, read);

        /// <inheritdoc />
        async Task SelectDynamicTermination<TDatabase>.ExecuteAsync(Action<ISqlFieldReader> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectDynamicTermination<TDatabase>.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectDynamicTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectDynamicTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<dynamic?> SelectDynamicTermination<TDatabase>.ExecuteAsync(Func<ISqlFieldReader, dynamic> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<dynamic?> SelectDynamicTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, dynamic> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<dynamic?> SelectDynamicTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, dynamic> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectDynamicTermination<TDatabase>.ExecuteAsync(Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectDynamicTermination<TDatabase>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectDynamicTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectDynamicTermination<TDatabase>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<dynamic?> SelectDynamicTermination<TDatabase>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, dynamic> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, map, cancellationToken).ConfigureAwait(false);
        #endregion
        #endregion
    }
}
