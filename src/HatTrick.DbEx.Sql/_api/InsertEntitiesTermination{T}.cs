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
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface InsertEntitiesTermination<TEntity> : IInsertTerminationExpressionBuilder<TEntity>
#pragma warning restore IDE1006 // Naming Styles
        where TEntity : class, IDbEntity
    {
        /// <summary>
        /// Assemble and execute a INSERT query to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        void Execute();

        /// <summary>
        /// Assemble and execute a INSERT query to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql INSERT statement and generating an error.</param>
        void Execute(int commandTimeout);

        /// <summary>
        /// Assemble and execute a INSERT query to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql INSERT statement.</param>
        void Execute(ISqlConnection connection);

        /// <summary>
        /// Assemble and execute a INSERT query to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql INSERT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql INSERT statement and generating an error.</param>
        void Execute(ISqlConnection connection, int commandTimeout);

        /// <summary>
        /// Assemble and execute a INSERT query to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the INSERT statement should be cancelled.</param>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        Task ExecuteAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a INSERT query to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql INSERT statement.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the INSERT statement should be cancelled.</param>
        Task ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a INSERT query to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql INSERT statement and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the INSERT statement should be cancelled.</param>
        Task ExecuteAsync(int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a INSERT query to insert <typeparamref name="TEntity"/> entities.
        /// </summary>
        /// <remarks>The inserted entities will be hydrated with any values controlled by the database; for example identity columns, computed columns, defaults where a field was ommitted from the statement.</remarks>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the sql INSERT statement.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the sql INSERT statement and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the INSERT statement should be cancelled.</param>
        Task ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default);
    }
}
