using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "RIGHT")]
    public partial class RightTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData("Kenny", 3)]
        public void Does_left_of_person_first_name_succeed(string firstName, int rightLength)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Right(dbo.Person.FirstName, rightLength)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            string? right = exp.Execute();

            //then
            right.Should().HaveLength(rightLength);
#pragma warning disable IDE0079
#pragma warning disable IDE0057 // Use range operator
            right.Should().Be(firstName.Substring(rightLength - 1));
#pragma warning restore IDE0057 // Use range operator
#pragma warning restore IDE0079
        }

        [Theory]
        [InlineData(1)]
        public void Does_left_of_address_line2_succeed(int rightLength)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Right(dbo.Address.Line2, rightLength)
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 != dbex.Null);

            //when               
            string? right = exp.Execute();

            //then
            right.Should().HaveLength(rightLength);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [InlineData(6, "1st St")]
        public void Does_right_of_aliased_field_succeed(int rightLength, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Right(("_address", "Line1"), rightLength).As("address_line1")
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
