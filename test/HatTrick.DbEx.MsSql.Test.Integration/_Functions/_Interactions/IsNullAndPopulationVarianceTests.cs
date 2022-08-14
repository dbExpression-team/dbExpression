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
    [Trait("Function", "VARP")]
    public partial class IsNullAndPopulationVarianceTests : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_isnull_of_populationvariance_of_credit_limit_succeed(int version, float expected = 127305176f)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectOne(
                    db.fx.IsNull(db.fx.VarP(dbo.Person.CreditLimit), 1f)
                ).From(dbo.Person);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .001f);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_populationvariance_of_isnull_of_credit_limit_succeed(int version, float expected = 193952740f)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectOne(
                    db.fx.VarP(db.fx.IsNull(dbo.Person.CreditLimit, 1))
                ).From(dbo.Person);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .001f);
        }


        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_isnull_of_populationvariance_of_credit_limit_and_populationvariance_of_year_of_last_credit_limit_review_succeed(int version, float expected = 127305176f)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectOne(
                    db.fx.IsNull(db.fx.VarP(dbo.Person.CreditLimit), db.fx.VarP(dbo.Person.YearOfLastCreditLimitReview))
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .001f);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_populationvariance_of_isnull_of_credit_limit_and_year_of_last_credit_limit_reviewsucceed(int version, float expected = 127305176f)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            var exp = db.SelectOne(
                    db.fx.VarP(db.fx.IsNull(dbo.Person.CreditLimit, dbo.Person.YearOfLastCreditLimitReview))
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .001f);
        }
    }
}
