using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Function", "ISNULL")]
    [Trait("Function", "STDEVP")]
    public partial class IsNullAndPopulationStandardDeviation : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_isnull_of_standarddeviationpopulation_of_credit_limit_and_static_value_succeed(int version, float expected = 11282.96f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.IsNull(db.fx.StDevP(dbo.Person.CreditLimit), 1.0f)
                ).From(dbo.Person);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .01f);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_standarddeviationpopulation_of_isnull_of_credit_limit_and_static_value_succeed(int version, float expected = 13926.691f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.StDevP(db.fx.IsNull(dbo.Person.CreditLimit, 1))
                ).From(dbo.Person);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .01f);
        }


        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_isnull_of_standarddeviationpopulation_of_credit_limit_and_year_of_last_credit_limit_review_succeed(int version, float expected = 11282.96f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.IsNull(db.fx.StDevP(dbo.Person.CreditLimit), db.fx.StDevP(dbo.Person.YearOfLastCreditLimitReview))
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .01f);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_standarddeviationpopulation_of_isnull_of_credit_limit_and_year_of_last_credit_limit_review_succeed(int version, float expected = 11282.96f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.StDevP(db.fx.IsNull(dbo.Person.CreditLimit, dbo.Person.YearOfLastCreditLimitReview))
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .01f);
        }
    }
}
