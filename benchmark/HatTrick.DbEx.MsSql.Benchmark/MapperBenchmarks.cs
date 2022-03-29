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
        private static SqlDatabaseRuntimeConfiguration config;
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
                            config = (database as ISqlDatabaseRuntimeConfigurationProvider<MsSqlSqlDatabaseRuntimeConfiguration>).Configuration;
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
}