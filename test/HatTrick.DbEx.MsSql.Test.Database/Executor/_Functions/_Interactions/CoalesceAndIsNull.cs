using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Function", "COALESCE")]
    [Trait("Function", "ISNULL")]
    public partial class CoalesceAndIsNull : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_isnull_of_ship_date_and_expected_delivery_date_and_static_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Coalesce(db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.ExpectedDeliveryDate), DateTime.Now)
                ).From(dbo.Purchase);

            //when               
            IList<DateTime> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.All(p => p != DateTime.MinValue).Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_isnull_of_coalesce_of_shipdate_and_purchasedate_and_static_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.IsNull(dbo.Purchase.ShipDate, db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.ExpectedDeliveryDate, DateTime.Now))
                ).From(dbo.Purchase);

            //when               
            IList<DateTime> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.All(p => p != DateTime.MinValue).Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_isnull_of_ship_date_and_expected_delivery_date_and_null_static_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Coalesce(db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.ExpectedDeliveryDate), (DateTime?)null)
                ).From(dbo.Purchase);

            //when               
            IList<DateTime?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.All(p => p != DateTime.MinValue).Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_isnull_of_coalesce_of_shipdate_and_purchasedate_and_static_null_date_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.IsNull(dbo.Purchase.ShipDate, db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.ExpectedDeliveryDate, (DateTime?)null))
                ).From(dbo.Purchase);

            //when               
            IList<DateTime?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.All(p => p != DateTime.MinValue).Should().BeTrue();
        }
    }
}
