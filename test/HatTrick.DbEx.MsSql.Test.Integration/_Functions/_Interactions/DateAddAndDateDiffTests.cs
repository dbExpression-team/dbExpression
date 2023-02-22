using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Function", "DATEADD")]
    [Trait("Function", "DATEDIFF")]
    public partial class DateAddAndDateDiffTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(15)]
        public void Does_selecting_datediff_of_dateadd_of_ship_date_and_purchase_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.DateDiff(DateParts.Year, db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate), dbo.Purchase.PurchaseDate)
                ).From(dbo.Purchase);

            //when               
            IEnumerable<int?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_selecting_datediff_of_dateadd_of_purcchase_date_and_ship_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.DateDiff(DateParts.Year, db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.PurchaseDate), dbo.Purchase.ShipDate)
                ).From(dbo.Purchase);

            //when               
            IEnumerable<int?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_selecting_datediff_of_dateadd_of_purcchase_date_and_date_created_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.DateDiff(DateParts.Year, db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.PurchaseDate), dbo.Purchase.DateCreated)
                ).From(dbo.Purchase);

            //when               
            IEnumerable<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }
    }
}
