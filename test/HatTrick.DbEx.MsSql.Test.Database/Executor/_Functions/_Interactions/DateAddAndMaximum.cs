using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Function", "DATEADD")]
    [Trait("Function", "MAX")]
    public partial class DateAddAndMaximum : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_maximum_of_dateadd_of_purchase_date_succeed(int version, int expected = 2020)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Max(db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.PurchaseDate))
                ).From(dbo.Purchase);

            //when               
            DateTime result = exp.Execute();

            //then
            result.Year.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_maximum_of_dateadd_of_ship_date_succeed(int version, int expected = 2020)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
