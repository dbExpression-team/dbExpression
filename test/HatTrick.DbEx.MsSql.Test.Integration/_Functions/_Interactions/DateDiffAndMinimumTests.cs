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
    [Trait("Function", "DATEDIFF")]
    [Trait("Function", "MIN")]
    public partial class DateDiffAndMinimumTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_minimum_of_datediff_of_purchase_date_and_ship_date_succeed(int version, int expected = 0)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Min(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                ).From(dbo.Purchase);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_minimum_of_datediff_of_purchase_date_and_date_created_succeed(int version, int expected = 0)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Min(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated))
                ).From(dbo.Purchase);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_minimum_of_quantity_added_to_datediff_of_purchase_date_and_ship_date_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Min(dbo.PurchaseLine.Quantity) + db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.PurchaseLine).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                .GroupBy(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_minimum_of_credit_limit_added_to_datediff_of_purchase_date_and_ship_date_succeed(int version, int expected = 10000)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Min(dbo.Person.CreditLimit) + db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .GroupBy(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_minimum_of_credit_limit_added_to_datediff_of_purchase_date_and_date_created_succeed(int version, int expected = 10000)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Min(dbo.Person.CreditLimit) + db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .GroupBy(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_minimum_of_quantity_added_to_datediff_of_purchase_date_and_date_created_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Min(dbo.PurchaseLine.Quantity) + db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.PurchaseLine).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                .GroupBy(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_minimum_of_quantity_minus_datediff_of_purchase_date_and_ship_date_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Min(dbo.PurchaseLine.Quantity) - db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.PurchaseLine).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                .GroupBy(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_minimum_of_credit_limit_minus_datediff_of_purchase_date_and_ship_date_succeed(int version, int expected = 10000)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Min(dbo.Person.CreditLimit) - db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .GroupBy(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_minimum_of_credit_limit_minus_datediff_of_purchase_date_and_date_created_succeed(int version, int expected = 10000)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Min(dbo.Person.CreditLimit) - db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .GroupBy(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_minimum_of_quantity_minus_datediff_of_purchase_date_and_date_created_succeed(int version, int expected = 1)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Min(dbo.PurchaseLine.Quantity) - db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.PurchaseLine).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                .GroupBy(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_minimum_of_quantity_multiplied_by_datediff_of_purchase_date_and_ship_date_succeed(int version, int expected = 0)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Min(dbo.PurchaseLine.Quantity) * db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.PurchaseLine).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                .GroupBy(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_minimum_of_credit_limit_multiplied_by_datediff_of_purchase_date_and_ship_date_succeed(int version, int expected = 0)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Min(dbo.Person.CreditLimit) * db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .GroupBy(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_minimum_of_credit_limit_multiplied_by_datediff_of_purchase_date_and_date_created_succeed(int version, int expected = 0)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Min(dbo.Person.CreditLimit) * db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .GroupBy(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_minimum_of_quantity_multiplied_by_datediff_of_purchase_date_and_date_created_succeed(int version, int expected = 0)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Min(dbo.PurchaseLine.Quantity) * db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.PurchaseLine).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                .GroupBy(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_minimum_of_quantity_divided_by_datediff_of_purchase_date_and_ship_date_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            Action execute = () => db.SelectOne(
                    db.fx.Min(dbo.PurchaseLine.Quantity) / db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.PurchaseLine).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                .GroupBy(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .Execute();

            //when & then
            execute.Should().Throw<SqlException>().And.Message.Should().Be("Divide by zero error encountered.");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_minimum_of_credit_limit_divided_by_datediff_of_purchase_date_and_ship_date_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            Action execute = () => db.SelectOne(
                    db.fx.Min(dbo.Person.CreditLimit) / db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .GroupBy(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .Execute();

            //when & then
            execute.Should().Throw<SqlException>().And.Message.Should().Be("Divide by zero error encountered.");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_minimum_of_credit_limit_divided_by_datediff_of_purchase_date_and_date_created_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            Action execute = () => db.SelectOne(
                    db.fx.Min(dbo.Person.CreditLimit) / db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .GroupBy(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated))
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .Execute();

            //when & then
            execute.Should().Throw<SqlException>().And.Message.Should().Be("Divide by zero error encountered.");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_minimum_of_quantity_divided_by_datediff_of_purchase_date_and_date_created_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            Action execute = () => db.SelectOne(
                    db.fx.Min(dbo.PurchaseLine.Quantity) / db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.PurchaseLine).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                .GroupBy(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated))
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .Execute();

            //when & then
            execute.Should().Throw<SqlException>().And.Message.Should().Be("Divide by zero error encountered.");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_minimum_of_quantity_modulus_of_datediff_of_purchase_date_and_ship_date_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            Action execute = () => db.SelectOne(
                    db.fx.Min(dbo.PurchaseLine.Quantity) % db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.PurchaseLine).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                .GroupBy(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .Execute();

            //when & then
            execute.Should().Throw<SqlException>().And.Message.Should().Be("Divide by zero error encountered.");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_minimum_of_credit_limit_modulus_of_datediff_of_purchase_date_and_ship_date_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            Action execute = () => db.SelectOne(
                    db.fx.Min(dbo.Person.CreditLimit) % db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .GroupBy(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .Execute();

            //when & then
            execute.Should().Throw<SqlException>().And.Message.Should().Be("Divide by zero error encountered.");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_minimum_of_credit_limit_modulus_of_datediff_of_purchase_date_and_date_created_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            Action execute = () => db.SelectOne(
                    db.fx.Min(dbo.Person.CreditLimit) % db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .GroupBy(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated))
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .Execute();

            //when & then
            execute.Should().Throw<SqlException>().And.Message.Should().Be("Divide by zero error encountered.");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_minimum_of_quantity_modulus_of_datediff_of_purchase_date_and_date_created_succeed(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            Action execute = () => db.SelectOne(
                    db.fx.Min(dbo.PurchaseLine.Quantity) % db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.PurchaseLine).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                .GroupBy(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated))
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .Execute();

            //when & then
            execute.Should().Throw<SqlException>().And.Message.Should().Be("Divide by zero error encountered.");
        }
    }
}
