using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using DbExpression.Sql.Builder.Alias;
using System;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "LTRIM")]
    public partial class LTrimTests : ResetDatabaseNotRequired
    {
        [Fact]
        public void Does_ltrim_of_person_first_name_with_space_padding_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.LTrim(" " + dbo.Person.FirstName + " ")
                ).From(dbo.Person);

            //when               
            var result = exp.Execute();

            //then
            result.Should().NotStartWith(" ");
            result.Should().EndWith(" ");
        }

        [Fact]
        public void Does_ltrim_of_null_address_line2_with_space_padding_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.LTrim(" " + dbo.Address.Line2 + " ")
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == dbex.Null);

            //when               
            var result = exp.Execute();

            //then
            result.Should().BeNull();
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [InlineData("100 1st St")]
        public void Does_ltrim_of_aliased_field_succeed(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.LTrim(("_address", "Line1")).As("address_line1")
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
