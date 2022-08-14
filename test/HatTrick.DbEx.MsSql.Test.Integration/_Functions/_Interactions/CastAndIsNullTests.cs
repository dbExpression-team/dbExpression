using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Function", "CAST")]
    [Trait("Function", "ISNULL")]
    public partial class CastAndIsNullTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_cast_of_isnull_of_shipdate_and_purchasedate_to_varchar_succeed(int version, int expected = 15)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(
                    db.fx.Cast(db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate)).AsVarChar(50)
                ).From(dbo.Purchase);

            //when               
            IList<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_cast_of_isnull_of_birthdate_and_datecreated_and_cast_to_varchar_succeed(int version, int expected = 50)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(
                    db.fx.Cast(db.fx.IsNull(dbo.Person.BirthDate, dbo.Person.DateCreated)).AsVarChar(50)
                ).From(dbo.Person);

            //when               
            IList<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_cast_of_isnull_of_ship_date_and_literal_date_and_cast_to_varchar_succeed(int version, int expected = 15)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(
                    db.fx.Cast(db.fx.IsNull(dbo.Purchase.ShipDate, DateTime.Parse("1/1/2020"))).AsVarChar(50)
                ).From(dbo.Purchase);

            //when               
            IList<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_isnull_of_cast_of_quantity_to_varchar_succeed(int version, int expected = 15)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectMany(
                    db.fx.IsNull(db.fx.Cast(dbo.Purchase.ShipDate).AsVarChar(50), "foo")
                ).From(dbo.Purchase);

            //when               
            IList<string> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }
    }
}
