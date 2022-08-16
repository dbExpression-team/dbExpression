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
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface UpdateEntitiesTermination : IUpdateTerminationExpressionBuilder
#pragma warning restore IDE1006 // Naming Styles
    {
        /// <summary>
        /// Assemble and execute a UPDATE query to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <returns>The number of records affected in the database.</returns>
        int Execute();

        /// <summary>
        /// Assemble and execute a UPDATE query to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql UPDATE statement and generating an error.</param>
        /// <returns>The number of records affected in the database.</returns>
        int Execute(int commandTimeout);

        /// <summary>
        /// Assemble and execute a UPDATE query to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql UPDATE statement.</param>
        /// <returns>The number of records affected in the database.</returns>
        int Execute(ISqlConnection connection);

        /// <summary>
        /// Assemble and execute a UPDATE query to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql UPDATE statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql UPDATE statement and generating an error.</param>
        /// <returns>The number of records affected in the database.</returns>
        int Execute(ISqlConnection connection, int commandTimeout);

        /// <summary>
        /// Assemble and execute a UPDATE query to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the UPDATE statement should be cancelled.</param>
        /// <returns>The number of records affected in the database.</returns>
        Task<int> ExecuteAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a UPDATE query to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql UPDATE statement.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the UPDATE statement should be cancelled.</param>
        /// <returns>The number of records affected in the database.</returns>
        Task<int> ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken = default);
        /// <summary>
        /// Assemble and execute a UPDATE query to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql UPDATE statement and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the UPDATE statement should be cancelled.</param>
        /// <returns>The number of records affected in the database.</returns>
        Task<int> ExecuteAsync(int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a UPDATE query to update <typeparamref name="TEntity"/> entities and return the number of records affected.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql UPDATE statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql UPDATE statement and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the UPDATE statement should be cancelled.</param>
        /// <returns>The number of records affected in the database.</returns>
        Task<int> ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default);
    }
}
