using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "COS")]
    public partial class CosTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(0.540f)]
        public void Does_selecting_cos_of_total_purchase_quantity_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Cos(dbo.PurchaseLine.Quantity)
                ).From(dbo.PurchaseLine)
                .Where(dbo.PurchaseLine.Id == 1);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of cosine");
        }

        [Theory]
        [InlineData(-0.957f)]
        public void Does_selecting_cos_of_total_purchase_amount_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Cos(dbo.Purchase.TotalPurchaseAmount).As("amount")
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.Id == 2);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of cosine");
        }

        [Theory]
        [InlineData(0.0440f)]
        public void Does_selecting_cos_of_purchase_price_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Cos(dbo.PurchaseLine.PurchasePrice)
                ).From(dbo.PurchaseLine)
                .Where(dbo.PurchaseLine.Id == 1);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of cosine");
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [InlineData(0.0440f)]
        public void Does_cos_of_aliased_field_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Cos(("lines", "PurchasePrice")).As("alias")
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectOne<PurchaseLine>()
                    .From(dbo.PurchaseLine)
                    .Where(dbo.PurchaseLine.Id == 1)
                ).As("lines").On(dbo.Purchase.Id == ("lines", "PurchaseId"));

            //when               
            object? result = exp.Execute();

            //then
            result.Should().BeOfType<float>().Which.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of cosine");
        }
    }
}
