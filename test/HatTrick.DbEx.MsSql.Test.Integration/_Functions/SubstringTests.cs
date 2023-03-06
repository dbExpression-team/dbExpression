using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using v2019DbEx.dboData;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;
using System;
using HatTrick.DbEx.MsSql.Builder;
using HatTrick.DbEx.MsSql.Builder.Alias;
using v2019DbEx.unit_testDataService;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "SUBSTRING")]
    public partial class SubstringTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData("Kenny", 5, 1, "y")]
        public void Does_substring_of_person_first_name_with_static_long_value_for_start_and_static_long_value_for_length_succeed(string firstName, long start, long length, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Substring(dbo.Person.FirstName, start, length)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("Kenny", 5, 1, "y")]
        public void Does_substring_of_person_first_name_with_static_int_value_for_start_and_static_int_value_for_length_succeed(string firstName, int start, int length, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Substring(dbo.Person.FirstName, start, length)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("Kenny", 5, 1, "y")]
        public void Does_substring_of_person_first_name_with_static_long_value_for_start_and_static_int_value_for_length_succeed(string firstName, long start, int length, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Substring(dbo.Person.FirstName, start, length)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("Kenny", 5, 1, "y")]
        public void Does_substring_of_person_first_name_with_static_int_value_for_start_and_static_long_value_for_length_succeed(string firstName, int start, long length, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Substring(dbo.Person.FirstName, start, length)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("Kenny", 1, "K")]
        public void Does_substring_of_person_first_name_with_int_expression_for_start_and_static_long_value_for_length_succeed(string firstName, int length, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Substring(dbo.Person.FirstName, dbo.Person.Id, length) //Kenny's id is 1
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("Kenny", "K")]
        public void Does_substring_of_person_first_name_with_int_expression_for_start_and_int_expression_for_length_succeed(string firstName, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Substring(dbo.Person.FirstName, dbo.Person.Id, dbo.Person.Id) //Kenny's id is 1
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Fact]
        public void Does_substring_of_unit_test_string_with_nullable_int_for_start_and_nullable_int_for_length_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Substring(unit_test.ExpressionElementType.String, unit_test.ExpressionElementType.NullableInt32, unit_test.ExpressionElementType.NullableInt32)
                ).From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.NullableInt32 == dbex.Null);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().BeNull();
        }

        [Fact]
        public void Does_substring_of_unit_test_string_with_nullable_int_for_start_and_nullable_long_for_length_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Substring(unit_test.ExpressionElementType.String, unit_test.ExpressionElementType.NullableInt32, unit_test.ExpressionElementType.NullableInt64)
                ).From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.NullableInt32 == dbex.Null);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().BeNull();
        }

        [Fact]
        public void Does_substring_of_unit_test_string_with_nullable_long_for_start_and_nullable_long_for_length_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Substring(unit_test.ExpressionElementType.String, unit_test.ExpressionElementType.NullableInt64, unit_test.ExpressionElementType.NullableInt64)
                ).From(unit_test.ExpressionElementType)
                .Where(unit_test.ExpressionElementType.NullableInt32 == dbex.Null);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().BeNull();
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [InlineData(1, 7, "100 1st")]
        public void Does_substring_of_aliased_field_succeed(int start, int length, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Substring(("_address", "Line1"), start, length).As("address_line1")  //100 1st St
                ).From(dbo.Address)
                .InnerJoin(
                    db.SelectOne<Address>()
                    .From(dbo.Address)
                    .Where(dbo.Address.Id == 1)
                ).As("_address").On(dbo.Address.Id == ("_address", "Id"));

            //when               
            string? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }
    }
}
