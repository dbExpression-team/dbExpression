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
    public partial class Substring : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_substring_of_person_first_name_with_static_long_value_for_start_and_static_long_value_for_length_succeed(int version, string firstName = "Kenny", long start = 5, long length = 1, string expected = "y")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Substring(dbo.Person.FirstName, start, length)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            string result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_substring_of_person_first_name_with_static_int_value_for_start_and_static_int_value_for_length_succeed(int version, string firstName = "Kenny", int start = 5, int length = 1, string expected = "y")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Substring(dbo.Person.FirstName, start, length)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            string result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_substring_of_person_first_name_with_static_long_value_for_start_and_static_int_value_for_length_succeed(int version, string firstName = "Kenny", long start = 5, int length = 1, string expected = "y")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Substring(dbo.Person.FirstName, start, length)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            string result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_substring_of_person_first_name_with_static_int_value_for_start_and_static_long_value_for_length_succeed(int version, string firstName = "Kenny", int start = 5, long length = 1, string expected = "y")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Substring(dbo.Person.FirstName, start, length)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            string result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_substring_of_person_first_name_with_int_expression_for_start_and_static_long_value_for_length_succeed(int version, string firstName = "Kenny", int length = 1, string expected = "K")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Substring(dbo.Person.FirstName, dbo.Person.Id, length) //Kenny's id is 1
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            string result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_substring_of_person_first_name_with_int_expression_for_start_and_int_expression_for_length_succeed(int version, string firstName = "Kenny", string expected = "K")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Substring(dbo.Person.FirstName, dbo.Person.Id, dbo.Person.Id) //Kenny's id is 1
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            string result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Does_substring_of_aliased_field_succeed(int version, int start = 1, int length = 7, string expected = "100 1st")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Substring(dbex.Alias("_address", "Line1"), start, length).As("address_line1")  //100 1st St
                ).From(dbo.Address)
                .InnerJoin(
                    db.SelectOne<Address>()
                    .From(dbo.Address)
                    .Where(dbo.Address.Id == 1)
                ).As("_address").On(dbo.Address.Id == dbex.Alias("_address", "Id"));

            //when               
            object result = exp.Execute();

            //then
            result.Should().BeOfType<string>().Which.Should().Be(expected);
        }
    }
}
