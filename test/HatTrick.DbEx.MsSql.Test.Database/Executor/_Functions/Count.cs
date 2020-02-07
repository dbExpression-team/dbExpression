using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Builder;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "COUNT")]
    public partial class Count : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_count_of_personid_succeed(int version, int expectedValue = 15)
        {
            //given
            ConfigureForMsSqlVersion(version);

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
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Count(dbo.Purchase.PersonId, distinct: true).As("count")
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
            ConfigureForMsSqlVersion(version);

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
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Count(dbo.Purchase.TotalPurchaseAmount, distinct: true)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Count(dbo.Purchase.TotalPurchaseAmount, distinct: true));

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
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Count(dbo.Purchase.TotalPurchaseAmount, distinct: true)
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Count(dbo.Purchase.TotalPurchaseAmount, distinct: true).Desc);

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
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Count(dbo.Purchase.TotalPurchaseAmount, distinct: true).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Count(dbo.Purchase.TotalPurchaseAmount, distinct: true));

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
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Count(dbo.Purchase.TotalPurchaseAmount, distinct: true).As("alias")
                ).From(dbo.Purchase)
                .OrderBy(db.fx.Count(dbo.Purchase.TotalPurchaseAmount, distinct: true).Desc);

            //when               
            int count = exp.Execute();

            //then
            count.Should().Be(expected);
        }
    }
}
