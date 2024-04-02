using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    public partial class ClrTypeOverrideTests : ResetDatabaseAfterEveryTest
    {
        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData("1")]
        public async Task Can_select_a_int_field_mapped_to_an_string_clr_type(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var quantity = await db.SelectOne(
                dbo.Purchase.TotalPurchaseQuantity
            )
            .From(dbo.Purchase)
            .Where(dbo.Purchase.Id == 1)
            .ExecuteAsync();

            //then
            quantity.Should().Be(expected);
        }

        [Theory]
        [Trait("Statement", "UPDATE")]
        [InlineData("2")]
        public async Task Can_update_a_int_field_mapped_to_an_string_clr_type(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            await db.Update(
                dbo.Purchase.TotalPurchaseQuantity.Set(expected)
            )
            .From(dbo.Purchase)
            .Where(dbo.Purchase.Id == 1)
            .ExecuteAsync();

            //then
            var quantity = await db.SelectOne(dbo.Purchase.TotalPurchaseQuantity).From(dbo.Purchase).Where(dbo.Purchase.Id == 1).ExecuteAsync();

            quantity.Should().Be(expected);
        }

        [Theory]
        [Trait("Statement", "SELECT")]
        [InlineData("1")]
        public async Task Can_select_entity_with_int_field_mapped_to_an_string_clr_type(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var purchase = await db.SelectOne<Purchase>()
                .From(dbo.Purchase)
                .Where(dbo.Purchase.Id == 1)
                .ExecuteAsync();

            //then
            purchase!.TotalPurchaseQuantity.Should().Be(expected);
        }

        [Theory]
        [Trait("Statement", "INSERT")]
        [InlineData("2")]
        public async Task Can_insert_entity_with_int_field_mapped_to_an_string_clr_type(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var purchase = new Purchase
            {
                PersonId = 1,
                OrderNumber = $"{DateTime.Now.Date:yyyymmdd}00099",
                PaymentMethodType = PaymentMethodType.ACH,
                PaymentSourceType = PaymentSourceType.InPerson,
                PurchaseDate = DateTime.Now,
                TotalPurchaseAmount = 12.0,
                TotalPurchaseQuantity = expected,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            //when
            await db.Insert(
                purchase
            )
            .Into(dbo.Purchase)
            .ExecuteAsync();

            //then
            var quantity = await db.SelectOne(dbo.Purchase.TotalPurchaseQuantity).From(dbo.Purchase).Where(dbo.Purchase.Id == purchase.Id).ExecuteAsync();

            quantity.Should().Be(expected);
        }
    }
}
