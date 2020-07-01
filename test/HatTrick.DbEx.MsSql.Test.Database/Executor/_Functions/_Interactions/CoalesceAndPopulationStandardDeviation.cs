using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Function", "COALESECE")]
    [Trait("Function", "STDEVP")]
    public partial class CoalesceAndPopulationStandardDeviation : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_standarddeviationpopulation_of_credit_limit_and_static_value_succeed(int version, float expected = 11282.96f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Coalesce(db.fx.StDevP(dbo.Person.CreditLimit), 1f)
                ).From(dbo.Person);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_standarddeviationpopulation_of_coalesce_of_credit_limit_and_static_value_succeed(int version, float expected = 13926.691f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.StDevP(db.fx.Coalesce(dbo.Person.CreditLimit, 1))
                ).From(dbo.Person);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_standarddeviationpopulation_of_credit_limit_and_year_of_last_credit_review_succeed(int version, float expected = 11282.96f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Coalesce(db.fx.StDevP(dbo.Person.CreditLimit), db.fx.StDevP(dbo.Person.YearOfLastCreditLimitReview))
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_standarddeviationpopulation_of_coalesce_of_credit_limit_and_year_of_last_credit_review_succeed(int version, float expected = 11282.96f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.StDevP(db.fx.Coalesce(dbo.Person.CreditLimit, dbo.Person.YearOfLastCreditLimitReview))
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_standarddeviationpopulation_of_credit_limit_and_null_static_value_succeed(int version, float expected = 11282.96f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Coalesce(db.fx.StDevP(dbo.Person.CreditLimit), (float?)null)
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_standarddeviationpopulation_of_coalesce_of_credit_limit_and_null_static_value_succeed(int version, float expected = 11282.96f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.StDevP(db.fx.Coalesce(dbo.Person.CreditLimit, (int?)null))
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }
    }
}
