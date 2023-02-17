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
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectValueStoredProcedureQueryExpressionBuilder<TDatabase, TEntity, TValue> : StoredProcedureQueryExpressionBuilder<TDatabase, TEntity>,
        StoredProcedureContinuation<TDatabase, TEntity>,
        SelectValueStoredProcedureContinuation<TDatabase, TEntity, TValue>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, StoredProcedure
    {
        #region constructors
        public SelectValueStoredProcedureQueryExpressionBuilder(
            IQueryExpressionExecutionPipelineFactory executionPipelineFactory,
            StoredProcedureQueryExpression expression
        ) : base(executionPipelineFactory, expression)
        {

        }
        #endregion

        #region methods
        #region SelectValueStoredProcedureTermination
        /// <inheritdoc />
        TValue? SelectValueStoredProcedureTermination<TDatabase, TEntity, TValue>.Execute()
        {
            return ExecuteValuePipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
		TValue? SelectValueStoredProcedureTermination<TDatabase, TEntity, TValue>.Execute(ISqlConnection connection)
        {
            return ExecuteValuePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
		TValue? SelectValueStoredProcedureTermination<TDatabase, TEntity, TValue>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteValuePipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
		TValue? SelectValueStoredProcedureTermination<TDatabase, TEntity, TValue>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteValuePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
		async Task<TValue?> SelectValueStoredProcedureTermination<TDatabase, TEntity, TValue>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return await ExecuteValuePipelineAsync(
                null,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
		async Task<TValue?> SelectValueStoredProcedureTermination<TDatabase, TEntity, TValue>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecuteValuePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
		async Task<TValue?> SelectValueStoredProcedureTermination<TDatabase, TEntity, TValue>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecuteValuePipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
		async Task<TValue?> SelectValueStoredProcedureTermination<TDatabase, TEntity, TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecuteValuePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        protected virtual TValue? ExecuteValuePipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => ExecutionPipelineFactory.CreateStoredProcedureExecutionPipeline().ExecuteSelectValue<TValue>(StoredProcedureQueryExpression, connection, configureCommand);

        protected virtual async Task<TValue?> ExecuteValuePipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => await ExecutionPipelineFactory.CreateStoredProcedureExecutionPipeline().ExecuteSelectValueAsync<TValue>(StoredProcedureQueryExpression, connection, configureCommand, ct).ConfigureAwait(false);

        #endregion
        #endregion
    }
}
