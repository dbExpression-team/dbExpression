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
    [Trait("Function", "CEILING")]
    public partial class Ceiling : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_ceil_total_purchase_amount_succeed(int version, double expected = 8.00)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount).As("min_amount")
                ).From(dbo.Purchase);

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_ceil_of_total_purchase_amount_ascending_succeed(int version, double expected = 6.00)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount));

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_ceil_of_total_purchase_amount_descending_succeed(int version, double expected = 56.00)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount).Desc);

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_ceil_of_total_purchase_amount_ascending_and_aliasing_succeed(int version, double expected = 6.00)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount));

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_ceil_of_total_purchase_amount_descending_and_aliasing_succeed(int version, double expected = 56.00)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount).Desc);

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Does_ceiling_of_aliased_field_succeed(int version, decimal expected = 8m)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Ceiling(db.alias("lines", "PurchasePrice")).As("alias")
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectMany<PurchaseLine>()
                    .From(dbo.PurchaseLine)
                ).As("lines").On(dbo.Purchase.Id == db.alias("lines", "PurchaseId"));

            //when               
            object value = exp.Execute();

            //then
            value.Should().BeOfType<decimal>().Which.Should().BeApproximately(expected, 0.1m, "Rounding errors in ceiling");
        }
    }
}
