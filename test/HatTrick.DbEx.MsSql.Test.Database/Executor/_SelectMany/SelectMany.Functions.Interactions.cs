using DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Extensions.Builder;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Function", "CAST")]
    [Trait("Function", "COALESCE")]
    public partial class CastAndCoalesce : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_cast_of_ship_date_to_varchar_succeed(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.Cast(db.Coalesce(dbo.Purchase.ShipDate, db.Literal(DateTime.Parse("1/1/2010")))).AsVarChar(50)
                ).From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_cast_of_gendertype_to_int_and_personid(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.Coalesce(db.Cast(dbo.Person.GenderType).AsInt(), dbo.Person.Id)
                ).From(dbo.Person);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }
    }

    [Trait("Function", "CAST")]
    [Trait("Function", "CONCAT")]
    public partial class ConcatAndCast : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_concat_of_ship_date_to_varchar_succeed(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.Concat(db.Literal("Shipped On: "), db.Cast(dbo.Purchase.ShipDate).AsVarChar(50))
                ).From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_concat_of_literal_and_purchaseid_to_varchar_succeed(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.Concat(db.Literal("1"), db.Cast(dbo.Purchase.Id).AsVarChar(50))
                ).From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }
    }

    [Trait("Function", "CAST")]
    [Trait("Function", "ISNULL")]
    public partial class CastAndIsNull : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_cast_of_isnull_of_shipdate_and_purchasedate_to_varchar_succeed(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.Cast(db.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate)).AsVarChar(50)
                ).From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_cast_of_isnull_of_birthdate_and_datecreated_and_cast_to_varchar_succeed(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.Cast(db.IsNull(dbo.Person.BirthDate, dbo.Person.DateCreated)).AsVarChar(50)
                ).From(dbo.Person);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_cast_of_isnull_of_birthdate_and_literal_date_and_cast_to_varchar_succeed(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.Cast(db.IsNull(dbo.Person.BirthDate, db.Literal(DateTime.Parse("1/1/2020")))).AsVarChar(50)
                ).From(dbo.Person);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }
    }
}
