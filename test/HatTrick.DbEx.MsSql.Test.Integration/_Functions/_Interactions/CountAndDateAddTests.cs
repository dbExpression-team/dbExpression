using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Function", "COUNT")]
    [Trait("Function", "DATEADD")]
    public partial class CountAndDateAddTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_count_of_dateadd_of_purchase_date_succeed(int version, int expected = 15)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Count(db.fx.DateAdd(DateParts.Hour, 1, dbo.Purchase.PurchaseDate))
                ).From(dbo.Purchase);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_count_of_dateadd_of_ship_date_succeed(int version, int expected = 12)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Count(db.fx.DateAdd(DateParts.Hour, 1, dbo.Purchase.ShipDate))
                ).From(dbo.Purchase);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }
    }
}
