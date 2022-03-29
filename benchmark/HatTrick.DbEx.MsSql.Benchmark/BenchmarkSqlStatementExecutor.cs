using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.MsSql.Benchmark
{
    public class BenchmarkSqlStatementExecutor : ISqlStatementExecutor
    {
        private readonly RuntimeSqlDatabaseConfiguration config;
        private static ISqlRowReader _reader;
        private static IAsyncSqlRowReader _asyncReader;

        private IAsyncSqlRowReader asyncReader => _asyncReader ?? (_asyncReader = new PersonRowReader(new SqlStatementValueConverterProvider(config.ValueConverterFactory)));
        private ISqlRowReader reader => _reader ?? (_reader = new PersonRowReader(new SqlStatementValueConverterProvider(config.ValueConverterFactory)));

        public BenchmarkSqlStatementExecutor(RuntimeSqlDatabaseConfiguration config)
        {
            this.config = config;
        }

        public int ExecuteNonQuery(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution)
            => 0;

        public Task<int> ExecuteNonQueryAsync(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution, CancellationToken ct)
            => Task.FromResult(0);

        public ISqlRowReader ExecuteQuery(SqlStatement statement, ISqlConnection connection, IValueConverterProvider finder, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution)
            => reader;

        public Task<IAsyncSqlRowReader> ExecuteQueryAsync(SqlStatement statement, ISqlConnection connection, IValueConverterProvider finder, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution, CancellationToken ct)
            => Task.FromResult(asyncReader);

        public T ExecuteScalar<T>(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution)
            => default;

        public Task<T> ExecuteScalarAsync<T>(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution, CancellationToken ct)
            => Task.FromResult<T>(default);
    }
}