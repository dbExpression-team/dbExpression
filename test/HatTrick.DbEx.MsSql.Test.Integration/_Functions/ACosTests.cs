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
    [Trait("Function", "ACOS")]
    public partial class ACosTests : ResetDatabaseNotRequired
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_acos_of_total_purchase_quantity_succeed(int version, float expected = 0f)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.ACos(dbo.PurchaseLine.Id) //valid range is -1.00 - 1.00
                ).From(dbo.PurchaseLine)
                .Where(dbo.PurchaseLine.Id == 1);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of arccosine");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_acos_of_total_purchase_amount_fail_with_expected_exception_as_value_is_out_of_range(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.ACos(dbo.Purchase.TotalPurchaseAmount).As("amount") //valid range is -1.00 - 1.00
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.Id == 2);

            //when & then
            Assert.Throws<System.Data.SqlClient.SqlException>(() => exp.Execute());
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_acos_of_purchase_price_fail_with_expected_exception_as_value_is_out_of_range(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.ACos(dbo.PurchaseLine.PurchasePrice) //valid range is -1.00 - 1.00
                ).From(dbo.PurchaseLine)
                .Where(dbo.PurchaseLine.Id == 1);

            //when & then
            Assert.Throws<System.Data.SqlClient.SqlException>(() => exp.Execute());
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Does_acos_of_aliased_field_fail_with_expected_exception_as_value_is_out_of_range(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.ACos(("lines", "PurchasePrice")).As("alias") //valid range is -1.00 - 1.00
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectOne<PurchaseLine>()
                    .From(dbo.PurchaseLine)
                    .Where(dbo.PurchaseLine.Id == 1)
                ).As("lines").On(dbo.Purchase.Id == ("lines", "PurchaseId"));

            //when & then
            Assert.Throws<System.Data.SqlClient.SqlException>(() => exp.Execute());
        }
    }
}
