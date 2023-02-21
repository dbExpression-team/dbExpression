using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Function", "AVG")]
    [Trait("Function", "DATEDIFF")]
    public partial class AverageAndDateDiffTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(168)]
        public void Does_selecting_average_of_datediff_of_purchasedate_and_shipdate_and_datepart_of_purchasedate_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Avg(db.fx.DateDiff(DateParts.Hour, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                ).From(dbo.Purchase);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }
    }
}
