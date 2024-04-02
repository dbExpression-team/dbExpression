using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Function", "ISNULL")]
    [Trait("Function", "VARP")]
    public partial class IsNullAndPopulationVarianceTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(127305176f)]
        public void Does_selecting_isnull_of_populationvariance_of_credit_limit_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.IsNull(db.fx.VarP(dbo.Person.CreditLimit), 1f)
                ).From(dbo.Person);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .001f);
        }

        [Theory]
        [InlineData(193952740f)]
        public void Does_selecting_populationvariance_of_isnull_of_credit_limit_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.VarP(db.fx.IsNull(dbo.Person.CreditLimit, 1))
                ).From(dbo.Person);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .001f);
        }


        [Theory]
        [InlineData(127305176f)]
        public void Does_selecting_isnull_of_populationvariance_of_credit_limit_and_populationvariance_of_year_of_last_credit_limit_review_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.IsNull(db.fx.VarP(dbo.Person.CreditLimit), db.fx.VarP(dbo.Person.YearOfLastCreditLimitReview))
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .001f);
        }

        [Theory]
        [InlineData(127305176f)]
        public void Does_selecting_populationvariance_of_isnull_of_credit_limit_and_year_of_last_credit_limit_reviewsucceed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
