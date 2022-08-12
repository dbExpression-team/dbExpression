using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    public partial class ArithmeticTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_arithmetic_order_of_precedence_succeed(int version, double expected = 36)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

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
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

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
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

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
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    dbo.Person.FirstName + " " + dbo.Person.LastName
                ).From(dbo.Person)
                .Where(dbo.Person.Id == 1);

            //when               
            string result = exp.Execute()!;

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 1, 1)]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 2, 2)]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 11, 11)]
        public void Does_arithmetic_of_a_field_added_to_an_int_literal_value_calculate_correctly(int version, int id, int expected)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            //when
            int value = db.SelectOne(dbo.Person.Id + 0)
                .From(dbo.Person)
                .Where(dbo.Person.Id == id)
                .Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 1, 1)]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 3, 3)]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 49, 49)]
        public void Does_arithmetic_of_an_int_literal_value_added_to_a_field_calculate_correctly(int version, int id, int expected = 1)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            //when
            int value = db.SelectOne(0 + dbo.Person.Id)
                .From(dbo.Person)
                .Where(dbo.Person.Id == id)
                .Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 1, 5)]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 3, 9)]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 49, 101)]
        public void Does_arithmetic_of_an_int_literal_value_added_to_a_field_and_another_int_literal_value_calculate_correctly(int version, int id = 1, int expected = 4)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            //when
            int value = db.SelectOne(id + dbo.Person.Id + 3)
                .From(dbo.Person)
                .Where(dbo.Person.Id == id)
                .Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 1, 5)]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 3, 9)]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 49, 101)]
        public void Does_arithmetic_of_an_int_literal_value_added_to_an_int_literal_value_added_to_a_field_use_compiler_addition_and_calculate_correctly(int version, int id, int expected)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            //when
            int value = db.SelectOne(id + 3 + dbo.Person.Id)
                .From(dbo.Person)
                .Where(dbo.Person.Id == id)
                .Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 1, -1)]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 3, 3)]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 49, 95)]
        public void Does_arithmetic_of_an_int_literal_value_added_to_a_field_value_and_subtracting_an_int_literal_value_calculate_correctly(int version, int id, int expected)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            //when
            int value = db.SelectOne(id + dbo.Person.Id - 3)
                .From(dbo.Person)
                .Where(dbo.Person.Id == id)
                .Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 1, -1)]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 3, 3)]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 49, 95)]
        public void Does_arithmetic_of_an_int_literal_value_added_to_a_precedence_declared_field_value_subtracting_an_int_literal_value_calculate_correctly(int version, int id, int expected)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            //when
            int value = db.SelectOne(id + (dbo.Person.Id - 3))
                .From(dbo.Person)
                .Where(dbo.Person.Id == id)
                .Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 1, -39)]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 3, 3)]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 49, 969)]
        public void Does_arithmetic_of_an_int_literal_value_added_to_a_precedence_declared_field_value_subtracting_an_int_literal_value_than_multiplied_by_int_literal_value_calculate_correctly(int version, int id, int expected)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            //when
            int value = db.SelectOne(id + (dbo.Person.Id - 3) * 20)
                .From(dbo.Person)
                .Where(dbo.Person.Id == id)
                .Execute();

            //then
            value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 1, -44)]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 3, -2)]
        [MsSqlVersionWithData(typeof(CurrentMsSqlVersion), 49, 964)]
        public void Does_arithmetic_expression_of_an_int_literal_value_added_to_a_precedence_declared_field_value_subtracting_a_double_literal_value_than_multiplied_by_int_literal_value_calculate_correctly(int version, int id, double expected)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            //when
            double value = db.SelectOne(id + (dbo.Person.Id - 3.25d) * 20)
                .From(dbo.Person)
                .Where(dbo.Person.Id == id)
                .Execute();

            //then
            value.Should().Be(expected);
        }
    }
}
