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
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectEntityTermination<TEntity> : ISelectTerminationExpressionBuilder
        where TEntity : class, IDbEntity, new()
#pragma warning restore IDE1006 // Naming Styles
    {
        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        TEntity? Execute();

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        TEntity? Execute(int commandTimeout);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        TEntity? Execute(ISqlConnection connection);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        TEntity? Execute(ISqlConnection connection, int commandTimeout);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and map the returned rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="map">A delegate for mapping the rowset values to a <typeparamref name="TEntity"/> entity.</param>
        /// <returns>A <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        TEntity? Execute(Func<ISqlFieldReader, TEntity> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and map the returned rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for mapping the rowset values to a <typeparamref name="TEntity"/> entity.</param>
        /// <returns>A <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        TEntity? Execute(int commandTimeout, Func<ISqlFieldReader, TEntity> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a a record and map the returned rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for mapping the rowset values to a <typeparamref name="TEntity"/> entity.</param>
        /// <returns>A <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        TEntity? Execute(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and map the returned rowset to a <typeparamref name="TEntity"/> entity using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for mapping the rowset values to a <typeparamref name="TEntity"/> entity.</param>
        /// <returns>A <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        TEntity? Execute(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        void Execute(Action<ISqlFieldReader> read);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        void Execute(int commandTimeout, Action<ISqlFieldReader> read);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        void Execute(ISqlConnection connection, Action<ISqlFieldReader> read);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        void Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="map">The delegate to manage the rowset returned from execution of the query.</param>
        /// <returns>A <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        TEntity? Execute(Action<ISqlFieldReader, TEntity> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage the rowset returned from execution of the query.</param>
        /// <returns>A <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        TEntity? Execute(int commandTimeout, Action<ISqlFieldReader, TEntity> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">The delegate to manage the rowset returned from execution of the query.</param>
        /// <returns>A <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        TEntity? Execute(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage the rowset returned from execution of the query.</param>
        /// <returns>A <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        TEntity? Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        Task<TEntity?> ExecuteAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        Task<TEntity?> ExecuteAsync(int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        Task<TEntity?> ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        Task<TEntity?> ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="map">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(Action<ISqlFieldReader> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="map">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        Task<TEntity?> ExecuteAsync(Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        Task<TEntity?> ExecuteAsync(int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        Task<TEntity?> ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity retrieved from execution of the sql SELECT query.</returns>
        Task<TEntity?> ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="map">A delegate for converting the retrieved database value to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity mapped using the provided <paramref name="map"/> delegate.</returns>
        Task<TEntity?> ExecuteAsync(Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity mapped using the provided <paramref name="map"/> delegate.</returns>
        Task<TEntity?> ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity mapped using the provided <paramref name="map"/> delegate.</returns>
        Task<TEntity?> ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity mapped using the provided <paramref name="map"/> delegate.</returns>
        Task<TEntity?> ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default);
        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="map">A delegate for converting the retrieved database value to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity mapped using the provided <paramref name="map"/> delegate.</returns>
        Task<TEntity?> ExecuteAsync(Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity mapped using the provided <paramref name="map"/> delegate.</returns>
        Task<TEntity?> ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity mapped using the provided <paramref name="map"/> delegate.</returns>
        Task<TEntity?> ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and use the <paramref name="map"/> delegate to map to an <typeparamref name="TEntity"/> entity instance created from the configured <see cref="IEntityFactory"> entity factory</see>.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a <typeparamref name="TEntity"/> entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TEntity"/> entity mapped using the provided <paramref name="map"/> delegate.</returns>
        Task<TEntity?> ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, TEntity, Task> map, CancellationToken cancellationToken = default);
    }
}
