using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Function", "ISNULL")]
    [Trait("Function", "DATEADD")]
    public partial class IsNullAndDateAddTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_isnull_of_dateadd_of_ship_date_and_dateadd_of_purchase_date_succeed(int version, int expected = 15)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.IsNull(db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate), db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.PurchaseDate))
                ).From(dbo.Purchase);

            //when               
            IList<DateTime> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_dateadd_of_isnull_of_ship_date_and_purchase_date_succeed(int version, int expected = 15)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.DateAdd(DateParts.Day, 1, db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate))
                ).From(dbo.Purchase);

            //when               
            IList<DateTime> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_isnull_of_year_dateadd_of_ship_date_and_dateadd_of_expected_delivery_date_succeed(int version, int expected = 15)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.IsNull(db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate), db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ExpectedDeliveryDate))
                ).From(dbo.Purchase);

            //when               
            IList<DateTime?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_isnull_of_day_datepart_of_ship_date_and_dateadd_of_expected_delivery_date_succeed(int version, int expected = 15)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.IsNull(db.fx.DateAdd(DateParts.Day, 1, dbo.Purchase.ShipDate), db.fx.DateAdd(DateParts.Day, 1, dbo.Purchase.ExpectedDeliveryDate))
                ).From(dbo.Purchase);

            //when               
            IList<DateTime?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_day_datepart_of_isnull_of_ship_date_and_dateadd_of_expected_delivery_date_succeed(int version, int expected = 15)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.DateAdd(DateParts.Day, 1, db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.ExpectedDeliveryDate))
                ).From(dbo.Purchase);

            //when               
            IList<DateTime?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }
    }
}
