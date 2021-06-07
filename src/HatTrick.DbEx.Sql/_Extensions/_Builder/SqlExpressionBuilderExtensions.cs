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

﻿using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql
{
    public static class SqlExpressionBuilderExtensions
    {
        #region builder termination
        #region InsertTerminationExpressionBuilder
        /// <summary>
        /// Assemble and execute a INSERT query to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        public static void Execute<TEntity>(this IInsertTerminationExpressionBuilder<TEntity> builder)
            where TEntity : class, IDbEntity
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                builder.ExecutePipeline(
                    connection, 
                    null
                );
        }

        /// <summary>
        /// Assemble and execute a INSERT query to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql INSERT statement and generating an error.</param>
        public static void Execute<TEntity>(this IInsertTerminationExpressionBuilder<TEntity> builder, int commandTimeout)
            where TEntity : class, IDbEntity
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                builder.ExecutePipeline(
                    connection, 
                    command => command.CommandTimeout = commandTimeout
                );
        }

        /// <summary>
        /// Assemble and execute a INSERT query to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql INSERT statement.</param>
        public static void Execute<TEntity>(this IInsertTerminationExpressionBuilder<TEntity> builder, ISqlConnection connection)
            where TEntity : class, IDbEntity
        {
            builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null
            );
        }

        /// <summary>
        /// Assemble and execute a INSERT query to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql INSERT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql INSERT statement and generating an error.</param>
        public static void Execute<TEntity>(this IInsertTerminationExpressionBuilder<TEntity> builder, ISqlConnection connection, int commandTimeout)
            where TEntity : class, IDbEntity
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a INSERT query to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the INSERT statement should be cancelled.</param>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        public static async Task ExecuteAsync<TEntity>(this IInsertTerminationExpressionBuilder<TEntity> builder, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection, 
                    null, 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a INSERT query to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql INSERT statement.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the INSERT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this IInsertTerminationExpressionBuilder<TEntity> builder, ISqlConnection connection, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity
        {
            await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a INSERT query to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql INSERT statement and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the INSERT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this IInsertTerminationExpressionBuilder<TEntity> builder, int commandTimeout, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a INSERT query to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql INSERT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql INSERT statement and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the INSERT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this IInsertTerminationExpressionBuilder<TEntity> builder, ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default)
           where TEntity : class, IDbEntity
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                cancellationToken
            ).ConfigureAwait(false);
        }
        #endregion

        #region UpdateEntitiesTermination
        /// <summary>
        /// Assemble and execute a UPDATE query to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <returns>The number of records affected in the database.</returns>
        public static int Execute<TEntity>(this UpdateEntitiesTermination<TEntity> builder)
            where TEntity : class, IDbEntity
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection, 
                    null
                );
        }

        /// <summary>
        /// Assemble and execute a UPDATE query to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql UPDATE statement and generating an error.</param>
        /// <returns>The number of records affected in the database.</returns>
        public static int Execute<TEntity>(this UpdateEntitiesTermination<TEntity> builder, int commandTimeout)
            where TEntity : class, IDbEntity
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection, 
                    command => command.CommandTimeout = commandTimeout
                );
        }

        /// <summary>
        /// Assemble and execute a UPDATE query to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql UPDATE statement.</param>
        /// <returns>The number of records affected in the database.</returns>
        public static int Execute<TEntity>(this UpdateEntitiesTermination<TEntity> builder, ISqlConnection connection)
            where TEntity : class, IDbEntity
        {
            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null
            );
        }

        /// <summary>
        /// Assemble and execute a UPDATE query to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql UPDATE statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql UPDATE statement and generating an error.</param>
        /// <returns>The number of records affected in the database.</returns>
        public static int Execute<TEntity>(this UpdateEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout)
            where TEntity : class, IDbEntity
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a UPDATE query to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the UPDATE statement should be cancelled.</param>
        /// <returns>The number of records affected in the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this UpdateEntitiesTermination<TEntity> builder, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    null, 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a UPDATE query to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql UPDATE statement.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the UPDATE statement should be cancelled.</param>
        /// <returns>The number of records affected in the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this UpdateEntitiesTermination<TEntity> builder, ISqlConnection connection, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity
        {
            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a UPDATE query to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql UPDATE statement and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the UPDATE statement should be cancelled.</param>
        /// <returns>The number of records affected in the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this UpdateEntitiesTermination<TEntity> builder, int commandTimeout, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a UPDATE query to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql UPDATE statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql UPDATE statement and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the UPDATE statement should be cancelled.</param>
        /// <returns>The number of records affected in the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this UpdateEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                cancellationToken
            ).ConfigureAwait(false);
        }
        #endregion

        #region DeleteEntitiesTermination
        /// <summary>
        /// Assemble and execute a DELETE query to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <returns>The number of records removed from the database.</returns>
        public static int Execute<TEntity>(this DeleteEntitiesTermination<TEntity> builder)
            where TEntity : class, IDbEntity
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection, 
                    null
                );
        }

        /// <summary>
        /// Assemble and execute a DELETE query to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql DELETE statement and generating an error.</param>
        /// <returns>The number of records removed from the database.</returns>
        public static int Execute<TEntity>(this DeleteEntitiesTermination<TEntity> builder, int commandTimeout)
            where TEntity : class, IDbEntity
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection, 
                    command => command.CommandTimeout = commandTimeout
                );
        }

        /// <summary>
        /// Assemble and execute a DELETE query to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql DELETE statement.</param>
        /// <returns>The number of records removed from the database.</returns>
        public static int Execute<TEntity>(this DeleteEntitiesTermination<TEntity> builder, ISqlConnection connection)
            where TEntity : class, IDbEntity
        {
            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null
            );
        }

        /// <summary>
        /// Assemble and execute a DELETE query to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql DELETE statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql DELETE statement and generating an error.</param>
        /// <returns>The number of records removed from the database.</returns>
        public static int Execute<TEntity>(this DeleteEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout)
            where TEntity : class, IDbEntity
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a DELETE query to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the DELETE statement should be cancelled.</param>
        /// <returns>The number of records removed from the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this DeleteEntitiesTermination<TEntity> builder, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    null, 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a DELETE query to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql DELETE statement.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the DELETE statement should be cancelled.</param>
        /// <returns>The number of records removed from the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this DeleteEntitiesTermination<TEntity> builder, ISqlConnection connection, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity
        {
            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a DELETE query to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql DELETE statement and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the DELETE statement should be cancelled.</param>
        /// <returns>The number of records removed from the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this DeleteEntitiesTermination<TEntity> builder, int commandTimeout, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection,
                    command => command.CommandTimeout = commandTimeout, 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a DELETE query to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql DELETE statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql DELETE statement and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the DELETE statement should be cancelled.</param>
        /// <returns>The number of records removed from the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this DeleteEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                cancellationToken
            ).ConfigureAwait(false);
        }
        #endregion

        #region SelectValueTermination<TValue>
        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a single <typeparamref name="TValue"/> value.
        /// </summary>
        /// <returns>The single <typeparamref name="TValue"/> value retrieved from execution of the sql SELECT query.</returns>
        public static TValue Execute<TValue>(this SelectValueTermination<TValue> builder)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection, 
                    null
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a single <typeparamref name="TValue"/> value.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>The single <typeparamref name="TValue"/> value retrieved from execution of the sql SELECT query.</returns>
        public static TValue Execute<TValue>(this SelectValueTermination<TValue> builder, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection, 
                    command => command.CommandTimeout = commandTimeout
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a single <typeparamref name="TValue"/> value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <returns>The single <typeparamref name="TValue"/> value retrieved from execution of the sql SELECT query.</returns>
        public static TValue Execute<TValue>(this SelectValueTermination<TValue> builder, ISqlConnection connection)
        {
            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a single <typeparamref name="TValue"/> value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>The single <typeparamref name="TValue"/> value retrieved from execution of the sql SELECT query.</returns>
        public static TValue Execute<TValue>(this SelectValueTermination<TValue> builder, ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a single <typeparamref name="TValue"/> value.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The single <typeparamref name="TValue"/> value retrieved from execution of the sql SELECT query.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectValueTermination<TValue> builder, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    null, 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a single <typeparamref name="TValue"/> value.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The single <typeparamref name="TValue"/> value retrieved from execution of the sql SELECT query.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectValueTermination<TValue> builder, int commandTimeout, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a single <typeparamref name="TValue"/> value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The single <typeparamref name="TValue"/> value retrieved from execution of the sql SELECT query.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectValueTermination<TValue> builder, ISqlConnection connection, CancellationToken cancellationToken = default)
        {
            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a single <typeparamref name="TValue"/> value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The single <typeparamref name="TValue"/> value retrieved from execution of the sql SELECT query.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectValueTermination<TValue> builder, ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                cancellationToken
            ).ConfigureAwait(false);
        }
        #endregion

        #region SelectValuesTermination<TValue>
        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        public static IList<TValue> Execute<TValue>(this SelectValuesTermination<TValue> builder)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection, 
                    null
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        public static IList<TValue> Execute<TValue>(this SelectValuesTermination<TValue> builder, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection, 
                    command => command.CommandTimeout = commandTimeout
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        public static IList<TValue> Execute<TValue>(this SelectValuesTermination<TValue> builder, ISqlConnection connection)
        {
            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        public static IList<TValue> Execute<TValue>(this SelectValuesTermination<TValue> builder, ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="handleValue"/> delegate to manage the retrieved value.
        /// </summary>
        /// <param name="handleValue">The delegate to manage the value returned from execution of the query.</param>
        public static void Execute<TValue>(this SelectValuesTermination<TValue> builder, Action<TValue> handleValue)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                builder.ExecutePipeline(
                    connection, 
                    null, 
                    handleValue ?? throw new ArgumentNullException(nameof(handleValue))
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="handleValue"/> delegate to manage the retrieved value.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="handleValue">The delegate to manage the value returned from execution of the query.</param>
        public static void Execute<TValue>(this SelectValuesTermination<TValue> builder, int commandTimeout, Action<TValue> handleValue)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                builder.ExecutePipeline(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    handleValue ?? throw new ArgumentNullException(nameof(handleValue))
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="handleValue"/> delegate to manage the retrieved value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="handleValue">The delegate to manage the value returned from execution of the query.</param>
        public static void Execute<TValue>(this SelectValuesTermination<TValue> builder, ISqlConnection connection, Action<TValue> handleValue)
        {
            builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                handleValue ?? throw new ArgumentNullException(nameof(handleValue))
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="handleValue"/> delegate to manage the retrieved value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="handleValue">The delegate to manage the value returned from execution of the query.</param>
        public static void Execute<TValue>(this SelectValuesTermination<TValue> builder, ISqlConnection connection, int commandTimeout, Action<TValue> handleValue)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                handleValue ?? throw new ArgumentNullException(nameof(handleValue))
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectValuesTermination<TValue> builder, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    null, 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectValuesTermination<TValue> builder, int commandTimeout, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectValuesTermination<TValue> builder, ISqlConnection connection, CancellationToken cancellationToken = default)
        {
            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectValuesTermination<TValue> builder, ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        public static async Task ExecuteAsync<TValue>(this SelectValuesTermination<TValue> builder, Action<TValue> read, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection,
                    null,
                    read ?? throw new ArgumentNullException(nameof(read)),
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        public static async Task ExecuteAsync<TValue>(this SelectValuesTermination<TValue> builder, int commandTimeout, Action<TValue> read, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection,
                    command => command.CommandTimeout = commandTimeout,
                    read ?? throw new ArgumentNullException(nameof(read)),
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        public static async Task ExecuteAsync<TValue>(this SelectValuesTermination<TValue> builder, ISqlConnection connection, Action<TValue> read, CancellationToken cancellationToken = default)
        {
            await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        public static async Task ExecuteAsync<TValue>(this SelectValuesTermination<TValue> builder, ISqlConnection connection, int commandTimeout, Action<TValue> read, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        public static async Task ExecuteAsync<TValue>(this SelectValuesTermination<TValue> builder, Func<TValue, Task> read, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection,
                    null,
                    read ?? throw new ArgumentNullException(nameof(read)),
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        public static async Task ExecuteAsync<TValue>(this SelectValuesTermination<TValue> builder, int commandTimeout, Func<TValue, Task> read, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection,
                    command => command.CommandTimeout = commandTimeout,
                    read ?? throw new ArgumentNullException(nameof(read)),
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        public static async Task ExecuteAsync<TValue>(this SelectValuesTermination<TValue> builder, ISqlConnection connection, Func<TValue, Task> read, CancellationToken cancellationToken = default)
        {
            await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        public static async Task ExecuteAsync<TValue>(this SelectValuesTermination<TValue> builder, ISqlConnection connection, int commandTimeout, Func<TValue, Task> read, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read)),
                cancellationToken
            ).ConfigureAwait(false);
        }
        #endregion

        #region SelectDynamicTermination
        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT query.</returns>
        public static dynamic Execute(this SelectDynamicTermination builder)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection, 
                    null
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT query.</returns>
        public static dynamic Execute(this SelectDynamicTermination builder, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection, 
                    command => command.CommandTimeout = commandTimeout
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT query.</returns>
        public static dynamic Execute(this SelectDynamicTermination builder, ISqlConnection connection)
        {
            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT query.</returns>
        public static dynamic Execute(this SelectDynamicTermination builder, ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of dynamic objects retrieved from execution of the sql SELECT query.</returns>
        public static async Task<dynamic> ExecuteAsync(this SelectDynamicTermination builder, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    null, 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT query.</returns>
        public static async Task<dynamic> ExecuteAsync(this SelectDynamicTermination builder, int commandTimeout, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection,
                    command => command.CommandTimeout = commandTimeout, 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT query.</returns>
        public static async Task<dynamic> ExecuteAsync(this SelectDynamicTermination builder, ISqlConnection connection, CancellationToken cancellationToken = default)
        {
            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT query.</returns>
        public static async Task<dynamic> ExecuteAsync(this SelectDynamicTermination builder, ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map to a <typeparamref name="TValue"/> using the <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <returns>The <typeparamref name="TValue"/> retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static TValue Execute<TValue>(this SelectDynamicTermination builder, Func<ISqlFieldReader, TValue> map)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection,
                    null, 
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map to a <typeparamref name="TValue"/> using the <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <returns>The <typeparamref name="TValue"/> retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static TValue Execute<TValue>(this SelectDynamicTermination builder, int commandTimeout, Func<ISqlFieldReader, TValue> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection,
                    command => command.CommandTimeout = commandTimeout, 
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map to a <typeparamref name="TValue"/> using the <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <returns>The <typeparamref name="TValue"/> retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static TValue Execute<TValue>(this SelectDynamicTermination builder, ISqlConnection connection, Func<ISqlFieldReader, TValue> map)
        {
            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map to a <typeparamref name="TValue"/> using the <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <returns>The <typeparamref name="TValue"/> retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static TValue Execute<TValue>(this SelectDynamicTermination builder, ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TValue> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        public static void Execute(this SelectDynamicTermination builder, Action<ISqlFieldReader> read)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                builder.ExecutePipeline(
                    connection, 
                    null, 
                    read ?? throw new ArgumentNullException(nameof(read))
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        public static void Execute(this SelectDynamicTermination builder, int commandTimeout, Action<ISqlFieldReader> read)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                builder.ExecutePipeline(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    read ?? throw new ArgumentNullException(nameof(read))
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        public static void Execute(this SelectDynamicTermination builder, ISqlConnection connection, Action<ISqlFieldReader> read)
        {
            builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        public static void Execute(this SelectDynamicTermination builder, ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout, 
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }
        
        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row from the rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/>The value mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        public static async Task ExecuteAsync(this SelectDynamicTermination builder, Action<ISqlFieldReader> map, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection,
                    null,
                    map ?? throw new ArgumentNullException(nameof(map)),
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row from the rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/>The value mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        public static async Task ExecuteAsync(this SelectDynamicTermination builder, int commandTimeout, Action<ISqlFieldReader> map, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection,
                    command => command.CommandTimeout = commandTimeout,
                    map ?? throw new ArgumentNullException(nameof(map)),
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row from the rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/>The value mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        public static async Task ExecuteAsync(this SelectDynamicTermination builder, ISqlConnection connection, Action<ISqlFieldReader> map, CancellationToken cancellationToken = default)
        {
            await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row from the rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/>The value mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        public static async Task ExecuteAsync(this SelectDynamicTermination builder, ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> map, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row from the rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/>The value mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectDynamicTermination builder, Func<ISqlFieldReader, TValue> map, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection,
                    null, 
                    map ?? throw new ArgumentNullException(nameof(map)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row from the rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/>The value mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectDynamicTermination builder, int commandTimeout, Func<ISqlFieldReader, TValue> map, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection,
                    command => command.CommandTimeout = commandTimeout, 
                    map ?? throw new ArgumentNullException(nameof(map)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row from the rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/>The value mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectDynamicTermination builder, ISqlConnection connection, Func<ISqlFieldReader, TValue> map, CancellationToken cancellationToken = default)
        {
            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                map ?? throw new ArgumentNullException(nameof(map)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row from the rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/>The value mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectDynamicTermination builder, ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TValue> map, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                map ?? throw new ArgumentNullException(nameof(map)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync(this SelectDynamicTermination builder, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection, 
                    null, 
                    read ?? throw new ArgumentNullException(nameof(read)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync(this SelectDynamicTermination builder, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    read ?? throw new ArgumentNullException(nameof(read)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync(this SelectDynamicTermination builder, ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default)
        {
            await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null, 
                read ?? throw new ArgumentNullException(nameof(read)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync(this SelectDynamicTermination builder, ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout, 
                read ?? throw new ArgumentNullException(nameof(read)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map the returned row to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/>The value mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectDynamicTermination builder, Func<ISqlFieldReader, Task<TValue>> map, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection,
                    null, 
                    map ?? throw new ArgumentNullException(nameof(map)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map the returned row to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/>The value mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectDynamicTermination builder, int commandTimeout, Func<ISqlFieldReader, Task<TValue>> map, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection,
                    command => command.CommandTimeout = commandTimeout, 
                    map ?? throw new ArgumentNullException(nameof(map)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map the returned row to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/>The value mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectDynamicTermination builder, ISqlConnection connection, Func<ISqlFieldReader, Task<TValue>> map, CancellationToken cancellationToken = default)
        {
            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                map ?? throw new ArgumentNullException(nameof(map)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map the returned row to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/>The value mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectDynamicTermination builder, ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task<TValue>> map, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                map ?? throw new ArgumentNullException(nameof(map)), 
                cancellationToken
            ).ConfigureAwait(false);
        }
        #endregion

        #region SelectDynamicsTermination
        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <returns>A list of dynamic objects retrieved from execution of the sql SELECT query.</returns>
        public static IList<dynamic> Execute(this SelectDynamicsTermination builder)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection,
                    null
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>A list of dynamic objects retrieved from execution of the sql SELECT query.</returns>
        public static IList<dynamic> Execute(this SelectDynamicsTermination builder, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection,
                    command => command.CommandTimeout = commandTimeout
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <returns>A list of dynamic objects retrieved from execution of the sql SELECT query.</returns>
        public static IList<dynamic> Execute(this SelectDynamicsTermination builder, ISqlConnection connection)
        {
            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>A list of dynamic objects retrieved from execution of the sql SELECT query.</returns>
        public static IList<dynamic> Execute(this SelectDynamicsTermination builder, ISqlConnection connection, int commandTimeout)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of dynamic objects retrieved from execution of the sql SELECT query.</returns>
        public static async Task<IList<dynamic>> ExecuteAsync(this SelectDynamicsTermination builder, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection,
                    null, 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of dynamic objects retrieved from execution of the sql SELECT query.</returns>
        public static async Task<IList<dynamic>> ExecuteAsync(this SelectDynamicsTermination builder, int commandTimeout, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection,
                    command => command.CommandTimeout = commandTimeout, 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of dynamic objects retrieved from execution of the sql SELECT query.</returns>
        public static async Task<IList<dynamic>> ExecuteAsync(this SelectDynamicsTermination builder, ISqlConnection connection, CancellationToken cancellationToken = default)
        {
            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of dynamic objects retrieved from execution of the sql SELECT query.</returns>
        public static async Task<IList<dynamic>> ExecuteAsync(this SelectDynamicsTermination builder, ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static IList<TValue> Execute<TValue>(this SelectDynamicsTermination builder, Func<ISqlFieldReader, TValue> map)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection,
                    null, 
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static IList<TValue> Execute<TValue>(this SelectDynamicsTermination builder, int commandTimeout, Func<ISqlFieldReader, TValue> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static IList<TValue> Execute<TValue>(this SelectDynamicsTermination builder, ISqlConnection connection, Func<ISqlFieldReader, TValue> map)
        {
            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static IList<TValue> Execute<TValue>(this SelectDynamicsTermination builder, ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TValue> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="map">The delegate to manage the rowset returned from execution of the query.</param>
        public static void Execute(this SelectDynamicsTermination builder, Action<ISqlFieldReader> map)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                builder.ExecutePipeline(
                    connection, 
                    null, 
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage the rowset returned from execution of the query.</param>
        public static void Execute(this SelectDynamicsTermination builder, int commandTimeout, Action<ISqlFieldReader> map)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                builder.ExecutePipeline(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        public static void Execute(this SelectDynamicsTermination builder, ISqlConnection connection, Action<ISqlFieldReader> read)
        {
            builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        public static void Execute(this SelectDynamicsTermination builder, ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout,
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectDynamicsTermination builder, Func<ISqlFieldReader, TValue> map, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    null, 
                    map ?? throw new ArgumentNullException(nameof(map)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectDynamicsTermination builder, int commandTimeout, Func<ISqlFieldReader, TValue> map, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    map ?? throw new ArgumentNullException(nameof(map)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectDynamicsTermination builder, ISqlConnection connection, Func<ISqlFieldReader, TValue> map, CancellationToken cancellationToken = default)
        {
            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                map ?? throw new ArgumentNullException(nameof(map)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectDynamicsTermination builder, ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TValue> map, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                map ?? throw new ArgumentNullException(nameof(map)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync(this SelectDynamicsTermination builder, Action<ISqlFieldReader> read, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection, 
                    null, 
                    read ?? throw new ArgumentNullException(nameof(read)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync(this SelectDynamicsTermination builder, int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    read ?? throw new ArgumentNullException(nameof(read)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync(this SelectDynamicsTermination builder, ISqlConnection connection, Action<ISqlFieldReader> read, CancellationToken cancellationToken = default)
        {
            await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                read ?? throw new ArgumentNullException(nameof(read)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync(this SelectDynamicsTermination builder, ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                read ?? throw new ArgumentNullException(nameof(read)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync(this SelectDynamicsTermination builder, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection, 
                    null, 
                    read ?? throw new ArgumentNullException(nameof(read)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync(this SelectDynamicsTermination builder, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    read ?? throw new ArgumentNullException(nameof(read)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync(this SelectDynamicsTermination builder, ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default)
        {
            await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                read ?? throw new ArgumentNullException(nameof(read)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync(this SelectDynamicsTermination builder, ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                command => command.CommandTimeout = commandTimeout, 
                read ?? throw new ArgumentNullException(nameof(read)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectDynamicsTermination builder, Func<ISqlFieldReader, Task<TValue>> map, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    null, 
                    map ?? throw new ArgumentNullException(nameof(map)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectDynamicsTermination builder, int commandTimeout, Func<ISqlFieldReader, Task<TValue>> map, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    map ?? throw new ArgumentNullException(nameof(map)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectDynamicsTermination builder, ISqlConnection connection, Func<ISqlFieldReader, Task<TValue>> map, CancellationToken cancellationToken = default)
        {
            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectDynamicsTermination builder, ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task<TValue>> map, CancellationToken cancellationToken = default)
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                map ?? throw new ArgumentNullException(nameof(map)), 
                cancellationToken
            ).ConfigureAwait(false);
        }
        #endregion

        #region SelectEntityTermination
        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        public static TEntity Execute<TEntity>(this SelectEntityTermination<TEntity> builder)
            where TEntity : class, IDbEntity, new()
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection, 
                    null
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        public static TEntity Execute<TEntity>(this SelectEntityTermination<TEntity> builder, int commandTimeout)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection, 
                    command => command.CommandTimeout = commandTimeout
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        public static TEntity Execute<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection)
            where TEntity : class, IDbEntity, new()
        {
            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        public static TEntity Execute<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, int commandTimeout)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and map the returned rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="map">A delegate for mapping the rowset values to a <typeparamref name="TEntity"/> entity.</param>
        /// <returns>A <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static TEntity Execute<TEntity>(this SelectEntityTermination<TEntity> builder, Func<ISqlFieldReader, TEntity> map)
            where TEntity : class, IDbEntity, new()
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection, 
                    null, 
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and map the returned rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for mapping the rowset values to a <typeparamref name="TEntity"/> entity.</param>
        /// <returns>A <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static TEntity Execute<TEntity>(this SelectEntityTermination<TEntity> builder, int commandTimeout, Func<ISqlFieldReader, TEntity> map)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a a record and map the returned rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for mapping the rowset values to a <typeparamref name="TEntity"/> entity.</param>
        /// <returns>A <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static TEntity Execute<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, Func<ISqlFieldReader, TEntity> map)
            where TEntity : class, IDbEntity, new()
        {
            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and map the returned rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for mapping the rowset values to a <typeparamref name="TEntity"/> entity.</param>
        /// <returns>A <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static TEntity Execute<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        public static void Execute<TEntity>(this SelectEntityTermination<TEntity> builder, Action<ISqlFieldReader> read)
            where TEntity : class, IDbEntity, new()
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                builder.ExecutePipeline(
                    connection, 
                    null, 
                    read ?? throw new ArgumentNullException(nameof(read))
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        public static void Execute<TEntity>(this SelectEntityTermination<TEntity> builder, int commandTimeout, Action<ISqlFieldReader> read)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                builder.ExecutePipeline(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    read ?? throw new ArgumentNullException(nameof(read))
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        public static void Execute<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, Action<ISqlFieldReader> read)
            where TEntity : class, IDbEntity, new()
        {
            builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        public static void Execute<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="map">The delegate to manage the rowset returned from execution of the query.</param>
        /// <returns>A <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static TEntity Execute<TEntity>(this SelectEntityTermination<TEntity> builder, Action<ISqlFieldReader, TEntity> map)
            where TEntity : class, IDbEntity, new()
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection, 
                    null, 
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage the rowset returned from execution of the query.</param>
        /// <returns>A <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static TEntity Execute<TEntity>(this SelectEntityTermination<TEntity> builder, int commandTimeout, Action<ISqlFieldReader, TEntity> map)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">The delegate to manage the rowset returned from execution of the query.</param>
        /// <returns>A <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static TEntity Execute<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, Action<ISqlFieldReader, TEntity> map)
            where TEntity : class, IDbEntity, new()
        {
            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage the rowset returned from execution of the query.</param>
        /// <returns>A <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static TEntity Execute<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    null, 
                    cancellationToken
                ).ConfigureAwait(false);
        }        

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, int commandTimeout, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="map">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, Action<ISqlFieldReader> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection, 
                    null,
                    map ?? throw new ArgumentNullException(nameof(map)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    read ?? throw new ArgumentNullException(nameof(read)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, Action<ISqlFieldReader> read, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                read ?? throw new ArgumentNullException(nameof(read)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                read ?? throw new ArgumentNullException(nameof(read)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="map">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    null, 
                    map ?? throw new ArgumentNullException(nameof(map)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    map ?? throw new ArgumentNullException(nameof(map)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                map ?? throw new ArgumentNullException(nameof(map)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                map ?? throw new ArgumentNullException(nameof(map)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="map">A delegate for converting the retrieved database value to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection,
                    null, 
                    map ?? throw new ArgumentNullException(nameof(map)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    map ?? throw new ArgumentNullException(nameof(map)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null,
                map ?? throw new ArgumentNullException(nameof(map)),
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                map ?? throw new ArgumentNullException(nameof(map)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection, 
                    null, 
                    read ?? throw new ArgumentNullException(nameof(read)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    read ?? throw new ArgumentNullException(nameof(read)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                read ?? throw new ArgumentNullException(nameof(read)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                read ?? throw new ArgumentNullException(nameof(read)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="map">A delegate for converting the retrieved database value to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    null, 
                    map ?? throw new ArgumentNullException(nameof(map)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    map ?? throw new ArgumentNullException(nameof(map)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                map ?? throw new ArgumentNullException(nameof(map)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                map ?? throw new ArgumentNullException(nameof(map)), 
                cancellationToken
            ).ConfigureAwait(false);
        }
        #endregion

        #region SelectEntitiesTermination
        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        public static IList<TEntity> Execute<TEntity>(this SelectEntitiesTermination<TEntity> builder)
            where TEntity : class, IDbEntity, new()
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection,
                    null
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        public static IList<TEntity> Execute<TEntity>(this SelectEntitiesTermination<TEntity> builder, int commandTimeout)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection, 
                    command => command.CommandTimeout = commandTimeout
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        public static IList<TEntity> Execute<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection)
            where TEntity : class, IDbEntity, new()
        {
            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        public static IList<TEntity> Execute<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="map">A delegate for mapping each rowset to a <typeparamref name="TEntity"/> entity.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static IList<TEntity> Execute<TEntity>(this SelectEntitiesTermination<TEntity> builder, Func<ISqlFieldReader, TEntity> map)
            where TEntity : class, IDbEntity, new()
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection, 
                    null, 
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for mapping each rowset to a <typeparamref name="TEntity"/> entity.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static IList<TEntity> Execute<TEntity>(this SelectEntitiesTermination<TEntity> builder, int commandTimeout, Func<ISqlFieldReader, TEntity> map)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for mapping each rowset to a <typeparamref name="TEntity"/> entity.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static IList<TEntity> Execute<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, Func<ISqlFieldReader, TEntity> map)
            where TEntity : class, IDbEntity, new()
        {
            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for mapping each rowset to a <typeparamref name="TEntity"/> entity.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static IList<TEntity> Execute<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        public static void Execute<TEntity>(this SelectEntitiesTermination<TEntity> builder, Action<ISqlFieldReader> map)
            where TEntity : class, IDbEntity, new()
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                builder.ExecutePipeline(
                    connection, 
                    null, 
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        public static void Execute<TEntity>(this SelectEntitiesTermination<TEntity> builder, int commandTimeout, Action<ISqlFieldReader> map)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                builder.ExecutePipeline(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage each rowset returned from execution of the query.</param>
        public static void Execute<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, Action<ISqlFieldReader> read)
            where TEntity : class, IDbEntity, new()
        {
            builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage each rowset returned from execution of the query.</param>
        public static void Execute<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                read ?? throw new ArgumentNullException(nameof(read))
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        public static IList<TEntity> Execute<TEntity>(this SelectEntitiesTermination<TEntity> builder, Action<ISqlFieldReader, TEntity> map)
            where TEntity : class, IDbEntity, new()
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection, 
                    null, 
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        public static IList<TEntity> Execute<TEntity>(this SelectEntitiesTermination<TEntity> builder, int commandTimeout, Action<ISqlFieldReader, TEntity> map)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    map ?? throw new ArgumentNullException(nameof(map))
                );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        public static IList<TEntity> Execute<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, Action<ISqlFieldReader, TEntity> map)
            where TEntity : class, IDbEntity, new()
        {
            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        public static IList<TEntity> Execute<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return builder.ExecutePipeline(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                map ?? throw new ArgumentNullException(nameof(map))
            );
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    null, 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, int commandTimeout, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="read">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, Action<ISqlFieldReader> read, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection, 
                    null,
                    read ?? throw new ArgumentNullException(nameof(read)),
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    read ?? throw new ArgumentNullException(nameof(read)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, Action<ISqlFieldReader> read, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                read ?? throw new ArgumentNullException(nameof(read)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                read ?? throw new ArgumentNullException(nameof(read)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to a <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    null, 
                    map ?? throw new ArgumentNullException(nameof(map)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to a <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    map ?? throw new ArgumentNullException(nameof(map)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to a <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                map ?? throw new ArgumentNullException(nameof(map)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to a <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                map ?? throw new ArgumentNullException(nameof(map)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="map">A delegate for mapping each rowset to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    null, 
                    map ?? throw new ArgumentNullException(nameof(map)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for mapping each rowset to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    map ?? throw new ArgumentNullException(nameof(map)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for mapping each rowset to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                map ?? throw new ArgumentNullException(nameof(map)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for mapping each rowset to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                map ?? throw new ArgumentNullException(nameof(map)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="read">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection, 
                    null, 
                    read ?? throw new ArgumentNullException(nameof(read)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    read ?? throw new ArgumentNullException(nameof(read)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                null, 
                read ?? throw new ArgumentNullException(nameof(read)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                read ?? throw new ArgumentNullException(nameof(read)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    null, 
                    map ?? throw new ArgumentNullException(nameof(map)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection, 
                    command => command.CommandTimeout = commandTimeout, 
                    map ?? throw new ArgumentNullException(nameof(map)), 
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)),
                null, 
                map ?? throw new ArgumentNullException(nameof(map)), 
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken = default)
            where TEntity : class, IDbEntity, new()
        {
            if (commandTimeout <= 0)
                throw new ArgumentException($"{nameof(commandTimeout)} must be a number greater than 0.");

            return await builder.ExecutePipelineAsync(
                connection ?? throw new ArgumentNullException(nameof(connection)), 
                command => command.CommandTimeout = commandTimeout, 
                map ?? throw new ArgumentNullException(nameof(map)), 
                cancellationToken
            ).ConfigureAwait(false);
        }
        #endregion

        #region StoredProcedureTermination
        /// <summary>
        /// Assemble and execute a stored procedure.
        /// </summary>
        public static void Execute(this StoredProcedureTermination builder)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                builder.ExecutePipeline(
                    connection,
                    null
                );
        }

        /// <summary>
        /// Assemble and execute a stored procedure.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        public static void Execute(this StoredProcedureTermination builder, ISqlConnection connection)
        {
            builder.ExecutePipeline(
                connection,
                null
            );
        }

        /// <summary>
        /// Assemble and execute a stored procedure.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        public static void Execute<T>(this StoredProcedureTermination builder, int commandTimeout)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                builder.ExecutePipeline(
                    connection,
                    command => command.CommandTimeout = commandTimeout
                );
        }

        /// <summary>
        /// Assemble and execute a stored procedure.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        public static void Execute(this StoredProcedureTermination builder, ISqlConnection connection, int commandTimeout)
        {
            builder.ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a stored procedure.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        public static async Task ExecuteAsync(this StoredProcedureTermination builder, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection,
                    null,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        public static async Task ExecuteAsync(this StoredProcedureTermination builder, ISqlConnection connection, CancellationToken cancellationToken = default)
        {
            await builder.ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        public static async Task ExecuteAsync(this StoredProcedureTermination builder, int commandTimeout, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection,
                    command => command.CommandTimeout = commandTimeout,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        public static async Task ExecuteAsync(this StoredProcedureTermination builder, ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default)
        {
            await builder.ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }
        #endregion

        #region MapValuesStoredProcedureTermination
        /// <summary>
        /// Assemble and execute a stored procedure and use the delegate provided in MapValues to handle the returned rowset(s).
        /// </summary>
        public static void Execute(this MapValuesStoredProcedureTermination builder)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                builder.ExecutePipeline(
                    connection,
                    null
                );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and use the delegate provided in MapValues to handle the returned rowset(s).
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        public static void Execute(this MapValuesStoredProcedureTermination builder, ISqlConnection connection)
        {
            builder.ExecutePipeline(
                connection,
                null
            );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and use the delegate provided in MapValues to handle the returned rowset(s).
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        public static void Execute(this MapValuesStoredProcedureTermination builder, int commandTimeout)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                builder.ExecutePipeline(
                    connection,
                    command => command.CommandTimeout = commandTimeout
                );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and use the delegate provided in MapValues to handle the returned rowset(s).
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        public static void Execute(this MapValuesStoredProcedureTermination builder, ISqlConnection connection, int commandTimeout)
        {
            builder.ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and use the delegate provided in MapValues to handle the returned rowset(s).
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        public static async Task ExecuteAsync(this MapValuesStoredProcedureTermination builder, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection,
                    null,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure and use the delegate provided in MapValues to handle the returned rowset(s).
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        public static async Task ExecuteAsync(this MapValuesStoredProcedureTermination builder, ISqlConnection connection, CancellationToken cancellationToken = default)
        {
            await builder.ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure and use the delegate provided in MapValues to handle the returned rowset(s).
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        public static async Task ExecuteAsync(this MapValuesStoredProcedureTermination builder, int commandTimeout, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                await builder.ExecutePipelineAsync(
                    connection,
                    command => command.CommandTimeout = commandTimeout,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure and use the delegate provided in MapValues to handle the returned rowset(s).
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        public static async Task ExecuteAsync(this MapValuesStoredProcedureTermination builder, ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default)
        {
            await builder.ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }
        #endregion

        #region SelectValueStoredProcedureTermination
        /// <summary>
        /// Assemble and execute a stored procedure and return the scalar value.
        /// </summary>
        /// <returns>The scalar value of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static T Execute<T>(this SelectValueStoredProcedureTermination<T> builder)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection,
                    null
                );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return the scalar value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <returns>The scalar value of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static T Execute<T>(this SelectValueStoredProcedureTermination<T> builder, ISqlConnection connection)
        {
            return builder.ExecutePipeline(
                connection,
                null
            );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return the scalar value.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <returns>The scalar value of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static T Execute<T>(this SelectValueStoredProcedureTermination<T> builder, int commandTimeout)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return the scalar value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <returns>The scalar value of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static T Execute<T>(this SelectValueStoredProcedureTermination<T> builder, ISqlConnection connection, int commandTimeout)
        {
            return builder.ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return the scalar value.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>The scalar value of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static async Task<T> ExecuteAsync<T>(this SelectValueStoredProcedureTermination<T> builder, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection,
                    null,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return the scalar value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>The scalar value of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static async Task<T> ExecuteAsync<T>(this SelectValueStoredProcedureTermination<T> builder, ISqlConnection connection, CancellationToken cancellationToken = default)
        {
            return await builder.ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return the scalar value.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>The scalar value of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static async Task<T> ExecuteAsync<T>(this SelectValueStoredProcedureTermination<T> builder, int commandTimeout, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection,
                    command => command.CommandTimeout = commandTimeout,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return the scalar value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>The scalar value of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static async Task<T> ExecuteAsync<T>(this SelectValueStoredProcedureTermination<T> builder, ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default)
        {
            return await builder.ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }
        #endregion

        #region SelectValuesStoredProcedureTermination
        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static IList<T> Execute<T>(this SelectValuesStoredProcedureTermination<T> builder)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection,
                    null
                );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static IList<T> Execute<T>(this SelectValuesStoredProcedureTermination<T> builder, ISqlConnection connection)
        {
            return builder.ExecutePipeline(
                connection,
                null
            );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static IList<T> Execute<T>(this SelectValuesStoredProcedureTermination<T> builder, int commandTimeout)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static IList<T> Execute<T>(this SelectValuesStoredProcedureTermination<T> builder, ISqlConnection connection, int commandTimeout)
        {
            return builder.ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static async Task<IList<T>> ExecuteAsync<T>(this SelectValuesStoredProcedureTermination<T> builder, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection,
                    null,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static async Task<IList<T>> ExecuteAsync<T>(this SelectValuesStoredProcedureTermination<T> builder, ISqlConnection connection, CancellationToken cancellationToken = default)
        {
            return await builder.ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static async Task<IList<T>> ExecuteAsync<T>(this SelectValuesStoredProcedureTermination<T> builder, int commandTimeout, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection,
                    command => command.CommandTimeout = commandTimeout,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static async Task<IList<T>> ExecuteAsync<T>(this SelectValuesStoredProcedureTermination<T> builder, ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default)
        {
            return await builder.ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }
        #endregion

        #region SelectObjectStoredProcedureTermination
        /// <summary>
        /// Assemble and execute a stored procedure and return the scalar value.
        /// </summary>
        /// <returns>The scalar value of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static T Execute<T>(this SelectObjectStoredProcedureTermination<T> builder)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection,
                    null
                );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return the scalar value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <returns>The scalar value of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static T Execute<T>(this SelectObjectStoredProcedureTermination<T> builder, ISqlConnection connection)
        {
            return builder.ExecutePipeline(
                connection,
                null
            );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return the scalar value.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <returns>The scalar value of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static T Execute<T>(this SelectObjectStoredProcedureTermination<T> builder, int commandTimeout)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return the scalar value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <returns>The scalar value of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static T Execute<T>(this SelectObjectStoredProcedureTermination<T> builder, ISqlConnection connection, int commandTimeout)
        {
            return builder.ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return the scalar value.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>The scalar value of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static async Task<T> ExecuteAsync<T>(this SelectObjectStoredProcedureTermination<T> builder, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection,
                    null,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return the scalar value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>The scalar value of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static async Task<T> ExecuteAsync<T>(this SelectObjectStoredProcedureTermination<T> builder, ISqlConnection connection, CancellationToken cancellationToken = default)
        {
            return await builder.ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return the scalar value.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>The scalar value of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static async Task<T> ExecuteAsync<T>(this SelectObjectStoredProcedureTermination<T> builder, int commandTimeout, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection,
                    command => command.CommandTimeout = commandTimeout,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return the scalar value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>The scalar value of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static async Task<T> ExecuteAsync<T>(this SelectObjectStoredProcedureTermination<T> builder, ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default)
        {
            return await builder.ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }
        #endregion

        #region SelectObjectsStoredProcedureTermination
        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static IList<T> Execute<T>(this SelectObjectsStoredProcedureTermination<T> builder)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection,
                    null
                );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static IList<T> Execute<T>(this SelectObjectsStoredProcedureTermination<T> builder, ISqlConnection connection)
        {
            return builder.ExecutePipeline(
                connection,
                null
            );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static IList<T> Execute<T>(this SelectObjectsStoredProcedureTermination<T> builder, int commandTimeout)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static IList<T> Execute<T>(this SelectObjectsStoredProcedureTermination<T> builder, ISqlConnection connection, int commandTimeout)
        {
            return builder.ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static async Task<IList<T>> ExecuteAsync<T>(this SelectObjectsStoredProcedureTermination<T> builder, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection,
                    null,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static async Task<IList<T>> ExecuteAsync<T>(this SelectObjectsStoredProcedureTermination<T> builder, ISqlConnection connection, CancellationToken cancellationToken = default)
        {
            return await builder.ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static async Task<IList<T>> ExecuteAsync<T>(this SelectObjectsStoredProcedureTermination<T> builder, int commandTimeout, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection,
                    command => command.CommandTimeout = commandTimeout,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        public static async Task<IList<T>> ExecuteAsync<T>(this SelectObjectsStoredProcedureTermination<T> builder, ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default)
        {
            return await builder.ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }
        #endregion






        #region SelectDynamicStoredProcedureTermination
        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a dynamic object.  The properties of the dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <returns>A dynamic object created from the return rowset from execution of the stored procedure.</returns>
        public static dynamic Execute(this SelectDynamicStoredProcedureTermination builder)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection,
                    null
                );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a dynamic object.  The properties of the dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <returns>A dynamic object created from the return rowset from execution of the stored procedure.</returns>
        public static dynamic Execute(this SelectDynamicStoredProcedureTermination builder, ISqlConnection connection)
        {
            return builder.ExecutePipeline(
                connection,
                null
            );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a dynamic object.  The properties of the dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <returns>A dynamic object created from the return rowset from execution of the stored procedure.</returns>
        public static dynamic Execute(this SelectDynamicStoredProcedureTermination builder, int commandTimeout)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a dynamic object.  The properties of the dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <returns>A dynamic object created from the return rowset from execution of the stored procedure.</returns>
        public static dynamic Execute(this SelectDynamicStoredProcedureTermination builder, ISqlConnection connection, int commandTimeout)
        {
            return builder.ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a dynamic object.  The properties of the dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A dynamic object created from the return rowset from execution of the stored procedure.</returns>
        public static async Task<dynamic> ExecuteAsync(this SelectDynamicStoredProcedureTermination builder, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection,
                    null,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a dynamic object.  The properties of the dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A dynamic object created from the return rowset from execution of the stored procedure.</returns>
        public static async Task<dynamic> ExecuteAsync(this SelectDynamicStoredProcedureTermination builder, ISqlConnection connection, CancellationToken cancellationToken = default)
        {
            return await builder.ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a dynamic object.  The properties of the dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A dynamic object created from the return rowset from execution of the stored procedure.</returns>
        public static async Task<dynamic> ExecuteAsync(this SelectDynamicStoredProcedureTermination builder, int commandTimeout, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection,
                    command => command.CommandTimeout = commandTimeout,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a dynamic object.  The properties of the dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A dynamic object created from the return rowset from execution of the stored procedure.</returns>
        public static async Task<dynamic> ExecuteAsync(this SelectDynamicStoredProcedureTermination builder, ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default)
        {
            return await builder.ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }
        #endregion

        #region SelectDynamicsStoredProcedureTermination
        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a list of dynamic objects.  The properties of each dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <returns>A list of dynamic objects created from the return rowset(s) from execution of the stored procedure.</returns>
        public static IList<dynamic> Execute(this SelectDynamicsStoredProcedureTermination builder)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                    connection,
                    null
                );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a list of dynamic objects.  The properties of each dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <returns>A list of dynamic objects created from the return rowset(s) from execution of the stored procedure.</returns>
        public static IList<dynamic> Execute(this SelectDynamicsStoredProcedureTermination builder, ISqlConnection connection)
        {
            return builder.ExecutePipeline(
                connection,
                null
            );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a list of dynamic objects.  The properties of each dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <returns>A list of dynamic objects created from the return rowset(s) from execution of the stored procedure.</returns>
        public static IList<dynamic> Execute(this SelectDynamicsStoredProcedureTermination builder, int commandTimeout)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return builder.ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a list of dynamic objects.  The properties of each dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <returns>A list of dynamic objects created from the return rowset(s) from execution of the stored procedure.</returns>
        public static IList<dynamic> Execute<T>(this SelectDynamicsStoredProcedureTermination builder, ISqlConnection connection, int commandTimeout)
        {
            return builder.ExecutePipeline(
                connection,
                command => command.CommandTimeout = commandTimeout
            );
        }

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a list of dynamic objects.  The properties of each dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A list of dynamic objects created from the return rowset(s) from execution of the stored procedure.</returns>
        public static async Task<IList<dynamic>> ExecuteAsync(this SelectDynamicsStoredProcedureTermination builder, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection,
                    null,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a list of dynamic objects.  The properties of each dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A list of dynamic objects created from the return rowset(s) from execution of the stored procedure.</returns>
        public static async Task<IList<dynamic>> ExecuteAsync(this SelectDynamicsStoredProcedureTermination builder, ISqlConnection connection, CancellationToken cancellationToken = default)
        {
            return await builder.ExecutePipelineAsync(
                connection,
                null,
                cancellationToken
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a list of dynamic objects.  The properties of each dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A list of dynamic objects created from the return rowset(s) from execution of the stored procedure.</returns>
        public static async Task<IList<dynamic>> ExecuteAsync(this SelectDynamicsStoredProcedureTermination builder, int commandTimeout, CancellationToken cancellationToken = default)
        {
            var config = builder.GetDatabaseConfiguration();
            using (var connection = new SqlConnector(config.ConnectionStringFactory, config.ConnectionFactory))
                return await builder.ExecutePipelineAsync(
                    connection,
                    command => command.CommandTimeout = commandTimeout,
                    cancellationToken
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a list of dynamic objects.  The properties of each dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A list of dynamic objects created from the return rowset(s) from execution of the stored procedure.</returns>
        public static async Task<IList<dynamic>> ExecuteAsync<T>(this SelectDynamicsStoredProcedureTermination builder, ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default)
        {
            return await builder.ExecutePipelineAsync(
                connection,
                command => command.CommandTimeout = commandTimeout,
                cancellationToken
            ).ConfigureAwait(false);
        }
        #endregion
        #endregion

        #region execute pipeline
        #region InsertTerminationExpressionBuilder
        private static void ExecutePipeline<T>(this IInsertTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
           where T : class, IDbEntity
           => builder.CreateInsertExecutionPipeline<T>().ExecuteInsert(builder.GetQueryExpression<InsertQueryExpression>(), connection, configureCommand);

        private static async Task ExecutePipelineAsync<T>(this IInsertTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken cancellationToken)
            where T : class, IDbEntity
            => await builder.CreateInsertExecutionPipeline<T>().ExecuteInsertAsync(builder.GetQueryExpression<InsertQueryExpression>(), connection, configureCommand, cancellationToken).ConfigureAwait(false);

        private static IInsertQueryExpressionExecutionPipeline<T> CreateInsertExecutionPipeline<T>(this ITerminationExpressionBuilder builder)
            where T : class, IDbEntity
        {
            var config = builder.GetDatabaseConfiguration();
            return config.ExecutionPipelineFactory.CreateExecutionPipeline<T>(config, builder.GetQueryExpression<InsertQueryExpression>());
        }
        #endregion

        #region UpdateTerminationExpressionBuilder
        private static int ExecutePipeline<T>(this IUpdateTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            where T : class, IDbEntity
            => builder.CreateUpdateExecutionPipeline<T>().ExecuteUpdate(builder.GetQueryExpression<UpdateQueryExpression>(), connection, configureCommand);

        private static async Task<int> ExecutePipelineAsync<T>(this IUpdateTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken cancellationToken)
            where T : class, IDbEntity
            => await builder.CreateUpdateExecutionPipeline<T>().ExecuteUpdateAsync(builder.GetQueryExpression<UpdateQueryExpression>(), connection, configureCommand, cancellationToken).ConfigureAwait(false);

        private static IUpdateQueryExpressionExecutionPipeline<T> CreateUpdateExecutionPipeline<T>(this ITerminationExpressionBuilder builder)
            where T : class, IDbEntity
        {
            var config = builder.GetDatabaseConfiguration();
            return config.ExecutionPipelineFactory.CreateExecutionPipeline<T>(config, builder.GetQueryExpression<UpdateQueryExpression>());
        }
        #endregion

        #region DeleteEntitiesTermination
        private static int ExecutePipeline<T>(this DeleteEntitiesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            where T : class, IDbEntity
            => builder.CreateDeleteExecutionPipeline<T>().ExecuteDelete(builder.GetQueryExpression<DeleteQueryExpression>(), connection, configureCommand);

        private static async Task<int> ExecutePipelineAsync<T>(this DeleteEntitiesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken cancellationToken)
            where T : class, IDbEntity
            => await builder.CreateDeleteExecutionPipeline<T>().ExecuteDeleteAsync(builder.GetQueryExpression<DeleteQueryExpression>(), connection, configureCommand, cancellationToken).ConfigureAwait(false);

        private static IDeleteQueryExpressionExecutionPipeline<T> CreateDeleteExecutionPipeline<T>(this ITerminationExpressionBuilder builder)
            where T : class, IDbEntity
        {
            var config = builder.GetDatabaseConfiguration();
            return config.ExecutionPipelineFactory.CreateExecutionPipeline<T>(config, builder.GetQueryExpression<DeleteQueryExpression>());
        }
        #endregion

        #region SelectValueTermination<T>
        private static T ExecutePipeline<T>(this SelectValueTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectValue<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static async Task<T> ExecutePipelineAsync<T>(this SelectValueTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken cancellationToken)
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectValueAsync<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, cancellationToken).ConfigureAwait(false);
        #endregion

        #region SelectValuesTermination<T>
        private static IList<T> ExecutePipeline<T>(this SelectValuesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectValueList<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static void ExecutePipeline<T>(this SelectValuesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<T> read)
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectValueList(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, read);

        private static async Task<IList<T>> ExecutePipelineAsync<T>(this SelectValuesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken cancellationToken)
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectValueListAsync<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, cancellationToken).ConfigureAwait(false);

        private static async Task ExecutePipelineAsync<T>(this SelectValuesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<T> read, CancellationToken cancellationToken)
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectValueListAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, read, cancellationToken);

        private static async Task ExecutePipelineAsync<T>(this SelectValuesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<T, Task> read, CancellationToken cancellationToken)
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectValueListAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, read, cancellationToken);
        #endregion

        #region SelectDynamicTermination
        private static dynamic ExecutePipeline(this SelectDynamicTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            => builder.CreateSelectExecutionPipeline<dynamic>().ExecuteSelectDynamic(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static void ExecutePipeline(this SelectDynamicTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read)
            => builder.CreateSelectExecutionPipeline<ExpandoObject>().ExecuteSelectDynamic(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, read);


        private static async Task<dynamic> ExecutePipelineAsync(this SelectDynamicTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken cancellationToken)
            => await builder.CreateSelectExecutionPipeline<dynamic>().ExecuteSelectDynamicAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, cancellationToken).ConfigureAwait(false);

        private static async Task ExecutePipelineAsync(this SelectDynamicTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => await builder.CreateSelectExecutionPipeline<ExpandoObject>().ExecuteSelectDynamicAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, read, cancellationToken).ConfigureAwait(false);

        private static async Task ExecutePipelineAsync(this SelectDynamicTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => await builder.CreateSelectExecutionPipeline<ExpandoObject>().ExecuteSelectDynamicAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, read, cancellationToken).ConfigureAwait(false);
        #endregion

        #region SelectDynamicsTermination
        private static IList<dynamic> ExecutePipeline(this SelectDynamicsTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            => builder.CreateSelectExecutionPipeline<dynamic>().ExecuteSelectDynamicList(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static void ExecutePipeline(this SelectDynamicsTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read)
            => builder.CreateSelectExecutionPipeline<ExpandoObject>().ExecuteSelectDynamicList(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, read);

        private static async Task<IList<dynamic>> ExecutePipelineAsync(this SelectDynamicsTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken cancellationToken)
            => await builder.CreateSelectExecutionPipeline<dynamic>().ExecuteSelectDynamicListAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, cancellationToken).ConfigureAwait(false);

        private static async Task ExecutePipelineAsync(this SelectDynamicsTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            => await builder.CreateSelectExecutionPipeline<ExpandoObject>().ExecuteSelectDynamicListAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, read, cancellationToken).ConfigureAwait(false);

        private static async Task ExecutePipelineAsync(this SelectDynamicsTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            => await builder.CreateSelectExecutionPipeline<ExpandoObject>().ExecuteSelectDynamicListAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, read, cancellationToken).ConfigureAwait(false);
        #endregion

        #region SelectDynamicTermination
        private static T ExecutePipeline<T>(this SelectDynamicTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map)
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectObject(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map);

        private static async Task<T> ExecutePipelineAsync<T>(this SelectDynamicTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectObjectAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map, cancellationToken).ConfigureAwait(false);

        private static async Task<T> ExecutePipelineAsync<T>(this SelectDynamicTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, Task<T>> map, CancellationToken cancellationToken)
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectObjectAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map, cancellationToken).ConfigureAwait(false);
        #endregion

        #region SelectValuesTermination (ExpandoObject -> object)
        private static IList<T> ExecutePipeline<T>(this SelectDynamicsTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map)
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectObjectList(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map);               

        private static async Task<IList<T>> ExecutePipelineAsync<T>(this SelectDynamicsTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectObjectListAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map, cancellationToken).ConfigureAwait(false);

        private static async Task<IList<T>> ExecutePipelineAsync<T>(this SelectDynamicsTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, Task<T>> map, CancellationToken cancellationToken)
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectObjectListAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map, cancellationToken).ConfigureAwait(false);
        #endregion

        #region SelectEntityTermination
        private static T ExecutePipeline<T>(this SelectEntityTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntity<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static T ExecutePipeline<T>(this SelectEntityTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map)
            where T : class, IDbEntity, new()
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntity(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map);

        private static void ExecutePipeline<T>(this SelectEntityTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read)
            where T : class, IDbEntity, new()
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntity<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, read);

        private static T ExecutePipeline<T>(this SelectEntityTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader, T> map)
            where T : class, IDbEntity, new()
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntity(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map);

        private static async Task<T> ExecutePipelineAsync<T>(this SelectEntityTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken cancellationToken)
            where T : class, IDbEntity, new()
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityAsync<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, cancellationToken).ConfigureAwait(false);

        private static async Task ExecutePipelineAsync<T>(this SelectEntityTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            where T : class, IDbEntity, new()
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityAsync<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, read, cancellationToken);

        private static async Task<T> ExecutePipelineAsync<T>(this SelectEntityTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader, T> map, CancellationToken cancellationToken)
            where T : class, IDbEntity, new()
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map, cancellationToken).ConfigureAwait(false);

        private static async Task<T> ExecutePipelineAsync<T>(this SelectEntityTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
            where T : class, IDbEntity, new()
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map, cancellationToken);

        private static async Task ExecutePipelineAsync<T>(this SelectEntityTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            where T : class, IDbEntity, new()
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityAsync<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, read, cancellationToken);

        private static async Task<T> ExecutePipelineAsync<T>(this SelectEntityTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T, Task> map, CancellationToken cancellationToken)
            where T : class, IDbEntity, new()
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map, cancellationToken).ConfigureAwait(false);
        #endregion

        #region SelectEntitiesTermination
        private static IList<T> ExecutePipeline<T>(this SelectEntitiesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityList<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static IList<T> ExecutePipeline<T>(this SelectEntitiesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map)
            where T : class, IDbEntity, new()
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityList(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map);

        private static void ExecutePipeline<T>(this SelectEntitiesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read)
            where T : class, IDbEntity, new()
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityList<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, read);

        private static IList<T> ExecutePipeline<T>(this SelectEntitiesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader, T> map)
            where T : class, IDbEntity, new()
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityList(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map);

        private static async Task<IList<T>> ExecutePipelineAsync<T>(this SelectEntitiesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken cancellationToken) 
            where T : class, IDbEntity, new()
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityListAsync<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, cancellationToken).ConfigureAwait(false);

        private static async Task ExecutePipelineAsync<T>(this SelectEntitiesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read, CancellationToken cancellationToken)
            where T : class, IDbEntity, new()
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityListAsync<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, read, cancellationToken).ConfigureAwait(false);

        private static async Task<IList<T>> ExecutePipelineAsync<T>(this SelectEntitiesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader, T> map, CancellationToken cancellationToken)
            where T : class, IDbEntity, new()
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityListAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map, cancellationToken).ConfigureAwait(false);

        private static async Task<IList<T>> ExecutePipelineAsync<T>(this SelectEntitiesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken)
            where T : class, IDbEntity, new()
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityListAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map, cancellationToken).ConfigureAwait(false);

        private static async Task ExecutePipelineAsync<T>(this SelectEntitiesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken)
            where T : class, IDbEntity, new()
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityListAsync<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, read, cancellationToken).ConfigureAwait(false);

        private static async Task<IList<T>> ExecutePipelineAsync<T>(this SelectEntitiesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T, Task> map, CancellationToken cancellationToken)
            where T : class, IDbEntity, new()
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityListAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map, cancellationToken).ConfigureAwait(false);
        #endregion

        private static ISelectQueryExpressionExecutionPipeline CreateSelectExecutionPipeline<T>(this ITerminationExpressionBuilder builder)
        {
            var config = builder.GetDatabaseConfiguration();
            return config.ExecutionPipelineFactory?.CreateExecutionPipeline(config, builder.GetQueryExpression<SelectQueryExpression>()) ?? throw new DbExpressionConfigurationException($"Could not resolve/create an execution pipeline for type '{builder.GetType()}',  please review and ensure the correct configuration for DbExpression.");
        }

        #region StoredProcedureTermination
        private static void ExecutePipeline(this StoredProcedureTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            => builder.CreateStoredProcedureExecutionPipeline().Execute(builder.GetQueryExpression<StoredProcedureQueryExpression>(), connection, configureCommand);

        private static async Task ExecutePipelineAsync(this StoredProcedureTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateStoredProcedureExecutionPipeline().ExecuteAsync(builder.GetQueryExpression<StoredProcedureQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);
        #endregion

        #region MapValuesStoredProcedureTermination
        private static void ExecutePipeline(this MapValuesStoredProcedureTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            => builder.CreateStoredProcedureExecutionPipeline().Execute(builder.GetQueryExpression<StoredProcedureQueryExpression>(), builder.Map, connection, configureCommand);

        private static async Task ExecutePipelineAsync(this MapValuesStoredProcedureTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateStoredProcedureExecutionPipeline().ExecuteAsync(builder.GetQueryExpression<StoredProcedureQueryExpression>(), builder.Map, connection, configureCommand, ct).ConfigureAwait(false);
        #endregion

        #region SelectValueStoredProcedureTermination
        private static T ExecutePipeline<T>(this SelectValueStoredProcedureTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            => builder.CreateStoredProcedureExecutionPipeline<T>().ExecuteSelectValue<T>(builder.GetQueryExpression<StoredProcedureQueryExpression>(), connection, configureCommand);

        private static async Task<T> ExecutePipelineAsync<T>(this SelectValueStoredProcedureTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateStoredProcedureExecutionPipeline<T>().ExecuteSelectValueAsync<T>(builder.GetQueryExpression<StoredProcedureQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);
        #endregion

        #region SelectValuesStoredProcedureTermination
        private static IList<T> ExecutePipeline<T>(this SelectValuesStoredProcedureTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            => builder.CreateStoredProcedureExecutionPipeline<T>().ExecuteSelectValueList<T>(builder.GetQueryExpression<StoredProcedureQueryExpression>(), connection, configureCommand);

        private static async Task<IList<T>> ExecutePipelineAsync<T>(this SelectValuesStoredProcedureTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateStoredProcedureExecutionPipeline<T>().ExecuteSelectValueListAsync<T>(builder.GetQueryExpression<StoredProcedureQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);
        #endregion

        #region SelectObjectStoredProcedureTermination
        private static T ExecutePipeline<T>(this SelectObjectStoredProcedureTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            => builder.CreateStoredProcedureExecutionPipeline<T>().ExecuteSelectObject<T>(builder.GetQueryExpression<StoredProcedureQueryExpression>(), builder.Map, connection, configureCommand);

        private static async Task<T> ExecutePipelineAsync<T>(this SelectObjectStoredProcedureTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateStoredProcedureExecutionPipeline<T>().ExecuteSelectObjectAsync<T>(builder.GetQueryExpression<StoredProcedureQueryExpression>(), builder.Map, connection, configureCommand, ct).ConfigureAwait(false);
        #endregion

        #region SelectObjectsStoredProcedureTermination
        private static IList<T> ExecutePipeline<T>(this SelectObjectsStoredProcedureTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            => builder.CreateStoredProcedureExecutionPipeline<T>().ExecuteSelectObjectList(builder.GetQueryExpression<StoredProcedureQueryExpression>(), builder.Map, connection, configureCommand);

        private static async Task<IList<T>> ExecutePipelineAsync<T>(this SelectObjectsStoredProcedureTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateStoredProcedureExecutionPipeline<T>().ExecuteSelectObjectListAsync(builder.GetQueryExpression<StoredProcedureQueryExpression>(), builder.Map, connection, configureCommand, ct).ConfigureAwait(false);
        #endregion

        #region SelectDynamicStoredProcedureTermination
        private static dynamic ExecutePipeline(this SelectDynamicStoredProcedureTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            => builder.CreateStoredProcedureExecutionPipeline<dynamic>().ExecuteSelectDynamic(builder.GetQueryExpression<StoredProcedureQueryExpression>(), connection, configureCommand);

        private static async Task<dynamic> ExecutePipelineAsync(this SelectDynamicStoredProcedureTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateStoredProcedureExecutionPipeline<dynamic>().ExecuteSelectDynamicAsync(builder.GetQueryExpression<StoredProcedureQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);
        #endregion

        #region SelectDynamicsStoredProcedureTermination
        private static IList<dynamic> ExecutePipeline(this SelectDynamicsStoredProcedureTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            => builder.CreateStoredProcedureExecutionPipeline<dynamic>().ExecuteSelectDynamicList(builder.GetQueryExpression<StoredProcedureQueryExpression>(), connection, configureCommand);

        private static async Task<IList<dynamic>> ExecutePipelineAsync(this SelectDynamicsStoredProcedureTermination builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateStoredProcedureExecutionPipeline<dynamic>().ExecuteSelectDynamicListAsync(builder.GetQueryExpression<StoredProcedureQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);
        #endregion

        private static IStoredProcedureQueryExpressionExecutionPipeline CreateStoredProcedureExecutionPipeline(this ITerminationExpressionBuilder builder)
        {
            var config = builder.GetDatabaseConfiguration();
            return config.ExecutionPipelineFactory?.CreateExecutionPipeline(config, builder.GetQueryExpression<StoredProcedureQueryExpression>()) ?? throw new DbExpressionConfigurationException($"Could not resolve/create an execution pipeline for type '{builder.GetType()}', please review and ensure the correct configuration for DbExpression.");
        }

        private static IStoredProcedureQueryExpressionExecutionPipeline CreateStoredProcedureExecutionPipeline<T>(this ITerminationExpressionBuilder builder)
        {
            var config = builder.GetDatabaseConfiguration();
            return config.ExecutionPipelineFactory?.CreateExecutionPipeline(config, builder.GetQueryExpression<StoredProcedureQueryExpression>()) ?? throw new DbExpressionConfigurationException($"Could not resolve/create an execution pipeline for type '{builder.GetType()}', please review and ensure the correct configuration for DbExpression.");
        }
        #endregion

        #region get database configuration
        private static RuntimeSqlDatabaseConfiguration GetDatabaseConfiguration(this ITerminationExpressionBuilder builder)
        {
            return builder.Configuration ?? throw new DbExpressionConfigurationException($"Database configuration is required, please review and ensure the correct configuration for DbExpression.");
        }
        #endregion

        #region get query expression
        private static T GetQueryExpression<T>(this ITerminationExpressionBuilder builder)
            where T : QueryExpression
        {
            return (builder as IQueryExpressionProvider).Expression as T ?? throw new DbExpressionConfigurationException($"Query expression is type '{(builder as IQueryExpressionProvider).Expression.GetType()}', the type was expected to be the requested type of '{typeof(T)}'.");
        }
        #endregion
    }
}
