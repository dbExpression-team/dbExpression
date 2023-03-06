using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Function", "CAST")]
    [Trait("Function", "STDEVP")]
    public partial class CastAndStandardDeviationPopulationTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData("0.6849")]
        public void Does_selecting_cast_of_standarddeviationpopulation_of_quantity_to_varchar_succeed(string expectedStDevP)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Cast(db.fx.StDevP(dbo.PurchaseLine.Quantity)).AsVarChar(50)
                ).From(dbo.PurchaseLine);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().StartWith(expectedStDevP);
        }

        [Theory]
        [InlineData(.45825f)]
        public void Does_selecting_standarddeviationpopulation_of_cast_of_gendertype_to_int_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.StDevP(db.fx.Cast(dbo.Person.GenderType).AsInt())
                ).From(dbo.Person);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }
    }
}
