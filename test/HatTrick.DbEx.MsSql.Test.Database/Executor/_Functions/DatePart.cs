using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "DATEPART")]
    public partial class DatePart : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Does_datepart_selecting_year_of_purchase_date_succeed(int version, int expected = 2019)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != DBNull.Value);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Does_datepart_selecting_day_of_ship_date_succeed(int version, int expected = 8)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DatePart(DateParts.Day, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != DBNull.Value);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_datepart_selecting_year_of_purchase_date_ascending_succeed(int version, int expected = 2019)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate));

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_datepart_selecting_year_of_ship_date_descending_succeed(int version, int expected = 2019)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate).Desc);

            //when               
            int? result = exp.Execute();

            //then
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_datepart_selecting_year_of_purchase_date_and_aliasing_succeed(int version, int expected = 2019)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate));

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_datepart_selecting_year_of_ship_date_descending_and_aliasing_succeed(int version, int expected = 2019)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate).Desc);

            //when               
            int? result = exp.Execute();

            //then
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Can_group_by_datepart_selecting_year_of_ship_date_succeed(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .GroupBy(db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate));

            //when               
            int? result = exp.Execute();

            //then
            result.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Can_group_by_datepart_selecting_year_of_purchase_date_and_aliasing_succeed(int version, int expected = 2019)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("alias")
                ).From(dbo.Purchase)
                .GroupBy(db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate));

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Can_datepart_of_aliased_field_succeed(int version, int expected = 4)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DatePart(DateParts.Day, dbex.Alias<DateTime>("lines", "DateCreated")).As("alias")
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectMany<PurchaseLine>().Top(100)
                    .From(dbo.PurchaseLine)
                    .OrderBy(dbo.PurchaseLine.PurchasePrice.Desc)
                ).As("lines").On(dbo.Purchase.Id == ("lines", "PurchaseId"));

            //when               
            int? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }
    }
}
