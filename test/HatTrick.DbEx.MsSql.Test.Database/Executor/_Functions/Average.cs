using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "AVG")]
    public partial class Average : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_averaging_total_purchase_amount_succeed(int version, double expected = 20.543)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Avg(dbo.Purchase.TotalPurchaseAmount).As("avg_amount")
                ).From(dbo.Purchase);

            //when               
            double average = exp.Execute();

            //then
            average.Should().BeApproximately(expected, 0.001, "Rounding errors in averaging");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_averaging_distinct_total_purchase_amount_succeed(int version, double expected = 21.367)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Avg(dbo.Purchase.TotalPurchaseAmount).Distinct().As("avg_amount")
                ).From(dbo.Purchase);

            //when               
            double average = exp.Execute();

            //then
            average.Should().BeApproximately(expected, 0.001, "Rounding errors in averaging");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_average_of_total_purchase_amount_ascending_succeed(int version, double expected = 21.367)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_average_of_total_purchase_amount_descending_succeed(int version, double expected = 21.367)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Avg(dbo.Purchase.TotalPurchaseAmount).Distinct()
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Avg(dbo.Purchase.TotalPurchaseAmount).Distinct().Desc);

            //when               
            double average = exp.Execute();

            //then
            average.Should().BeApproximately(expected, 0.001, "Rounding errors in averaging");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_average_of_total_purchase_amount_ascending_and_aliasing_succeed(int version, double expected = 21.367)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_average_of_total_purchase_amount_descending_and_aliasing_succeed(int version, double expected = 21.367)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Avg(dbo.Purchase.TotalPurchaseAmount).Distinct().As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Avg(dbo.Purchase.TotalPurchaseAmount).Distinct().Desc);

            //when               
            double average = exp.Execute();

            //then
            average.Should().BeApproximately(expected, 0.001, "Rounding errors in averaging");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_average_of_total_purchase_amount_added_to_static_value_succeed(int version, double expected = 21.543)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    (db.fx.Avg(dbo.Purchase.TotalPurchaseAmount) + 1).As("avg_amount")
                ).From(dbo.Purchase);

            //when               
            double average = exp.Execute();

            //then
            average.Should().BeApproximately(expected, 0.001, "Rounding errors in averaging");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_average_of_credit_limit_added_to_static_value_succeed(int version, int expected = 24635)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    (db.fx.Avg(dbo.Person.CreditLimit) + 1).As("avg_amount")
                ).From(dbo.Person);

            //when               
            int? average = exp.Execute();

            //then
            average.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_average_of_total_purchase_amount_minus_static_value_succeed(int version, double expected = 19.543)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    (db.fx.Avg(dbo.Purchase.TotalPurchaseAmount) - 1).As("avg_amount")
                ).From(dbo.Purchase);

            //when               
            double average = exp.Execute();

            //then
            average.Should().BeApproximately(expected, 0.001, "Rounding errors in averaging");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_average_of_credit_limit_added_minus_static_value_succeed(int version, int expected = 24633)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    (db.fx.Avg(dbo.Person.CreditLimit) - 1).As("avg_amount")
                ).From(dbo.Person);

            //when               
            int? average = exp.Execute();

            //then
            average.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_average_of_total_purchase_amount_multiplied_by_static_value_succeed(int version, double expected = 20.543333)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    (db.fx.Avg(dbo.Purchase.TotalPurchaseAmount) * 1).As("avg_amount")
                ).From(dbo.Purchase);

            //when               
            double average = exp.Execute();

            //then
            average.Should().BeApproximately(expected, 0.001, "Rounding errors in averaging");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_average_of_credit_limit_added_multiplied_by_static_value_succeed(int version, int expected = 24634)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    (db.fx.Avg(dbo.Person.CreditLimit) * 1).As("avg_amount")
                ).From(dbo.Person);

            //when               
            int? average = exp.Execute();

            //then
            average.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_average_of_total_purchase_amount_divided_by_static_value_succeed(int version, double expected = 20.543333)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    (db.fx.Avg(dbo.Purchase.TotalPurchaseAmount) / 1).As("avg_amount")
                ).From(dbo.Purchase);

            //when               
            double average = exp.Execute();

            //then
            average.Should().BeApproximately(expected, 0.001, "Rounding errors in averaging");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_average_of_credit_limit_added_divided_by_static_value_succeed(int version, int expected = 24634)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    (db.fx.Avg(dbo.Person.CreditLimit) / 1).As("avg_amount")
                ).From(dbo.Person);

            //when               
            int? average = exp.Execute();

            //then
            average.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_average_of_total_purchase_amount_modulus_of_static_value_succeed(int version, double expected = 0.543333)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    (db.fx.Avg(dbo.Purchase.TotalPurchaseAmount) % 1).As("avg_amount")
                ).From(dbo.Purchase);

            //when               
            double average = exp.Execute();

            //then
            average.Should().BeApproximately(expected, 0.001, "Rounding errors in averaging");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_average_of_credit_limit_added_modulus_of_static_value_succeed(int version, int expected = 0)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    (db.fx.Avg(dbo.Person.CreditLimit) % 1).As("avg_amount")
                ).From(dbo.Person);

            //when               
            int? average = exp.Execute();

            //then
            average.Should().Be(expected);
        }
    }
}
