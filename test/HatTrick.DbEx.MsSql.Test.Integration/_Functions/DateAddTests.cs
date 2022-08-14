using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Builder.Alias;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "DATEADD")]
    public partial class DateAddTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Does_dateadd_of_year_to_shipdate_succeed(int version, int expectedValue = 2020)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "WHERE")]
        public void Does_dateadd_of_year_to_null_shipdate_returning_datetime_succeed(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectOne(
                    db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate == dbex.Null);

            //when               
            DateTime? result = exp.Execute();

            //then
            result.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_dateadd_of_year_to_null_ship_date_ascending_succeed(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_dateadd_of_year_to_null_ship_date_descending_succeed(int version, int expected = 2020)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectOne(
                    db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate).Desc);

            //when               
            DateTime? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Year.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_dateadd_of_year_to_null_ship_date_ascending_and_aliasing_succeed(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_dateadd_of_year_to_null_ship_date_descending_and_aliasing_succeed(int version, int expected = 2020)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectOne(
                    db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate).Desc);

            //when               
            DateTime? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Year.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_select_date_add_of_aliased_value(int version, int expected = 2020)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_select_date_add_of_aliased_value_and_aliased_field(int version, int expected = 2020)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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
