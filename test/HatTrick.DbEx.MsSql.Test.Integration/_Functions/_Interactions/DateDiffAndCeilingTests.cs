using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Microsoft.Data.SqlClient;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Function", "DATEDIFF")]
    [Trait("Function", "CEILING")]
    public partial class DateDiffAndCeilingTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(0)]
        public void Does_selecting_ceil_of_datediff_of_purchase_date_and_ship_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Ceiling(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                ).From(dbo.Purchase);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(0)]
        public void Does_selecting_ceil_of_datediff_of_purchase_date_and_date_created_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Ceiling(db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated))
                ).From(dbo.Purchase);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData(1)]
        public void Does_selecting_ceil_of_quantity_added_to_datediff_of_purchase_date_and_ship_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Ceiling(dbo.PurchaseLine.Quantity) + db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.PurchaseLine).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                .GroupBy(db.fx.Ceiling(dbo.PurchaseLine.Quantity) + db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData(10000)]
        public void Does_selecting_ceil_of_credit_limit_added_to_datediff_of_purchase_date_and_ship_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Ceiling(dbo.Person.CreditLimit) + db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .GroupBy(db.fx.Ceiling(dbo.Person.CreditLimit) + db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData(10000)]
        public void Does_selecting_ceil_of_credit_limit_added_to_datediff_of_purchase_date_and_date_created_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Ceiling(dbo.Person.CreditLimit) + db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .GroupBy(db.fx.Ceiling(dbo.Person.CreditLimit) + db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData(1)]
        public void Does_selecting_ceil_of_quantity_added_to_datediff_of_purchase_date_and_date_created_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Ceiling(dbo.PurchaseLine.Quantity) + db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.PurchaseLine).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                .GroupBy(db.fx.Ceiling(dbo.PurchaseLine.Quantity) + db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData(1)]
        public void Does_selecting_ceil_of_quantity_minus_datediff_of_purchase_date_and_ship_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Ceiling(dbo.PurchaseLine.Quantity) - db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.PurchaseLine).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                .GroupBy(db.fx.Ceiling(dbo.PurchaseLine.Quantity) - db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData(10000)]
        public void Does_selecting_ceil_of_credit_limit_minus_datediff_of_purchase_date_and_ship_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Ceiling(dbo.Person.CreditLimit) - db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .GroupBy(db.fx.Ceiling(dbo.Person.CreditLimit) - db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData(10000)]
        public void Does_selecting_ceil_of_credit_limit_minus_datediff_of_purchase_date_and_date_created_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Ceiling(dbo.Person.CreditLimit) - db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .GroupBy(db.fx.Ceiling(dbo.Person.CreditLimit) - db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData(1)]
        public void Does_selecting_ceil_of_quantity_minus_datediff_of_purchase_date_and_date_created_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Ceiling(dbo.PurchaseLine.Quantity) - db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.PurchaseLine).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                .GroupBy(db.fx.Ceiling(dbo.PurchaseLine.Quantity) - db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData(0)]
        public void Does_selecting_ceil_of_quantity_multiplied_by_datediff_of_purchase_date_and_ship_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Ceiling(dbo.PurchaseLine.Quantity) * db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.PurchaseLine).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                .GroupBy(db.fx.Ceiling(dbo.PurchaseLine.Quantity) * db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData(0)]
        public void Does_selecting_ceil_of_credit_limit_multiplied_by_datediff_of_purchase_date_and_ship_date_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Ceiling(dbo.Person.CreditLimit) * db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .GroupBy(db.fx.Ceiling(dbo.Person.CreditLimit) * db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData(0)]
        public void Does_selecting_ceil_of_credit_limit_multiplied_by_datediff_of_purchase_date_and_date_created_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Ceiling(dbo.Person.CreditLimit) * db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .GroupBy(db.fx.Ceiling(dbo.Person.CreditLimit) * db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData(0)]
        public void Does_selecting_ceil_of_quantity_multiplied_by_datediff_of_purchase_date_and_date_created_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Ceiling(dbo.PurchaseLine.Quantity) * db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.PurchaseLine).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                .GroupBy(db.fx.Ceiling(dbo.PurchaseLine.Quantity) * db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated))
                .Where(dbo.Purchase.ShipDate != dbex.Null);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().NotBeNull();
            result!.Value.Should().Be(expected);
        }

        [Fact]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_ceil_of_quantity_divided_by_datediff_of_purchase_date_and_ship_date_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            Action execute = () => db.SelectOne(
                    db.fx.Ceiling(dbo.PurchaseLine.Quantity) / db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.PurchaseLine).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                .GroupBy(db.fx.Ceiling(dbo.PurchaseLine.Quantity) / db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .Execute();

            //when & then
            execute.Should().Throw<SqlException>().And.Message.Should().Be("Divide by zero error encountered.");
        }

        [Fact]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_ceil_of_credit_limit_divided_by_datediff_of_purchase_date_and_ship_date_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            Action execute = () => db.SelectOne(
                    db.fx.Ceiling(dbo.Person.CreditLimit) / db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .GroupBy(db.fx.Ceiling(dbo.Person.CreditLimit) / db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .Execute();

            //when & then
            execute.Should().Throw<SqlException>().And.Message.Should().Be("Divide by zero error encountered.");
        }

        [Fact]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_ceil_of_credit_limit_divided_by_datediff_of_purchase_date_and_date_created_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            Action execute = () => db.SelectOne(
                    db.fx.Ceiling(dbo.Person.CreditLimit) / db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .GroupBy(db.fx.Ceiling(dbo.Person.CreditLimit) / db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated))
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .Execute();

            //when & then
            execute.Should().Throw<SqlException>().And.Message.Should().Be("Divide by zero error encountered.");
        }

        [Fact]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_ceil_of_quantity_divided_by_datediff_of_purchase_date_and_date_created_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            Action execute = () => db.SelectOne(
                    db.fx.Ceiling(dbo.PurchaseLine.Quantity) / db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.PurchaseLine).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                .GroupBy(db.fx.Ceiling(dbo.PurchaseLine.Quantity) / db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated))
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .Execute();

            //when & then
            execute.Should().Throw<SqlException>().And.Message.Should().Be("Divide by zero error encountered.");
        }

        [Fact]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_ceil_of_quantity_modulus_of_datediff_of_purchase_date_and_ship_date_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            Action execute = () => db.SelectOne(
                    db.fx.Ceiling(dbo.PurchaseLine.Quantity) % db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.PurchaseLine).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                .GroupBy(db.fx.Ceiling(dbo.PurchaseLine.Quantity) % db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .Execute();

            //when & then
            execute.Should().Throw<SqlException>().And.Message.Should().Be("Divide by zero error encountered.");
        }

        [Fact]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_ceil_of_credit_limit_modulus_of_datediff_of_purchase_date_and_ship_date_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            Action execute = () => db.SelectOne(
                    db.fx.Ceiling(dbo.Person.CreditLimit) % db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .GroupBy(db.fx.Ceiling(dbo.Person.CreditLimit) % db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.ShipDate))
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .Execute();

            //when & then
            execute.Should().Throw<SqlException>().And.Message.Should().Be("Divide by zero error encountered.");
        }

        [Fact]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_ceil_of_credit_limit_modulus_of_datediff_of_purchase_date_and_date_created_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            Action execute = () => db.SelectOne(
                    db.fx.Ceiling(dbo.Person.CreditLimit) % db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.Person).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .GroupBy(db.fx.Ceiling(dbo.Person.CreditLimit) % db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated))
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .Execute();

            //when & then
            execute.Should().Throw<SqlException>().And.Message.Should().Be("Divide by zero error encountered.");
        }

        [Fact]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_ceil_of_quantity_modulus_of_datediff_of_purchase_date_and_date_created_succeed()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            Action execute = () => db.SelectOne(
                    db.fx.Ceiling(dbo.PurchaseLine.Quantity) % db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated)
                ).From(dbo.Purchase)
                .InnerJoin(dbo.PurchaseLine).On(dbo.Purchase.Id == dbo.PurchaseLine.PurchaseId)
                .GroupBy(db.fx.Ceiling(dbo.PurchaseLine.Quantity) % db.fx.DateDiff(DateParts.Year, dbo.Purchase.PurchaseDate, dbo.Purchase.DateCreated))
                .Where(dbo.Purchase.ShipDate != dbex.Null)
                .Execute();

            //when & then
            execute.Should().Throw<SqlException>().And.Message.Should().Be("Divide by zero error encountered.");
        }
    }
}
