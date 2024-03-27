using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using DbExpression.MsSql.Benchmark.dbExpression.DataService;
using DbExpression.MsSql.Benchmark.dbExpression.dboData;
using DbExpression.MsSql.Benchmark.dbExpression.dboDataService;
using DbExpression.MsSql.Configuration;
using DbExpression.Sql;
using Microsoft.Extensions.DependencyInjection;

namespace DbExpression.MsSql.Benchmark
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class QueryExpressionBenchmarks
    {
        private const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=MsSqlDbExTest;Integrated Security=true;";

        [GlobalSetup]
        public void ConfigureDbExpression()
        {
            var services = new ServiceCollection();
            services.AddDbExpression(dbex => dbex.AddDatabase<BenchmarkDatabase>(c => c.ConnectionString.Use(connectionString)));
            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.UseStaticRuntimeFor<BenchmarkDatabase>();
        }

        [Benchmark]
        public void CreateSelectQueryExpression()
        {
            db.SelectMany<Person>().From(dbo.Person);
        }

        [Benchmark]
        public void CreateSelectQueryExpressionWithFieldAlias()
        {
            db.SelectMany(
                dbo.Person.Id.As("person_Id"),
                dbo.Person.FirstName.As("person_FirstName"),
                dbo.Person.LastName.As("person_LastName")
            )
            .From(dbo.Person);
        }

        [Benchmark]
        public void CreateSelectQueryExpressionWithJoinClause()
        {
            db.SelectMany<Person>()
            .From(dbo.Person)
            .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId);
        }

        [Benchmark]
        public void CreateSelectQueryExpressionWithWhereClause()
        {
            db.SelectMany<Person>()
            .From(dbo.Person)
            .Where(dbo.Person.FirstName.Like("b%") & dbo.Person.CreditLimit > 1);
        }

        [Benchmark]
        public void CreateSelectQueryExpressionWithOrderByClause()
        {
            db.SelectMany<Person>()
            .From(dbo.Person)
            .OrderBy(dbo.Person.FirstName, dbo.Person.CreditLimit);
        }

        [Benchmark]
        public void CreateSelectQueryExpressionWithCountFunctionAndGroupByClause()
        {
            db.SelectMany(db.fx.Count())
            .From(dbo.Person)
            .GroupBy(dbo.Person.FirstName);
        }

        [Benchmark]
        public void CreateSelectQueryExpressionWithCountFunctionAndGroupByClauseAndHavingClause()
        {
            db.SelectMany(db.fx.Count())
            .From(dbo.Person)
            .GroupBy(dbo.Person.FirstName)
            .Having(db.fx.Count() > 1);
        }
    }
}