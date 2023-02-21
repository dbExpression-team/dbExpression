using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using v2019DbEx.dboData;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;
using HatTrick.DbEx.MsSql.Builder.Alias;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "CHARINDEX")]
    public partial class CharIndexTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData("y", "Kenny", 5)]
        public void Does_charindex_of_person_first_name_with_static_value_for_pattern_succeed(string pattern, string firstName, long expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.CharIndex(pattern, dbo.Person.FirstName)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            long result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("y", "Kenny", 1, 5)]
        public void Does_charindex_of_person_first_name_with_static_value_for_pattern_and_static_long_value_for_start_succeed(string pattern, string firstName, long start, long expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.CharIndex(pattern, dbo.Person.FirstName, start)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            long result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("y", "Kenny", 1, 5)]
        public void Does_charindex_of_person_first_name_with_static_value_for_pattern_and_static_int_value_for_start_succeed(string pattern, string firstName, int start, long expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.CharIndex(pattern, dbo.Person.FirstName, start)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            long result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("y", "Kenny", 5)]
        public void Does_charindex_of_person_first_name_with_static_value_for_pattern_and_int_expression_for_start_succeed(string pattern, string firstName, long expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.CharIndex(pattern, dbo.Person.FirstName, dbo.Person.Id) //kenny's id is 1
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            long result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("Kenny", 1)]
        public void Does_charindex_of_person_first_name_with_expression_for_pattern_succeed(string firstName, long expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.CharIndex(dbo.Person.FirstName, dbo.Person.FirstName)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            long result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("Kenny", 1, 1)]
        public void Does_charindex_of_person_first_name_with_expression_for_pattern_and_static_long_value_for_start_succeed(string firstName, long start, long expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.CharIndex(dbo.Person.FirstName, dbo.Person.FirstName, start)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            long result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("Kenny", 1, 1)]
        public void Does_charindex_of_person_first_name_with_expression_for_pattern_and_static_int_value_for_start_succeed(string firstName, int start, long expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.CharIndex(dbo.Person.FirstName, dbo.Person.FirstName, start)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            long result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("Kenny", 1)]
        public void Does_charindex_of_person_first_name_with_expression_for_pattern_and_int_expression_for_start_succeed(string firstName, long expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.CharIndex(dbo.Person.FirstName, dbo.Person.FirstName, dbo.Person.Id) //kenny's id is 1
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            long result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("4", "Apt. 42", 6)]
        public void Does_charindex_of_address_line2_with_static_value_for_pattern_succeed(string pattern, string line2, long expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.CharIndex(pattern, dbo.Address.Line2)
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == line2);

            //when               
            long? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("4", "Apt. 42", 5, 6)]
        public void Does_charindex_of_address_line2_with_static_value_for_pattern_and_static_long_value_for_start_succeed(string pattern, string line2, long start, long expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.CharIndex(pattern, dbo.Address.Line2, start)
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == line2);

            //when               
            long? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("4", "Apt. 42", 5, 6)]
        public void Does_charindex_of_address_line2_with_static_value_for_pattern_and_static_int_value_for_start_succeed(string pattern, string line2, int start, long expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.CharIndex(pattern, dbo.Address.Line2, start)
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == line2);

            //when               
            long? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("Box 13", 1, 0)]
        public void Does_charindex_of_address_line2_with_expression_for_pattern_and_int_expression_for_start_succeed(string line2, int start, long expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.CharIndex(dbo.Address.State, dbo.Address.Line2, start)
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == line2);

            //when               
            long? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("13", "Box 13", 1, 5)]
        public void Does_charindex_of_address_line2_with_static_value_for_pattern_and_int_static_value_for_start_succeed(string pattern, string line2, int start, long expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.CharIndex(pattern, dbo.Address.Line2, start)
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == line2);

            //when               
            long? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("o", "Box 13", 0)]
        public void Does_charindex_of_address_line2_with_static_value_for_pattern_and_int_expression_for_start_succeed(string pattern, string line2, long expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.CharIndex(pattern, dbo.Address.Line2, dbo.Address.Id) //id=3 for 'Box 13'
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == line2);

            //when               
            long? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(" ", "Box 13", 3)]
        public void Does_charindex_of_address_line1_with_static_value_for_pattern_and_int_expression_for_start_succeed(string pattern, string line2, long expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.CharIndex(pattern, dbo.Address.Line1, dbo.Address.Id) //id=3 for 'Box 13'
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == line2);

            //when               
            long? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("Box 13", 0)]
        public void Does_charindex_of_address_line2_with_null_expression_value_for_pattern_and_int_expression_for_start_succeed(string line2, long expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.CharIndex(dbo.Address.Line2, dbo.Address.Line2, dbo.Address.Id) //id=3 for 'Box 13'
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == line2);

            //when               
            long? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [InlineData(0)]
        public void Does_charindex_of_aliased_field_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.CharIndex("P%", ("_address", "Line1")).As("address_line1")
                ).From(dbo.Address)
                .InnerJoin(
                    db.SelectOne<Address>()
                    .From(dbo.Address)
                    .Where(dbo.Address.Id == 1)
                ).As("_address").On(dbo.Address.Id == ("_address", "Id"));

            //when               
            long? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }
    }
}
