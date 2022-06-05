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
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectValuesTermination<TDatabase, TValue> :
#pragma warning restore IDE1006 // Naming Styles
        IExpressionBuilder<TDatabase, TValue>,
        ISelectTerminationExpressionBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        IList<TValue> Execute();

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        IList<TValue> Execute(int commandTimeout);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        IList<TValue> Execute(ISqlConnection connection);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        IList<TValue> Execute(ISqlConnection connection, int commandTimeout);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the retrieved value.
        /// </summary>
        /// <param name="read">The delegate to manage the value returned from execution of the query.</param>
        void Execute(Action<TValue?> read);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the retrieved value.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the value returned from execution of the query.</param>
        void Execute(int commandTimeout, Action<TValue?> read);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the retrieved value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the value returned from execution of the query.</param>
        void Execute(ISqlConnection connection, Action<TValue?> read);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the retrieved value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the value returned from execution of the query.</param>
        void Execute(ISqlConnection connection, int commandTimeout, Action<TValue?> read);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        Task<IList<TValue>> ExecuteAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        Task<IList<TValue>> ExecuteAsync(int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        Task<IList<TValue>> ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        Task<IList<TValue>> ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="read">The delegate to manage the value returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        Task ExecuteAsync(Action<TValue?> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the value returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        Task ExecuteAsync(int commandTimeout, Action<TValue?> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage the value returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        Task ExecuteAsync(ISqlConnection connection, Action<TValue?> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the value returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        Task ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<TValue?> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        Task ExecuteAsync(Func<TValue?, Task> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the value returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        Task ExecuteAsync(int commandTimeout, Func<TValue?, Task> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage the value returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        Task ExecuteAsync(ISqlConnection connection, Func<TValue?, Task> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TValue"/> values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the value returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TValue"/> values retrieved from execution of the sql SELECT query.</returns>
        Task ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<TValue?, Task> read, CancellationToken cancellationToken = default);
    }
}
