using DbEx.Data;
using DbEx.dboDataService;
using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Xunit;
using DbEx.dboData;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "INSERT")]
    [Trait("Platform-Version", "v2005")]
    public partial class InsertTests : ExecutorTestBase
    {
        [Fact]
        public async Task Does_inserting_single_person_succeed_for_v2005()
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(2005);

            var persons = Enumerable.Range(0, 1).Select(x =>
                new Person
                {
                    FirstName = "FirstName",
                    LastName = "LastName",
                    GenderType = GenderType.Female,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                }
            ).ToList();

            await db.InsertMany(persons)
                .Into(dbo.Person)
                .ExecuteAsync();

            //when & then
            persons.Should().HaveCount(1);
            persons[0].Id.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Does_inserting_multiple_persons_fail_for_v2005()
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(2005);

            var firstNames = Enumerable.Range(0, 2).Select(x => $"FirstName_{x}");
            var lastNames = Enumerable.Range(0, 2).Select(x => $"LastName_{x}");
            var persons = Enumerable.Range(0, 2).Select(x =>
                new Person
                {
                    FirstName = firstNames.ElementAt(x),
                    LastName = lastNames.ElementAt(x),
                    GenderType = x % 2 == 0 ? GenderType.Female : GenderType.Male,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                }
            ).ToList();

            Action execute = () => db.InsertMany(persons)
                .Into(dbo.Person)
                .Execute();

            //when & then
            execute.Should().Throw<DbExpressionException>().And.Message.Should().Be("MsSql version 2005 does not support inserting multiple records in a single statement.");
        }
    }
}
