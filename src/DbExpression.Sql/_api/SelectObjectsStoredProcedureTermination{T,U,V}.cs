﻿#region license
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
using DbExpression.Sql.Executor;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DbExpression.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectObjectsStoredProcedureTermination<TDatabase, TEntity, T> : ITerminationExpressionBuilder<TDatabase>
#pragma warning restore IDE1006 // Naming Styles
        where TDatabase : class, ISqlDatabaseRuntime
        where TEntity : class, StoredProcedure
    {
        Func<ISqlFieldReader, T> Map { get; }

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        IList<T> Execute();

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        IList<T> Execute(ISqlConnection connection);

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        IList<T> Execute(int commandTimeout);

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        IList<T> Execute(ISqlConnection connection, int commandTimeout);

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        Task<IList<T>> ExecuteAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="T"/> values retrieved from execution of the stored procedure.</returns>
        IAsyncEnumerable<T> ExecuteAsyncEnumerable(CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        Task<IList<T>> ExecuteAsync(ISqlConnection connection, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="T"/> values retrieved from execution of the stored procedure.</returns>
        IAsyncEnumerable<T> ExecuteAsyncEnumerable(ISqlConnection connection, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        Task<IList<T>> ExecuteAsync(int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="T"/> values retrieved from execution of the stored procedure.</returns>
        IAsyncEnumerable<T> ExecuteAsyncEnumerable(int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>A list of type <typeparamref name="T"/> returned from execution of the stored procedure.</returns>
        Task<IList<T>> ExecuteAsync(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assemble and execute a stored procedure and return a list of values.
        /// </summary>
        /// <param name="connection">The active database <see cref="ISqlConnection">connection</see> to use for executing the stored procedure.</param>
        /// <param name="commandTimeout">The wait time (in seconds) before terminating the attempt to execute the stored procedure and generating an error.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken">cancellation token</see> to propagate notification that execution of the stored procedure should be cancelled.</param>
        /// <returns>An enumerator providing asynchronous iteration of <typeparamref name="T"/> values retrieved from execution of the stored procedure.</returns>
        IAsyncEnumerable<T> ExecuteAsyncEnumerable(ISqlConnection connection, int commandTimeout, CancellationToken cancellationToken = default);
    }
}
