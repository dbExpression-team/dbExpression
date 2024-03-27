using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Expression;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Function", "COUNT")]
    [Trait("Function", "DATEPART")]
    public partial class CountAndDatePartTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(15)]
        public void Does_selecting_count_of_datepart_of_purchase_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Count(db.fx.DatePart(DateParts.Hour, dbo.Purchase.PurchaseDate))
                ).From(dbo.Purchase);

            //when               
            int count = exp.Execute();

            //then
            count.Should().Be(expected);
        }

        [Theory]
        [InlineData(12)]
        public void Does_selecting_count_of_datepart_of_ship_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Count(db.fx.DatePart(DateParts.Hour, dbo.Purchase.ShipDate))
                ).From(dbo.Purchase);

            //when               
            int count = exp.Execute();

            //then
            count.Should().Be(expected);
        }
    }
}
