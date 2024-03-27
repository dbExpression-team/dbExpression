using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Expression;
using DbExpression.MsSql.Builder.Alias;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "DATEADD")]
    public partial class DateAddTests : ResetDatabaseNotRequired
    {
        [Theory]
        [Trait("Operation", "WHERE")]
        [InlineData(2020)]
        public void Does_dateadd_of_year_to_shipdate_succeed(int expectedValue)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            DateTime? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Year.Should().Be(expectedValue);
        }

        [Fact]
        [Trait("Operation", "WHERE")]
        public void Does_dateadd_of_year_to_null_shipdate_returning_datetime_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate == dbex.Null);

            //when               
            DateTime? result = exp.Execute();

            //then
            result.Should().BeNull();
        }

        [Fact]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_dateadd_of_year_to_null_ship_date_ascending_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate));

            //when               
            DateTime? result = exp.Execute();

            //then
            result.Should().BeNull();
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(2020)]
        public void Can_order_by_dateadd_of_year_to_null_ship_date_descending_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate).Desc());

            //when               
            DateTime? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Year.Should().Be(expected);
        }

        [Fact]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_dateadd_of_year_to_null_ship_date_ascending_and_aliasing_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate));

            //when               
            DateTime? result = exp.Execute();

            //then
            result.Should().BeNull();
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(2020)]
        public void Can_order_by_dateadd_of_year_to_null_ship_date_descending_and_aliasing_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate).Desc());

            //when               
            DateTime? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Year.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(2020)]
        public void Can_select_date_add_of_aliased_value(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.DateAdd(DateParts.Year, 1, ("other", "DateCreated")).As("alias")
                ).From(dbo.PurchaseLine)
                .InnerJoin(
                    db.SelectOne(
                        dbo.PurchaseLine.PurchaseId,
                        dbo.PurchaseLine.DateCreated
                    )
                    .From(dbo.PurchaseLine)
                    .OrderBy(dbo.PurchaseLine.Id)
                ).As("other").On(dbo.PurchaseLine.PurchaseId == ("other", "PurchaseId"));

            //when               
            DateTime? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Year.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(2020)]
        public void Can_select_date_add_of_aliased_value_and_aliased_field(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.DateAdd(DateParts.Year, ("other", "PurchaseId"), ("other", "DateCreated")).As("alias")
                ).From(dbo.PurchaseLine)
                .InnerJoin(
                    db.SelectOne(
                        dbo.PurchaseLine.PurchaseId,
                        dbo.PurchaseLine.DateCreated
                    )
                    .From(dbo.PurchaseLine)
                    .OrderBy(dbo.PurchaseLine.Id)
                ).As("other").On(dbo.PurchaseLine.PurchaseId == ("other", "PurchaseId"));

            //when               
            DateTime? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Year.Should().Be(expected);
        }
    }
}
