using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
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
    public partial class IsNullAndPatIndexTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData("A%", "Apt. 42", 1)]
        public void Does_isnull_of_address_line2_and_static_value_pattern_for_patindex_of_address_line2_succeed(string pattern, string line2, long expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [InlineData("A%")]
        public void xDoes_isnull_of_address_line2_and_static_value_pattern_for_patindex_of_address_line2_succeed(string pattern)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
