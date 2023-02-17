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
    public class SelectObjectsStoredProcedureQueryExpressionBuilder<TDatabase, TEntity, T> : StoredProcedureQueryExpressionBuilder<TDatabase, TEntity>,
        StoredProcedureContinuation<TDatabase, TEntity>,
        SelectObjectsStoredProcedureContinuation<TDatabase, TEntity, T>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, StoredProcedure
    {
        #region internals
        private readonly Func<ISqlFieldReader, T> map;
        #endregion

        #region interface
        Func<ISqlFieldReader, T> SelectObjectsStoredProcedureTermination<TDatabase, TEntity, T>.Map => map;
        #endregion

        #region constructors
        public SelectObjectsStoredProcedureQueryExpressionBuilder(
            IQueryExpressionExecutionPipelineFactory executionPipelineFactory,
            StoredProcedureQueryExpression expression,
            Func<ISqlFieldReader, T> map
        ) : base(executionPipelineFactory, expression)
        {
            this.map = map ?? throw new ArgumentNullException(nameof(map));
        }
        #endregion

        #region methods
        #region SelectObjectsStoredProcedureTermination
        /// <inheritdoc/ >
        IList<T> SelectObjectsStoredProcedureTermination<TDatabase, TEntity, T>.Execute()
        {
            return ExecuteObjectsPipeline(
                null,
                null
            );
        }

        /// <inheritdoc/ >
		IList<T> SelectObjectsStoredProcedureTermination<TDatabase, TEntity, T>.Execute(ISqlConnection connection)
        {
            return ExecuteObjectsPipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc/ >
		IList<T> SelectObjectsStoredProcedureTermination<TDatabase, TEntity, T>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteObjectsPipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc/ >
		IList<T> SelectObjectsStoredProcedureTermination<TDatabase, TEntity, T>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteObjectsPipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc/ >
		Task<IList<T>> SelectObjectsStoredProcedureTermination<TDatabase, TEntity, T>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return ExecuteObjectsPipelineAsync(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc/ >
		IAsyncEnumerable<T> SelectObjectsStoredProcedureTermination<TDatabase, TEntity, T>.ExecuteAsyncEnumerable(CancellationToken cancellationToken)
        {
            return ExecuteObjectsPipelineAsyncEnumerable(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc/ >
		Task<IList<T>> SelectObjectsStoredProcedureTermination<TDatabase, TEntity, T>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecuteObjectsPipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc/ >
		IAsyncEnumerable<T> SelectObjectsStoredProcedureTermination<TDatabase, TEntity, T>.ExecuteAsyncEnumerable(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecuteObjectsPipelineAsyncEnumerable(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc/ >
		Task<IList<T>> SelectObjectsStoredProcedureTermination<TDatabase, TEntity, T>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteObjectsPipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        /// <inheritdoc/ >
		IAsyncEnumerable<T> SelectObjectsStoredProcedureTermination<TDatabase, TEntity, T>.ExecuteAsyncEnumerable(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteObjectsPipelineAsyncEnumerable(
                null,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        /// <inheritdoc/ >
		Task<IList<T>> SelectObjectsStoredProcedureTermination<TDatabase, TEntity, T>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteObjectsPipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        /// <inheritdoc/ >
		IAsyncEnumerable<T> SelectObjectsStoredProcedureTermination<TDatabase, TEntity, T>.ExecuteAsyncEnumerable(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteObjectsPipelineAsyncEnumerable(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        protected virtual IList<T> ExecuteObjectsPipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => CreateExecutionPipeline().ExecuteSelectObjectList(StoredProcedureQueryExpression, map, connection, configureCommand);

        protected virtual Task<IList<T>> ExecuteObjectsPipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => CreateExecutionPipeline().ExecuteSelectObjectListAsync(StoredProcedureQueryExpression, map, connection, configureCommand, ct);

        protected virtual IAsyncEnumerable<T> ExecuteObjectsPipelineAsyncEnumerable(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => CreateExecutionPipeline().ExecuteSelectObjectListAsyncEnumerable(StoredProcedureQueryExpression, map, connection, configureCommand, ct);

        private IStoredProcedureQueryExpressionExecutionPipeline CreateExecutionPipeline()
            => ExecutionPipelineFactory.CreateStoredProcedureExecutionPipeline()
                    ?? throw new DbExpressionConfigurationException(ExceptionMessages.ServiceResolution(StoredProcedureQueryExpression.GetType()));

        #endregion
        #endregion
    }
}
