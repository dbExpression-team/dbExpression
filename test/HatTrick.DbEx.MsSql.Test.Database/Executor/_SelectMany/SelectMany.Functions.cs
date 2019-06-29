using DbEx.Data;
using DbEx.Data.dbo;
using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Extensions.Builder;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public partial class SelectMany
    {
        [Trait("Function", "CAST")]
        public partial class Cast : ExecutorTestBase
        {
            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_selecting_cast_of_ship_date_to_varchar_succeed(int version, int expectedCount = 15)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany<string>(
                        db.fx.Cast(dbo.Purchase.ShipDate).AsVarChar(50)
                    ).From(dbo.Purchase);

                //when               
                var datesAsStrings = exp.Execute();

                //then
                datesAsStrings.Should().HaveCount(expectedCount);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_selecting_multiple_fields_and_casting_ship_date_to_varchar_succeed(int version, int expectedCount = 15)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany(
                        dbo.Purchase.Id,
                        db.fx.Cast(dbo.Purchase.ShipDate).AsVarChar(50)
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
            [MsSqlVersions.AllVersions]
            public void Does_coalesceing_ship_date_and_purchase_date_succeed(int version, int expectedCount = 15)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany<DateTime>(
                        db.fx.Coalesce(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).As("relevant_date")
                    ).From(dbo.Purchase);

                //when               
                var dates = exp.Execute();

                //then
                dates.Should().HaveCount(expectedCount);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_coalesceing_all_product_dates_succeed(int version, int expectedCount = 15)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany<DateTime>(
                        db.fx.Coalesce(
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
            [MsSqlVersions.AllVersions]
            public void Does_coalesceing_all_product_dates_and_returning_total_purchase_amount_succeed(int version, int expectedCount = 15)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany(
                        dbo.Purchase.TotalPurchaseAmount,
                        db.fx.Coalesce(
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
            [MsSqlVersions.AllVersions]
            [Trait("Expression", "Arithmetic")]
            public void Does_coalesceing_all_product_dates_including_arithmetic_and_returning_total_purchase_amount_succeed(int version, int expectedCount = 15)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany(
                        dbo.Purchase.TotalPurchaseAmount,
                        db.fx.Coalesce(
                            dbo.Purchase.ShipDate,
                            dbo.Purchase.PurchaseDate,
                            db.fx.GetDate() + dbo.Purchase.PurchaseDate,
                            db.fx.Literal(DateTime.Now) + dbo.Purchase.DateCreated,
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
            [MsSqlVersions.AllVersions]
            public void Does_isnull_ship_date_and_purchase_date_succeed(int version, int expectedCount = 15)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany<DateTime>(
                        db.fx.IsNull(dbo.Purchase.ShipDate, dbo.Purchase.PurchaseDate).As("relevant_date")
                    ).From(dbo.Purchase);

                //when               
                var dates = exp.Execute();

                //then
                dates.Should().HaveCount(expectedCount);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_isnull_of_shipdate_succeed(int version, int expectedCount = 15)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany<DateTime>(
                        db.fx.IsNull(
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
            [MsSqlVersions.AllVersions]
            public void Does_isnull_all_product_dates_and_returning_total_purchase_amount_succeed(int version, int expectedCount = 15)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany(
                        dbo.Purchase.TotalPurchaseAmount,
                        db.fx.IsNull(
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
            [MsSqlVersions.AllVersions]
            [Trait("Expression", "Arithmetic")]
            public void Does_isnull_all_product_dates_including_arithmetic_and_returning_total_purchase_amount_succeed(int version, int expectedCount = 15)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany(
                        dbo.Purchase.TotalPurchaseAmount,
                        db.fx.IsNull(
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
            [MsSqlVersions.AllVersions]
            public void Does_isnull_persons_gender_succeed(int version, int expectedCount = 50)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany(
                        dbo.Person.Id,
                        db.fx.IsNull(
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
            [MsSqlVersions.AllVersions]
            public void Does_isnull_address_type_succeed(int version, int expectedCount = 32)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectMany(
                        dbo.Address.Id,
                        db.fx.IsNull(
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
            [MsSqlVersions.AllVersions]
            public void Does_averaging_total_purchase_amount_succeed(int version, decimal expectedValue = 20.543M)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.fx.Avg(dbo.Purchase.TotalPurchaseAmount).As("avg_amount")
                    ).From(dbo.Purchase);

                //when               
                var average = exp.Execute();

                //then
                average.Should().BeApproximately(expectedValue, 0.001M, "Rounding errors in averaging");
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_averaging_distinct_total_purchase_amount_succeed(int version, decimal expectedValue = 21.367M)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.fx.Avg(dbo.Purchase.TotalPurchaseAmount, distinct:true).As("avg_amount")
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
            [MsSqlVersions.AllVersions]
            public void Does_selecting_minimum_total_purchase_amount_succeed(int version, decimal expectedValue = 5.11M)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.fx.Min(dbo.Purchase.TotalPurchaseAmount).As("min_amount")
                    ).From(dbo.Purchase);

                //when               
                var min = exp.Execute();

                //then
                min.Should().Be(expectedValue);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_selecting_minimum_distinct_total_purchase_amount_succeed(int version, decimal expectedValue = 5.11M)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.fx.Min(dbo.Purchase.TotalPurchaseAmount, distinct: true).As("min_amount")
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
            [MsSqlVersions.AllVersions]
            public void Does_selecting_maximum_total_purchase_amount_succeed(int version, decimal expectedValue = 55.96M)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.fx.Max(dbo.Purchase.TotalPurchaseAmount).As("max_amount")
                    ).From(dbo.Purchase);

                //when               
                var max = exp.Execute();

                //then
                max.Should().Be(expectedValue);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_selecting_maximum_distinct_total_purchase_amount_succeed(int version, decimal expectedValue = 55.96M)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.fx.Max(dbo.Purchase.TotalPurchaseAmount, distinct: true).As("max_amount")
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
            [MsSqlVersions.AllVersions]
            public void Does_selecting_count_of_personid_succeed(int version, int expectedValue = 15)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<int>(
                        db.fx.Count(dbo.Purchase.PersonId).As("count")
                    ).From(dbo.Purchase);

                //when               
                var count = exp.Execute();

                //then
                count.Should().Be(expectedValue);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_selecting_count_of_distinct_personid_succeed(int version, int expectedValue = 6)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<int>(
                        db.fx.Count(dbo.Purchase.PersonId, distinct: true).As("count")
                    ).From(dbo.Purchase);

                //when               
                var max = exp.Execute();

                //then
                max.Should().Be(expectedValue);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_selecting_count_of_star_succeed(int version, int expectedValue = 15)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<int>(
                        db.fx.Count()
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
            [MsSqlVersions.AllVersions]
            public void Does_sum_of_total_purchase_amount_succeed(int version, decimal expectedValue = 308.15M)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.fx.Sum(dbo.Purchase.TotalPurchaseAmount).As("sum")
                    ).From(dbo.Purchase);

                //when               
                var sum = exp.Execute();

                //then
                sum.Should().Be(expectedValue);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_sum_of_distinct_total_purchase_amount_succeed(int version, decimal expectedValue = 299.15M)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.fx.Sum(dbo.Purchase.TotalPurchaseAmount, distinct: true).As("sum")
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
            [MsSqlVersions.AllVersions]
            public void Does_standard_deviation_of_total_purchase_amount_succeed(int version, decimal expectedValue = 16.146M)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.fx.StDev(dbo.Purchase.TotalPurchaseAmount).As("s")
                    ).From(dbo.Purchase);

                //when               
                var s = exp.Execute();

                //then
                s.Should().BeApproximately(expectedValue, 0.001M, "Rounding errors in calculation of standard deviation");
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_standard_deviation_of_distinct_total_purchase_amount_succeed(int version, decimal expectedValue = 16.425M)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.fx.StDev(dbo.Purchase.TotalPurchaseAmount, distinct: true).As("s")
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
            [MsSqlVersions.AllVersions]
            public void Does_standard_deviation_of_total_purchase_amount_succeed(int version, decimal expectedValue = 15.599M)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.fx.StDevP(dbo.Purchase.TotalPurchaseAmount).As("s")
                    ).From(dbo.Purchase);

                //when               
                var s = exp.Execute();

                //then
                s.Should().BeApproximately(expectedValue, 0.001M, "Rounding errors in calculation of standard deviation");
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_standard_deviation_of_distinct_total_purchase_amount_succeed(int version, decimal expectedValue = 15.827M)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.fx.StDevP(dbo.Purchase.TotalPurchaseAmount, distinct: true).As("s")
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
            [MsSqlVersions.AllVersions]
            public void Does_var_of_total_purchase_amount_succeed(int version, decimal expectedValue = 260.712M)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.fx.Var(dbo.Purchase.TotalPurchaseAmount).As("s")
                    ).From(dbo.Purchase);

                //when               
                var s = exp.Execute();

                //then
                s.Should().BeApproximately(expectedValue, 0.001M, "Rounding errors in calculation of standard deviation of population");
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_var_of_distinct_total_purchase_amount_succeed(int version, decimal expectedValue = 269.785M)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.fx.Var(dbo.Purchase.TotalPurchaseAmount, distinct: true).As("s")
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
            [MsSqlVersions.AllVersions]
            public void Does_varp_of_total_purchase_amount_succeed(int version, decimal expectedValue = 243.331M)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.fx.VarP(dbo.Purchase.TotalPurchaseAmount).As("s")
                    ).From(dbo.Purchase);

                //when               
                var s = exp.Execute();

                //then
                s.Should().BeApproximately(expectedValue, 0.001M, "Rounding errors in calculation of variance of population");
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_varp_of_distinct_total_purchase_amount_succeed(int version, decimal expectedValue = 250.515M)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<decimal>(
                        db.fx.VarP(dbo.Purchase.TotalPurchaseAmount, distinct: true).As("s")
                    ).From(dbo.Purchase);

                //when               
                var s = exp.Execute();

                //then
                s.Should().BeApproximately(expectedValue, 0.001M, "Rounding errors in calculation of variance of population");
            }
        }

        [Trait("Function", "DATEPART")]
        public partial class DatePart : ExecutorTestBase
        {
            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_datepart_selecting_year_of_shipdate_succeed(int version, int expectedValue = 2017)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<int>(
                        db.fx.DatePart(DateParts.Year, dbo.Purchase.DateCreated).As("s")
                    ).From(dbo.Purchase)
                    .Where(dbo.Purchase.ShipDate != null);

                //when               
                var s = exp.Execute();

                //then
                s.Should().Be(expectedValue);
            }

            [Theory]
            [MsSqlVersions.AllVersions]
            public void Does_datepart_selecting_day_of_shipdate_succeed(int version, int expectedValue = 1)
            {
                //given
                ConfigureForMsSqlVersion(version);

                var exp = db.SelectOne<int>(
                        db.fx.DatePart(DateParts.Day, dbo.Purchase.DateCreated).As("s")
                    ).From(dbo.Purchase)
                    .Where(dbo.Purchase.ShipDate != null);

                //when               
                var s = exp.Execute();

                //then
                s.Should().Be(expectedValue);
            }
        }
    }
}
