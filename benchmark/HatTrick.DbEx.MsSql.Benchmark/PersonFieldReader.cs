using HatTrick.DbEx.Sql.Benchmark.dbExpression;
using HatTrick.DbEx.Sql.Benchmark.dbExpression.dboData;
using HatTrick.DbEx.Sql.Benchmark.dbExpression.dboDataService;
using HatTrick.DbEx.Sql.Executor;

#nullable disable

namespace HatTrick.DbEx.Sql.Benchmark
{
    public class PersonRowReader : ISqlRowReader, IAsyncSqlRowReader
    {
        private static readonly Person person = new()
        {
            Id = 1,
            BirthDate = new DateTime(),
            CreditLimit = 1000,
            FirstName = "First",
            LastName = "Last",
            YearOfLastCreditLimitReview = 2010,
            DateCreated = new DateTime(),
            DateUpdated = new DateTime(),
            GenderType = GenderType.Female,
            LastLoginDate = new DateTime(),
            RegistrationDate = new DateTime()
        }; 
        private readonly IValueConverterProvider valueConverterProvider;
        private ISqlFieldReader fieldReader;

        public PersonRowReader(IValueConverterProvider valueConverterProvider)
        {
            this.valueConverterProvider = valueConverterProvider;
        }

        public void Close() { }

        public void Dispose() { }

        public ISqlFieldReader ReadRow()
            => CreateRow();

        public Task<ISqlFieldReader> ReadRowAsync()
            => Task.FromResult(CreateRow());

        private ISqlFieldReader CreateRow()
        {
            if (fieldReader is object)
                return default;
            fieldReader = new Row(0, new ISqlField[11]
                {
                    new Field(0, nameof(dbo.Person.Id), typeof(int), person.Id, (f, t) => valueConverterProvider.FindConverter(0, t, f.RawValue)),
                    new Field(1, nameof(dbo.Person.FirstName), typeof(string), person.FirstName, (f, t) => valueConverterProvider.FindConverter(1, t, person.FirstName)),
                    new Field(2, nameof(dbo.Person.LastName), typeof(string), person.LastName, (f, t) => valueConverterProvider.FindConverter(2, t, person.LastName)),
                    new Field(3, nameof(dbo.Person.BirthDate), typeof(DateTime?), person.BirthDate, (f, t) => valueConverterProvider.FindConverter(3, t, person.BirthDate)),
                    new Field(4, nameof(dbo.Person.GenderType), typeof(GenderType), person.GenderType, (f, t) => valueConverterProvider.FindConverter(4, t, person.GenderType)),
                    new Field(5, nameof(dbo.Person.CreditLimit), typeof(int?), person.CreditLimit, (f, t) => valueConverterProvider.FindConverter(5, t, person.CreditLimit)),
                    new Field(6, nameof(dbo.Person.YearOfLastCreditLimitReview), typeof(int?), person.YearOfLastCreditLimitReview, (f, t) => valueConverterProvider.FindConverter(6, t, person.YearOfLastCreditLimitReview)),
                    new Field(7, nameof(dbo.Person.RegistrationDate), typeof(DateTimeOffset), person.RegistrationDate, (f, t) => valueConverterProvider.FindConverter(7, t, person.RegistrationDate)),
                    new Field(8, nameof(dbo.Person.LastLoginDate), typeof(DateTimeOffset?), person.LastLoginDate, (f, t) => valueConverterProvider.FindConverter(8, t, person.LastLoginDate)),
                    new Field(9, nameof(dbo.Person.DateCreated), typeof(DateTime), person.DateCreated, (f, t) => valueConverterProvider.FindConverter(9, t, person.DateCreated)),
                    new Field(10, nameof(dbo.Person.DateUpdated), typeof(DateTime), person.DateUpdated, (f, t) => valueConverterProvider.FindConverter(10, t, person.DateUpdated)),
                });
            return fieldReader;
        }
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