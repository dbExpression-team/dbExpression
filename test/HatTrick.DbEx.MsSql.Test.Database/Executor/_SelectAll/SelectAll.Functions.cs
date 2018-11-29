using DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Extensions.Builder;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor._SelectAll
{
    public partial class SelectAll
    {
		[Trait("Category", "Coalesce")]
        public partial class Coalesce : ExecutorTestBase
        {
            [Theory]
            [InlineData(2014, 15)]
            public void Does_coalesceing_ship_date_and_purchase_date_succeed(int version, int expectedCount)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll<DateTime>(
                        db.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).As("relevant_date")
                    ).From(dbo.Purchase);

                //when               
                var dates = exp.Execute();

                //then
                dates.Should().HaveCount(expectedCount);
            }

            [Theory]
            [InlineData(2014, 15)]
            public void Does_coalesceing_all_product_dates_succeed(int version, int expectedCount)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll<DateTime>(
                        db.Coalesce(
                            dbo.Purchase.ShipDate, 
                            dbo.Purchase.PurchaseDate,
                            dbo.Purchase.DateCreated,
                            dbo.Purchase.DateUpdated
                        ).As("relevant_date")
                    ).From(dbo.Purchase);

                //when               
                var dates = exp.Execute();

                //then
                dates.Should().HaveCount(expectedCount);
            }

            [Theory]
            [InlineData(2014, 15)]
            public void Does_coalesceing_all_product_dates_and_returning_total_purchase_amount_succeed(int version, int expectedCount)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(
                        dbo.Purchase.TotalPurchaseAmount,
                        db.Coalesce(
                            dbo.Purchase.ShipDate,
                            dbo.Purchase.PurchaseDate,
                            dbo.Purchase.DateCreated,
                            dbo.Purchase.DateUpdated
                        ).As("relevant_date")
                    ).From(dbo.Purchase);

                //when               
                var dates = exp.Execute();

                //then
                dates.Should().HaveCount(expectedCount);
            }

            [Theory]
            [InlineData(2014, 15)]
            public void Does_coalesceing_all_product_dates_including_arithmetic_and_returning_total_purchase_amount_succeed(int version, int expectedCount)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(
                        dbo.Purchase.TotalPurchaseAmount,
                        db.Coalesce(
                            dbo.Purchase.ShipDate,
                            dbo.Purchase.PurchaseDate,
                            dbo.Purchase.DateCreated + DateTime.Now,
                            dbo.Purchase.DateUpdated
                        ).As("relevant_date")
                    ).From(dbo.Purchase);

                //when               
                var dates = exp.Execute();

                //then
                dates.Should().HaveCount(expectedCount);
            }
        }

        [Trait("Category", "Average")]
        public partial class Average : ExecutorTestBase
        {
            [Theory]
            [InlineData(2014, 20.543)]
            public void Does_averaging_total_purchase_amount_succeed(int version, decimal expectedValue)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.Avg(dbo.Purchase.TotalPurchaseAmount).As("avg_amount")
                    ).From(dbo.Purchase);

                //when               
                var average = exp.Execute();

                //then
                average.Should().BeApproximately(expectedValue, 0.001M, "Rounding errors in averaging");
            }
        }
    }
}
