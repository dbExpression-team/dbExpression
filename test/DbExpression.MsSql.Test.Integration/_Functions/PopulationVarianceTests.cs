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
    [Trait("Function", "VARP")]
    public partial class PopulationVarianceTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(243.331f)]
        public void Does_populationvariance_of_total_purchase_amount_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.VarP(dbo.Purchase.TotalPurchaseAmount)
                ).From(dbo.Purchase);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of variance of population");
        }

        [Theory]
        [InlineData(250.515f)]
        public void Does_populationvariance_of_distinct_total_purchase_amount_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.VarP(dbo.Purchase.TotalPurchaseAmount).Distinct()
                ).From(dbo.Purchase);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of variance of population");
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(243.33182f)]
        public void Can_order_by_populationvariance_of_total_purchase_amount_ascending_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.VarP(dbo.Purchase.TotalPurchaseAmount)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.VarP(dbo.Purchase.TotalPurchaseAmount));

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of population variance");
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(243.33182f)]
        public void Can_order_by_populationvariance_of_total_purchase_amount_descending_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.VarP(dbo.Purchase.TotalPurchaseAmount)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.VarP(dbo.Purchase.TotalPurchaseAmount).Desc());

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of population variance");
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(243.33182f)]
        public void Can_order_by_populationvariance_of_total_purchase_amount_ascending_and_aliasing_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.VarP(dbo.Purchase.TotalPurchaseAmount).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.VarP(dbo.Purchase.TotalPurchaseAmount));

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of population variance");
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(243.33182f)]
        public void Can_order_by_populationvariance_of_total_purchase_amount_descending_and_aliasing_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.VarP(dbo.Purchase.TotalPurchaseAmount).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.VarP(dbo.Purchase.TotalPurchaseAmount).Desc());

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of population variance");
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [InlineData(18.6667f)]
        public void Can_populationvariance_of_aliased_field_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.VarP(("lines", "PurchaseId")).Distinct().As("alias")
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectMany<PurchaseLine>()
                    .From(dbo.PurchaseLine)
                ).As("lines").On(dbo.Purchase.Id == ("lines", "PurchaseId"));

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.0001f, "Rounding errors in population standard deviation");
        }
    }
}
