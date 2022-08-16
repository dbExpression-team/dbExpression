using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "COUNT")]
    public partial class CountTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_count_of_personid_succeed(int version, int expectedValue = 15)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Count(dbo.Purchase.PersonId).As("count")
                ).From(dbo.Purchase);

            //when               
            int count = exp.Execute();

            //then
            count.Should().Be(expectedValue);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_count_of_distinct_personid_succeed(int version, int expectedValue = 6)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Count(dbo.Purchase.PersonId).Distinct().As("count")
                ).From(dbo.Purchase);

            //when               
            int max = exp.Execute();

            //then
            max.Should().Be(expectedValue);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_count_of_star_succeed(int version, int expectedValue = 15)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Count()
                ).From(dbo.Purchase);

            //when               
            int max = exp.Execute();

            //then
            max.Should().Be(expectedValue);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_count_of_total_purchase_amount_ascending_succeed(int version, int expected = 14)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_count_of_total_purchase_amount_descending_succeed(int version, int expected = 14)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Count(dbo.Purchase.TotalPurchaseAmount).Distinct()
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Count(dbo.Purchase.TotalPurchaseAmount).Distinct().Desc);

            //when               
            int count = exp.Execute();

            //then
            count.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_count_of_total_purchase_amount_ascending_and_aliasing_succeed(int version, int expected = 14)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "ORDER BY")]
        public void Can_order_by_count_of_total_purchase_amount_descending_and_aliasing_succeed(int version, int expected = 14)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Count(dbo.Purchase.TotalPurchaseAmount).Distinct().As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Count(dbo.Purchase.TotalPurchaseAmount).Distinct().Desc);

            //when               
            int count = exp.Execute();

            //then
            count.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "SUBQUERY")]
        public void Can_count_aliased_field_succeed(int version, int expected = 15)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

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
