using DbEx.DataService;
using DbEx.dboDataService;
using DbEx.dboData;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Builder.Alias;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "REPLACE")]
    public partial class ReplaceTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_replace_of_person_first_name_with_static_string_value_for_pattern_and_static_string_value_for_replacement_succeed(int version, string firstName = "Kenny", string pattern = "nn", string replacement = "xx", string expected = "Kexxy")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectOne(
                    db.fx.Replace(dbo.Person.FirstName, pattern, replacement)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_replace_of_person_first_name_with_expression_for_pattern_and_static_string_value_for_replacement_succeed(int version, string firstName = "Kenny", string replacement = "xx", string expected = "xx")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectOne(
                    db.fx.Replace(dbo.Person.FirstName, dbo.Person.FirstName, replacement)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_replace_of_person_first_name_with_expression_for_pattern_and_expression_for_replacement_succeed(int version, string firstName = "Kenny", string expected = "Kenny")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectOne(
                    db.fx.Replace(dbo.Person.FirstName, dbo.Person.FirstName, dbo.Person.FirstName)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_replace_of_person_first_name_with_static_value_for_pattern_and_expression_for_replacement_succeed(int version, string firstName = "Kenny", string pattern = "nn", string expected = "KeKennyy")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectOne(
                    db.fx.Replace(dbo.Person.FirstName, pattern, dbo.Person.FirstName)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Does_replace_of_aliased_field_succeed(int version, string pattern = "100", string replacement = "999", string expected = "999 1st St")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectOne(
                    db.fx.Replace(("_address", "Line1"), pattern, replacement).As("address_line1")  //100 1st St
                ).From(dbo.Address)
                .InnerJoin(
                    db.SelectOne<Address>()
                    .From(dbo.Address)
                    .Where(dbo.Address.Id == 1)
                ).As("_address").On(dbo.Address.Id == ("_address", "Id"));

            //when               
            object? result = exp.Execute();

            //then
            result.Should().BeOfType<string>().Which.Should().Be(expected);
        }
    }
}
