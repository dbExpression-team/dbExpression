using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using FluentAssertions.Common;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using System.Linq;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    public partial class NullableDateTimeFieldExpressionTests : ResetDatabaseAfterEveryTest
    {
        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(3)]
        public void Are_there_3_purchase_records_with_null_ship_date(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.ShipDate)
                .From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate == dbex.Null);

            //when               
            var shipDates = exp.Execute();

            //then
            shipDates.Should().HaveCount(expected).And.OnlyContain(x => x == null);
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData(12)]
        public void Are_there_12_purchase_records_with_not_null_ship_date(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(dbo.Purchase.ShipDate)
                .From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            var shipDates = exp.Execute();

            //then
            shipDates.Should().HaveCount(expected).And.NotContainNulls();
        }

        [Fact]
        [Trait("Statement", "SELECT")]
        public void Doas_a_purchase_record_with_null_ship_date_select_successfully()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(dbo.Purchase.ShipDate)
                .From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate == dbex.Null);

            //when               
            var shipDate = exp.Execute();

            //then
            shipDate.Should().BeNull();
        }

        [Theory]
        [Trait("Statement", "UPDATE")]
        [InlineData(15)]
        public void Can_update_a_purchase_record_with_null_ship_date_to_get_date_function(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.Update(dbo.Purchase.ShipDate.Set(db.fx.GetDate()))
                .From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate == dbex.Null);

            //when               
            exp.Execute();

            //then
            db.SelectOne(db.fx.Count()).From(dbo.Purchase).Where(dbo.Purchase.ShipDate != dbex.Null).Execute().Should().Be(expected);
        }

        [Theory]
        [Trait("Statement", "UPDATE")]
        [InlineData(15)]
        public void Can_update_a_purchase_record_with_null_ship_date_to_current_date(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.Update(dbo.Purchase.ShipDate.Set(DateTime.Now))
                .From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate == dbex.Null);

            //when               
            exp.Execute();

            //then
            db.SelectOne(db.fx.Count()).From(dbo.Purchase).Where(dbo.Purchase.ShipDate != dbex.Null).Execute().Should().Be(expected);
        }

        [Fact]
        [Trait("Statement", "INSERT")]
        public void Can_insert_a_purchase_record_with_null_ship_date()
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
                    PaymentMethodType = PaymentMethodType.CreditCard,
                    ShipDate = null,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                })
                .Into(dbo.Purchase);

            //when               
            exp.Execute();
        }
    }
}
