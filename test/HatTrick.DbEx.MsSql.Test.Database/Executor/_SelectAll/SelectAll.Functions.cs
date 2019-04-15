using Data;
using Data.dbo;
using DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions.Builder;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public partial class SelectAll
    {
        [Trait("Function", "CAST")]
        public partial class Cast : ExecutorTestBase
        {
            [Theory]
            [InlineData(2012, 15)]
            [InlineData(2014, 15)]
            public void Does_selecting_cast_of_ship_date_to_varchar_succeed(int version, int expectedCount)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll<string>(
                        db.Cast(dbo.Purchase.ShipDate).AsVarChar(50)
                    ).From(dbo.Purchase);

                //when               
                var datesAsStrings = exp.Execute();

                //then
                datesAsStrings.Should().HaveCount(expectedCount);
            }

            [Theory]
            [InlineData(2012, 15)]
            [InlineData(2014, 15)]
            public void Does_selecting_multiple_fields_and_casting_ship_date_to_varchar_succeed(int version, int expectedCount)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(
                        dbo.Purchase.Id,
                        db.Cast(dbo.Purchase.ShipDate).AsVarChar(50)
                    ).From(dbo.Purchase);

                //when               
                var datesAsStrings = exp.Execute();

                //then
                datesAsStrings.Should().HaveCount(expectedCount);
            }
        }

        [Trait("Function", "COALESCE")]
        public partial class Coalesce : ExecutorTestBase
        {
            [Theory]
            [InlineData(2012, 15)]
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
            [InlineData(2012, 15)]
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
            [InlineData(2012, 15)]
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
            [InlineData(2012, 15)]
            [InlineData(2014, 15)]
            [Trait("Expression", "Arithmetic")]
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
                            dbo.Purchase.DateUpdated + dbo.Purchase.DateCreated
                        ).As("relevant_date")
                    ).From(dbo.Purchase);

                //when               
                var dates = exp.Execute();

                //then
                dates.Should().HaveCount(expectedCount);
            }
        }

        [Trait("Function", "ISNULL")]
        public partial class IsNull : ExecutorTestBase
        {
            [Theory]
            [InlineData(2012, 15)]
            [InlineData(2014, 15)]
            public void Does_isnull_ship_date_and_purchase_date_succeed(int version, int expectedCount)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll<DateTime>(
                        db.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).As("relevant_date")
                    ).From(dbo.Purchase);

                //when               
                var dates = exp.Execute();

                //then
                dates.Should().HaveCount(expectedCount);
            }

            [Theory]
            [InlineData(2012, 15)]
            [InlineData(2014, 15)]
            public void Does_isnull_of_shipdate_succeed(int version, int expectedCount)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll<DateTime>(
                        db.IsNull(
                            dbo.Purchase.ShipDate,
                            DateTime.Now
                        ).As("relevant_date")
                    ).From(dbo.Purchase);

                //when               
                var dates = exp.Execute();

                //then
                dates.Should().HaveCount(expectedCount);
            }

            [Theory]
            [InlineData(2012, 15)]
            [InlineData(2014, 15)]
            public void Does_isnull_all_product_dates_and_returning_total_purchase_amount_succeed(int version, int expectedCount)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(
                        dbo.Purchase.TotalPurchaseAmount,
                        db.IsNull(
                            dbo.Purchase.ShipDate,
                            dbo.Purchase.PurchaseDate
                        ).As("relevant_date")
                    ).From(dbo.Purchase);

                //when               
                var dates = exp.Execute();

                //then
                dates.Should().HaveCount(expectedCount);
            }

            [Theory]
            [InlineData(2012, 15)]
            [InlineData(2014, 15)]
            [Trait("Expression", "Arithmetic")]
            public void Does_isnull_all_product_dates_including_arithmetic_and_returning_total_purchase_amount_succeed(int version, int expectedCount)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(
                        dbo.Purchase.TotalPurchaseAmount,
                        db.IsNull(
                            dbo.Purchase.ShipDate,
                            dbo.Purchase.DateCreated + DateTime.Now
                        ).As("relevant_date")
                    ).From(dbo.Purchase);

                //when               
                var dates = exp.Execute();

                //then
                dates.Should().HaveCount(expectedCount);
            }

            [Theory]
            [InlineData(2012, 50)]
            [InlineData(2014, 50)]
            public void Does_isnull_persons_gender_succeed(int version, int expectedCount)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(
                        dbo.Person.Id,
                        db.IsNull(
                            dbo.Person.GenderType,
                            GenderType.Female
                        )
                    ).From(dbo.Person);

                //when               
                var persons = exp.Execute();

                //then
                persons.Should().HaveCount(expectedCount);
            }

            [Theory]
            [InlineData(2012, 32)]
            [InlineData(2014, 32)]
            public void Does_isnull_address_type_succeed(int version, int expectedCount)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectAll(
                        dbo.Address.Id,
                        db.IsNull(
                            dbo.Address.AddressType,
                            AddressType.Billing
                        )
                    ).From(dbo.Address);

                //when               
                var addresses = exp.Execute();

                //then
                addresses.Should().HaveCount(expectedCount);
            }
        }

        [Trait("Function", "AVG")]
        public partial class Average : ExecutorTestBase
        {
            [Theory]
            [InlineData(2012, 20.543)]
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

            [Theory]
            [InlineData(2012, 21.367)]
            [InlineData(2014, 21.367)]
            public void Does_averaging_distinct_total_purchase_amount_succeed(int version, decimal expectedValue)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.Avg(dbo.Purchase.TotalPurchaseAmount, distinct:true).As("avg_amount")
                    ).From(dbo.Purchase);

                //when               
                var average = exp.Execute();

                //then
                average.Should().BeApproximately(expectedValue, 0.001M, "Rounding errors in averaging");
            }
        }

        [Trait("Function", "MIN")]
        public partial class Minimum : ExecutorTestBase
        {
            [Theory]
            [InlineData(2012, 5.11)]
            [InlineData(2014, 5.11)]
            public void Does_selecting_minimum_total_purchase_amount_succeed(int version, decimal expectedValue)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.Min(dbo.Purchase.TotalPurchaseAmount).As("min_amount")
                    ).From(dbo.Purchase);

                //when               
                var min = exp.Execute();

                //then
                min.Should().Be(expectedValue);
            }

            [Theory]
            [InlineData(2012, 5.11)]
            [InlineData(2014, 5.11)]
            public void Does_selecting_minimum_distinct_total_purchase_amount_succeed(int version, decimal expectedValue)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.Min(dbo.Purchase.TotalPurchaseAmount, distinct: true).As("min_amount")
                    ).From(dbo.Purchase);

                //when               
                var min = exp.Execute();

                //then
                min.Should().Be(expectedValue);
            }
        }

        [Trait("Function", "MAX")]
        public partial class Maximum : ExecutorTestBase
        {
            [Theory]
            [InlineData(2012, 55.96)]
            [InlineData(2014, 55.96)]
            public void Does_selecting_maximum_total_purchase_amount_succeed(int version, decimal expectedValue)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.Max(dbo.Purchase.TotalPurchaseAmount).As("max_amount")
                    ).From(dbo.Purchase);

                //when               
                var max = exp.Execute();

                //then
                max.Should().Be(expectedValue);
            }

            [Theory]
            [InlineData(2012, 55.96)]
            [InlineData(2014, 55.96)]
            public void Does_selecting_maximum_distinct_total_purchase_amount_succeed(int version, decimal expectedValue)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.Max(dbo.Purchase.TotalPurchaseAmount, distinct: true).As("max_amount")
                    ).From(dbo.Purchase);

                //when               
                var max = exp.Execute();

                //then
                max.Should().Be(expectedValue);
            }
        }

        [Trait("Function", "COUNT")]
        public partial class Count : ExecutorTestBase
        {
            [Theory]
            [InlineData(2012, 15)]
            [InlineData(2014, 15)]
            public void Does_selecting_count_of_personid_succeed(int version, int expectedValue)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<int>(
                        db.Count(dbo.Purchase.PersonId).As("count")
                    ).From(dbo.Purchase);

                //when               
                var count = exp.Execute();

                //then
                count.Should().Be(expectedValue);
            }

            [Theory]
            [InlineData(2012, 6)]
            [InlineData(2014, 6)]
            public void Does_selecting_count_of_distinct_personid_succeed(int version, int expectedValue)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<int>(
                        db.Count(dbo.Purchase.PersonId, distinct: true).As("count")
                    ).From(dbo.Purchase);

                //when               
                var max = exp.Execute();

                //then
                max.Should().Be(expectedValue);
            }

            [Theory]
            [InlineData(2012, 15)]
            [InlineData(2014, 15)]
            public void Does_selecting_count_of_star_succeed(int version, int expectedValue)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<int>(
                        db.Count()
                    ).From(dbo.Purchase);

                //when               
                var max = exp.Execute();

                //then
                max.Should().Be(expectedValue);
            }
        }

        [Trait("Function", "SUM")]
        public partial class Sum : ExecutorTestBase
        {
            [Theory]
            [InlineData(2012, 308.15)]
            [InlineData(2014, 308.15)]
            public void Does_sum_of_total_purchase_amount_succeed(int version, decimal expectedValue)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.Sum(dbo.Purchase.TotalPurchaseAmount).As("sum")
                    ).From(dbo.Purchase);

                //when               
                var sum = exp.Execute();

                //then
                sum.Should().Be(expectedValue);
            }

            [Theory]
            [InlineData(2012, 299.15)]
            [InlineData(2014, 299.15)]
            public void Does_sum_of_distinct_total_purchase_amount_succeed(int version, decimal expectedValue)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.Sum(dbo.Purchase.TotalPurchaseAmount, distinct: true).As("sum")
                    ).From(dbo.Purchase);

                //when               
                var sum = exp.Execute();

                //then
                sum.Should().Be(expectedValue);
            }
        }

        [Trait("Function", "STDEV")]
        public partial class StandardDeviation : ExecutorTestBase
        {
            [Theory]
            [InlineData(2012, 16.146)]
            [InlineData(2014, 16.146)]
            public void Does_standard_deviation_of_total_purchase_amount_succeed(int version, decimal expectedValue)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.StDev(dbo.Purchase.TotalPurchaseAmount).As("s")
                    ).From(dbo.Purchase);

                //when               
                var s = exp.Execute();

                //then
                s.Should().BeApproximately(expectedValue, 0.001M, "Rounding errors in calculation of standard deviation");
            }

            [Theory]
            [InlineData(2014, 16.425)]
            public void Does_standard_deviation_of_distinct_total_purchase_amount_succeed(int version, decimal expectedValue)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.StDev(dbo.Purchase.TotalPurchaseAmount, distinct: true).As("s")
                    ).From(dbo.Purchase);

                //when               
                var s = exp.Execute();

                //then
                s.Should().BeApproximately(expectedValue, 0.001M, "Rounding errors in calculation of standard deviation");
            }
        }

        [Trait("Function", "STDEVP")]
        public partial class StandardDeviationPopulation : ExecutorTestBase
        {
            [Theory]
            [InlineData(2012, 15.599)]
            [InlineData(2014, 15.599)]
            public void Does_standard_deviation_of_total_purchase_amount_succeed(int version, decimal expectedValue)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.StDevP(dbo.Purchase.TotalPurchaseAmount).As("s")
                    ).From(dbo.Purchase);

                //when               
                var s = exp.Execute();

                //then
                s.Should().BeApproximately(expectedValue, 0.001M, "Rounding errors in calculation of standard deviation");
            }

            [Theory]
            [InlineData(2012, 15.827)]
            [InlineData(2014, 15.827)]
            public void Does_standard_deviation_of_distinct_total_purchase_amount_succeed(int version, decimal expectedValue)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.StDevP(dbo.Purchase.TotalPurchaseAmount, distinct: true).As("s")
                    ).From(dbo.Purchase);

                //when               
                var s = exp.Execute();

                //then
                s.Should().BeApproximately(expectedValue, 0.001M, "Rounding errors in calculation of standard deviation");
            }
        }

        [Trait("Function", "VAR")]
        public partial class Var : ExecutorTestBase
        {
            [Theory]
            [InlineData(2012, 260.712)]
            [InlineData(2014, 260.712)]
            public void Does_var_of_total_purchase_amount_succeed(int version, decimal expectedValue)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.Var(dbo.Purchase.TotalPurchaseAmount).As("s")
                    ).From(dbo.Purchase);

                //when               
                var s = exp.Execute();

                //then
                s.Should().BeApproximately(expectedValue, 0.001M, "Rounding errors in calculation of standard deviation of population");
            }

            [Theory]
            [InlineData(2012, 269.785)]
            [InlineData(2014, 269.785)]
            public void Does_var_of_distinct_total_purchase_amount_succeed(int version, decimal expectedValue)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.Var(dbo.Purchase.TotalPurchaseAmount, distinct: true).As("s")
                    ).From(dbo.Purchase);

                //when               
                var s = exp.Execute();

                //then
                s.Should().BeApproximately(expectedValue, 0.001M, "Rounding errors in calculation of standard deviation of population");
            }
        }

        [Trait("Function", "VARP")]
        public partial class VariancePopulation : ExecutorTestBase
        {
            [Theory]
            [InlineData(2012, 243.331)]
            [InlineData(2014, 243.331)]
            public void Does_varp_of_total_purchase_amount_succeed(int version, decimal expectedValue)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.VarP(dbo.Purchase.TotalPurchaseAmount).As("s")
                    ).From(dbo.Purchase);

                //when               
                var s = exp.Execute();

                //then
                s.Should().BeApproximately(expectedValue, 0.001M, "Rounding errors in calculation of variance of population");
            }

            [Theory]
            [InlineData(2012, 250.515)]
            [InlineData(2014, 250.515)]
            public void Does_varp_of_distinct_total_purchase_amount_succeed(int version, decimal expectedValue)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.VarP(dbo.Purchase.TotalPurchaseAmount, distinct: true).As("s")
                    ).From(dbo.Purchase);

                //when               
                var s = exp.Execute();

                //then
                s.Should().BeApproximately(expectedValue, 0.001M, "Rounding errors in calculation of variance of population");
            }
        }
    }
}
