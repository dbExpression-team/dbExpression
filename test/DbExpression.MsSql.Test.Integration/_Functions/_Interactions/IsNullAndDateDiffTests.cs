using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Expression;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System.Collections.Generic;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Function", "ISNULL")]
    [Trait("Function", "DATEDIFF")]
    public partial class IsNullAndDateDiffTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(15)]
        public void Does_selecting_isnull_of_datediff_of_purchase_date_and_ship_date_and_datepart_of_purchase_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.IsNull(db.fx.DateDiff(DateParts.Hour, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate), 1)
                ).From(dbo.Purchase);

            //when               
            IEnumerable<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_selecting_isnull_of_datediff_of_ship_date_and_purchase_date_and_ship_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.DateDiff(DateParts.Hour, db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate), dbo.Purchase.DateCreated)
                ).From(dbo.Purchase);

            //when               
            IEnumerable<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_selecting_isnull_of_datediff_of_purchase_date_and_expected_delivery_date_and_static_value_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.IsNull(db.fx.DateDiff(DateParts.Hour, dbo.Purchase.PurchaseDate, dbo.Purchase.ExpectedDeliveryDate), 1)
                ).From(dbo.Purchase);

            //when               
            IEnumerable<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(15)]
        public void Does_selecting_datediff_of_isnull_of_ship_date_and_expected_delivery_date_and_date_created_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.DateDiff(DateParts.Hour, db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.ExpectedDeliveryDate), dbo.Purchase.DateCreated)
                ).From(dbo.Purchase);

            //when               
            IEnumerable<int?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }
    }
}
