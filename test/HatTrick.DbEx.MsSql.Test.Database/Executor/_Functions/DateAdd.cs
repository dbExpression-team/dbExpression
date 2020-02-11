using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Builder;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "DATEADD")]
    [Trait("Operation", "WHERE")]
    public partial class DateAdd : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_dateadd_of_year_to_shipdate_succeed(int version, int expectedValue = 2018)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != DBNull.Value);

            //when               
            DateTime? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result.Value.Year.Should().Be(expectedValue);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_dateadd_of_year_to_null_shipdate_returning_datetime_succeed(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate == DBNull.Value);

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
            ConfigureForMsSqlVersion(version);

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
        public void Can_order_by_dateadd_of_year_to_null_ship_date_descending_succeed(int version, int expected = 2018)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate).Desc);

            //when               
            DateTime? result = exp.Execute();

            //then
            result.Value.Year.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_dateadd_of_year_to_null_ship_date_ascending_and_aliasing_succeed(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        public void Can_order_by_dateadd_of_year_to_null_ship_date_descending_and_aliasing_succeed(int version, int expected = 2018)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate).Desc);

            //when               
            DateTime? result = exp.Execute();

            //then
            result.Value.Year.Should().Be(expected);
        }

        //MILESTONE: Shared Parameters
        //[Theory]
        //[MsSqlVersions.AllVersions]
        //[Trait("Operation", "GROUP BY")]
        //public void Can_group_by_dateadd_of_year_to_null_ship_date_succeed(int version)
        //{
        //    //given
        //    ConfigureForMsSqlVersion(version);

        //    var exp = db.SelectOne(
        //            db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate)
        //        ).From(dbo.Purchase)
        //        .GroupBy(db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate));

        //    //when               
        //    DateTime? result = exp.Execute();

        //    //then
        //    result.Should().BeNull();
        //}

        //MILESTONE: Shared Parameters
        //[Theory]
        //[MsSqlVersions.AllVersions]
        //[Trait("Operation", "GROUP BY")]
        //public void Can_group_by_dateadd_of_year_to_null_ship_date_and_aliasing_succeed(int version, int expected = 2018)
        //{
        //    //given
        //    ConfigureForMsSqlVersion(version);

        //    var exp = db.SelectOne(
        //            db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate).As("alias")
        //        ).From(dbo.Purchase)
        //        .GroupBy(db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate));

        //    //when               
        //    DateTime? result = exp.Execute();

        //    //then
        //    result.Value.Year.Should().Be(expected);
        //}
    }
}
