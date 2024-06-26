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
    [Trait("Function", "CAST")]
    [Trait("Function", "DATEDIFF")]
    public partial class CastAndDateDiffTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(15)]
        public void Does_selecting_cast_of_datediff_of_purchasedate_and_shipdate_as_varchar_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Cast(db.fx.DateDiff(DateParts.Hour, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)).AsVarChar(50)
                ).From(dbo.Purchase);

            //when               
            IEnumerable<string?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_selecting_cast_of_datediff_of_purchasedate_and_purchasedate_as_varchar_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Cast(db.fx.DateDiff(DateParts.Hour, dbo.Purchase.PurchaseDate, dbo.Purchase.PurchaseDate)).AsVarChar(50)
                ).From(dbo.Purchase);

            //when               
            IEnumerable<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Function", "GETDATE")]
        [InlineData(50)]
        public void Does_selecting_datediff_of_getdate_and_cast_of_personId_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.DateDiff(DateParts.Hour, db.fx.GetDate(), db.fx.Cast(dbo.Person.Id).AsDateTime())
                ).From(dbo.Person);

            //when               
            IEnumerable<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Function", "GETDATE")]
        [InlineData(50)]
        public void Does_selecting_datediff_of_cast_of_personId_and_getdate_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.DateDiff(DateParts.Hour, db.fx.Cast(dbo.Person.Id).AsDateTime(), db.fx.GetDate())
                ).From(dbo.Person);

            //when               
            IEnumerable<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Function", "GETUTCDATE")]
        [InlineData(50)]
        public void Does_selecting_datediff_of_getutcdate_and_cast_of_personId_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.DateDiff(DateParts.Hour, db.fx.GetUtcDate(), db.fx.Cast(dbo.Person.Id).AsDateTime())
                ).From(dbo.Person);

            //when               
            IEnumerable<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Function", "GETUTCDATE")]
        [InlineData(50)]
        public void Does_selecting_datediff_of_cast_of_personId_and_getutcdate_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.DateDiff(DateParts.Hour, db.fx.Cast(dbo.Person.Id).AsDateTime(), db.fx.GetUtcDate())
                ).From(dbo.Person);

            //when               
            IEnumerable<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_selecting_datediff_of_purchase_date_and_cast_of_personId_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.DateDiff(DateParts.Hour, dbo.Purchase.PurchaseDate, db.fx.Cast(dbo.Purchase.Id).AsDateTime())
                ).From(dbo.Purchase);

            //when               
            IEnumerable<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_selecting_datediff_of_ship_date_and_cast_of_personId_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.DateDiff(DateParts.Hour, dbo.Purchase.ShipDate, db.fx.Cast(dbo.Purchase.Id).AsDateTime())
                ).From(dbo.Purchase);

            //when               
            IEnumerable<int?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(1)]
        public void Does_selecting_datediff_of_purchase_date_and_ship_date_added_to_cast_of_personId_succeed(int expectedValue)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate) + db.fx.Cast(dbo.Purchase.Id).AsInt()
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(2019)]
        public void Does_datepart_of_ship_date_added_to_datediff_of_purchase_date_and_ship_date_succeed(int expectedValue)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate) + db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expectedValue);
        }
    }
}
