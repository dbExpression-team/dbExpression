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
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectEntitiesSelectQueryExpressionBuilder<TDatabase, TEntity> : SelectQueryExpressionBuilder<TDatabase>,
        IExpressionBuilder<TDatabase, TEntity>,
        SelectEntities<TDatabase, TEntity>,
        SelectEntitiesContinuation<TDatabase, TEntity>,
        SelectEntitiesOffsetContinuation<TDatabase, TEntity>,
        SelectEntitiesOrderByContinuation<TDatabase, TEntity>,
        SelectEntitiesTermination<TDatabase, TEntity>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, IDbEntity, new()
    {
        #region internals
        private readonly Func<SelectEntitiesTermination<TDatabase, TEntity>> _executor;
        private SelectEntitiesTermination<TDatabase, TEntity> Executor => _executor();
        #endregion

        #region constructors
        public SelectEntitiesSelectQueryExpressionBuilder(
            SelectQueryExpression expression,
            SqlDatabaseRuntimeConfiguration config,
            Func<UnionSelectAnyInitiation<TDatabase>> union,
            Func<SelectEntitiesTermination<TDatabase, TEntity>> executor
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

        #region SelectEntities<TDatabase, TEntity>
        /// <inheritdoc />
        SelectEntities<TDatabase, TEntity> SelectEntities<TDatabase, TEntity>.Top(int value)
        {
            ApplyTop(value);
            return this;
        }

        /// <inheritdoc />
        SelectEntities<TDatabase, TEntity> SelectEntities<TDatabase, TEntity>.Distinct()
        {
            ApplyDistinct();
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TDatabase, TEntity> SelectEntities<TDatabase, TEntity>.From(Table<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }
        #endregion

        #region SelectEntitiesContinuation<TDatabase, TEntity>
        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.OrderBy(params AnyOrderByClause[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.OrderBy(IEnumerable<AnyOrderByClause>? orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.GroupBy(params AnyGroupByClause[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.GroupBy(IEnumerable<AnyGroupByClause>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.Having(AnyHavingClause? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.Where(AnyWhereClause? where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectEntitiesContinuation<TDatabase, TEntity>> SelectEntitiesContinuation<TDatabase, TEntity>.InnerJoin(AnyEntity entity)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(SelectQueryExpression, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectEntitiesContinuation<TDatabase, TEntity>> SelectEntitiesContinuation<TDatabase, TEntity>.InnerJoin(AnySelectSubquery subquery)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectEntitiesContinuation<TDatabase, TEntity>> SelectEntitiesContinuation<TDatabase, TEntity>.LeftJoin(AnyEntity entity)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(SelectQueryExpression, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectEntitiesContinuation<TDatabase, TEntity>> SelectEntitiesContinuation<TDatabase, TEntity>.LeftJoin(AnySelectSubquery subquery)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectEntitiesContinuation<TDatabase, TEntity>> SelectEntitiesContinuation<TDatabase, TEntity>.RightJoin(AnyEntity entity)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(SelectQueryExpression, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectEntitiesContinuation<TDatabase, TEntity>> SelectEntitiesContinuation<TDatabase, TEntity>.RightJoin(AnySelectSubquery subquery)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectEntitiesContinuation<TDatabase, TEntity>> SelectEntitiesContinuation<TDatabase, TEntity>.FullJoin(AnyEntity entity)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(SelectQueryExpression, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectEntitiesContinuation<TDatabase, TEntity>> SelectEntitiesContinuation<TDatabase, TEntity>.FullJoin(AnySelectSubquery subquery)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(SelectQueryExpression, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectEntitiesContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }
        #endregion

        #region SelectEntitiesOrderByContinuation<TDatabase, TEntity>
        /// <inheritdoc />
        SelectEntitiesOffsetContinuation<TDatabase, TEntity> SelectEntitiesOrderByContinuation<TDatabase, TEntity>.Offset(int value)
        {
            ApplyOffset(value);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> SelectEntitiesOrderByContinuation<TDatabase, TEntity>.GroupBy(params AnyGroupByClause[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> SelectEntitiesOrderByContinuation<TDatabase, TEntity>.GroupBy(IEnumerable<AnyGroupByClause>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> SelectEntitiesOrderByContinuation<TDatabase, TEntity>.Having(AnyHavingClause? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> Limit<SelectEntitiesOrderByContinuation<TDatabase, TEntity>>.Having(AnyHavingClause? having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectEntitiesOffsetContinuation<TDatabase, TEntity>
        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> Limit<SelectEntitiesOrderByContinuation<TDatabase, TEntity>>.Limit(int value)
        {
            ApplyLimit(value);
            return this;
        }
        #endregion

        #region SelectEntitiesTermination<TDatabase, TEntity>
        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute()
            => Executor.Execute();

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(int commandTimeout)
            => Executor.Execute(commandTimeout);

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection)
            => Executor.Execute(connection);

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout)
            => Executor.Execute(connection, commandTimeout);

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(Func<ISqlFieldReader, TEntity> map)
            => Executor.Execute(map);

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(int commandTimeout, Func<ISqlFieldReader, TEntity> map)
            => Executor.Execute(commandTimeout, map);

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map)
            => Executor.Execute(connection, map);

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map)
            => Executor.Execute(connection, commandTimeout, map);

        /// <inheritdoc />
        void SelectEntitiesTermination<TDatabase, TEntity>.Execute(Action<ISqlFieldReader> map)
            => Executor.Execute(map);

        /// <inheritdoc />
        void SelectEntitiesTermination<TDatabase, TEntity>.Execute(int commandTimeout, Action<ISqlFieldReader> map)
            => Executor.Execute(commandTimeout, map);

        /// <inheritdoc />
        void SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, Action<ISqlFieldReader> read)
            => Executor.Execute(connection, read);

        /// <inheritdoc />
        void SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read)
            => Executor.Execute(connection, commandTimeout, read);

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(Action<ISqlFieldReader, TEntity> map)
            => Executor.Execute(map);

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(int commandTimeout, Action<ISqlFieldReader, TEntity> map)
            => Executor.Execute(commandTimeout, map);

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map)
            => Executor.Execute(connection, map);

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map)
            => Executor.Execute(connection, commandTimeout, map);

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, read, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(commandTimeout, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, map, cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
            => await Executor.ExecuteAsync(connection, commandTimeout, map, cancellationToken).ConfigureAwait(false);
        #endregion
        #endregion
    }
}
