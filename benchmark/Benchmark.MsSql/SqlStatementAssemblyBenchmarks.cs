using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using HatTrick.DbEx.MsSql.Benchmark.dbExpression.DataService;
using HatTrick.DbEx.MsSql.Benchmark.dbExpression.dboData;
using HatTrick.DbEx.MsSql.Benchmark.dbExpression.dboDataService;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql;
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
        private IServiceProvider serviceProvider = default;

        private static readonly QueryExpression selectQueryExpression = (db.SelectMany<Person>().From(dbo.Person) as IQueryExpressionProvider).Expression;

        private static readonly QueryExpression selectWithFieldAliasQueryExpression = (db.SelectMany(
                dbo.Person.Id.As("person_Id"),
                dbo.Person.FirstName.As("person_FirstName"),
                dbo.Person.LastName.As("person_LastName")
            )
            .From(dbo.Person)).Expression;

        private static readonly QueryExpression selectWithJoinClauseQueryExpression = (db.SelectMany<Person>()
                .From(dbo.Person)
                .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)).Expression;

        private static readonly QueryExpression selectWithWhereClauseQueryExpression = (db.SelectMany<Person>()
                    .From(dbo.Person)
                    .Where(dbo.Person.FirstName.Like("b%") & dbo.Person.CreditLimit > 1)).Expression;

        private static readonly QueryExpression selectWithOrderByClauseQueryExpression = (db.SelectMany<Person>()
                .From(dbo.Person)
                .OrderBy(dbo.Person.FirstName, dbo.Person.CreditLimit)).Expression;

        private static readonly QueryExpression selectWithCountFunctionAndGroupByClauseQueryExpression = (db.SelectMany(db.fx.Count())
                .From(dbo.Person)
                .GroupBy(dbo.Person.FirstName)).Expression;

        private static readonly QueryExpression selectWithCountFunctionAndHavingClauseQueryExpression = (db.SelectMany(db.fx.Count())
                .From(dbo.Person)
                .GroupBy(dbo.Person.FirstName)
                .Having(db.fx.Count() > 1)).Expression;


        [GlobalSetup]
        public void ConfigureDbExpression()
        {
            var services = new ServiceCollection();
            services.AddDbExpression(dbex => dbex.AddDatabase<BenchmarkDatabase>(c => c.ConnectionString.Use(connectionString)));
            services.AddSingleton<ISqlDatabaseMetadataProvider>(new SqlDatabaseMetadataProvider(new BenchmarkDatabaseSqlDatabaseMetadata("BenchmarkDatabase")));
            serviceProvider = services.BuildServiceProvider();
            serviceProvider.UseStaticRuntimeFor<BenchmarkDatabase>();
        }

        [Benchmark]
        public void CreateSelectSqlStatement()
        {
            serviceProvider.GetServiceProviderFor<BenchmarkDatabase>().GetRequiredService<ISqlStatementBuilder>().CreateSqlStatement(selectQueryExpression);
        }

        [Benchmark]
        public void CreateSelectSqlStatementWithFieldAlias()
        {
            serviceProvider.GetServiceProviderFor<BenchmarkDatabase>().GetRequiredService<ISqlStatementBuilder>().CreateSqlStatement(selectWithFieldAliasQueryExpression);
        }

        [Benchmark]
        public void CreateSelectSqlStatementWithJoinClause()
        {
            serviceProvider.GetServiceProviderFor<BenchmarkDatabase>().GetRequiredService<ISqlStatementBuilder>().CreateSqlStatement(selectWithJoinClauseQueryExpression);
        }

        [Benchmark]
        public void CreateSelectSqlStatementWithWhereClause()
        {
            serviceProvider.GetServiceProviderFor<BenchmarkDatabase>().GetRequiredService<ISqlStatementBuilder>().CreateSqlStatement(selectWithWhereClauseQueryExpression);
        }

        [Benchmark]
        public void CreateSelectSqlStatementWithOrderByClause()
        {
            serviceProvider.GetServiceProviderFor<BenchmarkDatabase>().GetRequiredService<ISqlStatementBuilder>().CreateSqlStatement(selectWithOrderByClauseQueryExpression);
        }

        [Benchmark]
        public void CreateSelectSqlStatementWithCountFunctionAndGroupByClause()
        {
            serviceProvider.GetServiceProviderFor<BenchmarkDatabase>().GetRequiredService<ISqlStatementBuilder>().CreateSqlStatement(selectWithCountFunctionAndGroupByClauseQueryExpression);
        }

        [Benchmark]
        public void CreateSelectSqlStatementWithCountFunctionAndGroupByClauseAndHavingClause()
        {
            serviceProvider.GetServiceProviderFor<BenchmarkDatabase>().GetRequiredService<ISqlStatementBuilder>().CreateSqlStatement(selectWithCountFunctionAndHavingClauseQueryExpression);
        }
    }
}