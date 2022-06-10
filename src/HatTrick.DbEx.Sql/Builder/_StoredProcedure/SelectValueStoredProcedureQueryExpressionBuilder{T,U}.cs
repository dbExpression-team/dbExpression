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
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectValueStoredProcedureQueryExpressionBuilder<TDatabase, TValue> : StoredProcedureQueryExpressionBuilder<TDatabase>,
        StoredProcedureContinuation<TDatabase>,
        SelectValueStoredProcedureContinuation<TDatabase, TValue>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region constructors
        public SelectValueStoredProcedureQueryExpressionBuilder(StoredProcedureQueryExpression expression, SqlDatabaseRuntimeConfiguration config)
            : base(expression, config)
        {

        }
        #endregion

        #region methods
        #region SelectValueStoredProcedureTermination
        /// <inheritdoc />
        TValue? SelectValueStoredProcedureTermination<TDatabase, TValue>.Execute()
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecuteValuePipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
		TValue? SelectValueStoredProcedureTermination<TDatabase, TValue>.Execute(ISqlConnection connection)
        {
            return ExecuteValuePipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
		TValue? SelectValueStoredProcedureTermination<TDatabase, TValue>.Execute(int commandTimeout)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecuteValuePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
		TValue? SelectValueStoredProcedureTermination<TDatabase, TValue>.Execute(ISqlConnection connection, int commandTimeout)
        {
            return ExecuteValuePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
		async Task<TValue?> SelectValueStoredProcedureTermination<TDatabase, TValue>.ExecuteAsync(CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecuteValuePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
		async Task<TValue?> SelectValueStoredProcedureTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecuteValuePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
		async Task<TValue?> SelectValueStoredProcedureTermination<TDatabase, TValue>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecuteValuePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
		async Task<TValue?> SelectValueStoredProcedureTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            return await ExecuteValuePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        protected virtual TValue? ExecuteValuePipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand)
            => CreateStoredProcedureExecutionPipeline().ExecuteSelectValue<TValue>(StoredProcedureQueryExpression, connection, configureCommand);

        protected virtual async Task<TValue?> ExecuteValuePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => await CreateStoredProcedureExecutionPipeline().ExecuteSelectValueAsync<TValue>(StoredProcedureQueryExpression, connection, configureCommand, ct).ConfigureAwait(false);

        #endregion
        #endregion
    }
}
