using HatTrick.DbEx.MsSql.Benchmark.dbExpression.DataService;
using HatTrick.DbEx.MsSql.Benchmark.dbExpression.dboData;
using HatTrick.DbEx.MsSql.Benchmark.dbExpression.dboDataService;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Executor;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.MsSql.Benchmark
{
    public class BenchmarkSqlStatementExecutor : ISqlStatementExecutor
    {
        private readonly IServiceProvider provider;
        private static ISqlRowReader _reader;
        private static IAsyncSqlRowReader _asyncReader;

        private IAsyncSqlRowReader asyncReader => _asyncReader ?? (_asyncReader = new PersonRowReader(new SqlStatementValueConverterProvider(provider.GetRequiredService<IValueConverterFactory>(), (dbo.Person as Table<Person>).BuildInclusiveSelectExpression())));
        private ISqlRowReader reader => _reader ?? (_reader = new PersonRowReader(new SqlStatementValueConverterProvider(provider.GetRequiredService<IValueConverterFactory>(), (dbo.Person as Table<Person>).BuildInclusiveSelectExpression())));

        public BenchmarkSqlStatementExecutor(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public int ExecuteNonQuery(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution)
            => 0;

        public Task<int> ExecuteNonQueryAsync(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution, CancellationToken ct)
            => Task.FromResult(0);

        public ISqlRowReader ExecuteQuery(SqlStatement statement, ISqlConnection connection, IValueConverterProvider provider, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution)
            => reader;

        public Task<IAsyncSqlRowReader> ExecuteQueryAsync(SqlStatement statement, ISqlConnection connection, IValueConverterProvider provider, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution, CancellationToken ct)
            => Task.FromResult(asyncReader);

        public async IAsyncEnumerable<ISqlFieldReader> ExecuteQueryAsyncEnumerable(SqlStatement statement, ISqlConnection connection, IValueConverterProvider provider, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution, [EnumeratorCancellation] CancellationToken ct)
        {
            await foreach (var row in asyncReader.ReadRowAsyncEnumerable(ct))
                yield return row;
        }

        public T ExecuteScalar<T>(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution)
            => default;

        public Task<T> ExecuteScalarAsync<T>(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution, CancellationToken ct)
            => Task.FromResult<T>(default);
    }
}