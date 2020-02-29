using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Builder;
using System;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "CAST")]
    public partial class Cast : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_cast_of_ship_date_to_varchar_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Cast(dbo.Purchase.ShipDate).AsVarChar(50)
                ).From(dbo.Purchase);

            //when               
            IList<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_multiple_fields_and_casting_ship_date_to_varchar_succeed(int version, int expected = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    dbo.Purchase.Id,
                    db.fx.Cast(dbo.Purchase.ShipDate).AsVarChar(50)
                ).From(dbo.Purchase);

            //when               
            IList<dynamic> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_cast_of_purchase_date_to_varchar_ascending_succeed(int version, string expected = "Nov  1 2017")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50));

            //when               
            string result = exp.Execute();

            //then
            result.Should().StartWith(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_cast_of_purchase_date_to_varchar_descending_succeed(int version, string expected = "Nov  5 2017")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50).Desc);

            //when               
            string result = exp.Execute();

            //then
            result.Should().StartWith(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_cast_of_purchase_date_to_varchar_ascending_and_aliasing_succeed(int version, string expected = "Nov  1 2017")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50));

            //when               
            string result = exp.Execute();

            //then
            result.Should().StartWith(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_cast_of_purchase_date_to_varchar_descending_and_aliasing_succeed(int version, string expected = "Nov  5 2017")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50).Desc);

            //when               
            string result = exp.Execute();

            //then
            result.Should().StartWith(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Can_group_by_cast_of_purchase_date_to_varchar_ascending_succeed(int version, string expected = "Nov  1 2017")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50)
                ).From(dbo.Purchase)
                .GroupBy(db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50));

            //when               
            string result = exp.Execute();

            //then
            result.Should().StartWith(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Can_group_by_cast_of_purchase_date_to_varchar_ascending_and_aliasing_succeed(int version, string expected = "Nov  1 2017")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50).As("alias")
                ).From(dbo.Purchase)
                .GroupBy(db.fx.Cast(dbo.Purchase.PurchaseDate).AsVarChar(50));

            //when               
            string result = exp.Execute();

            //then
            result.Should().StartWith(expected);
        }
    }
}
