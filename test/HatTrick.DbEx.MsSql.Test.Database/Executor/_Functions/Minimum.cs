using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "MIN")]
    public partial class Minimum : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_minimum_total_purchase_amount_succeed(int version, decimal expected = 5.11m)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Min(dbo.Purchase.TotalPurchaseAmount).As("min_amount")
                ).From(dbo.Purchase);

            //when               
            decimal result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_minimum_distinct_total_purchase_amount_succeed(int version, decimal expected = 5.11m)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Min(dbo.Purchase.TotalPurchaseAmount, distinct: true).As("min_amount")
                ).From(dbo.Purchase);

            //when               
            decimal result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_minimum_of_total_purchase_amount_ascending_succeed(int version, decimal expected = 5.11m)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Min(dbo.Purchase.TotalPurchaseAmount)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Min(dbo.Purchase.TotalPurchaseAmount));

            //when               
            decimal result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_minimum_of_total_purchase_amount_descending_succeed(int version, decimal expected = 5.11m)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Min(dbo.Purchase.TotalPurchaseAmount)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Min(dbo.Purchase.TotalPurchaseAmount).Desc);

            //when               
            decimal result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_minimum_of_total_purchase_amount_ascending_and_aliasing_succeed(int version, decimal expected = 5.11m)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Min(dbo.Purchase.TotalPurchaseAmount).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Min(dbo.Purchase.TotalPurchaseAmount));

            //when               
            decimal result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_minimum_of_total_purchase_amount_descending_and_aliasing_succeed(int version, decimal expected = 5.11m)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Min(dbo.Purchase.TotalPurchaseAmount).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Min(dbo.Purchase.TotalPurchaseAmount).Desc);

            //when               
            decimal result = exp.Execute();

            //then
            result.Should().Be(expected);
        }
    }
}
