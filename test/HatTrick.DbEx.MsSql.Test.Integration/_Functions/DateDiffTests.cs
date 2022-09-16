using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "DATEDIFF")]
    public partial class DateDiffTests : ResetDatabaseNotRequired
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Does_datediff_selecting_day_between_purchase_date_and_ship_date_succeed(int version, int expected = 7)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.Id == 1);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_datediff_selecting_day_between_purchase_date_and_ship_date_ascending_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate));

            //when               
            int? result = exp.Execute();

            //then
            result.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_datediff_selecting_day_between_purchase_date_and_ship_date_descending_succeed(int version, int expected = 7)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate).Desc);

            //when               
            int? result = exp.Execute();

            //then
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_datediff_selecting_day_between_purchase_date_and_ship_date_ascending_and_aliasing_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate));

            //when               
            int? result = exp.Execute();

            //then
            result!.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_datediff_selecting_day_between_purchase_date_and_ship_date_descending_and_aliasing_succeed(int version, int expected = 7)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate).Desc);

            //when               
            int? result = exp.Execute();

            //then
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Can_group_by_datediff_selecting_day_between_purchase_date_and_ship_date_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .GroupBy(db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate));

            //when               
            int? result = exp.Execute();

            //then
            result!.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Can_group_by_datediff_selecting_day_between_purchase_date_and_ship_date_and_aliasing_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate).As("alias")
                ).From(dbo.Purchase)
                .GroupBy(db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate));

            //when               
            int? result = exp.Execute();

            //then
            result!.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Can_datediff_of_aliased_field_succeed(int version, int expected = 7)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DateDiff(DateParts.Day, dbex.Alias<DateTime>("lines", "DateCreated"), dbo.Purchase.ShipDate).As("alias")
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectMany<PurchaseLine>().Top(100)
                    .From(dbo.PurchaseLine)
                    .OrderBy(dbo.PurchaseLine.PurchasePrice.Desc)
                ).As("lines").On(dbo.Purchase.Id == ("lines", "PurchaseId"));

            //when               
            int? result = exp.Execute();

            //then
            result!.Should().Be(expected);
        }
    }
}
