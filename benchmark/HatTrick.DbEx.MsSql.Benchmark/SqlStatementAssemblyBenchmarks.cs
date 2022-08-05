using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using HatTrick.DbEx.MsSql.Benchmark.dbExpression.DataService;
using HatTrick.DbEx.MsSql.Benchmark.dbExpression.dboData;
using HatTrick.DbEx.MsSql.Benchmark.dbExpression.dboDataService;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HatTrick.DbEx.MsSql.Benchmark
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class SqlStatementAssemblyBenchmarks
    {
        private const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=MsSqlDbExTest;Integrated Security=true;";
        private IServiceProvider provider = default;

        private static readonly QueryExpression selectQueryExpression = (db.SelectMany<Person>().From(dbo.Person) as IQueryExpressionProvider).Expression;

        private static readonly QueryExpression selectWithFieldAliasQueryExpression = (db.SelectMany(
                dbo.Person.Id.As("person_Id"),
                dbo.Person.FirstName.As("person_FirstName"),
                dbo.Person.LastName.As("person_LastName")
            )
            .From(dbo.Person) as IQueryExpressionProvider).Expression;

        private static readonly QueryExpression selectWithJoinClauseQueryExpression = (db.SelectMany<Person>()
                .From(dbo.Person)
                .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
             as IQueryExpressionProvider).Expression;

        private static readonly QueryExpression selectWithWhereClauseQueryExpression = (db.SelectMany<Person>()
                    .From(dbo.Person)
                    .Where(dbo.Person.FirstName.Like("b%") & dbo.Person.CreditLimit > 1)
             as IQueryExpressionProvider).Expression;

        private static readonly QueryExpression selectWithOrderByClauseQueryExpression = (db.SelectMany<Person>()
                .From(dbo.Person)
                .OrderBy(dbo.Person.FirstName, dbo.Person.CreditLimit)
             as IQueryExpressionProvider).Expression;

        private static readonly QueryExpression selectWithCountFunctionAndGroupByClauseQueryExpression = (db.SelectMany(db.fx.Count())
                .From(dbo.Person)
                .GroupBy(dbo.Person.FirstName)
             as IQueryExpressionProvider).Expression;

        private static readonly QueryExpression selectWithCountFunctionAndHavingClauseQueryExpression = (db.SelectMany(db.fx.Count())
                .From(dbo.Person)
                .GroupBy(dbo.Person.FirstName)
                .Having(db.fx.Count() > 1)
             as IQueryExpressionProvider).Expression;


        [GlobalSetup]
        public void ConfigureDbExpression()
        {
            Sql.Configuration.dbExpression.Configure(
                dbex => dbex.AddMsSql2019Database<BenchmarkDatabase>(db => db.ConnectionString.Use(connectionString))
            );
            provider = Sql.Configuration.dbExpression.BuildServiceProvider();
        }

        [Benchmark]
        public void CreateSelectSqlStatement()
        {
            provider.GetRequiredService<ISqlStatementBuilder<BenchmarkDatabase>>().CreateSqlStatement(selectQueryExpression);
        }

        [Benchmark]
        public void CreateSelectSqlStatementWithFieldAlias()
        {
            provider.GetRequiredService<ISqlStatementBuilder<BenchmarkDatabase>>().CreateSqlStatement(selectWithFieldAliasQueryExpression);
        }

        [Benchmark]
        public void CreateSelectSqlStatementWithJoinClause()
        {
            provider.GetRequiredService<ISqlStatementBuilder<BenchmarkDatabase>>().CreateSqlStatement(selectWithJoinClauseQueryExpression);
        }

        [Benchmark]
        public void CreateSelectSqlStatementWithWhereClause()
        {
            provider.GetRequiredService<ISqlStatementBuilder<BenchmarkDatabase>>().CreateSqlStatement(selectWithWhereClauseQueryExpression);
        }

        [Benchmark]
        public void CreateSelectSqlStatementWithOrderByClause()
        {
            provider.GetRequiredService<ISqlStatementBuilder<BenchmarkDatabase>>().CreateSqlStatement(selectWithOrderByClauseQueryExpression);
        }

        [Benchmark]
        public void CreateSelectSqlStatementWithCountFunctionAndGroupByClause()
        {
            provider.GetRequiredService<ISqlStatementBuilder<BenchmarkDatabase>>().CreateSqlStatement(selectWithCountFunctionAndGroupByClauseQueryExpression);
        }

        [Benchmark]
        public void CreateSelectSqlStatementWithCountFunctionAndGroupByClauseAndHavingClause()
        {
            provider.GetRequiredService<ISqlStatementBuilder<BenchmarkDatabase>>().CreateSqlStatement(selectWithCountFunctionAndHavingClauseQueryExpression);
        }
    }
}