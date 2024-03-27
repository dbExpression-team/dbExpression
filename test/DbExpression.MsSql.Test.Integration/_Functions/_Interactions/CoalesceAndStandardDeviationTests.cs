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
    [Trait("Function", "STDEV")]
    public partial class CoalesceAndStandardDeviationTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(11423.126f)]
        public void Does_selecting_coalesce_of_standarddeviation_of_credit_limit_and_static_value_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Coalesce<float>(db.fx.StDev(dbo.Person.CreditLimit), 1f)
                ).From(dbo.Person);

            //when               
            object result = exp.Execute();

            //then
            result.Should().BeOfType<float>().Which.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [InlineData(14068.083f)]
        public void Does_selecting_standarddeviation_of_coalesce_of_credit_limit_and_static_value_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.StDev(db.fx.Coalesce<int>(dbo.Person.CreditLimit, 1))
                ).From(dbo.Person);

            //when               
            float result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [InlineData(11423.126f)]
        public void Does_selecting_coalesce_of_standarddeviation_of_credit_limit_and_year_of_last_credit_review_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Coalesce(db.fx.StDev(dbo.Person.CreditLimit), db.fx.StDev(dbo.Person.YearOfLastCreditLimitReview))
                ).From(dbo.Person);

            //when               
            float? result = Convert.ToSingle(exp.Execute());

            //then
            result.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [InlineData(11423.126f)]
        public void Does_selecting_standarddeviation_of_coalesce_of_credit_limit_and_year_of_last_credit_review_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.StDev(db.fx.Coalesce<int?>(dbo.Person.CreditLimit, dbo.Person.YearOfLastCreditLimitReview))
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [InlineData(11423.126f)]
        public void Does_selecting_coalesce_of_standarddeviation_of_credit_limit_and_null_static_value_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Coalesce<float?>(db.fx.StDev(dbo.Person.CreditLimit), (float?)null!)
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [InlineData(11423.126f)]
        public void Does_selecting_standarddeviation_of_coalesce_of_credit_limit_and_null_static_value_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.StDev(db.fx.Coalesce<int?>(dbo.Person.CreditLimit, (int?)null!))
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }
    }
}
