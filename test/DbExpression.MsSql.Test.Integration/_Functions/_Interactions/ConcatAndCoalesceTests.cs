using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System.Collections.Generic;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Function", "CAST")]
    [Trait("Function", "CONCAT")]
    public partial class ConcatAndCastTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(15)]
        public void Does_selecting_concat_of_ship_date_to_varchar_succeed(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Concat("Shipped On: ", db.fx.Cast(dbo.Purchase.ShipDate).AsVarChar(50))
                ).From(dbo.Purchase);

            //when               
            IEnumerable<string> purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(15)]
        public void Does_selecting_concat_of_literal_and_purchaseid_to_varchar_succeed(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Concat("1", db.fx.Cast(dbo.Purchase.Id).AsVarChar(50))
                ).From(dbo.Purchase);

            //when               
            IEnumerable<string> purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(10)]
        public void Does_concat_of_product_name_and_purchase_payment_source_type_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Concat(dbo.Product.Name, db.fx.Cast(dbo.Purchase.PaymentSourceType).AsVarChar(20))
                ).From(dbo.Product)
                .InnerJoin(dbo.PurchaseLine).On(dbo.Product.Id == dbo.PurchaseLine.ProductId)
                .InnerJoin(dbo.Purchase).On(dbo.PurchaseLine.PurchaseId == dbo.Purchase.Id)
                .Where(dbo.Purchase.PaymentSourceType == PaymentSourceType.Web);

            //when               
            IEnumerable<string> values = exp.Execute();

            //then
            values.Should().HaveCount(expected);
            values.Should().OnlyContain(x => x.EndsWith(PaymentSourceType.Web.ToString()));
        }
    }
}
