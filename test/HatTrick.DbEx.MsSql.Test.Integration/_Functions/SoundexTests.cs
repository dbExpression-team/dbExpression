using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
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
        [InlineData("Bahir", "Baahir")]
        public void Does_soundex_of_misspelled_person_first_name_succeed(string close, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [Trait("Operation", "SUBQUERY")]
        [InlineData("Bahir", "Hakeem")]
        public void Does_soundex_of_aliased_field_succeed(string close, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
