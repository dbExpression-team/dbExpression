using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using HatTrick.DbEx.MsSql.Benchmark.dbExpression.DataService;
using HatTrick.DbEx.MsSql.Benchmark.dbExpression.dboData;
using HatTrick.DbEx.MsSql.Benchmark.dbExpression.dboDataService;
using HatTrick.DbEx.MsSql.Configuration;

namespace HatTrick.DbEx.MsSql.Benchmark
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class QueryExpressionBenchmarks
    {
        private const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=MsSqlDbExTest;Integrated Security=true;";

        [GlobalSetup]
        public void ConfigureDbExpression()
            => Sql.Configuration.dbExpression.Configure(dbex => dbex.AddMsSql2019Database<MsSqlDb>(database => database.ConnectionString.Use(connectionString)));

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