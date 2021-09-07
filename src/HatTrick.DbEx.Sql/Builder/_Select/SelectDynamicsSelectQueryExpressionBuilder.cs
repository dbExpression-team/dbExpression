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
    public class SelectDynamicsSelectQueryExpressionBuilder : SelectQueryExpressionBuilder,
        SelectDynamics,
        SelectDynamicsContinuation,
        SelectDynamicsOffsetContinuation,
        SelectDynamicsOrderByContinuation
    {
        #region internals
        #endregion

        #region constructors
        public SelectDynamicsSelectQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, SelectQueryExpression expression)
            : base(config, expression)
        {

        }
        #endregion

        #region methods
        #region SelectDynamics
        /// <inheritdoc />
        SelectDynamicsContinuation SelectDynamics.From<TEntity>(Entity<TEntity> entity)
        {
            ApplyFrom(entity);
            return this;
        }

        /// <inheritdoc />
        SelectDynamics SelectDynamics.Top(int value)
        {
            ApplyTop(value);
            return this;
        }

        /// <inheritdoc />
        SelectDynamics SelectDynamics.Distinct()
        {
            ApplyDistinct();
            return this;
        }
        #endregion

        #region SelectDynamicsContinuation

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation SelectDynamicsContinuation.OrderBy(params AnyOrderByClause[] orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation SelectDynamicsContinuation.OrderBy(IEnumerable<AnyOrderByClause> orderBy)
        {
            ApplyOrderBy(orderBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsContinuation SelectDynamicsContinuation.Where(AnyWhereClause where)
        {
            ApplyWhere(where);
            return this;
        }

        /// <inheritdoc />
        JoinOn<SelectDynamicsContinuation> SelectDynamicsContinuation.InnerJoin(AnyEntity entity)
            => new SelectDynamicsJoinBuilder(Expression, entity, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectDynamicsContinuation> SelectDynamicsContinuation.InnerJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinBuilder(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.INNER, this);

        /// <inheritdoc />
        JoinOn<SelectDynamicsContinuation> SelectDynamicsContinuation.LeftJoin(AnyEntity entity)
            => new SelectDynamicsJoinBuilder(Expression, entity, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectDynamicsContinuation> SelectDynamicsContinuation.LeftJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinBuilder(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.LEFT, this);

        /// <inheritdoc />
        JoinOn<SelectDynamicsContinuation> SelectDynamicsContinuation.RightJoin(AnyEntity entity)
            => new SelectDynamicsJoinBuilder(Expression, entity, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectDynamicsContinuation> SelectDynamicsContinuation.RightJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinBuilder(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.RIGHT, this);

        /// <inheritdoc />
        JoinOn<SelectDynamicsContinuation> SelectDynamicsContinuation.FullJoin(AnyEntity entity)
            => new SelectDynamicsJoinBuilder(Expression, entity, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        JoinOnWithAlias<SelectDynamicsContinuation> SelectDynamicsContinuation.FullJoin(AnySelectSubquery subquery)
            => new SelectDynamicsJoinBuilder(Expression, (subquery as IQueryExpressionProvider).Expression, JoinOperationExpressionOperator.FULL, this);

        /// <inheritdoc />
        SelectDynamicsContinuation SelectDynamicsContinuation.CrossJoin(AnyEntity entity)
        {
            ApplyCrossJoin(entity);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsContinuation SelectDynamicsContinuation.GroupBy(params AnyGroupByClause[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsContinuation SelectDynamicsContinuation.GroupBy(IEnumerable<AnyGroupByClause> groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsContinuation SelectDynamicsContinuation.Having(AnyHavingClause having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region Limit<SelectDynamicsOrderByContinuation>
        /// <inheritdoc />
        SelectDynamicsOrderByContinuation Limit<SelectDynamicsOrderByContinuation>.Having(AnyHavingClause having)
        {
            ApplyHaving(having);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation Limit<SelectDynamicsOrderByContinuation>.Limit(int value)
        {
            ApplyLimit(value);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOffsetContinuation SelectDynamicsOrderByContinuation.Offset(int value)
        {
            ApplyOffset(value);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation SelectDynamicsOrderByContinuation.GroupBy(params AnyGroupByClause[] groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation SelectDynamicsOrderByContinuation.GroupBy(IEnumerable<AnyGroupByClause> groupBy)
        {
            ApplyGroupBy(groupBy);
            return this;
        }

        /// <inheritdoc />
        SelectDynamicsOrderByContinuation SelectDynamicsOrderByContinuation.Having(AnyHavingClause having)
        {
            ApplyHaving(having);
            return this;
        }
        #endregion

        #region SelectDynamicsTermination
        /// <inheritdoc />
        IList<dynamic> SelectDynamicsTermination.Execute()
        {
            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                return ExecutePipeline(
                    connection,
                    null
                );
        }

        /// <inheritdoc />
        IList<dynamic> SelectDynamicsTermination.Execute(int commandTimeout)
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
        IList<dynamic> SelectDynamicsTermination.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        IList<dynamic> SelectDynamicsTermination.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        async Task<IList<dynamic>> SelectDynamicsTermination.ExecuteAsync(CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                return await ExecutePipelineAsync(
                    connection,
                    null,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<dynamic>> SelectDynamicsTermination.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        async Task<IList<dynamic>> SelectDynamicsTermination.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<dynamic>> SelectDynamicsTermination.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
        IList<T> SelectDynamicsTermination.Execute<T>(Func<ISqlFieldReader, T> map)
        {
            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                return ExecutePipeline(
                    connection,
                    null,
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <inheritdoc />
        IList<T> SelectDynamicsTermination.Execute<T>(int commandTimeout, Func<ISqlFieldReader, T> map)
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
        IList<T> SelectDynamicsTermination.Execute<T>(ISqlConnection connection, Func<ISqlFieldReader, T> map)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<T> SelectDynamicsTermination.Execute<T>(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, T> map)
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
        void SelectDynamicsTermination.Execute(Action<ISqlFieldReader> map)
        {
            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                ExecutePipeline(
                    connection,
                    null,
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <inheritdoc />
        void SelectDynamicsTermination.Execute(int commandTimeout, Action<ISqlFieldReader> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using (var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory))
                ExecutePipeline(
                    connection,
                    command => command.CommandTimeout = commandTimeout,
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <inheritdoc />
        void SelectDynamicsTermination.Execute(ISqlConnection connection, Action<ISqlFieldReader> read)
        {
            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectDynamicsTermination.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read)
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
        async Task<IList<T>> SelectDynamicsTermination.ExecuteAsync<T>(Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
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
        async Task<IList<T>> SelectDynamicsTermination.ExecuteAsync<T>(int commandTimeout, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
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
        async Task<IList<T>> SelectDynamicsTermination.ExecuteAsync<T>(ISqlConnection connection, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<T>> SelectDynamicsTermination.ExecuteAsync<T>(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
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
        async Task SelectDynamicsTermination.ExecuteAsync(Action<ISqlFieldReader> read, CancellationToken cancellationToken)
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
        async Task SelectDynamicsTermination.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
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
        async Task SelectDynamicsTermination.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectDynamicsTermination.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
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
        async Task SelectDynamicsTermination.ExecuteAsync(Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
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
        async Task SelectDynamicsTermination.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
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
        async Task SelectDynamicsTermination.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectDynamicsTermination.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
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
        #endregion

        protected virtual IList<dynamic> ExecutePipeline(ISqlConnection connection, Action<IDbCommand> configureCommand)
            => CreateSelectExecutionPipeline().ExecuteSelectDynamicList(Expression, connection, configureCommand);

        protected virtual void ExecutePipeline(ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read)
            => CreateSelectExecutionPipeline().ExecuteSelectDynamic(Expression, connection, configureCommand, read);

        protected virtual IList<T> ExecutePipeline<T>(ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map)
            => CreateSelectExecutionPipeline().ExecuteSelectObjectList(Expression, connection, configureCommand, map);

        protected virtual async Task<IList<dynamic>> ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken cancellationToken)
            => await CreateSelectExecutionPipeline().ExecuteSelectDynamicListAsync(Expression, connection, configureCommand, cancellationToken).ConfigureAwait(false);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => await CreateSelectExecutionPipeline().ExecuteSelectDynamicListAsync(Expression, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => await CreateSelectExecutionPipeline().ExecuteSelectDynamicListAsync(Expression, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);

        protected virtual async Task<IList<T>> ExecutePipelineAsync<T>(ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
            => await CreateSelectExecutionPipeline().ExecuteSelectObjectListAsync(Expression, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);

        protected virtual ISelectQueryExpressionExecutionPipeline CreateSelectExecutionPipeline()
        {
            return Configuration.ExecutionPipelineFactory?.CreateExecutionPipeline(Configuration, Expression) ?? throw new DbExpressionConfigurationException($"Could not resolve/create an execution pipeline for type '{GetType()}',  please review and ensure the correct configuration for DbExpression.");
        }
        #endregion
    }
}
