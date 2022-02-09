using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using HatTrick.DbEx.Sql.Benchmark.dbExpression.DataService;
using HatTrick.DbEx.Sql.Benchmark.dbExpression.dboData;
using HatTrick.DbEx.Sql.Benchmark.dbExpression.dboDataService;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Benchmark
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class SqlStatementAssemblyBenchmarks
    {
        private const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=MsSqlDbExTest;Integrated Security=true;";
        private RuntimeSqlDatabaseConfiguration config = default;

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
            => Configuration.dbExpression.Configure(dbex => dbex.AddMsSql2019Database<MsSqlDb>(database => { database.ConnectionString.Use(connectionString); config = database.Configuration; }));

        [Benchmark]
        public void CreateSelectSqlStatement()
        {
            config.StatementBuilderFactory.CreateSqlStatementBuilder(config, selectQueryExpression).CreateSqlStatement();
        }

        [Benchmark]
        public void CreateSelectSqlStatementWithFieldAlias()
        {
            config.StatementBuilderFactory.CreateSqlStatementBuilder(config, selectWithFieldAliasQueryExpression).CreateSqlStatement();
        }

        [Benchmark]
        public void CreateSelectSqlStatementWithJoinClause()
        {
            config.StatementBuilderFactory.CreateSqlStatementBuilder(config, selectWithJoinClauseQueryExpression).CreateSqlStatement();
        }

        [Benchmark]
        public void CreateSelectSqlStatementWithWhereClause()
        {
            config.StatementBuilderFactory.CreateSqlStatementBuilder(config, selectWithWhereClauseQueryExpression).CreateSqlStatement();
        }

        [Benchmark]
        public void CreateSelectSqlStatementWithOrderByClause()
        {
            config.StatementBuilderFactory.CreateSqlStatementBuilder(config, selectWithOrderByClauseQueryExpression).CreateSqlStatement();
        }

        [Benchmark]
        public void CreateSelectSqlStatementWithCountFunctionAndGroupByClause()
        {
            config.StatementBuilderFactory.CreateSqlStatementBuilder(config, selectWithCountFunctionAndGroupByClauseQueryExpression).CreateSqlStatement();
        }

        [Benchmark]
        public void CreateSelectSqlStatementWithCountFunctionAndGroupByClauseAndHavingClause()
        {
            config.StatementBuilderFactory.CreateSqlStatementBuilder(config, selectWithCountFunctionAndHavingClauseQueryExpression).CreateSqlStatement();
        }
    }
}