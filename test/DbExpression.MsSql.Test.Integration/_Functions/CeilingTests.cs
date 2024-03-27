using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using DbExpression.Sql.Builder.Alias;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "CEILING")]
    public partial class CeilingTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(8.00)]
        public void Does_selecting_ceil_total_purchase_amount_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount).As("min_amount")
                ).From(dbo.Purchase);

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(6.00)]
        public void Can_order_by_ceil_of_total_purchase_amount_ascending_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [Trait("Operation", "ORDER BY")]
        [InlineData(56.00)]
        public void Can_order_by_ceil_of_total_purchase_amount_descending_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount).Desc());

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(6.00)]
        public void Can_order_by_ceil_of_total_purchase_amount_ascending_and_aliasing_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [Trait("Operation", "ORDER BY")]
        [InlineData(56.00)]
        public void Can_order_by_ceil_of_total_purchase_amount_descending_and_aliasing_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Ceiling(dbo.Purchase.TotalPurchaseAmount).Desc());

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [InlineData(8)]
        public void Does_ceiling_of_aliased_field_succeed(decimal expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Ceiling(("lines", "PurchasePrice")).As("alias")
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectMany<PurchaseLine>()
                    .From(dbo.PurchaseLine)
                ).As("lines").On(dbo.Purchase.Id == ("lines", "PurchaseId"));

            //when               
            object? value = exp.Execute();

            //then
            value.Should().BeOfType<decimal>().Which.Should().BeApproximately(expected, 0.1m, "Rounding errors in ceiling");
        }
    }
}
