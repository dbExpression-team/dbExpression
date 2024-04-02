using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using DbExpression.Sql.Builder.Alias;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "COUNT")]
    public partial class CountTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(15)]
        public void Does_selecting_count_of_personid_succeed(int expectedValue)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Count(dbo.Purchase.PersonId).As("count")
                ).From(dbo.Purchase);

            //when               
            int count = exp.Execute();

            //then
            count.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(6)]
        public void Does_selecting_count_of_distinct_personid_succeed(int expectedValue)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Count(dbo.Purchase.PersonId).Distinct().As("count")
                ).From(dbo.Purchase);

            //when               
            int max = exp.Execute();

            //then
            max.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(15)]
        public void Does_selecting_count_of_star_succeed(int expectedValue)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Count()
                ).From(dbo.Purchase);

            //when               
            int max = exp.Execute();

            //then
            max.Should().Be(expectedValue);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(14)]
        public void Can_order_by_count_of_total_purchase_amount_ascending_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Count(dbo.Purchase.TotalPurchaseAmount).Distinct()
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Count(dbo.Purchase.TotalPurchaseAmount).Distinct());

            //when               
            int count = exp.Execute();

            //then
            count.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(14)]
        public void Can_order_by_count_of_total_purchase_amount_descending_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Count(dbo.Purchase.TotalPurchaseAmount).Distinct()
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Count(dbo.Purchase.TotalPurchaseAmount).Distinct().Desc());

            //when               
            int count = exp.Execute();

            //then
            count.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(14)]
        public void Can_order_by_count_of_total_purchase_amount_ascending_and_aliasing_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Count(dbo.Purchase.TotalPurchaseAmount).Distinct().As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Count(dbo.Purchase.TotalPurchaseAmount).Distinct());

            //when               
            int count = exp.Execute();

            //then
            count.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "ORDER BY")]
        [InlineData(14)]
        public void Can_order_by_count_of_total_purchase_amount_descending_and_aliasing_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Count(dbo.Purchase.TotalPurchaseAmount).Distinct().As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Count(dbo.Purchase.TotalPurchaseAmount).Distinct().Desc());

            //when               
            int count = exp.Execute();

            //then
            count.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "SUBQUERY")]
        [InlineData(15)]
        public void Can_count_aliased_field_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Count(("lines","PurchaseId")).Distinct().As("alias")
                ).From(dbo.Purchase)
                .InnerJoin(
                    db.SelectMany<PurchaseLine>()
                    .From(dbo.PurchaseLine)
                ).As("lines").On(dbo.Purchase.Id == ("lines", "PurchaseId"));

            //when               
            object? result = exp.Execute();

            //then
            result.Should().BeOfType<int>().And.Be(expected);
        }
    }
}
