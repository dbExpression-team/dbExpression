using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Builder.Alias;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using DbExpression.Sql.Builder.Alias;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "LOG")]
    public partial class LogTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(0f)]
        public void Does_selecting_log_of_total_purchase_quantity_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Log(dbo.PurchaseLine.Id)
                ).From(dbo.PurchaseLine)
                .Where(dbo.PurchaseLine.Id == 1);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of log");
        }

        [Theory]
        [InlineData(3.331f)]
        public void Does_selecting_log_of_total_purchase_amount_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Log(dbo.Purchase.TotalPurchaseAmount).As("amount")
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.Id == 2);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of log");
        }

        [Theory]
        [InlineData(2.055f)]
        public void Does_selecting_log_of_purchase_price_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Log(dbo.PurchaseLine.PurchasePrice)
                ).From(dbo.PurchaseLine)
                .Where(dbo.PurchaseLine.Id == 1);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of log");
        }

        [Theory]
        [InlineData(0f)]
        public void Does_selecting_log_with_literal_base_value_of_total_purchase_quantity_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Log(dbo.PurchaseLine.Id, 2)
                ).From(dbo.PurchaseLine)
                .Where(dbo.PurchaseLine.Id == 1);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of log");
        }

        [Theory]
        [InlineData(4.806f)]
        public void Does_selecting_log_with_literal_base_value_of_total_purchase_amount_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Log(dbo.Purchase.TotalPurchaseAmount, 2).As("amount")
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.Id == 2);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of log");
        }

        [Theory]
        [InlineData(2.055f)]
        public void Does_selecting_log_with_literal_base_value_of_purchase_price_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Log(dbo.PurchaseLine.PurchasePrice)
                ).From(dbo.PurchaseLine)
                .Where(dbo.PurchaseLine.Id == 1);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of log");
        }

        [Theory]
        [InlineData(1f)]
        public void Does_selecting_log_with_base_of_total_purchase_quantity_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Log(dbo.PurchaseLine.Id, dbo.PurchaseLine.Id)
                ).From(dbo.PurchaseLine)
                .Where(dbo.PurchaseLine.Id == 9);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of log");
        }

        [Theory]
        [InlineData(0.886f)]
        public void Does_selecting_log_with_base_of_total_purchase_amount_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Log(dbo.Purchase.TotalPurchaseAmount, dbo.Purchase.Id).As("amount")
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.Id == 9);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of log");
        }

        [Theory]
        [InlineData(0.967f)]
        public void Does_selecting_log_with_base_of_purchase_price_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Log(dbo.PurchaseLine.PurchasePrice, dbo.PurchaseLine.Id)
                ).From(dbo.PurchaseLine)
                .Where(dbo.PurchaseLine.Id == 9);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of log");
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [InlineData(1.443f)]
        public void Does_log_of_aliased_field_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Log(("lines", "PurchasePrice")).As("alias")
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectOne<PurchaseLine>()
                    .From(dbo.PurchaseLine)
                    .Where(dbo.PurchaseLine.Id == 1)
                ).As("lines").On(dbo.Purchase.Id == ("lines", "PurchaseId"));

            //when               
            object? result = exp.Execute();

            //then
            result.Should().BeOfType<float>().Which.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of log");
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [InlineData(2.965f)]
        public void Does_log_of_aliased_field_with_literal_value_for_base_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Log(("lines", "PurchasePrice"), 2).As("alias")
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectOne<PurchaseLine>()
                    .From(dbo.PurchaseLine)
                    .Where(dbo.PurchaseLine.Id == 1)
                ).As("lines").On(dbo.Purchase.Id == ("lines", "PurchaseId"));

            //when               
            object? result = exp.Execute();

            //then
            result.Should().BeOfType<float>().Which.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of log");
        }
    }
}
