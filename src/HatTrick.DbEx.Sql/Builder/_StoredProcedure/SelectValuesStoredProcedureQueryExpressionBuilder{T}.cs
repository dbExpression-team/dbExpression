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
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectValuesStoredProcedureQueryExpressionBuilder<TValue> : StoredProcedureQueryExpressionBuilder,
        StoredProcedureContinuation,
        SelectValuesStoredProcedureContinuation<TValue>
    {
        #region constructors
        public SelectValuesStoredProcedureQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, StoredProcedureQueryExpression expression)
            : base(config, expression, expression.BaseEntity!)
        {

        }
        #endregion

        #region methods
        #region SelectValuesStoredProcedureTermination
        /// <inheritdoc />
        IList<TValue> SelectValuesStoredProcedureTermination<TValue>.Execute()
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecuteValueListPipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
		IList<TValue> SelectValuesStoredProcedureTermination<TValue>.Execute(ISqlConnection connection)
        {
            return ExecuteValueListPipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
		IList<TValue> SelectValuesStoredProcedureTermination<TValue>.Execute(int commandTimeout)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecuteValueListPipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
		IList<TValue> SelectValuesStoredProcedureTermination<TValue>.Execute(ISqlConnection connection, int commandTimeout)
        {
            return ExecuteValueListPipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
		async Task<IList<TValue>> SelectValuesStoredProcedureTermination<TValue>.ExecuteAsync(CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecuteValueListPipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
		async Task<IList<TValue>> SelectValuesStoredProcedureTermination<TValue>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecuteValueListPipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
		async Task<IList<TValue>> SelectValuesStoredProcedureTermination<TValue>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecuteValueListPipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
		async Task<IList<TValue>> SelectValuesStoredProcedureTermination<TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            return await ExecuteValueListPipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        protected virtual IList<TValue> ExecuteValueListPipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand)
            => CreateStoredProcedureExecutionPipeline().ExecuteSelectValueList<TValue>(Expression, connection, configureCommand);

        protected virtual async Task<IList<TValue>> ExecuteValueListPipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => await CreateStoredProcedureExecutionPipeline().ExecuteSelectValueListAsync<TValue>(Expression, connection, configureCommand, ct).ConfigureAwait(false);

        #endregion
        #endregion
    }
}
