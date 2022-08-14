using DbEx.Data;
using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    public partial class ClrTypeOverrideTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public async Task Can_select_a_int_field_mapped_to_an_string_clr_type(int version, string expected = "1")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "UPDATE")]
        public async Task Can_update_a_int_field_mapped_to_an_string_clr_type(int version, string expected = "2")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "SELECT")]
        public async Task Can_select_entity_with_int_field_mapped_to_an_string_clr_type(int version, string expected = "1")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            //when
            var purchase = await db.SelectOne<Purchase>()
                .From(dbo.Purchase)
                .Where(dbo.Purchase.Id == 1)
                .ExecuteAsync();

            //then
            purchase!.TotalPurchaseQuantity.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Statement", "INSERT")]
        public async Task Can_insert_entity_with_int_field_mapped_to_an_string_clr_type(int version, string expected = "2")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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
