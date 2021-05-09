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

﻿using HatTrick.DbEx.Sql.Connection;
using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Executor
{
    public class SqlStatementExecutor : ISqlStatementExecutor
    {
        public virtual int ExecuteNonQuery(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution)
        {
            int @return = 0;
            using (IDbCommand cmd = connection.CreateCommand())
            {
                cmd.Connection = connection.DbConnection;
                cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
                (cmd.Parameters as DbParameterCollection).AddRange(statement.Parameters.Select(x => x.Parameter).ToArray());

                beforeExecution?.Invoke(cmd);
                connection.EnsureOpen();
                @return = cmd.ExecuteNonQuery();
                afterExecution?.Invoke(cmd);
            }
            return @return;
        }

        public virtual async Task<int> ExecuteNonQueryAsync(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution, CancellationToken ct)
        {
            int @return = 0;
            using (IDbCommand cmd = connection.CreateCommand())
            {
                cmd.Connection = connection.DbConnection;
                cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
                (cmd.Parameters as DbParameterCollection).AddRange(statement.Parameters.Select(x => x.Parameter).ToArray());

                beforeExecution?.Invoke(cmd);
                ct.ThrowIfCancellationRequested();
                await connection.EnsureOpenAsync(ct).ConfigureAwait(false);
                @return = await (cmd as DbCommand).ExecuteNonQueryAsync(ct).ConfigureAwait(false);
                afterExecution?.Invoke(cmd);
                ct.ThrowIfCancellationRequested();
            }
            return @return;
        }

        public virtual ISqlRowReader ExecuteQuery(SqlStatement statement, ISqlConnection connection, IValueConverterProvider finder, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution)
        {
            using (IDbCommand cmd = connection.CreateCommand())
            {
                cmd.Connection = connection.DbConnection;
                cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
                (cmd.Parameters as DbParameterCollection).AddRange(statement.Parameters.Select(x => x.Parameter).ToArray());

                beforeExecution?.Invoke(cmd);
                connection.EnsureOpen();
                var reader = cmd.ExecuteReader();
                afterExecution?.Invoke(cmd);
                return new DataReaderWrapper(connection, reader, finder);
            }
        }

        public virtual async Task<IAsyncSqlRowReader> ExecuteQueryAsync(SqlStatement statement, ISqlConnection connection, IValueConverterProvider finder, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution, CancellationToken ct)
        {
            using (IDbCommand cmd = connection.CreateCommand())
            {
                cmd.Connection = connection.DbConnection;
                cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
                (cmd.Parameters as DbParameterCollection).AddRange(statement.Parameters.Select(x => x.Parameter).ToArray());

                beforeExecution?.Invoke(cmd);
                ct.ThrowIfCancellationRequested();
                await connection.EnsureOpenAsync(ct).ConfigureAwait(false);
                var reader = await (cmd as DbCommand).ExecuteReaderAsync(ct).ConfigureAwait(false);
                afterExecution?.Invoke(cmd);
                ct.ThrowIfCancellationRequested();
                return new AsyncDataReaderWrapper(connection, reader, finder, ct);
            }
        }

        public virtual T ExecuteScalar<T>(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution)
        {
            object output = null;
            using (IDbCommand cmd = connection.CreateCommand())
            {
                cmd.Connection = connection.DbConnection;
                cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
                (cmd.Parameters as DbParameterCollection).AddRange(statement.Parameters.Select(x => x.Parameter).ToArray());

                beforeExecution?.Invoke(cmd);
                connection.EnsureOpen();
                output = cmd.ExecuteScalar();
                afterExecution?.Invoke(cmd);
            }
            return (T)Convert.ChangeType(output, typeof(T));
        }

        public virtual async Task<T> ExecuteScalarAsync<T>(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution, CancellationToken ct)
        {
            object output = null;
            using (IDbCommand cmd = connection.CreateCommand())
            {
                cmd.Connection = connection.DbConnection;
                cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                cmd.CommandText = statement.CommandTextWriter.Write(";").ToString();
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                cmd.CommandType = (statement.CommandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
                (cmd.Parameters as DbParameterCollection).AddRange(statement.Parameters.Select(x => x.Parameter).ToArray());

                beforeExecution?.Invoke(cmd);
                ct.ThrowIfCancellationRequested();
                connection.EnsureOpen();
                output = await (cmd as DbCommand).ExecuteScalarAsync(ct).ConfigureAwait(false);
                afterExecution?.Invoke(cmd);
                ct.ThrowIfCancellationRequested();
            }
            return (T)Convert.ChangeType(output, typeof(T));
        }
    }
}
