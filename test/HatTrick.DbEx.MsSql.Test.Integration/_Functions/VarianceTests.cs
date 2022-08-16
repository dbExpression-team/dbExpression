using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "VAR")]
    public partial class VarianceTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_variance_of_total_purchase_amount_succeed(int version, float expected = 260.712f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Var(dbo.Purchase.TotalPurchaseAmount).As("s")
                ).From(dbo.Purchase);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of variance");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_variance_of_distinct_total_purchase_amount_succeed(int version, float expectedValue = 269.785f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Var(dbo.Purchase.TotalPurchaseAmount).Distinct().As("s")
                ).From(dbo.Purchase);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expectedValue, 0.001f, "Rounding errors in calculation of variance");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_variance_of_total_purchase_amount_ascending_succeed(int version, float expected = 260.71268f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_variance_of_total_purchase_amount_descending_succeed(int version, float expected = 260.71268f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Var(dbo.Purchase.TotalPurchaseAmount)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Var(dbo.Purchase.TotalPurchaseAmount).Desc);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of variance");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_variance_of_total_purchase_amount_ascending_and_aliasing_succeed(int version, float expected = 260.71268f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_variance_of_total_purchase_amount_descending_and_aliasing_succeed(int version, float expected = 260.71268f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Var(dbo.Purchase.TotalPurchaseAmount).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Var(dbo.Purchase.TotalPurchaseAmount).Desc);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of variance");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Can_variance_of_aliased_field_succeed(int version, float expected = 16.5752f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
