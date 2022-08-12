using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "ISNULL")]
    [Trait("Function", "PATINDEX")]
    public partial class IsNullAndPatIndexTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_isnull_of_address_line2_and_static_value_pattern_for_patindex_of_address_line2_succeed(int version, string pattern = "A%", string line2 = "Apt. 42", long expected = 1)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.PatIndex(db.fx.IsNull(dbo.Address.Line2, pattern), dbo.Address.Line2)
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == line2);

            //when               
            long? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void xDoes_isnull_of_address_line2_and_static_value_pattern_for_patindex_of_address_line2_succeed(int version, string pattern = "A%")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.PatIndex(db.fx.IsNull(dbo.Address.Line2, pattern), dbo.Address.Line2)
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == dbex.Null);

            //when               
            long? result = exp.Execute();

            //then
            result.Should().BeNull();
        }
    }
}
