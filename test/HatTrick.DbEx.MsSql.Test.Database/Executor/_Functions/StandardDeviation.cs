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
    [Trait("Function", "STDEV")]
    public partial class StandardDeviation : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_standard_deviation_of_total_purchase_amount_succeed(int version, float expected = 16.146f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.StDev(dbo.Purchase.TotalPurchaseAmount).As("s")
                ).From(dbo.Purchase);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of standard deviation");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_standard_deviation_of_distinct_total_purchase_amount_succeed(int version, float expected = 16.425f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.StDev(dbo.Purchase.TotalPurchaseAmount).Distinct().As("s")
                ).From(dbo.Purchase);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of standard deviation");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_standarddeviation_of_total_purchase_amount_ascending_succeed(int version, float expected = 16.146599f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.StDev(dbo.Purchase.TotalPurchaseAmount)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.StDev(dbo.Purchase.TotalPurchaseAmount));

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of standard deviation");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_standarddeviation_of_total_purchase_amount_descending_succeed(int version, float expected = 16.146599f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.StDev(dbo.Purchase.TotalPurchaseAmount)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.StDev(dbo.Purchase.TotalPurchaseAmount).Desc);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of standard deviation");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_standarddeviation_of_total_purchase_amount_ascending_and_aliasing_succeed(int version, float expected = 16.146599f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.StDev(dbo.Purchase.TotalPurchaseAmount).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.StDev(dbo.Purchase.TotalPurchaseAmount));

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of standard deviation");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_standarddeviation_of_total_purchase_amount_descending_and_aliasing_succeed(int version, float expected = 16.146599f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.StDev(dbo.Purchase.TotalPurchaseAmount).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.StDev(dbo.Purchase.TotalPurchaseAmount).Desc);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of standard deviation");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Can_standarddeviation_of_aliased_field_succeed(int version, double expected = 4.472)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.StDev(dbex.Alias("lines", "PurchaseId")).Distinct().As("alias")
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectMany<PurchaseLine>()
                    .From(dbo.PurchaseLine)
                ).As("lines").On(dbo.Purchase.Id == dbex.Alias("lines", "PurchaseId"));

            //when               
            object result = exp.Execute();

            //then
            result.Should().BeOfType<double>().Which.Should().BeApproximately(expected, 0.001, "Rounding errors in standard deviation");
        }
    }
}
