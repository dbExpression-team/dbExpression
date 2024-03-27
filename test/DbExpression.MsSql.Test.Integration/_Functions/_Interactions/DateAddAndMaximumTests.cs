using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Expression;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Function", "DATEADD")]
    [Trait("Function", "MAX")]
    public partial class DateAddAndMaximumTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(2020)]
        public void Does_selecting_maximum_of_dateadd_of_purchase_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Max(db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.PurchaseDate))
                ).From(dbo.Purchase);

            //when               
            DateTime result = exp.Execute();

            //then
            result.Year.Should().Be(expected);
        }

        [Theory]
        [InlineData(2020)]
        public void Does_selecting_maximum_of_dateadd_of_ship_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Max(db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate))
                ).From(dbo.Purchase);

            //when               
            DateTime? result = exp.Execute();

            //then
            result!.Value.Year.Should().Be(expected);
        }
    }
}
