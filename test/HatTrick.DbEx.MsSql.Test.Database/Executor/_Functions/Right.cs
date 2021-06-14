using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "RIGHT")]
    public partial class Right : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_left_of_person_first_name_succeed(int version, string firstName = "Kenny", int rightLength = 3)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Right(dbo.Person.FirstName, rightLength)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            string right = exp.Execute();

            //then
            right.Should().HaveLength(rightLength);
            right.Should().Be(firstName.Substring(rightLength - 1));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_left_of_address_line2_succeed(int version, int rightLength = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Right(dbo.Address.Line2, rightLength)
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 != DBNull.Value);

            //when               
            string right = exp.Execute();

            //then
            right.Should().HaveLength(rightLength);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Does_right_of_aliased_field_succeed(int version, int rightLength = 6, string expected = "1st St")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Right(dbex.Alias("_address", "Line1"), rightLength).As("address_line1")
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
