using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Builder.Alias;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "LEFT")]
    public partial class LeftTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_left_of_person_first_name_succeed(int version, string firstName = "Kenny", int leftLength = 3)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public void Does_left_of_address_line2_succeed(int version, int leftLength = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Does_left_of_aliased_field_succeed(int version, int leftLength = 3, string expected = "100")
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
