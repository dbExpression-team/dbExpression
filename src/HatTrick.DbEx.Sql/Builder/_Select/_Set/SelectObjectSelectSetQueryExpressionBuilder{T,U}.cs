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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectObjectSelectSetQueryExpressionBuilder<TDatabase, TObject> : SelectSetQueryExpressionBuilder<TDatabase>,
        SelectObjectTermination<TDatabase, TObject>
        where TDatabase : class, ISqlDatabaseRuntime
        where TObject : class?
    {
        #region constructors
        public SelectObjectSelectSetQueryExpressionBuilder(
            SelectSetQueryExpression expression,
            SqlDatabaseRuntimeConfiguration config
        ) : base(expression, config)
        {

        }
        #endregion

        #region methods
        #region SelectObjectTermination<TDatabase, TObject>
        /// <inheritdoc />
        TObject? SelectObjectTermination<TDatabase, TObject>.Execute()
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecutePipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
        TObject? SelectObjectTermination<TDatabase, TObject>.Execute(int commandTimeout)
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
        TObject? SelectObjectTermination<TDatabase, TObject>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        TObject? SelectObjectTermination<TDatabase, TObject>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        async Task<TObject?> SelectObjectTermination<TDatabase, TObject>.ExecuteAsync(CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TObject?> SelectObjectTermination<TDatabase, TObject>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        async Task<TObject?> SelectObjectTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<TObject?> SelectObjectTermination<TDatabase, TObject>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }
        #endregion

        protected virtual TObject? ExecutePipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand)
            => CreateExecuteSinglePipeline().ExecuteSelectValue<TObject>(SelectSetQueryExpression.Expressions.Single().SelectQueryExpression, connection, configureCommand);

        protected virtual async Task<TObject?> ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
            => await CreateExecuteSinglePipeline().ExecuteSelectValueAsync<TObject>(SelectSetQueryExpression.Expressions.Single().SelectQueryExpression, connection, configureCommand, cancellationToken).ConfigureAwait(false);

        protected virtual void ExecutePipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand, Action<TObject?> read)
        {
            if (SelectSetQueryExpression.Expressions.Count > 1)
                CreateExecuteSetPipeline().ExecuteSelectValueList(SelectSetQueryExpression, connection, configureCommand, read);
            CreateExecuteSinglePipeline().ExecuteSelectValueList(SelectSetQueryExpression.Expressions.Single().SelectQueryExpression, connection, configureCommand, read);
        }
        #endregion
    }
}
