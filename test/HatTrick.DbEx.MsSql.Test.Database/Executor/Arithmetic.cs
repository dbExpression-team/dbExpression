using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "SELECT")]
    public partial class Arithmetic : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_arithmetic_order_of_precedence_succeed(int version, double expected = 36)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    (dbo.Purchase.TotalPurchaseAmount + 2) * 3
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.TotalPurchaseAmount == 10);

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_arithmetic_order_of_precedence_reversed_succeed(int version, double expected = 36)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    3 * (dbo.Purchase.TotalPurchaseAmount + 2)
                ).From(dbo.Purchase)
                .Where(dbo.Purchase.TotalPurchaseAmount == 10);

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_arithmetic_with_no_order_of_precedence_succeed(int version, double expected = 1002.00)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    dbo.Product.ListPrice * dbo.Product.Quantity + 3
                ).From(dbo.Product)
                .Where(dbo.Product.ListPrice == 9.99);

            //when               
            double result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_arithmetic_of_person_firstname_a_space_and_person_lastname_succeed(int version, string expected = "Kenny McCormick")
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    dbo.Person.FirstName + " " + dbo.Person.LastName
                ).From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            string result = exp.Execute();

            //then
            result.Should().Be(expected);
        }
    }
}
