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
    [Trait("Function", "TAN")]
    public partial class TanTests : ResetDatabaseNotRequired
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_tan_of_total_purchase_quantity_succeed(int version, float expected = 1.557f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Tan(dbo.PurchaseLine.Quantity)
                ).From(dbo.PurchaseLine)
                .Where(dbo.PurchaseLine.Id == 1);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of sine");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_tan_of_total_purchase_amount_succeed(int version, float expected = -0.303f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Tan(dbo.Purchase.TotalPurchaseAmount).As("amount")
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.Id == 2);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of sine");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_tan_of_purchase_price_succeed(int version, float expected = 22.722f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Tan(dbo.PurchaseLine.PurchasePrice)
                ).From(dbo.PurchaseLine)
                .Where(dbo.PurchaseLine.Id == 1);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of sine");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Does_tan_of_aliased_field_succeed(int version, float expected = 22.722f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Tan(("lines", "PurchasePrice")).As("alias")
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectOne<PurchaseLine>()
                    .From(dbo.PurchaseLine)
                    .Where(dbo.PurchaseLine.Id == 1)
                ).As("lines").On(dbo.Purchase.Id == ("lines", "PurchaseId"));

            //when               
            object? result = exp.Execute();

            //then
            result.Should().BeOfType<float>().Which.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of sine");
        }
    }
}
