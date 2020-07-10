using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Function", "DATEPART")]
    [Trait("Function", "MIN")]
    public partial class DatePartAndMinimum : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_minimum_of_year_datepart_of_purchase_date_succeed(int version, int expected = 2017)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Min(db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate))
                ).From(dbo.Purchase);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_minimum_of_year_datepart_of_ship_date_succeed(int version, int expected = 2017)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Min(db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate))
                ).From(dbo.Purchase);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }
    }
}
