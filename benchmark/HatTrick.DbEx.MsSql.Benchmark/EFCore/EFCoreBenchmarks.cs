using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using HatTrick.DbEx.MsSql.Benchmark;
using Microsoft.EntityFrameworkCore;

namespace HatTrick.DbEx.Sql.Benchmark.EFCore
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class EFCoreBenchmarks : PlatformBenchmarksBase
    {
        private MsSqlDbExTestContext context;

        [GlobalSetup]
        public void ConfigureEFCore()
        {
            context = new MsSqlDbExTestContext(Constants.ConnectionString);
        }

        [Benchmark(Description = "Select First Record")]
        public Person SelectOneQueryExpression()
        {
            return context.People.FirstOrDefault();
        }

        [Benchmark(Description = "Select First Record With Join Condition")]
        public Person SelectOneWithJoinsQueryExpression()
        {
            return context.People.Join(context.PersonAddresses, p => p.Id, pa => pa.PersonId, (p, pa) => p).FirstOrDefault();
        }

        [Benchmark(Description = "Select First Record With Where Clause")]
        public Person SelectOneWithWhereClauseQueryExpression()
        {
            return context.People.Where(p => p.Id == 1).FirstOrDefault();
        }

        [Benchmark(Description = "Select First Record With Scalar Return")]
        public int SelectOneWithFieldAliasQueryExpression()
        {
            return context.People.Select(x => x.Id).FirstOrDefault();
        }

        [Benchmark(Description = "Select First Record With Dynamic Return")]
        public dynamic SelectOneDynamicQueryExpression()
        {
            return context.People.Select(x => new { x.Id, x.FirstName, x.LastName }).FirstOrDefault();
        }

        [Benchmark(Description = "Select First Record With Dynamic Return (aliased columns)")]
        public dynamic SelectOneDynamicWithFieldAliasQueryExpression()
        {
            return context.People.Select(x => new { person_Id = x.Id, person_FirstName = x.FirstName, person_LastName = x.LastName }).FirstOrDefault();
        }

        [Benchmark(Description = "Async Select First Record With Entity Return")]
        public async Task<Person> AsyncSelectOneQueryExpression()
        {
            return await context.People.FirstOrDefaultAsync();
        }

        [Benchmark(Description = "Async Select First Record With Join Condition With Entity Return")]
        public async Task<Person> AsyncSelectOneWithJoinsQueryExpression()
        {
            return await context.People.Join(context.PersonAddresses, p => p.Id, pa => pa.PersonId, (p, pa) => p).FirstOrDefaultAsync();
        }

        [Benchmark(Description = "Async Select First Record With Where Clause With Entity Return")]
        public async Task<Person> AsyncSelectOneWithWhereClauseQueryExpression()
        {
            return await context.People.Where(p => p.Id == 1).FirstOrDefaultAsync();
        }

        [Benchmark(Description = "Async Select First Record With Scalar Return")]
        public async Task<dynamic> AsyncSelectOneWithFieldAliasQueryExpression()
        {
            return await context.People.Select(x => x.Id).FirstOrDefaultAsync();
        }

        [Benchmark(Description = "Async Select First Record With Dynamic Return")]
        public async Task<dynamic> AsyncSelectOneDynamicQueryExpression()
        {
            return await context.People.Select(x => new { x.Id, x.FirstName, x.LastName }).FirstOrDefaultAsync();
        }

        [Benchmark(Description = "Async Select First Record With Dynamic Return (aliased columns)")]
        public async Task<dynamic> AsyncSelectOneDynamicWithFieldAliasQueryExpression()
        {
            return await context.People.Select(x => new { person_Id = x.Id, person_FirstName = x.FirstName, person_LastName = x.LastName }).FirstOrDefaultAsync();
        }
    }
}