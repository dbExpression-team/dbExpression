using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using System;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "ISNULL")]
    public partial class IsNullTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(15)]
        public void Does_isnull_ship_date_and_purchase_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IEnumerable<DateTime> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_isnull_of_shipdate_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.IsNull(
                        dbo.Purchase.ShipDate,
                        DateTime.Now
                    ).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IEnumerable<DateTime> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_isnull_of_expecteddeliverydate_and_shipdate_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.IsNull(
                        dbo.Purchase.ExpectedDeliveryDate,
                        dbo.Purchase.ShipDate
                    ).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IEnumerable<DateTime?> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_isnull_of_expecteddeliverydate_and_null_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.IsNull(
                        dbo.Purchase.ExpectedDeliveryDate,
                        (DateTime?)null
                    ).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IEnumerable<DateTime?> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_isnull_all_product_dates_and_returning_total_purchase_amount_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Purchase.TotalPurchaseAmount,
                    db.fx.IsNull(
                        dbo.Purchase.ShipDate,
                        dbo.Purchase.PurchaseDate
                    ).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IEnumerable<dynamic> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Expression", "Arithmetic")]
        [InlineData(15)]
        public void Does_isnull_all_product_dates_including_arithmetic_and_returning_total_purchase_amount_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    dbo.Purchase.TotalPurchaseAmount,
                    db.fx.IsNull(
                        dbo.Purchase.ShipDate,
                        dbo.Purchase.DateCreated + DateTime.Now
                    ).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IEnumerable<dynamic> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(32)]
        public void Does_isnull_address_type_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.IsNull(
                        dbo.Address.AddressType,
                        AddressType.Billing
                    ).As("address_type")
                ).From(dbo.Address);

            //when               
            IEnumerable<AddressType> addresses = exp.Execute();

            //then
            addresses.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(2019)]
        public void Can_order_by_isnull_of_ship_date_and_purchase_date_ascending_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate));

            //when               
            DateTime result = exp.Execute();

            //then
            result.Year.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(2019)]
        public void Can_order_by_isnull_of_ship_date_and_purchase_date_descending_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).Desc());

            //when               
            DateTime result = exp.Execute();

            //then
            result.Year.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(2019)]
        public void Can_order_by_isnull_of_ship_date_and_purchase_date_ascending_and_aliasing_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate));

            //when               
            DateTime result = exp.Execute();

            //then
            result.Year.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(2019)]
        public void Can_order_by_isnull_of_ship_date_and_purchase_date_descending_and_aliasing_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                   db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).Desc());

            //when               
            DateTime result = exp.Execute();

            //then
            result.Year.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData(2019)]
        public void Can_group_by_isnull_of_ship_date_and_purchase_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate)
                ).From(dbo.Purchase)
                .GroupBy(db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate));

            //when               
            DateTime result = exp.Execute();

            //then
            result.Year.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData(2019)]
        public void Can_group_by_isnull_of_ship_date_and_purchase_date_and_aliasing_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).As("alias")
                ).From(dbo.Purchase)
                .GroupBy(db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate));

            //when               
            DateTime result = exp.Execute();

            //then
            result.Year.Should().Be(expected);
        }

        [Theory]
        [InlineData(36)]
        public void Does_arithmetic_order_of_precedence_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    (dbo.Purchase.TotalPurchaseAmount + 2) * 3
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.TotalPurchaseAmount == 10);

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }
    }
}
