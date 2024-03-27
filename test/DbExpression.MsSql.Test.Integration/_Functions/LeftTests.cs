using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.Sql.Builder.Alias;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "LEFT")]
    public partial class LeftTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData("Kenny", 3)]
        public void Does_left_of_person_first_name_succeed(string firstName, int leftLength)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Left(dbo.Person.FirstName, leftLength)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            string? left = exp.Execute();

            //then
            left.Should().HaveLength(leftLength);
#pragma warning disable IDE0079
#pragma warning disable IDE0057 // Use range operator
            left.Should().Be(firstName.Substring(0, leftLength));
#pragma warning restore IDE0057 // Use range operator
#pragma warning restore IDE0079
        }

        [Theory]
        [InlineData(1)]
        public void Does_left_of_address_line2_succeed(int leftLength)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Left(dbo.Address.Line2, leftLength)
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 != dbex.Null);

            //when               
            string? left = exp.Execute();

            //then
            left.Should().HaveLength(leftLength);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [InlineData(3, "100")]
        public void Does_left_of_aliased_field_succeed(int leftLength, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Left(("_address", "Line1"), leftLength).As("address_line1")
                ).From(dbo.Address)
                .InnerJoin(
                    db.SelectOne<Address>()
                    .From(dbo.Address)
                    .Where(dbo.Address.Id == 1)
                ).As("_address").On(dbo.Address.Id == ("_address", "Id"));

            //when               
            string? result = exp.Execute();

            //then
            result.Should().BeOfType<string>().Which.Should().Be(expected);
        }
    }
}
