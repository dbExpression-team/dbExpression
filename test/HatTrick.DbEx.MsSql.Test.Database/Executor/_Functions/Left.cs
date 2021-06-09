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
    [Trait("Function", "LEFT")]
    public partial class Left : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_left_of_person_first_name_succeed(int version, string firstName = "Kenny", int leftLength = 3)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Left(dbo.Person.FirstName, leftLength)
                ).From(dbo.Person)
                .Where(dbo.Person.FirstName == firstName);

            //when               
            string left = exp.Execute();

            //then
            left.Should().HaveLength(leftLength);
            left.Should().Be(firstName.Substring(0, leftLength));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_left_of_address_line2_succeed(int version, int leftLength = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Left(dbo.Address.Line2, leftLength)
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 != DBNull.Value);

            //when               
            string left = exp.Execute();

            //then
            left.Should().HaveLength(leftLength);
        }
    }
}
