using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
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
                    db.fx.Cast(db.fx.Coalesce(dbo.Purchase.ShipDate, db.fx.Literal(DateTime.Parse("1/1/2010")))).AsVarChar(50)
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
                    db.fx.Coalesce(db.fx.Cast(dbo.Person.GenderType).AsInt(), dbo.Person.Id)
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
                    db.fx.Concat(db.fx.Literal("Shipped On: "), db.fx.Cast(dbo.Purchase.ShipDate).AsVarChar(50))
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
                    db.fx.Concat(db.fx.Literal("1"), db.fx.Cast(dbo.Purchase.Id).AsVarChar(50))
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
                    db.fx.Cast(db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate)).AsVarChar(50)
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
                    db.fx.Cast(db.fx.IsNull(dbo.Person.BirthDate, dbo.Person.DateCreated)).AsVarChar(50)
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
                    db.fx.Cast(db.fx.IsNull(dbo.Person.BirthDate, db.fx.Literal(DateTime.Parse("1/1/2020")))).AsVarChar(50)
                ).From(dbo.Person);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }
    }

    [Trait("Function", "CAST")]
    [Trait("Function", "DATEPART")]
    public partial class CastAndDatePart : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_cast_of_year_datepart_of_shipdate_as_varchar_succeed(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Cast(db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate)).AsVarChar(50)
                ).From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_year_datepart_of_and_cast_of_personId_succeed(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<int>(
                    db.fx.DatePart(DateParts.Year, db.fx.Cast(dbo.Person.Id).AsDateTime())
                ).From(dbo.Person);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }
    }

    [Trait("Function", "ISNULL")]
    [Trait("Function", "DATEPART")]
    public partial class IsNullAndDatePart : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_isnull_of_year_datepart_of_shipdate_and_purchasedate_succeed(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.IsNull(db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate), db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate))
                ).From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_isnull_of_day_datepart_of_shipdate_and_purchasedate_succeed(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.IsNull(db.fx.DatePart(DateParts.Day, dbo.Purchase.ShipDate), db.fx.DatePart(DateParts.Day, dbo.Purchase.PurchaseDate))
                ).From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }
    }

    [Trait("Function", "COALESECE")]
    [Trait("Function", "DATEPART")]
    public partial class CoalesceAndDatePart : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_year_datepart_of_shipdate_and_purchasedate_succeed(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<int>(
                    db.fx.Coalesce(db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate), db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate), db.fx.Literal(1))
                ).From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_day_datepart_of_shipdate_and_purchasedate_succeed(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<int>(
                    db.fx.Coalesce(db.fx.DatePart(DateParts.Day, dbo.Purchase.ShipDate), db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate), db.fx.Literal(1))
                ).From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }
    }

    [Trait("Function", "CAST")]
    [Trait("Function", "DATEADD")]
    public partial class CastAndDateAdd : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_cast_of_dateadd_of_shipdate_as_varchar_succeed(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Cast(db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate)).AsVarChar(50)
                ).From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_dateadd_to_cast_of_personId_succeed(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<DateTime>(
                    db.fx.DateAdd(DateParts.Year, 1, db.fx.Cast(dbo.Person.Id).AsDateTime())
                ).From(dbo.Person);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }
    }

    [Trait("Function", "ISNULL")]
    [Trait("Function", "DATEADD")]
    public partial class IsNullAndDateAdd : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_isnull_of_year_dateadd_of_shipdate_and_dateadd_of_purchasedate_succeed(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.IsNull(db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate), db.fx.DateAdd(DateParts.Year,1,  dbo.Purchase.PurchaseDate))
                ).From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_isnull_of_day_datepart_of_shipdate_and_dateadd_of_purchasedate_succeed(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.IsNull(db.fx.DateAdd(DateParts.Day, 1, dbo.Purchase.ShipDate), db.fx.DateAdd(DateParts.Day, 1, dbo.Purchase.PurchaseDate))
                ).From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }
    }

    [Trait("Function", "COALESECE")]
    [Trait("Function", "DATEADD")]
    public partial class CoalesceAndDateAdd : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Function", "CURRENT_TIMESTAMP")]
        public void Does_selecting_coalesce_of_dateadd_of_shipdate_and_dateadd_of_purchasedate_succeed(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<DateTime>(
                    db.fx.Coalesce(db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.ShipDate), db.fx.DateAdd(DateParts.Year, 1, dbo.Purchase.PurchaseDate), db.fx.Current_Timestamp)
                ).From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Function", "GETUTCDATE")]
        public void Does_selecting_coalesce_of_day_dateadd_of_shipdate_and_dataadd_of_purchasedate_succeed(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<DateTime>(
                    db.fx.Coalesce(db.fx.DateAdd(DateParts.Day, 1, dbo.Purchase.ShipDate), db.fx.DateAdd(DateParts.Day, 1, dbo.Purchase.PurchaseDate), db.fx.GetUtcDate())
                ).From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }
    }

    [Trait("Function", "CAST")]
    [Trait("Function", "DATEDIFF")]
    public partial class CastAndDateDiff : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_cast_of_datediff_of_purchasedate_and_shipdate_as_varchar_succeed(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.Cast(db.fx.DateDiff(DateParts.Hour, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)).AsVarChar(50)
                ).From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Function", "GETDATE")]
        public void Does_selecting_datediff_to_cast_of_personId_succeed(int version, int expectedCount = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<int>(
                    db.fx.DateDiff(DateParts.Hour, db.fx.GetDate(), db.fx.Cast(dbo.Person.Id).AsDateTime())
                ).From(dbo.Person);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }
    }

    [Trait("Function", "ISNULL")]
    [Trait("Function", "DATEDIFF")]
    public partial class IsNullAndDateDiff : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_isnull_of_datediff_of_purchasedate_and_shipdate_and_datepart_of_purchasedate_succeed(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.IsNull(db.fx.DateDiff(DateParts.Hour, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate), db.fx.DatePart(DateParts.Hour, dbo.Purchase.PurchaseDate))
                ).From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_isnull_of_datepart_of_shipdate_and_datediff_of_purchasedate_and_shipdate_succeed(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany(
                    db.fx.IsNull(db.fx.DatePart(DateParts.Hour, dbo.Purchase.ShipDate), db.fx.DateDiff(DateParts.Hour, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                ).From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }
    }

    [Trait("Function", "COALESECE")]
    [Trait("Function", "DATEDIFF")]
    public partial class CoalesceAndDateDiff : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_datediff_of_purchasedate_and_shipdate_and_datepart_of_purchasedate_succeed(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<int>(
                    db.fx.Coalesce(db.fx.DateDiff(DateParts.Hour, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate), db.fx.DatePart(DateParts.Hour, dbo.Purchase.PurchaseDate), db.fx.Literal(1))
                ).From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_hour_datepart_of_shipdate_and_datadiff_of_purchasedate_and_shipdate_succeed(int version, int expectedCount = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectMany<int>(
                    db.fx.Coalesce(db.fx.DatePart(DateParts.Hour, dbo.Purchase.ShipDate), db.fx.DateDiff(DateParts.Hour, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate), db.fx.Literal(1))
                ).From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(expectedCount);
        }
    }
}
