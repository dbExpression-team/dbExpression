#region license
// Copyright (c) dbExpression.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion

﻿using DbExpression.Sql.Builder;
using DbExpression.Sql.Connection;
using DbExpression.Sql.Executor;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DbExpression.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectEntitiesTermination<TDatabase, TEntity> : ISelectTerminationExpressionBuilder<TDatabase>
#pragma warning restore IDE1006 // Naming Styles
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, IDbEntity, new()
    {
        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IList<TEntity> Execute();

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IList<TEntity> Execute(int commandTimeout);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IList<TEntity> Execute(ISqlConnection connection);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IList<TEntity> Execute(ISqlConnection connection, int commandTimeout);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="map">A delegate for mapping each rowset to a <typeparamref name="TEntity"/> entity.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        IList<TEntity> Execute(Func<ISqlFieldReader, TEntity> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for mapping each rowset to a <typeparamref name="TEntity"/> entity.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        IList<TEntity> Execute(int commandTimeout, Func<ISqlFieldReader, TEntity> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for mapping each rowset to a <typeparamref name="TEntity"/> entity.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        IList<TEntity> Execute(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for mapping each rowset to a <typeparamref name="TEntity"/> entity.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        IList<TEntity> Execute(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        void Execute(Action<ISqlFieldReader> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        void Execute(int commandTimeout, Action<ISqlFieldReader> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage each rowset returned from execution of the query.</param>
        void Execute(ISqlConnection connection, Action<ISqlFieldReader> read);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage each rowset returned from execution of the query.</param>
        void Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IList<TEntity> Execute(Action<ISqlFieldReader, TEntity> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IList<TEntity> Execute(int commandTimeout, Action<ISqlFieldReader, TEntity> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IList<TEntity> Execute(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IList<TEntity> Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        Task<IList<TEntity>> ExecuteAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<TEntity> ExecuteAsyncEnumerable(CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        Task<IList<TEntity>> ExecuteAsync(int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<TEntity> ExecuteAsyncEnumerable(int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        Task<IList<TEntity>> ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<TEntity> ExecuteAsyncEnumerable(ISqlConnection connection, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        Task<IList<TEntity>> ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<TEntity> ExecuteAsyncEnumerable(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="read">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(Action<ISqlFieldReader> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to a <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        Task<IList<TEntity>> ExecuteAsync(Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to a <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<TEntity> ExecuteAsyncEnumerable(Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to a <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        Task<IList<TEntity>> ExecuteAsync(int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to a <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<TEntity> ExecuteAsyncEnumerable(int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to a <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        Task<IList<TEntity>> ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to a <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<TEntity> ExecuteAsyncEnumerable(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to a <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        Task<IList<TEntity>> ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to a <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<TEntity> ExecuteAsyncEnumerable(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="map">A delegate for mapping each rowset to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        Task<IList<TEntity>> ExecuteAsync(Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="map">A delegate for mapping each rowset to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<TEntity> ExecuteAsyncEnumerable(Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for mapping each rowset to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        Task<IList<TEntity>> ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for mapping each rowset to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<TEntity> ExecuteAsyncEnumerable(int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for mapping each rowset to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        Task<IList<TEntity>> ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for mapping each rowset to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<TEntity> ExecuteAsyncEnumerable(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for mapping each rowset to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        Task<IList<TEntity>> ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for mapping each rowset to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<TEntity> ExecuteAsyncEnumerable(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="read">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage each rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task<IList<TEntity>> ExecuteAsync(Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <returns>A list of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<TEntity> ExecuteAsyncEnumerable(Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task<IList<TEntity>> ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<TEntity> ExecuteAsyncEnumerable(int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task<IList<TEntity>> ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<TEntity> ExecuteAsyncEnumerable(ISqlConnection connection, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task<IList<TEntity>> ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to map each rowset to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage each rowset returned from execution of the query.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="TEntity"/> entities retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<TEntity> ExecuteAsyncEnumerable(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken = default);
    }
}
