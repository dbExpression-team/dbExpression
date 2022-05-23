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
    public class SelectObjectsSelectSetQueryExpressionBuilder<TDatabase, TObject> : SelectSetQueryExpressionBuilder<TDatabase>,
        SelectObjectsTermination<TDatabase, TObject>
        where TDatabase : class, ISqlDatabaseRuntime
        where TObject : class?
    {
        #region constructors
        public SelectObjectsSelectSetQueryExpressionBuilder(
            SelectSetQueryExpression expression,
            SqlDatabaseRuntimeConfiguration config
        ) : base(expression, config)
        {

        }
        #endregion

        #region methods
        #region SelectObjectsTermination<TDatabase, TObject>
        /// <inheritdoc />
        IList<TObject> SelectObjectsTermination<TDatabase, TObject>.Execute()
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecutePipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
        IList<TObject> SelectObjectsTermination<TDatabase, TObject>.Execute(int commandTimeout)
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
        IList<TObject> SelectObjectsTermination<TDatabase, TObject>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        IList<TObject> SelectObjectsTermination<TDatabase, TObject>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        void SelectObjectsTermination<TDatabase, TObject>.Execute(Action<TObject?> read)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            ExecutePipeline(
                connection,
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectObjectsTermination<TDatabase, TObject>.Execute(int commandTimeout, Action<TObject?> read)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectObjectsTermination<TDatabase, TObject>.Execute(ISqlConnection connection, Action<TObject?> read)
        {
            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectObjectsTermination<TDatabase, TObject>.Execute(ISqlConnection connection, int commandTimeout, Action<TObject?> read)
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
        async Task<IList<TObject>> SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TObject>> SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        async Task<IList<TObject>> SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TObject>> SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
        async Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(Action<TObject?> read, CancellationToken cancellationToken)
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
        async Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(int commandTimeout, Action<TObject?> read, CancellationToken cancellationToken)
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
        async Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, Action<TObject?> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<TObject?> read, CancellationToken cancellationToken)
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
        async Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(Func<TObject?, Task> read, CancellationToken cancellationToken)
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
        async Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(int commandTimeout, Func<TObject?, Task> read, CancellationToken cancellationToken)
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
        async Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, Func<TObject?, Task> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectObjectsTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<TObject?, Task> read, CancellationToken cancellationToken)
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

        protected virtual IList<TObject> ExecutePipeline(ISqlConnection connection, Action<IDbCommand>? ConfigurationureCommand)
        {
            if (SelectSetQueryExpression.Expressions.Count > 1)
                return CreateExecuteSetPipeline().ExecuteSelectValueList<TObject>(SelectSetQueryExpression, connection, ConfigurationureCommand);
            return CreateExecuteSinglePipeline().ExecuteSelectValueList<TObject>(SelectSetQueryExpression.Expressions.Single().SelectQueryExpression, connection, ConfigurationureCommand);
        }

        protected virtual async Task<IList<TObject>> ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? ConfigurationureCommand, CancellationToken cancellationToken)
        {
            if (SelectSetQueryExpression.Expressions.Count > 1)
                return await CreateExecuteSetPipeline().ExecuteSelectValueListAsync<TObject>(SelectSetQueryExpression, connection, ConfigurationureCommand, cancellationToken).ConfigureAwait(false);
            return await CreateExecuteSinglePipeline().ExecuteSelectValueListAsync<TObject>(SelectSetQueryExpression.Expressions.Single().SelectQueryExpression, connection, ConfigurationureCommand, cancellationToken).ConfigureAwait(false);
        }

        protected virtual void ExecutePipeline(ISqlConnection connection, Action<IDbCommand>? ConfigurationureCommand, Action<TObject?> read)
        {
            if (SelectSetQueryExpression.Expressions.Count > 1)
                CreateExecuteSetPipeline().ExecuteSelectValueList<TObject>(SelectSetQueryExpression, connection, ConfigurationureCommand, read);
            CreateExecuteSinglePipeline().ExecuteSelectValueList<TObject>(SelectSetQueryExpression.Expressions.Single().SelectQueryExpression, connection, ConfigurationureCommand, read);
        }

        protected virtual async Task ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? ConfigurationureCommand, Action<TObject?> read, CancellationToken cancellationToken)
            => await CreateExecuteSetPipeline().ExecuteSelectValueListAsync(SelectSetQueryExpression, connection, ConfigurationureCommand, read, cancellationToken);

        protected virtual async Task ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? ConfigurationureCommand, Func<TObject?, Task> read, CancellationToken cancellationToken)
        {
            if (SelectSetQueryExpression.Expressions.Count > 1)
                await CreateExecuteSetPipeline().ExecuteSelectValueListAsync<TObject>(SelectSetQueryExpression, connection, ConfigurationureCommand, read, cancellationToken).ConfigureAwait(false);
            await CreateExecuteSinglePipeline().ExecuteSelectValueListAsync<TObject>(SelectSetQueryExpression.Expressions.Single().SelectQueryExpression, connection, ConfigurationureCommand, read, cancellationToken).ConfigureAwait(false);
        }
        #endregion
    }
}
