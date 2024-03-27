using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using System.Collections.Generic;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "COALESCE")]
    public partial class CoalesceTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(15)]
        public void Does_coalesceing_ship_date_and_purchase_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IEnumerable<object?> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_coalesceing_all_product_dates_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce(
                        dbo.Purchase.ShipDate,
                        dbo.Purchase.PurchaseDate
                    ).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IEnumerable<object?> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Expression", "Arithmetic")]
        [InlineData(15)]
        public void Does_coalesceing_ship_date_and_getdate_plus_purchase_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Purchase.TotalPurchaseAmount,
                    db.fx.Coalesce(
                        dbo.Purchase.ShipDate,
                        db.fx.GetDate() + dbo.Purchase.PurchaseDate
                    ).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IEnumerable<dynamic> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_coalesceing_ship_date_and_static_value_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce(
                        dbo.Purchase.ShipDate,
                        DateTime.Now
                    ).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IEnumerable<object?> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_coalesceing_ship_date_and_expected_delivery_date_and_static_value_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce(
                        dbo.Purchase.ShipDate,
                        dbo.Purchase.ExpectedDeliveryDate,
                        DateTime.Now
                    ).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IEnumerable<object?> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_coalesceing_ship_date_and_expected_delivery_date_and_static_null_value_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce(
                        dbo.Purchase.ShipDate,
                        dbo.Purchase.ExpectedDeliveryDate,
                        (DateTime?)null!
                    ).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IEnumerable<object?> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_coalesceing_ship_date_and_expected_delivery_date_and_static_non_null_value_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce(
                        dbo.Purchase.ShipDate,
                        dbo.Purchase.ExpectedDeliveryDate,
                        (DateTime?)DateTime.Now
                    ).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IEnumerable<object?> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(2019)]
        public void Can_order_by_coalesce_of_ship_date_and_purchase_date_ascending_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate));

            //when               
            object? result = exp.Execute();

            //then
            result.Should().BeOfType<DateTime>().Which.Year.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(2019)]
        public void Can_order_by_coalesce_of_ship_date_and_purchase_date_descending_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).Desc());

            //when               
            object? result = exp.Execute();

            //then
            result.Should().BeOfType<DateTime>().Which.Year.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(2019)]
        public void Can_order_by_coalesce_of_ship_date_and_purchase_date_ascending_and_aliasing_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate));

            //when               
            object? result = exp.Execute();

            //then
            result.Should().BeOfType<DateTime>().Which.Year.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(2019)]
        public void Can_order_by_coalesce_of_ship_date_and_purchase_date_descending_and_aliasing_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                   db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).Desc());

            //when               
            object? result = exp.Execute();

            //then
            result.Should().BeOfType<DateTime>().Which.Year.Should().Be(expected);
        }

        [Fact]
        public void Can_coalesce_of_ship_date_and_expected_delivery_date_with_aliasing_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                   db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.ExpectedDeliveryDate).As("alias")
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate == dbex.Null & dbo.Purchase.ExpectedDeliveryDate == dbex.Null);

            //when               
            object? result = exp.Execute();

            //then
            result.Should().BeNull();
        }

        [Theory]
        [InlineData(13)]
        public void Can_coalesce_of_ship_date_and_expected_delivery_date_and_id_with_aliasing_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                   db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.ExpectedDeliveryDate, dbo.Purchase.Id).As("alias")
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.Id == 13)
                .OrderBy(dbo.Purchase.Id);

            //when               
            object? result = exp.Execute();

            //then
            result.Should().BeOfType<DateTime>().Which.Should().Be(new DateTime(1900, 1, expected + 1)); //sql server returns "1900-01-01" as the default for datetime
        }

        [Theory]
        [InlineData(5)]
        public void Can_group_by_coalesce_of_ship_date_and_purchase_date_descending_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate)
                ).From(dbo.Purchase)
                .GroupBy(db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate));

            //when               
            IEnumerable<object?> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(5)]
        public void Can_group_by_coalesce_of_ship_date_and_purchase_date_descending_and_aliasing_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).As("relevant_date")
                ).From(dbo.Purchase)
                .GroupBy(db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate));

            //when               
            IEnumerable<object?> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Can_coalesce_of_ship_date_and_expected_delivery_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.ExpectedDeliveryDate).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IEnumerable<object?> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Can_coalesce_of_ship_date_and_expected_delivery_date_and_null_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.ExpectedDeliveryDate, (DateTime?)null!).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IEnumerable<object?> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(1)]
        public void Can_coalesce_of_valid_start_time_of_day_for_purchase_and_valid_end_time_of_day_for_purchase_and_timespan_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce(dbo.Product.ValidStartTimeOfDayForPurchase, dbo.Product.ValidEndTimeOfDayForPurchase, TimeSpan.FromHours(expected)).As("relevant_date")
                ).From(dbo.Product)
                .Where(dbo.Product.ValidStartTimeOfDayForPurchase == dbex.Null & dbo.Product.ValidEndTimeOfDayForPurchase == dbex.Null);

            //when               
            IEnumerable<object?> dates = exp.Execute();

            //then
            dates.Should().OnlyContain(x => (TimeSpan?)x == TimeSpan.FromHours(expected));
        }

        [Fact]
        public void Can_coalesce_of_valid_start_time_of_day_for_purchase_and_valid_end_time_of_day_for_purchase_and_null_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce(dbo.Product.ValidStartTimeOfDayForPurchase, dbo.Product.ValidEndTimeOfDayForPurchase, (TimeSpan?)null!).As("relevant_date")
                ).From(dbo.Product)
                .Where(dbo.Product.ValidStartTimeOfDayForPurchase == dbex.Null & dbo.Product.ValidEndTimeOfDayForPurchase == dbex.Null);

            //when               
            IEnumerable<object?> dates = exp.Execute();

            //then
            dates.Should().OnlyContain(x => x == null);
        }

        [Theory]
        [InlineData(1)]
        public void Can_coalesce_of_productcategorytype_for_product_and_terminate_with_null_succeed(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce(dbo.Product.ProductCategoryType, dbo.Product.ProductCategoryType, (ProductCategoryType?)null!).As("relevant")
                ).From(dbo.Product)
                .Where(dbo.Product.ProductCategoryType == dbex.Null);

            //when               
            IEnumerable<ProductCategoryType?> types = exp.Execute();

            //then
            types.Should().OnlyContain(x => x == null).And.HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(1)]
        public void Can_coalesce_of_productcategorytype_for_product_and_terminate_with_valid_productcategorytype_succeed(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce(dbo.Product.ProductCategoryType, dbo.Product.ProductCategoryType, ProductCategoryType.Books).As("relevant")
                ).From(dbo.Product)
                .Where(dbo.Product.ProductCategoryType == dbex.Null);

            //when               
            IEnumerable<ProductCategoryType> types = exp.Execute();

            //then
            types.Should().OnlyContain(x => x == ProductCategoryType.Books).And.HaveCount(expectedCount);
        }

        [Theory]
        [InlineData(1)]
        public void Can_coalesce_of_productcategorytype_for_product_and_terminate_with_productcategorytype_succeed(int expectedCount)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce(dbo.Product.ProductCategoryType, dbo.Product.ProductCategoryType, dbo.Product.ProductCategoryType).As("relevant")
                ).From(dbo.Product)
                .Where(dbo.Product.ProductCategoryType == dbex.Null);

            //when               
            IEnumerable<ProductCategoryType?> types = exp.Execute();

            //then
            types.Should().OnlyContain(x => x == null).And.HaveCount(expectedCount);
        }
    }
}
