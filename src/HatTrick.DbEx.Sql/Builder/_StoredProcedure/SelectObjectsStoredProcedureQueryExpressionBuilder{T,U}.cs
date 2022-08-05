﻿#region license
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
    public class SelectObjectsStoredProcedureQueryExpressionBuilder<TDatabase, T> : StoredProcedureQueryExpressionBuilder<TDatabase>,
        StoredProcedureContinuation<TDatabase>,
        SelectObjectsStoredProcedureContinuation<TDatabase, T>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly Func<ISqlFieldReader, T> map;
        #endregion

        #region interface
        Func<ISqlFieldReader, T> SelectObjectsStoredProcedureTermination<TDatabase, T>.Map => map;
        #endregion

        #region constructors
        public SelectObjectsStoredProcedureQueryExpressionBuilder(
            ISqlDatabaseRuntime database,
            StoredProcedureQueryExpression expression,
            Func<IStoredProcedureExecutionPipeline<TDatabase>> executionPipelineFactory,
            Func<ISqlFieldReader, T> map
        ) : base(database, expression, executionPipelineFactory)
        {
            this.map = map ?? throw new ArgumentNullException(nameof(map));
        }
        #endregion

        #region methods
        #region SelectObjectsStoredProcedureTermination
        /// <inheritdoc/ >
        IList<T> SelectObjectsStoredProcedureTermination<TDatabase, T>.Execute()
        {
            using var connection = Database.GetConnection();
            return ExecuteObjectsPipeline(
                connection,
                null
            );
        }

        /// <inheritdoc/ >
		IList<T> SelectObjectsStoredProcedureTermination<TDatabase, T>.Execute(ISqlConnection connection)
        {
            return ExecuteObjectsPipeline(
                connection,
                null
            );
        }

        /// <inheritdoc/ >
		IList<T> SelectObjectsStoredProcedureTermination<TDatabase, T>.Execute(int commandTimeout)
        {
            using var connection = Database.GetConnection();
            return ExecuteObjectsPipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc/ >
		IList<T> SelectObjectsStoredProcedureTermination<TDatabase, T>.Execute(ISqlConnection connection, int commandTimeout)
        {
            return ExecuteObjectsPipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc/ >
		async Task<IList<T>> SelectObjectsStoredProcedureTermination<TDatabase, T>.ExecuteAsync(CancellationToken cancellationToken)
        {
            using var connection = Database.GetConnection();
            return await ExecuteObjectsPipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc/ >
		async Task<IList<T>> SelectObjectsStoredProcedureTermination<TDatabase, T>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecuteObjectsPipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc/ >
		async Task<IList<T>> SelectObjectsStoredProcedureTermination<TDatabase, T>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            using var connection = Database.GetConnection();
            return await ExecuteObjectsPipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc/ >
		async Task<IList<T>> SelectObjectsStoredProcedureTermination<TDatabase, T>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            return await ExecuteObjectsPipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        protected virtual IList<T> ExecuteObjectsPipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand)
            => ExecutionPipelineFactory().ExecuteSelectObjectList(StoredProcedureQueryExpression, map, connection, configureCommand);

        protected virtual async Task<IList<T>> ExecuteObjectsPipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => await ExecutionPipelineFactory().ExecuteSelectObjectListAsync(StoredProcedureQueryExpression, map, connection, configureCommand, ct).ConfigureAwait(false);

        #endregion
        #endregion
    }
}
