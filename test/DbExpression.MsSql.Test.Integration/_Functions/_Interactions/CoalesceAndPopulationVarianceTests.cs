using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Function", "COALESCE")]
    [Trait("Function", "VARP")]
    public partial class CoalesceAndPopulationVarianceTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(127305176f)]
        public void Does_selecting_coalesce_of_populationvariance_of_credit_limit_and_static_value_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Coalesce<float>(db.fx.VarP(dbo.Person.CreditLimit), 1f)
                ).From(dbo.Person);

            //when               
            object result = exp.Execute();

            //then
            result.Should().BeOfType<float>().Which.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [InlineData(193952740f)]
        public void Does_selecting_populationvariance_of_coalesce_of_credit_limit_and_static_value_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.VarP(db.fx.Coalesce<int>(dbo.Person.CreditLimit, 1))
                ).From(dbo.Person);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [InlineData(127305176f)]
        public void Does_selecting_coalesce_of_populationvariance_of_credit_limit_and_year_of_last_credit_review_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Coalesce<float?>(db.fx.VarP(dbo.Person.CreditLimit), db.fx.VarP(dbo.Person.YearOfLastCreditLimitReview))
                ).From(dbo.Person);

            //when               
            object? result = exp.Execute();

            //then
            result.Should().BeAssignableTo<float?>().Which.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [InlineData(127305176f)]
        public void Does_selecting_populationvariance_of_coalesce_of_credit_limit_and_year_of_last_credit_review_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.VarP(db.fx.Coalesce<int?>(dbo.Person.CreditLimit, dbo.Person.YearOfLastCreditLimitReview))
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [InlineData(127305176f)]
        public void Does_selecting_coalesce_of_populationvariance_of_credit_limit_and_null_static_value_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Coalesce<float?>(db.fx.VarP(dbo.Person.CreditLimit), (float?)null!)
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [InlineData(127305176f)]
        public void Does_selecting_populationvariance_of_coalesce_of_credit_limit_and_null_static_value_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.VarP(db.fx.Coalesce<int?>(dbo.Person.CreditLimit, (int?)null!))
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }
    }
}
