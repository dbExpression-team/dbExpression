using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using DbExpression.MsSql.Benchmark.dbExpression.DataService;
using DbExpression.MsSql.Benchmark.dbExpression.dboData;
using DbExpression.MsSql.Benchmark.dbExpression.dboDataService;
using DbExpression.MsSql.Configuration;
using DbExpression.Sql;
using DbExpression.Sql.Connection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DbExpression.MsSql.Benchmark
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class QueryExecutionBenchmarks
    {
        private const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=MsSqlDbExTest;Integrated Security=true;";
        private ISqlConnection _connection;

        [GlobalSetup]
        public void ConfigureDbExpression()
        {
            var services = new ServiceCollection();
            services.AddDbExpression(dbex => dbex.AddDatabase<BenchmarkDatabase>(c => c.ConnectionString.Use(connectionString)));
            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.UseStaticRuntimeFor<BenchmarkDatabase>();

            _connection = db.GetConnection();
        }

        [Benchmark]
        public void ExecuteSelectQueryExpression()
        {
            db.SelectMany<Person>().From(dbo.Person).Execute(_connection).ToList();
        }

        [Benchmark]
        public void ExecuteSelectQueryExpressionWithFieldAlias()
        {
            db.SelectMany(
                dbo.Person.Id.As("person_Id"),
                dbo.Person.FirstName.As("person_FirstName"),
                dbo.Person.LastName.As("person_LastName")
            )
            .From(dbo.Person)
            .Execute(_connection).ToList();
        }

        [Benchmark]
        public void ExecuteSelectQueryExpressionWithJoinClause()
        {
            db.SelectMany<Person>()
            .From(dbo.Person)
            .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
            .Execute(_connection).ToList();
        }

        [Benchmark]
        public void ExecuteSelectQueryExpressionWithWhereClause()
        {
            db.SelectMany<Person>()
            .From(dbo.Person)
            .Where(dbo.Person.FirstName.Like("b%") & dbo.Person.CreditLimit > 1)
            .Execute(_connection).ToList();
        }

        [Benchmark]
        public void ExecuteSelectQueryExpressionWithOrderByClause()
        {
            db.SelectMany<Person>()
            .From(dbo.Person)
            .OrderBy(dbo.Person.FirstName, dbo.Person.CreditLimit)
            .Execute(_connection).ToList();
        }

        [Benchmark]
        public void ExecuteSelectQueryExpressionWithCountFunctionAndGroupByClause()
        {
            db.SelectMany(db.fx.Count())
            .From(dbo.Person)
            .GroupBy(dbo.Person.FirstName)
            .Execute(_connection).ToList();
        }

        [Benchmark]
        public void ExecuteSelectQueryExpressionWithCountFunctionAndGroupByClauseAndHavingClause()
        {
            db.SelectMany(db.fx.Count())
            .From(dbo.Person)
            .GroupBy(dbo.Person.FirstName)
            .Having(db.fx.Count() > 1)
            .Execute(_connection).ToList();
        }
    }
}