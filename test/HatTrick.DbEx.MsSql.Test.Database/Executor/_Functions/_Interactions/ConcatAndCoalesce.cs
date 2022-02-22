using DbEx.Data;
using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Function", "CAST")]
    [Trait("Function", "CONCAT")]
    public partial class ConcatAndCast : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_concat_of_ship_date_to_varchar_succeed(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Concat("Shipped On: ", db.fx.Cast(dbo.Purchase.ShipDate).AsVarChar(50))
                ).From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_concat_of_literal_and_purchaseid_to_varchar_succeed(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Concat("1", db.fx.Cast(dbo.Purchase.Id).AsVarChar(50))
                ).From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_concat_of_product_name_and_purchase_payment_source_type_succeed(int version, int expected = 10)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Concat(dbo.Product.Name, db.fx.Cast(dbo.Purchase.PaymentSourceType).AsVarChar(20))
                ).From(dbo.Product)
                .InnerJoin(dbo.PurchaseLine).On(dbo.Product.Id == dbo.PurchaseLine.ProductId)
                .InnerJoin(dbo.Purchase).On(dbo.PurchaseLine.PurchaseId == dbo.Purchase.Id)
                .Where(dbo.Purchase.PaymentSourceType == PaymentSourceType.Web);

            //when               
            var values = exp.Execute();

            //then
            values.Should().HaveCount(expected);
            values.Should().OnlyContain(x => x.EndsWith(PaymentSourceType.Web.ToString()));
        }
    }
}
