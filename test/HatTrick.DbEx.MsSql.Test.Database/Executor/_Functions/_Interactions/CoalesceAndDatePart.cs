using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Function", "COALESECE")]
    [Trait("Function", "DATEPART")]
    public partial class CoalesceAndDatePart : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datepart_of_day_of_coalesce_of_ship_date_and_purchase_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.DatePart(DateParts.Day, db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate))
                ).From(dbo.Purchase);

            //when               
            IList<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_year_datepart_of_ship_date_and_expected_delivery_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Coalesce(db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate), db.fx.DatePart(DateParts.Year, dbo.Purchase.ExpectedDeliveryDate), 1)
                ).From(dbo.Purchase);

            //when               
            IList<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_day_datepart_of_ship_date_and_expected_delivery_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Coalesce(db.fx.DatePart(DateParts.Day, dbo.Purchase.ShipDate), db.fx.DatePart(DateParts.Year, dbo.Purchase.ExpectedDeliveryDate), 1)
                ).From(dbo.Purchase);

            //when               
            IList<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datepart_of_day_of_coalesce_of_ship_date_and_expected_delivery_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.DatePart(DateParts.Day, db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.ExpectedDeliveryDate))
                ).From(dbo.Purchase);

            //when               
            IList<int?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }
    }
}
