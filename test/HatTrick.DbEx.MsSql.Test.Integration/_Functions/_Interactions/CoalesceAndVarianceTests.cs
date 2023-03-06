using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Function", "COALESCE")]
    [Trait("Function", "VAR")]
    public partial class CoalesceAndVarianceTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(130487810f)]
        public void Does_selecting_coalesce_of_variance_of_credit_limit_and_static_value_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Coalesce<float>(db.fx.Var(dbo.Person.CreditLimit), 1f)
                ).From(dbo.Person);

            //when               
            object result = exp.Execute();

            //then
            result.Should().BeOfType<float>().Which.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [InlineData(197910940f)]
        public void Does_selecting_variance_of_coalesce_of_credit_limit_and_static_value_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Var(db.fx.Coalesce<int>(dbo.Person.CreditLimit, 1))
                ).From(dbo.Person);

            //when               
            float result = Convert.ToSingle(exp.Execute());

            //then
            result.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [InlineData(130487810f)]
        public void Does_selecting_coalesce_of_variance_of_credit_limit_and_year_of_last_credit_review_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Coalesce<float?>(db.fx.Var(dbo.Person.CreditLimit), db.fx.Var(dbo.Person.YearOfLastCreditLimitReview))
                ).From(dbo.Person);

            //when               
            object? result = exp.Execute();

            //then
            result.Should().BeAssignableTo<float?>().Which.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [InlineData(130487810f)]
        public void Does_selecting_variance_of_coalesce_of_credit_limit_and_year_of_last_credit_review_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Var(db.fx.Coalesce<int?>(dbo.Person.CreditLimit, dbo.Person.YearOfLastCreditLimitReview))
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [InlineData(130487810f)]
        public void Does_selecting_coalesce_of_variance_of_credit_limit_and_null_static_value_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Coalesce<float?>(db.fx.Var(dbo.Person.CreditLimit), (float?)null!)
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }

        [Theory]
        [InlineData(130487810f)]
        public void Does_selecting_variance_of_coalesce_of_credit_limit_and_null_static_value_succeed(float expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Var(db.fx.Coalesce<int?>(dbo.Person.CreditLimit, (int?)null!))
                ).From(dbo.Person);

            //when               
            float? result = exp.Execute();

            //then
            result.Should().BeApproximately(expected, .0001f);
        }
    }
}
