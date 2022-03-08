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
    public class SelectObjectStoredProcedureQueryExpressionBuilder<T> : StoredProcedureQueryExpressionBuilder,
        StoredProcedureContinuation,
        SelectObjectStoredProcedureContinuation<T>
    {
        private readonly Func<ISqlFieldReader, T> map;
        Func<ISqlFieldReader, T> SelectObjectStoredProcedureTermination<T>.Map => map;

        public SelectObjectStoredProcedureQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, StoredProcedureQueryExpression expression, Func<ISqlFieldReader, T> map)
#pragma warning disable CS8604 // Possible null reference argument.
            : base(config, expression, expression.BaseEntity as StoredProcedureExpression) //TODO: interface
#pragma warning restore CS8604 // Possible null reference argument.
        {
            this.map = map ?? throw new ArgumentNullException(nameof(map));
        }

        #region methods
        #region SelectObjectStoredProcedureTermination
        /// <inheritdoc />
        IList<T> SelectObjectStoredProcedureTermination<T>.Execute()
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecuteObjectPipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
		IList<T> SelectObjectStoredProcedureTermination<T>.Execute(ISqlConnection connection)
        {
            return ExecuteObjectPipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
		IList<T> SelectObjectStoredProcedureTermination<T>.Execute(int commandTimeout)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecuteObjectPipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
		IList<T> SelectObjectStoredProcedureTermination<T>.Execute(ISqlConnection connection, int commandTimeout)
        {
            return ExecuteObjectPipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        async Task<IList<T>> SelectObjectStoredProcedureTermination<T>.ExecuteAsync(CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecuteObjectPipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
		async Task<IList<T>> SelectObjectStoredProcedureTermination<T>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecuteObjectPipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
		async Task<IList<T>> SelectObjectStoredProcedureTermination<T>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecuteObjectPipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
		async Task<IList<T>> SelectObjectStoredProcedureTermination<T>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            return await ExecuteObjectPipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        protected virtual IList<T> ExecuteObjectPipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand)
            => CreateStoredProcedureExecutionPipeline().ExecuteSelectObjectList(Expression, map, connection, configureCommand);

        protected virtual async Task<IList<T>> ExecuteObjectPipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => await CreateStoredProcedureExecutionPipeline().ExecuteSelectObjectListAsync(Expression, map, connection, configureCommand, ct).ConfigureAwait(false);
        #endregion
        #endregion
    }
}
