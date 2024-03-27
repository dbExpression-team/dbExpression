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

using DbExpression.Sql.Builder;
using DbExpression.Sql.Connection;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DbExpression.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectObjectsTermination<TDatabase, TObject> :
#pragma warning restore IDE1006 // Naming Styles
        IExpressionBuilder<TDatabase, TObject>,
        ISelectTerminationExpressionBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TObject"/> Objects.
        /// </summary>
        /// <returns>A list of <typeparamref name="TObject"/> Objects retrieved from execution of the sql SELECT query.</returns>
        IList<TObject> Execute();

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TObject"/> Objects.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>A list of <typeparamref name="TObject"/> Objects retrieved from execution of the sql SELECT query.</returns>
        IList<TObject> Execute(int commandTimeout);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TObject"/> Objects.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <returns>A list of <typeparamref name="TObject"/> Objects retrieved from execution of the sql SELECT query.</returns>
        IList<TObject> Execute(ISqlConnection connection);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TObject"/> Objects.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>A list of <typeparamref name="TObject"/> Objects retrieved from execution of the sql SELECT query.</returns>
        IList<TObject> Execute(ISqlConnection connection, int commandTimeout);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the retrieved Object.
        /// </summary>
        /// <param name="read">The delegate to manage the Object returned from execution of the query.</param>
        void Execute(Action<TObject?> read);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the retrieved Object.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the Object returned from execution of the query.</param>
        void Execute(int commandTimeout, Action<TObject?> read);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the retrieved Object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage the Object returned from execution of the query.</param>
        void Execute(ISqlConnection connection, Action<TObject?> read);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve records and use the <paramref name="read"/> delegate to manage the retrieved Object.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the Object returned from execution of the query.</param>
        void Execute(ISqlConnection connection, int commandTimeout, Action<TObject?> read);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TObject"/> Objects.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TObject"/> Objects retrieved from execution of the sql SELECT query.</returns>
        Task<IList<TObject>> ExecuteAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TObject"/> Objects.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TObject"/> Objects retrieved from execution of the sql SELECT query.</returns>
        Task<IList<TObject>> ExecuteAsync(int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TObject"/> Objects.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TObject"/> Objects retrieved from execution of the sql SELECT query.</returns>
        Task<IList<TObject>> ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TObject"/> Objects.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TObject"/> Objects retrieved from execution of the sql SELECT query.</returns>
        Task<IList<TObject>> ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TObject"/> Objects.
        /// </summary>
        /// <param name="read">The delegate to manage the Object returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TObject"/> Objects retrieved from execution of the sql SELECT query.</returns>
        Task ExecuteAsync(Action<TObject?> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TObject"/> Objects.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the Object returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TObject"/> Objects retrieved from execution of the sql SELECT query.</returns>
        Task ExecuteAsync(int commandTimeout, Action<TObject?> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TObject"/> Objects.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage the Object returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TObject"/> Objects retrieved from execution of the sql SELECT query.</returns>
        Task ExecuteAsync(ISqlConnection connection, Action<TObject?> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TObject"/> Objects.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the Object returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TObject"/> Objects retrieved from execution of the sql SELECT query.</returns>
        Task ExecuteAsync(ISqlConnection connection, int commandTimeout, Action<TObject?> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TObject"/> Objects.
        /// </summary>
        /// <param name="read">The delegate to manage the Object returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TObject"/> Objects retrieved from execution of the sql SELECT query.</returns>
        Task ExecuteAsync(Func<TObject?, Task> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TObject"/> Objects.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the Object returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TObject"/> Objects retrieved from execution of the sql SELECT query.</returns>
        Task ExecuteAsync(int commandTimeout, Func<TObject?, Task> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TObject"/> Objects.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="read">The delegate to manage the Object returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TObject"/> Objects retrieved from execution of the sql SELECT query.</returns>
        Task ExecuteAsync(ISqlConnection connection, Func<TObject?, Task> read, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a list of <typeparamref name="TObject"/> Objects.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="read">The delegate to manage the Object returned from execution of the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>A list of <typeparamref name="TObject"/> Objects retrieved from execution of the sql SELECT query.</returns>
        Task ExecuteAsync(ISqlConnection connection, int commandTimeout, Func<TObject?, Task> read, CancellationToken cancellationToken = default);
    }
}
