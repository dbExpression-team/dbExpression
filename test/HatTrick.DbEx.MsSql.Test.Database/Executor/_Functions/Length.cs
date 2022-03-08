using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "LENGTH")]
    public partial class Length : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_length_of_person_first_name_succeed(int version, string firstName = "Kenny", long expected = 5)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Len(dbo.Person.FirstName)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            long length = exp.Execute();

            //then
            length.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_length_of_address_line2_succeed(int version, string? line2 = null)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Len(dbo.Address.Line2)
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == line2);

            //when               
            long? length = exp.Execute();

            //then
            length.Should().BeNull();
        }
    }
}
