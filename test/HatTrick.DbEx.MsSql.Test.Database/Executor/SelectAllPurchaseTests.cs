using DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Extensions.Builder;
using Xunit;

using db = HatTrick.DbEx.MsSql.Builder.MsSqlExpressionBuilder;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public class SelectAllPurchaseTests : ExecutorTestBase
    {
        [Theory]
        [InlineData(2014)]
        public void Are_there_15_purchase_records(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectAll(dbo.Purchase.Id)
               .From(dbo.Purchase);

            //when               
            var purchases = exp.Execute();

            //then
            purchases.Should().HaveCount(15);
        }

        public class Where : ExecutorTestBase
        {
            [Theory]
            [InlineData(2014)]
            public void Does_ship_date_equal_to_null_have_3_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Purchase.Id)
                   .From(dbo.Purchase)
                   .Where(dbo.Purchase.ShipDate == null);

                //when               
                var purchases = exp.Execute();

                //then
                purchases.Should().HaveCount(3);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_ship_date_not_equal_to_null_have_12_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Purchase.Id)
                   .From(dbo.Purchase)
                   .Where(dbo.Purchase.ShipDate != null);

                //when               
                var purchases = exp.Execute();

                //then
                purchases.Should().HaveCount(12);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_negated_ship_date_equal_to_null_have_12_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Purchase.Id)
                   .From(dbo.Purchase)
                   .Where(!(dbo.Purchase.ShipDate == null));

                //when               
                var purchases = exp.Execute();

                //then
                purchases.Should().HaveCount(12);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_negated_ship_date_not_equal_to_null_have_3_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Purchase.Id)
                   .From(dbo.Purchase)
                   .Where(!(dbo.Purchase.ShipDate != null));

                //when               
                var purchases = exp.Execute();

                //then
                purchases.Should().HaveCount(3);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_ship_date_equal_to_null_or_total_purchase_amount_greater_than_50_have_4_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Purchase.Id)
                   .From(dbo.Purchase)
                   .Where(dbo.Purchase.ShipDate == null | dbo.Purchase.TotalPurchaseAmount > 55);

                //when               
                var purchases = exp.Execute();

                //then
                purchases.Should().HaveCount(4);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_ship_date_not_equal_to_null_and_total_purchase_amount_greater_than_50_have_1_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Purchase.Id)
                   .From(dbo.Purchase)
                   .Where(dbo.Purchase.ShipDate != null & dbo.Purchase.TotalPurchaseAmount > 55);

                //when               
                var purchases = exp.Execute();

                //then
                purchases.Should().HaveCount(1);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_negated_ship_date_equal_to_null_and_total_purchase_amount_greater_than_50_have_1_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Purchase.Id)
                   .From(dbo.Purchase)
                   .Where(!(dbo.Purchase.ShipDate == null) & dbo.Purchase.TotalPurchaseAmount > 55);

                //when               
                var purchases = exp.Execute();

                //then
                purchases.Should().HaveCount(1);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_Inegated_ship_date_equal_to_nullI_and_Itotal_purchase_amount_greater_than_50_or_less_than_10I_have_5_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Purchase.Id)
                   .From(dbo.Purchase)
                   .Where(!(dbo.Purchase.ShipDate == null) & (dbo.Purchase.TotalPurchaseAmount > 55 | dbo.Purchase.TotalPurchaseAmount < 10));

                //when               
                var purchases = exp.Execute();

                //then
                purchases.Should().HaveCount(5);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_ship_date_not_equal_to_null_and_Inegated_total_purchase_amount_greater_than_55_or_less_than_10I_have_7_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Purchase.Id)
                   .From(dbo.Purchase)
                   .Where(dbo.Purchase.ShipDate != null & !(dbo.Purchase.TotalPurchaseAmount > 55 | dbo.Purchase.TotalPurchaseAmount < 10));

                //when               
                var purchases = exp.Execute();

                //then
                purchases.Should().HaveCount(7);
            }

            [Theory]
            [InlineData(2014)]
            public void Does_Inegated_ship_date_equal_to_nullI_and_Inegated_total_purchase_amount_greater_than_55_or_less_than_10I_have_7_records(int version)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(dbo.Purchase.Id)
                   .From(dbo.Purchase)
                   .Where(!(dbo.Purchase.ShipDate == null) & !(dbo.Purchase.TotalPurchaseAmount > 55 | dbo.Purchase.TotalPurchaseAmount < 10));

                //when               
                var purchases = exp.Execute();

                //then
                purchases.Should().HaveCount(7);
            }
        }
    }
}
