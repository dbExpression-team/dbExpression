using DbEx.DataService;
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
    }
}
