using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Function", "CAST")]
    [Trait("Function", "COUNT")]
    public partial class CastAndCountTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData("15")]
        public void Does_selecting_cast_of_count_of_purchaseid_to_varchar_succeed(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Cast(db.fx.Count(dbo.Purchase.Id)).AsVarChar(50)
                ).From(dbo.Purchase);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(50)]
        public void Does_selecting_count_of_cast_of_gendertype_to_int_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Count(db.fx.Cast(dbo.Person.GenderType).AsInt())
                ).From(dbo.Person);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }
    }
}
