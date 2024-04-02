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
    [Trait("Function", "DATEADD")]
    public partial class CoalesceAndDateAddTests : ResetDatabaseNotRequired
    {
        [Theory]
        [Trait("Function", "CURRENT_TIMESTAMP")]
        [InlineData(15)]
        public void Does_selecting_coalesce_of_dateadd_of_ship_date_and_dateadd_of_purchase_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce<DateTime?>(db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ExpectedDeliveryDate), db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate), db.fx.Current_Timestamp)
                ).From(dbo.Purchase);

            //when               
            IEnumerable<DateTime?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Function", "GETUTCDATE")]
        [InlineData(15)]
        public void Does_selecting_coalesce_of_day_dateadd_of_ship_date_and_dataadd_of_purchase_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce<DateTime?>(db.fx.DateAdd(DateParts.Day, 1, dbo.Purchase.ExpectedDeliveryDate), db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate), db.fx.GetUtcDate())
                ).From(dbo.Purchase);

            //when               
            IEnumerable<DateTime?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }


        [Theory]
        [InlineData(15)]
        public void Does_selecting_dateadd_of_coalesce_of_expected_delivery_date_and_ship_date_and_purchase_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.DateAdd(DateParts.Year, 1, db.fx.Coalesce<DateTime>(dbo.Purchase.ExpectedDeliveryDate, dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate))
                ).From(dbo.Purchase);

            //when               
            IEnumerable<DateTime> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_selecting_dateadd_of_coalesce_of_ship_date_and_purchase_date_and_expected_delivery_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.DateAdd(DateParts.Year, 1, db.fx.Coalesce<DateTime?>(dbo.Purchase.ExpectedDeliveryDate, dbo.Purchase.ShipDate, dbo.Purchase.ExpectedDeliveryDate))
                ).From(dbo.Purchase);

            //when               
            IEnumerable<DateTime?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }
    }
}
