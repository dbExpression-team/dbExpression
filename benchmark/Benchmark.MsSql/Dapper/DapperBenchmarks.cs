using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HatTrick.DbEx.MsSql.Benchmark.Dapper
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
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

        [Benchmark(Description = "Select First Record With Join Condition")]
        public Person SelectOneWithJoinsQueryExpression()
        {
            return connection.Query<Person>("select top(1) * from Person inner join Person_Address on Person.Id = Person_Address.Id", buffered: true).First();
        }

        [Benchmark(Description = "Select First Record With Where Clause")]
        public Person SelectOneWithWhereClauseQueryExpression()
        {
            return connection.Query<Person>("select top(1) * from Person where Id = @Id", new { Id = 1 }, buffered: true).First();
        }

        [Benchmark(Description = "Select First Record With Scalar Return")]
        public int SelectOneWithFieldAliasQueryExpression()
        {
            return connection.Query<int>("select top(1) Id from Person where Id = @Id", new { Id = 1 }, buffered: true).First();
        }

        [Benchmark(Description = "Select First Record With Dynamic Return")]
        public dynamic SelectOneDynamicQueryExpression()
        {
            return connection.Query<dynamic>("select top(1) Id, FirstName, LastName from Person where Id = @Id", new { Id = 1 }, buffered: true).First();
        }

        [Benchmark(Description = "Select First Record With Dynamic Return (aliased columns)")]
        public dynamic SelectOneDynamicWithFieldAliasQueryExpression()
        {
            return connection.Query<dynamic>("select top(1) Id as person_Id, FirstName as person_FirstName, LastName as person_LastName from Person where Id = @Id", new { Id = 1 }, buffered: true).First();
        }

        [Benchmark(Description = "Async Select First Record With Entity Return")]
        public async Task<Person> AsyncSelectOneQueryExpression()
        {
            return (await connection.QueryAsync<Person>("select top(1) * from Person")).First();
        }

        [Benchmark(Description = "Async Select First Record With Join Condition With Entity Return")]
        public async Task<Person> AsyncSelectOneWithJoinsQueryExpression()
        {
            return (await connection.QueryAsync<Person>("select top(1) * from Person inner join Person_Address on Person.Id = Person_Address.Id")).First();
        }

        [Benchmark(Description = "Async Select First Record With Where Clause With Entity Return")]
        public async Task<Person> AsyncSelectOneWithWhereClauseQueryExpression()
        {
            return (await connection.QueryAsync<Person>("select top(1) * from Person where Id = @Id", new { Id = 1 })).First();
        }

        [Benchmark(Description = "Async Select First Record With Scalar Return")]
        public async Task<int> AsyncSelectOneWithFieldAliasQueryExpression()
        {
            return (await connection.QueryAsync<int>("select top(1) Id from Person where Id = @Id", new { Id = 1 })).First();
        }

        [Benchmark(Description = "Async Select First Record With Dynamic Return")]
        public async Task<dynamic> AsyncSelectOneDynamicQueryExpression()
        {
            return (await connection.QueryAsync<dynamic>("select top(1) Id, FirstName, LastName from Person")).First();
        }

        [Benchmark(Description = "Async Select First Record With Dynamic Return (aliased columns)")]
        public async Task<dynamic> AsyncSelectOneDynamicWithFieldAliasQueryExpression()
        {
            return (await connection.QueryAsync<dynamic>("select top(1) Id as person_Id, FirstName as person_FirstName, LastName as person_LastName from Person where Id = @Id", new { Id = 1 })).First();
        }
    }
}
