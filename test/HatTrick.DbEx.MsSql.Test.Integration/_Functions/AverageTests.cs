using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "AVG")]
    public partial class AverageTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(20.543)]
        public void Does_averaging_total_purchase_amount_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Avg(dbo.Purchase.TotalPurchaseAmount).As("avg_amount")
                ).From(dbo.Purchase);

            //when               
            double average = exp.Execute();

            //then
            average.Should().BeApproximately(expected, 0.001, "Rounding errors in averaging");
        }

        [Theory]
        [InlineData(21.367)]
        public void Does_averaging_distinct_total_purchase_amount_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Avg(dbo.Purchase.TotalPurchaseAmount).Distinct().As("avg_amount")
                ).From(dbo.Purchase);

            //when               
            double average = exp.Execute();

            //then
            average.Should().BeApproximately(expected, 0.001, "Rounding errors in averaging");
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(21.367)]
        public void Can_order_by_average_of_total_purchase_amount_ascending_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Avg(dbo.Purchase.TotalPurchaseAmount).Distinct()
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Avg(dbo.Purchase.TotalPurchaseAmount).Distinct());

            //when               
            double average = exp.Execute();

            //then
            average.Should().BeApproximately(expected, 0.001, "Rounding errors in averaging");
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(21.367)]
        public void Can_order_by_average_of_total_purchase_amount_descending_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Avg(dbo.Purchase.TotalPurchaseAmount).Distinct()
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Avg(dbo.Purchase.TotalPurchaseAmount).Distinct().Desc());

            //when               
            double average = exp.Execute();

            //then
            average.Should().BeApproximately(expected, 0.001, "Rounding errors in averaging");
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(21.367)]
        public void Can_order_by_average_of_total_purchase_amount_ascending_and_aliasing_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Avg(dbo.Purchase.TotalPurchaseAmount).Distinct().As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Avg(dbo.Purchase.TotalPurchaseAmount).Distinct());

            //when               
            double average = exp.Execute();

            //then
            average.Should().BeApproximately(expected, 0.001, "Rounding errors in averaging");
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(21.367)]
        public void Can_order_by_average_of_total_purchase_amount_descending_and_aliasing_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Avg(dbo.Purchase.TotalPurchaseAmount).Distinct().As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Avg(dbo.Purchase.TotalPurchaseAmount).Distinct().Desc());

            //when               
            double average = exp.Execute();

            //then
            average.Should().BeApproximately(expected, 0.001, "Rounding errors in averaging");
        }

        [Theory]
        [InlineData(21.543)]
        public void Does_average_of_total_purchase_amount_added_to_static_value_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    (db.fx.Avg(dbo.Purchase.TotalPurchaseAmount) + 1).As("avg_amount")
                ).From(dbo.Purchase);

            //when               
            double average = exp.Execute();

            //then
            average.Should().BeApproximately(expected, 0.001, "Rounding errors in averaging");
        }

        [Theory]
        [InlineData(24635)]
        public void Does_average_of_credit_limit_added_to_static_value_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    (db.fx.Avg(dbo.Person.CreditLimit) + 1).As("avg_amount")
                ).From(dbo.Person);

            //when               
            int? average = exp.Execute();

            //then
            average.Should().Be(expected);
        }

        [Theory]
        [InlineData(19.543)]
        public void Does_average_of_total_purchase_amount_minus_static_value_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    (db.fx.Avg(dbo.Purchase.TotalPurchaseAmount) - 1).As("avg_amount")
                ).From(dbo.Purchase);

            //when               
            double average = exp.Execute();

            //then
            average.Should().BeApproximately(expected, 0.001, "Rounding errors in averaging");
        }

        [Theory]
        [InlineData(24633)]
        public void Does_average_of_credit_limit_added_minus_static_value_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    (db.fx.Avg(dbo.Person.CreditLimit) - 1).As("avg_amount")
                ).From(dbo.Person);

            //when               
            int? average = exp.Execute();

            //then
            average.Should().Be(expected);
        }

        [Theory]
        [InlineData(20.543333)]
        public void Does_average_of_total_purchase_amount_multiplied_by_static_value_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    (db.fx.Avg(dbo.Purchase.TotalPurchaseAmount) * 1).As("avg_amount")
                ).From(dbo.Purchase);

            //when               
            double average = exp.Execute();

            //then
            average.Should().BeApproximately(expected, 0.001, "Rounding errors in averaging");
        }

        [Theory]
        [InlineData(24634)]
        public void Does_average_of_credit_limit_added_multiplied_by_static_value_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    (db.fx.Avg(dbo.Person.CreditLimit) * 1).As("avg_amount")
                ).From(dbo.Person);

            //when               
            int? average = exp.Execute();

            //then
            average.Should().Be(expected);
        }

        [Theory]
        [InlineData(20.543333)]
        public void Does_average_of_total_purchase_amount_divided_by_static_value_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    (db.fx.Avg(dbo.Purchase.TotalPurchaseAmount) / 1).As("avg_amount")
                ).From(dbo.Purchase);

            //when               
            double average = exp.Execute();

            //then
            average.Should().BeApproximately(expected, 0.001, "Rounding errors in averaging");
        }

        [Theory]
        [InlineData(24634)]
        public void Does_average_of_credit_limit_added_divided_by_static_value_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    (db.fx.Avg(dbo.Person.CreditLimit) / 1).As("avg_amount")
                ).From(dbo.Person);

            //when               
            int? average = exp.Execute();

            //then
            average.Should().Be(expected);
        }

        [Theory]
        [InlineData(0.543333)]
        public void Does_average_of_total_purchase_amount_modulus_of_static_value_succeed(double expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    (db.fx.Avg(dbo.Purchase.TotalPurchaseAmount) % 1).As("avg_amount")
                ).From(dbo.Purchase);

            //when               
            double average = exp.Execute();

            //then
            average.Should().BeApproximately(expected, 0.001, "Rounding errors in averaging");
        }

        [Theory]
        [InlineData(0)]
        public void Does_average_of_credit_limit_added_modulus_of_static_value_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    (db.fx.Avg(dbo.Person.CreditLimit) % 1).As("avg_amount")
                ).From(dbo.Person);

            //when               
            int? average = exp.Execute();

            //then
            average.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [Trait("Operation", "HAVING")]
        [InlineData(2)]
        public void Does_average_of_credit_limit_grouped_by_lastname_and_having_null_average_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var averages = db.SelectMany(
                    dbo.Person.LastName,
                    db.fx.Avg(dbo.Person.CreditLimit).As("avg_amount")
                ).From(dbo.Person)
                .GroupBy(
                    dbo.Person.LastName
                ).Having(
                    db.fx.Avg(dbo.Person.CreditLimit) == dbex.Null
                )
                .Execute();

            //then
            averages.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [InlineData(13.268)]
        public void Does_averaged_of_aliased_field_succeed(decimal expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Avg(("lines", "PurchasePrice")).Distinct().As("alias")
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectMany<PurchaseLine>()
                    .From(dbo.PurchaseLine)
                ).As("lines").On(dbo.Purchase.Id == ("lines", "PurchaseId"));

            //when               
            object? avg = exp.Execute();

            //then
            avg.Should().BeOfType<decimal>().Which.Should().BeApproximately(expected, 0.001m, "Rounding errors in averaging");
        }
    }
}
