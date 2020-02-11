using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Builder;
using System;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "COALESCE")]
    public partial class Coalesce : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_coalesceing_ship_date_and_purchase_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IList<DateTime> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_coalesceing_all_product_dates_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Coalesce(
                        dbo.Purchase.ShipDate,
                        dbo.Purchase.PurchaseDate
                    ).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IList<DateTime> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        //MEDIATOR
        //[Theory]
        //[MsSqlVersions.AllVersions]
        //[Trait("Expression", "Arithmetic")]
        //public void Does_coalesceing_ship_date_and_getdate_plus_purchase_date_succeed(int version, int expected = 15)
        //{
        //    //given
        //    ConfigureForMsSqlVersion(version);

        //    var exp = db.SelectMany(
        //            dbo.Purchase.TotalPurchaseAmount,
        //            db.fx.Coalesce(
        //                dbo.Purchase.ShipDate,
        //                db.fx.GetDate() + dbo.Purchase.PurchaseDate
        //            ).As("relevant_date")
        //        ).From(dbo.Purchase);

        //    //when               
        //    IList<dynamic> dates = exp.Execute();

        //    //then
        //    dates.Should().HaveCount(expected);
        //}

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_coalesceing_ship_date_and_static_value_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Coalesce(
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
        public void Does_coalesceing_ship_date_and_expected_delivery_date_and_static_value_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Coalesce(
                        dbo.Purchase.ShipDate,
                        dbo.Purchase.ExpectedDeliveryDate,
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
        public void Does_coalesceing_ship_date_and_expected_delivery_date_and_static_null_value_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Coalesce(
                        dbo.Purchase.ShipDate,
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
        public void Does_coalesceing_ship_date_and_expected_delivery_date_and_static_non_null_value_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Coalesce(
                        dbo.Purchase.ShipDate,
                        dbo.Purchase.ExpectedDeliveryDate,
                        (DateTime?)DateTime.Now
                    ).As("relevant_date")
                ).From(dbo.Purchase);

            //when               
            IList<DateTime?> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_coalesce_of_ship_date_and_purchase_date_ascending_succeed(int version, int expected = 2017)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate));

            //when               
            DateTime result = exp.Execute();

            //then
            result.Year.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_coalesce_of_ship_date_and_purchase_date_descending_succeed(int version, int expected = 2017)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).Desc);

            //when               
            DateTime result = exp.Execute();

            //then
            result.Year.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_coalesce_of_ship_date_and_purchase_date_ascending_and_aliasing_succeed(int version, int expected = 2017)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate));

            //when               
            DateTime result = exp.Execute();

            //then
            result.Year.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_coalesce_of_ship_date_and_purchase_date_descending_and_aliasing_succeed(int version, int expected = 2017)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                   db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).Desc);

            //when               
            DateTime result = exp.Execute();

            //then
            result.Year.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_group_by_coalesce_of_ship_date_and_purchase_date_descending_succeed(int version, int expected = 5)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate)
                ).From(dbo.Purchase)
                .GroupBy(db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate));

            //when               
            IList<DateTime> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_group_by_coalesce_of_ship_date_and_purchase_date_descending_and_aliasing_succeed(int version, int expected = 5)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).As("relevant_date")
                ).From(dbo.Purchase)
                .GroupBy(db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate));

            //when               
            IList<DateTime> dates = exp.Execute();

            //then
            dates.Should().HaveCount(expected);
        }
    }
}
