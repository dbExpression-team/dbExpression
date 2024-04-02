using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DbExpression.MsSql.Benchmark.EFCore
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.Method)]
    [RankColumn]
    [Description("EFCore (No Tracking)")]
    public class EFCoreNoTrackingBenchmarks : PlatformBenchmarksBase
    {
        private MsSqlDbExTestContext context;

        [GlobalSetup]
        public void ConfigureEFCore()
        {
            context = new MsSqlDbExTestContext(Constants.ConnectionString, QueryTrackingBehavior.NoTracking);
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

        [Benchmark(Description = "Select First Record With Entity Return Async")]
        public async Task<Person> AsyncSelectOneQueryExpression()
        {
            return await context.People.FirstOrDefaultAsync();
        }

        [Benchmark(Description = "Select First Record With Join Condition With Entity Return Async")]
        public async Task<Person> AsyncSelectOneWithJoinsQueryExpression()
        {
            return await context.People.Join(context.PersonAddresses, p => p.Id, pa => pa.PersonId, (p, pa) => p).FirstOrDefaultAsync();
        }

        [Benchmark(Description = "Select First Record With Where Clause With Entity Return Async")]
        public async Task<Person> AsyncSelectOneWithWhereClauseQueryExpression()
        {
            return await context.People.Where(p => p.Id == 1).FirstOrDefaultAsync();
        }

        [Benchmark(Description = "Select First Record With Scalar Return Async")]
        public async Task<dynamic> AsyncSelectOneWithFieldAliasQueryExpression()
        {
            return await context.People.Select(x => x.Id).FirstOrDefaultAsync();
        }

        [Benchmark(Description = "Select First Record With Dynamic Return Async")]
        public async Task<dynamic> AsyncSelectOneDynamicQueryExpression()
        {
            return await context.People.Select(x => new { x.Id, x.FirstName, x.LastName }).FirstOrDefaultAsync();
        }

        [Benchmark(Description = "Select First Record With Dynamic Return Async (aliased columns)")]
        public async Task<dynamic> AsyncSelectOneDynamicWithFieldAliasQueryExpression()
        {
            return await context.People.Select(x => new { person_Id = x.Id, person_FirstName = x.FirstName, person_LastName = x.LastName }).FirstOrDefaultAsync();
        }

        [Benchmark(Description = "Select Top 50")]
        public IList<Person> SelectManyQueryExpression()
        {
            return context.People.Take(50).ToList();
        }

        [Benchmark(Description = "Select Top 50 With Join Condition")]
        public IList<Person> SelectManyWithJoinsQueryExpression()
        {
            return context.People.GroupJoin(context.PersonAddresses, p => p.Id, pa => pa.PersonId, (person, address) => new { person, address })
                .SelectMany(pair => pair.address.DefaultIfEmpty(), (person, _) => person.person).Take(50).ToList();
        }

        [Benchmark(Description = "Select Top 50 With Where Clause")]
        public IList<Person> SelectManyWithWhereClauseQueryExpression()
        {
            return context.People.Where(p => p.Id == 1).Take(50).ToList();
        }

        [Benchmark(Description = "Select Top 50 With Scalar Return")]
        public IList<int> SelectManyWithFieldAliasQueryExpression()
        {
            return context.People.Select(x => x.Id).Take(50).ToList();
        }

        [Benchmark(Description = "Select Top 50 With Dynamic Return")]
        public IList<dynamic> SelectManyDynamicQueryExpression()
        {
            return context.People.Select(x => new { x.Id, x.FirstName, x.LastName }).Take(50).Cast<dynamic>().ToList();
        }

        [Benchmark(Description = "Select Top 50 With Dynamic Return (aliased columns)")]
        public IList<dynamic> SelectManyDynamicWithFieldAliasQueryExpression()
        {
            return context.People.Select(x => new { person_Id = x.Id, person_FirstName = x.FirstName, person_LastName = x.LastName }).Take(50).Cast<dynamic>().ToList();
        }

        [Benchmark(Description = "Select Top 50 With Entity Return Async")]
        public async Task<IList<Person>> AsyncSelectManyQueryExpression()
        {
            return await context.People.Take(50).ToListAsync();
        }

        [Benchmark(Description = "Select Top 50 With Join Condition With Entity Return Async")]
        public async Task<IList<Person>> AsyncSelectManyWithJoinsQueryExpression()
        {
            return await context.People.GroupJoin(context.PersonAddresses, p => p.Id, pa => pa.PersonId, (person, address) => new { person, address })
                .SelectMany(pair => pair.address.DefaultIfEmpty(), (person, _) => person.person).Take(50).ToListAsync();
        }

        [Benchmark(Description = "Select Top 50 With Where Clause With Entity Return Async")]
        public async Task<IList<Person>> AsyncSelectManyWithWhereClauseQueryExpression()
        {
            return await context.People.Where(p => p.Id == 1).Take(50).ToListAsync();
        }

        [Benchmark(Description = "Select Top 50 With Scalar Return Async")]
        public async Task<IList<int>> AsyncSelectManyWithFieldAliasQueryExpression()
        {
            return await context.People.Select(x => x.Id).Take(50).Cast<int>().ToListAsync();
        }

        [Benchmark(Description = "Select Top 50 With Dynamic Return Async")]
        public async Task<IList<dynamic>> AsyncSelectManyDynamicQueryExpression()
        {
            return await context.People.Select(x => new { x.Id, x.FirstName, x.LastName }).Take(50).Cast<dynamic>().ToListAsync();
        }

        [Benchmark(Description = "Select Top 50 With Dynamic Return Async (aliased columns)")]
        public async Task<List<dynamic>> AsyncSelectManyDynamicWithFieldAliasQueryExpression()
        {
            return await context.People.Select(x => new { person_Id = x.Id, person_FirstName = x.FirstName, person_LastName = x.LastName }).Take(50).Cast<dynamic>().ToListAsync();
        }
    }
}