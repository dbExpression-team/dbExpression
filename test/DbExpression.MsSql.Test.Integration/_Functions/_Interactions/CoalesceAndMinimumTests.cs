using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System.Collections.Generic;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Function", "COALESCE")]
    [Trait("Function", "MIN")]
    public partial class CoalesceAndMinimumTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(10000)]
        public void Does_selecting_coalesce_of_min_of_credit_limit_and_static_value_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Coalesce(db.fx.Min(dbo.Person.CreditLimit), 1)
                ).From(dbo.Person);

            //when               
            object? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData(50)]
        public void Does_selecting_coalesce_of_min_of_credit_limit_and_person_id_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce(db.fx.Min(dbo.Person.CreditLimit), dbo.Person.Id)
                ).From(dbo.Person)
                .GroupBy(dbo.Person.Id);

            //when               
            IEnumerable<object?> result = exp.Execute();

            //then
            result.Should().HaveCount(expected);
        }


        [Theory]
        [InlineData(1)]
        public void Does_selecting_min_of_coalesce_of_credit_limit_and_static_value_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Min(db.fx.Coalesce<int>(dbo.Person.CreditLimit, 1))
                ).From(dbo.Person);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(42)]
        public void Does_selecting_min_of_coalesce_of_credit_limit_and_person_id_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Min(db.fx.Coalesce<int>(dbo.Person.CreditLimit, dbo.Person.Id))
                ).From(dbo.Person);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(10000)]
        public void Does_selecting_min_of_coalesce_of_quantity_and_year_of_last_credit_limit_review_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Min(db.fx.Coalesce<int?>(dbo.Person.CreditLimit, dbo.Person.YearOfLastCreditLimitReview))
                ).From(dbo.Person);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }
    }
}
