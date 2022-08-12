using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Data.SqlClient;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Function", "DATEADD")]
    [Trait("Function", "DATEPART")]
    public partial class DateDiffAndDatePartTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datediff_of_purchase_date_and_date_created_added_to_datepart_of_purchase_date_succeed(int version, int expected = 2019)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated) + db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datepart_of_ship_date_added_to_datediff_of_purchase_date_and_ship_date_succeed(int version, int expected = 2019)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate) + db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datepart_of_ship_date_added_to_datediff_of_purchase_date_and_date_created_succeed(int version, int expected = 2019)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate) + db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datepart_of_purchase_date_added_to_datediff_of_purchase_date_and_date_created_succeed(int version, int expected = 2019)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate) + db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datediff_of_purchase_date_and_date_created_minus_datepart_of_purchase_date_succeed(int version, int expected = -2019)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated) - db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datepart_of_ship_date_minus_datediff_of_purchase_date_and_ship_date_succeed(int version, int expected = 2019)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate) - db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datepart_of_ship_date_minus_datediff_of_purchase_date_and_date_created_succeed(int version, int expected = 2019)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate) - db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datepart_of_purchase_date_minums_datediff_of_purchase_date_and_date_created_succeed(int version, int expected = 2019)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate) - db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datediff_of_purchase_date_and_date_created_multiplied_by_datepart_of_purchase_date_succeed(int version, int expected = 0)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated) * db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datepart_of_ship_date_multiplied_by_datediff_of_purchase_date_and_ship_date_succeed(int version, int expected = 0)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate) * db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datepart_of_ship_date_multiplied_by_datediff_of_purchase_date_and_date_created_succeed(int version, int expected = 0)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate) * db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datepart_of_purchase_date_multiplied_by_datediff_of_purchase_date_and_date_created_succeed(int version, int expected = 0)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate) * db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datediff_of_purchase_date_and_date_created_divided_by_datepart_of_purchase_date_succeed(int version, int expected = 0)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated) / db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datepart_of_ship_date_divided_by_datediff_of_purchase_date_and_ship_date_succeed(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            Action execute = () => db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate) / db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .Execute();

            //when & then
            execute.Should().Throw<SqlException>().And.Message.Should().Be("Divide by zero error encountered.");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datepart_of_ship_date_divided_by_datediff_of_purchase_date_and_date_created_succeed(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            Action execute = () => db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate) / db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .Execute();

            //when & then
            execute.Should().Throw<SqlException>().And.Message.Should().Be("Divide by zero error encountered.");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datepart_of_purchase_date_divided_by_datediff_of_purchase_date_and_date_created_succeed(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            Action execute = () => db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate) / db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .Execute();

            //when & then
            execute.Should().Throw<SqlException>().And.Message.Should().Be("Divide by zero error encountered.");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datediff_of_purchase_date_and_date_created_modulus_of_datepart_of_purchase_date_succeed(int version, int expected = 0)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated) % db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datepart_of_ship_date_modulus_of_datediff_of_purchase_date_and_ship_date_succeed(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            Action execute = () => db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate) % db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .Execute();

            //when & then
            execute.Should().Throw<SqlException>().And.Message.Should().Be("Divide by zero error encountered.");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datepart_of_ship_date_modulus_of_datediff_of_purchase_date_and_date_created_succeed(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            Action execute = () => db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.ShipDate) % db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .Execute();

            //when & then
            execute.Should().Throw<SqlException>().And.Message.Should().Be("Divide by zero error encountered.");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_datepart_of_purchase_date_modulus_of_datediff_of_purchase_date_and_date_created_succeed(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            Action execute = () => db.SelectOne(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate) % db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .Execute();

            //when & then
            execute.Should().Throw<SqlException>().And.Message.Should().Be("Divide by zero error encountered.");
        }
    }
}
