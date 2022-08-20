using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Builder.Alias;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "LENGTH")]
    public partial class LengthTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_length_of_person_first_name_succeed(int version, string firstName = "Kenny", long expected = 5)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Len(dbo.Address.Line2)
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == line2);

            //when               
            long? length = exp.Execute();

            //then
            length.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Can_datepart_of_aliased_field_succeed(int version, long expected = 10)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Len(("other", "Line1")).As("alias")
                ).From(dbo.Address)
                .InnerJoin(
                    db.SelectOne(
                            dbo.Address.Id,
                            dbo.Address.Line1
                        )
                        .From(dbo.Address)
                        .Where(dbo.Address.Line1 == "100 1st St")
                ).As("other").On(dbo.Address.Id == ("other", "Id"));

            //when               
            long? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }
    }
}
