using DbEx.Data;
using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
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
    public partial class IsNullTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_isnull_ship_date_and_purchase_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IList<DateTime> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_isnull_of_shipdate_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.IsNull(
                        dbo.Purchase.ShipDate,
                        DateTime.Now
                    ).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IList<DateTime> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_isnull_of_expecteddeliverydate_and_shipdate_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.IsNull(
                        dbo.Purchase.ExpectedDeliveryDate,
                        dbo.Purchase.ShipDate
                    ).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IList<DateTime?> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_isnull_of_expecteddeliverydate_and_null_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.IsNull(
                        dbo.Purchase.ExpectedDeliveryDate,
                        (DateTime?)null
                    ).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IList<DateTime?> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_isnull_all_product_dates_and_returning_total_purchase_amount_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    dbo.Purchase.TotalPurchaseAmount,
                    db.fx.IsNull(
                        dbo.Purchase.ShipDate,
                        dbo.Purchase.PurchaseDate
                    ).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IList<dynamic> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Expression", "Arithmetic")]
        public void Does_isnull_all_product_dates_including_arithmetic_and_returning_total_purchase_amount_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    dbo.Purchase.TotalPurchaseAmount,
                    db.fx.IsNull(
                        dbo.Purchase.ShipDate,
                        dbo.Purchase.DateCreated + DateTime.Now
                    ).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IList<dynamic> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_isnull_address_type_succeed(int version, int expected = 32)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.IsNull(
                        dbo.Address.AddressType,
                        AddressType.Billing
                    ).As("address_type")
                ).From(dbo.Address);

            //when               
            IList<AddressType> addresses = exp.Execute();

            //then
            addresses.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_isnull_of_ship_date_and_purchase_date_ascending_succeed(int version, int expected = 2019)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_isnull_of_ship_date_and_purchase_date_descending_succeed(int version, int expected = 2019)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).Desc);

            //when               
            DateTime result = exp.Execute();

            //then
            result.Year.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_isnull_of_ship_date_and_purchase_date_ascending_and_aliasing_succeed(int version, int expected = 2019)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_isnull_of_ship_date_and_purchase_date_descending_and_aliasing_succeed(int version, int expected = 2019)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                   db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).Desc);

            //when               
            DateTime result = exp.Execute();

            //then
            result.Year.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Can_group_by_isnull_of_ship_date_and_purchase_date_succeed(int version, int expected = 2019)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Can_group_by_isnull_of_ship_date_and_purchase_date_and_aliasing_succeed(int version, int expected = 2019)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        public void Does_arithmetic_order_of_precedence_succeed(int version, double expected = 36)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    (dbo.Purchase.TotalPurchaseAmount + 2) * 3
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.TotalPurchaseAmount == 10);

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Can_isnull_of_aliased_field_succeed(int version, decimal expected = 0m)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.IsNull(("lines", "PurchasePrice"), 0m).As("alias")
                ).From(dbo.Purchase)
                .LeftJoin(
                    db.SelectOne<PurchaseLine>()
                    .From(dbo.PurchaseLine)
                    .OrderBy(dbo.PurchaseLine.PurchasePrice.Desc)
                ).As("lines").On(dbo.Purchase.Id == ("lines", "PurchaseId"))
                .Where(dbo.Purchase.Id == 1);

            //when               
            decimal result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, 0.001m, "Rounding errors in isnull");
        }
    }
}
