using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "LTRIM")]
    public partial class LTrim : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_ltrim_of_person_first_with_space_padding_succeed(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.LTrim(" " + dbo.Person.FirstName + " ")
                ).From(dbo.Person);

            //when               
            var name = exp.Execute();

            //then
            name.Should().NotStartWith(" ");
            name.Should().EndWith(" ");
        }
    }
}
