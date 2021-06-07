using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "TRIM")]
    public partial class Trim : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersionsExcept(2005, 2008, 2012, 2014, 2016)]
        public void Does_trim_of_person_first_with_space_padding_succeed(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Trim(" " + dbo.Person.FirstName + " ")
                ).From(dbo.Person);

            //when               
            var name = exp.Execute();

            //then
            name.Should().NotStartWith(" ");
            name.Should().NotEndWith(" ");
        }
    }
}
