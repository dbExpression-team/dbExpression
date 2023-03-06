using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    public partial class NullableGuidFieldExpressionTests : ResetDatabaseAfterEveryTest
    {
        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(11)]
        public void Are_there_3_purchase_records_with_null_tracking_identifier(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.TrackingIdentifier)
                .From(dbo.Purchase)
                .Where(dbo.Purchase.TrackingIdentifier == dbex.Null);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expected).And.OnlyContain(x => x == null);
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Doas_a_purchase_record_with_null_tracking_identifier_select_successfully()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(dbo.Purchase.TrackingIdentifier)
                .From(dbo.Purchase)
                .Where(dbo.Purchase.TrackingIdentifier == dbex.Null);

            //when               
            var purchase = exp.Execute();

            //then
            purchase.Should().BeNull();
        }

        [Theory]
        [Trait("Statement", "UPDATE")]
        [InlineData(15)]
        public void Can_update_a_purchase_record_with_null_tracking_identifier_to_new_id_function(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.Update(dbo.Purchase.TrackingIdentifier.Set(db.fx.NewId()))
                .From(dbo.Purchase)
                .Where(dbo.Purchase.TrackingIdentifier == dbex.Null);

            //when               
            exp.Execute();

            //then
            db.SelectOne(db.fx.Count()).From(dbo.Purchase).Where(dbo.Purchase.TrackingIdentifier != dbex.Null).Execute().Should().Be(expected);
        }

        [Theory]
        [Trait("Statement", "UPDATE")]
        [InlineData(15)]
        public void Can_update_a_purchase_record_with_null_tracking_identifier_to_generated_guid(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.Update(dbo.Purchase.TrackingIdentifier.Set(Guid.NewGuid()))
                .From(dbo.Purchase)
                .Where(dbo.Purchase.TrackingIdentifier == dbex.Null);

            //when               
            exp.Execute();

            //then
            db.SelectOne(db.fx.Count()).From(dbo.Purchase).Where(dbo.Purchase.TrackingIdentifier != dbex.Null).Execute().Should().Be(expected);
        }

        [Fact]
        [Trait("Statement", "INSERT")]
        public void Can_insert_a_purchase_record_with_null_tracking_identifier()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.Insert(
                new Purchase 
                { 
                    PersonId = 1,
                    OrderNumber = $"{DateTime.Now.Date:yyyymmdd}00099",
                    TotalPurchaseQuantity = 0.ToString(),
                    PurchaseDate = DateTime.Now,
                    PaymentMethodType = PaymentMethodType.ACH,
                    ShipDate = DateTime.Now,
                    TrackingIdentifier = null,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                })
                .Into(dbo.Purchase);

            //when               
            exp.Execute();
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(15)]
        public void Can_select_list_of_purchase_record_and_convert_string_to_payment_method(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var purchases = db.SelectMany<Purchase>()
                .From(dbo.Purchase)
                .Execute();

            //then
            purchases.Should().HaveCount(expected);
            purchases.Should().Match(p => p.All(x => ((PaymentMethodType[])Enum.GetValues(typeof(PaymentMethodType))).Contains(x.PaymentMethodType)));
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(15)]
        public void Can_select_list_of_PaymentMethodType_field_from_purchase_and_convert_string_to_payment_method(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var paymentMethods = db.SelectMany(
                    dbo.Purchase.PaymentMethodType
                )
                .From(dbo.Purchase)
                .Execute();

            //then
            paymentMethods.Should().HaveCount(expected);
            paymentMethods.Should().Contain((PaymentMethodType[])Enum.GetValues(typeof(PaymentMethodType)));
        }
    }
}
