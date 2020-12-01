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
    [Trait("Function", "SUM")]
    public partial class Sum : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_sum_of_total_purchase_amount_succeed(int version, double expected = 308.15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Sum(dbo.Purchase.TotalPurchaseAmount).As("sum")
                ).From(dbo.Purchase);

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_sum_of_distinct_total_purchase_amount_succeed(int version, double expected = 299.15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Sum(dbo.Purchase.TotalPurchaseAmount).Distinct().As("sum")
                ).From(dbo.Purchase);

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }


        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_sum_of_total_purchase_amount_ascending_succeed(int version, double expected = 308.15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Sum(dbo.Purchase.TotalPurchaseAmount)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Sum(dbo.Purchase.TotalPurchaseAmount));

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_sum_of_total_purchase_amount_descending_succeed(int version, double expected = 308.15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Sum(dbo.Purchase.TotalPurchaseAmount)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Sum(dbo.Purchase.TotalPurchaseAmount).Desc);

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_sum_of_total_purchase_amount_ascending_and_aliasing_succeed(int version, double expected = 308.15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Sum(dbo.Purchase.TotalPurchaseAmount).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Sum(dbo.Purchase.TotalPurchaseAmount));

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_sum_of_total_purchase_amount_descending_and_aliasing_succeed(int version, double expected = 308.15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Sum(dbo.Purchase.TotalPurchaseAmount).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Sum(dbo.Purchase.TotalPurchaseAmount).Desc);

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Can_sum_of_aliased_field_succeed(int version, decimal expected = 222.65m)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Sum(db.alias("lines", "PurchasePrice")).As("alias")
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectMany<PurchaseLine>()
                    .From(dbo.PurchaseLine)
                ).As("lines").On(dbo.Purchase.Id == db.alias("lines", "PurchaseId"));

            //when               
            object result = exp.Execute();

            //then
            result.Should().BeOfType<decimal>().Which.Should().BeApproximately(expected, 0.01m, "Rounding errors in summation");
        }
    }
}
