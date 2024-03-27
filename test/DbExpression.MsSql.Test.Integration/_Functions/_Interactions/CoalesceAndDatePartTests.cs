using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Expression;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using System.Collections.Generic;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Function", "COALESCE")]
    [Trait("Function", "DATEPART")]
    public partial class CoalesceAndDatePartTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(15)]
        public void Does_selecting_datepart_of_day_of_coalesce_of_ship_date_and_purchase_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.DatePart(DateParts.Day, db.fx.Coalesce<DateTime>(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate))
                ).From(dbo.Purchase);

            //when               
            IEnumerable<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_selecting_coalesce_of_year_datepart_of_ship_date_and_expected_delivery_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce<int>(db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate), db.fx.DatePart(DateParts.Year, dbo.Purchase.ExpectedDeliveryDate), 1)
                ).From(dbo.Purchase);

            //when               
            IEnumerable<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_selecting_coalesce_of_day_datepart_of_ship_date_and_expected_delivery_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce<int>(db.fx.DatePart(DateParts.Day, dbo.Purchase.ShipDate), db.fx.DatePart(DateParts.Year, dbo.Purchase.ExpectedDeliveryDate), 1)
                ).From(dbo.Purchase);

            //when               
            IEnumerable<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_selecting_datepart_of_day_of_coalesce_of_ship_date_and_expected_delivery_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.DatePart(DateParts.Day, db.fx.Coalesce<DateTime?>(dbo.Purchase.ShipDate, dbo.Purchase.ExpectedDeliveryDate))
                ).From(dbo.Purchase);

            //when               
            IEnumerable<int?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }
    }
}
