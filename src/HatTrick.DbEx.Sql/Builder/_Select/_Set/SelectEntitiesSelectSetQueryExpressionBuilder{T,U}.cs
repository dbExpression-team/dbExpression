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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SelectEntitiesSelectSetQueryExpressionBuilder<TDatabase, TEntity> : SelectSetQueryExpressionBuilder<TDatabase>,
        SelectEntitiesTermination<TDatabase, TEntity>
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, IDbEntity, new()
    {
        #region constructors
        public SelectEntitiesSelectSetQueryExpressionBuilder(
            SelectSetQueryExpression expression,
            SqlDatabaseRuntimeConfiguration config
        ) : base(expression, config)
        {

        }
        #endregion

        #region methods
        #region SelectEntitiesTermination
        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute()
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecutePipeline(
                connection,
                null
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(int commandTimeout)
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
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(Func<ISqlFieldReader, TEntity> map)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecutePipeline(
                connection,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(int commandTimeout, Func<ISqlFieldReader, TEntity> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        void SelectEntitiesTermination<TDatabase, TEntity>.Execute(Action<ISqlFieldReader> map)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            ExecutePipeline(
                connection,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        void SelectEntitiesTermination<TDatabase, TEntity>.Execute(int commandTimeout, Action<ISqlFieldReader> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        void SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, Action<ISqlFieldReader> read)
        {
            ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <inheritdoc />
        void SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read)
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
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(Action<ISqlFieldReader, TEntity> map)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecutePipeline(
                connection,
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(int commandTimeout, Action<ISqlFieldReader, TEntity> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map)
        {
            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        IList<TEntity> SelectEntitiesTermination<TDatabase, TEntity>.Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, CancellationToken cancellationToken)
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
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken)
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
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(Action<ISqlFieldReader> read, CancellationToken cancellationToken)
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
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
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
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
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
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecutePipelineAsync(
                connection,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecutePipelineAsync(
                connection,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
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
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
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
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
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
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecutePipelineAsync(
                connection,
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            using var connection = new SqlConnector(Configuration.ConnectionStringFactory, Configuration.ConnectionFactory);
            return await ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <inheritdoc />
        async Task<IList<TEntity>> SelectEntitiesTermination<TDatabase, TEntity>.ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }
        #endregion

        protected virtual IList<TEntity> ExecutePipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand)
        {
            if (SelectSetQueryExpression.Expressions.Count > 1)
                return CreateExecuteSetPipeline().ExecuteSelectEntityList<TEntity>(SelectSetQueryExpression, connection, configureCommand);
            return CreateExecuteSinglePipeline().ExecuteSelectEntityList<TEntity>(SelectSetQueryExpression.Expressions.Single().SelectQueryExpression, connection, configureCommand);
        }

        protected virtual IList<TEntity> ExecutePipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity> map)
        {
            if (SelectSetQueryExpression.Expressions.Count > 1)
                return CreateExecuteSetPipeline().ExecuteSelectEntityList<TEntity>(SelectSetQueryExpression, connection, configureCommand, map);
            return CreateExecuteSinglePipeline().ExecuteSelectEntityList<TEntity>(SelectSetQueryExpression.Expressions.Single().SelectQueryExpression, connection, configureCommand, map);
        }

        protected virtual void ExecutePipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read)
        {
            if (SelectSetQueryExpression.Expressions.Count > 1)
                CreateExecuteSetPipeline().ExecuteSelectEntityList<TEntity>(SelectSetQueryExpression, connection, configureCommand, read);
            CreateExecuteSinglePipeline().ExecuteSelectEntityList<TEntity>(SelectSetQueryExpression.Expressions.Single().SelectQueryExpression, connection, configureCommand, read);
        }

        protected virtual IList<TEntity> ExecutePipeline(ISqlConnection connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map)
        {
            if (SelectSetQueryExpression.Expressions.Count > 1)
                return CreateExecuteSetPipeline().ExecuteSelectEntityList<TEntity>(SelectSetQueryExpression, connection, configureCommand, map);
            return CreateExecuteSinglePipeline().ExecuteSelectEntityList<TEntity>(SelectSetQueryExpression.Expressions.Single().SelectQueryExpression, connection, configureCommand, map);
        }

        protected virtual async Task<IList<TEntity>> ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, CancellationToken cancellationToken)
        {
            if (SelectSetQueryExpression.Expressions.Count > 1)
                return await CreateExecuteSetPipeline().ExecuteSelectEntityListAsync<TEntity>(SelectSetQueryExpression, connection, configureCommand, cancellationToken).ConfigureAwait(false);
            return await CreateExecuteSinglePipeline().ExecuteSelectEntityListAsync<TEntity>(SelectSetQueryExpression.Expressions.Single().SelectQueryExpression, connection, configureCommand, cancellationToken).ConfigureAwait(false);
        }

        protected virtual async Task ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
        {
            if (SelectSetQueryExpression.Expressions.Count > 1)
                await CreateExecuteSetPipeline().ExecuteSelectEntityListAsync<TEntity>(SelectSetQueryExpression, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);
            await CreateExecuteSinglePipeline().ExecuteSelectEntityListAsync<TEntity>(SelectSetQueryExpression.Expressions.Single().SelectQueryExpression, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);
        }

        protected virtual async Task<IList<TEntity>> ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            if (SelectSetQueryExpression.Expressions.Count > 1)
                return await CreateExecuteSetPipeline().ExecuteSelectEntityListAsync<TEntity>(SelectSetQueryExpression, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);
            return await CreateExecuteSinglePipeline().ExecuteSelectEntityListAsync<TEntity>(SelectSetQueryExpression.Expressions.Single().SelectQueryExpression, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);
        }

        protected virtual async Task<IList<TEntity>> ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken)
        {
            if (SelectSetQueryExpression.Expressions.Count > 1)
                return await CreateExecuteSetPipeline().ExecuteSelectEntityListAsync<TEntity>(SelectSetQueryExpression, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);
            return await CreateExecuteSinglePipeline().ExecuteSelectEntityListAsync<TEntity>(SelectSetQueryExpression.Expressions.Single().SelectQueryExpression, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);
        }

        protected virtual async Task ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
        {
            if (SelectSetQueryExpression.Expressions.Count > 1)
                await CreateExecuteSetPipeline().ExecuteSelectEntityListAsync<TEntity>(SelectSetQueryExpression, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);
            await CreateExecuteSinglePipeline().ExecuteSelectEntityListAsync<TEntity>(SelectSetQueryExpression.Expressions.Single().SelectQueryExpression, connection, configureCommand, read, cancellationToken).ConfigureAwait(false);
        }

        protected virtual async Task<IList<TEntity>> ExecutePipelineAsync(ISqlConnection connection, Action<IDbCommand>? configureCommand, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken)
        {
            if (SelectSetQueryExpression.Expressions.Count > 1)
                return await CreateExecuteSetPipeline().ExecuteSelectEntityListAsync<TEntity>(SelectSetQueryExpression, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);
            return await CreateExecuteSinglePipeline().ExecuteSelectEntityListAsync<TEntity>(SelectSetQueryExpression.Expressions.Single().SelectQueryExpression, connection, configureCommand, map, cancellationToken).ConfigureAwait(false);
        }
        #endregion
    }
}
