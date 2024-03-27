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
    [Trait("Function", "MAX")]
    public partial class MaximumTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(55.96)]
        public void Does_selecting_maximum_total_purchase_amount_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Max(dbo.Purchase.TotalPurchaseAmount).As("max_amount")
                ).From(dbo.Purchase);

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(55.96)]
        public void Does_selecting_maximum_distinct_total_purchase_amount_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Max(dbo.Purchase.TotalPurchaseAmount).Distinct().As("max_amount")
                ).From(dbo.Purchase);

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(55.96)]
        public void Can_order_by_maximum_of_total_purchase_amount_ascending_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Max(dbo.Purchase.TotalPurchaseAmount).As("avg_amount")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Max(dbo.Purchase.TotalPurchaseAmount));

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(55.96)]
        public void Can_order_by_maximum_of_total_purchase_amount_descending_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Max(dbo.Purchase.TotalPurchaseAmount)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Max(dbo.Purchase.TotalPurchaseAmount).Desc());

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(55.96)]
        public void Can_order_by_maximum_of_total_purchase_amount_ascending_and_aliasing_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Max(dbo.Purchase.TotalPurchaseAmount).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Max(dbo.Purchase.TotalPurchaseAmount));

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(55.96)]
        public void Can_order_by_maximum_of_total_purchase_amount_descending_and_aliasing_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Max(dbo.Purchase.TotalPurchaseAmount).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Max(dbo.Purchase.TotalPurchaseAmount).Desc());

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [InlineData(30.00)]
        public void Does_maximum_of_aliased_field_succeed(decimal expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Max(("lines", "PurchasePrice")).As("alias")
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectMany<PurchaseLine>()
                    .From(dbo.PurchaseLine)
                ).As("lines").On(dbo.Purchase.Id == ("lines", "PurchaseId"));

            //when               
            object? result = exp.Execute();

            //then
            result.Should().BeOfType<decimal>().Which.Should().BeApproximately(expected, 0.001m, "Rounding errors in ceiling");
        }
    }
}
