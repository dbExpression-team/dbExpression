using DbEx.Data;
using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
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
    [Trait("Platform-Version", "v2014")]
    public partial class SelectManyTests
    {
        [Theory]
        [InlineData(2014, 50)]
        public void Can_execute_trim_function_for_v2014(int version, int expectedCount)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            IList<string> persons = db.SelectMany(db.fx.Trim(dbo.Person.FirstName))
                .From(dbo.Person)
                .Execute();

            //then
            persons.Should().HaveCount(expectedCount);
        }
    }
}
