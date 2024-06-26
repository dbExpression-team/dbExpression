﻿#region license
// Copyright (c) dbExpression.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion

using DbExpression.Sql.Connection;
using DbExpression.Sql.Executor;
using DbExpression.Sql.Expression;
using DbExpression.Sql.Pipeline;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace DbExpression.Sql.Builder
{
    public class SelectObjectStoredProcedureQueryExpressionBuilder<TDatabase, TEntity, T> : StoredProcedureQueryExpressionBuilder<TDatabase, TEntity>,
        StoredProcedureContinuation<TDatabase, TEntity>,
        SelectObjectStoredProcedureContinuation<TDatabase, TEntity, T>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, StoredProcedure
    {
        private readonly Func<ISqlFieldReader, T> map;
        Func<ISqlFieldReader, T> SelectObjectStoredProcedureTermination<TDatabase, TEntity, T>.Map => map;

        public SelectObjectStoredProcedureQueryExpressionBuilder(
            IQueryExpressionExecutionPipelineFactory executionPipelineFactory,
            StoredProcedureQueryExpression expression,
            Func<ISqlFieldReader, T> map
        ) : base(executionPipelineFactory, expression)
        {
            this.map = map ?? throw new ArgumentNullException(nameof(map));
        }

        #region methods
        #region SelectObjectStoredProcedureTermination
        /// <inheritdoc />
        T? SelectObjectStoredProcedureTermination<TDatabase, TEntity, T>.Execute()
        {
            return ExecuteObjectPipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
		T? SelectObjectStoredProcedureTermination<TDatabase, TEntity, T>.Execute(ISqlConnection connection)
        {
            return ExecuteObjectPipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
		T? SelectObjectStoredProcedureTermination<TDatabase, TEntity, T>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteObjectPipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
		T? SelectObjectStoredProcedureTermination<TDatabase, TEntity, T>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteObjectPipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        async Task<T?> SelectObjectStoredProcedureTermination<TDatabase, TEntity, T>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return await ExecuteObjectPipelineAsync(
                null,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
		async Task<T?> SelectObjectStoredProcedureTermination<TDatabase, TEntity, T>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecuteObjectPipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
		async Task<T?> SelectObjectStoredProcedureTermination<TDatabase, TEntity, T>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecuteObjectPipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
		async Task<T?> SelectObjectStoredProcedureTermination<TDatabase, TEntity, T>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecuteObjectPipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        protected virtual T? ExecuteObjectPipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => ExecutionPipelineFactory.CreateStoredProcedureExecutionPipeline().ExecuteSelectObject(StoredProcedureQueryExpression, map, connection, configureCommand);

        protected virtual async Task<T?> ExecuteObjectPipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => await ExecutionPipelineFactory.CreateStoredProcedureExecutionPipeline().ExecuteSelectObjectAsync(StoredProcedureQueryExpression, map, connection, configureCommand, ct).ConfigureAwait(false);
        #endregion
        #endregion
    }
}
