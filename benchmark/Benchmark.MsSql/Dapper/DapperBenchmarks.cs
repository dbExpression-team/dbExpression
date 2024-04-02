using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbExpression.MsSql.Benchmark.Dapper
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.Method)]
    [RankColumn]
    public class DapperBenchmarks : PlatformBenchmarksBase
    {
        private SqlConnection connection;

        [GlobalSetup]
        public void ConfigureDbExpression()
        {
            connection = new SqlConnection(Constants.ConnectionString);
            connection.Open();
        }

        [Benchmark(Description = "Select First Record")]
        public Person SelectOneQueryExpression()
        {
            return connection.Query<Person>("select top(1) * from Person", buffered: true).First();
        }

        [Benchmark(Description = "Select First With Join Condition")]
        public Person SelectOneWithJoinsQueryExpression()
        {
            return connection.Query<Person>("select top(1) * from Person inner join Person_Address on Person.Id = Person_Address.Id", buffered: true).First();
        }

        [Benchmark(Description = "Select First With Where Clause")]
        public Person SelectOneWithWhereClauseQueryExpression()
        {
            return connection.Query<Person>("select top(1) * from Person where Id = @Id", new { Id = 1 }, buffered: true).First();
        }

        [Benchmark(Description = "Select First With Scalar Return")]
        public int SelectOneWithFieldAliasQueryExpression()
        {
            return connection.Query<int>("select top(1) Id from Person where Id = @Id", new { Id = 1 }, buffered: true).First();
        }

        [Benchmark(Description = "Select First With Dynamic Return")]
        public dynamic SelectOneDynamicQueryExpression()
        {
            return connection.Query<dynamic>("select top(1) Id, FirstName, LastName from Person where Id = @Id", new { Id = 1 }, buffered: true).First();
        }

        [Benchmark(Description = "Select First With Dynamic Return (aliased columns)")]
        public dynamic SelectOneDynamicWithFieldAliasQueryExpression()
        {
            return connection.Query<dynamic>("select top(1) Id as person_Id, FirstName as person_FirstName, LastName as person_LastName from Person where Id = @Id", new { Id = 1 }, buffered: true).First();
        }

        [Benchmark(Description = "Select First With Entity Return Async")]
        public async Task<Person> AsyncSelectOneQueryExpression()
        {
            return (await connection.QueryAsync<Person>("select top(1) * from Person")).First();
        }

        [Benchmark(Description = "Select First With Join Condition With Entity Return Async")]
        public async Task<Person> AsyncSelectOneWithJoinsQueryExpression()
        {
            return (await connection.QueryAsync<Person>("select top(1) * from Person inner join Person_Address on Person.Id = Person_Address.Id")).First();
        }

        [Benchmark(Description = "Select First With Where Clause With Entity Return Async")]
        public async Task<Person> AsyncSelectOneWithWhereClauseQueryExpression()
        {
            return (await connection.QueryAsync<Person>("select top(1) * from Person where Id = @Id", new { Id = 1 })).First();
        }

        [Benchmark(Description = "Select First With Scalar Return Async")]
        public async Task<int> AsyncSelectOneWithFieldAliasQueryExpression()
        {
            return (await connection.QueryAsync<int>("select top(1) Id from Person where Id = @Id", new { Id = 1 })).First();
        }

        [Benchmark(Description = "Select First With Dynamic Return Async")]
        public async Task<dynamic> AsyncSelectOneDynamicQueryExpression()
        {
            return (await connection.QueryAsync<dynamic>("select top(1) Id, FirstName, LastName from Person")).First();
        }

        [Benchmark(Description = "Select First With Dynamic Return Async (aliased columns)")]
        public async Task<dynamic> AsyncSelectOneDynamicWithFieldAliasQueryExpression()
        {
            return (await connection.QueryAsync<dynamic>("select top(1) Id as person_Id, FirstName as person_FirstName, LastName as person_LastName from Person where Id = @Id", new { Id = 1 })).First();
        }

        [Benchmark(Description = "Select Top 50")]
        public IList<Person> SelectManyQueryExpression()
        {
            return connection.Query<Person>("select top(50) * from Person", buffered: true).ToList();
        }

        [Benchmark(Description = "Select Top 50 With Join Condition")]
        public IList<Person> SelectManyWithJoinsQueryExpression()
        {
            return connection.Query<Person>("select top(50) * from Person left join Person_Address on Person.Id = Person_Address.Id", buffered: true).ToList();
        }

        [Benchmark(Description = "Select Top 50 With Where Clause")]
        public IList<Person> SelectManyWithWhereClauseQueryExpression()
        {
            return connection.Query<Person>("select top(50) * from Person where Id > @Id", new { Id = 0 }, buffered: true).ToList();
        }

        [Benchmark(Description = "Select Top 50 With Scalar Return")]
        public IList<int> SelectManyWithFieldAliasQueryExpression()
        {
            return connection.Query<int>("select top(50) Id from Person where Id > @Id", new { Id = 0 }, buffered: true).ToList();
        }

        [Benchmark(Description = "Select Top 50 With Dynamic Return")]
        public IList<dynamic> SelectManyDynamicQueryExpression()
        {
            return connection.Query<dynamic>("select top(50) Id, FirstName, LastName from Person where Id > @Id", new { Id = 0 }, buffered: true).ToList();
        }

        [Benchmark(Description = "Select Top 50 With Dynamic Return (aliased columns)")]
        public IList<dynamic> SelectManyDynamicWithFieldAliasQueryExpression()
        {
            return connection.Query<dynamic>("select top(50) Id as person_Id, FirstName as person_FirstName, LastName as person_LastName from Person where Id > @Id", new { Id = 0 }, buffered: true).ToList();
        }

        [Benchmark(Description = "Select Top 50 With Entity Return Async")]
        public async Task<IList<Person>> AsyncSelectManyQueryExpression()
        {
            return (await connection.QueryAsync<Person>("select top(50) * from Person")).ToList();
        }

        [Benchmark(Description = "Select Top 50 With Join Condition With Entity Return Async")]
        public async Task<IList<Person>> AsyncSelectManyWithJoinsQueryExpression()
        {
            return (await connection.QueryAsync<Person>("select top(50) * from Person left join Person_Address on Person.Id = Person_Address.Id")).ToList();
        }

        [Benchmark(Description = "Select Top 50 With Where Clause With Entity Return Async")]
        public async Task<IList<Person>> AsyncSelectManyWithWhereClauseQueryExpression()
        {
            return (await connection.QueryAsync<Person>("select top(50) * from Person where Id > @Id", new { Id = 0 })).ToList();
        }

        [Benchmark(Description = "Select Top 50 With Scalar Return Async")]
        public async Task<IList<int>> AsyncSelectManyWithFieldAliasQueryExpression()
        {
            return (await connection.QueryAsync<int>("select top(50) Id from Person where Id > @Id", new { Id = 0 })).ToList();
        }

        [Benchmark(Description = "Select Top 50 With Dynamic Return Async")]
        public async Task<IList<dynamic>> AsyncSelectManyDynamicQueryExpression()
        {
            return (await connection.QueryAsync<dynamic>("select top(50) Id, FirstName, LastName from Person")).ToList();
        }

        [Benchmark(Description = "Select Top 50 With Dynamic Return Async (aliased columns)")]
        public async Task<IList<dynamic>> AsyncSelectManyDynamicWithFieldAliasQueryExpression()
        {
            return (await connection.QueryAsync<dynamic>("select top(50) Id as person_Id, FirstName as person_FirstName, LastName as person_LastName from Person where Id > @Id", new { Id = 0 })).ToList();
        }
    }
}
