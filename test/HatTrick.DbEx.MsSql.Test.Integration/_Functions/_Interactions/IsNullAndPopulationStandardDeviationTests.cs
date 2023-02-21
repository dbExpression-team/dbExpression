using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Function", "ISNULL")]
    [Trait("Function", "STDEVP")]
    public partial class IsNullAndPopulationStandardDeviationTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(11282.96f)]
        public void Does_selecting_isnull_of_standarddeviationpopulation_of_credit_limit_and_static_value_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.IsNull(db.fx.StDevP(dbo.Person.CreditLimit), 1.0f)
                ).From(dbo.Person);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .01f);
        }

        [Theory]
        [InlineData(13926.691f)]
        public void Does_selecting_standarddeviationpopulation_of_isnull_of_credit_limit_and_static_value_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.StDevP(db.fx.IsNull(dbo.Person.CreditLimit, 1))
                ).From(dbo.Person);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .01f);
        }


        [Theory]
        [InlineData(11282.96f)]
        public void Does_selecting_isnull_of_standarddeviationpopulation_of_credit_limit_and_year_of_last_credit_limit_review_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.IsNull(db.fx.StDevP(dbo.Person.CreditLimit), db.fx.StDevP(dbo.Person.YearOfLastCreditLimitReview))
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .01f);
        }

        [Theory]
        [InlineData(11282.96f)]
        public void Does_selecting_standarddeviationpopulation_of_isnull_of_credit_limit_and_year_of_last_credit_limit_review_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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
