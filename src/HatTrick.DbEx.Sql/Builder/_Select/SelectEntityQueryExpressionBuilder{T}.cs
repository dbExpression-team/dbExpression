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
    public class SelectEntityQueryExpressionBuilder<TEntity> : SelectQueryExpressionBuilder,
        IExpressionBuilder<TEntity>,
        SelectEntity<TEntity>,
        SelectEntityContinuation<TEntity>
        where TEntity : class, IDbEntity, new()
    {
        #region constructors
        public SelectEntityQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, SelectQueryExpression expression) : base(config, expression)
        {

        }
        #endregion

        #region methods
        protected override void ApplyFrom<T>(Entity<T> entity)
        {
            base.ApplyFrom(entity);
            Expression.Select = new SelectExpressionSet(entity.BuildInclusiveSelectExpression());
        }

        /// <inheritdoc />
        SelectEntityContinuation<TEntity> SelectEntity<TEntity>.From(Entity<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TEntity> SelectEntityContinuation<TEntity>.OrderBy(params AnyOrderByClause[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TEntity> SelectEntityContinuation<TEntity>.OrderBy(IEnumerable<AnyOrderByClause> orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TEntity> SelectEntityContinuation<TEntity>.GroupBy(params AnyGroupByClause[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TEntity> SelectEntityContinuation<TEntity>.GroupBy(IEnumerable<AnyGroupByClause> groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TEntity> SelectEntityContinuation<TEntity>.Having(AnyHavingClause having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectEntityContinuation<TEntity> SelectEntityContinuation<TEntity>.Where(AnyWhereClause where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectEntityContinuation<TEntity>> SelectEntityContinuation<TEntity>.InnerJoin(AnyEntity entity)
            => new SelectEntityJoinBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectEntityContinuation<TEntity>> SelectEntityContinuation<TEntity>.InnerJoin(AnySelectSubquery subquery)
            => new SelectEntityJoinBuilder<TEntity>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectEntityContinuation<TEntity>> SelectEntityContinuation<TEntity>.LeftJoin(AnyEntity entity)
            => new SelectEntityJoinBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectEntityContinuation<TEntity>> SelectEntityContinuation<TEntity>.LeftJoin(AnySelectSubquery subquery)
            => new SelectEntityJoinBuilder<TEntity>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectEntityContinuation<TEntity>> SelectEntityContinuation<TEntity>.RightJoin(AnyEntity entity)
            => new SelectEntityJoinBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectEntityContinuation<TEntity>> SelectEntityContinuation<TEntity>.RightJoin(AnySelectSubquery subquery)
            => new SelectEntityJoinBuilder<TEntity>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectEntityContinuation<TEntity>> SelectEntityContinuation<TEntity>.FullJoin(AnyEntity entity)
            => new SelectEntityJoinBuilder<TEntity>(Expression, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectEntityContinuation<TEntity>> SelectEntityContinuation<TEntity>.FullJoin(AnySelectSubquery subquery)
            => new SelectEntityJoinBuilder<TEntity>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectEntityContinuation<TEntity> SelectEntityContinuation<TEntity>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        #region SelectEntityTermination
        /// <inheritdoc />
        TEntity SelectEntityTermination<TEntity>.Execute()
        {
            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                return ExecutePipeline(
                    connection,
                    null
                );
        }

        /// <inheritdoc />
        TEntity SelectEntityTermination<TEntity>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                return ExecutePipeline(
                    connection,
                    command => command.CommandTimeout = commandTimeout
                );
        }

        /// <inheritdoc />
        TEntity SelectEntityTermination<TEntity>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        TEntity SelectEntityTermination<TEntity>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        TEntity SelectEntityTermination<TEntity>.Execute(Func<ISqlFieldReader, TEntity> map)
        {
            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                return ExecutePipeline(
                    connection,
                    null,
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <inheritdoc />
        TEntity SelectEntityTermination<TEntity>.Execute(int commandTimeout, Func<ISqlFieldReader, TEntity> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                return ExecutePipeline(
                    connection,
                    command => command.CommandTimeout = commandTimeout,
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <inheritdoc />
        TEntity SelectEntityTermination<TEntity>.Execute(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        TEntity SelectEntityTermination<TEntity>.Execute(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map)
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
            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                ExecutePipeline(
                    connection,
                    null,
                    read ?? throw new ArgumentNullException(nameof(read))
                );
        }

        /// <inheritdoc />
        void SelectEntityTermination<TEntity>.Execute(int commandTimeout, Action<ISqlFieldReader> read)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                ExecutePipeline(
                    connection,
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
        TEntity SelectEntityTermination<TEntity>.Execute(Action<ISqlFieldReader, TEntity> map)
        {
            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                return ExecutePipeline(
                    connection,
                    null,
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <inheritdoc />
        TEntity SelectEntityTermination<TEntity>.Execute(int commandTimeout, Action<ISqlFieldReader, TEntity> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                return ExecutePipeline(
                    connection,
                    command => command.CommandTimeout = commandTimeout,
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <inheritdoc />
        TEntity SelectEntityTermination<TEntity>.Execute(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        TEntity SelectEntityTermination<TEntity>.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map)
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
        async Task<TEntity> SelectEntityTermination<TEntity>.ExecuteAsync(CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                return await ExecutePipelineAsync(
                    connection,
                    null,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TEntity> SelectEntityTermination<TEntity>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                return await ExecutePipelineAsync(
                    connection,
                    command => command.CommandTimeout = commandTimeout,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TEntity> SelectEntityTermination<TEntity>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TEntity> SelectEntityTermination<TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                await ExecutePipelineAsync(
                    connection,
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

            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                await ExecutePipelineAsync(
                    connection,
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
        async Task<TEntity> SelectEntityTermination<TEntity>.ExecuteAsync(Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                return await ExecutePipelineAsync(
                    connection,
                    null,
                    map ?? throw new ArgumentNullException(nameof(map)),
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TEntity> SelectEntityTermination<TEntity>.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                return await ExecutePipelineAsync(
                    connection,
                    command => command.CommandTimeout = commandTimeout,
                    map ?? throw new ArgumentNullException(nameof(map)),
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TEntity> SelectEntityTermination<TEntity>.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TEntity> SelectEntityTermination<TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
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
        async Task<TEntity> SelectEntityTermination<TEntity>.ExecuteAsync(Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                return await ExecutePipelineAsync(
                    connection,
                    null,
                    map ?? throw new ArgumentNullException(nameof(map)),
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TEntity> SelectEntityTermination<TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                return await ExecutePipelineAsync(
                    connection,
                    command => command.CommandTimeout = commandTimeout,
                    map ?? throw new ArgumentNullException(nameof(map)),
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TEntity> SelectEntityTermination<TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TEntity> SelectEntityTermination<TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
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
            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                await ExecutePipelineAsync(
                    connection,
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

            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                await ExecutePipelineAsync(
                    connection,
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
        async Task<TEntity> SelectEntityTermination<TEntity>.ExecuteAsync(Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                return await ExecutePipelineAsync(
                    connection,
                    null,
                    map ?? throw new ArgumentNullException(nameof(map)),
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TEntity> SelectEntityTermination<TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                return await ExecutePipelineAsync(
                    connection,
                    command => command.CommandTimeout = commandTimeout,
                    map ?? throw new ArgumentNullException(nameof(map)),
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TEntity> SelectEntityTermination<TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TEntity> SelectEntityTermination<TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
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

        protected virtual TEntity ExecutePipeline(ISqlConnection connection, Action<IDbCommand> configureCommand)
            => CreateSelectExecutionPipeline().ExecuteSelectEntity<TEntity>(Expression, connection, configureCommand);

        protected virtual TEntity ExecutePipeline(ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, TEntity> map)
            => CreateSelectExecutionPipeline().ExecuteSelectEntity(Expression, connection, configureCommand, map);

        protected virtual void ExecutePipeline(ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read)
            => CreateSelectExecutionPipeline().ExecuteSelectEntity<TEntity>(Expression, connection, configureCommand, read);

        protected virtual TEntity ExecutePipeline(ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader, TEntity> map)
            => CreateSelectExecutionPipeline().ExecuteSelectEntity(Expression, connection, configureCommand, map);

        protected virtual async Task<TEntity> ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken cancellationToken)
            => await CreateSelectExecutionPipeline().ExecuteSelectEntityAsync<TEntity>(Expression, connection, configureCommand, cancellationToken).ConfigureAwait(false);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => await CreateSelectExecutionPipeline().ExecuteSelectEntityAsync<TEntity>(Expression, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);

        protected virtual async Task<TEntity> ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await CreateSelectExecutionPipeline().ExecuteSelectEntityAsync(Expression, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);

        protected virtual async Task<TEntity> ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
            => await CreateSelectExecutionPipeline().ExecuteSelectEntityAsync(Expression, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => await CreateSelectExecutionPipeline().ExecuteSelectEntityAsync<TEntity>(Expression, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);

        protected virtual async Task<TEntity> ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
            => await CreateSelectExecutionPipeline().ExecuteSelectEntityAsync(Expression, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);

        protected virtual ISelectQueryExpressionExecutionPipeline CreateSelectExecutionPipeline()
        {
            return Configuration.ExecutionPipelineFactory?.CreateExecutionPipeline(Configuration, Expression) ?? throw new DbExpressionConfigurationException($"Could not resolve/create an execution pipeline for type '{GetType()}',  please review and ensure the correct configuration for DbExpression.");
        }
        #endregion
        #endregion
    }
}
