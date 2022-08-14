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
    [Trait("Function", "DATEPART")]
    public partial class CountAndDatePartTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_count_of_datepart_of_purchase_date_succeed(int version, int expected = 15)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectOne(
                    db.fx.Count(db.fx.DatePart(DateParts.Hour, dbo.Purchase.PurchaseDate))
                ).From(dbo.Purchase);

            //when               
            int count = exp.Execute();

            //then
            count.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_count_of_datepart_of_ship_date_succeed(int version, int expected = 12)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

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
