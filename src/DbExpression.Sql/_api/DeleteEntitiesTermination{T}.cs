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
    public interface DeleteEntitiesTermination<TDatabase> : IDeleteEntitiesTerminationExpressionBuilder<TDatabase>
#pragma warning restore IDE1006 // Naming Styles
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Assemble and execute a DELETE query to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <returns>The number of records removed from the database.</returns>
        int Execute();

        /// <summary>
        /// Assemble and execute a DELETE query to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql DELETE statement and generating an error.</param>
        /// <returns>The number of records removed from the database.</returns>
        int Execute(int commandTimeout);

        /// <summary>
        /// Assemble and execute a DELETE query to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql DELETE statement.</param>
        /// <returns>The number of records removed from the database.</returns>
        int Execute(ISqlConnection connection);

        /// <summary>
        /// Assemble and execute a DELETE query to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql DELETE statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql DELETE statement and generating an error.</param>
        /// <returns>The number of records removed from the database.</returns>
        int Execute(ISqlConnection connection, int commandTimeout);

        /// <summary>
        /// Assemble and execute a DELETE query to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the DELETE statement should be cancelled.</param>
        /// <returns>The number of records removed from the database.</returns>
        ValueTask<int> ExecuteAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a DELETE query to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql DELETE statement.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the DELETE statement should be cancelled.</param>
        /// <returns>The number of records removed from the database.</returns>
        ValueTask<int> ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a DELETE query to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql DELETE statement and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the DELETE statement should be cancelled.</param>
        /// <returns>The number of records removed from the database.</returns>
        ValueTask<int> ExecuteAsync(int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a DELETE query to delete <typeparamref name="TEntity"/> entities and return the number of records removed.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql DELETE statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql DELETE statement and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the DELETE statement should be cancelled.</param>
        /// <returns>The number of records removed from the database.</returns>
        ValueTask<int> ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default);
    }
}
