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
    public class SelectEntitySelectQueryExpressionBuilder<TEntity> : SelectQueryExpressionBuilder,
        SelectEntity<TEntity>,
        SelectEntityContinuation<TEntity>,
        WithAlias<SelectEntityContinuation<TEntity>>,
        UnionSelectEntitiesInitiation<TEntity>
        where TEntity : class, IDbEntity, new()
    {
        #region internals
        private readonly Table<TEntity> table;
        #endregion

        #region constructors
        public SelectEntitySelectQueryExpressionBuilder(
            Func<ISelectQueryExecutionPipeline> executionPipelineFactory,
            SelectSetQueryExpressionBuilder controller,
            Table<TEntity> table
        ) : base(executionPipelineFactory, controller)
        {
            this.table = table ?? throw new ArgumentNullException(nameof(table));
        }
        #endregion

        #region methods
        #region UnionSelectEntitiesInitiation
        UnionSelectEntitiesContinuation<TEntity> UnionSelectEntitiesInitiation<TEntity>.Union()
        {
            Controller.ApplyUnion();
            return new SelectEntitiesSelectQueryExpressionBuilder<TEntity>(
                ExecutionPipelineFactory,
                Controller,
                table
            );
        }

        UnionSelectEntitiesContinuation<TEntity> UnionSelectEntitiesInitiation<TEntity>.UnionAll()
        {
            Controller.ApplyUnionAll();
            return new SelectEntitiesSelectQueryExpressionBuilder<TEntity>(
                ExecutionPipelineFactory,
                Controller,
                table
            );
        }
        #endregion

        #region SelectEntity<TEntity>
        /// <inheritdoc />
        SelectEntityContinuation<TEntity> SelectEntity<TEntity>.From<TFrom>(Table<TFrom> entity)
        {
            ApplyFrom(entity);
            return this;
        }
        #endregion

        #region SelectEntityContinuation<TEntity>
        /// <inheritdoc />
        SelectEntityContinuation<TEntity> SelectEntityContinuation<TEntity>.OrderBy(params AnyOrderByExpression[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TEntity> SelectEntityContinuation<TEntity>.OrderBy(IEnumerable<AnyOrderByExpression> orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TEntity> SelectEntityContinuation<TEntity>.GroupBy(params AnyGroupByExpression[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TEntity> SelectEntityContinuation<TEntity>.GroupBy(IEnumerable<AnyGroupByExpression> groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TEntity> SelectEntityContinuation<TEntity>.Having(AnyHavingExpression having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TEntity> SelectEntityContinuation<TEntity>.Where(AnyWhereExpression where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectEntityContinuation<TEntity>> SelectEntityContinuation<TEntity>.InnerJoin(AnyEntity entity)
            => new SelectEntityJoinExpressionBuilder<TEntity>(Controller.Current, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectEntityContinuation<TEntity>>> SelectEntityContinuation<TEntity>.InnerJoin(AnySelectSubquery subquery)
            => new SelectEntityJoinExpressionBuilder<TEntity>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectEntityContinuation<TEntity>> SelectEntityContinuation<TEntity>.LeftJoin(AnyEntity entity)
            => new SelectEntityJoinExpressionBuilder<TEntity>(Controller.Current, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectEntityContinuation<TEntity>>> SelectEntityContinuation<TEntity>.LeftJoin(AnySelectSubquery subquery)
            => new SelectEntityJoinExpressionBuilder<TEntity>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectEntityContinuation<TEntity>> SelectEntityContinuation<TEntity>.RightJoin(AnyEntity entity)
            => new SelectEntityJoinExpressionBuilder<TEntity>(Controller.Current, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectEntityContinuation<TEntity>>> SelectEntityContinuation<TEntity>.RightJoin(AnySelectSubquery subquery)
            => new SelectEntityJoinExpressionBuilder<TEntity>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectEntityContinuation<TEntity>> SelectEntityContinuation<TEntity>.FullJoin(AnyEntity entity)
            => new SelectEntityJoinExpressionBuilder<TEntity>(Controller.Current, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        WithAlias<JoinOn<SelectEntityContinuation<TEntity>>> SelectEntityContinuation<TEntity>.FullJoin(AnySelectSubquery subquery)
            => new SelectEntityJoinExpressionBuilder<TEntity>(Controller.Current, subquery.Expression, JoinOperationExpressionOperator.FULL, this); 

        /// <inheritdoc />
        SelectEntityContinuation<TEntity> SelectEntityContinuation<TEntity>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TEntity> WithAlias<SelectEntityContinuation<TEntity>>.As(string alias)
        {
            Controller.Current.From!.As(alias);
            return this;
        }
        #endregion

        #region SelectEntityTermination<TEntity>
        /// <inheritdoc />
        TEntity? SelectEntityTermination<TEntity>.Execute()
        {
            return ExecutePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TEntity>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TEntity>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TEntity>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TEntity>.Execute(Func<ISqlFieldReader, TEntity> map)
        {
            return ExecutePipeline(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TEntity>.Execute(int commandTimeout, Func<ISqlFieldReader, TEntity> map)
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
        TEntity? SelectEntityTermination<TEntity>.Execute(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TEntity>.Execute(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map)
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
        void SelectEntityTermination<TEntity>.Execute(Action<ISqlFieldReader> read)
        {
            ExecutePipeline(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectEntityTermination<TEntity>.Execute(int commandTimeout, Action<ISqlFieldReader> read)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            ExecutePipeline(
                null,
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectEntityTermination<TEntity>.Execute(ISqlConnection connection, Action<ISqlFieldReader> read)
        {
            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectEntityTermination<TEntity>.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read)
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
        TEntity? SelectEntityTermination<TEntity>.Execute(Action<ISqlFieldReader, TEntity> map)
        {
            return ExecutePipeline(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TEntity>.Execute(int commandTimeout, Action<ISqlFieldReader, TEntity> map)
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
        TEntity? SelectEntityTermination<TEntity>.Execute(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        TEntity? SelectEntityTermination<TEntity>.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map)
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
        async Task<TEntity?> SelectEntityTermination<TEntity>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                null,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TEntity>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        async Task<TEntity?> SelectEntityTermination<TEntity>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
        async Task SelectEntityTermination<TEntity>.ExecuteAsync(Action<ISqlFieldReader> map, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectEntityTermination<TEntity>.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
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
        async Task SelectEntityTermination<TEntity>.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectEntityTermination<TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
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
        async Task<TEntity?> SelectEntityTermination<TEntity>.ExecuteAsync(Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TEntity>.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
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
        async Task<TEntity?> SelectEntityTermination<TEntity>.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
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
        async Task<TEntity?> SelectEntityTermination<TEntity>.ExecuteAsync(Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
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
        async Task<TEntity?> SelectEntityTermination<TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
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
        async Task SelectEntityTermination<TEntity>.ExecuteAsync(Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                null,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectEntityTermination<TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
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
        async Task SelectEntityTermination<TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectEntityTermination<TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
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
        async Task<TEntity?> SelectEntityTermination<TEntity>.ExecuteAsync(Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                null,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
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
        async Task<TEntity?> SelectEntityTermination<TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TEntity?> SelectEntityTermination<TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
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

        protected virtual TEntity? ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => ExecutionPipelineFactory().ExecuteSelectEntity<TEntity>(Controller.Current, table, connection, configureCommand);

        protected virtual TEntity? ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity> map)
            => ExecutionPipelineFactory().ExecuteSelectEntity<TEntity>(Controller.Current, table, connection, configureCommand, map);

        protected virtual void ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read)
            => ExecutionPipelineFactory().ExecuteSelectEntity<TEntity>(Controller.Current, table, connection, configureCommand, read);

        protected virtual TEntity? ExecutePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map)
            => ExecutionPipelineFactory().ExecuteSelectEntity<TEntity>(Controller.Current, table, connection, configureCommand, map);

        protected virtual async Task<TEntity?> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => await ExecutionPipelineFactory().ExecuteSelectEntityAsync<TEntity>(Controller.Current, table, connection, configureCommand, cancellationToken).ConfigureAwait(false);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => await ExecutionPipelineFactory().ExecuteSelectEntityAsync<TEntity>(Controller.Current, table, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);

        protected virtual async Task<TEntity?> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await ExecutionPipelineFactory().ExecuteSelectEntityAsync<TEntity>(Controller.Current, table, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);

        protected virtual async Task<TEntity?> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await ExecutionPipelineFactory().ExecuteSelectEntityAsync<TEntity>(Controller.Current, table, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => await ExecutionPipelineFactory().ExecuteSelectEntityAsync<TEntity>(Controller.Current, table, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);

        protected virtual async Task<TEntity?> ExecutePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
            => await ExecutionPipelineFactory().ExecuteSelectEntityAsync<TEntity>(Controller.Current, table, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);
        #endregion
        #endregion
    }
}
