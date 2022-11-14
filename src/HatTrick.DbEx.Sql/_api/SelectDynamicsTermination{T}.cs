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

using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectDynamicsTermination<TDatabase> :
#pragma warning restore IDE1006 // Naming Styles
        IExpressionBuilder<TDatabase>,
        ISelectTerminationExpressionBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <returns>A list of dynamic objects retrieved from execution of the sql SELECT query.</returns>
        IEnumerable<dynamic> Execute();

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>A list of dynamic objects retrieved from execution of the sql SELECT query.</returns>
        IEnumerable<dynamic> Execute(int commandTimeout);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <returns>A list of dynamic objects retrieved from execution of the sql SELECT query.</returns>
        IEnumerable<dynamic> Execute(ISqlConnection connection);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>A list of dynamic objects retrieved from execution of the sql SELECT query.</returns>
        IEnumerable<dynamic> Execute(ISqlConnection connection, int commandTimeout);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of dynamic objects retrieved from execution of the sql SELECT query.</returns>
        Task<IEnumerable<dynamic>> ExecuteAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of dynamic objects retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<dynamic> ExecuteAsyncEnumerable(CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of dynamic objects retrieved from execution of the sql SELECT query.</returns>
        Task<IEnumerable<dynamic>> ExecuteAsync(int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of dynamic objects retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<dynamic> ExecuteAsyncEnumerable(int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of dynamic objects retrieved from execution of the sql SELECT query.</returns>
        Task<IEnumerable<dynamic>> ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of dynamic objects retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<dynamic> ExecuteAsyncEnumerable(ISqlConnection connection, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of dynamic objects retrieved from execution of the sql SELECT query.</returns>
        Task<IEnumerable<dynamic>> ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of dynamic objects.  The member elements of the SELECT clause determine the properties of each returned dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of dynamic objects retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<dynamic> ExecuteAsyncEnumerable(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="dynamic"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="dynamic"/>.</param>
        /// <returns>A list of <typeparamref name="T"/> values retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        IEnumerable<T> Execute<T>(Func<ISqlFieldReader, T> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="dynamic"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="dynamic"/>.</param>
        /// <returns>A list of <typeparamref name="T"/> values retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        IEnumerable<T> Execute<T>(int commandTimeout, Func<ISqlFieldReader, T> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="dynamic"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="dynamic"/>.</param>
        /// <returns>A list of <typeparamref name="T"/> values retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        IEnumerable<T> Execute<T>(ISqlConnection connection, Func<ISqlFieldReader, T> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="dynamic"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="dynamic"/>.</param>
        /// <returns>A list of <typeparamref name="T"/> values retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        IEnumerable<T> Execute<T>(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, T> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        void Execute(Action<ISqlFieldReader> read);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="map"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        void Execute(int commandTimeout, Action<ISqlFieldReader> read);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        void Execute(ISqlConnection connection, Action<ISqlFieldReader> read);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        void Execute(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="dynamic"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="dynamic"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="T"/> values retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        Task<IEnumerable<T>> ExecuteAsync<T>(Func<ISqlFieldReader, T> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="dynamic"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="dynamic"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="T"/> values retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<T> ExecuteAsyncEnumerable<T>(Func<ISqlFieldReader, T> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="dynamic"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="dynamic"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="T"/> values retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        Task<IEnumerable<T>> ExecuteAsync<T>(int commandTimeout, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="dynamic"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="dynamic"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="T"/> values retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<T> ExecuteAsyncEnumerable<T>(int commandTimeout, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="dynamic"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="dynamic"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="T"/> values retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        Task<IEnumerable<T>> ExecuteAsync<T>(ISqlConnection connection, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="dynamic"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="dynamic"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="T"/> values retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<T> ExecuteAsyncEnumerable<T>(ISqlConnection connection, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="dynamic"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="dynamic"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="T"/> values retrieved from execution of the sql SELECT query and mapped using the provided <paramref name="map"/> delegate.</returns>
        Task<IEnumerable<T>> ExecuteAsync<T>(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row of the returned rowset to a <typeparamref name="dynamic"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="dynamic"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="T"/> values retrieved from execution of the sql SELECT query.</returns>
        IAsyncEnumerable<T> ExecuteAsyncEnumerable<T>(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, T> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(Action<ISqlFieldReader> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> map, CancellationToken cancellationToken = default);
    }
}
