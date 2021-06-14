using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Function", "ISNULL")]
    [Trait("Function", "RIGHT")]
    public partial class IsNullAndRight : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_static_value_character_count_for_right_of_isnull_of_address_line2_succeed(int version, int characterCount = 3, string expected = "FOO")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Right(db.fx.IsNull(dbo.Address.Line2, expected), characterCount)
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == DBNull.Value);

            //when               
            string result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_static_value_character_count_for_right_of_isnull_of_address_line1_succeed(int version, int characterCount = 3, string expected = "FOO")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Right(db.fx.IsNull(dbo.Address.Line1, expected), characterCount)
                ).From(dbo.Address)
                .Where(dbo.Address.Line1 != DBNull.Value);

            //when               
            string result = exp.Execute();

            //then
            result.Should().NotBe(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_right_of_isnull_of_address_line2_and_static_value_character_count_for_succeed(int version, int characterCount = 3, string expected = "FOO")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Right(db.fx.IsNull(dbo.Address.Line1, expected), characterCount)
                ).From(dbo.Address)
                .Where(dbo.Address.Line1 != DBNull.Value);

            //when               
            string result = exp.Execute();

            //then
            result.Should().NotBe(expected);
        }
    }
}
