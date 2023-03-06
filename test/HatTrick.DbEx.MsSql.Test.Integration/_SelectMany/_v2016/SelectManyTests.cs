using v2016DbEx.DataService;
using v2016DbEx.dboData;
using v2016DbEx.dboDataService;
using v2016DbEx.secDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Platform-Version", "v2016")]
    public partial class SelectManyTests
    {
        [Theory]
        [InlineData(50)]
        public void Can_execute_ltrim_and_rtrim_functions_for_v2016(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2016MsSqlDb>();

            //when
            IEnumerable<string> persons = db.SelectMany(db.fx.LTrim(db.fx.RTrim(dbo.Person.FirstName)))
                .From(dbo.Person)
                .Execute();

            //then
            persons.Should().HaveCount(expectedCount);
        }
    }
}
