using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Function", "COALESE")]
    [Trait("Function", "VARP")]
    public partial class CoalesceAndPopulationVariance : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_populationvariance_of_credit_limit_and_static_value_succeed(int version, float expected = 127305176f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Coalesce(db.fx.VarP(dbo.Person.CreditLimit), 1f)
                ).From(dbo.Person);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_populationvariance_of_coalesce_of_credit_limit_and_static_value_succeed(int version, float expected = 193952740f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.VarP(db.fx.Coalesce(dbo.Person.CreditLimit, 1))
                ).From(dbo.Person);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_populationvariance_of_credit_limit_and_year_of_last_credit_review_succeed(int version, float expected = 127305176f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Coalesce(db.fx.VarP(dbo.Person.CreditLimit), db.fx.VarP(dbo.Person.YearOfLastCreditLimitReview))
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_populationvariance_of_coalesce_of_credit_limit_and_year_of_last_credit_review_succeed(int version, float expected = 127305176f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.VarP(db.fx.Coalesce(dbo.Person.CreditLimit, dbo.Person.YearOfLastCreditLimitReview))
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_coalesce_of_populationvariance_of_credit_limit_and_null_static_value_succeed(int version, float expected = 127305176f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.Coalesce(db.fx.VarP(dbo.Person.CreditLimit), (float?)null)
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_populationvariance_of_coalesce_of_credit_limit_and_null_static_value_succeed(int version, float expected = 127305176f)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.VarP(db.fx.Coalesce(dbo.Person.CreditLimit, (int?)null))
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }
    }
}
