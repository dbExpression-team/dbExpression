using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Function", "COALESCE")]
    [Trait("Function", "ISNULL")]
    public partial class CoalesceAndIsNullTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(15)]
        public void Does_selecting_coalesce_of_isnull_of_ship_date_and_expected_delivery_date_and_static_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce<DateTime>(db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.ExpectedDeliveryDate), DateTime.Now)
                ).From(dbo.Purchase);

            //when               
            IEnumerable<DateTime> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.All(p => p != DateTime.MinValue).Should().BeTrue();
        }

        [Theory]
        [InlineData(15)]
        public void Does_selecting_isnull_of_coalesce_of_shipdate_and_purchasedate_and_static_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.IsNull(dbo.Purchase.ShipDate, db.fx.Coalesce<DateTime>(dbo.Purchase.ShipDate, dbo.Purchase.ExpectedDeliveryDate, DateTime.Now))
                ).From(dbo.Purchase);

            //when               
            IEnumerable<DateTime> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.All(p => p != DateTime.MinValue).Should().BeTrue();
        }

        [Theory]
        [InlineData(15)]
        public void Does_selecting_coalesce_of_isnull_of_ship_date_and_expected_delivery_date_and_null_static_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce<DateTime?>(db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.ExpectedDeliveryDate), (DateTime?)null!)
                ).From(dbo.Purchase);

            //when               
            IEnumerable<DateTime?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.All(p => p != DateTime.MinValue).Should().BeTrue();
        }

        [Theory]
        [InlineData(15)]
        public void Does_selecting_isnull_of_coalesce_of_shipdate_and_purchasedate_and_static_null_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.IsNull(dbo.Purchase.ShipDate, db.fx.Coalesce<DateTime?>(dbo.Purchase.ShipDate, dbo.Purchase.ExpectedDeliveryDate, (DateTime?)null!))
                ).From(dbo.Purchase);

            //when               
            IEnumerable<DateTime?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
            results.All(p => p != DateTime.MinValue).Should().BeTrue();
        }
    }
}
