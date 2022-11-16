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
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectDynamicsStoredProcedureTermination<TDatabase> : IStoredProcedureTermination<TDatabase>
#pragma warning restore IDE1006 // Naming Styles
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a list of dynamic objects.  The properties of each dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <returns>A list of dynamic objects created from the return rowset(s) from execution of the stored procedure.</returns>
        IEnumerable<dynamic> Execute();

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a list of dynamic objects.  The properties of each dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <returns>A list of dynamic objects created from the return rowset(s) from execution of the stored procedure.</returns>
        IEnumerable<dynamic> Execute(ISqlConnection connection);

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a list of dynamic objects.  The properties of each dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <returns>A list of dynamic objects created from the return rowset(s) from execution of the stored procedure.</returns>
        IEnumerable<dynamic> Execute(int commandTimeout);

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a list of dynamic objects.  The properties of each dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <returns>A list of dynamic objects created from the return rowset(s) from execution of the stored procedure.</returns>
        IEnumerable<dynamic> Execute(ISqlConnection connection, int commandTimeout);

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a list of dynamic objects.  The properties of each dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A list of dynamic objects created from the return rowset(s) from execution of the stored procedure.</returns>
        Task<IEnumerable<dynamic>> ExecuteAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a list of dynamic objects.  The properties of each dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of dynamic objects retrieved from execution of the stored procedure.</returns>
        IAsyncEnumerable<dynamic> ExecuteAsyncEnumerable(CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a list of dynamic objects.  The properties of each dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A list of dynamic objects created from the return rowset(s) from execution of the stored procedure.</returns>
        Task<IEnumerable<dynamic>> ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a list of dynamic objects.  The properties of each dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of dynamic objects retrieved from execution of the stored procedure.</returns>
        IAsyncEnumerable<dynamic> ExecuteAsyncEnumerable(ISqlConnection connection, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a list of dynamic objects.  The properties of each dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A list of dynamic objects created from the return rowset(s) from execution of the stored procedure.</returns>
        Task<IEnumerable<dynamic>> ExecuteAsync(int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a list of dynamic objects.  The properties of each dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of dynamic objects retrieved from execution of the stored procedure.</returns>
        IAsyncEnumerable<dynamic> ExecuteAsyncEnumerable(int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a list of dynamic objects.  The properties of each dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A list of dynamic objects created from the return rowset(s) from execution of the stored procedure.</returns>
        Task<IEnumerable<dynamic>> ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a stored procedure and retrieve a list of dynamic objects.  The properties of each dynamic object are defined by the column attributes of the returned rowset.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of dynamic objects retrieved from execution of the stored procedure.</returns>
        IAsyncEnumerable<dynamic> ExecuteAsyncEnumerable(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default);
    }
}
