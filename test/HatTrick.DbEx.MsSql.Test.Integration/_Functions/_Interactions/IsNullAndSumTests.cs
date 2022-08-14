using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Function", "ISNULL")]
    [Trait("Function", "SUM")]
    public partial class IsNullAndSumTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_isnull_of_sum_of_credit_limit_and_static_value_succeed(int version, int expected = 1010000)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectOne(
                    db.fx.IsNull(db.fx.Sum(dbo.Person.CreditLimit), 1)
                ).From(dbo.Person);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_sum_of_isnull_of_credit_limit_and_static_value_succeed(int version, int expected = 1010009)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectOne(
                    db.fx.Sum(db.fx.IsNull(dbo.Person.CreditLimit, 1))
                ).From(dbo.Person);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        [Trait("Operation", "GROUP BY")]
        public void Does_selecting_isnull_of_sum_of_credit_limit_and_year_of_last_credit_limit_review_succeed(int version, int expected = 700000)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectOne(
                    db.fx.IsNull(db.fx.Sum(dbo.Person.CreditLimit), dbo.Person.YearOfLastCreditLimitReview)
                ).From(dbo.Person)
                .GroupBy(dbo.Person.YearOfLastCreditLimitReview);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_sum_of_isnull_of_credit_limit_and_year_of_last_credit_limit_review_succeed(int version, int expected = 1010000)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectOne(
                    db.fx.Sum(db.fx.IsNull(dbo.Person.CreditLimit, dbo.Person.YearOfLastCreditLimitReview))
                ).From(dbo.Person);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }
    }
}
