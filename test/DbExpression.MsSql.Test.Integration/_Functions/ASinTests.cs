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
    [Trait("Function", "ASIN")]
    public partial class ASinTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(1.571f)]
        public void Does_selecting_asin_of_total_purchase_quantity_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.ASin(dbo.PurchaseLine.Id) //valid range is -1.00 - 1.00
                ).From(dbo.PurchaseLine)
                .Where(dbo.PurchaseLine.Id == 1);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001f, "Rounding errors in calculation of arcsine");
        }

        [Fact]
        public void Does_selecting_asin_of_total_purchase_amount_fail_with_expected_exception_as_value_is_out_of_range()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.ASin(dbo.Purchase.TotalPurchaseAmount).As("amount") //valid range is -1.00 - 1.00
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.Id == 2);

            //when & then
            Assert.Throws<Microsoft.Data.SqlClient.SqlException>(() => exp.Execute());
        }

        [Fact]
        public void Does_selecting_asin_of_purchase_price_fail_with_expected_exception_as_value_is_out_of_range()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.ASin(dbo.PurchaseLine.PurchasePrice) //valid range is -1.00 - 1.00
                ).From(dbo.PurchaseLine)
                .Where(dbo.PurchaseLine.Id == 1);

            //when & then
            Assert.Throws<Microsoft.Data.SqlClient.SqlException>(() => exp.Execute());
        }

        [Fact]
        [Trait("Operation", "SUBQUERY")]
        public void Does_asin_of_aliased_field_fail_with_expected_exception_as_value_is_out_of_range()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.ASin(("lines", "PurchasePrice")).As("alias") //valid range is -1.00 - 1.00
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectOne<PurchaseLine>()
                    .From(dbo.PurchaseLine)
                    .Where(dbo.PurchaseLine.Id == 1)
                ).As("lines").On(dbo.Purchase.Id == ("lines", "PurchaseId"));

            //when & then
            Assert.Throws<Microsoft.Data.SqlClient.SqlException>(() => exp.Execute());
        }
    }
}
