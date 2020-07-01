using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Function", "COALESECE")]
    [Trait("Function", "DATEADD")]
    public partial class CoalesceAndDateAdd : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Function", "CURRENT_TIMESTAMP")]
        public void Does_selecting_coalesce_of_dateadd_of_ship_date_and_dateadd_of_purchase_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Coalesce(db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ExpectedDeliveryDate), db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate), db.fx.Current_Timestamp)
                ).From(dbo.Purchase);

            //when               
            IList<DateTime> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Function", "GETUTCDATE")]
        public void Does_selecting_coalesce_of_day_dateadd_of_ship_date_and_dataadd_of_purchase_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Coalesce(db.fx.DateAdd(DateParts.Day, 1, dbo.Purchase.ExpectedDeliveryDate), db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate), db.fx.GetUtcDate())
                ).From(dbo.Purchase);

            //when               
            IList<DateTime> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }


        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_dateadd_of_coalesce_of_expected_delivery_date_and_ship_date_and_purchase_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.DateAdd(DateParts.Year, 1, db.fx.Coalesce(dbo.Purchase.ExpectedDeliveryDate, dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate))
                ).From(dbo.Purchase);

            //when               
            IList<DateTime> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_dateadd_of_coalesce_of_ship_date_and_purchase_date_and_expected_delivery_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.DateAdd(DateParts.Year, 1, db.fx.Coalesce(dbo.Purchase.ExpectedDeliveryDate, dbo.Purchase.ShipDate, dbo.Purchase.ExpectedDeliveryDate))
                ).From(dbo.Purchase);

            //when               
            IList<DateTime?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }
    }
}
