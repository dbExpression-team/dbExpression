using DbEx.DataService;
using DbEx.dboDataService;
using DbEx.dboData;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "CHARINDEX")]
    public partial class CharIndex : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_charindex_of_person_first_name_with_static_value_for_pattern_succeed(int version, string pattern = "y", string firstName = "Kenny", long expected = 5)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public void Does_charindex_of_person_first_name_with_static_value_for_pattern_and_static_long_value_for_start_succeed(int version, string pattern = "y", string firstName = "Kenny", long start = 1, long expected = 5)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public void Does_charindex_of_person_first_name_with_static_value_for_pattern_and_static_int_value_for_start_succeed(int version, string pattern = "y", string firstName = "Kenny", int start = 1, long expected = 5)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public void Does_charindex_of_person_first_name_with_static_value_for_pattern_and_int_expression_for_start_succeed(int version, string pattern = "y", string firstName = "Kenny", long expected = 5)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public void Does_charindex_of_person_first_name_with_expression_for_pattern_succeed(int version, string firstName = "Kenny", long expected = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public void Does_charindex_of_person_first_name_with_expression_for_pattern_and_static_long_value_for_start_succeed(int version, string firstName = "Kenny", long start = 1, long expected = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public void Does_charindex_of_person_first_name_with_expression_for_pattern_and_static_int_value_for_start_succeed(int version, string firstName = "Kenny", int start = 1, long expected = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public void Does_charindex_of_person_first_name_with_expression_for_pattern_and_int_expression_for_start_succeed(int version, string firstName = "Kenny", long expected = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public void Does_charindex_of_address_line2_with_static_value_for_pattern_succeed(int version, string pattern = "4", string line2 = "Apt. 42", long expected = 6)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public void Does_charindex_of_address_line2_with_static_value_for_pattern_and_static_long_value_for_start_succeed(int version, string pattern = "4", string line2 = "Apt. 42", long start = 5, long expected = 6)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public void Does_charindex_of_address_line2_with_static_value_for_pattern_and_static_int_value_for_start_succeed(int version, string pattern = "4", string line2 = "Apt. 42", int start = 5, long expected = 6)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public void Does_charindex_of_address_line2_with_expression_for_pattern_and_int_expression_for_start_succeed(int version, string line2 = "Box 13", int start = 1, long expected = 0)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public void Does_charindex_of_address_line2_with_static_value_for_pattern_and_int_static_value_for_start_succeed(int version, string pattern = "13", string line2 = "Box 13", int start = 1, long expected = 5)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public void Does_charindex_of_address_line2_with_static_value_for_pattern_and_int_expression_for_start_succeed(int version, string pattern = "o", string line2 = "Box 13", long expected = 0)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public void Does_charindex_of_address_line1_with_static_value_for_pattern_and_int_expression_for_start_succeed(int version, string pattern = " ", string line2 = "Box 13", long expected = 3)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public void Does_charindex_of_address_line2_with_null_expression_value_for_pattern_and_int_expression_for_start_succeed(int version, string line2 = "Box 13", long expected = 0)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Does_charindex_of_aliased_field_succeed(int version, int expected = 0)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.CharIndex("P%", dbex.Alias<string>("_address", "Line1")).As("address_line1")
                ).From(dbo.Address)
                .InnerJoin(
                    db.SelectOne<Address>()
                    .From(dbo.Address)
                    .Where(dbo.Address.Id == 1)
                ).As("_address").On(dbo.Address.Id == ("_address", "Id"));

            //when               
            object result = exp.Execute();

            //then
            result.Should().BeOfType<int>().Which.Should().Be(expected);
        }
    }
}
