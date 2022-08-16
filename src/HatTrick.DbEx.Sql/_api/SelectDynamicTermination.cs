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
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectDynamicTermination :
#pragma warning restore IDE1006 // Naming Styles
        IExpressionBuilder,
        ISelectTerminationExpressionBuilder
    {
        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT query.</returns>
        dynamic? Execute();

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT query.</returns>
        dynamic? Execute(int commandTimeout);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT query.</returns>
        dynamic? Execute(ISqlConnection connection);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT query.</returns>
        dynamic? Execute(ISqlConnection connection, int commandTimeout);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and map to a dynamic object using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="map">A delegate for converting the retrieved database values to a dynamic object.</param>
        /// <returns>The dynamic object mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        dynamic? Execute(Func<ISqlFieldReader, dynamic> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and map to a dynamic object using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for converting the retrieved database values to a dynamic object.</param>
        /// <returns>The dynamic object mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        dynamic? Execute(ISqlConnection connection, Func<ISqlFieldReader, dynamic> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and map to a dynamic object using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database values to a dynamic object.</param>
        /// <returns>The dynamic object mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        dynamic? Execute(int commandTimeout, Func<ISqlFieldReader, dynamic> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a record and map to a dynamic object using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database values to a dynamic object.</param>
        /// <returns>The dynamic object mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        dynamic? Execute(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, dynamic> map);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of dynamic objects retrieved from execution of the sql SELECT query.</returns>
        Task<dynamic?> ExecuteAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT query.</returns>
        Task<dynamic?> ExecuteAsync(int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT query.</returns>
        Task<dynamic?> ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a dynamic object.  The member elements of the SELECT clause determine the properties of the dynamic object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt toc execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The dynamic object retrieved from execution of the sql SELECT query.</returns>
        Task<dynamic?> ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        void Execute(Action<ISqlFieldReader> read);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        void Execute(int commandTimeout, Action<ISqlFieldReader> read);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
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
        /// Assemble and execute a SELECT query to retrieve records and map each row from the rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="map">A delegate for converting the retrieved database values to a dynamic object.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/>The value mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        Task ExecuteAsync(Action<ISqlFieldReader> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row from the rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database values to a dynamic object.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/>The value mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        Task ExecuteAsync(int commandTimeout, Action<ISqlFieldReader> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row from the rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/>The value mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        Task ExecuteAsync(ISqlConnection connection, Action<ISqlFieldReader> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row from the rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database values to a dynamic object.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/>The value mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        Task ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<ISqlFieldReader> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row from the rowset to a <typeparamref name="TValue"/> using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="map">A delegate for converting the retrieved database values to a dynamic object.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/>The value mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        Task<dynamic?> ExecuteAsync(Func<ISqlFieldReader, dynamic> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row from the rowset to a dynamic object using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database values to a dynamic object.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/>The value mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        Task<dynamic?> ExecuteAsync(int commandTimeout, Func<ISqlFieldReader, dynamic> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row from the rowset to a dynamic object using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="map">A delegate for converting the retrieved database value to a value of type <typeparamref name="TValue"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/>The value mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        Task<dynamic?> ExecuteAsync(ISqlConnection connection, Func<ISqlFieldReader, dynamic> map, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and map each row from the rowset to a dynamic object using the provided <paramref name="map"/> delegate.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="map">A delegate for converting the retrieved database values to a dynamic object.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The <typeparamref name="TValue"/>The value mapped using the provided <paramref name="map"/> delegate from execution of the sql SELECT query.</returns>
        Task<dynamic?> ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, dynamic> map, CancellationToken cancellationToken = default);

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
        /// <param name="read">The delegate to manage the rowset returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        Task ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<ISqlFieldReader, Task> read, CancellationToken cancellationToken = default);
    }
}
