using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using HatTrick.DbEx.MsSql.Benchmark.dbExpression.DataService;
using HatTrick.DbEx.MsSql.Benchmark.dbExpression.dboData;
using HatTrick.DbEx.MsSql.Benchmark.dbExpression.dboDataService;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql.Connection;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace HatTrick.DbEx.MsSql.Benchmark
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class dbExpressionBenchmarks : PlatformBenchmarksBase
    {
        private ISqlConnection connection;

        [GlobalSetup]
        public void ConfigureDbExpression()
        {
            Sql.Configuration.dbExpression.Initialize(dbex => dbex.AddMsSql2019Database<BenchmarkDatabase>(db => db.ConnectionString.Use(Constants.ConnectionString)));
            connection = db.GetConnection();
            connection.EnsureOpen();
        }

        [Benchmark(Description = "Select First Record")]
        public Person SelectOneQueryExpression()
        {
            return db.SelectOne<Person>().From(dbo.Person).Execute(connection);
        }

        [Benchmark(Description = "Select First Record With Join Condition")]
        public Person SelectOneWithJoinsQueryExpression()
        {
            return db.SelectOne<Person>().From(dbo.Person).InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId).Execute(connection);
        }

        [Benchmark(Description = "Select First Record With Where Clause")]
        public Person SelectOneWithWhereClauseQueryExpression()
        {
            return db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.Id == 1).Execute(connection);
        }

        [Benchmark(Description = "Select First Record With Scalar Return")]
        public int SelectOneWithFieldAliasQueryExpression()
        {
            return db.SelectOne(dbo.Person.Id).From(dbo.Person).Execute(connection);
        }

        [Benchmark(Description = "Select First Record With Dynamic Return")]
        public dynamic SelectOneDynamicQueryExpression()
        {
            return db.SelectOne(dbo.Person.Id, dbo.Person.FirstName, dbo.Person.LastName).From(dbo.Person).Execute(connection);
        }

        [Benchmark(Description = "Select First Record With Dynamic Return (aliased columns)")]
        public dynamic SelectOneDynamicWithFieldAliasQueryExpression()
        {
            return db.SelectOne(dbo.Person.Id.As("person_Id"), dbo.Person.FirstName.As("person_FirstName"), dbo.Person.LastName.As("person_LastName")).From(dbo.Person).Execute(connection);
        }

        [Benchmark(Description = "Async Select First Record With Entity Return")]
        public async Task<Person> AsyncSelectOneQueryExpression()
        {
            return await db.SelectOne<Person>().From(dbo.Person).ExecuteAsync(connection);
        }

        [Benchmark(Description = "Async Select First Record With Join Condition With Entity Return")]
        public async Task<Person> AsyncSelectOneWithJoinsQueryExpression()
        {
            return await db.SelectOne<Person>().From(dbo.Person).InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId).ExecuteAsync(connection);
        }

        [Benchmark(Description = "Async Select First Record With Where Clause With Entity Return")]
        public async Task<Person> AsyncSelectOneWithWhereClauseQueryExpression()
        {
            return await db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync(connection);
        }

        [Benchmark(Description = "Async Select First Record With Scalar Return")]
        public async Task<int> AsyncSelectOneWithFieldAliasQueryExpression()
        {
            return await db.SelectOne(dbo.Person.Id).From(dbo.Person).ExecuteAsync(connection);
        }

        [Benchmark(Description = "Async Select First Record With Dynamic Return")]
        public async Task<dynamic> AsyncSelectOneDynamicQueryExpression()
        {
            return await db.SelectOne(dbo.Person.Id, dbo.Person.FirstName, dbo.Person.LastName).From(dbo.Person).ExecuteAsync(connection);
        }

        [Benchmark(Description = "Async Select First Record With Dynamic Return (aliased columns)")]
        public async Task<dynamic> AsyncSelectOneDynamicWithFieldAliasQueryExpression()
        {
            return await db.SelectOne(dbo.Person.Id.As("person_Id"), dbo.Person.FirstName.As("person_FirstName"), dbo.Person.LastName.As("person_LastName")).From(dbo.Person).ExecuteAsync(connection);
        }
    }
}