using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Function", "ISNULL")]
    [Trait("Function", "LEFT")]
    public partial class IsNullAndLeftTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_static_value_character_count_for_left_of_isnull_of_address_line2_succeed(int version, int characterCount = 3, string expected = "FOO")
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Left(db.fx.IsNull(dbo.Address.Line2, expected), characterCount)
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == dbex.Null);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_static_value_character_count_for_left_of_isnull_of_address_line1_succeed(int version, int characterCount = 3)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.IsNull(dbo.Address.Line2, db.fx.Left(dbo.Address.Line1, characterCount))
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == dbex.Null);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().NotBeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_left_of_isnull_of_address_line2_and_static_value_character_count_for_succeed(int version, int characterCount = 3, string expected = "FOO")
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Left(db.fx.IsNull(dbo.Address.Line1, expected), characterCount)
                ).From(dbo.Address)
                .Where(dbo.Address.Line1 != dbex.Null);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().NotBe(expected);
        }
    }
}
