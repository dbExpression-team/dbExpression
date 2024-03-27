using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Function", "CAST")]
    [Trait("Function", "STDEV")]
    public partial class CastAndStandardDeviationTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData("0.704")]
        public void Does_selecting_cast_of_standarddeviation_of_quantity_to_varchar_succeed(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Cast(db.fx.StDev(dbo.PurchaseLine.Quantity)).AsVarChar(50)
                ).From(dbo.PurchaseLine);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().StartWith(expected);
        }

        [Theory]
        [InlineData(.4629f)]
        public void Does_selecting_standarddeviation_of_cast_of_gendertype_to_int_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.StDev(db.fx.Cast(dbo.Person.GenderType).AsInt())
                ).From(dbo.Person);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }
    }
}
