using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using HatTrick.DbEx.MsSql.Benchmark.dbExpression.DataService;
using HatTrick.DbEx.MsSql.Benchmark.dbExpression.dboData;
using HatTrick.DbEx.MsSql.Benchmark.dbExpression.dboDataService;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Mapper;
using System.Dynamic;

namespace HatTrick.DbEx.MsSql.Benchmark
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public partial class MapperBenchmarks
    {
        private const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=MsSqlDbExTest;Integrated Security=true;";
        private static RuntimeSqlDatabaseConfiguration config;
        private static IValueConverterProvider valueConverterProvider;
        private static IEntityMapper<Person> personMapper;
        private static IExpandoObjectMapper personObjectMapper;

        [GlobalSetup]
        public void ConfigureDbExpression()
        {
            Sql.Configuration.dbExpression.Configure(
                dbex =>
                {

                    dbex.AddMsSql2019Database<MsSqlDb>(
                        database =>
                        {
                            config = database.Configuration;
                            database.ConnectionString.Use(connectionString);
                        }
                    );

                });

            valueConverterProvider = new SqlStatementValueConverterProvider(config.ValueConverterFactory);
            personMapper = config.MapperFactory.CreateEntityMapper(dbo.Person);
            personObjectMapper = config.MapperFactory.CreateExpandoObjectMapper();
        }

        [Benchmark]
        public void MapPersonFromFieldReader()
        {
            personMapper.Map(new PersonRowReader(valueConverterProvider).ReadRow(), new Person());
        }

        [Benchmark]
        public void MapDynamicPersonFromFieldReader()
        {
            personObjectMapper.Map(new ExpandoObject(), new PersonRowReader(valueConverterProvider).ReadRow());
        }
    }



    //[MemoryDiagnoser]
    //[Orderer(SummaryOrderPolicy.FastestToSlowest)]
    //[RankColumn]
    //public class xQueryExpressionBenchmarks
    //{
    //    private static readonly Person person = new Person
    //    {
    //        Id = 1,
    //        BirthDate = new DateTime(),
    //        CreditLimit = 1000,
    //        FirstName = "First",
    //        LastName = "Last",
    //        YearOfLastCreditLimitReview = 2010,
    //        DateCreated = new DateTime(),
    //        DateUpdated = new DateTime(),
    //        GenderType = GenderType.Female,
    //        LastLoginDate = new DateTime(),
    //        RegistrationDate = new DateTime()
    //    };

    //    private static readonly ISqlStatementExecutor executor = new BenchmarkSqlStatementExecutor();
    //    private RuntimeSqlDatabaseConfiguration config = default;
    //    private static readonly QueryExpression query = (db.SelectMany<Person>().From(dbo.Person) as IQueryExpressionProvider)!.Expression;

    //    [GlobalSetup]
    //    public void ConfigureDbExpression()
    //    {
    //        dbExpression.Configure(
    //            dbex => {

    //                dbex.AddMsSql2019Database<MsSqlDb>(
    //                    database => {
    //                        config = database.Configuration;
    //                        database.ConnectionString.Use("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=MsSqlDbExTest;Integrated Security=true;");
    //                        database.Conversions.UseDefaultFactory(x =>
    //                            x.OverrideForEnumType<PaymentMethodType>().PersistAsString()
    //                             .OverrideForEnumType<PaymentSourceType>().PersistAsString()
    //                        );
    //                        database.SqlStatements.Execution.Executor.Use(() => executor);
    //                    }
    //                );

    //            });
    //    }

    //    [Benchmark]
    //    public void CreateSelectQueryExpression()
    //    {
    //        db.SelectMany<Person>().From(dbo.Person);
    //    }

    //    [Benchmark]
    //    public void CreateSelectSqlStatement()
    //    {
    //        config.StatementBuilderFactory.CreateSqlStatementBuilder(config, query).CreateSqlStatement();
    //    }

    //    [Benchmark]
    //    public void ExecuteSelectQueryExpression()
    //    {
    //        db.SelectMany<Person>().From(dbo.Person).Execute();
    //    }

    //    [Benchmark]
    //    public void ExecuteSelectWithJoinsQueryExpression()
    //    {
    //        db.SelectMany<Person>().From(dbo.Person).InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId).Execute();
    //    }

    //    [Benchmark]
    //    public void ExecuteSelectWithWhereClauseQueryExpression()
    //    {
    //        db.SelectMany<Person>().From(dbo.Person).Where(dbo.Person.Id == 1).Execute();
    //    }

    //    [Benchmark]
    //    public void ExecuteSelectWithFieldAliasQueryExpression()
    //    {
    //        db.SelectMany(dbo.Person.Id.As("person_Id")).From(dbo.Person).Execute();
    //    }



    //    [Benchmark]
    //    public async Task ExecuteAsyncSelectQueryExpression()
    //    {
    //        await db.SelectMany<Person>().From(dbo.Person).ExecuteAsync();
    //    }

    //    [Benchmark]
    //    public async Task ExecuteAsyncSelectWithJoinsQueryExpression()
    //    {
    //        await db.SelectMany<Person>().From(dbo.Person).InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId).ExecuteAsync();
    //    }

    //    [Benchmark]
    //    public async Task ExecuteAsyncSelectWithWhereClauseQueryExpression()
    //    {
    //        await db.SelectMany<Person>().From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync();
    //    }

    //    [Benchmark]
    //    public async Task ExecuteAsyncSelectWithFieldAliasQueryExpression()
    //    {
    //        await db.SelectMany(dbo.Person.Id.As("person_Id")).From(dbo.Person).ExecuteAsync();
    //    }



    //    private class SqlRowReader : ISqlRowReader
    //    {
    //        public void Close() { }
    //        public void Dispose() { }
    //        public ISqlFieldReader? ReadRow() => null;
    //    }

    //    private class AsyncSqlRowReader : IAsyncSqlRowReader
    //    {
    //        public void Close() { }
    //        public void Dispose() { }
    //        public Task<ISqlFieldReader> ReadRowAsync() => Task.FromResult((ISqlFieldReader)null);
    //    }

    //    private class BenchmarkSqlStatementExecutor : ISqlStatementExecutor
    //    {
    //        private static readonly ISqlRowReader reader = new SqlRowReader();
    //        private static readonly IAsyncSqlRowReader asyncReader = new AsyncSqlRowReader();

    //        public int ExecuteNonQuery(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution)
    //            => 0;

    //        public Task<int> ExecuteNonQueryAsync(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution, CancellationToken ct)
    //            => Task.FromResult(0);

    //        public ISqlRowReader ExecuteQuery(SqlStatement statement, ISqlConnection connection, IValueConverterProvider finder, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution)
    //            => reader;

    //        public Task<IAsyncSqlRowReader> ExecuteQueryAsync(SqlStatement statement, ISqlConnection connection, IValueConverterProvider finder, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution, CancellationToken ct)
    //            => Task.FromResult(asyncReader);

    //        public T ExecuteScalar<T>(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution)
    //            => default;

    //        public Task<T> ExecuteScalarAsync<T>(SqlStatement statement, ISqlConnection connection, Action<IDbCommand> beforeExecution, Action<IDbCommand> afterExecution, CancellationToken ct)
    //            => Task.FromResult<T>(default);
    //    }
    //}
}