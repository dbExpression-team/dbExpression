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
    [Trait("Function", "DATEADD")]
    [Trait("Function", "DATEPART")]
    public partial class DateAddAndDatePart : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_dateadd_of_datepart_of_ship_date_and_purchase_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.DateAdd(DateParts.Year, db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate), dbo.Purchase.PurchaseDate)
                ).From(dbo.Purchase);

            //when               
            IList<DateTime?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_dateadd_of_datepart_of_purchase_date_and_ship_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.DateAdd(DateParts.Year, db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate), dbo.Purchase.ShipDate)
                ).From(dbo.Purchase);

            //when               
            IList<DateTime?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_dateadd_of_datepart_of_purchase_date_and_date_created_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.DateAdd(DateParts.Year, db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate), dbo.Purchase.DateCreated)
                ).From(dbo.Purchase);

            //when               
            IList<DateTime> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_dateadd_of_datepart_of_ship_date_and_date_created_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.DateAdd(DateParts.Year, db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate), dbo.Purchase.DateCreated)
                ).From(dbo.Purchase);

            //when               
            IList<DateTime?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datepart_of_dateadd_of_ship_date_and_purchase_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.DatePart(DateParts.Day, db.fx.DateAdd(DateParts.Day, 1, dbo.Purchase.PurchaseDate))
                ).From(dbo.Purchase);

            //when               
            IList<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datepart_of_dateadd_of_ship_date_and_ship_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.DatePart(DateParts.Day, db.fx.DateAdd(DateParts.Day, 1, dbo.Purchase.ShipDate))
                ).From(dbo.Purchase);

            //when               
            IList<int?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }
    }
}
