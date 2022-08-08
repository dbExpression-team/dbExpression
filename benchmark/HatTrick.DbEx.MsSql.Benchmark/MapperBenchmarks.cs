using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using HatTrick.DbEx.MsSql.Benchmark.dbExpression.DataService;
using HatTrick.DbEx.MsSql.Benchmark.dbExpression.dboData;
using HatTrick.DbEx.MsSql.Benchmark.dbExpression.dboDataService;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Dynamic;

namespace HatTrick.DbEx.MsSql.Benchmark
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public partial class MapperBenchmarks
    {
        private const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=MsSqlDbExTest;Integrated Security=true;";
        private static IValueConverterProvider valueConverterProvider;
        private static IEntityMapper<Person> personMapper;
        private static IExpandoObjectMapper personObjectMapper;

        [GlobalSetup]
        public void ConfigureDbExpression()
        {
            IServiceProvider sp = Sql.Configuration.dbExpression.Configure(
                dbex =>
                {

                    dbex.AddMsSql2019Database<BenchmarkDatabase>(
                        database => database.ConnectionString.Use(connectionString)
                    );

                });
            valueConverterProvider = new SqlStatementValueConverterProvider(sp.GetRequiredService<IValueConverterFactory<BenchmarkDatabase>>());
            personMapper = sp.GetRequiredService<IMapperFactory<BenchmarkDatabase>>().CreateEntityMapper(dbo.Person);
            personObjectMapper = sp.GetRequiredService<IMapperFactory<BenchmarkDatabase>>().CreateExpandoObjectMapper();
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