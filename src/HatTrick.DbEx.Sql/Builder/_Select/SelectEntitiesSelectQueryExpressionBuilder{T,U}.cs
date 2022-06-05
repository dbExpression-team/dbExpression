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
        SelectEntities<TDatabase, TEntity>,
        SelectEntitiesContinuation<TDatabase, TEntity>,
        WithAlias<SelectEntitiesContinuation<TDatabase, TEntity>>,
        SelectEntitiesOrderByContinuation<TDatabase, TEntity>,
        SelectEntitiesOffsetContinuation<TDatabase, TEntity>,
        UnionSelectEntitiesContinuation<TDatabase, TEntity>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, IDbEntity, new()
    {
        #region internals
        private readonly Table<TEntity> table;
        #endregion

        #region constructors
        public SelectEntitiesSelectQueryExpressionBuilder(
            SqlDatabaseRuntimeConfiguration config,
            SelectSetQueryExpressionBuilder<TDatabase> controller,
            Table<TEntity> table
        ) : base(config, controller)
        {
            this.table = table ?? throw new ArgumentNullException(nameof(table));
        }
        #endregion

        #region methods
        #region UnionSelectEntitiesInitiation<TDatabase, TEntity>
        UnionSelectEntitiesContinuation<TDatabase, TEntity> UnionSelectEntitiesInitiation<TDatabase, TEntity>.Union()
        {
            Controller.ApplyUnion();
            return this;
        }

        UnionSelectEntitiesContinuation<TDatabase, TEntity> UnionSelectEntitiesInitiation<TDatabase, TEntity>.UnionAll()
        {
            Controller.ApplyUnionAll();
            return this;
        }
        #endregion

        #region UnionSelectValuesContinuation<TDatabase, TValue>
        /// <inheritdoc>
        SelectEntities<TDatabase, TEntity> UnionSelectEntitiesContinuation<TDatabase, TEntity>.SelectOne()
        {
            var select = Controller.Current.Select;
            var exp = Controller.StartNew();
            exp.Select = select;
            exp.Top = 1;
            return this;
        }

        /// <inheritdoc>
        SelectEntities<TDatabase, TEntity> UnionSelectEntitiesContinuation<TDatabase, TEntity>.SelectMany()
        {
            var select = Controller.Current.Select;
            var exp = Controller.StartNew();
            exp.Select = select;
            return this;
        }
        #endregion

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
        SelectEntitiesContinuation<TDatabase, TEntity> SelectEntities<TDatabase, TEntity>.From<TFrom>(Table<TFrom> entity)
        {
            ApplyFrom(entity);
            return this;
        }
        #endregion

        #region SelectEntitiesContinuation<TDatabase, TEntity>
        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.OrderBy(params AnyOrderByExpression[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.OrderBy(IEnumerable<AnyOrderByExpression>? orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.GroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.Where(AnyWhereExpression? where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectEntitiesContinuation<TDatabase, TEntity>> SelectEntitiesContinuation<TDatabase, TEntity>.InnerJoin(AnyEntity entity)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(Controller.Current, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectEntitiesContinuation<TDatabase, TEntity>>> SelectEntitiesContinuation<TDatabase, TEntity>.InnerJoin(AnySelectSubquery subquery)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectEntitiesContinuation<TDatabase, TEntity>> SelectEntitiesContinuation<TDatabase, TEntity>.LeftJoin(AnyEntity entity)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(Controller.Current, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectEntitiesContinuation<TDatabase, TEntity>>> SelectEntitiesContinuation<TDatabase, TEntity>.LeftJoin(AnySelectSubquery subquery)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectEntitiesContinuation<TDatabase, TEntity>> SelectEntitiesContinuation<TDatabase, TEntity>.RightJoin(AnyEntity entity)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(Controller.Current, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectEntitiesContinuation<TDatabase, TEntity>>> SelectEntitiesContinuation<TDatabase, TEntity>.RightJoin(AnySelectSubquery subquery)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectEntitiesContinuation<TDatabase, TEntity>> SelectEntitiesContinuation<TDatabase, TEntity>.FullJoin(AnyEntity entity)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(Controller.Current, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectEntitiesContinuation<TDatabase, TEntity>>> SelectEntitiesContinuation<TDatabase, TEntity>.FullJoin(AnySelectSubquery subquery)
            => new SelectEntitiesJoinExpressionBuilder<TDatabase, TEntity>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectEntitiesContinuation<TDatabase, TEntity> SelectEntitiesContinuation<TDatabase, TEntity>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TDatabase, TEntity> WithAlias<SelectEntitiesContinuation<TDatabase, TEntity>>.As(string alias)
        {
            Controller.Current.From!.As(alias);
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
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> SelectEntitiesOrderByContinuation<TDatabase, TEntity>.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> SelectEntitiesOrderByContinuation<TDatabase, TEntity>.GroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> SelectEntitiesOrderByContinuation<TDatabase, TEntity>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TDatabase, TEntity> Limit<SelectEntitiesOrderByContinuation<TDatabase, TEntity>>.Having(AnyHavingExpression? having)
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
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecutePipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(Func<ISqlFieldReader, TEntity> map)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecutePipeline(
                connection,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(int commandTimeout, Func<ISqlFieldReader, TEntity> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        void SelectEntitiesTermination<TDatabase, TEntity>.Execute(Action<ISqlFieldReader> map)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            ExecutePipeline(
                connection,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        void SelectEntitiesTermination<TDatabase, TEntity>.Execute(int commandTimeout, Action<ISqlFieldReader> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        void SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, Action<ISqlFieldReader> read)
        {
            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(Action<ISqlFieldReader, TEntity> map)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecutePipeline(
                connection,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(int commandTimeout, Action<ISqlFieldReader, TEntity> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            await ExecutePipelineAsync(
                connection,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecutePipelineAsync(
                connection,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecutePipelineAsync(
                connection,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            await ExecutePipelineAsync(
                connection,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecutePipelineAsync(
                connection,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        #region execute pipeline
        protected virtual IList<TEntity> ExecutePipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand)
            => Controller.CreateExecutionPipeline().ExecuteSelectEntityList<TEntity>(Controller.SelectSetQueryExpression, table, connection, configureCommand);

        protected virtual IList<TEntity> ExecutePipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity> map)
            => Controller.CreateExecutionPipeline().ExecuteSelectEntityList<TEntity>(Controller.SelectSetQueryExpression, table, connection, configureCommand, map);

        protected virtual void ExecutePipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read)
            => Controller.CreateExecutionPipeline().ExecuteSelectEntityList<TEntity>(Controller.SelectSetQueryExpression, table, connection, configureCommand, read);

        protected virtual IList<TEntity> ExecutePipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map)
            => Controller.CreateExecutionPipeline().ExecuteSelectEntityList<TEntity>(Controller.SelectSetQueryExpression, table, connection, configureCommand, map);

        protected virtual async Task<IList<TEntity>> ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectEntityListAsync<TEntity>(Controller.SelectSetQueryExpression, table, connection, configureCommand, cancellationToken).ConfigureAwait(false);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectEntityListAsync<TEntity>(Controller.SelectSetQueryExpression, table, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);

        protected virtual async Task<IList<TEntity>> ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectEntityListAsync<TEntity>(Controller.SelectSetQueryExpression, table, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);

        protected virtual async Task<IList<TEntity>> ExecutePipelineAsync<T>(ISqlConnection connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectEntityListAsync<TEntity>(Controller.SelectSetQueryExpression, table, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);

        protected virtual async Task<IList<TEntity>> ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectEntityListAsync<TEntity>(Controller.SelectSetQueryExpression, table, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task> map, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectEntityListAsync<TEntity>(Controller.SelectSetQueryExpression, table, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);

        protected virtual async Task<IList<TEntity>> ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectEntityListAsync<TEntity>(Controller.SelectSetQueryExpression, table, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);
        #endregion
        #endregion
        #endregion
    }
}
