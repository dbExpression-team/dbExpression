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
    public class SelectValuesSelectQueryExpressionBuilder<TValue> : SelectQueryExpressionBuilder,
        IExpressionBuilder<TValue>,
        SelectValues<TValue>,
        SelectValuesContinuation<TValue>,
        SelectValuesOffsetContinuation<TValue>,
        SelectValuesOrderByContinuation<TValue>
    {
        #region constructors
        public SelectValuesSelectQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, SelectQueryExpression expression) 
            : base(config, expression)
        {

        }
        #endregion

        #region methods
        /// <inheritdoc />
        SelectValues<TValue> SelectValues<TValue>.Top(int value)
        {
            ApplyTop(value);
            return this;
        }

        /// <inheritdoc />
        SelectValues<TValue> SelectValues<TValue>.Distinct()
        {
            ApplyDistinct();
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TValue> SelectValues<TValue>.From<TEntity>(Entity<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOrderByContinuation<TValue> SelectValuesContinuation<TValue>.OrderBy(params AnyOrderByClause[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOrderByContinuation<TValue> SelectValuesContinuation<TValue>.OrderBy(IEnumerable<AnyOrderByClause> orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TValue> SelectValuesContinuation<TValue>.GroupBy(params AnyGroupByClause[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TValue> SelectValuesContinuation<TValue>.GroupBy(IEnumerable<AnyGroupByClause> groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TValue> SelectValuesContinuation<TValue>.Having(AnyHavingClause having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectValuesContinuation<TValue> SelectValuesContinuation<TValue>.Where(AnyWhereClause where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectValuesContinuation<TValue>> SelectValuesContinuation<TValue>.InnerJoin(AnyEntity entity)
            => new SelectValuesJoinBuilder<TValue>(Expression, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectValuesContinuation<TValue>> SelectValuesContinuation<TValue>.InnerJoin(AnySelectSubquery subquery)
            => new SelectValuesJoinBuilder<TValue>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectValuesContinuation<TValue>> SelectValuesContinuation<TValue>.LeftJoin(AnyEntity entity)
            => new SelectValuesJoinBuilder<TValue>(Expression, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectValuesContinuation<TValue>> SelectValuesContinuation<TValue>.LeftJoin(AnySelectSubquery subquery)
            => new SelectValuesJoinBuilder<TValue>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectValuesContinuation<TValue>> SelectValuesContinuation<TValue>.RightJoin(AnyEntity entity)
            => new SelectValuesJoinBuilder<TValue>(Expression, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectValuesContinuation<TValue>> SelectValuesContinuation<TValue>.RightJoin(AnySelectSubquery subquery)
            => new SelectValuesJoinBuilder<TValue>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectValuesContinuation<TValue>> SelectValuesContinuation<TValue>.FullJoin(AnyEntity entity)
            => new SelectValuesJoinBuilder<TValue>(Expression, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectValuesContinuation<TValue>> SelectValuesContinuation<TValue>.FullJoin(AnySelectSubquery subquery)
            => new SelectValuesJoinBuilder<TValue>(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectValuesContinuation<TValue> SelectValuesContinuation<TValue>.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOffsetContinuation<TValue> SelectValuesOrderByContinuation<TValue>.Offset(int value)
        {
            ApplyOffset(value);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOrderByContinuation<TValue> Limit<SelectValuesOrderByContinuation<TValue>>.Limit(int value)
        {
            ApplyLimit(value);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOrderByContinuation<TValue> SelectValuesOrderByContinuation<TValue>.GroupBy(params AnyGroupByClause[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOrderByContinuation<TValue> SelectValuesOrderByContinuation<TValue>.GroupBy(IEnumerable<AnyGroupByClause> groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOrderByContinuation<TValue> Limit<SelectValuesOrderByContinuation<TValue>>.Having(AnyHavingClause having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectValuesOrderByContinuation<TValue> SelectValuesOrderByContinuation<TValue>.Having(AnyHavingClause having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectValuesTermination<TValue>
        /// <inheritdoc />
        IList<TValue> SelectValuesTermination<TValue>.Execute()
        {
            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                return ExecutePipeline(
                    connection,
                    null
                );
        }

        /// <inheritdoc />
        IList<TValue> SelectValuesTermination<TValue>.Execute(int commandTimeout)
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
        IList<TValue> SelectValuesTermination<TValue>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        IList<TValue> SelectValuesTermination<TValue>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        void SelectValuesTermination<TValue>.Execute(Action<TValue> handleValue)
        {
            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                ExecutePipeline(
                    connection,
                    null,
                    handleValue ?? throw new ArgumentNullException(nameof(handleValue))
                );
        }

        /// <inheritdoc />
        void SelectValuesTermination<TValue>.Execute(int commandTimeout, Action<TValue> handleValue)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                ExecutePipeline(
                    connection,
                    command => command.CommandTimeout = commandTimeout,
                    handleValue ?? throw new ArgumentNullException(nameof(handleValue))
                );
        }

        /// <inheritdoc />
        void SelectValuesTermination<TValue>.Execute(ISqlConnection connection, Action<TValue> handleValue)
        {
            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                handleValue ?? throw new ArgumentNullException(nameof(handleValue))
            );
        }

        /// <inheritdoc />
        void SelectValuesTermination<TValue>.Execute(ISqlConnection connection, int commandTimeout, Action<TValue> handleValue)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                handleValue ?? throw new ArgumentNullException(nameof(handleValue))
            );
        }

        /// <inheritdoc />
        async Task<IList<TValue>> SelectValuesTermination<TValue>.ExecuteAsync(CancellationToken cancellationToken = default)
        {
            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                return await ExecutePipelineAsync(
                    connection,
                    null,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TValue>> SelectValuesTermination<TValue>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken = default)
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
        async Task<IList<TValue>> SelectValuesTermination<TValue>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken = default)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TValue>> SelectValuesTermination<TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default)
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
        async Task SelectValuesTermination<TValue>.ExecuteAsync(Action<TValue> read, CancellationToken cancellationToken = default)
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
        async Task SelectValuesTermination<TValue>.ExecuteAsync(int commandTimeout, Action<TValue> read, CancellationToken cancellationToken = default)
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
        async Task SelectValuesTermination<TValue>.ExecuteAsync(ISqlConnection connection, Action<TValue> read, CancellationToken cancellationToken = default)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectValuesTermination<TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<TValue> read, CancellationToken cancellationToken = default)
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
        async Task SelectValuesTermination<TValue>.ExecuteAsync(Func<TValue, Task> read, CancellationToken cancellationToken = default)
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
        async Task SelectValuesTermination<TValue>.ExecuteAsync(int commandTimeout, Func<TValue, Task> read, CancellationToken cancellationToken = default)
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
        async Task SelectValuesTermination<TValue>.ExecuteAsync(ISqlConnection connection, Func<TValue, Task> read, CancellationToken cancellationToken = default)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectValuesTermination<TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<TValue, Task> read, CancellationToken cancellationToken = default)
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

        protected virtual IList<TValue> ExecutePipeline(ISqlConnection connection, Action<IDbCommand> configureCommand)
            => CreateSelectExecutionPipeline().ExecuteSelectValueList<TValue>(Expression, connection, configureCommand);

        protected virtual void ExecutePipeline(ISqlConnection connection, Action<IDbCommand> configureCommand, Action<TValue> read)
            => CreateSelectExecutionPipeline().ExecuteSelectValueList(Expression, connection, configureCommand, read);

        protected virtual async Task<IList<TValue>> ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken cancellationToken)
            => await CreateSelectExecutionPipeline().ExecuteSelectValueListAsync<TValue>(Expression, connection, configureCommand, cancellationToken).ConfigureAwait(false);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand> configureCommand, Action<TValue> read, CancellationToken cancellationToken)
            => await CreateSelectExecutionPipeline().ExecuteSelectValueListAsync(Expression, connection, configureCommand, read, cancellationToken);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand> configureCommand, Func<TValue, Task> read, CancellationToken cancellationToken)
            => await CreateSelectExecutionPipeline().ExecuteSelectValueListAsync(Expression, connection, configureCommand, read, cancellationToken);

        protected virtual ISelectQueryExpressionExecutionPipeline CreateSelectExecutionPipeline()
        {
            return Configuration.ExecutionPipelineFactory?.CreateExecutionPipeline(Configuration, Expression) ?? throw new DbExpressionConfigurationException($"Could not resolve/create an execution pipeline for type '{GetType()}',  please review and ensure the correct configuration for DbExpression.");
        }
        #endregion
    }
}
