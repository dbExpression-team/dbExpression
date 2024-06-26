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
    [Trait("Function", "VAR")]
    public partial class VarianceTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(260.712f)]
        public void Does_variance_of_total_purchase_amount_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Var(dbo.Purchase.TotalPurchaseAmount).As("s")
                ).From(dbo.Purchase);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of variance");
        }

        [Theory]
        [InlineData(269.785f)]
        public void Does_variance_of_distinct_total_purchase_amount_succeed(float expectedValue)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Var(dbo.Purchase.TotalPurchaseAmount).Distinct().As("s")
                ).From(dbo.Purchase);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expectedValue, 0.001f, "Rounding errors in calculation of variance");
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(260.71268f)]
        public void Can_order_by_variance_of_total_purchase_amount_ascending_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Var(dbo.Purchase.TotalPurchaseAmount)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Var(dbo.Purchase.TotalPurchaseAmount));

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of variance");
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(260.71268f)]
        public void Can_order_by_variance_of_total_purchase_amount_descending_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Var(dbo.Purchase.TotalPurchaseAmount)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Var(dbo.Purchase.TotalPurchaseAmount).Desc());

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of variance");
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(260.71268f)]
        public void Can_order_by_variance_of_total_purchase_amount_ascending_and_aliasing_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Var(dbo.Purchase.TotalPurchaseAmount).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Var(dbo.Purchase.TotalPurchaseAmount));

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of variance");
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(260.71268f)]
        public void Can_order_by_variance_of_total_purchase_amount_descending_and_aliasing_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Var(dbo.Purchase.TotalPurchaseAmount).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Var(dbo.Purchase.TotalPurchaseAmount).Desc());

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of variance");
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [InlineData(16.5752f)]
        public void Can_variance_of_aliased_field_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Var(("lines", "PurchaseId")).As("alias")
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectMany<PurchaseLine>()
                    .From(dbo.PurchaseLine)
                ).As("lines").On(dbo.Purchase.Id == ("lines", "PurchaseId"));

            //when               
            object? result = exp.Execute();

            //then
            result.Should().BeOfType<float>().Which.Should().BeApproximately(expected, 0.0001f, "Rounding errors in population standard deviation");
        }
    }
}
