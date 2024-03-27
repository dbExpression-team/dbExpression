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

using DbExpression.Sql.Configuration;
using DbExpression.Sql.Connection;
using DbExpression.Sql.Expression;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace DbExpression.Sql.Executor
{
    public class SqlStatementExecutor : ISqlStatementExecutor
    {
        private readonly ILogger<SqlStatementExecutor> logger;
        private readonly LoggingOptions loggingOptions;

        public SqlStatementExecutor(ILogger<SqlStatementExecutor> logger, LoggingOptions loggingOptions)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.loggingOptions = loggingOptions ?? throw new ArgumentNullException(nameof(loggingOptions));
        }

        public virtual int ExecuteNonQuery(SqlStatement statement, ISqlConnection connection, Action<IDbCommand>? beforeExecution, Action<IDbCommand>? afterExecution)
        {
            int @return = 0;

            if (statement is null)
                throw new ArgumentNullException(nameof(statement));

            if (connection is null)
                throw new ArgumentNullException(nameof(connection));

            using IDbCommand cmd = connection.CreateCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
            cmd.CommandType = CommandType.Text;
            foreach (var parameter in statement.Parameters.Select(x => x.Parameter))
                cmd.Parameters.Add(parameter);

            beforeExecution?.Invoke(cmd);

            if (string.IsNullOrWhiteSpace(cmd.CommandText))
                cmd.CommandText = statement.CommandTextWriter.ToString();

            if (logger.IsEnabled(LogLevel.Debug))
                logger.LogDebug($"Executing query:{System.Environment.NewLine}{{query}}{System.Environment.NewLine}{{parameters}}", cmd.CommandText, ConvertParametersForLogging(statement.Parameters));
            connection.EnsureOpen();
            @return = cmd.ExecuteNonQuery();
            afterExecution?.Invoke(cmd);

            return @return;
        }

        public virtual async Task<int> ExecuteNonQueryAsync(SqlStatement statement, ISqlConnection connection, Action<IDbCommand>? beforeExecution, Action<IDbCommand>? afterExecution, CancellationToken ct)
        {
            int @return = 0;

            if (statement is null)
                throw new ArgumentNullException(nameof(statement));

            if (connection is null)
                throw new ArgumentNullException(nameof(connection));

            using IDbCommand cmd = connection.CreateCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
            cmd.CommandText = statement.CommandTextWriter.ToString();
            cmd.CommandType = CommandType.Text;
            foreach (var parameter in statement.Parameters.Select(x => x.Parameter))
                cmd.Parameters.Add(parameter);

            beforeExecution?.Invoke(cmd);
            ct.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(cmd.CommandText))
                cmd.CommandText = statement.CommandTextWriter.ToString();

            if (logger.IsEnabled(LogLevel.Debug))
                logger.LogDebug($"Executing query:{System.Environment.NewLine}{{query}}{System.Environment.NewLine}{{parameters}}", cmd.CommandText, ConvertParametersForLogging(statement.Parameters));
            await connection.EnsureOpenAsync(ct).ConfigureAwait(false);
            @return = cmd is DbCommand dbCommand ? await dbCommand.ExecuteNonQueryAsync(ct).ConfigureAwait(false) 
                : DbExpressionQueryException.ThrowWrongDbCommandTypeWithReturn<int>(statement.QueryExpression, cmd.GetType(), typeof(DbCommand));

            afterExecution?.Invoke(cmd);
            ct.ThrowIfCancellationRequested();
            return @return;
        }

        public virtual ISqlRowReader ExecuteQuery(SqlStatement statement, ISqlConnection connection, IValueConverterProvider provider, Action<IDbCommand>? beforeExecution, Action<IDbCommand>? afterExecution)
        {
            if (statement is null)
                throw new ArgumentNullException(nameof(statement));

            if (connection is null)
                throw new ArgumentNullException(nameof(connection));

            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            using IDbCommand cmd = connection.CreateCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
            cmd.CommandType = CommandType.Text;
            foreach (var parameter in statement.Parameters.Select(x => x.Parameter))
                cmd.Parameters.Add(parameter);

            beforeExecution?.Invoke(cmd);

            if (string.IsNullOrWhiteSpace(cmd.CommandText))
                cmd.CommandText = statement.CommandTextWriter.ToString();

            if (logger.IsEnabled(LogLevel.Debug))
                logger.LogDebug($"Executing query:{System.Environment.NewLine}{{query}}{System.Environment.NewLine}{{parameters}}", cmd.CommandText, ConvertParametersForLogging(statement.Parameters));
            connection.EnsureOpen();
            var reader = cmd.ExecuteReader();
            afterExecution?.Invoke(cmd);
            return new DataReaderWrapper(connection, reader, provider);
        }

        public virtual async Task<IAsyncSqlRowReader> ExecuteQueryAsync(SqlStatement statement, ISqlConnection connection, IValueConverterProvider provider, Action<IDbCommand>? beforeExecution, Action<IDbCommand>? afterExecution, CancellationToken ct)
        {
            if (statement is null)
                throw new ArgumentNullException(nameof(statement));

            if (connection is null)
                throw new ArgumentNullException(nameof(connection));

            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            using IDbCommand cmd = connection.CreateCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
            cmd.CommandText = statement.CommandTextWriter.ToString();
            cmd.CommandType = CommandType.Text;
            foreach (var parameter in statement.Parameters.Select(x => x.Parameter))
                cmd.Parameters.Add(parameter);

            beforeExecution?.Invoke(cmd);
            ct.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(cmd.CommandText))
                cmd.CommandText = statement.CommandTextWriter.ToString();

            if (logger.IsEnabled(LogLevel.Debug))
                logger.LogDebug($"Executing query:{System.Environment.NewLine}{{query}}{System.Environment.NewLine}{{parameters}}", cmd.CommandText, ConvertParametersForLogging(statement.Parameters));
            await connection.EnsureOpenAsync(ct).ConfigureAwait(false);
            var reader = cmd is DbCommand dbCommand ? await dbCommand.ExecuteReaderAsync(ct).ConfigureAwait(false)
                : DbExpressionQueryException.ThrowWrongDbCommandTypeWithReturn<DbDataReader>(statement.QueryExpression, cmd.GetType(), typeof(DbCommand));

            afterExecution?.Invoke(cmd);
            ct.ThrowIfCancellationRequested();
            return new AsyncDataReaderWrapper(connection, reader, provider, ct);
        }

        public virtual async IAsyncEnumerable<ISqlFieldReader> ExecuteQueryAsyncEnumerable(SqlStatement statement, ISqlConnection connection, IValueConverterProvider provider, Action<IDbCommand>? beforeExecution, Action<IDbCommand>? afterExecution, [EnumeratorCancellation] CancellationToken ct)
        {
            if (statement is null)
                throw new ArgumentNullException(nameof(statement));

            if (connection is null)
                throw new ArgumentNullException(nameof(connection));

            if (provider is null)
                throw new ArgumentNullException(nameof(provider));

            using IDbCommand cmd = connection.CreateCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
            cmd.CommandText = statement.CommandTextWriter.ToString();
            cmd.CommandType = CommandType.Text;
            foreach (var parameter in statement.Parameters.Select(x => x.Parameter))
                cmd.Parameters.Add(parameter);

            beforeExecution?.Invoke(cmd);
            ct.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(cmd.CommandText))
                cmd.CommandText = statement.CommandTextWriter.ToString();

            if (logger.IsEnabled(LogLevel.Debug))
                logger.LogDebug($"Executing query:{System.Environment.NewLine}{{query}}{System.Environment.NewLine}{{parameters}}", cmd.CommandText, ConvertParametersForLogging(statement.Parameters));
            await connection.EnsureOpenAsync(ct).ConfigureAwait(false);
            var reader = cmd is DbCommand dbCommand ? await dbCommand.ExecuteReaderAsync(ct).ConfigureAwait(false)
                : DbExpressionQueryException.ThrowWrongDbCommandTypeWithReturn<DbDataReader>(statement.QueryExpression, cmd.GetType(), typeof(DbCommand));

            afterExecution?.Invoke(cmd);
            ct.ThrowIfCancellationRequested();
            await foreach (var row in (new AsyncDataReaderWrapper(connection, reader, provider)).ReadRowAsyncEnumerable(ct))
                yield return row;
        }

        public virtual T? ExecuteScalar<T>(SqlStatement statement, ISqlConnection connection, Action<IDbCommand>? beforeExecution, Action<IDbCommand>? afterExecution)
        {
            if (statement is null)
                throw new ArgumentNullException(nameof(statement));

            if (connection is null)
                throw new ArgumentNullException(nameof(connection));

            using IDbCommand cmd = connection.CreateCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
            cmd.CommandType = CommandType.Text;
            foreach (var parameter in statement.Parameters.Select(x => x.Parameter))
                cmd.Parameters.Add(parameter);

            beforeExecution?.Invoke(cmd);

            if (string.IsNullOrWhiteSpace(cmd.CommandText))
                cmd.CommandText = statement.CommandTextWriter.ToString();

            if (logger.IsEnabled(LogLevel.Debug))
                logger.LogDebug($"Executing query:{System.Environment.NewLine}{{query}}{System.Environment.NewLine}{{parameters}}", cmd.CommandText, ConvertParametersForLogging(statement.Parameters));
            connection.EnsureOpen();
            var output = cmd.ExecuteScalar();
            afterExecution?.Invoke(cmd);

            if (output is null)
                return default;

            return (T)Convert.ChangeType(output, typeof(T));
        }

        public virtual async Task<T?> ExecuteScalarAsync<T>(SqlStatement statement, ISqlConnection connection, Action<IDbCommand>? beforeExecution, Action<IDbCommand>? afterExecution, CancellationToken ct)
        {
            using IDbCommand cmd = connection.CreateCommand();
            cmd.Connection = connection.DbConnection;
            cmd.Transaction = connection.IsTransactional ? connection.DbTransaction : null;
            cmd.CommandText = statement.CommandTextWriter.ToString();
            cmd.CommandType = CommandType.Text;
            foreach (var parameter in statement.Parameters.Select(x => x.Parameter))
                cmd.Parameters.Add(parameter);

            beforeExecution?.Invoke(cmd);
            ct.ThrowIfCancellationRequested();
            if (logger.IsEnabled(LogLevel.Debug))
                logger.LogDebug($"Executing query:{System.Environment.NewLine}{{query}}{System.Environment.NewLine}{{parameters}}", cmd.CommandText, ConvertParametersForLogging(statement.Parameters));
            connection.EnsureOpen();
            var output = cmd is DbCommand dbCommand ? await dbCommand.ExecuteScalarAsync(ct).ConfigureAwait(false)
                : DbExpressionQueryException.ThrowWrongDbCommandTypeWithReturn<object?>(statement.QueryExpression, cmd.GetType(), typeof(DbCommand));
            afterExecution?.Invoke(cmd);
            ct.ThrowIfCancellationRequested();

            if (output is null)
                return default;

            return (T)Convert.ChangeType(output, typeof(T));
        }

        private IEnumerable<string> ConvertParametersForLogging(IList<ParameterizedExpression> parameters)
        {
            if (!loggingOptions.LogParameterValues)
                return Enumerable.Empty<string>();
            return parameters.Select(p => $"{p.Parameter.ParameterName}={p.Parameter.Value}");
        }
    }
}
