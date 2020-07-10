using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Function", "COALESECE")]
    [Trait("Function", "DATEDIFF")]
    public partial class CoalesceAndDateDiff : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_datediff_of_purchase_date_and_shipdate_and_datepart_of_purchase_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Coalesce(db.fx.DateDiff(DateParts.Hour, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate), db.fx.DatePart(DateParts.Hour, dbo.Purchase.PurchaseDate))
                ).From(dbo.Purchase);

            //when               
            IList<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_hour_datepart_of_shipdate_and_datadiff_of_purchase_date_and_ship_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Coalesce(db.fx.DatePart(DateParts.Hour, dbo.Purchase.ShipDate), db.fx.DateDiff(DateParts.Hour, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate), 1)
                ).From(dbo.Purchase);

            //when               
            IList<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }


        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datediff_of_hour_of_purchase_date_and_ship_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.DateCreated))
                ).From(dbo.Purchase);

            //when               
            IList<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datediff_of_hour_of_purchase_date_and_expected_delivery_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.ExpectedDeliveryDate))
                ).From(dbo.Purchase);

            //when               
            IList<int?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }
    }
}
