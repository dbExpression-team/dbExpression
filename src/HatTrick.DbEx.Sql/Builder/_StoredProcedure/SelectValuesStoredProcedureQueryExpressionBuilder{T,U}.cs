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
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectValuesStoredProcedureQueryExpressionBuilder<TDatabase, TValue> : StoredProcedureQueryExpressionBuilder<TDatabase>,
        StoredProcedureContinuation<TDatabase>,
        SelectValuesStoredProcedureContinuation<TDatabase, TValue>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region constructors
        public SelectValuesStoredProcedureQueryExpressionBuilder(
            StoredProcedureQueryExpression expression,
            Func<IStoredProcedureQueryExpressionExecutionPipeline> executionPipelineFactory
        ) : base(expression, executionPipelineFactory)
        {

        }
        #endregion

        #region methods
        #region SelectValuesStoredProcedureTermination
        /// <inheritdoc />
        IList<TValue> SelectValuesStoredProcedureTermination<TDatabase, TValue>.Execute()
        {
            return ExecuteValueListPipeline(
                null,
                null
            );
        }

        /// <inheritdoc />
		IList<TValue> SelectValuesStoredProcedureTermination<TDatabase, TValue>.Execute(ISqlConnection connection)
        {
            return ExecuteValueListPipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
		IList<TValue> SelectValuesStoredProcedureTermination<TDatabase, TValue>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteValueListPipeline(
                null,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
		IList<TValue> SelectValuesStoredProcedureTermination<TDatabase, TValue>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteValueListPipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
		Task<IList<TValue>> SelectValuesStoredProcedureTermination<TDatabase, TValue>.ExecuteAsync(CancellationToken cancellationToken)
        {
            return ExecuteValueListPipelineAsync(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
		IAsyncEnumerable<TValue> SelectValuesStoredProcedureTermination<TDatabase, TValue>.ExecuteAsyncEnumerable(CancellationToken cancellationToken)
        {
            return ExecuteValueListPipelineAsyncEnumerable(
                null,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
		Task<IList<TValue>> SelectValuesStoredProcedureTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecuteValueListPipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
		IAsyncEnumerable<TValue> SelectValuesStoredProcedureTermination<TDatabase, TValue>.ExecuteAsyncEnumerable(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return ExecuteValueListPipelineAsyncEnumerable(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            );
        }

        /// <inheritdoc />
		Task<IList<TValue>> SelectValuesStoredProcedureTermination<TDatabase, TValue>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteValueListPipelineAsync(
                null,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        /// <inheritdoc />
		IAsyncEnumerable<TValue> SelectValuesStoredProcedureTermination<TDatabase, TValue>.ExecuteAsyncEnumerable(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteValueListPipelineAsyncEnumerable(
                null,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        /// <inheritdoc />
		Task<IList<TValue>> SelectValuesStoredProcedureTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteValueListPipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        /// <inheritdoc />
		IAsyncEnumerable<TValue> SelectValuesStoredProcedureTermination<TDatabase, TValue>.ExecuteAsyncEnumerable(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecuteValueListPipelineAsyncEnumerable(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            );
        }

        protected virtual IList<TValue> ExecuteValueListPipeline(ISqlConnection? connection, Action<IDbCommand>? configureCommand)
            => CreateExecutionPipeline().ExecuteSelectValueList<TValue>(StoredProcedureQueryExpression, connection, configureCommand);

        protected virtual Task<IList<TValue>> ExecuteValueListPipelineAsync(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => CreateExecutionPipeline().ExecuteSelectValueListAsync<TValue>(StoredProcedureQueryExpression, connection, configureCommand, ct);

        protected virtual IAsyncEnumerable<TValue> ExecuteValueListPipelineAsyncEnumerable(ISqlConnection? connection, Action<IDbCommand>? configureCommand, CancellationToken ct)
            => CreateExecutionPipeline().ExecuteSelectValueListAsyncEnumerable<TValue>(StoredProcedureQueryExpression, connection, configureCommand, ct);

        private IStoredProcedureQueryExpressionExecutionPipeline CreateExecutionPipeline()
            => ExecutionPipelineFactory()
                    ?? throw new DbExpressionConfigurationException(ExceptionMessages.ServiceResolution(StoredProcedureQueryExpression.GetType()));

        #endregion
        #endregion
    }
}
