using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using v2019DbEx.dboData;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql.Builder.Alias;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "REPLACE")]
    public partial class ReplaceTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData("Kenny", "nn", "xx", "Kexxy")]
        public void Does_replace_of_person_first_name_with_static_string_value_for_pattern_and_static_string_value_for_replacement_succeed(string firstName, string pattern, string replacement, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [InlineData("Kenny", "xx", "xx")]
        public void Does_replace_of_person_first_name_with_expression_for_pattern_and_static_string_value_for_replacement_succeed(string firstName, string replacement, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [InlineData("Kenny", "Kenny")]
        public void Does_replace_of_person_first_name_with_expression_for_pattern_and_expression_for_replacement_succeed(string firstName, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [InlineData("Kenny", "nn", "KeKennyy")]
        public void Does_replace_of_person_first_name_with_static_value_for_pattern_and_expression_for_replacement_succeed(string firstName, string pattern, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [Trait("Operation", "SUBQUERY")]
        [InlineData("100", "999", "999 1st St")]
        public void Does_replace_of_aliased_field_succeed(string pattern, string replacement, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
