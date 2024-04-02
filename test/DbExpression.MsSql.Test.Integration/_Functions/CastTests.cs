using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Builder.Alias;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using System.Collections.Generic;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "CAST")]
    public partial class CastTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(15)]
        public void Does_selecting_cast_of_ship_date_to_varchar_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Cast(dbo.Purchase.ShipDate).AsVarChar(50)
                ).From(dbo.Purchase);

            //when               
            IEnumerable<string?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_selecting_multiple_fields_and_casting_ship_date_to_varchar_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Purchase.Id,
                    db.fx.Cast(dbo.Purchase.ShipDate).AsVarChar(50).As("ship_date")
                ).From(dbo.Purchase);

            //when               
            IEnumerable<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData("Nov  1 2019")]
        public void Can_order_by_cast_of_purchase_date_to_varchar_ascending_succeed(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [Trait("Operation", "ORDER BY")]
        [InlineData("Nov  5 2019")]
        public void Can_order_by_cast_of_purchase_date_to_varchar_descending_succeed(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50).Desc());

            //when               
            string? result = exp.Execute();

            //then
            result.Should().StartWith(expected);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData("Nov  1 2019")]
        public void Can_order_by_cast_of_purchase_date_to_varchar_ascending_and_aliasing_succeed(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [Trait("Operation", "ORDER BY")]
        [InlineData("Nov  5 2019")]
        public void Can_order_by_cast_of_purchase_date_to_varchar_descending_and_aliasing_succeed(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50).Desc());

            //when               
            string? result = exp.Execute();

            //then
            result.Should().StartWith(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData("Nov  1 2019")]
        public void Can_group_by_cast_of_purchase_date_to_varchar_ascending_succeed(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [Trait("Operation", "GROUP BY")]
        [InlineData("Nov  1 2019")]
        public void Can_group_by_cast_of_purchase_date_to_varchar_ascending_and_aliasing_succeed(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [InlineData(23)]
        public void Can_cast_product_valid_end_time_of_day_for_purchase_to_datetime_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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

        [Fact]
        public void Can_cast_product_category_type_to_varchar()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [Trait("Operation", "SUBQUERY")]
        [InlineData("30.00")]
        public void Can_cast_of_aliased_field_succeed(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Cast(("lines", "PurchasePrice")).AsVarChar(50).As("alias")
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectMany<PurchaseLine>().Top(100)
                    .From(dbo.PurchaseLine)
                    .OrderBy(dbo.PurchaseLine.PurchasePrice.Desc())
                ).As("lines").On(dbo.Purchase.Id == ("lines", "PurchaseId"));

            //when               
            object? result = exp.Execute();

            //then
            result.Should().BeOfType<string>().Which.Should().StartWith(expected);
        }
    }
}
