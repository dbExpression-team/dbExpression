using DbEx.DataService;
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
        public void Does_sum_of_total_purchase_amount_succeed(int version, decimal expected = 308.15m)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Sum(dbo.Purchase.TotalPurchaseAmount).As("sum")
                ).From(dbo.Purchase);

            //when               
            decimal result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_sum_of_distinct_total_purchase_amount_succeed(int version, decimal expected = 299.15m)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Sum(dbo.Purchase.TotalPurchaseAmount, distinct: true).As("sum")
                ).From(dbo.Purchase);

            //when               
            decimal result = exp.Execute();

            //then
            result.Should().Be(expected);
        }


        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_sum_of_total_purchase_amount_ascending_succeed(int version, decimal expected = 308.15m)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Sum(dbo.Purchase.TotalPurchaseAmount)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Sum(dbo.Purchase.TotalPurchaseAmount));

            //when               
            decimal result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_sum_of_total_purchase_amount_descending_succeed(int version, decimal expected = 308.15m)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Sum(dbo.Purchase.TotalPurchaseAmount)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Sum(dbo.Purchase.TotalPurchaseAmount).Desc);

            //when               
            decimal result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_sum_of_total_purchase_amount_ascending_and_aliasing_succeed(int version, decimal expected = 308.15m)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Sum(dbo.Purchase.TotalPurchaseAmount).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Sum(dbo.Purchase.TotalPurchaseAmount));

            //when               
            decimal result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_sum_of_total_purchase_amount_descending_and_aliasing_succeed(int version, decimal expected = 308.15m)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Sum(dbo.Purchase.TotalPurchaseAmount).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Sum(dbo.Purchase.TotalPurchaseAmount).Desc);

            //when               
            decimal result = exp.Execute();

            //then
            result.Should().Be(expected);
        }
    }
}
