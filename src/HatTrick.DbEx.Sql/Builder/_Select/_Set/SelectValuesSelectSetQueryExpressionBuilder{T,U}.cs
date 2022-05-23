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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectValuesSelectSetQueryExpressionBuilder<TDatabase, TValue> : SelectSetQueryExpressionBuilder<TDatabase>,
        SelectValuesTermination<TDatabase, TValue>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region constructors
        public SelectValuesSelectSetQueryExpressionBuilder(
            SelectSetQueryExpression expression,
            SqlDatabaseRuntimeConfiguration config
        ) : base(expression, config)
        {

        }
        #endregion

        #region methods
        #region SelectValuesTermination<TDatabase, TValue>
        /// <inheritdoc />
        IList<TValue> SelectValuesTermination<TDatabase, TValue>.Execute()
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecutePipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
        IList<TValue> SelectValuesTermination<TDatabase, TValue>.Execute(int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        IList<TValue> SelectValuesTermination<TDatabase, TValue>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        IList<TValue> SelectValuesTermination<TDatabase, TValue>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        void SelectValuesTermination<TDatabase, TValue>.Execute(Action<TValue?> handleValue)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            ExecutePipeline(
                connection,
                null,
                handleValue ?? throw new ArgumentNullException(nameof(handleValue))
            );
        }

        /// <inheritdoc />
        void SelectValuesTermination<TDatabase, TValue>.Execute(int commandTimeout, Action<TValue?> handleValue)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout,
                handleValue ?? throw new ArgumentNullException(nameof(handleValue))
            );
        }

        /// <inheritdoc />
        void SelectValuesTermination<TDatabase, TValue>.Execute(ISqlConnection connection, Action<TValue?> handleValue)
        {
            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                handleValue ?? throw new ArgumentNullException(nameof(handleValue))
            );
        }

        /// <inheritdoc />
        void SelectValuesTermination<TDatabase, TValue>.Execute(ISqlConnection connection, int commandTimeout, Action<TValue?> handleValue)
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
        async Task<IList<TValue>> SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TValue>> SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TValue>> SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TValue>> SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(Action<TValue?> read, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            await ExecutePipelineAsync(
                connection,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(int commandTimeout, Action<TValue?> read, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, Action<TValue?> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<TValue?> read, CancellationToken cancellationToken)
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
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(Func<TValue?, Task> read, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            await ExecutePipelineAsync(
                connection,
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(int commandTimeout, Func<TValue?, Task> read, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, Func<TValue?, Task> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectValuesTermination<TDatabase, TValue>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<TValue?, Task> read, CancellationToken cancellationToken)
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

        protected virtual IList<TValue> ExecutePipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand)
        {
            if (SelectSetQueryExpression.Expressions.Count > 1)
                return CreateExecuteSetPipeline().ExecuteSelectValueList<TValue>(SelectSetQueryExpression, connection, configureCommand);
            return CreateExecuteSinglePipeline().ExecuteSelectValueList<TValue>(SelectSetQueryExpression.Expressions.Single().SelectQueryExpression, connection, configureCommand);
        }

        protected virtual async Task<IList<TValue>> ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
        {
            if (SelectSetQueryExpression.Expressions.Count > 1)
                return await CreateExecuteSetPipeline().ExecuteSelectValueListAsync<TValue>(SelectSetQueryExpression, connection, configureCommand, cancellationToken).ConfigureAwait(false);
            return await CreateExecuteSinglePipeline().ExecuteSelectValueListAsync<TValue>(SelectSetQueryExpression.Expressions.Single().SelectQueryExpression, connection, configureCommand, cancellationToken).ConfigureAwait(false);
        }

        protected virtual void ExecutePipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand, Action<TValue?> read)
        {
            if (SelectSetQueryExpression.Expressions.Count > 1)
                CreateExecuteSetPipeline().ExecuteSelectValueList<TValue>(SelectSetQueryExpression, connection, configureCommand, read);
            CreateExecuteSinglePipeline().ExecuteSelectValueList<TValue>(SelectSetQueryExpression.Expressions.Single().SelectQueryExpression, connection, configureCommand, read);
        }

        protected virtual async Task ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, Action<TValue?> read, CancellationToken cancellationToken)
            => await CreateExecuteSetPipeline().ExecuteSelectValueListAsync(SelectSetQueryExpression, connection, configureCommand, read, cancellationToken);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, Func<TValue?, Task> read, CancellationToken cancellationToken)
        {
            if (SelectSetQueryExpression.Expressions.Count > 1)
                await CreateExecuteSetPipeline().ExecuteSelectValueListAsync<TValue>(SelectSetQueryExpression, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);
            await CreateExecuteSinglePipeline().ExecuteSelectValueListAsync<TValue>(SelectSetQueryExpression.Expressions.Single().SelectQueryExpression, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);
        }
        #endregion
    }
}
