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
using System.Threading;
using System.Threading.Tasks;

namespace DbExpression.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectObjectTermination<TDatabase, TObject> :
#pragma warning restore IDE1006 // Naming Styles
        IExpressionBuilder<TDatabase, TObject>,
        ISelectTerminationExpressionBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
        where TObject : class?
    {
        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a single <typeparamref name="TObject"/> value.
        /// </summary>
        /// <returns>The single <typeparamref name="TObject"/> value retrieved from execution of the sql SELECT query.</returns>
        TObject? Execute();

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a single <typeparamref name="TObject"/> value.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>The single <typeparamref name="TObject"/> value retrieved from execution of the sql SELECT query.</returns>
        TObject? Execute(int commandTimeout);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a single <typeparamref name="TObject"/> value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <returns>The single <typeparamref name="TObject"/> value retrieved from execution of the sql SELECT query.</returns>
        TObject? Execute(ISqlConnection connection);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a single <typeparamref name="TObject"/> value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <returns>The single <typeparamref name="TObject"/> value retrieved from execution of the sql SELECT query.</returns>
        TObject? Execute(ISqlConnection connection, int commandTimeout);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a single <typeparamref name="TObject"/> value.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The single <typeparamref name="TObject"/> value retrieved from execution of the sql SELECT query.</returns>
        Task<TObject?> ExecuteAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a single <typeparamref name="TObject"/> value.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The single <typeparamref name="TObject"/> value retrieved from execution of the sql SELECT query.</returns>
        Task<TObject?> ExecuteAsync(int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a single <typeparamref name="TObject"/> value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The single <typeparamref name="TObject"/> value retrieved from execution of the sql SELECT query.</returns>
        Task<TObject?> ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a SELECT query to retrieve a single <typeparamref name="TObject"/> value.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql SELECT query.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql SELECT query and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the SELECT statement should be cancelled.</param>
        /// <returns>The single <typeparamref name="TObject"/> value retrieved from execution of the sql SELECT query.</returns>
        Task<TObject?> ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default);
    }
}
