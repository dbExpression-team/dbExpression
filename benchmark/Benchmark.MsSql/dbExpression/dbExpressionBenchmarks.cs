using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using DbExpression.MsSql.Benchmark.dbExpression.DataService;
using DbExpression.MsSql.Benchmark.dbExpression.dboData;
using DbExpression.MsSql.Benchmark.dbExpression.dboDataService;
using DbExpression.MsSql.Configuration;
using DbExpression.Sql;
using DbExpression.Sql.Assembler;
using DbExpression.Sql.Connection;
using DbExpression.Sql.Mapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbExpression.MsSql.Benchmark
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.Method)]
    [RankColumn]
    public class dbExpressionBenchmarks : PlatformBenchmarksBase
    {
        private ISqlConnection connection;

        [GlobalSetup]
        public void ConfigureDbExpression()
        {
            var services = new ServiceCollection();
            services.AddDbExpression(dbex =>
            {
                dbex.AddDatabase<BenchmarkDatabase>(database => database.ConnectionString.Use(Constants.ConnectionString));
            });
            var provider = services.BuildServiceProvider();
            provider.UseStaticRuntimeFor<BenchmarkDatabase>();

			//"pre-fetch" an entity so first creation isn't measured
            provider.GetServiceProviderFor<BenchmarkDatabase>().GetRequiredService<IEntityFactory>().CreateEntity<Person>();

            connection = db.GetConnection();
            connection.EnsureOpen();
        }

        [Benchmark(Description = "Select First Record")]
        public Person SelectOneQueryExpression()
        {
            return db.SelectOne<Person>().From(dbo.Person).Execute(connection);
        }

        [Benchmark(Description = "Select First With Join Condition")]
        public Person SelectOneWithJoinsQueryExpression()
        {
            return db.SelectOne<Person>().From(dbo.Person).InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId).Execute(connection);
        }

        [Benchmark(Description = "Select First With Where Clause")]
        public Person SelectOneWithWhereClauseQueryExpression()
        {
            return db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.Id == 1).Execute(connection);
        }

        [Benchmark(Description = "Select First With Scalar Return")]
        public int SelectOneWithFieldAliasQueryExpression()
        {
            return db.SelectOne(dbo.Person.Id).From(dbo.Person).Execute(connection);
        }

        [Benchmark(Description = "Select First With Dynamic Return")]
        public dynamic SelectOneDynamicQueryExpressionBaseline()
        {
            return db.SelectOne(dbo.Person.Id, dbo.Person.FirstName, dbo.Person.LastName).From(dbo.Person).Execute(connection);
        }

        [Benchmark(Description = "Select First With Dynamic Return (aliased columns)")]
        public dynamic SelectOneDynamicWithFieldAliasQueryExpression()
        {
            return db.SelectOne(dbo.Person.Id.As("person_Id"), dbo.Person.FirstName.As("person_FirstName"), dbo.Person.LastName.As("person_LastName")).From(dbo.Person).Execute(connection);
        }

        [Benchmark(Description = "Select First With Entity Return Async")]
        public async Task<Person> AsyncSelectOneQueryExpression()
        {
            return await db.SelectOne<Person>().From(dbo.Person).ExecuteAsync(connection);
        }

        [Benchmark(Description = "Select First With Join Condition With Entity Return Async")]
        public async Task<Person> AsyncSelectOneWithJoinsQueryExpression()
        {
            return await db.SelectOne<Person>().From(dbo.Person).InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId).ExecuteAsync(connection);
        }

        [Benchmark(Description = "Select First With Where Clause With Entity Return Async")]
        public async Task<Person> AsyncSelectOneWithWhereClauseQueryExpression()
        {
            return await db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync(connection);
        }

        [Benchmark(Description = "Select First With Scalar Return Async")]
        public async Task<int> AsyncSelectOneWithFieldAliasQueryExpression()
        {
            return await db.SelectOne(dbo.Person.Id).From(dbo.Person).ExecuteAsync(connection);
        }

        [Benchmark(Description = "Select First With Dynamic Return Async")]
        public async Task<dynamic> AsyncSelectOneDynamicQueryExpression()
        {
            return await db.SelectOne(dbo.Person.Id, dbo.Person.FirstName, dbo.Person.LastName).From(dbo.Person).ExecuteAsync(connection);
        }

        [Benchmark(Description = "Select First With Dynamic Return Async (aliased columns)")]
        public async Task<dynamic> AsyncSelectOneDynamicWithFieldAliasQueryExpression()
        {
            return await db.SelectOne(dbo.Person.Id.As("person_Id"), dbo.Person.FirstName.As("person_FirstName"), dbo.Person.LastName.As("person_LastName")).From(dbo.Person).ExecuteAsync(connection);
        }

        [Benchmark(Description = "Select Top 50")]
        public IList<Person> SelectManyQueryExpression()
        {
            return db.SelectMany<Person>().From(dbo.Person).Execute(connection);
        }

        [Benchmark(Description = "Select Top 50 With Join Condition")]
        public IList<Person> SelectManyWithJoinsQueryExpression()
        {
            return db.SelectMany<Person>().From(dbo.Person).LeftJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId).Execute(connection);
        }

        [Benchmark(Description = "Select Top 50 With Where Clause")]
        public IList<Person> SelectManyWithWhereClauseQueryExpression()
        {
            return db.SelectMany<Person>().From(dbo.Person).Where(dbo.Person.Id > 0).Execute(connection);
        }

        [Benchmark(Description = "Select Top 50 With Scalar Return")]
        public IList<int> SelectManyWithFieldAliasQueryExpression()
        {
            return db.SelectMany(dbo.Person.Id).From(dbo.Person).Execute(connection);
        }

        [Benchmark(Description = "Select Top 50 With Dynamic Return")]
        public IList<dynamic> SelectManyDynamicQueryExpressionBaseline()
        {
            return db.SelectMany(dbo.Person.Id, dbo.Person.FirstName, dbo.Person.LastName).From(dbo.Person).Execute(connection);
        }

        [Benchmark(Description = "Select Top 50 With Dynamic Return (aliased columns)")]
        public IList<dynamic> SelectManyDynamicWithFieldAliasQueryExpression()
        {
            return db.SelectMany(dbo.Person.Id.As("person_Id"), dbo.Person.FirstName.As("person_FirstName"), dbo.Person.LastName.As("person_LastName")).From(dbo.Person).Execute(connection);
        }

        [Benchmark(Description = "Select Top 50 With Entity Return Async")]
        public async Task<IList<Person>> AsyncSelectManyQueryExpression()
        {
            return await db.SelectMany<Person>().From(dbo.Person).ExecuteAsync(connection);
        }

        [Benchmark(Description = "Select Top 50 With Join Condition With Entity Return Async")]
        public async Task<IList<Person>> AsyncSelectManyWithJoinsQueryExpression()
        {
            return await db.SelectMany<Person>().From(dbo.Person).LeftJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId).ExecuteAsync(connection);
        }

        [Benchmark(Description = "Select Top 50 With Where Clause With Entity Return Async")]
        public async Task<IList<Person>> AsyncSelectManyWithWhereClauseQueryExpression()
        {
            return await db.SelectMany<Person>().From(dbo.Person).Where(dbo.Person.Id > 0).ExecuteAsync(connection);
        }

        [Benchmark(Description = "Select Top 50 With Scalar Return Async")]
        public async Task<IList<int>> AsyncSelectManyWithFieldAliasQueryExpression()
        {
            return await db.SelectMany(dbo.Person.Id).From(dbo.Person).ExecuteAsync(connection);
        }

        [Benchmark(Description = "Select Top 50 With Dynamic Return Async")]
        public async Task<IList<dynamic>> AsyncSelectManyDynamicQueryExpression()
        {
            return await db.SelectMany(dbo.Person.Id, dbo.Person.FirstName, dbo.Person.LastName).From(dbo.Person).ExecuteAsync(connection);
        }

        [Benchmark(Description = "Select Top 50 With Dynamic Return Async (aliased columns)")]
        public async Task<IList<dynamic>> AsyncSelectManyDynamicWithFieldAliasQueryExpression()
        {
            return await db.SelectMany(dbo.Person.Id.As("person_Id"), dbo.Person.FirstName.As("person_FirstName"), dbo.Person.LastName.As("person_LastName")).From(dbo.Person).ExecuteAsync(connection);
        }
    }
}