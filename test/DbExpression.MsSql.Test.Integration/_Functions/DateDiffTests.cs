using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Expression;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "DATEDIFF")]
    public partial class DateDiffTests : ResetDatabaseNotRequired
    {
        [Theory]
        [Trait("Operation", "WHERE")]
        [InlineData(7)]
        public void Does_datediff_selecting_day_between_purchase_date_and_ship_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.Id == 1);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Fact]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_datediff_selecting_day_between_purchase_date_and_ship_date_ascending_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [Trait("Operation", "ORDER BY")]
        [InlineData(7)]
        public void Can_order_by_datediff_selecting_day_between_purchase_date_and_ship_date_descending_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate).Desc());

            //when               
            int? result = exp.Execute();

            //then
            result!.Value.Should().Be(expected);
        }

        [Fact]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_datediff_selecting_day_between_purchase_date_and_ship_date_ascending_and_aliasing_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [Trait("Operation", "ORDER BY")]
        [InlineData(7)]
        public void Can_order_by_datediff_selecting_day_between_purchase_date_and_ship_date_descending_and_aliasing_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate).Desc());

            //when               
            int? result = exp.Execute();

            //then
            result!.Value.Should().Be(expected);
        }

        [Fact]
        [Trait("Operation", "GROUP BY")]
        public void Can_group_by_datediff_selecting_day_between_purchase_date_and_ship_date_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .GroupBy(db.fx.DateDiff(DateParts.Day, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate));

            //when               
            int? result = exp.Execute();

            //then
            result!.Should().BeNull();
        }

        [Fact]
        [Trait("Operation", "GROUP BY")]
        public void Can_group_by_datediff_selecting_day_between_purchase_date_and_ship_date_and_aliasing_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
        [Trait("Operation", "SUBQUERY")]
        [InlineData(7)]
        public void Can_datediff_of_aliased_field_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.DateDiff(DateParts.Day, dbex.Alias<DateTime>("lines", "DateCreated"), dbo.Purchase.ShipDate).As("alias")
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectMany<PurchaseLine>().Top(100)
                    .From(dbo.PurchaseLine)
                    .OrderBy(dbo.PurchaseLine.PurchasePrice.Desc())
                ).As("lines").On(dbo.Purchase.Id == ("lines", "PurchaseId"));

            //when               
            int? result = exp.Execute();

            //then
            result!.Should().Be(expected);
        }
    }
}
