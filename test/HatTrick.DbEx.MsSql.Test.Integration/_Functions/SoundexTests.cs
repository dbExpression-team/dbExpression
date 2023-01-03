using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "SOUNDEX")]
    public partial class SoundexTests : ResetDatabaseNotRequired
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_soundex_of_misspelled_person_first_name_succeed(int version, string close = "Bahir", string expected = "Baahir")
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(db.fx.Soundex(dbo.Person.FirstName) == db.fx.Soundex(close));

            //when               
            var result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.FirstName.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Does_soundex_of_aliased_field_succeed(int version, string close = "Bahir", string expected = "Hakeem")
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    dbex.Alias("peep", "LastName").As("LastName")
                ).From(dbo.Person)
                .InnerJoin(
                    db.SelectOne<Person>()
                    .From(dbo.Person)
                    .Where(db.fx.Soundex(dbo.Person.FirstName) == db.fx.Soundex(close))
                ).As("peep").On(dbo.Person.Id == ("peep", "Id"));

            //when               
            object? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }
    }
}
