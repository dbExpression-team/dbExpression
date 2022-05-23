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
    public class SelectEntitySelectQueryExpressionBuilder<TDatabase, TEntity> : SelectQueryExpressionBuilder<TDatabase>,
        IExpressionBuilder<TDatabase, TEntity>,
        SelectEntity<TDatabase, TEntity>,
        SelectEntityContinuation<TDatabase, TEntity>,
        SelectEntityTermination<TDatabase, TEntity>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, IDbEntity, new()
    {
        #region internals
        private readonly Func<SelectEntityTermination<TDatabase, TEntity>> _executor;
        private SelectEntityTermination<TDatabase, TEntity> Executor => _executor();
        #endregion

        #region constructors
        public SelectEntitySelectQueryExpressionBuilder(
            SelectQueryExpression expression,
            SqlDatabaseRuntimeConfiguration config,
            Func<UnionSelectAnyInitiation<TDatabase>> union,
            Func<SelectEntityTermination<TDatabase, TEntity>> executor
        ) : base(expression, config, union)
        {
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        }
        #endregion

        #region methods
        protected override void ApplyFrom<T>(Table<T> entity)
        {
            base.ApplyFrom(entity);
            SelectQueryExpression.Select = new SelectExpressionSet(entity.BuildInclusiveSelectExpression());
        }

        #region SelectEntity<TDatabase, TEntity>
        /// <inheritdoc />
        SelectEntityContinuation<TDatabase, TEntity> SelectEntity<TDatabase, TEntity>.From(Table<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }
        #endregion

        #region SelectEntityContinuation<TDatabase, TEntity>
        /// <inheritdoc />
        SelectEntityContinuation<TDatabase, TEntity> SelectEntityContinuation<TDatabase, TEntity>.OrderBy(params AnyOrderByClause[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TDatabase, TEntity> SelectEntityContinuation<TDatabase, TEntity>.OrderBy(IEnumerable<AnyOrderByClause> orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TDatabase, TEntity> SelectEntityContinuation<TDatabase, TEntity>.GroupBy(params AnyGroupByClause[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TDatabase, TEntity> SelectEntityContinuation<TDatabase, TEntity>.GroupBy(IEnumerable<AnyGroupByClause> groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TDatabase, TEntity> SelectEntityContinuation<TDatabase, TEntity>.Having(AnyHavingClause having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TDatabase, TEntity> SelectEntityContinuation<TDatabase, TEntity>.Where(AnyWhereClause where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectEntityContinuation<TDatabase, TEntity>> SelectEntityContinuation<TDatabase, TEntity>.InnerJoin(AnyEntity entity)
            => new SelectEntityJoinExpressionBuilder<TDatabase, TEntity>(SelectQueryExpression, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectEntityContinuation<TDatabase, TEntity>> SelectEntityContinuation<TDatabase, TEntity>.InnerJoin(AnySelectSubquery subquery)
            => new SelectEntityJoinExpressionBuilder<TDatabase, TEntity>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectEntityContinuation<TDatabase, TEntity>> SelectEntityContinuation<TDatabase, TEntity>.LeftJoin(AnyEntity entity)
            => new SelectEntityJoinExpressionBuilder<TDatabase, TEntity>(SelectQueryExpression, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectEntityContinuation<TDatabase, TEntity>> SelectEntityContinuation<TDatabase, TEntity>.LeftJoin(AnySelectSubquery subquery)
            => new SelectEntityJoinExpressionBuilder<TDatabase, TEntity>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectEntityContinuation<TDatabase, TEntity>> SelectEntityContinuation<TDatabase, TEntity>.RightJoin(AnyEntity entity)
            => new SelectEntityJoinExpressionBuilder<TDatabase, TEntity>(SelectQueryExpression, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectEntityContinuation<TDatabase, TEntity>> SelectEntityContinuation<TDatabase, TEntity>.RightJoin(AnySelectSubquery subquery)
            => new SelectEntityJoinExpressionBuilder<TDatabase, TEntity>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectEntityContinuation<TDatabase, TEntity>> SelectEntityContinuation<TDatabase, TEntity>.FullJoin(AnyEntity entity)
            => new SelectEntityJoinExpressionBuilder<TDatabase, TEntity>(SelectQueryExpression, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectEntityContinuation<TDatabase, TEntity>> SelectEntityContinuation<TDatabase, TEntity>.FullJoin(AnySelectSubquery subquery)
            => new SelectEntityJoinExpressionBuilder<TDatabase, TEntity>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.FULL, this); 

        /// <inheritdoc />
        SelectEntityContinuation<TDatabase, TEntity> SelectEntityContinuation<TDatabase, TEntity>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }
        #endregion

        #region SelectEntityTermination
        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute()
            => Executor.Execute();

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute(int commandTimeout)
            => Executor.Execute(commandTimeout);

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute(ISqlConnection connection)
            => Executor.Execute(connection);

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout)
            => Executor.Execute(connection, commandTimeout);

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute(Func<ISqlFieldReader, TEntity> map)
            => Executor.Execute(map);

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute(int commandTimeout, Func<ISqlFieldReader, TEntity> map)
             => Executor.Execute(commandTimeout, map);

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map)
            => Executor.Execute(connection, map);

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map)
            => Executor.Execute(connection, commandTimeout, map);

        /// <inheritdoc />
        void SelectEntityTermination<TDatabase, TEntity>.Execute(Action<ISqlFieldReader> read)
            => Executor.Execute(read);

        /// <inheritdoc />
        void SelectEntityTermination<TDatabase, TEntity>.Execute(int commandTimeout, Action<ISqlFieldReader> read)
            => Executor.Execute(commandTimeout, read);

        /// <inheritdoc />
        void SelectEntityTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, Action<ISqlFieldReader> read)
            => Executor.Execute(connection, read);

        /// <inheritdoc />
        void SelectEntityTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read)
            => Executor.Execute(connection, commandTimeout, read);

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute(Action<ISqlFieldReader, TEntity> map)
            => Executor.Execute(map);

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute(int commandTimeout, Action<ISqlFieldReader, TEntity> map)
            => Executor.Execute(commandTimeout, map);

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map)
            => Executor.Execute(connection, map);

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map)
            => Executor.Execute(connection, commandTimeout, map);

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(Action<ISqlFieldReader> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, map, cancellationToken).ConfigureAwait(false);
        #endregion
        #endregion
    }
}
