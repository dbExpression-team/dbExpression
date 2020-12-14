using HatTrick.DbEx.Sql.Builder;
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
        /// Execute a sql INSERT query expression as a sql statement to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        public static void Execute<TEntity>(this IInsertTerminationExpressionBuilder<TEntity> builder)
            where TEntity : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                builder.ExecutePipeline(connection, null);
        }

        /// <summary>
        /// Execute a sql INSERT query expression as a sql statement to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql INSERT statement and generating an error.</param>
        public static void Execute<TEntity>(this IInsertTerminationExpressionBuilder<TEntity> builder, int commandTimeout)
            where TEntity : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);
        }

        /// <summary>
        /// Execute a sql INSERT query expression as a sql statement to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql INSERT statement.</param>
        public static void Execute<TEntity>(this IInsertTerminationExpressionBuilder<TEntity> builder, ISqlConnection connection)
            where TEntity : class, IDbEntity
            => builder.ExecutePipeline(connection, null);

        /// <summary>
        /// Execute a sql INSERT query expression as a sql statement to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql INSERT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql INSERT statement and generating an error.</param>
        public static void Execute<TEntity>(this IInsertTerminationExpressionBuilder<TEntity> builder, ISqlConnection connection, int commandTimeout)
            where TEntity : class, IDbEntity
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        /// <summary>
        /// Execute a sql INSERT query expression as a sql statement to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        public static async Task ExecuteAsync<TEntity>(this IInsertTerminationExpressionBuilder<TEntity> builder)
            where TEntity : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql INSERT query expression as a sql statement to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql INSERT statement.</param>
        public static async Task ExecuteAsync<TEntity>(this IInsertTerminationExpressionBuilder<TEntity> builder, ISqlConnection connection)
            where TEntity : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql INSERT query expression as a sql statement to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql INSERT statement.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the INSERT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this IInsertTerminationExpressionBuilder<TEntity> builder, CancellationToken ct)
            where TEntity : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql INSERT query expression as a sql statement to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql INSERT statement.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the INSERT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this IInsertTerminationExpressionBuilder<TEntity> builder, ISqlConnection connection, CancellationToken ct)
            where TEntity : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql INSERT query expression as a sql statement to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql INSERT statement and generating an error.</param>
        public static async Task ExecuteAsync<TEntity>(this IInsertTerminationExpressionBuilder<TEntity> builder, int commandTimeout)
            where TEntity : class, IDbEntity
        {
            using (var connetion = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                await builder.ExecutePipelineAsync(connetion, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql INSERT query expression as a sql statement to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql INSERT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql INSERT statement and generating an error.</param>
        public static async Task ExecuteAsync<TEntity>(this IInsertTerminationExpressionBuilder<TEntity> builder, ISqlConnection connection, int commandTimeout)
           where TEntity : class, IDbEntity
             => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql INSERT query expression as a sql statement to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql INSERT statement and generating an error.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the INSERT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this IInsertTerminationExpressionBuilder<TEntity> builder, int commandTimeout, CancellationToken ct)
            where TEntity : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql INSERT query expression as a sql statement to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql INSERT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql INSERT statement and generating an error.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the INSERT statement should be cancelled.</param>
        public static async Task ExecuteAsync<TEntity>(this IInsertTerminationExpressionBuilder<TEntity> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            where TEntity : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region UpdateEntitiesTermination
        /// <summary>
        /// Execute a sql UPDATE query expression as a sql statement to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <returns>The number of records affected in the database.</returns>
        public static int Execute<TEntity>(this UpdateEntitiesTermination<TEntity> builder)
            where TEntity : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, null);
        }

        /// <summary>
        /// Execute a sql UPDATE query expression as a sql statement to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql UPDATE statement and generating an error.</param>
        /// <returns>The number of records affected in the database.</returns>
        public static int Execute<TEntity>(this UpdateEntitiesTermination<TEntity> builder, int commandTimeout)
            where TEntity : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);
        }

        /// <summary>
        /// Execute a sql UPDATE query expression as a sql statement to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql UPDATE statement.</param>
        /// <returns>The number of records affected in the database.</returns>
        public static int Execute<TEntity>(this UpdateEntitiesTermination<TEntity> builder, ISqlConnection connection)
            where TEntity : class, IDbEntity
            => builder.ExecutePipeline(connection, null);

        /// <summary>
        /// Execute a sql UPDATE query expression as a sql statement to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql UPDATE statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql UPDATE statement and generating an error.</param>
        /// <returns>The number of records affected in the database.</returns>
        public static int Execute<TEntity>(this UpdateEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout)
            where TEntity : class, IDbEntity
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        /// <summary>
        /// Execute a sql UPDATE query expression as a sql statement to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <returns>The number of records affected in the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this UpdateEntitiesTermination<TEntity> builder)
            where TEntity : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql UPDATE query expression as a sql statement to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql UPDATE statement.</param>
        /// <returns>The number of records affected in the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this UpdateEntitiesTermination<TEntity> builder, ISqlConnection connection)
            where TEntity : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql UPDATE query expression as a sql statement to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the UPDATE statement should be cancelled.</param>
        public static async Task<int> ExecuteAsync<TEntity>(this UpdateEntitiesTermination<TEntity> builder, CancellationToken ct)
            where TEntity : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql UPDATE query expression as a sql statement to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql UPDATE statement.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the UPDATE statement should be cancelled.</param>
        /// <returns>The number of records affected in the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this UpdateEntitiesTermination<TEntity> builder, ISqlConnection connection, CancellationToken ct)
            where TEntity : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql UPDATE query expression as a sql statement to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql UPDATE statement and generating an error.</param>
        /// <returns>The number of records affected in the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this UpdateEntitiesTermination<TEntity> builder, int commandTimeout)
            where TEntity : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql UPDATE query expression as a sql statement to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql UPDATE statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql UPDATE statement and generating an error.</param>
        /// <returns>The number of records affected in the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this UpdateEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout)
            where TEntity : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql UPDATE query expression as a sql statement to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql UPDATE statement and generating an error.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the UPDATE statement should be cancelled.</param>
        /// <returns>The number of records affected in the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this IUpdateTerminationExpressionBuilder<TEntity> builder, int commandTimeout, CancellationToken ct)
            where TEntity : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql UPDATE query expression as a sql statement to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql UPDATE statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql UPDATE statement and generating an error.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the UPDATE statement should be cancelled.</param>
        /// <returns>The number of records affected in the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this UpdateEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            where TEntity : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region DeleteEntitiesTermination
        /// <summary>
        /// Execute a sql DELETE query expression as a sql statement to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <returns>The number of records removed from the database.</returns>
        public static int Execute<TEntity>(this DeleteEntitiesTermination<TEntity> builder)
            where TEntity : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, null);
        }

        /// <summary>
        /// Execute a sql DELETE query expression as a sql statement to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql DELETE statement and generating an error.</param>
        /// <returns>The number of records removed from the database.</returns>
        public static int Execute<TEntity>(this DeleteEntitiesTermination<TEntity> builder, int commandTimeout)
            where TEntity : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);
        }

        /// <summary>
        /// Execute a sql DELETE query expression as a sql statement to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql DELETE statement.</param>
        /// <returns>The number of records removed from the database.</returns>
        public static int Execute<TEntity>(this DeleteEntitiesTermination<TEntity> builder, ISqlConnection connection)
            where TEntity : class, IDbEntity
            => builder.ExecutePipeline(connection, null);

        /// <summary>
        /// Execute a sql DELETE query expression as a sql statement to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql DELETE statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql DELETE statement and generating an error.</param>
        /// <returns>The number of records removed from the database.</returns>
        public static int Execute<TEntity>(this DeleteEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout)
            where TEntity : class, IDbEntity
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        /// <summary>
        /// Execute a sql DELETE query expression as a sql statement to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <returns>The number of records removed from the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this DeleteEntitiesTermination<TEntity> builder)
            where TEntity : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql DELETE query expression as a sql statement to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql DELETE statement.</param>
        /// <returns>The number of records removed from the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this DeleteEntitiesTermination<TEntity> builder, ISqlConnection connection)
            where TEntity : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql DELETE query expression as a sql statement to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the DELETE statement should be cancelled.</param>
        /// <returns>The number of records removed from the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this DeleteEntitiesTermination<TEntity> builder, CancellationToken ct)
            where TEntity : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql DELETE query expression as a sql statement to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql DELETE statement.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the DELETE statement should be cancelled.</param>
        /// <returns>The number of records removed from the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this DeleteEntitiesTermination<TEntity> builder, ISqlConnection connection, CancellationToken ct)
            where TEntity : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql DELETE query expression as a sql statement to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql DELETE statement and generating an error.</param>
        /// <returns>The number of records removed from the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this DeleteEntitiesTermination<TEntity> builder, int commandTimeout)
            where TEntity : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql DELETE query expression as a sql statement to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql DELETE statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql DELETE statement and generating an error.</param>
        /// <returns>The number of records removed from the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this DeleteEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout)
            where TEntity : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql DELETE query expression as a sql statement to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql DELETE statement and generating an error.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the DELETE statement should be cancelled.</param>
        /// <returns>The number of records removed from the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this DeleteEntitiesTermination<TEntity> builder, int commandTimeout, CancellationToken ct)
            where TEntity : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql DELETE query expression as a sql statement to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql DELETE statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql DELETE statement and generating an error.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the DELETE statement should be cancelled.</param>
        /// <returns>The number of records removed from the database.</returns>
        public static async Task<int> ExecuteAsync<TEntity>(this DeleteEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            where TEntity : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region SelectValueTermination<TValue>
        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a single <typeparamref name="TValue"/> value.
        /// </summary>
        /// <returns>The single <typeparamref name="TValue"/> value retrieved from execution of the sql SELECT statement.</returns>
        public static TValue Execute<TValue>(this SelectValueTermination<TValue> builder)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, null);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a single <typeparamref name="TValue"/> value.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The single <typeparamref name="TValue"/> value retrieved from execution of the sql SELECT statement.</returns>
        public static TValue Execute<TValue>(this SelectValueTermination<TValue> builder, int commandTimeout)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a single <typeparamref name="TValue"/> value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <returns>The single <typeparamref name="TValue"/> value retrieved from execution of the sql SELECT statement.</returns>
        public static TValue Execute<TValue>(this SelectValueTermination<TValue> builder, ISqlConnection connection)
            => builder.ExecutePipeline(connection, null);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a single <typeparamref name="TValue"/> value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The single <typeparamref name="TValue"/> value retrieved from execution of the sql SELECT statement.</returns>
        public static TValue Execute<TValue>(this SelectValueTermination<TValue> builder, ISqlConnection connection, int commandTimeout)
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a single <typeparamref name="TValue"/> value.
        /// </summary>
        /// <returns>The single <typeparamref name="TValue"/> value retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectValueTermination<TValue> builder)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a single <typeparamref name="TValue"/> value.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The single <typeparamref name="TValue"/> value retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectValueTermination<TValue> builder, int commandTimeout)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a single <typeparamref name="TValue"/> value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <returns>The single <typeparamref name="TValue"/> value retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectValueTermination<TValue> builder, ISqlConnection connection)
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a single <typeparamref name="TValue"/> value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The single <typeparamref name="TValue"/> value retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectValueTermination<TValue> builder, ISqlConnection connection, int commandTimeout)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a single <typeparamref name="TValue"/> value.
        /// </summary>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The single <typeparamref name="TValue"/> value retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectValueTermination<TValue> builder, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a single <typeparamref name="TValue"/> value.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The single <typeparamref name="TValue"/> value retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectValueTermination<TValue> builder, int commandTimeout, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a single <typeparamref name="TValue"/> value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The single <typeparamref name="TValue"/> value retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectValueTermination<TValue> builder, ISqlConnection connection, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a single <typeparamref name="TValue"/> value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The single <typeparamref name="TValue"/> value retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectValueTermination<TValue> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region SelectValuesTermination<TValue>
        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement.</returns>
        public static IList<TValue> Execute<TValue>(this SelectValuesTermination<TValue> builder)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, null);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement.</returns>
        public static IList<TValue> Execute<TValue>(this SelectValuesTermination<TValue> builder, int commandTimeout)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement.</returns>
        public static IList<TValue> Execute<TValue>(this SelectValuesTermination<TValue> builder, ISqlConnection connection)
            => builder.ExecutePipeline(connection, null);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement.</returns>
        public static IList<TValue> Execute<TValue>(this SelectValuesTermination<TValue> builder, ISqlConnection connection, int commandTimeout)
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectValuesTermination<TValue> builder)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectValuesTermination<TValue> builder, int commandTimeout)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectValuesTermination<TValue> builder, ISqlConnection connection)
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectValuesTermination<TValue> builder, ISqlConnection connection, int commandTimeout)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectValuesTermination<TValue> builder, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectValuesTermination<TValue> builder, int commandTimeout, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectValuesTermination<TValue> builder, ISqlConnection connection, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectValuesTermination<TValue> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region SelectValueTermination<ExpandoObject>
        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT statement.</returns>
        public static dynamic Execute(this SelectValueTermination<ExpandoObject> builder)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, null);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT statement.</returns>
        public static dynamic Execute(this SelectValueTermination<ExpandoObject> builder, int commandTimeout)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT statement.</returns>
        public static dynamic Execute(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection)
            => builder.ExecutePipeline(connection, null);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT statement.</returns>
        public static dynamic Execute(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout)
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<dynamic> ExecuteAsync(this SelectValueTermination<ExpandoObject> builder)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<dynamic> ExecuteAsync(this SelectValueTermination<ExpandoObject> builder, int commandTimeout)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<dynamic> ExecuteAsync(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection)
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<dynamic> ExecuteAsync(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The list of dynamic objects retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<dynamic> ExecuteAsync(this SelectValueTermination<ExpandoObject> builder, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<dynamic> ExecuteAsync(this SelectValueTermination<ExpandoObject> builder, int commandTimeout, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<dynamic> ExecuteAsync(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<dynamic> ExecuteAsync(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve records and map to a <typeparamref name="TValue"/> using the <paramref name="map"/> function.
        /// </summary>
        /// <param name="map">A custom mapping function to use for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <returns>The <typeparamref name="TValue"/> retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static TValue Execute<TValue>(this SelectValueTermination<ExpandoObject> builder, Func<ISqlRow, TValue> map)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, null, map);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve records and map to a <typeparamref name="TValue"/> using the <paramref name="map"/> function.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="map">A custom mapping function to use for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <returns>The <typeparamref name="TValue"/> retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static TValue Execute<TValue>(this SelectValueTermination<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, TValue> map)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout, map);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve records and map to a <typeparamref name="TValue"/> using the <paramref name="map"/> function.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="map">A custom mapping function to use for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <returns>The <typeparamref name="TValue"/> retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static TValue Execute<TValue>(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, TValue> map)
            => builder.ExecutePipeline(connection, null, map);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve records and map to a <typeparamref name="TValue"/> using the <paramref name="map"/> function.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="map">A custom mapping function to use for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <returns>The <typeparamref name="TValue"/> retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static TValue Execute<TValue>(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, TValue> map)
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout, map);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve records and map to a <typeparamref name="TValue"/> using the <paramref name="map"/> function.
        /// </summary>
        /// <param name="map">A custom mapping function to use for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <returns>The <typeparamref name="TValue"/> retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectValueTermination<ExpandoObject> builder, Func<ISqlRow, TValue> map)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, map, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve records and map to a <typeparamref name="TValue"/> using the <paramref name="map"/> function.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="map">A custom mapping function to use for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <returns>The <typeparamref name="TValue"/> retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectValueTermination<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, TValue> map)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, map, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve records and map to a <typeparamref name="TValue"/> using the <paramref name="map"/> function.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="map">A custom mapping function to use for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <returns>The <typeparamref name="TValue"/> retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, TValue> map)
            => await builder.ExecutePipelineAsync(connection, null, map, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve records and map to a <typeparamref name="TValue"/> using the <paramref name="map"/> function.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="map">A custom mapping function to use for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <returns>The <typeparamref name="TValue"/> retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, TValue> map)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, map, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve records and map to a <typeparamref name="TValue"/> using the <paramref name="map"/> function.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="map">A custom mapping function to use for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/> retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectValueTermination<ExpandoObject> builder, Func<ISqlRow, TValue> map, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, map, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve records and map to a <typeparamref name="TValue"/> using the <paramref name="map"/> function.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="map">A custom mapping function to use for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/> retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectValueTermination<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, TValue> map, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, map, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve records and map to a <typeparamref name="TValue"/> using the <paramref name="map"/> function.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="map">A custom mapping function to use for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/> retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, TValue> map, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, null, map, ct).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve records and map to a <typeparamref name="TValue"/> using the <paramref name="map"/> function.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="map">A custom mapping function to use for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/> retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static async Task<TValue> ExecuteAsync<TValue>(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, TValue> map, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, map, ct).ConfigureAwait(false);
        #endregion

        #region SelectValuesTermination<ExpandoObject>
        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <returns>The list of dynamic objects retrieved from execution of the sql SELECT statement.</returns>
        public static IList<dynamic> Execute(this SelectValuesTermination<ExpandoObject> builder)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, null);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The list of dynamic objects retrieved from execution of the sql SELECT statement.</returns>
        public static IList<dynamic> Execute(this SelectValuesTermination<ExpandoObject> builder, int commandTimeout)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <returns>The list of dynamic objects retrieved from execution of the sql SELECT statement.</returns>
        public static IList<dynamic> Execute(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection)
            => builder.ExecutePipeline(connection, null);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The list of dynamic objects retrieved from execution of the sql SELECT statement.</returns>
        public static IList<dynamic> Execute(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout)
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <returns>The list of dynamic objects retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<dynamic>> ExecuteAsync(this SelectValuesTermination<ExpandoObject> builder)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The list of dynamic objects retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<dynamic>> ExecuteAsync(this SelectValuesTermination<ExpandoObject> builder, int commandTimeout)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The list of dynamic objects retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<dynamic>> ExecuteAsync(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection)
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The list of dynamic objects retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<dynamic>> ExecuteAsync(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The list of dynamic objects retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<dynamic>> ExecuteAsync(this SelectValuesTermination<ExpandoObject> builder, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The list of dynamic objects retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<dynamic>> ExecuteAsync(this SelectValuesTermination<ExpandoObject> builder, int commandTimeout, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The list of dynamic objects retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<dynamic>> ExecuteAsync(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The list of dynamic objects retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<dynamic>> ExecuteAsync(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="map">A custom mapping function to use for converting the retrieved database values to values of type <typeparamref name="TValue"/>.</param>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static IList<TValue> Execute<TValue>(this SelectValuesTermination<ExpandoObject> builder, Func<ISqlRow, TValue> map)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, null, map);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="map">A custom mapping function to use for converting the retrieved database values to values of type <typeparamref name="TValue"/>.</param>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static IList<TValue> Execute<TValue>(this SelectValuesTermination<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, TValue> map)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout, map);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="map">A custom mapping function to use for converting the retrieved database values to values of type <typeparamref name="TValue"/>.</param>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static IList<TValue> Execute<TValue>(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, TValue> map)
            => builder.ExecutePipeline(connection, null, map);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="map">A custom mapping function to use for converting the retrieved database values to values of type <typeparamref name="TValue"/>.</param>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static IList<TValue> Execute<TValue>(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, TValue> map)
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout, map);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="map">A custom mapping function to use for converting the retrieved database values to values of type <typeparamref name="TValue"/>.</param>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectValuesTermination<ExpandoObject> builder, Func<ISqlRow, TValue> map)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, map, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="map">A custom mapping function to use for converting the retrieved database values to values of type <typeparamref name="TValue"/>.</param>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectValuesTermination<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, TValue> map)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, map, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="map">A custom mapping function to use for converting the retrieved database values to values of type <typeparamref name="TValue"/>.</param>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, TValue> map)
            => await builder.ExecutePipelineAsync(connection, null, map, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="map">A custom mapping function to use for converting the retrieved database values to values of type <typeparamref name="TValue"/>.</param>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, TValue> map)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, map, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="map">A custom mapping function to use for converting the retrieved database values to values of type <typeparamref name="TValue"/>.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectValuesTermination<ExpandoObject> builder, Func<ISqlRow, TValue> map, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, map, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="map">A custom mapping function to use for converting the retrieved database values to values of type <typeparamref name="TValue"/>.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectValuesTermination<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, TValue> map, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, map, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="map">A custom mapping function to use for converting the retrieved database values to values of type <typeparamref name="TValue"/>.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, TValue> map, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, null, map, ct).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="map">A custom mapping function to use for converting the retrieved database values to values of type <typeparamref name="TValue"/>.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT statement and mapped using the provided <paramref name="map"/> function.</returns>
        public static async Task<IList<TValue>> ExecuteAsync<TValue>(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, TValue> map, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, map, ct).ConfigureAwait(false);
        #endregion

        #region SelectEntityTermination
        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT statement.</returns>
        public static TEntity Execute<TEntity>(this SelectEntityTermination<TEntity> builder)
            where TEntity : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, null);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT statement.</returns>
        public static TEntity Execute<TEntity>(this SelectEntityTermination<TEntity> builder, int commandTimeout)
            where TEntity : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT statement.</returns>
        public static TEntity Execute<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection)
            where TEntity : class, IDbEntity, new()
            => builder.ExecutePipeline(connection, null);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT statement.</returns>
        public static TEntity Execute<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, int commandTimeout)
            where TEntity : class, IDbEntity, new()
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder)
            where TEntity : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, int commandTimeout)
            where TEntity : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection)
            where TEntity : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, int commandTimeout)
            where TEntity : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, CancellationToken ct)
            where TEntity : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, int commandTimeout, CancellationToken ct)
            where TEntity : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, CancellationToken ct)
            where TEntity : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<TEntity> ExecuteAsync<TEntity>(this SelectEntityTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            where TEntity : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region SelectEntitiesTermination
        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <returns>The list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT statement.</returns>
        public static IList<TEntity> Execute<TEntity>(this SelectEntitiesTermination<TEntity> builder)
            where TEntity : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, null);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT statement.</returns>
        public static IList<TEntity> Execute<TEntity>(this SelectEntitiesTermination<TEntity> builder, int commandTimeout)
            where TEntity : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <returns>The list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT statement.</returns>
        public static IList<TEntity> Execute<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection)
            where TEntity : class, IDbEntity, new()
            => builder.ExecutePipeline(connection, null);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT statement.</returns>
        public static IList<TEntity> Execute<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout)
            where TEntity : class, IDbEntity, new()
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <returns>The list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder)
            where TEntity : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, int commandTimeout)
            where TEntity : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <returns>The list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection)
            where TEntity : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <returns>The list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout)
            where TEntity : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, CancellationToken ct)
            where TEntity : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, int commandTimeout, CancellationToken ct)
            where TEntity : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, CancellationToken ct)
            where TEntity : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        /// <summary>
        /// Execute a sql SELECT query expression as a sql statement to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT statement and generating an error.</param>
        /// <param name="ct">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT statement.</returns>
        public static async Task<IList<TEntity>> ExecuteAsync<TEntity>(this SelectEntitiesTermination<TEntity> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            where TEntity : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion
        #endregion

        #region execute pipeline
        #region InsertTerminationExpressionBuilder
        private static void ExecutePipeline<T>(this IInsertTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
           where T : class, IDbEntity
           => builder.CreateInsertExecutionPipeline<T>().ExecuteInsert(builder.GetQueryExpression<InsertQueryExpression>(), connection, configureCommand);

        private static async Task ExecutePipelineAsync<T>(this IInsertTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.CreateInsertExecutionPipeline<T>().ExecuteInsertAsync(builder.GetQueryExpression<InsertQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);

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

        private static async Task<int> ExecutePipelineAsync<T>(this IUpdateTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.CreateUpdateExecutionPipeline<T>().ExecuteUpdateAsync(builder.GetQueryExpression<UpdateQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);

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

        private static async Task<int> ExecutePipelineAsync<T>(this DeleteEntitiesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.CreateDeleteExecutionPipeline<T>().ExecuteDeleteAsync(builder.GetQueryExpression<DeleteQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);

        private static IDeleteQueryExpressionExecutionPipeline<T> CreateDeleteExecutionPipeline<T>(this ITerminationExpressionBuilder builder)
            where T : class, IDbEntity
        {
            var config = builder.GetDatabaseConfiguration();
            return config.ExecutionPipelineFactory.CreateExecutionPipeline<T>(config, builder.GetQueryExpression<DeleteQueryExpression>());
        }
        #endregion

        #region SelectValueTermination
        private static T ExecutePipeline<T>(this SelectValueTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectValue<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static async Task<T> ExecutePipelineAsync<T>(this SelectValueTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectValueAsync<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);

        private static IList<T> ExecutePipeline<T>(this SelectValuesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectValueList<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static async Task<IList<T>> ExecutePipelineAsync<T>(this SelectValuesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectValueListAsync<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);

        private static dynamic ExecutePipeline(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            => builder.CreateSelectExecutionPipeline<dynamic>().ExecuteSelectDynamic(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static async Task<dynamic> ExecutePipelineAsync(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateSelectExecutionPipeline<dynamic>().ExecuteSelectDynamicAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);

        private static IList<dynamic> ExecutePipeline(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            => builder.CreateSelectExecutionPipeline<dynamic>().ExecuteSelectDynamicList(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static async Task<IList<dynamic>> ExecutePipelineAsync(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateSelectExecutionPipeline<dynamic>().ExecuteSelectDynamicListAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);

        private static T ExecutePipeline<T>(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlRow, T> map)
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectObject(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map);

        private static async Task<T> ExecutePipelineAsync<T>(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectObjectAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map, ct).ConfigureAwait(false);

        private static IList<T> ExecutePipeline<T>(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlRow, T> map)
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectObjectList(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map);

        private static async Task<IList<T>> ExecutePipelineAsync<T>(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectObjectListAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map, ct).ConfigureAwait(false);

        private static T ExecutePipeline<T>(this SelectEntityTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntity<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static async Task<T> ExecutePipelineAsync<T>(this SelectEntityTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityAsync<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);

        private static IList<T> ExecutePipeline<T>(this SelectEntitiesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityList<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static async Task<IList<T>> ExecutePipelineAsync<T>(this SelectEntitiesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityListAsync<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false); 
        
        private static ISelectQueryExpressionExecutionPipeline CreateSelectExecutionPipeline<T>(this ITerminationExpressionBuilder builder)
        {
            var config = builder.GetDatabaseConfiguration();
            return config.ExecutionPipelineFactory?.CreateExecutionPipeline(config, builder.GetQueryExpression<SelectQueryExpression>()) ?? throw new DbExpressionConfigurationException($"Could not resolve/create an execution pipeline for type '{builder.GetType()}',  please review and ensure the correct configuration for DbExpression.");
        }
        #endregion
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
