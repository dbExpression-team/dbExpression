using DbEx.Data;
using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Builder.Alias;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "CAST")]
    public partial class CastTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_cast_of_ship_date_to_varchar_succeed(int version, int expected = 15)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Cast(dbo.Purchase.ShipDate).AsVarChar(50)
                ).From(dbo.Purchase);

            //when               
            IList<string?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_multiple_fields_and_casting_ship_date_to_varchar_succeed(int version, int expected = 15)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    dbo.Purchase.Id,
                    db.fx.Cast(dbo.Purchase.ShipDate).AsVarChar(50).As("ship_date")
                ).From(dbo.Purchase);

            //when               
            IList<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_cast_of_purchase_date_to_varchar_ascending_succeed(int version, string expected = "Nov  1 2019")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50));

            //when               
            string? result = exp.Execute();

            //then
            result.Should().StartWith(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_cast_of_purchase_date_to_varchar_descending_succeed(int version, string expected = "Nov  5 2019")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50).Desc);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().StartWith(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_cast_of_purchase_date_to_varchar_ascending_and_aliasing_succeed(int version, string expected = "Nov  1 2019")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50));

            //when               
            string? result = exp.Execute();

            //then
            result.Should().StartWith(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_cast_of_purchase_date_to_varchar_descending_and_aliasing_succeed(int version, string expected = "Nov  5 2019")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50).Desc);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().StartWith(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Can_group_by_cast_of_purchase_date_to_varchar_ascending_succeed(int version, string expected = "Nov  1 2019")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50)
                ).From(dbo.Purchase)
                .GroupBy(db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50));

            //when               
            string? result = exp.Execute();

            //then
            result.Should().StartWith(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Can_group_by_cast_of_purchase_date_to_varchar_ascending_and_aliasing_succeed(int version, string expected = "Nov  1 2019")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50).As("alias")
                ).From(dbo.Purchase)
                .GroupBy(db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50));

            //when               
            string? result = exp.Execute();

            //then
            result.Should().StartWith(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_cast_product_valid_end_time_of_day_for_purchase_to_datetime_succeed(int version, int expected = 23)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Cast(dbo.Product.ValidEndTimeOfDayForPurchase).AsDateTime()
                ).From(dbo.Product)
                .Where(dbo.Product.ValidEndTimeOfDayForPurchase != dbex.Null);

            //when               
            DateTime? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Hour.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_cast_product_category_type_to_varchar(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Cast(dbo.Product.ProductCategoryType).AsVarChar(2)
                ).From(dbo.Product)
                .Where(dbo.Product.ProductCategoryType == ProductCategoryType.Books);

            //when               
            string? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result.Should().Be(((int)ProductCategoryType.Books).ToString());
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Can_cast_of_aliased_field_succeed(int version, string expected = "30.00")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Cast(("lines", "PurchasePrice")).AsVarChar(50).As("alias")
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectMany<PurchaseLine>().Top(100)
                    .From(dbo.PurchaseLine)
                    .OrderBy(dbo.PurchaseLine.PurchasePrice.Desc)
                ).As("lines").On(dbo.Purchase.Id == ("lines", "PurchaseId"));

            //when               
            object? result = exp.Execute();

            //then
            result.Should().BeOfType<string>().Which.Should().StartWith(expected);
        }
    }
}
