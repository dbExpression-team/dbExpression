using DbEx.Data;
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
    [Trait("Function", "AVG")]
    public partial class CoalesceAndAverageTests : ResetDatabaseNotRequired
    {
        [Theory]
        [InlineData(1)]
        public void Does_selecting_coalesce_of_average_of_credit_limit_and_static_value_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce<int>(db.fx.Avg(dbo.Person.CreditLimit), 1)
                ).From(dbo.Person);

            //when               
            IEnumerable<int> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData(5)]
        public void Does_selecting_coalesce_of_average_of_credit_limit_and_credit_limit_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce<int?>(db.fx.Avg(dbo.Person.CreditLimit), dbo.Person.CreditLimit)
                ).From(dbo.Person)
                .GroupBy(dbo.Person.CreditLimit);

            //when               
            IEnumerable<int?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [Trait("Operation", "GROUP BY")]
        [InlineData(50)]
        public void Does_selecting_coalesce_of_average_of_credit_limit_and_person_id_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Coalesce<int?>(db.fx.Avg(dbo.Person.CreditLimit), dbo.Person.Id)
                ).From(dbo.Person)
                .GroupBy(dbo.Person.Id);

            //when               
            IEnumerable<int?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(1)]
        public void Does_selecting_average_of_coalesce_of_credit_limit_and_credit_limit_succeed(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp = db.SelectMany(
                    db.fx.Avg(db.fx.Coalesce<int?>(dbo.Person.CreditLimit, dbo.Person.CreditLimit))
                ).From(dbo.Person);

            //when               
            IEnumerable<int?> results = exp.Execute();

            //then
            results.Should().HaveCount(expected);
        }
    }
}
