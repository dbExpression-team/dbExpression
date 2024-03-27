using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using System;
using System.Collections.Generic;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    [Trait("Function", "COALESCE")]
    [Trait("Function", "SUM")]
    public partial class CoalesceAndSumTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(1010000)]
        public void Does_selecting_coalesce_of_sum_of_credit_limit_and_static_value_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Coalesce<float>(db.fx.Sum(dbo.Person.CreditLimit), 1)
                ).From(dbo.Person);

            //when               
            object result = exp.Execute();

            //then
            result.Should().BeOfType<float>().Which.Should().Be(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData(50)]
        public void Does_selecting_coalesce_of_sum_of_credit_limit_and_person_id_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce<int?>(db.fx.Sum(dbo.Person.CreditLimit), dbo.Person.Id)
                ).From(dbo.Person)
                .GroupBy(dbo.Person.Id);

            //when               
            IEnumerable<int?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        
        [Theory]
        [InlineData(1010009)]
        public void Does_selecting_sum_of_coalesce_of_credit_limit_and_static_value_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Sum(db.fx.Coalesce<int>(dbo.Person.CreditLimit, 1))
                ).From(dbo.Person);

            //when               
            int result = exp.Execute();

            //then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(1010414)]
        public void Does_selecting_sum_of_coalesce_of_credit_limit_and_person_id_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectOne(
                    db.fx.Sum(db.fx.Coalesce<int>(dbo.Person.CreditLimit, dbo.Person.Id))
                ).From(dbo.Person);

            //when               
            int? result = exp.Execute();

            //then
            result.Should().Be(expected);
        }
    }
}
