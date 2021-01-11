using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "FLOOR")]
    public partial class Floor : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_floor_total_purchase_amount_succeed(int version, double expected = 7.00)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Floor(dbo.Purchase.TotalPurchaseAmount).As("min_amount")
                ).From(dbo.Purchase);

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_floor_of_total_purchase_amount_ascending_succeed(int version, double expected = 5.00)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Floor(dbo.Purchase.TotalPurchaseAmount)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Floor(dbo.Purchase.TotalPurchaseAmount));

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_floor_of_total_purchase_amount_descending_succeed(int version, double expected = 55.00)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Floor(dbo.Purchase.TotalPurchaseAmount)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Floor(dbo.Purchase.TotalPurchaseAmount).Desc);

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_floor_of_total_purchase_amount_ascending_and_aliasing_succeed(int version, double expected = 5.00)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Floor(dbo.Purchase.TotalPurchaseAmount).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Floor(dbo.Purchase.TotalPurchaseAmount));

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_floor_of_total_purchase_amount_descending_and_aliasing_succeed(int version, double expected = 55.00)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Floor(dbo.Purchase.TotalPurchaseAmount).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Floor(dbo.Purchase.TotalPurchaseAmount).Desc);

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Does_floor_of_aliased_field_succeed(int version, decimal expected = 7m)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Floor(dbex.Alias("lines", "PurchasePrice")).As("alias")
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectMany<PurchaseLine>()
                    .From(dbo.PurchaseLine)
                ).As("lines").On(dbo.Purchase.Id == dbex.Alias("lines", "PurchaseId"));

            //when               
            object value = exp.Execute();

            //then
            value.Should().BeOfType<decimal>().Which.Should().BeApproximately(expected, 0.1m, "Rounding errors in ceiling");
        }
    }
}
