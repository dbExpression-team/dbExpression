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
    public class SelectEntitiesSelectQueryExpressionBuilder<TEntity> : SelectQueryExpressionBuilder,
        SelectEntities<TEntity>,
        SelectEntitiesContinuation<TEntity>,
        WithAlias<SelectEntitiesContinuation<TEntity>>,
        SelectEntitiesOrderByContinuation<TEntity>,
        SelectEntitiesOffsetContinuation<TEntity>,
        UnionSelectEntitiesContinuation<TEntity>
        where TEntity : class, IDbEntity, new()
    {
        #region internals
        private readonly Table<TEntity> table;
        #endregion

        #region constructors
        public SelectEntitiesSelectQueryExpressionBuilder(
            Func<ISelectQueryExecutionPipeline> executionPipelineFactory,
            SelectSetQueryExpressionBuilder controller,
            Table<TEntity> table
        ) : base(executionPipelineFactory, controller)
        {
            this.table = table ?? throw new ArgumentNullException(nameof(table));
        }
        #endregion

        #region methods
        #region UnionSelectEntitiesInitiation<TEntity>
        UnionSelectEntitiesContinuation<TEntity> UnionSelectEntitiesInitiation<TEntity>.Union()
        {
            Controller.ApplyUnion();
            return this;
        }

        UnionSelectEntitiesContinuation<TEntity> UnionSelectEntitiesInitiation<TEntity>.UnionAll()
        {
            Controller.ApplyUnionAll();
            return this;
        }
        #endregion

        #region UnionSelectValuesContinuation<TValue>
        /// <inheritdoc>
        SelectEntities<TEntity> UnionSelectEntitiesContinuation<TEntity>.SelectOne()
        {
            var select = Controller.Current.Select;
            var exp = Controller.StartNew();
            exp.Select = select;
            exp.Top = 1;
            return this;
        }

        /// <inheritdoc>
        SelectEntities<TEntity> UnionSelectEntitiesContinuation<TEntity>.SelectMany()
        {
            var select = Controller.Current.Select;
            var exp = Controller.StartNew();
            exp.Select = select;
            return this;
        }
        #endregion

        #region SelectEntities<TEntity>
        /// <inheritdoc />
        SelectEntities<TEntity> SelectEntities<TEntity>.Top(int value)
        {
            ApplyTop(value);
            return this;
        }

        /// <inheritdoc />
        SelectEntities<TEntity> SelectEntities<TEntity>.Distinct()
        {
            ApplyDistinct();
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TEntity> SelectEntities<TEntity>.From<TFrom>(Table<TFrom> entity)
        {
            ApplyFrom(entity);
            return this;
        }
        #endregion

        #region SelectEntitiesContinuation<TEntity>
        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TEntity> SelectEntitiesContinuation<TEntity>.OrderBy(params AnyOrderByExpression[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TEntity> SelectEntitiesContinuation<TEntity>.OrderBy(IEnumerable<AnyOrderByExpression>? orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TEntity> SelectEntitiesContinuation<TEntity>.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TEntity> SelectEntitiesContinuation<TEntity>.GroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TEntity> SelectEntitiesContinuation<TEntity>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TEntity> SelectEntitiesContinuation<TEntity>.Where(AnyWhereExpression? where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectEntitiesContinuation<TEntity>> SelectEntitiesContinuation<TEntity>.InnerJoin(AnyEntity entity)
            => new SelectEntitiesJoinExpressionBuilder<TEntity>(Controller.Current, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectEntitiesContinuation<TEntity>>> SelectEntitiesContinuation<TEntity>.InnerJoin(AnySelectSubquery subquery)
            => new SelectEntitiesJoinExpressionBuilder<TEntity>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectEntitiesContinuation<TEntity>> SelectEntitiesContinuation<TEntity>.LeftJoin(AnyEntity entity)
            => new SelectEntitiesJoinExpressionBuilder<TEntity>(Controller.Current, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectEntitiesContinuation<TEntity>>> SelectEntitiesContinuation<TEntity>.LeftJoin(AnySelectSubquery subquery)
            => new SelectEntitiesJoinExpressionBuilder<TEntity>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectEntitiesContinuation<TEntity>> SelectEntitiesContinuation<TEntity>.RightJoin(AnyEntity entity)
            => new SelectEntitiesJoinExpressionBuilder<TEntity>(Controller.Current, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectEntitiesContinuation<TEntity>>> SelectEntitiesContinuation<TEntity>.RightJoin(AnySelectSubquery subquery)
            => new SelectEntitiesJoinExpressionBuilder<TEntity>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectEntitiesContinuation<TEntity>> SelectEntitiesContinuation<TEntity>.FullJoin(AnyEntity entity)
            => new SelectEntitiesJoinExpressionBuilder<TEntity>(Controller.Current, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectEntitiesContinuation<TEntity>>> SelectEntitiesContinuation<TEntity>.FullJoin(AnySelectSubquery subquery)
            => new SelectEntitiesJoinExpressionBuilder<TEntity>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectEntitiesContinuation<TEntity> SelectEntitiesContinuation<TEntity>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesContinuation<TEntity> WithAlias<SelectEntitiesContinuation<TEntity>>.As(string alias)
        {
            Controller.Current.From!.As(alias);
            return this;
        }
        #endregion

        #region SelectEntitiesOrderByContinuation<TEntity>
        /// <inheritdoc />
        SelectEntitiesOffsetContinuation<TEntity> SelectEntitiesOrderByContinuation<TEntity>.Offset(int value)
        {
            ApplyOffset(value);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TEntity> SelectEntitiesOrderByContinuation<TEntity>.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TEntity> SelectEntitiesOrderByContinuation<TEntity>.GroupBy(IEnumerable<AnyGroupByExpression>? groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TEntity> SelectEntitiesOrderByContinuation<TEntity>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TEntity> Limit<SelectEntitiesOrderByContinuation<TEntity>>.Having(AnyHavingExpression? having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectEntitiesOffsetContinuation<TEntity>
        /// <inheritdoc />
        SelectEntitiesOrderByContinuation<TEntity> Limit<SelectEntitiesOrderByContinuation<TEntity>>.Limit(int value)
        {
            ApplyLimit(value);
            return this;
        }
        #endregion

        #region SelectEntitiesTermination<TEntity>
        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TEntity>.Execute()
        {
            return ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TEntity>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TEntity>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TEntity>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TEntity>.Execute(Func<ISqlFieldReader, TEntity> map)
        {
            return ExecutePipeline(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TEntity>.Execute(int commandTimeout, Func<ISqlFieldReader, TEntity> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TEntity>.Execute(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TEntity>.Execute(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map)
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
        void SelectEntitiesTermination<TEntity>.Execute(Action<ISqlFieldReader> map)
        {
            ExecutePipeline(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        void SelectEntitiesTermination<TEntity>.Execute(int commandTimeout, Action<ISqlFieldReader> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        void SelectEntitiesTermination<TEntity>.Execute(ISqlConnection connection, Action<ISqlFieldReader> read)
        {
            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectEntitiesTermination<TEntity>.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read)
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
        IList<TEntity> SelectEntitiesTermination<TEntity>.Execute(Action<ISqlFieldReader, TEntity> map)
        {
            return ExecutePipeline(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TEntity>.Execute(int commandTimeout, Action<ISqlFieldReader, TEntity> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TEntity>.Execute(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TEntity>.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map)
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
        async Task<IList<TEntity>> SelectEntitiesTermination<TEntity>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TEntity>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TEntity>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
        async Task SelectEntitiesTermination<TEntity>.ExecuteAsync(Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TEntity>.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            await ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TEntity>.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
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
        async Task<IList<TEntity>> SelectEntitiesTermination<TEntity>.ExecuteAsync(Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TEntity>.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TEntity>.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
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
        async Task<IList<TEntity>> SelectEntitiesTermination<TEntity>.ExecuteAsync(Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
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
        async Task SelectEntitiesTermination<TEntity>.ExecuteAsync(Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            await ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
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
        async Task<IList<TEntity>> SelectEntitiesTermination<TEntity>.ExecuteAsync(Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
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
        protected virtual IList<TEntity> ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => Controller.CreateExecutionPipeline().ExecuteSelectEntityList<TEntity>(Controller.SelectSetQueryExpression, table, connection, configureCommand);

        protected virtual IList<TEntity> ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity> map)
            => Controller.CreateExecutionPipeline().ExecuteSelectEntityList<TEntity>(Controller.SelectSetQueryExpression, table, connection, configureCommand, map);

        protected virtual void ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read)
            => Controller.CreateExecutionPipeline().ExecuteSelectEntityList<TEntity>(Controller.SelectSetQueryExpression, table, connection, configureCommand, read);

        protected virtual IList<TEntity> ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map)
            => Controller.CreateExecutionPipeline().ExecuteSelectEntityList<TEntity>(Controller.SelectSetQueryExpression, table, connection, configureCommand, map);

        protected virtual async Task<IList<TEntity>> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectEntityListAsync<TEntity>(Controller.SelectSetQueryExpression, table, connection, configureCommand, cancellationToken).ConfigureAwait(false);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectEntityListAsync<TEntity>(Controller.SelectSetQueryExpression, table, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);

        protected virtual async Task<IList<TEntity>> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectEntityListAsync<TEntity>(Controller.SelectSetQueryExpression, table, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);

        protected virtual async Task<IList<TEntity>> ExecutePipelineAsync<T>(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectEntityListAsync<TEntity>(Controller.SelectSetQueryExpression, table, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);

        protected virtual async Task<IList<TEntity>> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectEntityListAsync<TEntity>(Controller.SelectSetQueryExpression, table, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task> map, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectEntityListAsync<TEntity>(Controller.SelectSetQueryExpression, table, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);

        protected virtual async Task<IList<TEntity>> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
            => await Controller.CreateExecutionPipeline().ExecuteSelectEntityListAsync<TEntity>(Controller.SelectSetQueryExpression, table, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);
        #endregion
        #endregion
        #endregion
    }
}
